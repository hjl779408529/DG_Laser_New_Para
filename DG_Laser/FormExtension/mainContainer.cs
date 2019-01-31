using netDxf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DG_Laser
{
    /// <summary>
    /// main操作页面
    /// </summary>
    partial class MainForm
    {
        //定义启动按钮触发
        public static ValueChangeEvent Start_Button = new ValueChangeEvent();
        //CAM加工数据解析
        Cam_Data_Resolve Cam_Data_Cal = new Cam_Data_Resolve();
        //CAM辅助加工数据集合
        List<Entity_Data> Mark_Circle_Entity_Data = new List<Entity_Data>();//mark 点数据收集
        List<List<List<Interpolation_Data>>> Cam_Drill_Data = new List<List<List<Interpolation_Data>>>();
        List<List<List<Interpolation_Data>>> Cam_Arc_Data = new List<List<List<Interpolation_Data>>>();
        List<List<List<Interpolation_Data>>> Cam_Line_Data = new List<List<List<Interpolation_Data>>>();
        List<List<List<Interpolation_Data>>> Cam_LWPolyLine_Data = new List<List<List<Interpolation_Data>>>();
        //CAM加工数据解析
        List<List<List<Interpolation_Data>>> Cam_Drill_Work_Data = new List<List<List<Interpolation_Data>>>();
        List<List<List<Interpolation_Data>>> Cam_Arc_Work_Data = new List<List<List<Interpolation_Data>>>();
        List<List<List<Interpolation_Data>>> Cam_Line_Work_Data = new List<List<List<Interpolation_Data>>>();
        List<List<List<Interpolation_Data>>> Cam_LWPolyLine_Work_Data = new List<List<List<Interpolation_Data>>>();
        //加工过程
        private bool Cam_Working = false;//加工ing标志
        private int Work_Type_No = 0;//工作模式序号
        //加工方式序号选择
        string[] Methods_List =
        {
            "振镜空白和平台未补偿",
            "振镜仿射和平台未补偿",
            "振镜仿射和平台已补偿",
            "振镜旋转和平台已补偿",
            "振镜矩阵和平台已补偿",
            "振镜桶形畸变图形加工",
            "振镜桶形畸变数据采集",
            "振镜仿射矩阵图形加工",
            "振镜仿射矩阵数据采集",
            "Mark坐标定位矫正",
            "Mark坐标定位重矫正",
            "相机坐标系标定(打标)",
            "相机坐标系标定(标定板)",
            "矫正振镜坐标系偏转角",
            "振镜与ORG距离校准",
            "坐标系原点坐标校准",
            "计算标定板旋转参数",
            "标定板原始校准数据",
            "标定板二次校准验证",
            "振镜空白和平台已补偿"
        };

        /// <summary>
        /// 主页界面初始化
        /// </summary>
        private void mainContainerInitial()
        {
            //Back坐标
            BackX.Text = Program.SystemContainer.SysPara.Upload_Point.X.ToString();
            BackY.Text = Program.SystemContainer.SysPara.Upload_Point.Y.ToString();

            //选择起始加工位置
            Start_Pos_Sel.SelectedIndex = Program.SystemContainer.SysPara.Calibration_Type;

            //加工方式选择
            Work_Type_Select_List.SelectedIndex = Program.SystemContainer.SysPara.Work_Type_Select;

            //回退位置选择
            Back_Pos_Select.SelectedIndex = Program.SystemContainer.SysPara.Upload_Type_Select;

            //按钮变化出发的事件
            Start_Button.Greater_Than_Change += Cam_Start_Work_Thread;

            //绑定Cam_Data_Cal的日志事件
            Cam_Data_Cal.LogInfo += new LogInfo(Info);

            //直角坐标系状态建立、定位坐标点、加工启动、加工停止等按钮状态刷新
            if (Program.SystemContainer.IO.Gts_Home_Flag)
            {
                EstablishCoordinate.Enabled = true;
                GoPoint.Enabled = true;
                Cam_Work_Start.Enabled = true;
                Cam_Work_Stop.Enabled = true;
            }
            else
            {
#if !DEBUG
                EstablishCoordinate.Enabled = false;
                GoPoint.Enabled = false;
                Cam_Work_Start.Enabled = false;
                Cam_Work_Stop.Enabled = false;
#endif
            }

        }
        /// <summary>
        /// 日志记录带时间戳
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        public void appendInfo(string info)
        {
            this.Invoke((EventHandler)delegate
            {
                Debug_Info_Display.AppendText(Cal_Elapse_Time.Get_Current_Time(1) + "\r\n");
                Debug_Info_Display.AppendText(info + "\r\n");
            });            
        }
        /// <summary>
        /// 日志记录
        /// </summary>
        /// <param name="info"></param>
        public void Info(string info)
        {
            this.Invoke((EventHandler)delegate
            {
                Debug_Info_Display.AppendText(info + "\r\n");
            });
            
        }

        /// <summary>
        /// 获取文件名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetFileName_Click(object sender, EventArgs e)
        {
            // 获取文件名
            OpenFileDialog openfile = new OpenFileDialog
            {
                Filter = "dxf 文件(*.dxf)|*.dxf"
            };
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                Program.SystemContainer.SysPara.DxfFileName = openfile.FileName;
                appendInfo(Program.SystemContainer.SysPara.DxfFileName);
            }
        }

        /// <summary>
        /// 两轴回零
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AxisHome_Click(object sender, EventArgs e)
        {
            Thread Axis01_home_thread = new Thread(this.Axis01_Home);
            Thread Axis02_home_thread = new Thread(this.Axis02_Home);
            Axis01_home_thread.Start();
            Axis02_home_thread.Start();
            AxisHome.Enabled = false;
            EstablishCoordinate.Enabled = false;
            appendInfo("XY平台归零启动！！！");
        }
        /// <summary>
        /// X轴回零
        /// </summary>
        private void Axis01_Home()
        {
            if (Program.SystemContainer.IO.Axis01_EN)
            {
                if (Program.SystemContainer.GTS_Fun.Axis01_Home_Down_Motor() == 0)
                {
                    appendInfo("X轴归零完成！！！");
                    Thread.Sleep(200);
                    if (Program.SystemContainer.IO.Gts_Home_Flag)
                    {
                        appendInfo("XY平台归零完成！！！");
                        this.Invoke((EventHandler)delegate
                        {
                            AxisHome.Enabled = true;
                            EstablishCoordinate.Enabled = true;
                            GoPoint.Enabled = true;
                            Cam_Work_Start.Enabled = true;
                            Cam_Work_Stop.Enabled = true;
                        });
                        Program.SystemContainer.GTS_Fun.Coordination(Program.SystemContainer.SysPara.Work.X, Program.SystemContainer.SysPara.Work.Y);
                        appendInfo("直角坐标系建立完成！！！");
                    }
                }
                else
                {
                    appendInfo("X轴归零失败！！！");
                }

            }
            else
            {
                if (this.IsHandleCreated) this.Invoke((EventHandler)delegate
                {
                    AxisHome.Enabled = true;
                    appendInfo("X轴使能关闭，归零失败！！！");
                });
                
            }
        }
        /// <summary>
        /// Y轴回零
        /// </summary>
        private void Axis02_Home()
        {
            if (Program.SystemContainer.IO.Axis02_EN)
            {
                //GTS_Fun.Axis_Home.Home_Upper_Monitor(2);
                if (Program.SystemContainer.GTS_Fun.Axis02_Home_Down_Motor() == 0)
                {
                    appendInfo("Y轴归零完成！！！");
                    Thread.Sleep(200);
                    if (Program.SystemContainer.IO.Gts_Home_Flag)
                    {
                        appendInfo("XY平台归零完成！！！");
                        this.Invoke((EventHandler)delegate
                        {
                            AxisHome.Enabled = true;
                            EstablishCoordinate.Enabled = true;
                            GoPoint.Enabled = true;
                            Cam_Work_Start.Enabled = true;
                            Cam_Work_Stop.Enabled = true;
                        });
                        Program.SystemContainer.GTS_Fun.Coordination(Program.SystemContainer.SysPara.Work.X, Program.SystemContainer.SysPara.Work.Y);
                        appendInfo("直角坐标系建立完成！！！");
                    }
                }
                else
                {
                    appendInfo("Y轴归零失败！！！");
                }
            }
            else
            {
                if (this.IsHandleCreated) this.Invoke((EventHandler)delegate
                {
                    AxisHome.Enabled = true;
                    appendInfo("Y轴使能关闭，归零失败！！！");
                });
                
            }
        }
        /// <summary>
        /// 建立直角坐标系
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EstablishCoordinate_Click(object sender, EventArgs e)
        {
            Program.SystemContainer.GTS_Fun.Coordination(Program.SystemContainer.SysPara.Work.X, Program.SystemContainer.SysPara.Work.Y);
        }
        /// <summary>
        /// 定位坐标点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoPoint_Click(object sender, EventArgs e)
        {
            Program.SystemContainer.GTS_Fun.Gts_Ready_Correct(Program.SystemContainer.SysPara.Upload_Point);
        }
        /// <summary>
        /// 加工启动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cam_Work_Start_Click(object sender, EventArgs e)
        {
            Cam_Start_Work_Thread();
        }
        /// <summary>
        /// 加工终止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cam_Work_Stop_Click(object sender, EventArgs e)
        {
            if (this.IsHandleCreated) this.Invoke((EventHandler)delegate
            {
                switch (Array.IndexOf(Methods_List, Work_Type_Select_List.SelectedItem.ToString()))
                {
                    case 0://振镜空白和平台未补偿
                        Cam_Integrate_Fun.Exit_Flag = true;
                        Cam_Integrate.Exit_Flag = true;
                        break;
                    case 1://振镜仿射和平台未补偿
                        Cam_Integrate_Fun.Exit_Flag = true;
                        Cam_Integrate.Exit_Flag = true;
                        break;
                    case 2://振镜仿射和平台已补偿
                        Cam_Integrate_Fun.Exit_Flag = true;
                        Cam_Integrate.Exit_Flag = true;
                        break;
                    case 3://振镜旋转和平台已补偿
                        Cam_Integrate_Fun.Exit_Flag = true;
                        Cam_Integrate.Exit_Flag = true;
                        break;
                    case 4://振镜矩阵和平台已补偿
                        Cam_Integrate_Fun.Exit_Flag = true;
                        Cam_Integrate.Exit_Flag = true;
                        break;
                    case 5://振镜桶形畸变图形加工
                        Cam_Integrate_Fun.Exit_Flag = true;
                        Cam_Integrate.Exit_Flag = true;
                        break;
                    case 6://振镜桶形畸变数据采集                    
                        break;
                    case 7://振镜仿射矩阵图形加工
                        Cam_Integrate_Fun.Exit_Flag = true;
                        Cam_Integrate.Exit_Flag = true;
                        break;
                    case 8://振镜仿射矩阵数据采集
                        break;
                    case 9://Mark坐标定位矫正
                        break;
                    case 10://Mark坐标定位重矫正
                        break;
                    case 11://相机坐标系标定(打标)
                        break;
                    case 12://相机坐标系标定(标定板)
                        break;
                    case 13://矫正振镜坐标系偏转角
                        break;
                    case 14://振镜与ORG距离校准
                        break;
                    case 15://坐标系原点坐标校准
                        break;
                    case 16://计算标定板旋转参数
                        break;
                    case 17://标定板原始校准数据
                        Calibration.Exit_Flag = true;
                        break;
                    case 18://标定板二次校准验证                    
                        Calibration.Exit_Flag = true;
                        break;
                    case 19://振镜空白和平台已补偿                  
                        Cam_Integrate_Fun.Exit_Flag = true;
                        Cam_Integrate.Exit_Flag = true;
                        break;
                    default:
                        break;
                }
                Work_Type_Select_List.Enabled = true;
                Cam_Work_Start.Enabled = true;
            });
            
        }
        /// <summary>
        /// 整合加工启动
        /// </summary>
        public void Cam_Start_Work_Thread()
        {
            if (!Cam_Working)
            {
                Cam_Working = true;
                Thread Integrate_thread = new Thread(CAM_Integrated_Start);
                Integrate_thread.Start();
                this.Invoke((EventHandler)delegate
                {
                    AxisHome.Enabled = false;
                    EstablishCoordinate.Enabled = false;
                    Work_Type_Select_List.Enabled = false;
                    Cam_Work_Start.Enabled = false;
                });                
            }
        }
        /// <summary>
        /// 加工方式选择
        /// </summary>
        private void CAM_Integrated_Start()
        {
            this.Invoke((EventHandler)delegate
            {
                Work_Type_No = Array.IndexOf(Methods_List, Work_Type_Select_List.SelectedItem.ToString());
            });            
            switch (Work_Type_No)
            {
                case 0://振镜空白和平台未补偿
                    Cam_Method_Start(0);
                    break;
                case 1://振镜仿射和平台未补偿
                    Cam_Method_Start(1);
                    break;
                case 2://振镜仿射和平台已补偿
                    Cam_Method_Start(2);
                    break;
                case 3://振镜旋转和平台已补偿
                    Cam_Method_Start(3);
                    break;
                case 4://振镜矩阵和平台已补偿
                    Cam_Method_Start(4);
                    break;
                case 5://振镜桶形畸变图形加工
                    Rtc_Barrel_Distortion_Figure_Sculpture();
                    break;
                case 6://振镜桶形畸变数据采集
                    Rtc_Barrel_Distortion_Figure_Data_Acquisition();
                    break;
                case 7://振镜仿射矩阵图形加工
                    Rtc_AFF_Matrix_Figure_Sculpture();
                    break;
                case 8://振镜仿射矩阵数据采集
                    Rtc_AFF_Matrix_Figure_Data_Acquisition();
                    break;
                case 9://Mark坐标定位矫正
                    Mark_AFF_Correction();
                    break;
                case 10://Mark坐标定位重矫正
                    Mark_AFF_Re_Correction();
                    break;
                case 11://相机坐标系标定(打标)
                    Calibration_Camera_Axes_Mark();
                    break;
                case 12://相机坐标系标定(标定板)
                    Calibration_Camera_Axes_Board();
                    break;
                case 13://矫正振镜坐标系偏转角
                    Calibration_Rtc_Axes_AFF_Angle();
                    break;
                case 14://振镜与ORG距离校准
                    Calibration_Rtc_Gts_ORG_Distance();
                    break;
                case 15://坐标系原点坐标校准
                    Clabration_ORG_Align();
                    break;
                case 16://计算标定板旋转参数
                    Calibration_Board_Angle();
                    break;
                case 17://标定板原始校准数据
                    Calibration_Original_Data_Collect();
                    break;
                case 18://标定板二次校准验证                    
                    Calibration_Second_Data_Collect();
                    break;
                case 19://振镜空白和平台已补偿                  
                    Cam_Method_Start(6);
                    break;
                default:
                    break;
            }
            Cam_Working = false;
            this.Invoke((EventHandler)delegate
            {
                AxisHome.Enabled = true;
                EstablishCoordinate.Enabled = true;
                Work_Type_Select_List.Enabled = true;
                Cam_Work_Start.Enabled = true;
            });         
        }
        /// <summary>
        /// 整合加工方式选择和指定
        /// </summary>
        /// <param name="method_index"></param>
        private void Cam_Method_Start(int method_index)
        {
            /*
             1、提取mark信息
             2、矫正Mark坐标
             3、dxf文件处理
             4、数据拆分
             5、加工启动
             */
            Get_Mark_Information();//提取Mark信息
            if (Program.SystemContainer.SysPara.Calibration_Type == 1)//启用mark点矫正
            {
                if (!Mark_AFF_Correction())//矫正Mark坐标
                {
                    return;
                }
            }
            else if (Program.SystemContainer.SysPara.Calibration_Type == 2)//启用mark点重矫正
            {
                if (!Mark_AFF_Re_Correction())//重矫正Mark坐标
                {
                    return;
                }
            }
            if(!Cam_Dxf_Data_Distract()) return;//提取轨迹信息
            CAM_Work_Data_Resolve();//数据拆分

            Info("CAM加工启动！！！");
            //钻孔数据拆分
            if (Cam_Drill_Work_Data.Count >= 1)
            {
                appendInfo("钻孔加工启动！！！！");
                Cam_Integrate.Cam_Work_Start(Cam_Drill_Work_Data, 0, method_index);
                appendInfo("钻孔加工结束！！！！");
            }
            else
                appendInfo("无可用钻孔加工数据！！！！");
            //圆弧数据拆分
            if (Cam_Arc_Work_Data.Count >= 1)
            {
                appendInfo("圆弧加工启动！！！！");
                Cam_Integrate.Cam_Work_Start(Cam_Arc_Work_Data, 1, method_index);
                appendInfo("圆弧加工结束！！！！");
            }
            else
                appendInfo("无可用圆弧加工数据！！！！");
            //直线数据拆分
            if (Cam_Line_Work_Data.Count >= 1)
            {
                appendInfo("直线加工启动！！！！");
                Cam_Integrate.Cam_Work_Start(Cam_Line_Work_Data, 2, method_index);
                appendInfo("直线加工结束！！！！");
            }
            else
                appendInfo("无可用直线加工数据！！！！");
            //折线数据拆分
            if (Cam_LWPolyLine_Work_Data.Count >= 1)
            {
                appendInfo("折线加工启动！！！！");
                Cam_Integrate.Cam_Work_Start(Cam_LWPolyLine_Work_Data, 2, method_index);
                appendInfo("折线加工结束！！！！");
            }
            else
                appendInfo("无可用折线加工数据！！！！");
            Info("CAM加工结束！！！");

            //回退位置
            Cam_Integrate.Pos_Upload();
        }
        /// <summary>
        /// 提取Mark信息
        /// </summary>
        private void Get_Mark_Information()
        {
            //读取Dxf文件
            DxfDocument dxf = Cam_Data_Cal.Read_File(Program.SystemContainer.SysPara.DxfFileName);
            if (dxf == null)
            {
                return;
            }
            appendInfo("Mark 数据提取中！！！");
            Mark_Circle_Entity_Data = new List<Entity_Data>(Cam_Data_Cal.Resolve_Mark_Point(dxf));//提取Mark点数据
            if (Mark_Circle_Entity_Data.Count >= 4) Cam_Data_Cal.Mark_Calculate(Mark_Circle_Entity_Data);
            appendInfo("Mark 数据提取完成！！！");
            appendInfo("Mark 数据计数：！！！" + Mark_Circle_Entity_Data.Count);
        }
        /// <summary>
        /// 加工数据拆分
        /// </summary>
        private void CAM_Work_Data_Resolve()
        {
            //Cam_Data_Cal
            Cam_Drill_Work_Data.Clear();
            Cam_Arc_Work_Data.Clear();
            Cam_Line_Work_Data.Clear();
            Cam_LWPolyLine_Work_Data.Clear();
            Info("CAM加工路径生成中！！！");
            //钻孔数据拆分
            if (Cam_Drill_Data.Count >= 1)
                Cam_Drill_Work_Data = new List<List<List<Interpolation_Data>>>(Cam_Data_Cal.Separate_Rtc_Gts_Cam(Cam_Drill_Data, 1));
            else
                appendInfo("无钻孔加工数据拆分！！！！");
            //圆弧数据拆分
            if (Cam_Arc_Data.Count >= 1)
                Cam_Arc_Work_Data = new List<List<List<Interpolation_Data>>>(Cam_Data_Cal.Separate_Rtc_Gts_Cam(Cam_Arc_Data, 1));
            else
                appendInfo("无圆弧加工数据拆分！！！！");
            //直线数据拆分
            if (Cam_Line_Data.Count >= 1)
                Cam_Line_Work_Data = new List<List<List<Interpolation_Data>>>(Cam_Data_Cal.Separate_Rtc_Gts_Cam(Cam_Line_Data, 0));
            else
                appendInfo("无直线加工数据拆分！！！！");
            //折线数据拆分
            if (Cam_LWPolyLine_Data.Count >= 1)
                Cam_LWPolyLine_Work_Data = new List<List<List<Interpolation_Data>>>(Cam_Data_Cal.Separate_Rtc_Gts_Cam(Cam_LWPolyLine_Data, 0));
            else
                appendInfo("无折线加工数据拆分！！！！");
            Info("CAM加工路径生成完毕！！！");
            //钻孔数据
            Info("钻孔加工分区数量：" + Cam_Drill_Work_Data.Count);
            for (int i = 0; i < Cam_Drill_Work_Data.Count; i++)
            {
                Info(string.Format("    分区序号：{0}，钻孔刀具序号：{1}，钻孔总数：{2}", i, Cam_Drill_Work_Data[i][0][0].Path_Type, Cam_Drill_Work_Data[i].Count));
            }
            //圆弧数据
            Info("圆弧加工分区数量：" + Cam_Arc_Work_Data.Count);
            for (int i = 0; i < Cam_Arc_Work_Data.Count; i++)
            {
                Info(string.Format("    分区序号：{0}，圆弧刀具序号：{1}，圆弧总数：{2}", i, Cam_Arc_Work_Data[i][0][0].Path_Type, Cam_Arc_Work_Data[i].Count));
            }
            //直线数据
            Info("直线加工分区数量：" + Cam_Line_Work_Data.Count);
            for (int i = 0; i < Cam_Line_Work_Data.Count; i++)
            {
                Info(string.Format("    分区序号：{0}，直线刀具序号：{1}，直线总数：{2}", i, Cam_Line_Work_Data[i][0][0].Path_Type, Cam_Line_Work_Data[i].Count));
            }
            //折线数据
            Info("折线加工分区数量：" + Cam_LWPolyLine_Work_Data.Count);
            for (int i = 0; i < Cam_LWPolyLine_Work_Data.Count; i++)
            {
                Info(string.Format("    分区序号：{0}，折线刀具序号：{1}，折线总数：{2}", i, Cam_LWPolyLine_Work_Data[i][0][0].Path_Type, Cam_LWPolyLine_Work_Data[i].Count));
            }
        }
        /// <summary>
        /// Cam辅助加工数据提取
        /// </summary>
        private bool Cam_Dxf_Data_Distract()
        {
            //读取Dxf文件
            DxfDocument dxf = Cam_Data_Cal.Read_File(Program.SystemContainer.SysPara.DxfFileName);
            if (dxf == null)
            {
                return false;
            }
            Info("Dxf数据提取中！！！！");
            //建立临时数据存储组 和数据矫正
            List<List<List<Entity_Data>>> Cam_Drill_Entity_Data = new List<List<List<Entity_Data>>>(Cam_Data_Cal.Calibration_List_Of_Entity(Cam_Data_Cal.Resolve_Cam_Circle(dxf), Program.SystemContainer.SysPara.Trans_Affinity));//提取钻孔数据
            List<List<Entity_Data>> Cam_Arc_Entity_Data = new List<List<Entity_Data>>(Cam_Data_Cal.Calibration_List_Entity(Cam_Data_Cal.Resolve_Cam_Arc(dxf), Program.SystemContainer.SysPara.Trans_Affinity));//提取圆弧数据
            List<List<Entity_Data>> Cam_Line_Entity_Data = new List<List<Entity_Data>>(Cam_Data_Cal.Calibration_List_Entity(Cam_Data_Cal.Resolve_Cam_Line(dxf), Program.SystemContainer.SysPara.Trans_Affinity));//提取直线数据
            List<List<List<Entity_Data>>> Cam_LWPolyLine_Entity_Data = new List<List<List<Entity_Data>>>(Cam_Data_Cal.Calibration_List_Of_Entity(Cam_Data_Cal.Resolve_Cam_LWPolyline(dxf), Program.SystemContainer.SysPara.Trans_Affinity));//提取直线数据
            Info("Dxf数据提取完成！！！！");

            //加工范围判断
            Info("加工范围判断启动");
            decimal Limit_Max_X = 0;
            decimal Limit_Min_X = 0;
            decimal Limit_Max_Y = 0;
            decimal Limit_Min_Y = 0;
            if (Program.SystemContainer.SysPara.Calibration_Type != 0)//不启用mark点矫正
            {
                Limit_Max_X = 350;
                Limit_Min_X = 0.0m;
                Limit_Max_Y = 350;
                Limit_Min_Y = 0.0m;
            }
            else
            {
                Limit_Max_X = 350;
                Limit_Min_X = 0.0m;
                Limit_Max_Y = 350.0m;
                Limit_Min_Y = Program.SystemContainer.SysPara.Rtc_Org.Y;
            }
            List<decimal> Drill_Limit_X = new List<decimal>();
            decimal Drill_Limit_Max_X, Drill_Limit_Min_X;
            List<decimal> Drill_Limit_Y = new List<decimal>();
            decimal Drill_Limit_Max_Y, Drill_Limit_Min_Y;
            List<decimal> Arc_Limit_X = new List<decimal>();
            decimal Arc_Limit_Max_X, Arc_Limit_Min_X;
            List<decimal> Arc_Limit_Y = new List<decimal>();
            decimal Arc_Limit_Max_Y, Arc_Limit_Min_Y;
            List<decimal> Line_Limit_X = new List<decimal>();
            decimal Line_Limit_Max_X, Line_Limit_Min_X;
            List<decimal> Line_Limit_Y = new List<decimal>();
            decimal Line_Limit_Max_Y, Line_Limit_Min_Y;
            List<decimal> LWLine_Limit_X = new List<decimal>();
            decimal LWLine_Limit_Max_X, LWLine_Limit_Min_X;
            List<decimal> LWLine_Limit_Y = new List<decimal>();
            decimal LWLine_Limit_Max_Y, LWLine_Limit_Min_Y;
            //钻孔数据
            if (Cam_Drill_Entity_Data.Count > 0)
            {
                Drill_Limit_X.Add(Cam_Drill_Entity_Data.Max(o => o.Max(p => p.Max(q => q.Center_x))));
                Drill_Limit_X.Add(Cam_Drill_Entity_Data.Max(o => o.Max(p => p.Max(q => q.Start_x))));
                Drill_Limit_X.Add(Cam_Drill_Entity_Data.Max(o => o.Max(p => p.Max(q => q.End_x))));
                Drill_Limit_X.Add(Cam_Drill_Entity_Data.Min(o => o.Min(p => p.Min(q => q.Center_x))));
                Drill_Limit_X.Add(Cam_Drill_Entity_Data.Min(o => o.Min(p => p.Min(q => q.Start_x))));
                Drill_Limit_X.Add(Cam_Drill_Entity_Data.Min(o => o.Min(p => p.Min(q => q.End_x))));
                Drill_Limit_Y.Add(Cam_Drill_Entity_Data.Max(o => o.Max(p => p.Max(q => q.Center_y))));
                Drill_Limit_Y.Add(Cam_Drill_Entity_Data.Max(o => o.Max(p => p.Max(q => q.Start_y))));
                Drill_Limit_Y.Add(Cam_Drill_Entity_Data.Max(o => o.Max(p => p.Max(q => q.End_y))));
                Drill_Limit_Y.Add(Cam_Drill_Entity_Data.Min(o => o.Min(p => p.Min(q => q.Center_y))));
                Drill_Limit_Y.Add(Cam_Drill_Entity_Data.Min(o => o.Min(p => p.Min(q => q.Start_y))));
                Drill_Limit_Y.Add(Cam_Drill_Entity_Data.Min(o => o.Min(p => p.Min(q => q.End_y))));
                Drill_Limit_Max_X = Drill_Limit_X.Max();
                Drill_Limit_Min_X = Drill_Limit_X.Min();
                Drill_Limit_Max_Y = Drill_Limit_Y.Max();
                Drill_Limit_Min_Y = Drill_Limit_Y.Min();
                if ((Drill_Limit_Max_X > Limit_Max_X) || (Drill_Limit_Min_X < Limit_Min_X) || (Drill_Limit_Max_Y > Limit_Max_Y) || (Drill_Limit_Min_Y < Limit_Min_Y))
                {
                    Info("Drill 数据超出加工范围限制！！！请检查DXF文件");
                    return false;
                }
                if (Cam_Drill_Entity_Data.Max(o => o.Max(p => p.Max(q => q.Path_Type))) > Program.SystemContainer.Repeat_Drill_Scissor.Count)
                {
                    Info("Drill 刀具配置错误！！！请检查Drill重复参数配置表");
                    return false;
                }
            }
            //圆弧数据
            if (Cam_Arc_Entity_Data.Count > 0)
            {
                Arc_Limit_X.Add(Cam_Arc_Entity_Data.Max(o => o.Max(p => p.Center_x)));
                Arc_Limit_X.Add(Cam_Arc_Entity_Data.Max(o => o.Max(p => p.Start_x)));
                Arc_Limit_X.Add(Cam_Arc_Entity_Data.Max(o => o.Max(p => p.End_x)));
                Arc_Limit_X.Add(Cam_Arc_Entity_Data.Min(o => o.Min(p => p.Center_x)));
                Arc_Limit_X.Add(Cam_Arc_Entity_Data.Min(o => o.Min(p => p.Start_x)));
                Arc_Limit_X.Add(Cam_Arc_Entity_Data.Min(o => o.Min(p => p.End_x)));
                Arc_Limit_Y.Add(Cam_Arc_Entity_Data.Max(o => o.Max(p => p.Center_y)));
                Arc_Limit_Y.Add(Cam_Arc_Entity_Data.Max(o => o.Max(p => p.Start_y)));
                Arc_Limit_Y.Add(Cam_Arc_Entity_Data.Max(o => o.Max(p => p.End_y)));
                Arc_Limit_Y.Add(Cam_Arc_Entity_Data.Min(o => o.Min(p => p.Center_y)));
                Arc_Limit_Y.Add(Cam_Arc_Entity_Data.Min(o => o.Min(p => p.Start_y)));
                Arc_Limit_Y.Add(Cam_Arc_Entity_Data.Min(o => o.Min(p => p.End_y)));
                Arc_Limit_Max_X = Arc_Limit_X.Max();
                Arc_Limit_Min_X = Arc_Limit_X.Min();
                Arc_Limit_Max_Y = Arc_Limit_Y.Max();
                Arc_Limit_Min_Y = Arc_Limit_Y.Min();
                if ((Arc_Limit_Max_X > Limit_Max_X) || (Arc_Limit_Min_X < Limit_Min_X) || (Arc_Limit_Max_Y > Limit_Max_Y) || (Arc_Limit_Min_Y < Limit_Min_Y))
                {
                    Info("Arc 数据超出加工范围限制！！！请检查DXF文件");
                    return false;
                }
                if (Cam_Arc_Entity_Data.Max(o => o.Max(p => p.Path_Type)) > Program.SystemContainer.Repeat_Arc_Scissor.Count)
                {
                    Info("Arc 刀具配置错误！！！请检查Arc重复参数配置表");
                    return false;
                }
            }
            //直线数据
            if (Cam_Line_Entity_Data.Count > 0)
            {
                Line_Limit_X.Add(Cam_Line_Entity_Data.Max(o => o.Max(p => p.Start_x)));
                Line_Limit_X.Add(Cam_Line_Entity_Data.Max(o => o.Max(p => p.End_x)));
                Line_Limit_X.Add(Cam_Line_Entity_Data.Min(o => o.Min(p => p.Start_x)));
                Line_Limit_X.Add(Cam_Line_Entity_Data.Min(o => o.Min(p => p.End_x)));
                Line_Limit_Y.Add(Cam_Line_Entity_Data.Max(o => o.Max(p => p.Start_y)));
                Line_Limit_Y.Add(Cam_Line_Entity_Data.Max(o => o.Max(p => p.End_y)));
                Line_Limit_Y.Add(Cam_Line_Entity_Data.Min(o => o.Min(p => p.Start_y)));
                Line_Limit_Y.Add(Cam_Line_Entity_Data.Min(o => o.Min(p => p.End_y)));
                Line_Limit_Max_X = Line_Limit_X.Max();
                Line_Limit_Min_X = Line_Limit_X.Min();
                Line_Limit_Max_Y = Line_Limit_Y.Max();
                Line_Limit_Min_Y = Line_Limit_Y.Min();
                if ((Line_Limit_Max_X > Limit_Max_X) || (Line_Limit_Min_X < Limit_Min_X) || (Line_Limit_Max_Y > Limit_Max_Y) || (Line_Limit_Min_Y < Limit_Min_Y))
                {
                    Info("Line 数据超出加工范围限制！！！请检查DXF文件");
                    return false;
                }
                if (Cam_Line_Entity_Data.Max(o => o.Max(p => p.Path_Type)) > Program.SystemContainer.Repeat_Line_Scissor.Count)
                {
                    Info("Line 刀具配置错误！！！请检查Line重复参数配置表");
                    return false;
                }
            }
            //折线数据
            if (Cam_LWPolyLine_Entity_Data.Count > 0)
            {
                LWLine_Limit_X.Add(Cam_LWPolyLine_Entity_Data.Max(o => o.Max(p => p.Max(q => q.Start_x))));
                LWLine_Limit_X.Add(Cam_LWPolyLine_Entity_Data.Max(o => o.Max(p => p.Max(q => q.End_x))));
                LWLine_Limit_X.Add(Cam_LWPolyLine_Entity_Data.Min(o => o.Min(p => p.Min(q => q.Start_x))));
                LWLine_Limit_X.Add(Cam_LWPolyLine_Entity_Data.Min(o => o.Min(p => p.Min(q => q.End_x))));
                LWLine_Limit_Y.Add(Cam_LWPolyLine_Entity_Data.Max(o => o.Max(p => p.Max(q => q.Start_y))));
                LWLine_Limit_Y.Add(Cam_LWPolyLine_Entity_Data.Max(o => o.Max(p => p.Max(q => q.End_y))));
                LWLine_Limit_Y.Add(Cam_LWPolyLine_Entity_Data.Min(o => o.Min(p => p.Min(q => q.Start_y))));
                LWLine_Limit_Y.Add(Cam_LWPolyLine_Entity_Data.Min(o => o.Min(p => p.Min(q => q.End_y))));
                LWLine_Limit_Max_X = LWLine_Limit_X.Max();
                LWLine_Limit_Min_X = LWLine_Limit_X.Min();
                LWLine_Limit_Max_Y = LWLine_Limit_Y.Max();
                LWLine_Limit_Min_Y = LWLine_Limit_Y.Min();
                if ((LWLine_Limit_Max_X > Limit_Max_X) || (LWLine_Limit_Min_X < Limit_Min_X) || (LWLine_Limit_Max_Y > Limit_Max_Y) || (LWLine_Limit_Min_Y < Limit_Min_Y))
                {
                    Info("LWLine 数据超出加工范围限制！！！请检查DXF文件");
                    return false;
                }
                if (Cam_LWPolyLine_Entity_Data.Max(o => o.Max(p => p.Max(q => q.Path_Type))) > Program.SystemContainer.Repeat_Line_Scissor.Count)
                {
                    Info("Line 刀具配置错误！！！请检查Line重复参数配置表");
                    return false;
                }
            }
            //钻孔数据
            Info("钻孔加工分区数量：" + Cam_Drill_Entity_Data.Count);
            for (int i = 0; i < Cam_Drill_Entity_Data.Count; i++)
            {
                Info(string.Format("    分区序号：{0}，钻孔刀具序号：{1}，钻孔总数：{2}", i, Cam_Drill_Entity_Data[i][0][0].Path_Type, Cam_Drill_Entity_Data[i].Count));
            }
            //圆弧数据
            Info("圆弧加工分区数量：" + Cam_Arc_Entity_Data.Count);
            for (int i = 0; i < Cam_Arc_Entity_Data.Count; i++)
            {
                Info(string.Format("    分区序号：{0}，圆弧刀具序号：{1}，圆弧总数：{2}", i, Cam_Arc_Entity_Data[i][0].Path_Type, Cam_Arc_Entity_Data[i].Count));
            }
            //直线数据
            Info("直线加工分区数量：" + Cam_Line_Entity_Data.Count);
            for (int i = 0; i < Cam_Line_Entity_Data.Count; i++)
            {
                Info(string.Format("    分区序号：{0}，直线刀具序号：{1}，直线总数：{2}", i, Cam_Line_Entity_Data[i][0].Path_Type, Cam_Line_Entity_Data[i].Count));
            }
            //折线数据
            Info("折线加工分区数量：" + Cam_LWPolyLine_Entity_Data.Count);
            for (int i = 0; i < Cam_LWPolyLine_Entity_Data.Count; i++)
            {
                Info(string.Format("    分区序号：{0}，折线刀具序号：{1}，折线总数：{2}", i, Cam_LWPolyLine_Entity_Data[i][0][0].Path_Type, Cam_LWPolyLine_Entity_Data[i].Count));
            }
            Info("Cam轨迹数据生成中！！！！");
            Cam_Drill_Data = new List<List<List<Interpolation_Data>>>(Cam_Data_Cal.Integrate_Cam_Circle(Cam_Drill_Entity_Data)); //钻孔加工轨迹生成
            Cam_Arc_Data = new List<List<List<Interpolation_Data>>>(Cam_Data_Cal.Integrate_Cam_Arc(Cam_Arc_Entity_Data)); //圆弧加工轨迹生成
            Cam_Line_Data = new List<List<List<Interpolation_Data>>>(Cam_Data_Cal.Integrate_Cam_Line(Cam_Line_Entity_Data)); //直线加工轨迹生成
            Cam_LWPolyLine_Data = new List<List<List<Interpolation_Data>>>(Cam_Data_Cal.Integrate_Cam_LWPolyLine(Cam_LWPolyLine_Entity_Data)); //折线加工轨迹生成
            Info("Cam轨迹数据生成完成！！！！");
            //钻孔数据
            Info("钻孔加工分区数量：" + Cam_Drill_Data.Count);
            for (int i = 0; i < Cam_Drill_Data.Count; i++)
            {
                Info(string.Format("    分区序号：{0}，钻孔刀具序号：{1}，钻孔总数：{2}", i, Cam_Drill_Data[i][0][0].Path_Type, Cam_Drill_Data[i].Count));
            }
            //圆弧数据
            Info("圆弧加工分区数量：" + Cam_Arc_Data.Count);
            for (int i = 0; i < Cam_Arc_Data.Count; i++)
            {
                Info(string.Format("    分区序号：{0}，圆弧刀具序号：{1}，圆弧总数：{2}", i, Cam_Arc_Data[i][0][0].Path_Type, Cam_Arc_Data[i].Count));
            }
            //直线数据
            Info("直线加工分区数量：" + Cam_Line_Data.Count);
            for (int i = 0; i < Cam_Line_Data.Count; i++)
            {
                Info(string.Format("    分区序号：{0}，直线刀具序号：{1}，直线总数：{2}", i, Cam_Line_Data[i][0][0].Path_Type, Cam_Line_Data[i].Count));
            }
            //折线数据
            Info("折线加工分区数量：" + Cam_LWPolyLine_Data.Count);
            for (int i = 0; i < Cam_LWPolyLine_Data.Count; i++)
            {
                Info(string.Format("    分区序号：{0}，折线刀具序号：{1}，折线总数：{2}", i, Cam_LWPolyLine_Data[i][0][0].Path_Type, Cam_LWPolyLine_Data[i].Count));
            }
            return true;
        }

        /// <summary>
        /// 振镜桶形畸变图形加工
        /// </summary>
        private void Rtc_Barrel_Distortion_Figure_Sculpture()
        {
            if (((Int16)(Program.SystemContainer.SysPara.Rtc_Distortion_Data_Limit / Program.SystemContainer.SysPara.Rtc_Distortion_Data_Interval) % 2) != 0)
            {
                appendInfo(string.Format("振镜矫正范围除以打标间距：{0}不为偶数，禁止加工！！！", Program.SystemContainer.SysPara.Rtc_Distortion_Data_Limit / Program.SystemContainer.SysPara.Rtc_Distortion_Data_Interval));
                return;
            }
            else
            {
                List<List<List<Interpolation_Data>>> Cam_Common_Work_Data = new List<List<List<Interpolation_Data>>>
                {
                    new List<List<Interpolation_Data>>(Calibration.Generate_Rtc_Correct_Data(Program.SystemContainer.SysPara.Rtc_Distortion_Data_Type, Program.SystemContainer.SysPara.Rtc_Distortion_Data_Radius, Program.SystemContainer.SysPara.Rtc_Distortion_Data_Interval, Program.SystemContainer.SysPara.Rtc_Distortion_Data_Limit))
                };
                if (Program.SystemContainer.SysPara.Rtc_Distortion_Data_Type == 0)
                {
                    Cam_Integrate.Cam_Work_Start(Cam_Common_Work_Data, 0, 5);
                }
                else
                {
                    Cam_Integrate.Cam_Work_Start(Cam_Common_Work_Data, 2, 5);
                }
            }
        }
        /// <summary>
        /// 振镜桶形畸变数据采集
        /// </summary>
        private void Rtc_Barrel_Distortion_Figure_Data_Acquisition()
        {
            if (Program.SystemContainer.SysPara.Rtc_Distortion_Data_Type == 0)//只采集整圆图形
            {
                Calibration.Rtc_Correct_Coordinate();

            }
            else
            {
                appendInfo("只支持整圆图形采集！！！！");
            }
        }
        /// <summary>
        /// 振镜仿射矩阵图形加工
        /// </summary>
        private void Rtc_AFF_Matrix_Figure_Sculpture()
        {
            if ((((Int16)(Program.SystemContainer.SysPara.Rtc_Calibration_X_Len / Program.SystemContainer.SysPara.Rtc_Calibration_Cell) % 2) != 0) || (((Int16)(Program.SystemContainer.SysPara.Rtc_Calibration_Y_Len / Program.SystemContainer.SysPara.Rtc_Calibration_Cell) % 2) != 0))
            {
                MessageBox.Show(string.Format("振镜矫正范围除以打标间距：X-{0}或Y-{1} 不为偶数，数据采集终止！！！", Program.SystemContainer.SysPara.Rtc_Calibration_X_Len / Program.SystemContainer.SysPara.Rtc_Calibration_Cell, Program.SystemContainer.SysPara.Rtc_Calibration_Y_Len / Program.SystemContainer.SysPara.Rtc_Calibration_Cell));
                return;
            }
            else
            {
                List<List<List<Interpolation_Data>>> Cam_Common_Work_Data = new List<List<List<Interpolation_Data>>>
                {
                    new List<List<Interpolation_Data>>(Calibration.Generate_Rtc_Correct_Data(0, Program.SystemContainer.SysPara.Rtc_Distortion_Data_Radius, Program.SystemContainer.SysPara.Rtc_Distortion_Data_Interval, Program.SystemContainer.SysPara.Rtc_Distortion_Data_Limit))
                };
                Cam_Integrate.Cam_Work_Start(Cam_Common_Work_Data, 0, 6);
            }
        }
        /// <summary>
        /// 振镜仿射矩阵数据采集
        /// </summary>
        private void Rtc_AFF_Matrix_Figure_Data_Acquisition()
        {
            Calibration.Rtc_Correct_AFF_Coordinate();
        }
        /// <summary>
        /// Mark坐标定位矫正
        /// </summary>
        private bool Mark_AFF_Correction()
        {
            if (Calibration.Calibrate_Mark(0))
            {
                appendInfo("Mark点矫正完成！！！");
                return true;
            }
            else
            {
                appendInfo("Mark点矫正失败！！！");
                return false;
            }
        }
        /// <summary>
        /// Mark坐标定位重矫正
        /// </summary>
        private bool Mark_AFF_Re_Correction()
        {
            if (Calibration.Calibrate_Mark(1))
            {
                appendInfo("Mark点重矫正完成！！！");
                return true;
            }
            else
            {
                appendInfo("Mark点重矫正失败！！！");
                return false;
            }
        }
        /// <summary>
        /// 相机坐标系标定(打标)
        /// </summary>
        private void Calibration_Camera_Axes_Mark()
        {
            if (Calibration.Cal_Cam_Affinity())
            {
                appendInfo("相机坐标系标定完成！！！");
            }
            else
            {
                appendInfo("相机坐标系标定失败！！！");
            }
        }
        /// <summary>
        /// 相机坐标系标定(标定板)
        /// </summary>
        private void Calibration_Camera_Axes_Board()
        {
            if (Calibration.Cal_Cam_Affinity_By_Board())
            {
                appendInfo("相机坐标系标定板标定完成！！！");
            }
            else
            {
                appendInfo("相机坐标系标定板标定失败！！！");
            }
        }

        /// <summary>
        /// 矫正振镜坐标系偏转角
        /// </summary>
        private void Calibration_Rtc_Axes_AFF_Angle()
        {
            if (Calibration.Get_Rtc_Coordinate_Affinity())
            {
                appendInfo("振镜坐标系偏转角矫正完成！！！");
            }
            else
            {
                appendInfo("振镜坐标系偏转角矫正失败！！！");
            }
        }
        /// <summary>
        /// 振镜与ORG距离校准
        /// </summary>
        private void Calibration_Rtc_Gts_ORG_Distance()
        {
            if (Calibration.Calibrate_RTC_ORG())
            {
                RefreshRtcOrgDistance();
                appendInfo("振镜与ORG的距离矫正完成！！");
            }
            else
            {
                appendInfo("振镜与ORG的距离矫正失败！！");
            }
        }
        /// <summary>
        /// 坐标系原点坐标校准
        /// </summary>
        private void Clabration_ORG_Align()
        {
            if (Calibration.Calibrate_Org())
            {
                RefreshWork();
                appendInfo("坐标原点矫正成功！！！");
            }
            else
            {
                appendInfo("坐标原点矫正失败！！！");
                return;
            }
            Info("矫正后数据 X：" + Program.SystemContainer.SysPara.Cal_Org.X + ", Y：" + Program.SystemContainer.SysPara.Cal_Org.Y);
        }
        /// <summary>
        /// //计算标定板旋转参数
        /// </summary>
        private void Calibration_Board_Angle()
        {
            //先矫正坐标原点
            if (Calibration.Calibrate_Org())
            {
                appendInfo("坐标原点矫正成功！！！");
            }
            else
            {
                appendInfo("坐标原点矫正失败！！！");
                return;
            }
            Info("矫正后数据 X：" + Program.SystemContainer.SysPara.Cal_Org.X + ", Y：" + Program.SystemContainer.SysPara.Cal_Org.Y);
            //建立直角坐标系
            Program.SystemContainer.GTS_Fun.Coordination(Program.SystemContainer.SysPara.Work.X, Program.SystemContainer.SysPara.Work.Y);
            appendInfo("直角坐标系建立完成！！！");
            //矫正标定板旋转参数
            if (Calibration.Cal_Calibration_Angle_Matrix())
            {
                appendInfo("标定板旋转参数矫正成功！！！");
            }
            else
            {
                appendInfo("标定板旋转参数矫正失败！！！");
                return;
            }
            Info("标定板旋转参数Stretch_X：" + Program.SystemContainer.SysPara.Cal_Trans_Angle.Stretch_X);
            Info("标定板旋转参数Distortion_X：" + Program.SystemContainer.SysPara.Cal_Trans_Angle.Distortion_X);
            Info("标定板旋转参数DeltaX：" + Program.SystemContainer.SysPara.Cal_Trans_Angle.Delta_X);
            Info("标定板旋转参数Stretch_Y：" + Program.SystemContainer.SysPara.Cal_Trans_Angle.Stretch_Y);
            Info("标定板旋转参数Distortion_Y：" + Program.SystemContainer.SysPara.Cal_Trans_Angle.Distortion_Y);
            Info("标定板旋转参数DeltaY：" + Program.SystemContainer.SysPara.Cal_Trans_Angle.Delta_Y);
        }
        /// <summary>
        /// 标定板原始校准数据
        /// </summary>
        private void Calibration_Original_Data_Collect()
        {
            appendInfo("标定板原始校准数据采集启动！！！");
            Calibration.Get_Datas();
            appendInfo("标定板原始校准数据采集成功！！！");
        }

        /// <summary>
        /// 标定板二次校准验证
        /// </summary>
        private void Calibration_Second_Data_Collect()
        {
            appendInfo("标定板二次校准验证数据采集启动！！！");
            Calibration.Get_Datas_Correct();
            appendInfo("标定板二次校准验证数据采集成功！！！");
        }

        /// <summary>
        /// 回退坐标X
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackX_TextChanged(object sender, EventArgs e)
        {
            if (!decimal.TryParse(BackX.Text, out decimal tmp))
            {
                MessageBox.Show("请正确输入数字");
                return;
            }
            Program.SystemContainer.SysPara.Upload_Point = new Vector(tmp, Program.SystemContainer.SysPara.Upload_Point.Y);
        }
        /// <summary>
        /// 回退坐标Y
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackY_TextChanged(object sender, EventArgs e)
        {
            if (!decimal.TryParse(BackY.Text, out decimal tmp))
            {
                MessageBox.Show("请正确输入数字");
                return;
            }
            Program.SystemContainer.SysPara.Upload_Point = new Vector(Program.SystemContainer.SysPara.Upload_Point.X, tmp);
        }
        /// <summary>
        /// 加工起始位置选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Start_Pos_Sel_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.SystemContainer.SysPara.Calibration_Type = (UInt16)Start_Pos_Sel.SelectedIndex;
        }
        /// <summary>
        /// 加工完成回退位置选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Back_Pos_Select_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.SystemContainer.SysPara.Upload_Type_Select = Back_Pos_Select.SelectedIndex;
        }
        /// <summary>
        /// 加工方式选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Work_Type_Select_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.SystemContainer.SysPara.Work_Type_Select = Work_Type_Select_List.SelectedIndex;
        }
    }
}

using netDxf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DG_Laser
{
    public delegate void Work();
    partial class MainForm
    {
        File_Entity_Data File_Entity_Datas = new File_Entity_Data();//文件数据集合
        //定义标志位
        Thread SectionWorkThread;//线程
        public bool SectionWorkThreadEnd = false;//线程结束标志
        ManualResetEvent ma;//手动置位
        public bool running = false;//运行中 
        public bool on_off = false;//运行、暂停切换
        public bool stop = false;//停止
        public bool LaserReady = false;//激光准备ok
        //事件定义区
        public event Work StartEvent;
        public event Work PauseEvent;
        public event Work ResumeEvent;
        public event Work StopEvent;
        /// <summary>
        /// 分区加工参数初始化
        /// </summary>
        private void SectionWorkInitial()
        {
            //注册停止事件
            StopEvent += EndMotion;
        }
        /// <summary>
        /// 文件加工启动 软按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileMarkRun_Click(object sender, EventArgs e)
        {
            WorkStartEvent();
        }
        /// <summary>
        /// 启动加工
        /// </summary>
        private void WorkStartEvent()
        {
            if (!running)//非运行状态
            {
                running = !running;//切换运行状态
                //按钮状态锁定
                ButtonDisable();
                //启动和停止按钮例外
                this.Invoke((EventHandler)delegate
                {
                    FileMarkRun.Enabled = true;
                    FileMarkStop.Enabled = true;
                });
                //启动线程
                ThreadStart();
                //切换按钮状态
                FileMarkRun.Text = "暂  停";
            }
            else
            {
                if (FileMarkRun.Text == "暂  停")
                {
                    FileMarkRun.Text = "继  续";
                    ThreadPause();//启动线程暂停
                }
                else if (FileMarkRun.Text == "继  续")
                {
                    FileMarkRun.Text = "暂  停";
                    ThreadResume();//恢复继续运行
                }
            }
        }
        /// <summary>
        /// 文件加工终止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileMarkStop_Click(object sender, EventArgs e)
        {
            if (running)//运行中
            {
                ThreadStop();//终止线程
            }
        }
        /// <summary>
        /// 加工终止后的动作
        /// </summary>
        public void EndMotion()
        {
            this.Invoke((EventHandler)delegate
            {
                //回退位置
                End_Pos_Go();
                /**********加工结束提醒***********/
                if (!Program.SystemContainer.IO.GlobalAlarm)
                {
                    if(Program.SystemContainer.SysPara.Con_endAlarm == 1)//0 - 不启用结束报警，其他 - 启用结束报警
                    {
                        //蜂鸣ON
                        Program.SystemContainer.IO.Beeze_Control = 1;
                    }
                }
                if (Program.SystemContainer.SysPara.Con_endDlg == 1)//0 - 不启用结束对话框，其他 - 启用结束对话框
                {
                    //弹出确认窗口
                    DialogResult dr = MessageBox.Show("加工结束！！！", "加工状态", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                //蜂鸣OFF
                if (!Program.SystemContainer.IO.GlobalAlarm) Program.SystemContainer.IO.Beeze_Control = 0;
                //状态切换
                if (running) running = !running;//切换运行状态
                FileMarkRun.Text = "启  动";
                //运行状态切换
                Program.SystemContainer.IO.GlobalRunnig = false;
                //按钮状态切换
                ButtonEnable();                
            });
            
        }
        
        /// <summary>
        /// 启动运行
        /// </summary>
        public void ThreadStart()
        {
            SectionWorkThread = new Thread(Runtime);
            SectionWorkThread.Start();
            SectionWorkThreadEnd = false;//清除 线程结束标志
        }
        /// <summary>
        /// 暂停运行
        /// </summary>
        public void ThreadPause()
        {
            on_off = true;
        }
        /// <summary>
        /// 恢复运行
        /// </summary>
        public void ThreadResume()
        {
            on_off = false;
            ma.Set();
        }
        /// <summary>
        /// 终止运行
        /// </summary>
        public void ThreadStop()
        {
            //置位退出标志
            stop = true;
            //检测是否在暂停中
            if (on_off)
            {
                ThreadResume();
            }
            do
            {
                Thread.Sleep(100);
            }
            while(!SectionWorkThreadEnd);
            SectionWorkThreadEnd = false;//清除 线程结束标志
            Thread.Sleep(30);
            //清除标志位
            on_off = false;
            stop = false;
            //加工结束 响应的动作
            StopEvent?.Invoke();
        }
        /// <summary>
        /// 循环结构
        /// </summary>
        public void Runtime()
        {
#if !DEBUG
            /****************启动前检测***************/
            //判断是否有报警
            if (Program.SystemContainer.IO.GlobalAlarm)
            {
                Info("检测设备报警发生，请复位设备并重新回零！！！");
                return;
            }
            //判断坐标系建立是否破坏
            //if ((Program.SystemContainer.IO.Axis01_mode != 5) || (Program.SystemContainer.IO.Axis01_mode != 5))
            //{
            //    Info("检测到平台坐标系未建立，请重新回零！！！");
            //    //非强制退出
            //    if (!stop)
            //    {
            //        //加工结束 响应的动作
            //        StopEvent?.Invoke();
            //    }
            //    return;
            //}
#endif
            //进入运行状态
            this.Invoke((EventHandler)delegate
            {
                Program.SystemContainer.IO.GlobalRunnig = true;
            });
            /****************加工方式选择***************/
            //选择加工方式
            this.Invoke((EventHandler)delegate
            {
                Work_Type_No = Array.IndexOf(Methods_List, Work_Type_Select_List.SelectedItem.ToString());
            });

            switch (Work_Type_No)
            {
                case 0://振镜空白和平台未补偿
                    Work_Running(0, 2);
                    break;
                case 1://振镜仿射和平台未补偿
                    Work_Running(0, 0);
                    break;
                case 2://振镜仿射和平台已补偿
                    Work_Running(1, 0);
                    break;
                case 3://振镜旋转和平台已补偿(废弃)
                    break;
                case 4://振镜矩阵和平台已补偿(废弃)
                    break;
                case 5://振镜桶形畸变图形加工
                    Rtc_Barrel_Distortion_Figure_Sculpture();
                    break;
                case 6://振镜桶形畸变数据采集
                    Rtc_Barrel_Distortion_Figure_Data_Acquisition();
                    break;
                case 7://振镜仿射矩阵图形加工(废弃)
                    break;
                case 8://振镜仿射矩阵数据采集(废弃)
                    break;
                case 9://Mark坐标试验证
                    Mark_Certify(MainLaserProject.FileList[0].PlatFormPos);
                    break;
                case 10://Mark坐标定位重矫正(废弃)
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
                case 16://计算标定板旋转参数(废弃)
                    break;
                case 17://标定板对齐校准
                    Calibration_Original_Data_Collect();
                    break;
                case 18://标定板校准验证
                    Get_Borad_Certify_Datas();
                    break;
                case 19://振镜空白和平台已补偿
                    Work_Running(1, 2);
                    break;
                case 20://标定板多次校准 
                    Calibration_Multiple_Data_Collect();
                    break;
                case 21://获取当前平台坐标
                    Vector TemPoint = Program.SystemContainer.GTS_Fun.Get_Coordinate(1);
                    MessageBox.Show(string.Format("({0},{1})", TemPoint.X.ToString(4), TemPoint.Y.ToString(4)));
                    break;
                case 22://指定点数据校准
                    Specific_List_Certify();
                    break;
                case 23://Rtc仿射校准数据采集
                    Rtc_Affinity_Data_Acquisition();
                    break;
                default:
                    break;
            }
            /************非强制退出************/
            //非强制退出
            if (!stop)
            {
                //加工结束 响应的动作
                StopEvent?.Invoke();
            }
            /************线程结束标志************/
            SectionWorkThreadEnd = true;//置位 线程结束标志
        }

        /// <summary>
        /// 解析数据
        /// </summary>
        public void ResolveData()
        {
            //解析项目工程
            if (MainLaserProject.FileList.Count <= 0)
            {
                MessageBox.Show("项目中无可用文件！！！");
                return;
            }
            //读取DXF文件
            DxfDocument dxf = DataResolve.Read_File(MainLaserProject.FileList[0].Path);
            if (dxf == null)
            {
                MessageBox.Show(string.Format("{0}数据读取失败！！！", MainLaserProject.FileList[0].Name));
                return;
            }
            //指定文件名
            File_Entity_Datas = new File_Entity_Data();
            File_Entity_Datas.FileName = MainLaserProject.FileList[0].Name;
            //提取Mark信息
            if (Program.SystemContainer.SysPara.Calibration_Type == 1)// 1 - 整块板Mark定位(取4角)
            {
                File_Entity_Datas.DxfMarkInfo = DataResolve.DistractMark(dxf, "Mark");//mark信息
            }
            //获取分区编号序列
            File_Entity_Datas.SectionList = new List<int>();
            foreach (var o in MainLaserProject.FileList[0].LaserLayer)
            {
                File_Entity_Datas.SectionList.AddRange(DataResolve.DistractSectionColor(dxf, o));//追加数据
            }
            File_Entity_Datas.SectionList = File_Entity_Datas.SectionList.Distinct().OrderBy(o => o).ToList();
            if (File_Entity_Datas.SectionList.Count <= 0) return;
            //按分区提取数据
            Integrate_Entity_Data TemData = new Integrate_Entity_Data();//图层数据
            Section_Entity_Data TemSectionData = new Section_Entity_Data();//分区数据
            foreach (var o in MainLaserProject.FileList[0].LaserLayer)
            {
                TemData.LayerName = o;
                foreach (var p in File_Entity_Datas.SectionList)
                {
                    TemSectionData.Color = p;
                    TemSectionData.ArcLine = DataResolve.DistractArcLine(dxf, p, o);//圆弧直线数据
                    TemSectionData.Circle = DataResolve.DistractCircle(dxf, p, o);//整圆数据
                    TemSectionData.LWPolyline = DataResolve.DistractLWPolyline(dxf, p, o);//多边形数据
                    TemData.SectionEntityDatas.Add(new Section_Entity_Data(TemSectionData));
                    TemSectionData.Empty();//释放数据
                }
                File_Entity_Datas.LayerSectionDatas.Add(new Integrate_Entity_Data(TemData));
                TemData.Empty();//释放数据
            }
            
        }

        /// <summary>
        /// Mark定位 矫正偏转
        /// </summary>
        /// <param name="File_Entity_Datas"></param>
        /// <returns></returns>
        public bool CalibrateFileData(File_Entity_Data File_Entity_Datas,Vector PlatformPos)
        {
            Affinity_Matrix Matrix = new Affinity_Matrix();
            //重新梳理Mark信息            
            if (Program.SystemContainer.SysPara.Calibration_Type == 1)//0 - 原点起始加工；1 - 整块板Mark定位(取4角)；2 - 指定点起始加工
            {
                File_Entity_Datas.PlatformMarkInfo.Clear();//清空平台Mark坐标
                foreach (var o in File_Entity_Datas.DxfMarkInfo)
                {
                    File_Entity_Datas.PlatformMarkInfo.Add(new Vector(o.X + PlatformPos.X, o.Y + PlatformPos.Y));
                }
                //Mark点位数量异常
                if ((File_Entity_Datas.PlatformMarkInfo.Count < 3) || (File_Entity_Datas.DxfMarkInfo.Count < 3))
                {
                    MessageBox.Show("Mark定位点位数据异常！！！");
                    return false;
                }
                //获取整图偏转参数
                Matrix = Calibration.Calibrate_Mark(File_Entity_Datas.DxfMarkInfo, File_Entity_Datas.PlatformMarkInfo);
                if (Matrix == null) return false;//Mark校准失败
                //处理所有分区数据
                for (int i = 0; i < File_Entity_Datas.LayerSectionDatas.Count; i++)
                {
                    for (int j = 0; j < File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas.Count; j++)
                    {
                        File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas[j].ArcLine = DataResolve.CalDataByMatrix(File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas[j].ArcLine, Matrix, Program.SystemContainer.SysPara.Calibration_Type);
                        File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas[j].Circle = DataResolve.CalDataByMatrix(File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas[j].Circle, Matrix, Program.SystemContainer.SysPara.Calibration_Type);
                        File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas[j].LWPolyline = DataResolve.CalDataByMatrix(File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas[j].LWPolyline, Matrix, Program.SystemContainer.SysPara.Calibration_Type);
                    }
                }
            }
            else if (Program.SystemContainer.SysPara.Calibration_Type == 2)//0 - 原点起始加工；1 - 整块板Mark定位(取4角)；2 - 指定点起始加工
            {
                //处理数据
                for (int i = 0; i < File_Entity_Datas.LayerSectionDatas.Count; i++)
                {
                    for (int j = 0; j < File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas.Count; j++)
                    {
                        File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas[j].ArcLine = DataResolve.CalDataByMatrix(File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas[j].ArcLine, Matrix, Program.SystemContainer.SysPara.Calibration_Type);
                        File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas[j].Circle = DataResolve.CalDataByMatrix(File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas[j].Circle, Matrix, Program.SystemContainer.SysPara.Calibration_Type);
                        File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas[j].LWPolyline = DataResolve.CalDataByMatrix(File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas[j].LWPolyline, Matrix, Program.SystemContainer.SysPara.Calibration_Type);
                    }
                }
            }
            else//无Mark定位校准数据处理
            {
                //处理数据
                for (int i = 0; i < File_Entity_Datas.LayerSectionDatas.Count; i++)
                {
                    for (int j = 0; j < File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas.Count; j++)
                    {
                        File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas[j].ArcLine = DataResolve.CalDataByMatrix(File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas[j].ArcLine, Matrix, Program.SystemContainer.SysPara.Calibration_Type);
                        File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas[j].Circle = DataResolve.CalDataByMatrix(File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas[j].Circle, Matrix, Program.SystemContainer.SysPara.Calibration_Type);
                        File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas[j].LWPolyline = DataResolve.CalDataByMatrix(File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas[j].LWPolyline, Matrix, Program.SystemContainer.SysPara.Calibration_Type);
                    }
                }
            }
            //整合分区内包含多图层数据
            int index = 0;//索引
            SectionData TempSectionData = new SectionData();
            SectionDataCollection TempSectionDataCollection = new SectionDataCollection();//空分区数据
            foreach (var o in File_Entity_Datas.SectionList)
            {
                //数据清空
                TempSectionDataCollection = new SectionDataCollection();
                //记录分区编号
                TempSectionDataCollection.Color = o;
                //整合数据
                foreach (var p in File_Entity_Datas.LayerSectionDatas)
                {
                    //数据清空
                    TempSectionData = new SectionData();
                    //标注图层名
                    TempSectionData.LayerName = p.LayerName;
                    //获取索引
                    index = p.SectionEntityDatas.FindIndex(m => m.Color == o);//获取当前分区编号数据索引
                    if (index == -1)
                    {
                        TempSectionData.EN = false;
                    }
                    else
                    {
                        TempSectionData.EN = true;
                        TempSectionData.ArcLine = new List<List<Entity_Data>>(p.SectionEntityDatas[index].ArcLine);//圆弧直线数据
                        TempSectionData.Circle = new List<Entity_Data>(p.SectionEntityDatas[index].Circle);//整圆数据
                        TempSectionData.LWPolyline = new List<List<Entity_Data>>(p.SectionEntityDatas[index].LWPolyline);//折线数据
                    }
                    //追加数据
                    TempSectionDataCollection.SectionDatas.Add(new SectionData(TempSectionData));
                }
                //追加数据
                File_Entity_Datas.SectionDataCollections.Add(new SectionDataCollection(TempSectionDataCollection));
            }
            //分区数据计算
            File_Entity_Datas = DataResolve.SeperateFileData(File_Entity_Datas);
            //返回
            return true;
        }

        /// <summary>
        /// 推入数据进入控制器，并加工 Gts: 0 - 不矫正，1 - 矫正；Rtc: 0 - 仿射矫正，1 - 桶形畸变，2 - 无仿射矫正
        /// </summary>
        /// <param name="File_Entity_Datas"></param>
        /// <param name="Gts"></param>
        /// <param name="Rtc"></param>
        public void PushDataToController(File_Entity_Data File_Entity_Datas,int Gts,int Rtc)
        {
            //急停按钮按下终止运行
            if (Program.SystemContainer.IO.GlobalEMG)
            {
                return;
            }
            //选择分区加工方式
            switch (Program.SystemContainer.SysPara.SectionWorkType)
            {
                case 0://单分区中多图层加工
                    SectionWorkType_0(File_Entity_Datas, Gts, Rtc);
                    break;
                case 1://单分区中单图层加工
                    SectionWorkType_1(File_Entity_Datas, Gts, Rtc);
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 单振镜多刀具加工----Gts: 0 - 不矫正，1 - 矫正；Rtc: 0 - 仿射矫正，1 - 桶形畸变，2 - 无仿射矫正
        /// </summary>
        private void SectionWorkType_0(File_Entity_Data File_Entity_Datas, int Gts, int Rtc)
        {
            int ScissorIndex = 0;
            List<string> ScissorList = new List<string>();//刀具列表
            Tech_Parameter ScissorPara = new Tech_Parameter();//刀具参数
            foreach (var o in File_Entity_Datas.SectionDataCollections)
            {
                //分区数据
                foreach (var m in o.SectionDatas)
                {
                    //启用刀具参数
                    ScissorList = GetScissorList(File_Entity_Datas.FileName, m.LayerName);//获取当前图层刀具列表
                    if (ScissorList.Count <= 0)
                    {
                        MessageBox.Show(string.Format("图层:{0},未指定刀具，该图层加工终止！！", m.LayerName));
                        return;//未指定刀具
                    }
                    //循环调用刀具参数
                    foreach (var s in ScissorList)
                    {
                        ScissorIndex = Program.SystemContainer.ScissorList.FindIndex(t => t.Scissors_Name == s);//获取刀具索引
                        if (ScissorIndex == -1)//不含此刀具
                        {
                            MessageBox.Show(string.Format("刀具:{0}，不存在加工终止！！", s));
                            return;//未指定刀具
                        }
                        ScissorPara = new Tech_Parameter(Program.SystemContainer.ScissorList[ScissorIndex]);//提取刀具参数
#if !DEBUG
                        Program.SystemContainer.RTC_Fun.Scissors_Para_Exe(ScissorPara, Program.SystemContainer.SysPara.MarkJump);//启用刀具参数
                        //判断是否开始红光预览                                                                                                         //红光预览
                        if (!Program.SystemContainer.SysPara.MarkJump)
                            Program.SystemContainer.IO.RedLaser_Control = 1;//开启红光
#endif
                        //按照刀具参数进行加工
                        for (int i = 1; i < ScissorPara.RepeatTime + 1; i++)//加工次数
                        {
                            /*********************************************/
                            //加工前动作  
                            //Z轴动作
                            if (i == 1)//初始Z轴高度
                            {
                                //定位到Z轴高度
                            }
                            //循序步进Z轴高度 
                            if ((ScissorPara.FocusCompensationTimes > 0) && ((i % ScissorPara.FocusCompensationTimes) == 0))
                            {
                                //Z轴步进值
                            }

                            /*********************************************/
                            //加工过程
                            //关闭激光
                            Program.SystemContainer.RTC_Fun.Close_Laser();
                            //平台定位
                            if(!Program.SystemContainer.GTS_Fun.Gts_Point_Go(o.Centre, Gts))
                            {
                                MessageBox.Show("平台定位异常，加工终止！！！");
                                return;
                            }
                            //急停按钮按下终止运行
                            if (Program.SystemContainer.IO.GlobalEMG)
                            {
                                return;
                            }
                            //运行和暂停切换
                            if (on_off)
                            {
                                ma = new ManualResetEvent(false);
                                ma.WaitOne();
                            }
                            //退出循环
                            if (stop)
                            {
                                return;
                            }

                            //振镜加工轨迹推入
                            Program.SystemContainer.RTC_Fun.Draw_Mark(m, 1, Rtc);
                            //关闭激光
                            Program.SystemContainer.RTC_Fun.Close_Laser();
                            /*********************************************/
                            //加工结束
                            //延时操作
                            if ((ScissorPara.DelayCompensationTimes > 0) && ((i % ScissorPara.DelayCompensationTimes) == 0))
                            {
                                Thread.Sleep(ScissorPara.DelayCompensation);//延时
                            }
#if !DEBUG
                            //测试代码
                            //appendInfo("当前次数：" + i);
                            //Thread.Sleep(1000);
#endif
                        }
                        
                        //判断是否开始红光预览                                                                                                         //红光预览
                        if (!Program.SystemContainer.SysPara.MarkJump)
                            Program.SystemContainer.IO.RedLaser_Control = 0;//关闭红光
                    }
                }
            }
            //回退Rtc Home
#if !DEBUG
            Program.SystemContainer.RTC_Fun.Home();
#endif
        }
        /// <summary>
        /// 单刀具分振镜加工----Gts: 0 - 不矫正，1 - 矫正；Rtc: 0 - 仿射矫正，1 - 桶形畸变，2 - 无仿射矫正
        /// </summary>
        private void SectionWorkType_1(File_Entity_Data File_Entity_Datas, int Gts, int Rtc)
        {
            int ScissorIndex = 0;
            List<string> ScissorList = new List<string>();//刀具列表
            Tech_Parameter ScissorPara = new Tech_Parameter();//刀具参数
            foreach (var o in File_Entity_Datas.LayerSectionDatas)
            {
                //启用刀具参数
                ScissorList = GetScissorList(File_Entity_Datas.FileName, o.LayerName);//获取当前图层刀具列表
                if (ScissorList.Count <= 0)
                {
                    MessageBox.Show(string.Format("图层:{0},未指定刀具，该图层加工终止！！", o.LayerName));
                    return;//未指定刀具
                }
                //循环调用刀具参数
                foreach (var s in ScissorList)
                {
                    ScissorIndex = Program.SystemContainer.ScissorList.FindIndex(t => t.Scissors_Name == s);//获取刀具索引
                    if (ScissorIndex == -1)//不含此刀具
                    {
                        MessageBox.Show(string.Format("刀具:{0}，不存在加工终止！！", s));
                        return;//未指定刀具
                    }
                    ScissorPara = new Tech_Parameter(Program.SystemContainer.ScissorList[ScissorIndex]);//提取刀具参数
#if !DEBUG
                    Program.SystemContainer.RTC_Fun.Scissors_Para_Exe(ScissorPara, Program.SystemContainer.SysPara.MarkJump);//启用刀具参数
                    //判断是否开始红光预览                                                                                                         //判断是否开始红光预览                                                                                                         //红光预览
                    if (!Program.SystemContainer.SysPara.MarkJump)
                        Program.SystemContainer.IO.RedLaser_Control = 1;//开启红光
#endif
                    //按照刀具参数进行加工
                    for (int i = 1; i < ScissorPara.RepeatTime + 1; i++)//加工次数
                    {
                        /*********************************************/
                        //加工前动作  
                        //Z轴动作
                        if (i == 1)//初始Z轴高度
                        {
                            //定位到Z轴高度
                        }
                        //循序步进Z轴高度 
                        if ((ScissorPara.FocusCompensationTimes > 0) && ((i % ScissorPara.FocusCompensationTimes) == 0))
                        {
                            //Z轴步进值
                        }
                        /*********************************************/
                        //加工中
                        foreach (var p in o.SectionEntityDatas)
                        {
                            //关闭激光
                            Program.SystemContainer.RTC_Fun.Close_Laser();

                            //平台定位
                            if(!Program.SystemContainer.GTS_Fun.Gts_Point_Go(p.Centre, Gts))
                            {
                                MessageBox.Show("平台定位异常，加工终止！！！");
                                return;
                            }
                            //急停按钮按下终止运行
                            if (Program.SystemContainer.IO.GlobalEMG)
                            {
                                return;
                            }
                            //运行和暂停切换
                            if (on_off)
                            {
                                ma = new ManualResetEvent(false);
                                ma.WaitOne();
                            }
                            //退出循环
                            if (stop)
                            {
                                return;
                            }
                            //振镜加工轨迹推入
                            Program.SystemContainer.RTC_Fun.Draw_Mark(p, 1, Rtc);
                            //关闭激光
                            Program.SystemContainer.RTC_Fun.Close_Laser();
                        }
                        /*********************************************/
                        //加工结束
                        //延时操作
                        if ((ScissorPara.DelayCompensationTimes > 0) && ((i % ScissorPara.DelayCompensationTimes) == 0))
                        {
                            Thread.Sleep(ScissorPara.DelayCompensation);//延时
                        }
#if !DEBUG
                        //测试代码
                        //appendInfo("当前次数：" + i);
                        //Thread.Sleep(1000);
#endif
                    }
                    //判断是否开始红光预览                                                                                                         //判断是否开始红光预览                                                                                                         //红光预览
                    if (!Program.SystemContainer.SysPara.MarkJump)
                        Program.SystemContainer.IO.RedLaser_Control = 0;//关闭红光
                }
            }
            //回退Rtc Home
#if !DEBUG
            Program.SystemContainer.RTC_Fun.Home();
#endif
        }
        /// <summary>
        /// 获取指定图层的刀具列表
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="LayerName"></param>
        /// <returns></returns>
        public List<string> GetScissorList(string FileName,string LayerName)
        {
            int FileIndex = MainLaserProject.FileList.FindIndex(o =>o.Name == FileName);//获取文件索引
            int LayerScissorIndex = MainLaserProject.FileList[FileIndex].LayerScissor.FindIndex(o =>o.Layer == LayerName);//获取图层索引
            return new List<string>(MainLaserProject.FileList[FileIndex].LayerScissor[LayerScissorIndex].Scissor);//返回刀具列表
        }

        /// <summary>
        /// 定位归卸料位
        /// </summary>
        public void End_Pos_Go()
        {
            Vector Temp = new Vector(0, 0);
            switch (Program.SystemContainer.SysPara.PrecessEnd)
            {
                case 0://无动作
                    return;
                case 1://归零
                    Temp = new Vector(0, 0);
                    break;
                case 2://左暂停位
                    Temp = new Vector(Program.SystemContainer.SysPara.LeftPausePoint);
                    break;
                case 3://右暂停位
                    Temp = new Vector(Program.SystemContainer.SysPara.RightPausePoint);
                    break;
                case 4://上下料位
                    Temp = new Vector(Program.SystemContainer.SysPara.Upload_Point);
                    break;
                default:
                    break;
            }
            //判断定位坐标是否合适
            Vector MarkPoint = Temp - Program.SystemContainer.SysPara.Rtc_Org;
            //判断坐标是否超出定位范围
            if (!DeterminePoint(MarkPoint)) return;
            //定位至激光对准的原点坐标
            if (!Program.SystemContainer.GTS_Fun.Gts_Point_Go(MarkPoint, 1))
            {
                MessageBox.Show("平台定位异常，加工终止！！！");
                return;
            }           
        }

        /// <summary>
        /// 振镜桶形畸变图形加工
        /// </summary>
        private void Rtc_Barrel_Distortion_Figure_Sculpture()
        {
            int RtcXNum = (Int16)(Program.SystemContainer.SysPara.Rtc_Calibration_X_Len / Program.SystemContainer.SysPara.Rtc_Calibration_X_Cell) % 2;
            int RtcYNum = (Int16)(Program.SystemContainer.SysPara.Rtc_Calibration_Y_Len / Program.SystemContainer.SysPara.Rtc_Calibration_Y_Cell) % 2;
            if ((RtcXNum != 0) || (RtcYNum != 0))
            {
                appendInfo(string.Format("振镜矫正范围除以打标间距：X-{0}或Y-{1}不为偶数，禁止加工！！！", RtcXNum,RtcYNum));
                return;
            }
            else
            {
                int ScissorIndex = 0;
                Tech_Parameter ScissorPara = new Tech_Parameter();//刀具参数
                //待加工数据
                List<Section_Entity_Data> Mark_Datas = new List<Section_Entity_Data>(Calibration.Create_Rtc_Calibrate_Data(0, Program.SystemContainer.SysPara.Rtc_Distortion_Data_Radius, Program.SystemContainer.SysPara.Rtc_Calibration_X_Cell, Program.SystemContainer.SysPara.Rtc_Calibration_Y_Cell, Program.SystemContainer.SysPara.Rtc_Calibration_X_Len, Program.SystemContainer.SysPara.Rtc_Calibration_Y_Len));//十个一组
                //启用刀具参数
                ScissorIndex = Program.SystemContainer.ScissorList.FindIndex(t => t.Scissors_Name == Program.SystemContainer.SysPara.Calibrate_Mark_Scissor);//获取刀具索引
                if (ScissorIndex == -1)//不含此刀具
                {
                    MessageBox.Show(string.Format("刀具:{0}，不存在加工终止！！", Program.SystemContainer.SysPara.Calibrate_Mark_Scissor));
                    return;//未指定刀具
                }
                ScissorPara = new Tech_Parameter(Program.SystemContainer.ScissorList[ScissorIndex]);//提取刀具参数
                Program.SystemContainer.RTC_Fun.Scissors_Para_Exe(ScissorPara, Program.SystemContainer.SysPara.MarkJump);//启用刀具参数
                //按照刀具参数进行加工
                for (int i = 1; i < ScissorPara.RepeatTime + 1; i++)//加工次数
                {
                    /*********************************************/
                    //加工前动作  
                    //Z轴动作
                    if (i == 1)//初始Z轴高度
                    {
                        //定位到Z轴高度
                    }
                    //循序步进Z轴高度 
                    if ((ScissorPara.FocusCompensationTimes > 0) && ((i % ScissorPara.FocusCompensationTimes) == 0))
                    {
                        //Z轴步进值
                    }
                    /*********************************************/
                    //加工中
                    foreach (var p in Mark_Datas)
                    {
                        //关闭激光
                        Program.SystemContainer.RTC_Fun.Close_Laser();
                        //平台定位
                        if(!Program.SystemContainer.GTS_Fun.Gts_Point_Go(p.Centre,1))
                        {
                            MessageBox.Show("平台定位异常，加工终止！！！");
                            return;
                        }

                        //运行和暂停切换
                        if (on_off)
                        {
                            ma = new ManualResetEvent(false);
                            ma.WaitOne();
                        }
                        //退出循环
                        if (stop)
                        {
                            return;
                        }

                        //振镜加工轨迹推入
                        Program.SystemContainer.RTC_Fun.Draw_Mark(p, 1, 1);

                        //关闭激光
                        Program.SystemContainer.RTC_Fun.Close_Laser();
                    }
                    /*********************************************/
                    //加工结束
                    //延时操作
                    if ((ScissorPara.DelayCompensationTimes > 0) && ((i % ScissorPara.DelayCompensationTimes) == 0))
                    {
                        Thread.Sleep(ScissorPara.DelayCompensation);//延时
                    }
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
                //生成相机采集数据点位
                List<Vector> Aquisition_Point = new List<Vector>();
                List<Vector> Rtc_Point = new List<Vector>();
                Vector CurrenPoint = Program.SystemContainer.SysPara.Debug_Gts_Basis - Program.SystemContainer.SysPara.Rtc_Org;
                Vector GtsBasic = CurrenPoint + Program.SystemContainer.SysPara.Rtc_Org;
                Vector Cam = new Vector();
                Vector Tem_Mark = new Vector();
                Vector Coordinate = new Vector();
                Vector Tem_Datum = new Vector();
                int Counting = 0;
                //数据采集
                DataTable Temp_Acquisition = new DataTable();
                Temp_Acquisition.Columns.Add("振镜坐标X", typeof(decimal));
                Temp_Acquisition.Columns.Add("振镜坐标Y", typeof(decimal));
                Temp_Acquisition.Columns.Add("实际坐标X", typeof(decimal));
                Temp_Acquisition.Columns.Add("实际坐标Y", typeof(decimal));
                DataTable Calibration_Data_Acquisition = new DataTable();
                Calibration_Data_Acquisition.Columns.Add("振镜坐标X", typeof(decimal));
                Calibration_Data_Acquisition.Columns.Add("振镜坐标Y", typeof(decimal));
                Calibration_Data_Acquisition.Columns.Add("实际坐标X", typeof(decimal));
                Calibration_Data_Acquisition.Columns.Add("实际坐标Y", typeof(decimal));
                //计算总间距
                int NoX = (Int16)(Program.SystemContainer.SysPara.Rtc_Calibration_X_Len / Program.SystemContainer.SysPara.Rtc_Calibration_X_Cell);
                int NoY = (Int16)(Program.SystemContainer.SysPara.Rtc_Calibration_Y_Len / Program.SystemContainer.SysPara.Rtc_Calibration_Y_Cell);
                ///Rtc要求数据 顺序：左上角-->右上角 Y坐标不变，依次变更X坐标
                ///Gts匹配 顺序：右上角-->右下角 X坐标不变，依次变更Y坐标 （Rts坐标轴交换，同时Rtc的X轴方向取反）
                for (int i = NoY / 2; i >= -NoY / 2; i--)//Y
                {
                    for (int j = NoX / 2; j >= -NoX / 2; j--)//X
                    {
                        Aquisition_Point.Add(new Vector(GtsBasic.X + i * Program.SystemContainer.SysPara.Rtc_Calibration_X_Cell, GtsBasic.Y + j * Program.SystemContainer.SysPara.Rtc_Calibration_Y_Cell));
                    }
                }
                //振镜打标数据
                for (int i = -NoY / 2; i <= NoY / 2; i++)//Y坐标
                {
                    for (int j = -NoX / 2; j <= NoX / 2; j++)//X坐标
                    {
                        Rtc_Point.Add(new Vector(j * Program.SystemContainer.SysPara.Rtc_Calibration_X_Cell, -i * Program.SystemContainer.SysPara.Rtc_Calibration_Y_Cell));
                    }
                }
                //进行数据采集
                if (Rtc_Point.Count == Aquisition_Point.Count)
                {
                    for (int i = 0; i < Aquisition_Point.Count; i++)
                    {

                        /*********************获取矫正数据**********************/
                        Tem_Mark = new Vector(Aquisition_Point[i]);
                        Counting = 0;
                        if (Program.SystemContainer.SysPara.Rtc_Get_Data_Align == 1)
                        {
                            //对齐中心
                            do
                            {
                                /*******线程控制部分**********/
                                //运行和暂停切换
                                if (on_off)
                                {
                                    ma = new ManualResetEvent(false);
                                    ma.WaitOne();
                                }
                                //退出循环
                                if (stop)
                                {
                                    CSV_RW.SaveCSV(Temp_Acquisition, "Rtc_Data_Aquisition_Temp_Exit");//原始数据保存
                                    CSV_RW.SaveCSV(Calibration_Data_Acquisition, "Rtc_Data_Aquisition_Exit");//原始数据保存
                                    return;
                                }
                                /*******数据采集部分**********/
                                if (!Program.SystemContainer.GTS_Fun.Gts_Point_Go(Tem_Mark,1))
                                {
                                    MessageBox.Show("平台定位异常，加工终止！！！");
                                    return;
                                }
                                //调用相机，获取对比的坐标信息
                                Thread.Sleep(500);
                                //相机反馈的当前坐标
                                Cam = new Vector(Program.SystemContainer.T_Client.Get_Cam_Deviation_Coordinate_Correct(Program.SystemContainer.SysPara.Camera_Intrigue_Sequence));//触发拍照 
                                if (Cam.Length == 0)
                                {
                                    MessageBox.Show("相机坐标提取失败，请检查！！！");
                                    CSV_RW.SaveCSV(Temp_Acquisition, "Rtc_Data_Aquisition_Temp_Fail");//原始数据保存
                                    CSV_RW.SaveCSV(Calibration_Data_Acquisition, "Rtc_Data_Aquisition_Fail");//原始数据保存
                                    return;
                                }
                                Coordinate = Program.SystemContainer.GTS_Fun.Get_Coordinate(1);
                                Tem_Mark = new Vector(Coordinate - Cam);//获取实际位置
                                //统计对齐次数
                                Counting++;
                                if (Counting > 20)
                                {
                                    MainFormLogErr(string.Format("坐标({0},{1}),超出对齐次数！！！", Tem_Mark.X, Tem_Mark.Y));
                                    break;//退出继续对齐
                                }
                            } while (!Differ_Deviation(Cam, Program.SystemContainer.SysPara.Pos_Tolerance));
                        }
                        else
                        {
                            //实际测量
                            if(!Program.SystemContainer.GTS_Fun.Gts_Point_Go(Tem_Mark,1))
                            {
                                MessageBox.Show("平台定位异常，加工终止！！！");
                                return;
                            }
                            //调用相机，获取对比的坐标信息
                            Thread.Sleep(500);
                            //相机反馈的当前坐标
                            Cam = new Vector(Program.SystemContainer.T_Client.Get_Cam_Deviation_Coordinate_Correct(Program.SystemContainer.SysPara.Camera_Intrigue_Sequence));//触发拍照 
                            if (Cam.Length == 0)
                            {
                                MessageBox.Show("相机坐标提取失败，请检查！！！");
                                CSV_RW.SaveCSV(Temp_Acquisition, "Rtc_Data_Aquisition_Temp_Fail");//原始数据保存
                                CSV_RW.SaveCSV(Calibration_Data_Acquisition, "Rtc_Data_Aquisition_Fail");//原始数据保存
                                return;
                            }
                            Coordinate = Program.SystemContainer.GTS_Fun.Get_Coordinate(1);
                        }
                        //添加数据
                        Temp_Acquisition.Rows.Add(new object[] { Rtc_Point[i].X, Rtc_Point[i].Y, Tem_Mark.Y, Tem_Mark.X });

                        /*******线程控制部分**********/
                        //运行和暂停切换
                        if (on_off)
                        {
                            ma = new ManualResetEvent(false);
                            ma.WaitOne();
                        }
                        //退出循环
                        if (stop)
                        {
                            CSV_RW.SaveCSV(Temp_Acquisition, "Rtc_Data_Aquisition_Temp_Exit");//原始数据保存
                            CSV_RW.SaveCSV(Calibration_Data_Acquisition, "Rtc_Data_Aquisition_Exit");//原始数据保存
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("打标数据不匹配！！！");
                    return;
                }

                /*******数据处理********/
                //Tem_Datum = new Vector(Convert.ToDecimal(Temp_Acquisition.Rows[((NoX + 1) * (NoY + 1) - 1) / 2][2].ToString()), Convert.ToDecimal(Temp_Acquisition.Rows[((NoX + 1) * (NoY + 1) - 1) / 2][3].ToString()));
                Tem_Datum = new Vector(GtsBasic);//中心点坐标
                //数据处理
                for (int i = 0; i < Temp_Acquisition.Rows.Count; i++)
                {
                    decimal t1, t2, t3, t4;
                    t1 = Convert.ToDecimal(Temp_Acquisition.Rows[i][0].ToString());
                    t2 = Convert.ToDecimal(Temp_Acquisition.Rows[i][1].ToString());
                    t3 = Convert.ToDecimal(Temp_Acquisition.Rows[i][2].ToString());
                    t4 = Convert.ToDecimal(Temp_Acquisition.Rows[i][3].ToString());
                    Calibration_Data_Acquisition.Rows.Add(new object[] { t1, t2, -(t3 - Tem_Datum.X), (t4 - Tem_Datum.Y) });
                }
                CSV_RW.SaveCSV(Temp_Acquisition, "Rtc_Data_Aquisition_Temp");//原始数据保存
                CSV_RW.SaveCSV(Calibration_Data_Acquisition, "Rtc_Data_Aquisition");//原始数据保存
            }
            else
            {
                appendInfo("只支持整圆图形采集！！！！");
            }
        }

        /// <summary>
        /// 振镜仿射矫正数据采集
        /// </summary>
        private void Rtc_Affinity_Data_Acquisition() 
        {
            if (Program.SystemContainer.SysPara.Rtc_Distortion_Data_Type == 0)//只采集整圆图形
            {
                //生成相机采集数据点位
                List<Vector> Aquisition_Point = new List<Vector>();
                Vector CurrenPoint = Program.SystemContainer.SysPara.Debug_Gts_Basis - Program.SystemContainer.SysPara.Rtc_Org;
                Vector GtsBasic = CurrenPoint + Program.SystemContainer.SysPara.Rtc_Org;
                Vector Cam = new Vector();
                Vector Tem_Mark = new Vector();
                Vector Coordinate = new Vector();
                Vector Tem_Datum = new Vector();
                int Counting = 0;
                //数据采集
                DataTable Temp_Acquisition = new DataTable();
                Temp_Acquisition.Columns.Add("振镜坐标X", typeof(decimal));
                Temp_Acquisition.Columns.Add("振镜坐标Y", typeof(decimal));
                Temp_Acquisition.Columns.Add("实际坐标X", typeof(decimal));
                Temp_Acquisition.Columns.Add("实际坐标Y", typeof(decimal));
                DataTable Calibration_Data_Acquisition = new DataTable();
                Calibration_Data_Acquisition.Columns.Add("振镜坐标X", typeof(decimal));
                Calibration_Data_Acquisition.Columns.Add("振镜坐标Y", typeof(decimal));
                Calibration_Data_Acquisition.Columns.Add("实际坐标X", typeof(decimal));
                Calibration_Data_Acquisition.Columns.Add("实际坐标Y", typeof(decimal));
                //计算总间距
                int NoX = (Int16)(Program.SystemContainer.SysPara.Rtc_Calibration_X_Len / Program.SystemContainer.SysPara.Rtc_Calibration_X_Cell);
                int NoY = (Int16)(Program.SystemContainer.SysPara.Rtc_Calibration_Y_Len / Program.SystemContainer.SysPara.Rtc_Calibration_Y_Cell);
                ///Affinity要求数据 顺序：左下角-->右下角 Y坐标不变，依次变更X坐标
                ///
                ///Gts匹配 顺序：左下角-->右下角 Y坐标不变，依次变更X坐标
                for (int i = -NoY / 2; i <= NoY / 2; i++)//Y坐标
                {
                    for (int j = -NoY / 2; j <= NoY / 2; j++)//X坐标
                    {
                        Aquisition_Point.Add(new Vector(j * Program.SystemContainer.SysPara.Rtc_Calibration_X_Cell, i * Program.SystemContainer.SysPara.Rtc_Calibration_Y_Cell));
                    }
                }
                //进行数据采集
                for (int i = 0; i < Aquisition_Point.Count; i++)
                {
                    /*******线程控制部分**********/
                    //运行和暂停切换
                    if (on_off)
                    {
                        ma = new ManualResetEvent(false);
                        ma.WaitOne();
                    }
                    //退出循环
                    if (stop)
                    {
                        CSV_RW.SaveCSV(Temp_Acquisition, "Rtc_Affinity_Acquisition/Rtc_Affinity_Data_Aquisition_Temp_Exit");//原始数据保存
                        CSV_RW.SaveCSV(Calibration_Data_Acquisition, "Rtc_Affinity_Acquisition/Rtc_Affinity_Data_Aquisition_Exit");//原始数据保存
                        return;
                    }

                    /*********************获取矫正数据**********************/
                    Tem_Mark = new Vector(Aquisition_Point[i]);
                    Counting = 0;
                    if (Program.SystemContainer.SysPara.Rtc_Get_Data_Align == 1)
                    {
                        //对齐中心
                        do
                        {
                            /*******线程控制部分**********/
                            //运行和暂停切换
                            if (on_off)
                            {
                                ma = new ManualResetEvent(false);
                                ma.WaitOne();
                            }
                            //退出循环
                            if (stop)
                            {
                                CSV_RW.SaveCSV(Temp_Acquisition, "Rtc_Affinity_Acquisition/Rtc_Affinity_Data_Aquisition_Temp_Exit");//原始数据保存
                                CSV_RW.SaveCSV(Calibration_Data_Acquisition, "Rtc_Affinity_Acquisition/Rtc_Affinity_Data_Aquisition_Exit");//原始数据保存
                                return;
                            }
                            /*******数据采集部分**********/
                            if (!Program.SystemContainer.GTS_Fun.Gts_Point_Go(Tem_Mark, 1))
                            {
                                MessageBox.Show("平台定位异常，加工终止！！！");
                                return;
                            }
                            //调用相机，获取对比的坐标信息
                            Thread.Sleep(500);
                            //相机反馈的当前坐标
                            Cam = new Vector(Program.SystemContainer.T_Client.Get_Cam_Deviation_Coordinate_Correct(Program.SystemContainer.SysPara.Camera_Intrigue_Sequence));//触发拍照 
                            if (Cam.Length == 0)
                            {
                                MessageBox.Show("相机坐标提取失败，请检查！！！");
                                CSV_RW.SaveCSV(Temp_Acquisition, "Rtc_Affinity_Acquisition/Rtc_Affinity_Data_Aquisition_Temp_Cam_Fail");//原始数据保存
                                CSV_RW.SaveCSV(Calibration_Data_Acquisition, "Rtc_Affinity_Acquisition/Rtc_Affinity_Data_Aquisition_Cam_Fail");//原始数据保存
                                return;
                            }
                            Coordinate = Program.SystemContainer.GTS_Fun.Get_Coordinate(1);
                            Tem_Mark = new Vector(Coordinate - Cam);//获取实际位置
                            //统计对齐次数
                            Counting++;
                            if (Counting > 20)
                            {
                                MainFormLogErr(string.Format("坐标({0},{1}),超出对齐次数！！！", Tem_Mark.X, Tem_Mark.Y));
                                break;//退出继续对齐
                            }
                        } while (!Differ_Deviation(Cam, Program.SystemContainer.SysPara.Pos_Tolerance));
                    }
                    else
                    {
                        //实际测量
                        if (!Program.SystemContainer.GTS_Fun.Gts_Point_Go(Tem_Mark, 1))
                        {
                            MessageBox.Show("平台定位异常，加工终止！！！");
                            return;
                        }
                        //调用相机，获取对比的坐标信息
                        Thread.Sleep(500);
                        //相机反馈的当前坐标
                        Cam = new Vector(Program.SystemContainer.T_Client.Get_Cam_Deviation_Coordinate_Correct(Program.SystemContainer.SysPara.Camera_Intrigue_Sequence));//触发拍照 
                        if (Cam.Length == 0)
                        {
                            MessageBox.Show("相机坐标提取失败，请检查！！！");
                            CSV_RW.SaveCSV(Temp_Acquisition, "Rtc_Affinity_Acquisition/Rtc_Affinity_Data_Aquisition_Temp_Cam_Fail");//原始数据保存
                            CSV_RW.SaveCSV(Calibration_Data_Acquisition, "Rtc_Affinity_Acquisition/Rtc_Affinity_Data_Aquisition_Cam_Fail");//原始数据保存
                            return;
                        }
                        Coordinate = Program.SystemContainer.GTS_Fun.Get_Coordinate(1);
                    }
                    //添加数据
                    Temp_Acquisition.Rows.Add(new object[] { Aquisition_Point[i].X, Aquisition_Point[i].Y, Tem_Mark.Y, Tem_Mark.X });
                }
                /**********数据处理部分************/
                //数据处理部分
                //Tem_Datum = new Vector(Convert.ToDecimal(Temp_Acquisition.Rows[((NoX + 1) * (NoY + 1) - 1) / 2][2].ToString()), Convert.ToDecimal(Temp_Acquisition.Rows[((NoX + 1) * (NoY + 1) - 1) / 2][3].ToString()));
                Tem_Datum = new Vector(GtsBasic);//中心点坐标
                //数据处理
                for (int i = 0; i < Temp_Acquisition.Rows.Count; i++)
                {
                    decimal t1, t2, t3, t4;
                    t1 = Convert.ToDecimal(Temp_Acquisition.Rows[i][0].ToString());
                    t2 = Convert.ToDecimal(Temp_Acquisition.Rows[i][1].ToString());
                    t3 = Convert.ToDecimal(Temp_Acquisition.Rows[i][2].ToString());
                    t4 = Convert.ToDecimal(Temp_Acquisition.Rows[i][3].ToString());
                    Calibration_Data_Acquisition.Rows.Add(new object[] { t1, t2, (t3 - Tem_Datum.X), (t4 - Tem_Datum.Y) });
                }
                CSV_RW.SaveCSV(Temp_Acquisition, "Rtc_Affinity_Acquisition/Rtc_Affinity_Data_Aquisition_Temp_OK");//原始数据保存
                CSV_RW.SaveCSV(Calibration_Data_Acquisition, "Rtc_Affinity_Acquisition/Rtc_Affinity_Data_Aquisition_OK");//原始数据保存
            }
            else
            {
                appendInfo("只支持整圆图形采集！！！！");
            }
        }

        /// <summary>
        /// Gts: 0 - 不矫正，1 - 矫正；Rtc: 0 - 仿射矫正，1 - 桶形畸变，2 - 无仿射矫正
        /// </summary>
        /// <param name="Gts"></param>
        /// <param name="Rtc"></param>
        private void Work_Running(int Gts,int Rtc)
        {
            //解析DXF文件
            ResolveData();
            //判断是否存在加工轨迹偏移轨迹
            if (File_Entity_Datas.LayerSectionDatas.Count <= 0)
            {
                StopEvent?.Invoke();
                return;
            }
            //Mark定位 矫正偏转
            if (!CalibrateFileData(File_Entity_Datas, MainLaserProject.FileList[0].PlatFormPos))
            {
                StopEvent?.Invoke();
                return;
            }
            //加工指定文件
            PushDataToController(File_Entity_Datas, Gts, Rtc); //从这里指定加判断
        }

        /// <summary>
        /// Mark坐标定位 验证
        /// </summary>
        private void Mark_Certify(Vector PlatformPos)
        {
            //解析DXF文件
            ResolveData();
            //判断是否存在加工轨迹偏移轨迹
            if (File_Entity_Datas.LayerSectionDatas.Count <= 0)
            {
                StopEvent?.Invoke();
                return;
            }
            //Mark定位 检测是否Mark是否在相机视野
            //重新梳理定位Mark信息            
            if (Program.SystemContainer.SysPara.Calibration_Type == 1)// 1 - 整块板Mark定位
            {
                Vector Cam = new Vector();
                File_Entity_Datas.PlatformMarkInfo.Clear();//清空平台Mark坐标
                foreach (var o in File_Entity_Datas.DxfMarkInfo)
                {
                    File_Entity_Datas.PlatformMarkInfo.Add(new Vector(o.X + PlatformPos.X, o.Y + PlatformPos.Y));
                }
                //Mark点位数量异常
                if ((File_Entity_Datas.PlatformMarkInfo.Count < 3) || (File_Entity_Datas.DxfMarkInfo.Count < 3))
                {
                    MessageBox.Show("Mark定位点位数据异常！！！");
                    return;
                }
                //验证
                for (int i = 0; i < File_Entity_Datas.PlatformMarkInfo.Count; i++)
                {

                    //定位到Mark点
                    if(!Program.SystemContainer.GTS_Fun.Gts_Point_Go(File_Entity_Datas.PlatformMarkInfo[i],1))
                    {
                        MessageBox.Show("平台定位异常，加工终止！！！");
                        return;
                    }
                    //调用相机，获取对比的坐标信息
                    Thread.Sleep(50);//延时50ms
                    Cam = new Vector(Program.SystemContainer.T_Client.Get_Cam_Deviation_Coordinate_Correct(Program.SystemContainer.SysPara.Camera_Intrigue_Sequence));//触发拍照 
                    if (Cam.Length == 0)
                    {
                        MessageBox.Show("Mark拾取失败，请检查！！！");
                        appendInfo("Mark点验证失败！！！");
                        return;
                    }
                    //运行和暂停切换
                    if (on_off)
                    {
                        ma = new ManualResetEvent(false);
                        ma.WaitOne();
                    }
                    //退出循环
                    if (stop)
                    {
                        return;
                    }
                }
                appendInfo("Mark点验证完成！！！");
            }
            else
            {
                appendInfo("非Mark矫正模式！！！");
            }
        }

        /// <summary>
        /// 相机坐标系标定(打标)
        /// </summary>
        private void Calibration_Camera_Axes_Mark()
        {
            int ScissorIndex = 0;
            Tech_Parameter ScissorPara = new Tech_Parameter();//刀具参数
            //启用刀具参数
            ScissorIndex = Program.SystemContainer.ScissorList.FindIndex(t => t.Scissors_Name == Program.SystemContainer.SysPara.Calibrate_Mark_Scissor);//获取刀具索引
            if (ScissorIndex == -1)//不含此刀具
            {
                MessageBox.Show(string.Format("刀具:{0}，不存在加工终止！！", Program.SystemContainer.SysPara.Calibrate_Mark_Scissor));
                return;//未指定刀具
            }
            ScissorPara = new Tech_Parameter(Program.SystemContainer.ScissorList[ScissorIndex]);//提取刀具参数
            Program.SystemContainer.RTC_Fun.Scissors_Para_Exe(ScissorPara, Program.SystemContainer.SysPara.MarkJump);//启用刀具参数
            /***************加工Mark圆****************/
            //生成RTC扫圆轨迹
            Section_Entity_Data Calibrate_Data = Calibration.CreateMarkData(0.4m, 2.0m, 1);
            //关闭激光
            Program.SystemContainer.RTC_Fun.Close_Laser();
            //平台定位
            if(!Program.SystemContainer.GTS_Fun.Gts_Point_Go(Calibrate_Data.Centre,0))
            {
                MessageBox.Show("平台定位异常，加工终止！！！");
                return;
            }
            //加工图形
            for (int i = 1; i < ScissorPara.RepeatTime + 1; i++)//加工次数
            {
                //急停按钮按下终止运行
                if (Program.SystemContainer.IO.GlobalEMG)
                {
                    return;
                }
                //运行和暂停切换
                if (on_off)
                {
                    ma = new ManualResetEvent(false);
                    ma.WaitOne();
                }
                //退出循环
                if (stop)
                {
                    return;
                }
                //振镜加工轨迹推入
                Program.SystemContainer.RTC_Fun.Draw_Mark(Calibrate_Data, 1, 2);
                //关闭激光
                Program.SystemContainer.RTC_Fun.Close_Laser();
            }            
            //识别并矫正
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
            int ScissorIndex = 0;
            Tech_Parameter ScissorPara = new Tech_Parameter();//刀具参数
            //启用刀具参数
            ScissorIndex = Program.SystemContainer.ScissorList.FindIndex(t => t.Scissors_Name == Program.SystemContainer.SysPara.Calibrate_Mark_Scissor);//获取刀具索引
            if (ScissorIndex == -1)//不含此刀具
            {
                MessageBox.Show(string.Format("刀具:{0}，不存在加工终止！！", Program.SystemContainer.SysPara.Calibrate_Mark_Scissor));
                return;//未指定刀具
            }
            ScissorPara = new Tech_Parameter(Program.SystemContainer.ScissorList[ScissorIndex]);//提取刀具参数
            Program.SystemContainer.RTC_Fun.Scissors_Para_Exe(ScissorPara, Program.SystemContainer.SysPara.MarkJump);//启用刀具参数
            /***************加工Mark圆****************/
            //生成RTC扫圆轨迹
            Section_Entity_Data Calibrate_Data = Calibration.CreateMarkData(0.4m, 25, 5);//5个圆，间距25
            //关闭激光
            Program.SystemContainer.RTC_Fun.Close_Laser();
            //平台定位
            if(!Program.SystemContainer.GTS_Fun.Gts_Point_Go(Calibrate_Data.Centre,1))
            {
                MessageBox.Show("平台定位异常，加工终止！！！");
                return;
            }
            //加工图形
            for (int i = 1; i < ScissorPara.RepeatTime + 1; i++)//加工次数
            { 
                //急停按钮按下终止运行
                if (Program.SystemContainer.IO.GlobalEMG)
                {
                    return;
                }
                //运行和暂停切换
                if (on_off)
                {
                    ma = new ManualResetEvent(false);
                    ma.WaitOne();
                }
                //退出循环
                if (stop)
                {
                    return;
                }
                //振镜加工轨迹推入
                Program.SystemContainer.RTC_Fun.Draw_Mark(Calibrate_Data, 1, 2);
                //关闭激光
                Program.SystemContainer.RTC_Fun.Close_Laser();
            }
            /***************识别矫正****************/
            if (Calibration.Get_Rtc_Coordinate_Affinity(0.4m,25))
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
            int ScissorIndex = 0;
            Tech_Parameter ScissorPara = new Tech_Parameter();//刀具参数
            //启用刀具参数
            ScissorIndex = Program.SystemContainer.ScissorList.FindIndex(t => t.Scissors_Name == Program.SystemContainer.SysPara.Calibrate_Mark_Scissor);//获取刀具索引
            if (ScissorIndex == -1)//不含此刀具
            {
                MessageBox.Show(string.Format("刀具:{0}，不存在加工终止！！", Program.SystemContainer.SysPara.Calibrate_Mark_Scissor));
                return;//未指定刀具
            }
            ScissorPara = new Tech_Parameter(Program.SystemContainer.ScissorList[ScissorIndex]);//提取刀具参数
#if !DEBUG
            Program.SystemContainer.RTC_Fun.Scissors_Para_Exe(ScissorPara, Program.SystemContainer.SysPara.MarkJump);//启用刀具参数            
#endif
            /***************加工Mark圆****************/
            //生成RTC扫圆轨迹
            Section_Entity_Data Calibrate_Data = Calibration.CreateMarkData(0.4m, 2.0m, 1);
            //关闭激光
            Program.SystemContainer.RTC_Fun.Close_Laser();
            //平台定位
            if(!Program.SystemContainer.GTS_Fun.Gts_Point_Go(Calibrate_Data.Centre,1))
            {
                MessageBox.Show("平台定位异常，加工终止！！！");
                return;
            }
            //加工图形
            for (int i = 1; i < ScissorPara.RepeatTime + 1; i++)//加工次数
            {
                //急停按钮按下终止运行
                if (Program.SystemContainer.IO.GlobalEMG)
                {
                    return;
                }
                //运行和暂停切换
                if (on_off)
                {
                    ma = new ManualResetEvent(false);
                    ma.WaitOne();
                }
                //退出循环
                if (stop)
                {
                    return;
                }
                //振镜加工轨迹推入
                Program.SystemContainer.RTC_Fun.Draw_Mark(Calibrate_Data, 1, 2);
                //关闭激光
                Program.SystemContainer.RTC_Fun.Close_Laser();
            }
            /************矫正距离***************/
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
        /// 平台校准数据采集  中心对齐
        /// </summary>
        private void Calibration_Original_Data_Collect()
        {
            appendInfo("标定板中心对齐校准数据采集启动！！！");            
            //计算数据
            List<Correct_Data> Result = new List<Correct_Data>();//校准数据初始化
            Correct_Data Temp_Correct_Data = new Correct_Data();//添加数据初始化
            //标定板数据采集
            DataTable Calibration_Data_Acquisition = new DataTable();
            Calibration_Data_Acquisition.Columns.Add("理论X坐标", typeof(decimal));
            Calibration_Data_Acquisition.Columns.Add("理论Y坐标", typeof(decimal));
            Calibration_Data_Acquisition.Columns.Add("平台X坐标", typeof(decimal));
            Calibration_Data_Acquisition.Columns.Add("平台Y坐标", typeof(decimal));
            Calibration_Data_Acquisition.Columns.Add("相机X坐标", typeof(decimal));
            Calibration_Data_Acquisition.Columns.Add("相机Y坐标", typeof(decimal));
            //建立变量
            Vector Cam = new Vector();//相机反馈的当前坐标
            Vector Tem_Mark = new Vector();//
            Vector Coodinate_Point = new Vector();// 
            int i = 0, j = 0, Counting = 0;
            //2.5mm步距进行数据提取和整合，使用INC指令
            for (i = 0; i < Program.SystemContainer.SysPara.Gts_Calibration_Row_Y; i++)
            {
                //1轴-x轴，2轴-y轴，X轴归零，y轴归 步距*i
                for (j = 0; j < Program.SystemContainer.SysPara.Gts_Calibration_Col_X; j++)
                {
                    Temp_Correct_Data.Empty();//清空数据
                    Tem_Mark = new Vector(j * Program.SystemContainer.SysPara.Gts_Calibration_X_Cell, i * Program.SystemContainer.SysPara.Gts_Calibration_Y_Cell);
                    //矫正Mark           
                    Counting = 0;
                    do
                    {
                        /**********************线程控制部分******************************/
                        //运行和暂停切换
                        if (on_off)
                        {
                            ma = new ManualResetEvent(false);
                            ma.WaitOne();
                        }
                        //退出循环
                        if (stop)
                        {
                            CSV_RW.SaveCSV(Calibration_Data_Acquisition, "Calibration_Board_Align/Calibration_Board_Align_Exit");//标定板原始数据保存
                            return;
                        }
                        /**********************数据采集部分******************************/
                        //定位到Mark点
                        if (!Program.SystemContainer.GTS_Fun.Gts_Point_Go(Tem_Mark, 0))
                        {
                            MessageBox.Show("平台定位异常，加工终止！！！");
                            CSV_RW.SaveCSV(Calibration_Data_Acquisition, "Calibration_Board_Align/Calibration_Board_Align_Gts_Fail");//定位失败数据保存
                            return;
                        }
                        Cam = new Vector(Program.SystemContainer.T_Client.Get_Cam_Deviation_Coordinate_Correct(Program.SystemContainer.SysPara.Camera_Intrigue_Sequence));//触发拍照 
                        if (Cam.Length == 0)
                        {
                            MessageBox.Show("相机坐标提取失败，请检查！！！");
                            CSV_RW.SaveCSV(Calibration_Data_Acquisition, "Calibration_Board_Align/Calibration_Board_Align_Cam_Fail");//相机识别失败数据保存
                            return;
                        }
                        //获取平台坐标系坐标
                        Coodinate_Point = new Vector(Program.SystemContainer.GTS_Fun.Get_Coordinate(0));
                        //计算偏移
                        Tem_Mark = new Vector(Coodinate_Point - Cam);
                        //反馈回Mark点
                        Tem_Mark = new Vector(Tem_Mark);
                        //自增
                        Counting++;
                        //跳出
                        if (Counting > 20)
                        {
                            MainFormLogErr(String.Format("标定板坐标({0},{1})相机对准失败！！！", j * Program.SystemContainer.SysPara.Gts_Calibration_X_Cell, i * Program.SystemContainer.SysPara.Gts_Calibration_Y_Cell));
                            break;
                        }
                    } while (!Differ_Deviation(Cam, Program.SystemContainer.SysPara.Pos_Tolerance));
                    //获取平台坐标系坐标
                    Coodinate_Point = new Vector(Program.SystemContainer.GTS_Fun.Get_Coordinate(0));
                    /**********************数据保存部分******************************/
                    Calibration_Data_Acquisition.Rows.Add(new object[] { j * Program.SystemContainer.SysPara.Gts_Calibration_X_Cell, i * Program.SystemContainer.SysPara.Gts_Calibration_Y_Cell, Coodinate_Point.X, Coodinate_Point.Y, Cam.X, Cam.Y });
                    //计算矫正数据保存
                    Temp_Correct_Data.Xo = j * Program.SystemContainer.SysPara.Gts_Calibration_X_Cell;//理论实际X坐标
                    Temp_Correct_Data.Yo = i * Program.SystemContainer.SysPara.Gts_Calibration_Y_Cell;//理论实际Y坐标
                    Temp_Correct_Data.Xm = Coodinate_Point.X;//平台电机当前X坐标
                    Temp_Correct_Data.Ym = Coodinate_Point.Y;//平台电机当前Y坐标
                    Result.Add(Temp_Correct_Data);
                    /**********************线程控制部分******************************/
                    //运行和暂停切换
                    if (on_off)
                    {
                        ma = new ManualResetEvent(false);
                        ma.WaitOne();
                    }
                    //退出循环
                    if (stop)
                    {
                        CSV_RW.SaveCSV(Calibration_Data_Acquisition, "Calibration_Board_Align/Calibration_Board_Align_Exit");//标定板原始数据保存
                        return;
                    }
                }                
            }
            //保存文件
            CSV_RW.SaveCSV(Calibration_Data_Acquisition, "Calibration_Board_Align/Calibration_Board_Align");//标定板原始数据保存
            Serialize_Data.Serialize_Correct_Data(Result, string.Format("Calibration_Board_Align/Calibration_Board_Align_Original.xml"));//保存校准源数据
            Gts_Cal_Data_Resolve.Resolve(Result, string.Format("Calibration_Board_Align/Calibration_Board_Align_Affinity.xml"));//生成校准文件
            appendInfo("标定板中心对齐校准数据采集成功！！！");
        }

        /// <summary>
        /// 平台校准数据采集  多次校准
        /// </summary>
        private void Calibration_Multiple_Data_Collect()
        {
            appendInfo("标定板多次校准启动！！！");
            //变量
            DataTable Calibration_Data_Acquisition;
            List<Correct_Data> Result;
            Correct_Data Temp_Correct_Data;
            Vector Cam;//相机坐标
            Vector Coodinate_Point;//平台坐标
            Vector Tem_Mark = new Vector();//临时坐标
            int i, j;
            //定义校准次数
            for (int m = 0; m < Program.SystemContainer.SysPara.CalTimes; m++)
            {
                //标定板数据采集初始化
                Calibration_Data_Acquisition = new DataTable();
                Calibration_Data_Acquisition.Columns.Add("理论X坐标", typeof(decimal));
                Calibration_Data_Acquisition.Columns.Add("理论Y坐标", typeof(decimal));
                Calibration_Data_Acquisition.Columns.Add("平台X坐标", typeof(decimal));
                Calibration_Data_Acquisition.Columns.Add("平台Y坐标", typeof(decimal));
                Calibration_Data_Acquisition.Columns.Add("相机X坐标", typeof(decimal));
                Calibration_Data_Acquisition.Columns.Add("相机Y坐标", typeof(decimal));
                //变量初始化
                Cam = new Vector();//相机反馈的当前坐标
                Coodinate_Point = new Vector();//平台坐标初始化
                Tem_Mark = new Vector();//临时坐标初始化
                i = 0; j = 0;//循环变量初始化
                Result = new List<Correct_Data>();//校准数据初始化
                Temp_Correct_Data = new Correct_Data();//添加数据初始化
                appendInfo(String.Format("标定板第{0}校准启动！！！", m));
                //加载校准文件
                if (m > 0)
                {
                    //加载平台校准文件
                    if (!Program.SystemContainer.GTS_Fun.Load_Affinity_Matrix(string.Format("Multiple_Calibration_Board/Gts_Affinity_Matrix_{0}.xml", m - 1)))
                    {
                        MessageBox.Show("平台校准文件加载失败！！！");
                        return;
                    }
                }
                //校准步距进行数据提取和整合，使用INC指令
                for (i = 0; i < Program.SystemContainer.SysPara.Gts_Calibration_Row_Y; i++)//Y
                {
                    //1轴-x轴，2轴-y轴，X轴归零，y轴归 步距*i
                    for (j = 0; j < Program.SystemContainer.SysPara.Gts_Calibration_Col_X; j++)//X
                    {
                        Temp_Correct_Data.Empty();
                        Tem_Mark = new Vector(j * Program.SystemContainer.SysPara.Gts_Calibration_X_Cell, i * Program.SystemContainer.SysPara.Gts_Calibration_Y_Cell);
                        //定位到Mark点
                        if (m == 0)
                        {
                            if (!Program.SystemContainer.GTS_Fun.Gts_Point_Go(Tem_Mark, 0))
                            {
                                MessageBox.Show("平台定位异常，加工终止！！！");
                                CSV_RW.SaveCSV_NoDate(Calibration_Data_Acquisition, string.Format("Multiple_Calibration_Board/Calibration_Multiple_Gts_Fail_{0}.csv", m));//定位失败数据保存
                                return;
                            }
                        }
                        else
                        {
                            if (!Program.SystemContainer.GTS_Fun.Gts_Point_Go(Tem_Mark, 1))
                            {
                                MessageBox.Show("平台定位异常，加工终止！！！");
                                CSV_RW.SaveCSV_NoDate(Calibration_Data_Acquisition, string.Format("Multiple_Calibration_Board/Calibration_Multiple_Gts_Fail_{0}.csv", m));//定位失败数据保存
                                return;
                            }
                        }
                        Thread.Sleep(50);
                        Cam = new Vector(Program.SystemContainer.T_Client.Get_Cam_Deviation_Coordinate_Correct(Program.SystemContainer.SysPara.Camera_Intrigue_Sequence));//触发拍照 
                        if (Cam.Length == 0)
                        {
                            MessageBox.Show("相机坐标提取失败，请检查！！！");
                            CSV_RW.SaveCSV_NoDate(Calibration_Data_Acquisition, string.Format("Multiple_Calibration_Board/Calibration_Multiple_Cam_Fail_{0}.csv", m));//相机踩点失败数据保存
                            return;
                        }
                        //获取平台坐标系坐标
                        Coodinate_Point = new Vector(Program.SystemContainer.GTS_Fun.Get_Coordinate(0));//平台实际坐标
                        //数据保存
                        Temp_Correct_Data.Xo = Tem_Mark.X - Cam.X;//理论实际X坐标
                        Temp_Correct_Data.Yo = Tem_Mark.Y - Cam.Y;//理论实际Y坐标
                        Temp_Correct_Data.Xm = Coodinate_Point.X;//平台电机当前X坐标
                        Temp_Correct_Data.Ym = Coodinate_Point.Y;//平台电机当前Y坐标
                        /**********************数据追加******************************/
                        Result.Add(Temp_Correct_Data);
                        Calibration_Data_Acquisition.Rows.Add(new object[] { Tem_Mark.X, Tem_Mark.Y, Coodinate_Point.X, Coodinate_Point.Y, Cam.X, Cam.Y });
                        /**********************线程控制部分******************************/
                        //运行和暂停切换
                        if (on_off)
                        {
                            ma = new ManualResetEvent(false);
                            ma.WaitOne();
                        }
                        //退出循环
                        if (stop)
                        {
                            CSV_RW.SaveCSV_NoDate(Calibration_Data_Acquisition, string.Format("Multiple_Calibration_Board/Calibration_Multiple_Exit_{0}.csv", m));//标定板原始数据保存
                            return;
                        }
                    }
                }
                //保存文件
                CSV_RW.SaveCSV_NoDate(Calibration_Data_Acquisition, string.Format("Multiple_Calibration_Board/Calibration_Multiple_OK_{0}.csv", m));//标定板原始数据保存                                                                                                                    
                Serialize_Data.Serialize_Correct_Data(Result, string.Format("Multiple_Calibration_Board/Gts_Correct_Data_OK_{0}.xml", m));//保存校准源数据
                Gts_Cal_Data_Resolve.Resolve(Result, string.Format("Multiple_Calibration_Board/Gts_Affinity_Matrix_{0}.xml", m));//生成校准文件
                appendInfo(String.Format("标定板第{0}校准结束！！！", m));
            }
            appendInfo("标定板多次校准完成！！！");
        }

        /// <summary>
        /// 平台校准验证
        /// </summary>
        public void Get_Borad_Certify_Datas()
        {
            //变量
            DataTable Calibration_Data_Acquisition;
            Vector Cam;//相机坐标
            Vector Coodinate_Point;//平台坐标
            Vector Tem_Mark = new Vector();//临时坐标
            int i, j;
            //标定板数据采集初始化
            Calibration_Data_Acquisition = new DataTable();
            Calibration_Data_Acquisition.Columns.Add("理论X坐标", typeof(decimal));
            Calibration_Data_Acquisition.Columns.Add("理论Y坐标", typeof(decimal));
            Calibration_Data_Acquisition.Columns.Add("平台X坐标", typeof(decimal));
            Calibration_Data_Acquisition.Columns.Add("平台Y坐标", typeof(decimal));
            Calibration_Data_Acquisition.Columns.Add("相机X坐标", typeof(decimal));
            Calibration_Data_Acquisition.Columns.Add("相机Y坐标", typeof(decimal));
            //变量初始化
            Cam = new Vector();//相机反馈的当前坐标
            Coodinate_Point = new Vector();//平台坐标初始化
            Tem_Mark = new Vector();//临时坐标初始化
            i = 0; j = 0;//循环变量初始化
            appendInfo(String.Format("标定板验证数据启动！！！"));
            //校准步距进行数据提取和整合，使用INC指令
            for (i = 0; i < Program.SystemContainer.SysPara.Gts_Calibration_Row_Y; i++)
            {
                //1轴-x轴，2轴-y轴，X轴归零，y轴归 步距*i
                for (j = 0; j < Program.SystemContainer.SysPara.Gts_Calibration_Col_X; j++)
                {
                    Tem_Mark = new Vector(j * Program.SystemContainer.SysPara.Gts_Calibration_X_Cell, i * Program.SystemContainer.SysPara.Gts_Calibration_Y_Cell);
                    //定位到Mark点
                    if (!Program.SystemContainer.GTS_Fun.Gts_Point_Go(Tem_Mark, 1))
                    {
                        MessageBox.Show("平台定位异常，加工终止！！！");
                        CSV_RW.SaveCSV(Calibration_Data_Acquisition, string.Format("Certify_Calibration_Board/Board_Certify_Gts_Fail"));//平台定位失败数据保存
                        return;
                    }
                    Thread.Sleep(50);
                    Cam = new Vector(Program.SystemContainer.T_Client.Get_Cam_Deviation_Coordinate_Correct(Program.SystemContainer.SysPara.Camera_Intrigue_Sequence));//触发拍照 
                    if (Cam.Length == 0)
                    {
                        MessageBox.Show("相机坐标提取失败，请检查！！！");
                        CSV_RW.SaveCSV(Calibration_Data_Acquisition, string.Format("Certify_Calibration_Board/Board_Certify_Cam_Fail"));//相机踩点失败数据保存
                        return;
                    }
                    //获取平台坐标系坐标
                    Coodinate_Point = new Vector(Program.SystemContainer.GTS_Fun.Get_Coordinate(0));
                    /**********************数据追加******************************/
                    Calibration_Data_Acquisition.Rows.Add(new object[] { Tem_Mark.X, Tem_Mark.Y, Coodinate_Point.X, Coodinate_Point.Y, Cam.X, Cam.Y });
                    /**********************线程退出部分******************************/
                    //运行和暂停切换
                    if (on_off)
                    {
                        ma = new ManualResetEvent(false);
                        ma.WaitOne();
                    }
                    //退出循环
                    if (stop)
                    {
                        CSV_RW.SaveCSV(Calibration_Data_Acquisition, string.Format("Certify_Calibration_Board/Board_Certify_Exit"));//标定板原始数据保存
                        return;
                    }
                }
            }
            //保存文件
            CSV_RW.SaveCSV(Calibration_Data_Acquisition, string.Format("Certify_Calibration_Board/Board_Certify_OK"));//标定板采集数据保存 
            appendInfo(String.Format("标定板验证数据提取结束！！！"));
        }

        /// <summary>
        /// 校验指定坐标的数据
        /// </summary>
        /// <returns></returns>
        public void Specific_List_Certify()
        {
           
            //建立变量  
            DataTable Calibration_Data_Acquisition = new DataTable();
            Calibration_Data_Acquisition.Columns.Add("理论X坐标", typeof(decimal));
            Calibration_Data_Acquisition.Columns.Add("理论Y坐标", typeof(decimal));
            Calibration_Data_Acquisition.Columns.Add("平台X坐标", typeof(decimal));
            Calibration_Data_Acquisition.Columns.Add("平台Y坐标", typeof(decimal));
            Calibration_Data_Acquisition.Columns.Add("相机X坐标", typeof(decimal));
            Calibration_Data_Acquisition.Columns.Add("相机Y坐标", typeof(decimal));
            //标定板数据采集
            DataTable PointListTable = CSV_RW.OpenCSV(@"./\Config/Calibration_PointList/PointList.csv");
            appendInfo(String.Format("{0}列表数据校准启动！！！","PointList.csv"));
            decimal X = 0, Y = 0;
            Vector Tem_Mark = new Vector();
            Vector Cam = new Vector();
            Vector Coodinate_Point = new Vector();
            //获取PointList
            List<Vector> PointList = new List<Vector>();
            for (int i = 0; i < PointListTable.Rows.Count; i++)
            {
                if ((decimal.TryParse(PointListTable.Rows[i][0].ToString(), out X)) && (decimal.TryParse(PointListTable.Rows[i][1].ToString(), out Y)))
                    PointList.Add(new Vector(X, Y));
            }
            //重复次数
            for (int Repeat = 0;Repeat<Program.SystemContainer.SysPara.PointListRepeatTimes;Repeat++)
            {
                /**********************线程控制部分******************************/
                //运行和暂停切换
                if (on_off)
                {
                    ma = new ManualResetEvent(false);
                    ma.WaitOne();
                }
                //退出循环
                if (stop)
                {
                    CSV_RW.SaveCSV(Calibration_Data_Acquisition, string.Format("Calibration_PointList/PointList_Certify_Exit"));//指定点列表数据采集退出
                    return;
                }
                /**********************数据采集部分******************************/
                for (int i = 0; i < PointList.Count; i++)
                {
                    Tem_Mark = new Vector(PointList[i]);
                    //定位到矫正点
                    //定位到Mark点
                    if (!Program.SystemContainer.GTS_Fun.Gts_Point_Go(Tem_Mark, 1))
                    {
                        MessageBox.Show("平台定位异常，加工终止！！！");
                        CSV_RW.SaveCSV(Calibration_Data_Acquisition, string.Format("Calibration_PointList/PointList_Certify_Gts_Fail"));//平台定位踩点失败数据保存
                        return;
                    }
                    Thread.Sleep(50);
                    Cam = new Vector(Program.SystemContainer.T_Client.Get_Cam_Deviation_Coordinate_Correct(Program.SystemContainer.SysPara.Camera_Intrigue_Sequence));//触发拍照 
                    if (Cam.Length == 0)
                    {
                        MessageBox.Show("相机坐标提取失败，请检查！！！");
                        CSV_RW.SaveCSV(Calibration_Data_Acquisition, string.Format("Calibration_PointList/PointList_Certify_Cam_Fail"));//相机踩点失败数据保存
                        return;
                    }
                    //获取平台坐标系坐标
                    Coodinate_Point = new Vector(Program.SystemContainer.GTS_Fun.Get_Coordinate(0));//平台实际坐标
                                                                                                    /**********************数据追加******************************/
                    Calibration_Data_Acquisition.Rows.Add(new object[] { Tem_Mark.X, Tem_Mark.Y, Coodinate_Point.X, Coodinate_Point.Y, Cam.X, Cam.Y });
                    /**********************线程控制部分******************************/
                    //运行和暂停切换
                    if (on_off)
                    {
                        ma = new ManualResetEvent(false);
                        ma.WaitOne();
                    }
                    //退出循环
                    if (stop)
                    {
                        CSV_RW.SaveCSV(Calibration_Data_Acquisition, string.Format("Calibration_PointList/PointList_Certify_Exit"));//指定点列表数据采集退出
                        return;
                    }
                }
            }
            //保存文件
            CSV_RW.SaveCSV(Calibration_Data_Acquisition, string.Format("Calibration_PointList/PointList_Certify_OK"));//指定点列表数据采集完成
            appendInfo(String.Format("{0}列表数据校准完成！！！", "PointList.csv"));
        }

        /// <summary>
        /// 判别误差范围之内
        /// </summary>
        /// <param name="Indata"></param>
        /// <param name="reference"></param>
        /// <returns></returns>
        public bool Differ_Deviation(Vector Indata, decimal reference)
        {
            if ((Math.Abs(Indata.X) <= reference) && (Math.Abs(Indata.Y) <= reference))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

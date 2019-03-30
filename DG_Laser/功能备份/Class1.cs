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
        Thread thread;//线程
        ManualResetEvent ma;//手动置位
        public bool running = false;//运行中 
        public bool on_off = false;//运行、暂停切换
        public bool stop = false;//停止
        //事件定义区
        public event Work StartEvent;
        public event Work PauseEvent;
        public event Work ResumeEvent;
        public event Work StopEvent;
        int MarkType = 0;//0 - 不需要Mark定位；1 - Mark定位

        /// <summary>
        /// 文件加工启动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileMarkRun_Click(object sender, EventArgs e)
        {
            if (!running)//非运行状态
            {
                running = !running;//切换运行状态
                //启动线程
                ThreadStart();
                //切换按钮状态
                FileMarkRun.Text = "加工暂停";
                //注册停止事件
                StopEvent = new Work(EndMotion);
            }
            else
            {
                if(FileMarkRun.Text == "加工暂停")
                {
                    FileMarkRun.Text = "加工继续";
                    ThreadPause();//启动线程暂停
                }
                else if (FileMarkRun.Text == "加工继续")
                {
                    FileMarkRun.Text = "加工暂停";
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
            if (this.IsHandleCreated) this.Invoke((EventHandler)delegate
            {
                //回退位置
                End_Pos_Go();
                //状态切换
                if (running) running = !running;//切换运行状态
                FileMarkRun.Text = "加工启动";
            });
            
        }
        
        /// <summary>
        /// 启动运行
        /// </summary>
        public void ThreadStart()
        {
            thread = new Thread(Runtime);
            thread.Start();
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
            while(thread.IsAlive);
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
            /****************启动前检测***************/
            //判断坐标系建立是否破坏
            if ((Program.SystemContainer.IO.Axis01_mode != 5) || (Program.SystemContainer.IO.Axis01_mode != 5))
            {
                Info("检测到平台坐标系未建立，请重新回零！！！");
                //非强制退出
                if (!stop)
                {
                    //加工结束 响应的动作
                    StopEvent?.Invoke();
                }
                return;
            }
            /****************加工方式选择***************/
            //选择加工方式
            this.Invoke((EventHandler)delegate
            {
                Work_Type_No = Array.IndexOf(Methods_List, Work_Type_Select_List.SelectedItem.ToString());
            });
            switch (Work_Type_No)
            {
                case 0://振镜空白和平台未补偿
                    break;
                case 1://振镜仿射和平台未补偿
                    break;
                case 2://振镜仿射和平台已补偿
                    //解析DXF文件
                    ResolveData();
                    //判断是否存在加工轨迹偏移轨迹
                    if (File_Entity_Datas.LayerSectionDatas.Count <= 0)
                    {
                        StopEvent?.Invoke();
                        return;
                    }
                    //Mark定位 矫正偏转
                    if (!CalibrateFileData(File_Entity_Datas))
                    {
                        StopEvent?.Invoke();
                        return;
                    }
                    //加工指定文件
                    PushDataToController(File_Entity_Datas); //从这里指定加判断
                    break;
                case 3://振镜旋转和平台已补偿
                    break;
                case 4://振镜矩阵和平台已补偿
                    break;
                case 5://振镜桶形畸变图形加工
                    Rtc_Barrel_Distortion_Figure_Sculpture();
                    break;
                case 6://振镜桶形畸变数据采集
                    Rtc_Barrel_Distortion_Figure_Data_Acquisition();
                    break;
                case 7://振镜仿射矩阵图形加工
                    break;
                case 8://振镜仿射矩阵数据采集
                    break;
                case 9://Mark坐标定位矫正
                    Mark_AFF_Correction();
                    break;
                case 10://Mark坐标定位重矫正  移除，不再使用
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

                    break;
                case 20://标定板多次校准验证 

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
            if (MarkType == 1)// 1 - 整块板定位(取4角)
            {
                File_Entity_Datas.DxfMarkInfo = DataResolve.DistractMark(dxf, "Mark");//mark信息
            }
            //获取分区编号序列
            List<int> SectionList = new List<int>();
            foreach (var o in MainLaserProject.FileList[0].LaserLayer)
            {
                SectionList.AddRange(DataResolve.DistractSectionColor(dxf, o));//追加数据
            }
            SectionList = SectionList.Distinct().OrderBy(o => o).ToList();
            if (SectionList.Count <= 0) return;
            //按分区提取数据
            Integrate_Entity_Data TemData = new Integrate_Entity_Data();//图层数据
            Section_Entity_Data TemSectionData = new Section_Entity_Data();//分区数据
            foreach (var o in MainLaserProject.FileList[0].LaserLayer)
            {
                TemData.LayerName = o;
                foreach (var p in SectionList)
                {
                    TemSectionData.Color = p;
                    TemSectionData.ArcLine = DataResolve.DistractArcLine(dxf, p, o);//圆弧直线数据
                    TemSectionData.Circle = DataResolve.DistractCircle(dxf, p, o);//整圆数据
                    TemSectionData.LWPolyline = DataResolve.DistractLWPolyline(dxf, p, o);//多边形数据
                    if (MarkType == 2)//2 - 阵列文件定位(小分区取4角)
                    {
                        TemSectionData.DxfMarkInfo = DataResolve.DistractMark(dxf, p, "Mark");//mark信息
                    }
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
        public bool CalibrateFileData(File_Entity_Data File_Entity_Datas)
        {
            Affinity_Matrix Matrix = new Affinity_Matrix();
            //重新梳理Mark信息            
            if (MarkType == 1)// 1 - 整块板定位(取4角)
            {
                File_Entity_Datas.PlatformMarkInfo.Clear();//清空平台Mark坐标
                foreach (var o in File_Entity_Datas.DxfMarkInfo)
                {
                    File_Entity_Datas.PlatformMarkInfo.Add(new Vector(o.X + File_Entity_Datas.Mark.X, o.Y + File_Entity_Datas.Mark.Y));
                }
            }
            else if (MarkType == 2)// 2 - 阵列文件定位(小分区取4角)；
            {
                for (int i = 0; i < File_Entity_Datas.LayerSectionDatas.Count; i++)
                {
                    for (int j = 0; j < File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas.Count; j++)
                    {
                        File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas[j].PlatformMarkInfo.Clear();//清空平台Mark坐标
                        foreach (var o in File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas[j].DxfMarkInfo)
                        {
                            File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas[j].PlatformMarkInfo.Add(new Vector(o.X + File_Entity_Datas.Mark.X, o.Y + File_Entity_Datas.Mark.Y));
                        }
                    }
                }
            }
            //计算偏转参数
            if (MarkType == 1)// 1 - 整块板定位(取4角)
            {
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
                        File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas[j].ArcLine = DataResolve.CalDataByMatrix(File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas[j].ArcLine, Matrix, true);
                        File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas[j].Circle = DataResolve.CalDataByMatrix(File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas[j].Circle, Matrix, true);
                        File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas[j].LWPolyline = DataResolve.CalDataByMatrix(File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas[j].LWPolyline, Matrix, true);
                    }
                }
            }
            else if (MarkType == 2)// 2 - 每个小分区定位
            {
                //处理数据
                for (int i = 0; i < File_Entity_Datas.LayerSectionDatas.Count; i++)
                {
                    for (int j = 0; j < File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas.Count; j++)
                    {
                        //Mark点位数量异常
                        if ((File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas[j].PlatformMarkInfo.Count < 3) || (File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas[j].DxfMarkInfo.Count < 3))
                        {
                            MessageBox.Show("Mark定位点位数据异常！！！");
                            return false;
                        }
                        //获取小分区偏转参数
                        Matrix = Calibration.Calibrate_Mark(File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas[j].DxfMarkInfo, File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas[j].PlatformMarkInfo);
                        if (Matrix == null) return false;//Mark校准失败
                        //处理所有分区数据
                        File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas[j].ArcLine = DataResolve.CalDataByMatrix(File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas[j].ArcLine, Matrix, true);
                        File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas[j].Circle = DataResolve.CalDataByMatrix(File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas[j].Circle, Matrix, true);
                        File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas[j].LWPolyline = DataResolve.CalDataByMatrix(File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas[j].LWPolyline, Matrix, true);
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
                        File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas[j].ArcLine = DataResolve.CalDataByMatrix(File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas[j].ArcLine, Matrix, false);
                        File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas[j].Circle = DataResolve.CalDataByMatrix(File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas[j].Circle, Matrix, false);
                        File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas[j].LWPolyline = DataResolve.CalDataByMatrix(File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas[j].LWPolyline, Matrix, false);
                    }
                }
            }
            //分区数据计算
            File_Entity_Datas = DataResolve.SeperateFileData(File_Entity_Datas);
            //返回
            return true;
        }

        /// <summary>
        /// 推入数据进入控制器，并加工
        /// </summary>
        /// <param name="File_Entity_Datas"></param>
        /// <returns></returns>
        public void PushDataToController(File_Entity_Data File_Entity_Datas)
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
                    //按照刀具参数进行加工
                    for (int i = 1;i < ScissorPara.RepeatTime + 1;i++)//加工次数
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
                            Program.SystemContainer.GTS_Fun.Gts_Ready_Correct(p.Centre);

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
                            Program.SystemContainer.RTC_Fun.Draw_Mark(p, 1, 0);
                            //关闭激光
                            Program.SystemContainer.RTC_Fun.Close_Laser();
                        }
                        /*********************************************/
                        //加工结束
                        //延时操作
                        if ((ScissorPara.DelayCompensationTimes >0) && ((i % ScissorPara.DelayCompensationTimes) == 0))
                        {
                            Thread.Sleep(ScissorPara.DelayCompensation);//延时
                        }
                    }
                }
            }
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
            if (Program.SystemContainer.SysPara.Upload_Type_Select == 1)//坐标系原点
            {
                Program.SystemContainer.GTS_Fun.Gts_Ready_Correct(0, 0);
            }
            else if (Program.SystemContainer.SysPara.Upload_Type_Select == 2)//上下料位
            {
                Program.SystemContainer.GTS_Fun.Gts_Ready_Correct(Program.SystemContainer.SysPara.Upload_Point.X, Program.SystemContainer.SysPara.Upload_Point.Y);
            }
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
                int ScissorIndex = 0;
                Tech_Parameter ScissorPara = new Tech_Parameter();//刀具参数
                //待加工数据
                List<Section_Entity_Data> Mark_Datas = new List<Section_Entity_Data>(Calibration.Create_Rtc_Calibrate_Data(0, Program.SystemContainer.SysPara.Rtc_Distortion_Data_Radius, Program.SystemContainer.SysPara.Rtc_Distortion_Data_Interval, Program.SystemContainer.SysPara.Rtc_Distortion_Data_Limit));//十个一组
                //启用刀具参数
                ScissorIndex = Program.SystemContainer.ScissorList.FindIndex(t => t.Scissors_Name == Program.SystemContainer.SysPara.Calibrate_Mark_Scissor);//获取刀具索引
                if (ScissorIndex == -1)//不含此刀具
                {
                    MessageBox.Show(string.Format("刀具:{0}，不存在加工终止！！", Program.SystemContainer.SysPara.Calibrate_Mark_Scissor));
                    return;//未指定刀具
                }
                ScissorPara = new Tech_Parameter(Program.SystemContainer.ScissorList[ScissorIndex]);//提取刀具参数
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
                        Program.SystemContainer.GTS_Fun.Gts_Ready_Correct(p.Centre);

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
                decimal Gts_X = Program.SystemContainer.SysPara.Base_Gts.X, Gts_Y = Program.SystemContainer.SysPara.Base_Gts.Y;//X、Y坐标
                Vector Cam = new Vector();
                Vector Tem_Mark = new Vector();
                Vector Coordinate = new Vector();
                Vector Tem_Datum = new Vector();
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
                Int16 No = (Int16)(Program.SystemContainer.SysPara.Rtc_Distortion_Data_Limit / Program.SystemContainer.SysPara.Rtc_Distortion_Data_Interval);
                ///Rtc要求数据 顺序：左上角-->右上角 Y坐标不变，依次变更X坐标
                ///Gts匹配 顺序：右上角-->右下角 X坐标不变，依次变更Y坐标 （Rts坐标轴交换，同时Rtc的X轴方向取反）
                for (int i = No / 2; i >= -No / 2; i--)
                {
                    for (int j = No / 2; j >= -No / 2; j--)
                    {
                        Aquisition_Point.Add(new Vector(Gts_X + i * Program.SystemContainer.SysPara.Rtc_Distortion_Data_Interval, Gts_Y + j * Program.SystemContainer.SysPara.Rtc_Distortion_Data_Interval));
                    }
                }
                //振镜打标数据
                for (int i = -No / 2; i <= No / 2; i++)//Y坐标
                {
                    for (int j = -No / 2; j <= No / 2; j++)//X坐标
                    {
                        Rtc_Point.Add(new Vector(j * Program.SystemContainer.SysPara.Rtc_Distortion_Data_Interval, -i * Program.SystemContainer.SysPara.Rtc_Distortion_Data_Interval));
                    }
                }
                //进行数据采集
                if (Rtc_Point.Count == Aquisition_Point.Count)
                {
                    for (int i = 0; i < Aquisition_Point.Count; i++)
                    {
                        /*********************获取矫正数据**********************/
                        Tem_Mark = new Vector(Aquisition_Point[i].X + Program.SystemContainer.SysPara.Rtc_Org.X, Aquisition_Point[i].Y + Program.SystemContainer.SysPara.Rtc_Org.Y);
                        if (Program.SystemContainer.SysPara.Rtc_Get_Data_Align == 1)
                        {
                            //对齐中心
                            do
                            {
                                Program.SystemContainer.GTS_Fun.Gts_Ready_Correct(Tem_Mark.X, Tem_Mark.Y);
                                //调用相机，获取对比的坐标信息
                                Thread.Sleep(500);
                                //相机反馈的当前坐标
                                Cam = new Vector(Program.SystemContainer.T_Client.Get_Cam_Deviation_Coordinate_Correct(1));//触发拍照 
                                if (Cam.Length == 0)
                                {
                                    MessageBox.Show("相机坐标提取失败，请检查！！！");
                                    CSV_RW.SaveCSV(Temp_Acquisition, "Rtc_Data_Aquisition_Temp_Fail");//原始数据保存
                                    CSV_RW.SaveCSV(Calibration_Data_Acquisition, "Rtc_Data_Aquisition_Fail");//原始数据保存
                                    return;
                                }
                                Coordinate = Program.SystemContainer.GTS_Fun.Get_Coordinate(1);
                                Tem_Mark = new Vector(Coordinate - Cam);//获取实际位置
                            } while (!Differ_Deviation(Cam, Program.SystemContainer.SysPara.Pos_Tolerance));
                        }
                        else
                        {
                            //实际测量
                            Program.SystemContainer.GTS_Fun.Gts_Ready_Correct(Tem_Mark.X, Tem_Mark.Y);
                            //调用相机，获取对比的坐标信息
                            Thread.Sleep(500);
                            //相机反馈的当前坐标
                            Cam = new Vector(Program.SystemContainer.T_Client.Get_Cam_Deviation_Coordinate_Correct(1));//触发拍照 
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
                Tem_Datum = new Vector(Convert.ToDecimal(Temp_Acquisition.Rows[((No + 1) * (No + 1) - 1) / 2][2].ToString()), Convert.ToDecimal(Temp_Acquisition.Rows[((No + 1) * (No + 1) - 1) / 2][3].ToString()));
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
        /// Mark坐标定位 试矫正
        /// </summary>
        private void Mark_AFF_Correction()
        {
            if (Calibration.Calibrate_Mark(0))
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
                if (MarkType == 1)// 1 - 整块板定位(取4角)
                {
                    File_Entity_Datas.PlatformMarkInfo.Clear();//清空平台Mark坐标
                    foreach (var o in File_Entity_Datas.DxfMarkInfo)
                    {
                        File_Entity_Datas.PlatformMarkInfo.Add(new Vector(o.X + File_Entity_Datas.Mark.X, o.Y + File_Entity_Datas.Mark.Y));
                    }
                }
                else if (MarkType == 2)// 2 - 阵列文件定位(小分区取4角)；
                {
                    for (int i = 0; i < File_Entity_Datas.LayerSectionDatas.Count; i++)
                    {
                        for (int j = 0; j < File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas.Count; j++)
                        {
                            File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas[j].PlatformMarkInfo.Clear();//清空平台Mark坐标
                            foreach (var o in File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas[j].DxfMarkInfo)
                            {
                                File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas[j].PlatformMarkInfo.Add(new Vector(o.X + File_Entity_Datas.Mark.X, o.Y + File_Entity_Datas.Mark.Y));
                            }
                        }
                    }
                }
                //验证视野是否存在Mark图形
                if (MarkType == 1)// 1 - 整块板定位(取4角)
                {
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
                        Program.SystemContainer.GTS_Fun.Gts_Ready_Correct(File_Entity_Datas.PlatformMarkInfo[i]);
                        //调用相机，获取对比的坐标信息
                        Thread.Sleep(50);//延时50ms
                        Cam = new Vector(Program.SystemContainer.T_Client.Get_Cam_Deviation_Coordinate_Correct(Program.SystemContainer.SysPara.Camera_Mark_Type));//触发拍照 
                        if (Cam.Length == 0)
                        {
                            MessageBox.Show("相机坐标提取失败，请检查！！！");
                            return null;
                        }
                    }
                }
                else if (MarkType == 2)// 2 - 阵列文件定位(小分区取4角)；
                {
                    //处理数据
                    for (int i = 0; i < File_Entity_Datas.LayerSectionDatas.Count; i++)
                    {
                        for (int j = 0; j < File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas.Count; j++)
                        {
                            //验证

                        }
                    }
                }
                appendInfo("Mark点矫正完成！！！");
                return;
            }
            else
            {
                appendInfo("Mark点矫正失败！！！");
                return;
            }
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

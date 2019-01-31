using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GTS;
using RTC5Import;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Threading;

namespace DG_Laser
{
    class Initial
    {
        //日志记录
        public Log Log;
        //系统参数
        public Parameter SysPara = new Parameter();
        //用户数据库操作
        public DB_Operate User_DB;
        //板卡IO
        public IO IO = new IO();
        //Gts板卡程序
        public GTS_Fun GTS_Fun;
        //Rtc板卡程序
        public RTC_Fun RTC_Fun;
        //强制定义RS232端口 
        public RS232 Laser_Control_Com = new RS232(); //激光发生器 串口通讯
        public Laser_Operation Laser_Operation_00 = new Laser_Operation(); //激光发生器 控制
        public RS232 Laser_Watt_Com = new RS232(); //激光功率计 串口通讯
        public Laser_Watt_Operation Laser_Watt_00 = new Laser_Watt_Operation();//激光功率计
        public Double_Fit_Data Laser_Watt_Percent_Relate = new Double_Fit_Data();//激光功率与百分比对应关系
        //定义Tcp连接
        public HPSocket_Communication T_Client = new HPSocket_Communication();
        //定义相机
        public Basler_Net_Cam BaslerCamera;
        //定义刀具列表
        public List<Tech_Parameter> Drill_Scissor = new List<Tech_Parameter>();
        public List<Tech_Parameter> Line_Scissor = new List<Tech_Parameter>();
        public List<Tech_Parameter> Arc_Scissor = new List<Tech_Parameter>();
        //定义重复列表
        public List<Repeat_Parameter> Repeat_Drill_Scissor = new List<Repeat_Parameter>();
        public List<Repeat_Parameter> Repeat_Line_Scissor = new List<Repeat_Parameter>();
        public List<Repeat_Parameter> Repeat_Arc_Scissor = new List<Repeat_Parameter>();
        //运动控制卡IO监视
        System.Timers.Timer GtsIORefreshTimer = new System.Timers.Timer(20);//10ms刷新一次
        //标志反转刷新 
        System.Timers.Timer RefreshTimer1s = new System.Timers.Timer(900);//1s刷新一次

        /// <summary>
        /// 构造函数
        /// </summary>
        public Initial()
        {
            Log = new Log();//初始化Log参数
        }
        /// <summary>
        /// GTS初始化
        /// </summary>
        public void Gts_Initial()
        {            
            //打开运动控制器 
            //定义GTS函数调用返回值
            short Com_Return;
            Com_Return = MC.GT_Open(0, 0);
            Log.WriteError("Gts_Initial---GT_Open", Com_Return);
            //Gts_Fun初始化
            GTS_Fun = new GTS_Fun();
            GTS_Fun.LogErr += Log.WriteError;
            GTS_Fun.LogInfo += Log.Info;
            //复位
            GTS_Fun.Reset();
            //读校准文件
            GTS_Fun.Load_Affinity_Matrix();
        }

        /// <summary>
        /// RTC初始化内容
        /// </summary>
        public void Rtc_Initial()
        {
            //Rtc_Fun初始化
            RTC_Fun = new RTC_Fun();
            RTC_Fun.LogErr += Log.WriteError;
            RTC_Fun.LogInfo += Log.Info;
            //复位
            RTC_Fun.Reset(SysPara.RtcAutoDelayCorrect);
            //读取校准参数
            RTC_Fun.Load_Affinity_Matrix();
        }
        //公共初始化内容
        //文件目录指定  配置文件夹所在目录
        const string Dir = @"./\Config";//当前目录下的Config文件夹
        /// <summary>
        /// 通用初始化
        /// </summary>
        public void Common_Initial()
        {
            //建立配置文件存储目录
            if (!Directory.Exists(Dir))
            {
                Directory.CreateDirectory(Dir);
            }
            //读取系统参数
            SysPara = OperatePara.LoadParaXml("Para");//读取参数   
            User_DB = new DB_Operate(SysPara.UserDB, SysPara.UserTB, SysPara.UserPath);//指定用户数据库和表
        }
        /// <summary>
        /// Rs232通讯初始化
        /// </summary>
        public void RS232_Initial()
        {
            //激光控制器 232
            Laser_Control_Com.Receive_Event += new Receive_Delegate(Laser_Operation_00.Resolve_Com_Data);
            Laser_Control_Com.LogErr += Log.WriteError;
            if (SysPara.Laser_Control_Com_No < Laser_Control_Com.PortName.Count)
            {
                Laser_Control_Com.Open_Com(SysPara.Laser_Control_Com_No);
            }
            else
            {
                MessageBox.Show("激光控制器通讯串口端口编号异常，请在激光控制面板选择正确的串口编号！！！");
            }

            //激光功率计 232
            Laser_Watt_Com.Receive_Event += new Receive_Delegate(Laser_Watt_00.Resolve_Com_Data);
            Laser_Watt_Com.LogErr += Log.WriteError;
            if (SysPara.Laser_Watt_Com_No < Laser_Watt_Com.PortName.Count)
            {
                Laser_Watt_Com.Open_Com(SysPara.Laser_Watt_Com_No, 3);
            }
            else
            {
                MessageBox.Show("激光功率计端口编号异常，请在激光功率计控制面板选择正确的串口编号！！！");
            }
            //加载功率 与 百分比校准文件
            Load_Watt_Percent_Relate();
        }
        /// <summary>
        /// laser 功率矫正初始化
        /// </summary>
        /// <returns></returns>
        public bool Load_Watt_Percent_Relate()
        {
            string File_Name = "Correct_File/Laser_Watt_Percent_Relate.csv";
            string File_Path = @"./\Config/" + File_Name;
            if (File.Exists(File_Path))
            {
                //获取矫正数据
                if (CSV_RW.DataTable_Double_Fit_Data(CSV_RW.OpenCSV(File_Path)).Count >= 1)
                {
                    Laser_Watt_Percent_Relate = new Double_Fit_Data(CSV_RW.DataTable_Double_Fit_Data(CSV_RW.OpenCSV(File_Path))[0]);
                    Log.Info("Laser_Watt_Percent_Relate 矫正文件加载成功！！！");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                Log.Info("Laser_Watt_Percent_Relate 矫正文件不存在！！！，禁止加工，请检查！");
                return false;
            }

        }
        /// <summary>
        /// Tcp通讯初始化
        /// </summary>
        public void Tcp_Initial()
        {
            //if (Process_Operate.StartApp("CellLocation"))//打开相机
            //{
            //    Thread.Sleep(2000);
                T_Client.TCP_Start(SysPara.Server_Ip, SysPara.Server_Port);
            //}
            //else
            //{
            //    Log.Info("相机打开失败!!!");
            //}   
            T_Client.LogErr += Log.WriteError;
            T_Client.LogInfo += Log.Info;
        }
        /// <summary>
        /// 加载刀具参数
        /// </summary>
        public bool Load_Scissor_Para()
        {
            string File_Path1 = @"./\Config/" + "Scissor_Parameter/Drill_Para.csv";
            string File_Path2 = @"./\Config/" + "Scissor_Parameter/Line_Para.csv";
            string File_Path3 = @"./\Config/" + "Scissor_Parameter/Arc_Para.csv";
            if (File.Exists(File_Path1) && File.Exists(File_Path2) && File.Exists(File_Path3))
            {
                Drill_Scissor = Common_Collect.DtToList<Tech_Parameter>.ConvertToModel(CSV_RW.OpenCSV(File_Path1));//钻孔刀具参数 读取
                Line_Scissor = Common_Collect.DtToList<Tech_Parameter>.ConvertToModel(CSV_RW.OpenCSV(File_Path2));//线段刀具参数 读取
                Arc_Scissor = Common_Collect.DtToList<Tech_Parameter>.ConvertToModel(CSV_RW.OpenCSV(File_Path3));//圆弧刀具参数 读取
                return true;
            }
            else
            {
                return false;
            }
           
        }
        /// <summary>
        /// 保存刀具参数
        /// </summary>
        public void Save_Scissor_Para() 
        {
            CSV_RW.SaveCSV_NoDate(Common_Collect.ListToDt<Tech_Parameter>(Drill_Scissor), "Scissor_Parameter/Drill_Para.csv");//钻孔刀具参数 保存
            CSV_RW.SaveCSV_NoDate(Common_Collect.ListToDt<Tech_Parameter>(Line_Scissor), "Scissor_Parameter/Line_Para.csv");//线段刀具参数 保存
            CSV_RW.SaveCSV_NoDate(Common_Collect.ListToDt<Tech_Parameter>(Arc_Scissor), "Scissor_Parameter/Arc_Para.csv");//圆弧刀具参数 保存
        }
        /// <summary>
        ///// 加载重复加工参数
        /// </summary>
        public bool Load_Repeat_Para()
        {
            string File_Name1 = "Scissor_Parameter/Repeat_Drill_Para.xml";
            string File_Name2 = "Scissor_Parameter/Repeat_Line_Para.xml";
            string File_Name3 = "Scissor_Parameter/Repeat_Arc_Para.xml";
            string File_Path1 = @"./\Config/" + File_Name1;
            string File_Path2 = @"./\Config/" + File_Name2;
            string File_Path3 = @"./\Config/" + File_Name3;
            if (File.Exists(File_Path1) && File.Exists(File_Path2) && File.Exists(File_Path3))
            {
                Repeat_Drill_Scissor = Common_Collect.Reserialize<Repeat_Parameter>(File_Name1);//钻孔线型重复加工参数 读取
                Repeat_Line_Scissor = Common_Collect.Reserialize<Repeat_Parameter>(File_Name2);//线段线型重复加工参数 读取
                Repeat_Arc_Scissor = Common_Collect.Reserialize<Repeat_Parameter>(File_Name3);//圆弧线型重复加工参数 读取
                return true;
            }
            else
            {
                Repeat_Parameter Tmp_Parameter = new Repeat_Parameter();
                List<Repeat_Parameter> Tmp_Parameter_List = new List<Repeat_Parameter>();
                for (int i = 0;i < Tmp_Parameter.Repeat.Length;i++)
                {
                    Tmp_Parameter.Repeat[i] = (byte)i;
                }
                Tmp_Parameter_List.Add(new Repeat_Parameter(Tmp_Parameter));
                Repeat_Drill_Scissor = new List<Repeat_Parameter>(Tmp_Parameter_List);//钻孔线型重复加工参数 读取
                Repeat_Line_Scissor = new List<Repeat_Parameter>(Tmp_Parameter_List);//线段线型重复加工参数 读取
                Repeat_Arc_Scissor = new List<Repeat_Parameter>(Tmp_Parameter_List);//圆弧线型重复加工参数 读取
                return false;
            }

        }
        /// <summary>
        /// 保存重复加工参数
        /// </summary>
        public void Save_Repeat_Para()
        {
            Common_Collect.Serialize<Repeat_Parameter>(Repeat_Drill_Scissor, "Scissor_Parameter/Repeat_Drill_Para.xml");//钻孔线型重复加工参数 保存
            Common_Collect.Serialize<Repeat_Parameter>(Repeat_Line_Scissor, "Scissor_Parameter/Repeat_Line_Para.xml");//线段线型重复加工参数 保存
            Common_Collect.Serialize<Repeat_Parameter>(Repeat_Arc_Scissor, "Scissor_Parameter/Repeat_Arc_Para.xml");//圆弧线型重复加工参数 保存
        }
        /// <summary>
        /// 启动Timer
        /// </summary>
        public void TimerEN()
        {
            //启用定时器
            GtsIORefreshTimer.Elapsed += IO.Refresh_IO;
            GtsIORefreshTimer.AutoReset = true;
            GtsIORefreshTimer.Enabled = true;
            GtsIORefreshTimer.Start();

            //启用定时器 
            RefreshTimer1s.Elapsed += IO.Timer_1s;
            RefreshTimer1s.Disposed += IO.Clear;
            RefreshTimer1s.AutoReset = true;
            RefreshTimer1s.Enabled = true;
            RefreshTimer1s.Start();
        }
        /// <summary>
        /// 释放Timer
        /// </summary>
        public void TimerOFF()
        {
            GtsIORefreshTimer.Dispose();
            RefreshTimer1s.Dispose();
        }
    }


}
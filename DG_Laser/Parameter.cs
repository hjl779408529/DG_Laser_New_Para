using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using SharpConfig;

namespace DG_Laser
{
    [Serializable]
    public class Parameter
    {       
        //用户数据
        public string UserDB { get; set; }
        public string UserTB { get; set; }
        public string UserPath { get; set; }
        

        //运动控制卡
        public decimal Gts_Vel_reference { get; set; }//速度参数转换基准，脉冲数转换为mm
        public decimal Gts_Acc_reference { get; set; }//加速度参数转换基准 mm/s2
        public decimal Gts_Pos_reference { get; set; }//位置参数转换基准，脉冲数转换为mm
        
        //轴软件限位
        public int AxisIndicate { get; set; }
        public Int32 AxisXSoftLimitPositive { get; set; }
        public Int32 AxisXSoftLimitNegative { get; set; }
        public Int32 AxisYSoftLimitPositive { get; set; }
        public Int32 AxisYSoftLimitNegative { get; set; }
        public Int32 AxisZSoftLimitPositive { get; set; }
        public Int32 AxisZSoftLimitNegative { get; set; }
        //单轴运行参数
        public decimal AxisXAcc { get; set; }//加速度 mm/s2
        public decimal AxisXDcc { get; set; }//减速度 mm/s2
        public decimal AxisXVelocity { get; set; }//速度 mm/s2
        public short AxisXSmoothTime { get; set; }//平滑时间 ms
        public decimal AxisYAcc { get; set; }//加速度 mm/s2
        public decimal AxisYDcc { get; set; }//减速度 mm/s2
        public decimal AxisYVelocity { get; set; }//速度 mm/s2
        public short AxisYSmoothTime { get; set; }//平滑时间 ms
        public decimal AxisZAcc { get; set; }//加速度 mm/s2
        public decimal AxisZDcc { get; set; }//减速度 mm/s2
        public decimal AxisZVelocity { get; set; }//速度 mm/s2
        public short AxisZSmoothTime { get; set; }//平滑时间 ms
        //轴到位整定
        public UInt16 Axis_X_Band { get; set; }//X轴到位允许误差 /pluse
        public UInt16 Axis_X_Time { get; set; }//X轴误差带保持时间 /250us
        public UInt16 Axis_Y_Band { get; set; }//X轴到位允许误差 /pluse
        public UInt16 Axis_Y_Time { get; set; }//X轴误差带保持时间 /250us
        public UInt16 Posed_Time { get; set; }//到位延时
        
        //轴上位机回零参数
        public decimal Search_Home { get; set; }//设定原点搜索范围 1脉冲10um，搜索范围-2000mm
        public decimal Home_OffSet { get; set; }//设定原点OFF偏移距离
        public decimal Home_High_Speed { get; set; }//设定原点回归速度，脉冲/ms,即200HZ mm/s
        public decimal Home_acc { get; set; }//回零加速度 mm/s2
        public decimal Home_dcc { get; set; }//回零减速度 mm/s2
        public short Home_smoothTime { get; set; }//回零平滑时间 ms
        public decimal Pos_Tolerance { get; set; }//坐标误差范围判断
        //标定选项
        public int CalibrationSelect { get; set; }
        //平台标定板参数
        public int Gts_Calibration_Method { get; set; }//校准方式3/4
        public decimal Gts_Calibration_X_Len { get; set; }//标定板X尺寸 mm
        public decimal Gts_Calibration_Y_Len { get; set; }//标定板Y尺寸 mm
        public decimal Gts_Calibration_X_Cell { get; set; }//标定板间隔尺寸 mm
        public decimal Gts_Calibration_Y_Cell { get; set; }//标定板间隔尺寸 mm
        public int Gts_Calibration_Col_X { get; set; }//标定板的点位gts_calibration横纵数 col-列-X
        public int Gts_Calibration_Row_Y { get; set; }//标定板的点位gts_calibration横纵数 row-行-Y
        public int Gts_Affinity_Col_X { get; set; }//仿射变换的横纵数 col-列-X
        public int Gts_Affinity_Row_Y { get; set; }//仿射变换的横纵数 row-行-Y
        //振镜标定参数     
        public int Rtc_Calibration_Method { get; set; }//校准方式3/4
        public decimal Rtc_Calibration_X_Len { get; set; }//打标X长度
        public decimal Rtc_Calibration_Y_Len { get; set; }//打标Y长度
        public decimal Rtc_Calibration_X_Cell { get; set; }//打标间距
        public decimal Rtc_Calibration_Y_Cell { get; set; }//打标间距
        public int Rtc_Calibration_Col_X { get; set; }//打标 Col 列数 X
        public int Rtc_Calibration_Row_Y { get; set; }//打标 Row 行数 Y
        public int Rtc_Affinity_Col_X { get; set; }//仿射计算 Col 列数 X
        public int Rtc_Affinity_Row_Y { get; set; }//仿射计算 Row 行数 Y
        public int RtcCorrectType { get; set; }//校准方式 0 - 坐标系仿射，1 - 仿射矩阵
        public int Rtc_Distortion_Data_Type { get; set; }
        public decimal Rtc_Distortion_Data_Radius { get; set; }
        public int Rtc_Get_Data_Align { get; set; }//采集校准数据的时对齐，还是采集源数据
        //坐标系参数
        public Vector Work { get; set; }//加工坐标系坐标点
        public decimal Cam_Reference { get; set; }//相机单像素对应的实际比例 mm/pixel
        public Vector Rtc_Org { get; set; }//振镜激光原点  相对于 直角坐标系原点 相对间距
        public Vector Cal_Org { get; set; }//坐标系原点对正偏移量

        //RTC板卡参数
        public UInt32 Reset_Completely { get; set; }//复位范围
        public UInt32 Default_Card { get; set; }//初始PCI卡号
        public UInt32 Laser_Mode { get; set; }//激光类型 0-CO2/1-YAG MODE1/2-YAG MODE2/3-YAG MODE3/4-LASER MODE4/6-LASER MODE6
        public UInt32 Laser_Control { get; set; }//激光控制 Laser signals LOW active  (Bit 3 and 4) 0x18 高电平 
        public decimal Rtc_Period_Reference { get; set; }//分频基准 RTC4-1/8us RTC5-1/64us 用于set_standby( HalfPeriod, PulseLength )、set_laser_pulses( HalfPeriod, PulseLength )、set_firstpulse_killer( Length )
        public decimal Laser_Delay_Reference { get; set; }//延时基准 RTC4-1us RTC5-1/2us 用于set_laser_delays( LaserOnDelay, LaserOffDelay )
        public decimal Scanner_Delay_Reference { get; set; }//延时基准 10us  用于set_scanner_delays( Jump, Mark, Polygon )，eg.warmup_time/jump_delay/mark_delay/polygon_delay/arc_delay/line_delay
        public decimal Rtc_Pos_Reference { get; set; }//mm与振镜变量转换比例 mm/bit
        public UInt32 Analog_Out_Ch { get; set; }//输出通道 
        public UInt32 Analog_Out_Value { get; set; }//Standard Pump Source Value
        public UInt32 Analog_Out_Standby { get; set; }//Standby Pump Source Value
        //以rtc_period_reference为基准
        public decimal Standby_Half_Period { get; set; }//[1/64 us] 
        public decimal Standby_Pulse_Width { get; set; }//[1/64 us] 
        public decimal Laser_Half_Period { get; set; }//[1/64 us]
        public decimal Laser_Pulse_Width { get; set; }//[1/64 us]
        //以laser_delay_reference为基准
        public decimal First_Pulse_Killer { get; set; }//[1 us]
        public decimal Laser_On_Delay { get; set; }//[1 us]
        //以scanner_delay_reference为基准 
        public decimal Laser_Off_Delay { get; set; }//[10 us]
        public decimal Warmup_Time { get; set; }//[10 us]
        public decimal Jump_Delay { get; set; }//[10 us]
        public decimal Mark_Delay { get; set; }//[10 us]
        public decimal Polygon_Delay { get; set; }//[10 us]
        //加工速度
        public double Mark_Speed { get; set; }//[Bits/ms]        
        public double Jump_Speed { get; set; }//[Bits/ms]  
        public UInt32 List1_Size { get; set; }//list1 容量
        public UInt32 List2_Size { get; set; }//list1 容量
        public Vector Rtc_Home { get; set; }//振镜坐标原点
        public Int32 Laser_Control_Com_No { get; set; }//激光控制器串口号
        public Int32 Laser_Watt_Com_No { get; set; }//激光功率计串口号
        public decimal Rtc_Cal_Radius { get; set; }//振镜打标半径
        public decimal Rtc_Cal_Interval { get; set; } //振镜打标间距
        public bool RtcAutoDelayCorrect { get; set; }//自动校正延时开启与否
       
        //仿射变换参数
        public Affinity_Matrix Cam_Trans_Affinity { get; set; }//相机坐标系标定仿射变换参数
        public Affinity_Matrix Rtc_Trans_Affinity { get; set; }//振镜坐标系的仿射变换参数
        public Vector Rtc_Limit { get; set; }//振镜扫描范围

        //激光发生器参数
        public decimal Seed_Current { get; set; }
        public decimal Amp1_Current { get; set; }
        public decimal Amp2_Current { get; set; }
        public decimal Seed_Temperature { get; set; }
        public decimal Amp_Temperature { get; set; }
        public decimal PRF { get; set; }
        public decimal PEC { get; set; }

        public UInt16 Calibration_Type { get; set; }
        public decimal Mark_Reference { get; set; }
        public UInt16 Split_Block_X { get; set; }
        public UInt16 Split_Block_Y { get; set; }
        //Tcp通讯配置
        public string Server_Ip { get; set; }
        public ushort Server_Port { get; set; }        
        //平台配合振镜数据定位点
        public string Calibrate_Mark_Scissor { get; set; } //所用的刀具指定，强制标记为校准用刀      
        
        
        public int Camera_Intrigue_Num { get; set; } //触发 信号 测试用
        public int Camera_Mark_Type { get; set; } //相机识别Mark图形 0 - 圆;1 - 矩形；2 - 十字叉
        public int Camera_Intrigue_Sequence { get; set; }//相机触发信号
        public bool CamEn { get; set; } //false - 不启用，true - 启用
        public decimal CameraCentreX { get; set; } //相机像素中心X
        public decimal CameraCentreY { get; set; } //相机像素中心Y
        public int Work_Type_Select { get; set; }//加工方式选择
        public decimal CoordinateJogStep { get; set; }//坐标系Jog步距
        public int CalTimes { get; set; }//多次校准次数
        public Vector LeftDownPoint { get; set; } //文档左下角平台
        public bool MarkJump { get; set; } //false - 红光预览，true - 激光加工


        //点位设置
        public int PrecessEnd { get; set; }//结束位置选择               0：无动作 1：归零 2：至左平台暂停位 3：至右平台暂停位 4：至卸料位
        public int PointListIndex { get; set; }//点位选择
        public Vector FreedomPoint { get; set; }//自由点位
        public Vector StandbyPoint { get; set; }//待机点位
        public Vector ResignationPoint { get; set; }//指定点位
        public Vector LeftPausePoint { get; set; }//左暂停位
        public Vector RightPausePoint { get; set; }//右暂停位
        public Vector Upload_Point { get; set; }//下料点位
        public Vector Debug_Gts_Basis { get; set; }//调试点位



        public int SectionWorkType { get; set; } //0 - 单分区多图层，1 - 单分区单图层
        public int ShieldBeepTime { get; set; } //蜂鸣器屏蔽时长/s     
        public int Move_Z { get; set; }                //Zz轴动作                0：无动作 1：至快移位 2：至快移位（仅加工定位前）

        public int Count_nnum { get; set; }            //加工计数功能            1:开启 0：不开启
        public int Count_pieces { get; set; }          //片数提醒功能            1:开启 0：不开启
 
        public int Door_use { get; set; }              //加工时启用自动门开关    1：启用 0：不启用
        public int Door_timelimit { get; set; }        //状态检测时限 （ms） 滤波时间
        public int Door_delay { get; set; }            //开门稳定延时（ms） 

        public int Con_chillerTem { get; set; }        //启动后检查冷水机温度    1：检查 0：不检查
        public int Con_light { get; set; }             //加工时自动开辅助照明    1：开启 0：不开启
        public int Con_lasersta { get; set; }          //加工前检查激光器状态    1：检查 0：不检查
        public int Con_endAlarm { get; set; }          //加工结束后报警提醒      1：报警 0：不报警
        public int Con_endDlg { get; set; }            //加工结束后对话框提醒    1：提醒 0：不提醒
        //public int Con_coverUD { get; set; }           //启用加工时风罩自动升降  1：启用 0：不启用

        public int Safe_Baffle { get; set; }            //启用激光挡板功能        1：启用 0：不启用
        public int Safe_door { get; set; }             //加工时检测仓门状态      1：检测 0：不检测
        public int Safe_moveEntrench { get; set; }     //启用运动安全防护        1：启用 0：不启用
        public int Safe_openEntrench { get; set; }     //启用开门安全防护        1：启用 0：不启用
        public int Safe_closeEntrench { get; set; }    //启用关门安全防护        1：启用 0：不启用

        public int Vacuum_openCleaner { get; set; }     //加工前自动打开吸尘器    1：打开  0：不打开
        public int Vacuum_closeCleaner { get; set; }    //加工完成自动关闭吸尘器  1：关闭  0：不关闭
        public int Vacuum_PressCheck { get; set; }           //加工时检查真空压力      1：检查 0：不检查
        public int Vacuum_opendelay { get; set; }       //加工前开真空延时    
        public int Vacuum_closedelay { get; set; }      //加工完关真空延时

        public int Gtc_axis { get; set; }              //轴                      0：X轴   1：Y轴
        public decimal Gtc_highLimit { get; set; }     //正限位
        public decimal Gtc_lowLimit { get; set; }      //负限位

        //校准文件及路径
        public string RtcXmlCorrectFile { get; set; }
        public string RtcXmlCorrectFilePath { get; set; }
        public string RtcCt5CorrectFile { get; set; }
        public string RtcCt5CorrectFilePath { get; set; }
        public string GtsCorrectFile { get; set; }
        public string GtsCorrectFilePath { get; set; }

        //重复性测试
        public int PointListRepeatTimes { get; set; }//重复次数

    }
    class OperatePara
    {
        /// <summary>
        /// 读取配置参数 返回实例化后的参数，如：类，结构体
        /// </summary>
        /// <param name="filename"></param>
        public class SharpConfig<T> where T : new()  
        {
            public static T LoadPara(string filename,string section)
            {
                T Result = new T();
                string filepath = @"./\Config/" + filename;
                Configuration config = Configuration.LoadFromFile(filepath);
                var props = typeof(T).GetProperties();
                Result = config[section].ToObject<T>();
                return Result;
            }
        }  
        public static bool InsertToConfig<T>(Configuration config, T shuju)
        {

            return true;
        }
        /// <summary>
        /// 保存配置参数到指定文件
        /// </summary>
        /// <param name="filename"></param>
        public static bool SavePara(string filename, Configuration config)
        {
            string filepath = @"./\Config/" + filename;
            config.SaveToFile(filepath,Encoding.GetEncoding("gb2312"));
            return true;
        }
        // <summary>
        /// 读取配置参数
        /// </summary>
        /// <param name="filename"></param>
        public static Parameter LoadParaXml(string filename)
        { 
            Parameter Result = new Parameter();
            string filepath = @"./\Config/" + filename + ".xml";
            if (File.Exists(filepath))
            {
                using (FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    //xml 反序列化
                    XmlSerializer bf = new XmlSerializer(typeof(Parameter));
                    Result = (Parameter)bf.Deserialize(fs);
                    fs.Close();
                }
            }
            return Result;
        }

        /// <summary>
        /// 保存配置参数 XML
        /// </summary>
        /// <param name="filename"></param>
        public static bool SaveParaXml(string filename, Parameter para) 
        {
            string filepath = @"./\Config/" + filename + ".xml";
            //xml 序列化
            using (FileStream fs = new FileStream(filepath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                XmlSerializer bf = new XmlSerializer(typeof(Parameter));
                bf.Serialize(fs, para);
                fs.Close();
            }
            return true;
        }
        /// <summary>
        /// 保存配置参数 XML
        /// </summary>
        /// <param name="filename"></param>
        public static bool SaveXml<T>(string filename, T para)
        {
            string filepath = @"./\Config/" + filename + ".xml";
            //xml 序列化
            using (FileStream fs = new FileStream(filepath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                XmlSerializer bf = new XmlSerializer(typeof(T));
                bf.Serialize(fs, para);
                fs.Close();
            }
            return true;
        }
        /// <summary>
        /// 保存配置参数 XML
        /// </summary>
        /// <param name="filename"></param>
        public static bool SaveXmlNoPath<T>(string filename, T para)
        {
            //xml 序列化
            using (FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                XmlSerializer bf = new XmlSerializer(typeof(T));
                bf.Serialize(fs, para);
                fs.Close();
            }
            return true;
        }
        // <summary>
        /// 读取配置参数
        /// </summary>
        /// <param name="filename"></param>
        /// /// <summary>
        /// 读取配置参数 返回实例化后的参数，如：类，结构体
        /// </summary>
        /// <param name="filename"></param>
        public class LoadXml<T> where T : new()
        {
            public static T LoadPara(string filename)
            {
                T Result = new T();
                string filepath = @"./\Config/" + filename + ".xml";
                if (File.Exists(filepath))
                {
                    using (FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        //xml 反序列化
                        XmlSerializer bf = new XmlSerializer(typeof(T));
                        Result = (T)bf.Deserialize(fs);
                        fs.Close();
                    }
                }
                return Result;
            }
        }
        // <summary>
        /// 读取配置参数
        /// </summary>
        /// <param name="filename"></param>
        /// /// <summary>
        /// 读取配置参数 返回实例化后的参数，如：类，结构体
        /// </summary>
        /// <param name="filename"></param>
        public class LoadXmlNoPath<T> where T : new()
        {
            public static T LoadPara(string filename)
            {
                T Result = new T();
                if (File.Exists(filename))
                {
                    using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        //xml 反序列化
                        XmlSerializer bf = new XmlSerializer(typeof(T));
                        Result = (T)bf.Deserialize(fs);
                        fs.Close();
                    }
                }
                return Result;
            }
        }

    }
}

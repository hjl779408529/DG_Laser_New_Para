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
        public decimal Manual_Vel { get; set; }//手动速度 mm/s
        public decimal Auto_Vel { get; set; }//自动速度 mm/s
        public decimal Acc { get; set; }//加速度 mm/s2
        public decimal Dcc { get; set; }//减速度 mm/s2
        public decimal Syn_MaxVel { get; set; }//最大合成速度 mm/s
        public decimal Syn_MaxAcc { get; set; }//最大合成加速度 mm/s2 1G=10米/秒
        public decimal Syn_EvenTime { get; set; }//合成平滑时间 ms
        public decimal Line_synVel { get; set; }//直线插补速度 mm/s
        public decimal Line_synAcc { get; set; }//直线插补加速度 mm/s2
        public decimal Line_endVel { get; set; }//直线插补结束停止速度 mm/s
        public decimal Circle_synVel { get; set; }//圆弧插补速度 mm/s
        public decimal Circle_synAcc { get; set; }//圆弧插补加速度  mm/s2
        public decimal Circle_endVel { get; set; }//圆弧插补结束停止速度 mm/s
        public decimal LookAhead_EvenTime { get; set; }//前瞻运动平滑时间  ms
        public decimal LookAhead_MaxAcc { get; set; }//前瞻运动最大合成加速度 mm/s2 1G=10米/秒
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
        //XY平台标定板参数
        public decimal Gts_Calibration_X_Len { get; set; }//标定板X尺寸 mm
        public decimal Gts_Calibration_Y_Len { get; set; }//标定板Y尺寸 mm
        public decimal Gts_Calibration_Cell { get; set; }//标定板间隔尺寸 mm
        public Int16 Gts_Calibration_Col { get; set; }//标定板的点位gts_calibration横纵数 col-列-y
        public Int16 Gts_Calibration_Row { get; set; }//标定板的点位gts_calibration横纵数 row-行-x
        public Int16 Gts_Affinity_Col { get; set; }//仿射变换的横纵数 col-列-y
        public Int16 Gts_Affinity_Row { get; set; }//仿射变换的横纵数 row-行-x
        public Int16 Gts_Affinity_Type { get; set; }//GTS坐标矫正变换类型 0-三对点 小区块数据 仿射变换、1-全部点对 仿射变换

        //振镜标定参数
        public decimal Rtc_Calibration_X_Len { get; set; }//打标X长度
        public decimal Rtc_Calibration_Y_Len { get; set; }//打标Y长度
        public decimal Rtc_Calibration_Cell { get; set; }//打标间距
        public Int16 Rtc_Calibration_Col { get; set; }//打标 Col 列数
        public Int16 Rtc_Calibration_Row { get; set; }//打标 Row 行数
        public Int16 Rtc_Affinity_Col { get; set; }//仿射计算 Col 列数
        public Int16 Rtc_Affinity_Row { get; set; }//仿射计算 Row 行数 
        public Int16 Rtc_Affinity_Type { get; set; }//RTC坐标矫正变换类型 0-三对点 小区块数据 仿射变换、1-全部点对 仿射变换

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
        //平台定位Mark点
        public Vector Mark1 { get; set; }
        public Vector Mark2 { get; set; }
        public Vector Mark3 { get; set; }
        public Vector Mark4 { get; set; }
        //Dxf文件定位点
        public Vector Mark_Dxf1 { get; set; }
        public Vector Mark_Dxf2 { get; set; }
        public Vector Mark_Dxf3 { get; set; }
        public Vector Mark_Dxf4 { get; set; }

        //仿射变换参数
        public Affinity_Matrix Trans_Affinity { get; set; }//工件摆放仿射变换参数
        public Affinity_Matrix Cal_Trans_Angle { get; set; }//标定板摆放角度仿射变换参数
        public Affinity_Matrix Cam_Trans_Affinity { get; set; }//相机坐标系标定仿射变换参数
        public Affinity_Matrix Rtc_Trans_Affinity { get; set; }//振镜坐标系的仿射变换参数
        public Affinity_Matrix Rtc_Trans_Angle { get; set; }//振镜坐标系的旋转变换参数
        public Vector Rtc_Limit { get; set; }//振镜扫描范围

        //激光发生器参数
        public decimal Seed_Current { get; set; }
        public decimal Amp1_Current { get; set; }
        public decimal Amp2_Current { get; set; }
        public decimal PRF { get; set; }
        public decimal PEC { get; set; }

        public UInt16 Calibration_Type { get; set; }
        public decimal Mark_Reference { get; set; }
        public UInt16 Split_Block_X { get; set; }
        public UInt16 Split_Block_Y { get; set; }
        //Tcp通讯配置
        public string Server_Ip { get; set; }
        public ushort Server_Port { get; set; }
        //通行畸变打标参数
        public ushort Rtc_Distortion_Data_Type { get; set; }
        public decimal Rtc_Distortion_Data_Radius { get; set; }
        public decimal Rtc_Distortion_Data_Interval { get; set; }
        public decimal Rtc_Distortion_Data_Limit { get; set; }
        public UInt16 Rtc_Get_Data_Align { get; set; }
        //平台配合振镜数据定位点
        public Vector Base_Gts { get; set; }//加工点
        public Vector Upload_Point { get; set; }//下料点
        public int Upload_Type_Select { get; set; }//结束位置选择
        public UInt16 Camera_Mark_Type { get; set; }//相机识别Mark图形
        public int Work_Type_Select { get; set; }//加工方式选择
        public int Work_Scissors_Limit { get; set; }//刀具数量限制
        public int Work_Repeat_Times { get; set; }//整体加工次数
        public int Work_Repeat_Limit { get; set; }//整体加工次数限制
        public string DxfFileName { get; set; }//待加工文件名
        
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
    }
}

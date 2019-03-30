using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using RTC5Import;

namespace DG_Laser
{
    class RTC_Fun
    {
        //Rtc执行返回值
        public uint Rtc_Return;
        public event LogErruint LogErr;
        public event LogInfo LogInfo;
        //仿射矫正矩阵数据匹配标志
        public bool AffinityCountOK = false;
        /// <summary>
        /// 初始化振镜
        /// </summary>
        public void Reset(bool delaycorrect)
        {
            //初始化Dll
            Rtc_Return = RTC5Wrap.init_rtc5_dll();
            if (Rtc_Return != 0u && Rtc_Return != 2u)
            {
                LogErr?.Invoke("振镜初始化出错", Rtc_Return);
            }
            //设置兼容RTC4
            //RTC5Wrap.set_rtc4_mode();
            RTC5Wrap.set_rtc5_mode();

            //加载校准文件
            Load_CorrectFile("./Config/Cor_1to1.ct5");
               
            //加载Program_File文件
            if (delaycorrect)
            {
                Rtc_Return = RTC5Wrap.load_program_file("./Config/Rtc/");
                if (Rtc_Return != 0u)
                {
                    LogErr?.Invoke("加载Program_File出错", Rtc_Return);
                }
            }
            else
            {
                Rtc_Return = RTC5Wrap.load_program_file(null);
                if (Rtc_Return != 0u)
                {
                    LogErr?.Invoke("加载Program_File出错", Rtc_Return);
                }
            }
            

            //assigns the previously loaded correction tables #1 or #2 to the scan head control ports
            //and activates image field correction.
            //  table #1 at primary connector (default)
            RTC5Wrap.select_cor_table(1, 1);

            //stop_execution might have created an RTC5_TIMEOUT error
            //复位Rtc
            RTC5Wrap.reset_error(Program.SystemContainer.SysPara.Reset_Completely);
            //defines the length of the FirstPulseKiller signal for a YAG laser
            RTC5Wrap.set_firstpulse_killer(Convert.ToUInt32(Program.SystemContainer.SysPara.First_Pulse_Killer * Program.SystemContainer.SysPara.Rtc_Period_Reference));

            //配置list大小
            //Configure list memory, default: config_list(4000,4000)
            RTC5Wrap.config_list(Program.SystemContainer.SysPara.List1_Size, Program.SystemContainer.SysPara.List2_Size);
            //配置激光模式
            RTC5Wrap.set_laser_mode(Program.SystemContainer.SysPara.Laser_Mode);
            //配置激光控制
            //  This function must be called at least once to activate laser 
            //  signals. Later on enable/disable_laser would be sufficient.
            //Bit #0 (LSB) Pulse Switch Setting (doesn’t apply neither to laser mode 4 nor to laser mode 6):
            //    The setting only affects those laser control signals(more precisely: those LASER1 or LASER2
            //    “laser active” modulation pulses in CO2 mode or LASER1 Q - Switch pulses in the YAG modes) that are
            //    not yet fully processed at completion of the LASERON signal(see figure 46 and figure 47).
            //    = 0: The signals are cut off at the end of the LASERON signal.
            //    = 1: The final pulse will fully execute despite completion of the LASERON signal.
            //Bit #1 Phase shift of the laser control signals (doesn’t apply neither to laser mode 4 nor to laser mode 6)
            //    = 0: no phase shift
            //    = 1: CO2 mode: The LASER1 signal is exchanged with the LASER2 signal.
            //    YAG modes: The LASER1 is shifted back 180° (half a signal period).
            //Bit #2 Enabling or disabling of laser control signals for “Laser active” operation
            //    = 0: The “Laser active” laser control signals will be enabled.
            //    = 1: The “Laser active” laser control signals will be disabled.
            //Bit #3 LASERON signal level
            //    = 0: The signal at the LASERON port will be set to active - high.
            //    = 1: The signal at the LASERON port will be set to active - low.
            //Bit #4 LASER1/LASER2 signal level
            //    = 0: The signals at the LASER1 and LASER2 output ports will be set to active-high.
            //    = 1: The signals at the LASER1 and LASER2 output ports will be set to active-low.
            RTC5Wrap.set_laser_control(Program.SystemContainer.SysPara.Laser_Control);//0x18 

            RTC5Wrap.set_firstpulse_killer(Convert.ToUInt32(Program.SystemContainer.SysPara.First_Pulse_Killer * Program.SystemContainer.SysPara.Rtc_Period_Reference));

            //activates the home jump mode (for the X and Y axes) and defines the home position
            RTC5Wrap.home_position(Convert.ToInt32(Program.SystemContainer.SysPara.Rtc_Home.Y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(Program.SystemContainer.SysPara.Rtc_Home.X * Program.SystemContainer.SysPara.Rtc_Pos_Reference));

            // Turn on the optical pump source and wait for 2 seconds.
            // (The following assumes that signal ANALOG OUT1 of the
            // laser connector controls the pump source.)
            RTC5Wrap.write_da_x(Program.SystemContainer.SysPara.Analog_Out_Ch, Program.SystemContainer.SysPara.Analog_Out_Value);

            //定义待机 激光周期和脉冲长度
            //defines the output period and the pulse length of the standby pulses for “laser standby”
            //operation or – in laser mode 4 and laser mode 6 – the continuously-running laser signals
            //for “laser active” and “laser standby” operation.
            RTC5Wrap.set_standby(Convert.ToUInt32(Program.SystemContainer.SysPara.Standby_Half_Period * Program.SystemContainer.SysPara.Rtc_Period_Reference), Convert.ToUInt32(Program.SystemContainer.SysPara.Standby_Pulse_Width * Program.SystemContainer.SysPara.Rtc_Period_Reference));

            // Timing, delay and speed preset.
            // Transmit the following list commands to the list buffer.
            RTC5Wrap.set_start_list(1U);
            // Wait for Program.SystemContainer.SysPara.Warmup_Time seconds
            RTC5Wrap.long_delay(Convert.ToUInt32(Program.SystemContainer.SysPara.Warmup_Time / Program.SystemContainer.SysPara.Scanner_Delay_Reference));
            RTC5Wrap.set_laser_pulses(
                Convert.ToUInt32(Program.SystemContainer.SysPara.Laser_Half_Period * Program.SystemContainer.SysPara.Rtc_Period_Reference),    // half of the laser signal period.
                Convert.ToUInt32(Program.SystemContainer.SysPara.Laser_Pulse_Width * Program.SystemContainer.SysPara.Rtc_Period_Reference));  // pulse widths of signal LASER1.
            RTC5Wrap.set_scanner_delays(
                Convert.ToUInt32(Program.SystemContainer.SysPara.Jump_Delay / Program.SystemContainer.SysPara.Scanner_Delay_Reference),    // jump delay, in 10 microseconds.
                Convert.ToUInt32(Program.SystemContainer.SysPara.Mark_Delay / Program.SystemContainer.SysPara.Scanner_Delay_Reference),    // mark delay, in 10 microseconds.
                Convert.ToUInt32(Program.SystemContainer.SysPara.Polygon_Delay / Program.SystemContainer.SysPara.Scanner_Delay_Reference));    // polygon delay, in 10 microseconds.
            RTC5Wrap.set_laser_delays(
                Convert.ToInt32(Program.SystemContainer.SysPara.Laser_On_Delay * Program.SystemContainer.SysPara.Laser_Delay_Reference),    // laser on delay, in microseconds.
                Convert.ToUInt32(Program.SystemContainer.SysPara.Laser_Off_Delay * Program.SystemContainer.SysPara.Laser_Delay_Reference));   // laser off delay, in microseconds.
            // jump speed in bits per milliseconds.
            RTC5Wrap.set_jump_speed(Program.SystemContainer.SysPara.Jump_Speed);
            // marking speed in bits per milliseconds.
            RTC5Wrap.set_mark_speed(Program.SystemContainer.SysPara.Mark_Speed);
            RTC5Wrap.set_end_of_list();
            RTC5Wrap.execute_list(1U);

            //Pump source warming up ,wait!!!
            uint Busy;
            do
            {
                RTC5Wrap.get_status(out Busy, out uint Position);
            } while (Busy != 0U);

        }
        /// <summary>
        /// 加载校准文件
        /// </summary>
        /// <param name="file"></param>
        public bool Load_CorrectFile(string file)
        {
            if (!File.Exists(file)) return false;

            //停止正在执行的Rtc
            //  If the DefaultCard has been used previously by another application 
            //  a list might still be running. This would prevent load_program_file
            //  and load_correction_file from being executed.
            RTC5Wrap.stop_execution();

            //加载Correct文件
            Rtc_Return = RTC5Wrap.load_correction_file(
                file,
                1u,
                2u
                );
            if (Rtc_Return != 0u)
            {
                LogErr?.Invoke(string.Format("{0}-加载失败！！！",file), Rtc_Return);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 修改参数
        /// </summary>
        public void Change_Para()
        {
            //  wait list List_No to be not busy
            //  load_list( List_No, 0) returns 1 if successful, otherwise 0
            //执行到POS 0
            do
            {

            }
            while (RTC5Wrap.load_list(1u, 0u) == 0);
            // Timing, delay and speed preset.
            // Transmit the following list commands to the list buffer.
            RTC5Wrap.set_start_list(1u);
            RTC5Wrap.set_laser_pulses(
                Convert.ToUInt32(Program.SystemContainer.SysPara.Laser_Half_Period * Program.SystemContainer.SysPara.Rtc_Period_Reference),    // half of the laser signal period.
                Convert.ToUInt32(Program.SystemContainer.SysPara.Laser_Pulse_Width * Program.SystemContainer.SysPara.Rtc_Period_Reference));  // pulse widths of signal LASER1.
            RTC5Wrap.set_scanner_delays(
                Convert.ToUInt32(Program.SystemContainer.SysPara.Jump_Delay / Program.SystemContainer.SysPara.Scanner_Delay_Reference),    // jump delay, in 10 microseconds.
                Convert.ToUInt32(Program.SystemContainer.SysPara.Mark_Delay / Program.SystemContainer.SysPara.Scanner_Delay_Reference),    // mark delay, in 10 microseconds.
                Convert.ToUInt32(Program.SystemContainer.SysPara.Polygon_Delay / Program.SystemContainer.SysPara.Scanner_Delay_Reference));    // polygon delay, in 10 microseconds.
            RTC5Wrap.set_laser_delays(
                Convert.ToInt32(Program.SystemContainer.SysPara.Laser_On_Delay * Program.SystemContainer.SysPara.Laser_Delay_Reference),    // laser on delay, in microseconds.
                Convert.ToUInt32(Program.SystemContainer.SysPara.Laser_Off_Delay * Program.SystemContainer.SysPara.Laser_Delay_Reference));   // laser off delay, in microseconds.
            // jump speed in bits per milliseconds.
            RTC5Wrap.set_jump_speed(Program.SystemContainer.SysPara.Jump_Speed * (double)Program.SystemContainer.SysPara.Rtc_Pos_Reference / 1000);
            // marking speed in bits per milliseconds.
            RTC5Wrap.set_mark_speed(Program.SystemContainer.SysPara.Mark_Speed * (double)Program.SystemContainer.SysPara.Rtc_Pos_Reference / 1000);
            RTC5Wrap.set_end_of_list();
            RTC5Wrap.execute_list(1u);

            //Pump source warming up ,wait!!!
            uint Busy;
            do
            {
                RTC5Wrap.get_status(out Busy, out uint Position);
            } while (Busy != 0U);
        }

        /// <summary>
        /// 启用刀具参数 Tyoe: false - Jump跳刀，true - Mark打标
        /// </summary>
        /// <param name="Scissors_Para"></param>
        /// <param name="Type"></param>
        /// <returns></returns>
        public bool Scissors_Para_Exe(Tech_Parameter Scissors_Para ,bool Type) 
        {
            //设置激光功率和频率
            decimal SetPEC = 0, SetPRF = 0;
            decimal ReadPEC = 0, ReadPRF = 0;
            int Count = 0;
            if (Type)
            {
                SetPEC = 0;
                SetPRF = Scissors_Para.PRF;
            }
            else
            {                
                SetPEC = Scissors_Para.PEC;
                SetPRF = Scissors_Para.PRF;
            }
            //设置功率和参数
            do
            {
                //读取PEC功率值
                Program.SystemContainer.Laser_Operation_00.Read("00", "55");
                ReadPEC = Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num / 10m;
                
                //读取PRF频率值
                Program.SystemContainer.Laser_Operation_00.Read("00", "21");
                ReadPRF = Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num / 1000m;

                //设置PEC功率值
                if (ReadPEC != SetPEC) Program.SystemContainer.Laser_Operation_00.Change_Pec(SetPEC);
                
                //设置PRF频率值
                if (ReadPRF != SetPRF) Program.SystemContainer.Laser_Operation_00.Write("00", "21", Program.SystemContainer.Laser_Operation_00.PRF_To_Str((UInt32)(SetPRF * 1000)));

                //超出重试次数
                Count++;
                if (Count >=5)
                {
                    return false;
                }
                //延时
                Thread.Sleep(100);
            } while ((ReadPEC != SetPEC) || (ReadPRF != SetPRF));
            

            //设置振镜参数
#if !DEBUG
            //  wait list List_No to be not busy
            //  load_list( List_No, 0) returns 1 if successful, otherwise 0
            //执行到POS 0
            do
            {

            }
            while (RTC5Wrap.load_list(1u, 0u) == 0);
            // Timing, delay and speed preset.
            // Transmit the following list commands to the list buffer.
            RTC5Wrap.set_start_list(1u);
            RTC5Wrap.set_laser_pulses(
                Convert.ToUInt32(Program.SystemContainer.SysPara.Laser_Half_Period * Program.SystemContainer.SysPara.Rtc_Period_Reference),    // half of the laser signal period.
                Convert.ToUInt32(Program.SystemContainer.SysPara.Laser_Pulse_Width * Program.SystemContainer.SysPara.Rtc_Period_Reference));  // pulse widths of signal LASER1.
            RTC5Wrap.set_scanner_delays(
                Convert.ToUInt32(Scissors_Para.Jump_Delay / Program.SystemContainer.SysPara.Scanner_Delay_Reference),    // jump delay, in 10 microseconds.
                Convert.ToUInt32(Scissors_Para.Mark_Delay / Program.SystemContainer.SysPara.Scanner_Delay_Reference),    // mark delay, in 10 microseconds.
                Convert.ToUInt32(Scissors_Para.Polygon_Delay / Program.SystemContainer.SysPara.Scanner_Delay_Reference));    // polygon delay, in 10 microseconds.
            RTC5Wrap.set_laser_delays(
                Convert.ToInt32(Scissors_Para.Laser_On_Delay * Program.SystemContainer.SysPara.Laser_Delay_Reference),    // laser on delay, in microseconds.
                Convert.ToUInt32(Scissors_Para.Laser_Off_Delay * Program.SystemContainer.SysPara.Laser_Delay_Reference));   // laser off delay, in microseconds.
            // jump speed in bits per milliseconds.
            RTC5Wrap.set_jump_speed(Scissors_Para.Jump_Speed * (double)Program.SystemContainer.SysPara.Rtc_Pos_Reference / 1000);
            // marking speed in bits per milliseconds.
            RTC5Wrap.set_mark_speed(Scissors_Para.Mark_Speed * (double)Program.SystemContainer.SysPara.Rtc_Pos_Reference / 1000);
            RTC5Wrap.set_end_of_list();
            RTC5Wrap.execute_list(1u);

            //Pump source warming up ,wait!!!
            uint Busy;
            do
            {
                RTC5Wrap.get_status(out Busy, out uint Position);
            } while (Busy != 0U);
#endif
            return true;

        }
       
        /// <summary>
        /// 释放Rtc5_dll
        /// </summary>
        public void Free()  
        {
            //释放Rtc5_dll
            RTC5Wrap.free_rtc5_dll();
        }
        /// <summary>
        /// 加载校准文件
        /// </summary>
        public bool Load_Correct_File(bool delaycorrect)
        {
            Free();
            Thread.Sleep(1000);
            Reset(delaycorrect);
            return true;
        }
        /********************************************************/
        /**以下是坐标系运动**/
        public List<Affinity_Matrix> affinity_Matrices=new List<Affinity_Matrix>();//校准数据集合
        
        /// <summary>
        /// 构造函数
        /// </summary>
        public RTC_Fun()
        {
            AffinityCountOK = false;//清除 仿射矫正矩阵数据匹配标志
        }

        /// <summary>
        /// 加载相关矫正参数
        /// </summary>
        public void Load_Affinity_Matrix()
        {
            AffinityCountOK = false;//清除 仿射矫正矩阵数据匹配标志
            //file name
            string File_Name = "Correct_File/Rtc_Affinity_Matrix_Three.xml";
            //file path
            string File_Path = @"./\Config/" + File_Name;
            //read file
            if (File.Exists(File_Path))
            {
                //获取矫正数据
                affinity_Matrices = new List<Affinity_Matrix>(Common_Collect.Reserialize<Affinity_Matrix>(File_Path));
                if (affinity_Matrices.Count != Program.SystemContainer.SysPara.Rtc_Affinity_Col_X * Program.SystemContainer.SysPara.Rtc_Affinity_Row_Y)
                {
                    affinity_Matrices = new List<Affinity_Matrix>();
                    LogInfo?.Invoke("Rtc Affinity 矫正文件文件不匹配！！！，禁止加工，请检查！");
                    return;
                }
                LogInfo?.Invoke(File_Path + "---矫正文件加载成功！！！,数据数量：" + affinity_Matrices.Count);
                AffinityCountOK = true;//置位 仿射矫正矩阵数据匹配标志
            }
            else
            {
                affinity_Matrices = new List<Affinity_Matrix>();
                MessageBox.Show(File_Path + "---矫正文件不存在，禁止加工，请检查！");
                LogInfo?.Invoke(File_Path + "---矫正文件不存在，禁止加工，请检查！");
            }
        }
        /// <summary>
        /// 加载相关矫正参数
        /// </summary>
        public bool Load_Affinity_MatrixBySpecificfile(string File_Path)
        {
            AffinityCountOK = false;//清除 仿射矫正矩阵数据匹配标志
            //read file
            if (File.Exists(File_Path))
            {
                //获取矫正数据
                affinity_Matrices = new List<Affinity_Matrix>(Common_Collect.Reserialize<Affinity_Matrix>(File_Path));
                if (affinity_Matrices.Count != Program.SystemContainer.SysPara.Rtc_Affinity_Col_X * Program.SystemContainer.SysPara.Rtc_Affinity_Row_Y)
                {
                    affinity_Matrices = new List<Affinity_Matrix>();
                    LogInfo?.Invoke("Rtc Affinity 矫正文件文件不匹配！！！，禁止加工，请检查！");
                    return false;
                }
                LogInfo?.Invoke(File_Path + "---矫正文件加载成功！！！,数据数量：" + affinity_Matrices.Count);
                AffinityCountOK = true;//清除 仿射矫正矩阵数据匹配标志
                return true;
            }
            else
            {
                affinity_Matrices = new List<Affinity_Matrix>();
                LogInfo?.Invoke(File_Path + "---矫正文件不存在，禁止加工，请检查！");
                return false;
            }
        }

        /// <summary>
        /// 关闭激光
        /// </summary>
        public void Close_Laser()
        {

            RTC5Wrap.disable_laser();
            //强制低电平
            RTC5Wrap.set_laser_control(0);
        }
        
        /// <summary>
        /// 打开激光
        /// </summary>
        public void Open_Laser()
        {
            RTC5Wrap.enable_laser();
            //强制高电平
            RTC5Wrap.set_laser_control(0x08);
        }

        /// <summary>
        /// 回到Home点
        /// </summary>
        public void Home()
        {
#if !DEBUG
            UInt32 List_No = 1u;
            //  wait list List_No to be not busy
            //  load_list( List_No, 0) returns 1 if successful, otherwise 0
            //  执行到POS 0
            do
            {

            }
            while (RTC5Wrap.load_list(List_No, 0u) == 0);
            // Transmit the following list commands to the list buffer.
            RTC5Wrap.set_start_list(List_No);
            //修正当前位置00
            RTC5Wrap.jump_abs(-Convert.ToInt32(Program.SystemContainer.SysPara.Rtc_Home.Y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(Program.SystemContainer.SysPara.Rtc_Home.X * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
            //设置List结束位置
            RTC5Wrap.set_end_of_list();
            //启动执行
            RTC5Wrap.execute_list(List_No);
            //Busy 运行等待结束
            uint Busy;
            do
            {
                RTC5Wrap.get_status(out Busy, out uint Position);
            } while (Busy != 0U);

            //移动光点
            RTC5Wrap.goto_xy(-Convert.ToInt32(Program.SystemContainer.SysPara.Rtc_Home.Y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(Program.SystemContainer.SysPara.Rtc_Home.X * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
#endif
        }

        /// <summary>
        /// 关闭激光，移动激光聚焦点至加工起始位置
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Rtc_Ready(decimal x, decimal y)
        {
            UInt32 List_No = 1u;
            //  wait list List_No to be not busy
            //  load_list( List_No, 0) returns 1 if successful, otherwise 0
            //  执行到POS 0
            do
            {

            }
            while (RTC5Wrap.load_list(List_No, 0u) == 0);
            // Transmit the following list commands to the list buffer.
            RTC5Wrap.set_start_list(List_No);
            //修正当前位置00
            RTC5Wrap.jump_abs(-Convert.ToInt32(y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(x * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
            //设置List结束位置
            RTC5Wrap.set_end_of_list();
            //启动执行
            RTC5Wrap.execute_list(List_No);
            //Busy 运行等待结束
            uint Busy;
            do
            {
                RTC5Wrap.get_status(out Busy, out uint Position);
            } while (Busy != 0U);
            //goto 指定点
            RTC5Wrap.goto_xy(-Convert.ToInt32(y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(x * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
        }
        
        /// <summary>
        /// X方向相对位移
        /// </summary>
        /// <param name="Distance"></param>
        /// <param name="Control"></param>
        /// <param name="List_No"></param>
        public void Inc_X(decimal Distance, UInt32 Control, UInt32 List_No)//距离、控制方式、list区域        
        {
            //  wait list List_No to be not busy
            //  load_list( List_No, 0) returns 1 if successful, otherwise 0
            //  执行到POS 0
            do
            {

            }
            while (RTC5Wrap.load_list(List_No, 0u) == 0);
            // Transmit the following list commands to the list buffer.
            RTC5Wrap.set_start_list(List_No);

            //生成数据            
            if (Control == 4)//jump_rel
            {
                RTC5Wrap.jump_rel(0, Convert.ToInt32(Distance * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
            }
            else if (Control == 6)//mark_rel
            {
                RTC5Wrap.mark_rel(0, Convert.ToInt32(Distance * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
            }
            //设置List结束位置
            RTC5Wrap.set_end_of_list();

            //启动执行
            RTC5Wrap.execute_list(List_No);

            //Busy 运行等待结束
            uint Busy;
            do
            {
                RTC5Wrap.get_status(out Busy, out uint Position);
            } while (Busy != 0U);
        }
        
        /// <summary>
        /// Y方向相对位移
        /// </summary>
        /// <param name="Distance"></param>
        /// <param name="Control"></param>
        /// <param name="List_No"></param>
        public void Inc_Y(decimal Distance, UInt32 Control, UInt32 List_No)//距离、控制方式、list区域        
        {
            //  wait list List_No to be not busy
            //  load_list( List_No, 0) returns 1 if successful, otherwise 0
            //  执行到POS 0
            do
            {

            }
            while (RTC5Wrap.load_list(List_No, 0u) == 0);
            // Transmit the following list commands to the list buffer.
            RTC5Wrap.set_start_list(List_No);

            //生成数据            
            if (Control == 4)//jump_rel
            {
                RTC5Wrap.jump_rel(-Convert.ToInt32(Distance * Program.SystemContainer.SysPara.Rtc_Pos_Reference), 0);
            }
            else if (Control == 6)//mark_rel
            {
                RTC5Wrap.mark_rel(-Convert.ToInt32(Distance * Program.SystemContainer.SysPara.Rtc_Pos_Reference), 0);
            }
            //设置List结束位置
            RTC5Wrap.set_end_of_list();

            //启动执行
            RTC5Wrap.execute_list(List_No);

            //Busy 运行等待结束
            uint Busy;
            do
            {
                RTC5Wrap.get_status(out Busy, out uint Position);
            } while (Busy != 0U);
        }
       
        /// <summary>
        /// XY方向绝对位移
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="Control"></param>
        /// <param name="List_No"></param>
        public void Abs_XY(decimal x,decimal y, UInt32 Control, UInt32 List_No)//距离、控制方式、list区域         
        {
            //  wait list List_No to be not busy
            //  load_list( List_No, 0) returns 1 if successful, otherwise 0
            //  执行到POS 0
            do
            {

            }
            while (RTC5Wrap.load_list(List_No, 0u) == 0);
            // Transmit the following list commands to the list buffer.
            RTC5Wrap.set_start_list(List_No);

            //生成数据            
            if (Control == 4)//jump_rel
            {
                RTC5Wrap.jump_rel(-Convert.ToInt32(y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(x * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
            }
            else if (Control == 6)//mark_rel
            {
                RTC5Wrap.mark_rel(-Convert.ToInt32(y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(x * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
            }
            //设置List结束位置
            RTC5Wrap.set_end_of_list();

            //启动执行
            RTC5Wrap.execute_list(List_No);

            //Busy 运行等待结束
            uint Busy;
            do
            {
                RTC5Wrap.get_status(out Busy, out uint Position);
            } while (Busy != 0U);
        }


        
        
        /// <summary>
        /// 振镜加工终止
        /// </summary>
        public void Draw_Stop()
        {
            //终止运行
            RTC5Wrap.stop_execution();
        }

        /// <summary>
        /// 执行Rtc坐标系矫正 Entity_Data Mark跳转 0 - 仿射矫正，1 - 桶形畸变，2 - 无仿射矫正
        /// </summary>
        /// <param name="Mark_Datas"></param>
        /// <param name="List_No"></param>
        /// <param name="Type"></param>
        public void Draw_Mark(Section_Entity_Data Mark_Datas, UInt32 List_No,int Type)
        {
#if !DEBUG
            //定义处理的变量
            Vector Tmp_Start = new Vector();
            Vector Tmp_End = new Vector();
            Vector Tmp_Center = new Vector();

            //  wait list List_No to be not busy
            //  load_list( List_No, 0) returns 1 if successful, otherwise 0
            //执行到POS 0
            do
            {

            }
            while (RTC5Wrap.load_list(List_No, 0u) == 0);
            //急停按钮按下终止运行
            if (Program.SystemContainer.IO.GlobalEMG)
            {
                Draw_Stop();
                return;
            }
            // Transmit the following list commands to the list buffer.
            RTC5Wrap.set_start_list(List_No);

            switch (Type)
            {
                case 0:
                    //仿射矫正写入
                    //ArcLines数据
                    if (Mark_Datas.ArcLine.Count > 0)
                    {
                        foreach (var o in Mark_Datas.ArcLine)
                        {
                            //进入起点
                            if (o.Count <= 0) continue;//如果该层没有ArcLine，则继续下一个
                            //Jump 至 起点
                            Tmp_Start = new Vector(Rtc_Cal_Data_Resolve.AFF_Correct_Rtc_Axes(o[0].Start_x, o[0].Start_y));
                            //初始Jump到启动点位
                            RTC5Wrap.jump_abs(Convert.ToInt32(-Tmp_Start.Y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(Tmp_Start.X * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                            //后续数据追加
                            foreach (var p in o)
                            {                                
                                //序列内部数据
                                //传入数据 1-直线，2-圆弧，3-整圆
                                if (p.Type == 2)//arc_abs 圆弧
                                {
                                    //获取圆心坐标
                                    Tmp_Center = new Vector(Rtc_Cal_Data_Resolve.AFF_Correct_Rtc_Axes(p.Center_x, p.Center_y));
                                    //推入缓存
                                    RTC5Wrap.arc_abs(Convert.ToInt32(-Tmp_Center.Y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(Tmp_Center.X * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToDouble(p.Angle));
                                }
                                else if (p.Type == 1)//mark_abs 直线
                                {
                                    //获取终点
                                    Tmp_End = new Vector(Rtc_Cal_Data_Resolve.AFF_Correct_Rtc_Axes(p.End_x, p.End_y));
                                    //推入缓存
                                    RTC5Wrap.mark_abs(Convert.ToInt32(-Tmp_End.Y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(Tmp_End.X * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                                }
                            }
                        }
                    }
                    //LWPolyline数据
                    if (Mark_Datas.LWPolyline.Count > 0)
                    {
                        foreach (var o in Mark_Datas.LWPolyline)
                        {
                            //进入起点
                            if (o.Count <= 0) continue;//如果该层没有LWPolyline，则继续下一个
                            //Jump 至 起点
                            Tmp_Start = new Vector(Rtc_Cal_Data_Resolve.AFF_Correct_Rtc_Axes(o[0].Start_x, o[0].Start_y));
                            //初始Jump到启动点位
                            RTC5Wrap.jump_abs(Convert.ToInt32(-Tmp_Start.Y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(Tmp_Start.X * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                            //后续数据追加
                            foreach (var p in o)
                            {
                                //传入数据 1-直线，2-圆弧，3-整圆
                                if (p.Type == 1)//mark_abs 直线
                                {
                                    //获取终点坐标
                                    Tmp_End = new Vector(Rtc_Cal_Data_Resolve.AFF_Correct_Rtc_Axes(p.End_x, p.End_y));
                                    //推入缓存
                                    RTC5Wrap.mark_abs(Convert.ToInt32(-Tmp_End.Y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(Tmp_End.X * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                                }
                            }
                        }
                    }
                    //Circle数据
                    if (Mark_Datas.Circle.Count > 0)
                    {
                        foreach (var p in Mark_Datas.Circle)
                        {
                            //Jump 至 起点
                            Tmp_Start = new Vector(Rtc_Cal_Data_Resolve.AFF_Correct_Rtc_Axes(p.Start_x, p.Start_y));
                            //初始Jump到启动点位
                            RTC5Wrap.jump_abs(Convert.ToInt32(-Tmp_Start.Y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(Tmp_Start.X * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                            //传入数据 1-直线，2-圆弧，3-整圆
                            if (p.Type == 3)//arc_abs 整圆
                            {
                                //获取圆心坐标
                                Tmp_Center = new Vector(Rtc_Cal_Data_Resolve.AFF_Correct_Rtc_Axes(p.Center_x, p.Center_y));
                                //推入控制器
                                RTC5Wrap.arc_abs(Convert.ToInt32(-Tmp_Center.Y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(Tmp_Center.X * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToDouble(p.Angle));
                            }
                        }
                    }
                    break;
                case 1:
                    //桶形畸变加工
                    //ArcLines数据
                    if (Mark_Datas.ArcLine.Count > 0)
                    {
                        foreach (var o in Mark_Datas.ArcLine)
                        {
                            //进入起点
                            if (o.Count <= 0) continue;//如果该层没有ArcLine，则继续下一个
                            //初始Jump到启动点位
                            RTC5Wrap.jump_abs(Convert.ToInt32(o[0].Start_x * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(o[0].Start_y * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                            //推入数据
                            foreach (var p in o)
                            {
                                //序列内部数据
                                if (p.Type == 1)//mark_abs 直线
                                {
                                    //推入缓存
                                    RTC5Wrap.mark_abs(Convert.ToInt32(p.End_x * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(p.End_y * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                                }
                            }
                        }
                    }
                    //Circle数据
                    if (Mark_Datas.Circle.Count > 0)
                    {
                        foreach (var p in Mark_Datas.Circle)
                        {
                            //初始Jump到启动点位
                            RTC5Wrap.jump_abs(Convert.ToInt32(p.Start_x * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(p.Start_y * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                            //传入数据 1-直线，2-圆弧，3-整圆
                            if (p.Type == 3)//arc_abs 整圆
                            {
                                RTC5Wrap.arc_abs(Convert.ToInt32(p.Center_x * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(p.Center_y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToDouble(p.Angle));
                            }
                        }
                    }
                    break;
                case 2:
                    //无补偿加工
                    //ArcLines数据
                    if (Mark_Datas.ArcLine.Count > 0)
                    {
                        foreach (var o in Mark_Datas.ArcLine)
                        {
                            //进入起点
                            if (o.Count <= 0) continue;//如果该层没有ArcLine，则继续下一个
                            //初始Jump到启动点位
                            RTC5Wrap.jump_abs(Convert.ToInt32(-o[0].Start_y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(o[0].Start_x * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                            //推入数据
                            foreach (var p in o)
                            {
                                //序列内部数据
                                //传入数据 1-直线，2-圆弧，3-整圆
                                if (p.Type == 2)//arc_abs 圆弧
                                {
                                    //推入缓存
                                    RTC5Wrap.arc_abs(Convert.ToInt32(-p.Center_y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(p.Center_x * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToDouble(p.Angle));
                                }
                                else if (p.Type == 1)//mark_abs 直线
                                {
                                    //推入缓存
                                    RTC5Wrap.mark_abs(Convert.ToInt32(-p.End_y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(p.End_x * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                                }
                            }
                        }
                    }
                    //LWPolyline数据
                    if (Mark_Datas.LWPolyline.Count > 0)
                    {
                        foreach (var o in Mark_Datas.LWPolyline)
                        {
                            //进入起点
                            if (o.Count <= 0) continue;//如果该层没有ArcLine，则继续下一个
                            //初始Jump到启动点位
                            RTC5Wrap.jump_abs(Convert.ToInt32(-o[0].Start_y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(o[0].Start_x * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                            //推入数据
                            foreach (var p in o)
                            {
                                //传入数据 1-直线，2-圆弧，3-整圆
                                if (p.Type == 1)//mark_abs 直线
                                {
                                    //推入缓存
                                    RTC5Wrap.mark_abs(Convert.ToInt32(-p.End_y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(p.End_x * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                                }
                            }
                        }
                    }
                    //Circle数据
                    if (Mark_Datas.Circle.Count > 0)
                    {
                        foreach (var p in Mark_Datas.Circle)
                        {
                            //初始Jump到启动点位
                            RTC5Wrap.jump_abs(Convert.ToInt32(-p.Start_y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(p.Start_x * Program.SystemContainer.SysPara.Rtc_Pos_Reference));

                            //传入数据 1-直线，2-圆弧，3-整圆
                            if (p.Type == 3)//arc_abs 整圆
                            {
                                RTC5Wrap.arc_abs(Convert.ToInt32(-p.Center_y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(p.Center_x * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToDouble(p.Angle));
                            }
                        }
                    }
                    break;
                default:
                    break;
            }

            //结束Jump到启动点位
            //RTC5Wrap.jump_abs(0, 0);

            //设置List结束位置
            RTC5Wrap.set_end_of_list();
            //启动执行
            RTC5Wrap.execute_list(1u);
            //Busy 运行等待结束
            uint Busy;
            do
            {
                //急停按钮按下终止运行
                if (Program.SystemContainer.IO.GlobalEMG)
                {
                    Draw_Stop();
                    return;
                }
                RTC5Wrap.get_status(out Busy, out uint Position);
                Thread.Sleep(50);
            } while (Busy != 0U);
#endif
        }
        /// <summary>
        /// 执行Rtc坐标系矫正 Entity_Data Mark跳转 0 - 仿射矫正，1 - 桶形畸变，2 - 无仿射矫正
        /// </summary>
        /// <param name="Mark_Datas"></param>
        /// <param name="List_No"></param>
        /// <param name="Type"></param>
        public void Draw_Mark(SectionData Mark_Datas, UInt32 List_No, int Type)
        {
#if !DEBUG
            //定义处理的变量
            Vector Tmp_Start = new Vector();
            Vector Tmp_End = new Vector();
            Vector Tmp_Center = new Vector();

            //  wait list List_No to be not busy
            //  load_list( List_No, 0) returns 1 if successful, otherwise 0
            //执行到POS 0
            do
            {

            }
            while (RTC5Wrap.load_list(List_No, 0u) == 0);
            //急停按钮按下终止运行
            if (Program.SystemContainer.IO.GlobalEMG)
            {
                Draw_Stop();
                return;
            }
            // Transmit the following list commands to the list buffer.
            RTC5Wrap.set_start_list(List_No);

            switch (Type)
            {
                case 0:
                    //仿射矫正写入
                    //ArcLines数据
                    if (Mark_Datas.ArcLine.Count > 0)
                    {
                        foreach (var o in Mark_Datas.ArcLine)
                        {
                            //进入起点
                            if (o.Count <= 0) continue;//如果该层没有ArcLine，则继续下一个
                            //Jump 至 起点
                            Tmp_Start = new Vector(Rtc_Cal_Data_Resolve.AFF_Correct_Rtc_Axes(o[0].Start_x, o[0].Start_y));
                            //初始Jump到启动点位
                            RTC5Wrap.jump_abs(Convert.ToInt32(-Tmp_Start.Y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(Tmp_Start.X * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                            //后续数据追加
                            foreach (var p in o)
                            {
                                //序列内部数据
                                //传入数据 1-直线，2-圆弧，3-整圆
                                if (p.Type == 2)//arc_abs 圆弧
                                {
                                    //获取圆心坐标
                                    Tmp_Center = new Vector(Rtc_Cal_Data_Resolve.AFF_Correct_Rtc_Axes(p.Center_x, p.Center_y));
                                    //推入缓存
                                    RTC5Wrap.arc_abs(Convert.ToInt32(-Tmp_Center.Y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(Tmp_Center.X * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToDouble(p.Angle));
                                }
                                else if (p.Type == 1)//mark_abs 直线
                                {
                                    //获取终点
                                    Tmp_End = new Vector(Rtc_Cal_Data_Resolve.AFF_Correct_Rtc_Axes(p.End_x, p.End_y));
                                    //推入缓存
                                    RTC5Wrap.mark_abs(Convert.ToInt32(-Tmp_End.Y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(Tmp_End.X * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                                }
                            }
                        }
                    }
                    //LWPolyline数据
                    if (Mark_Datas.LWPolyline.Count > 0)
                    {
                        foreach (var o in Mark_Datas.LWPolyline)
                        {
                            //进入起点
                            if (o.Count <= 0) continue;//如果该层没有LWPolyline，则继续下一个
                            //Jump 至 起点
                            Tmp_Start = new Vector(Rtc_Cal_Data_Resolve.AFF_Correct_Rtc_Axes(o[0].Start_x, o[0].Start_y));
                            //初始Jump到启动点位
                            RTC5Wrap.jump_abs(Convert.ToInt32(-Tmp_Start.Y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(Tmp_Start.X * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                            //后续数据追加
                            foreach (var p in o)
                            {
                                //传入数据 1-直线，2-圆弧，3-整圆
                                if (p.Type == 1)//mark_abs 直线
                                {
                                    //获取终点坐标
                                    Tmp_End = new Vector(Rtc_Cal_Data_Resolve.AFF_Correct_Rtc_Axes(p.End_x, p.End_y));
                                    //推入缓存
                                    RTC5Wrap.mark_abs(Convert.ToInt32(-Tmp_End.Y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(Tmp_End.X * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                                }
                            }
                        }
                    }
                    //Circle数据
                    if (Mark_Datas.Circle.Count > 0)
                    {
                        foreach (var p in Mark_Datas.Circle)
                        {
                            //Jump 至 起点
                            Tmp_Start = new Vector(Rtc_Cal_Data_Resolve.AFF_Correct_Rtc_Axes(p.Start_x, p.Start_y));
                            //初始Jump到启动点位
                            RTC5Wrap.jump_abs(Convert.ToInt32(-Tmp_Start.Y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(Tmp_Start.X * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                            //传入数据 1-直线，2-圆弧，3-整圆
                            if (p.Type == 3)//arc_abs 整圆
                            {
                                //获取圆心坐标
                                Tmp_Center = new Vector(Rtc_Cal_Data_Resolve.AFF_Correct_Rtc_Axes(p.Center_x, p.Center_y));
                                //推入控制器
                                RTC5Wrap.arc_abs(Convert.ToInt32(-Tmp_Center.Y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(Tmp_Center.X * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToDouble(p.Angle));
                            }
                        }
                    }
                    break;
                case 1:
                    //桶形畸变加工
                    //ArcLines数据
                    if (Mark_Datas.ArcLine.Count > 0)
                    {
                        foreach (var o in Mark_Datas.ArcLine)
                        {
                            //进入起点
                            if (o.Count <= 0) continue;//如果该层没有ArcLine，则继续下一个
                            //初始Jump到启动点位
                            RTC5Wrap.jump_abs(Convert.ToInt32(o[0].Start_x * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(o[0].Start_y * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                            //推入数据
                            foreach (var p in o)
                            {
                                //序列内部数据
                                if (p.Type == 1)//mark_abs 直线
                                {
                                    //推入缓存
                                    RTC5Wrap.mark_abs(Convert.ToInt32(p.End_x * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(p.End_y * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                                }
                            }
                        }
                    }
                    //Circle数据
                    if (Mark_Datas.Circle.Count > 0)
                    {
                        foreach (var p in Mark_Datas.Circle)
                        {
                            //初始Jump到启动点位
                            RTC5Wrap.jump_abs(Convert.ToInt32(p.Start_x * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(p.Start_y * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                            //传入数据 1-直线，2-圆弧，3-整圆
                            if (p.Type == 3)//arc_abs 整圆
                            {
                                RTC5Wrap.arc_abs(Convert.ToInt32(p.Center_x * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(p.Center_y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToDouble(p.Angle));
                            }
                        }
                    }
                    break;
                case 2:
                    //无补偿加工
                    //ArcLines数据
                    if (Mark_Datas.ArcLine.Count > 0)
                    {
                        foreach (var o in Mark_Datas.ArcLine)
                        {
                            //进入起点
                            if (o.Count <= 0) continue;//如果该层没有ArcLine，则继续下一个
                            //初始Jump到启动点位
                            RTC5Wrap.jump_abs(Convert.ToInt32(-o[0].Start_y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(o[0].Start_x * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                            //推入数据
                            foreach (var p in o)
                            {
                                //序列内部数据
                                //传入数据 1-直线，2-圆弧，3-整圆
                                if (p.Type == 2)//arc_abs 圆弧
                                {
                                    //推入缓存
                                    RTC5Wrap.arc_abs(Convert.ToInt32(-p.Center_y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(p.Center_x * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToDouble(p.Angle));
                                }
                                else if (p.Type == 1)//mark_abs 直线
                                {
                                    //推入缓存
                                    RTC5Wrap.mark_abs(Convert.ToInt32(-p.End_y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(p.End_x * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                                }
                            }
                        }
                    }
                    //LWPolyline数据
                    if (Mark_Datas.LWPolyline.Count > 0)
                    {
                        foreach (var o in Mark_Datas.LWPolyline)
                        {
                            //进入起点
                            if (o.Count <= 0) continue;//如果该层没有ArcLine，则继续下一个
                            //初始Jump到启动点位
                            RTC5Wrap.jump_abs(Convert.ToInt32(-o[0].Start_y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(o[0].Start_x * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                            //推入数据
                            foreach (var p in o)
                            {
                                //传入数据 1-直线，2-圆弧，3-整圆
                                if (p.Type == 1)//mark_abs 直线
                                {
                                    //推入缓存
                                    RTC5Wrap.mark_abs(Convert.ToInt32(-p.End_y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(p.End_x * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                                }
                            }
                        }
                    }
                    //Circle数据
                    if (Mark_Datas.Circle.Count > 0)
                    {
                        foreach (var p in Mark_Datas.Circle)
                        {
                            //初始Jump到启动点位
                            RTC5Wrap.jump_abs(Convert.ToInt32(-p.Start_y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(p.Start_x * Program.SystemContainer.SysPara.Rtc_Pos_Reference));

                            //传入数据 1-直线，2-圆弧，3-整圆
                            if (p.Type == 3)//arc_abs 整圆
                            {
                                RTC5Wrap.arc_abs(Convert.ToInt32(-p.Center_y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(p.Center_x * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToDouble(p.Angle));
                            }
                        }
                    }
                    break;
                default:
                    break;
            }

            //结束Jump到启动点位
            //RTC5Wrap.jump_abs(0, 0);

            //设置List结束位置
            RTC5Wrap.set_end_of_list();
            //启动执行
            RTC5Wrap.execute_list(1u);
            //Busy 运行等待结束
            uint Busy;
            do
            {
                //急停按钮按下终止运行
                if (Program.SystemContainer.IO.GlobalEMG)
                {
                    Draw_Stop();
                    return;
                }
                RTC5Wrap.get_status(out Busy, out uint Position);
                Thread.Sleep(50);
            } while (Busy != 0U);
#endif
        }
    }
}

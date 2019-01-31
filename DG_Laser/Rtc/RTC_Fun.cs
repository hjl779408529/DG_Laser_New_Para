﻿using System;
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
            //停止正在执行的Rtc
            //  If the DefaultCard has been used previously by another application 
            //  a list might still be running. This would prevent load_program_file
            //  and load_correction_file from being executed.
            RTC5Wrap.stop_execution();

            //加载Correct文件
            Rtc_Return = RTC5Wrap.load_correction_file(
                "./Config/Cor_1to1.ct5",
                1u,
                2u
                );
            if (Rtc_Return != 0u)
            {
                LogErr?.Invoke("加载Cor_1to1.ct5出错", Rtc_Return);
            }
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
        public bool Scissors_Para_Exe(Tech_Parameter Scissors_Para) 
        {
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
        public List<Double_Fit_Data> Fit_Matrices = new List<Double_Fit_Data>();//校准数据集合 
        /// <summary>
        /// 构造函数
        /// </summary>
        public RTC_Fun()
        {
            
        }
        /// <summary>
        /// 加载相关矫正参数
        /// </summary>
        public void Load_Affinity_Matrix()
        {
            //file name
            string File_Name = "";
            if (Program.SystemContainer.SysPara.Rtc_Affinity_Type == 1)
            {
                File_Name = "Correct_File/Rtc_Affinity_Matrix_All.xml";
            }
            else if (Program.SystemContainer.SysPara.Rtc_Affinity_Type == 2)
            {
                File_Name = "Correct_File/Rtc_Line_Fit_Data.csv";
            }
            else
            {
                File_Name = "Correct_File/Rtc_Affinity_Matrix_Three.xml";
            }
            //file path
            string File_Path = @"./\Config/" + File_Name;
            //read file
            if (Program.SystemContainer.SysPara.Rtc_Affinity_Type == 2)
            {
                if (File.Exists(File_Path))
                {                  
                    Fit_Matrices = new List<Double_Fit_Data>(CSV_RW.DataTable_Double_Fit_Data(CSV_RW.OpenCSV(File_Path)));
                    LogInfo?.Invoke("Rtc 线性 矫正文件加载成功！！！,数据数量：" + Fit_Matrices.Count);
                }
                else
                {
                    Fit_Matrices = new List<Double_Fit_Data>();
                    MessageBox.Show("Rtc 线性 矫正文件不存在，禁止加工，请检查！");
                    LogInfo?.Invoke("Rtc 线性 矫正文件不存在，禁止加工，请检查！");
                }
            }
            else
            {
                if (File.Exists(File_Path))
                {
                    //获取矫正数据
                    if (Program.SystemContainer.SysPara.Rtc_Affinity_Type == 1)//点阵匹配
                    {
                        affinity_Matrices = new List<Affinity_Matrix>(Common_Collect.Reserialize<Affinity_Matrix>(File_Name));
                        LogInfo?.Invoke("Rtc Affinity_ALL 矫正文件加载成功！！！,数据数量：" + affinity_Matrices.Count);
                    }
                    else
                    {
                        affinity_Matrices = new List<Affinity_Matrix>(Common_Collect.Reserialize<Affinity_Matrix>(File_Name));
                        LogInfo?.Invoke("Rtc Affinity_Three 矫正文件加载成功！！！,数据数量：" + affinity_Matrices.Count);
                    }
                }
                else
                {
                    affinity_Matrices = new List<Affinity_Matrix>();
                    MessageBox.Show("Rtc Affinity_ALL/Affinity_Three 矫正文件不存在，禁止加工，请检查！");
                    LogInfo?.Invoke("Rtc Affinity_ALL/Affinity_Three 矫正文件不存在，禁止加工，请检查！");
                }
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
        /// 执行 经坐标系匹配的数据
        /// </summary>
        /// <param name="Rtc_Datas"></param>
        /// <param name="List_No"></param>
        public void Draw(List<Interpolation_Data> Rtc_Datas,UInt32 List_No)
        {
            //  wait list List_No to be not busy
            //  load_list( List_No, 0) returns 1 if successful, otherwise 0
            //  执行到POS 0
            do
            {

            }
            while (RTC5Wrap.load_list(List_No, 0u) == 0);
            // Transmit the following list commands to the list buffer.
            //RTC5Wrap.set_start_list(List_No);

            //初始Jump到启动点位
            RTC5Wrap.jump_abs(Convert.ToInt32(-Rtc_Datas[0].Rtc_y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(Rtc_Datas[0].Rtc_x * Program.SystemContainer.SysPara.Rtc_Pos_Reference));

            //生成数据
            foreach (var o in Rtc_Datas)
            {
                if (o.Type == 11)//arc_abs 绝对圆弧
                {
                    RTC5Wrap.arc_abs(Convert.ToInt32(-o.Center_y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(o.Center_x * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToDouble(o.Angle));
                }
                else if (o.Type == 12)//arc_rel
                {
                    RTC5Wrap.arc_rel(Convert.ToInt32(-o.Center_y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(o.Center_x * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToDouble(o.Angle));
                }
                else if (o.Type == 13)//jump_abs
                {
                    RTC5Wrap.jump_abs(Convert.ToInt32(-o.End_y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(o.End_x * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                }
                else if (o.Type == 14)//jump_rel
                {
                    RTC5Wrap.jump_rel(Convert.ToInt32(-o.End_y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(o.End_x * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                }
                else if (o.Type == 15)//mark_abs
                {
                    RTC5Wrap.mark_abs(Convert.ToInt32(-o.End_y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(o.End_x * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                }
                else if (o.Type == 16)//mark_rel
                {
                    RTC5Wrap.mark_rel(Convert.ToInt32(-o.End_y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(o.End_x * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                }
            }
            //结束Jump到启动点位
            //RTC5Wrap.jump_abs(0,0);

            //设置List结束位置
            RTC5Wrap.set_end_of_list();

            //启动执行
            RTC5Wrap.execute_list(1u);

            //Busy 运行等待结束
            uint Busy;
            do
            {
                RTC5Wrap.get_status(out Busy, out uint Position);
            } while (Busy != 0U);
        }


        /// <summary>
        /// 执行 未经任何矫正的数据，包括坐标系匹配，用于原始振镜坐标系输出，进行桶形矫正
        /// </summary>
        /// <param name="Rtc_Datas"></param>
        /// <param name="List_No"></param>
        public void Draw_Cal(List<Interpolation_Data> Rtc_Datas, UInt32 List_No) 
        {
            //  wait list List_No to be not busy
            //  load_list( List_No, 0) returns 1 if successful, otherwise 0
            //  执行到POS 0
            do
            {

            }
            while (RTC5Wrap.load_list(List_No, 0u) == 0);
            // Transmit the following list commands to the list buffer.
            //RTC5Wrap.set_start_list(List_No);

            //初始Jump到启动点位
            RTC5Wrap.jump_abs(Convert.ToInt32(Rtc_Datas[0].Rtc_x * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(Rtc_Datas[0].Rtc_y * Program.SystemContainer.SysPara.Rtc_Pos_Reference));

            //生成数据
            foreach (var o in Rtc_Datas)
            {
                if (o.Type == 11)//arc_abs 绝对圆弧
                {
                    RTC5Wrap.arc_abs(Convert.ToInt32(o.Center_x * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(o.Center_y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToDouble(o.Angle));
                }
                else if (o.Type == 12)//arc_rel
                {
                    RTC5Wrap.arc_rel(Convert.ToInt32(o.Center_x * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(o.Center_y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToDouble(o.Angle));
                }
                else if (o.Type == 13)//jump_abs
                {
                    RTC5Wrap.jump_abs(Convert.ToInt32(o.End_x * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(o.End_y * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                }
                else if (o.Type == 14)//jump_rel
                {
                    RTC5Wrap.jump_rel(Convert.ToInt32(o.End_x * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(o.End_y * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                }
                else if (o.Type == 15)//mark_abs
                {
                    RTC5Wrap.mark_abs(Convert.ToInt32(o.End_x * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(o.End_y * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                }
                else if (o.Type == 16)//mark_rel
                {
                    RTC5Wrap.mark_rel(Convert.ToInt32(o.End_x * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(o.End_y * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                }
            }
            //结束Jump到启动点位
            //RTC5Wrap.jump_abs(0,0);

            //设置List结束位置
            RTC5Wrap.set_end_of_list();

            //启动执行
            RTC5Wrap.execute_list(1u);

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
        /// Mark 执行 经坐标系匹配的数据
        /// </summary>
        /// <param name="Rtc_Datas"></param>
        /// <param name="List_No"></param>
        public void Draw_Mark_Axis(List<Interpolation_Data> Rtc_Datas, UInt32 List_No)
        {
            //  wait list List_No to be not busy
            //  load_list( List_No, 0) returns 1 if successful, otherwise 0
            //  执行到POS 0
            do
            {

            }
            while (RTC5Wrap.load_list(List_No, 0u) == 0);
            // Transmit the following list commands to the list buffer.
            //RTC5Wrap.set_start_list(List_No);

            //初始Jump到启动点位
            RTC5Wrap.jump_abs(Convert.ToInt32(-Rtc_Datas[0].Rtc_y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(Rtc_Datas[0].Rtc_x * Program.SystemContainer.SysPara.Rtc_Pos_Reference));

            //生成数据
            foreach (var o in Rtc_Datas)
            {
                if (o.Type == 11)//arc_abs 绝对圆弧
                {
                    RTC5Wrap.arc_abs(Convert.ToInt32(-o.Center_y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(o.Center_x * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToDouble(o.Angle));
                }
                else if (o.Type == 12)//arc_rel
                {
                    RTC5Wrap.arc_rel(Convert.ToInt32(-o.Center_y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(o.Center_x * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToDouble(o.Angle));
                }
                else if (o.Type == 13)//jump_abs
                {
                    RTC5Wrap.jump_abs(Convert.ToInt32(-o.End_y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(o.End_x * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                }
                else if (o.Type == 14)//jump_rel
                {
                    RTC5Wrap.jump_rel(Convert.ToInt32(-o.End_y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(o.End_x * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                }
                else if (o.Type == 15)//mark_abs
                {
                    RTC5Wrap.mark_abs(Convert.ToInt32(-o.End_y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(o.End_x * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                }
                else if (o.Type == 16)//mark_rel
                {
                    RTC5Wrap.mark_rel(Convert.ToInt32(-o.End_y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(o.End_x * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                }
            }
            //结束Jump到启动点位
            //RTC5Wrap.jump_abs(0,0);

            //设置List结束位置
            RTC5Wrap.set_end_of_list();

            //启动执行
            RTC5Wrap.execute_list(1u);

            //Busy 运行等待结束
            uint Busy;
            do
            {
                RTC5Wrap.get_status(out Busy, out uint Position);
            } while (Busy != 0U);
        }

        /// <summary>
        /// Mark 执行 未经任何矫正的数据，包括坐标系匹配，用于原始振镜坐标系输出，进行桶形矫正图形加工
        /// </summary>
        /// <param name="Rtc_Datas"></param>
        /// <param name="List_No"></param>
        public void Draw_Mark_Origin(List<Interpolation_Data> Rtc_Datas, UInt32 List_No)
        {
            //  wait list List_No to be not busy
            //  load_list( List_No, 0) returns 1 if successful, otherwise 0
            //  执行到POS 0
            do
            {

            }
            while (RTC5Wrap.load_list(List_No, 0u) == 0);
            // Transmit the following list commands to the list buffer.
            //RTC5Wrap.set_start_list(List_No);

            //初始Jump到启动点位
            RTC5Wrap.jump_abs(Convert.ToInt32(Rtc_Datas[0].Rtc_x * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(Rtc_Datas[0].Rtc_y * Program.SystemContainer.SysPara.Rtc_Pos_Reference));

            //生成数据
            foreach (var o in Rtc_Datas)
            {
                if (o.Type == 11)//arc_abs 绝对圆弧
                {
                    RTC5Wrap.arc_abs(Convert.ToInt32(o.Center_x * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(o.Center_y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToDouble(o.Angle));
                }
                else if (o.Type == 12)//arc_rel
                {
                    RTC5Wrap.arc_rel(Convert.ToInt32(o.Center_x * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(o.Center_y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToDouble(o.Angle));
                }
                else if (o.Type == 13)//jump_abs
                {
                    RTC5Wrap.jump_abs(Convert.ToInt32(o.End_x * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(o.End_y * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                }
                else if (o.Type == 14)//jump_rel
                {
                    RTC5Wrap.jump_rel(Convert.ToInt32(o.End_x * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(o.End_y * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                }
                else if (o.Type == 15)//mark_abs
                {
                    RTC5Wrap.mark_abs(Convert.ToInt32(o.End_x * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(o.End_y * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                }
                else if (o.Type == 16)//mark_rel
                {
                    RTC5Wrap.mark_rel(Convert.ToInt32(o.End_x * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(o.End_y * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                }
            }
            //结束Jump到启动点位
            //RTC5Wrap.jump_abs(0,0);

            //设置List结束位置
            RTC5Wrap.set_end_of_list();

            //启动执行
            RTC5Wrap.execute_list(1u);

            //Busy 运行等待结束
            uint Busy;
            do
            {
                RTC5Wrap.get_status(out Busy, out uint Position);
            } while (Busy != 0U);
        }

        /// <summary>
        /// 执行 数据采样矫正后的数据 矩阵补偿
        /// </summary>
        /// <param name="Rtc_Datas"></param>
        /// <param name="List_No"></param>
        public void Draw_Mark_Matrix(List<Interpolation_Data> Rtc_Datas, UInt32 List_No) 
        {
            //定义处理的变量
            Vector Tmp_Point = new Vector();
            decimal Tmp_R0_X = 0.0m;
            decimal Tmp_R0_Y = 0.0m;
            decimal Tmp_End_X = 0.0m;
            decimal Tmp_End_Y = 0.0m;
            decimal Tmp_Center_X = 0.0m;
            decimal Tmp_Center_Y = 0.0m;
#if !DEBUG
            //  wait list List_No to be not busy
            //  load_list( List_No, 0) returns 1 if successful, otherwise 0
            //执行到POS 0
            do
            {

            }
            while (RTC5Wrap.load_list(List_No, 0u) == 0);
            // Transmit the following list commands to the list buffer.
            RTC5Wrap.set_start_list(List_No);
#endif
            if (Program.SystemContainer.SysPara.Rtc_Affinity_Type == 2)
            {
                Tmp_Point = new Vector(Rtc_Cal_Data_Resolve.Get_Line_Fit_Coordinate(Rtc_Datas[0].Rtc_x, Rtc_Datas[0].Rtc_y, Fit_Matrices));
                Tmp_R0_X = Tmp_Point.X;
                Tmp_R0_Y = Tmp_Point.Y;
            }
            else
            {
                //获取数据落点
                Tmp_Point = new Vector(Rtc_Cal_Data_Resolve.Get_Affinity_Point(0, Rtc_Datas[0].Rtc_x, Rtc_Datas[0].Rtc_y, affinity_Matrices));
                Tmp_R0_X = Tmp_Point.X;
                Tmp_R0_Y = Tmp_Point.Y;
            }           
            
#if !DEBUG
            //初始Jump到启动点位
            RTC5Wrap.jump_abs(Convert.ToInt32(-Tmp_R0_Y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(Tmp_R0_X * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
#endif
            //生成数据
            foreach (var o in Rtc_Datas)
            {

                if (Program.SystemContainer.SysPara.Rtc_Affinity_Type == 2)
                {
                    Tmp_Point = new Vector(Rtc_Cal_Data_Resolve.Get_Line_Fit_Coordinate(o.End_x, o.End_y, Fit_Matrices));
                    Tmp_End_X = Tmp_Point.X;
                    Tmp_End_Y = Tmp_Point.Y;
                    Tmp_Point = new Vector(Rtc_Cal_Data_Resolve.Get_Line_Fit_Coordinate(o.Center_x, o.Center_y, Fit_Matrices));
                    Tmp_Center_X = Tmp_Point.X;
                    Tmp_Center_Y = Tmp_Point.Y;
                }
                else
                {

                    Tmp_Point = new Vector(Rtc_Cal_Data_Resolve.Get_Affinity_Point(0, o.End_x, o.End_y, affinity_Matrices));
                    Tmp_End_X = Tmp_Point.X;
                    Tmp_End_Y = Tmp_Point.Y;
                    Tmp_Point = new Vector(Rtc_Cal_Data_Resolve.Get_Affinity_Point(0, o.Center_x, o.Center_y, affinity_Matrices));
                    Tmp_Center_X = Tmp_Point.X;
                    Tmp_Center_Y = Tmp_Point.Y;
                }
#if !DEBUG
                if (o.Type == 11)//arc_abs 绝对圆弧
                {
                    RTC5Wrap.arc_abs(Convert.ToInt32(-Tmp_Center_Y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(Tmp_Center_X * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToDouble(o.Angle));
                }
                else if (o.Type == 12)//arc_rel
                {
                    RTC5Wrap.arc_rel(Convert.ToInt32(-Tmp_Center_Y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(Tmp_Center_X * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToDouble(o.Angle));
                }
                else if (o.Type == 13)//jump_abs
                {
                    RTC5Wrap.jump_abs(Convert.ToInt32(-Tmp_End_Y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(Tmp_End_X * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                }
                else if (o.Type == 14)//jump_rel
                {
                    RTC5Wrap.jump_rel(Convert.ToInt32(-Tmp_End_Y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(Tmp_End_X * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                }
                else if (o.Type == 15)//mark_abs
                {
                    RTC5Wrap.mark_abs(Convert.ToInt32(-Tmp_End_Y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(Tmp_End_X * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                }
                else if (o.Type == 16)//mark_rel
                {
                    RTC5Wrap.mark_rel(Convert.ToInt32(-Tmp_End_Y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(Tmp_End_X * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                }
#endif
            }
#if !DEBUG
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
                RTC5Wrap.get_status(out Busy, out uint Position);                
            } while (Busy != 0U);
#endif
        }
        /// <summary>
        /// 执行Rtc坐标系矫正后的数据
        /// </summary>
        /// <param name="Rtc_Datas"></param>
        /// <param name="List_No"></param>
        public void Draw_Mark_Angle(List<Interpolation_Data> Rtc_Datas, UInt32 List_No)
        {
            //定义处理的变量
            Vector Tmp_Point = new Vector();
            decimal Tmp_R0_X = 0.0m;
            decimal Tmp_R0_Y = 0.0m;
            decimal Tmp_End_X = 0.0m;
            decimal Tmp_End_Y = 0.0m;
            decimal Tmp_Center_X = 0.0m;
            decimal Tmp_Center_Y = 0.0m;
#if !DEBUG
            //  wait list List_No to be not busy
            //  load_list( List_No, 0) returns 1 if successful, otherwise 0
            //执行到POS 0
            do
            {

            }
            while (RTC5Wrap.load_list(List_No, 0u) == 0);
            // Transmit the following list commands to the list buffer.
            RTC5Wrap.set_start_list(List_No);
#endif
            //Tmp_Point = new Vector(Rtc_Cal_Data_Resolve.Correct_Rtc_Axes(Rtc_Datas[0].Rtc_x, Rtc_Datas[0].Rtc_y));
            Tmp_Point = new Vector(Rtc_Cal_Data_Resolve.Angle_Correct_Rtc_Axes(Rtc_Datas[0].Rtc_x, Rtc_Datas[0].Rtc_y));
            Tmp_R0_X = Tmp_Point.X;
            Tmp_R0_Y = Tmp_Point.Y;

#if !DEBUG
            //初始Jump到启动点位
            RTC5Wrap.jump_abs(Convert.ToInt32(-Tmp_R0_Y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(Tmp_R0_X * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
            
#endif
            //生成数据
            foreach (var o in Rtc_Datas)
            {
                //Tmp_Point = new Vector(Rtc_Cal_Data_Resolve.Correct_Rtc_Axes(o.End_x, o.End_y));
                Tmp_Point = new Vector(Rtc_Cal_Data_Resolve.Angle_Correct_Rtc_Axes(o.End_x, o.End_y));
                Tmp_End_X = Tmp_Point.X;
                Tmp_End_Y = Tmp_Point.Y;
                //Tmp_Point = new Vector(Rtc_Cal_Data_Resolve.Correct_Rtc_Axes(o.Center_x, o.Center_y));
                Tmp_Point = new Vector(Rtc_Cal_Data_Resolve.Angle_Correct_Rtc_Axes(o.Center_x, o.Center_y));
                Tmp_Center_X = Tmp_Point.X;
                Tmp_Center_Y = Tmp_Point.Y;
#if !DEBUG
                if (o.Type == 11)//arc_abs 绝对圆弧
                {
                    RTC5Wrap.arc_abs(Convert.ToInt32(-Tmp_Center_Y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(Tmp_Center_X * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToDouble(o.Angle));
                }
                else if (o.Type == 12)//arc_rel
                {
                    RTC5Wrap.arc_rel(Convert.ToInt32(-Tmp_Center_Y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(Tmp_Center_X * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToDouble(o.Angle));
                }
                else if (o.Type == 13)//jump_abs
                {
                    RTC5Wrap.jump_abs(Convert.ToInt32(-Tmp_End_Y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(Tmp_End_X * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                }
                else if (o.Type == 14)//jump_rel
                {
                    RTC5Wrap.jump_rel(Convert.ToInt32(-Tmp_End_Y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(Tmp_End_X * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                }
                else if (o.Type == 15)//mark_abs
                {
                    RTC5Wrap.mark_abs(Convert.ToInt32(-Tmp_End_Y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(Tmp_End_X * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                }
                else if (o.Type == 16)//mark_rel
                {
                    RTC5Wrap.mark_rel(Convert.ToInt32(-Tmp_End_Y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(Tmp_End_X * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                }
#endif
            }
#if !DEBUG
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
                RTC5Wrap.get_status(out Busy, out uint Position);
            } while (Busy != 0U);
#endif
        }
        /// <summary>
        /// 执行Rtc坐标系矫正后的数据
        /// </summary>
        /// <param name="Rtc_Datas"></param>
        /// <param name="List_No"></param>
        public void Draw_Mark_AFF(List<Interpolation_Data> Rtc_Datas, UInt32 List_No)
        {
            //定义处理的变量
            Vector Tmp_Point = new Vector();
            decimal Tmp_R0_X = 0.0m;
            decimal Tmp_R0_Y = 0.0m;
            decimal Tmp_End_X = 0.0m;
            decimal Tmp_End_Y = 0.0m;
            decimal Tmp_Center_X = 0.0m;
            decimal Tmp_Center_Y = 0.0m;
#if !DEBUG
            //  wait list List_No to be not busy
            //  load_list( List_No, 0) returns 1 if successful, otherwise 0
            //执行到POS 0
            do
            {

            }
            while (RTC5Wrap.load_list(List_No, 0u) == 0);
            // Transmit the following list commands to the list buffer.
            RTC5Wrap.set_start_list(List_No);
#endif
            Tmp_Point = new Vector(Rtc_Cal_Data_Resolve.AFF_Correct_Rtc_Axes(Rtc_Datas[0].Rtc_x, Rtc_Datas[0].Rtc_y));
            Tmp_R0_X = Tmp_Point.X;
            Tmp_R0_Y = Tmp_Point.Y;

#if !DEBUG
            //初始Jump到启动点位
            RTC5Wrap.jump_abs(Convert.ToInt32(-Tmp_R0_Y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(Tmp_R0_X * Program.SystemContainer.SysPara.Rtc_Pos_Reference));

#endif
            //生成数据
            foreach (var o in Rtc_Datas)
            {
                Tmp_Point = new Vector(Rtc_Cal_Data_Resolve.AFF_Correct_Rtc_Axes(o.End_x, o.End_y));
                Tmp_End_X = Tmp_Point.X;
                Tmp_End_Y = Tmp_Point.Y;
                Tmp_Point = new Vector(Rtc_Cal_Data_Resolve.AFF_Correct_Rtc_Axes(o.Center_x, o.Center_y));
                Tmp_Center_X = Tmp_Point.X;
                Tmp_Center_Y = Tmp_Point.Y;
#if !DEBUG
                if (o.Type == 11)//arc_abs 绝对圆弧
                {
                    RTC5Wrap.arc_abs(Convert.ToInt32(-Tmp_Center_Y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(Tmp_Center_X * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToDouble(o.Angle));
                }
                else if (o.Type == 12)//arc_rel
                {
                    RTC5Wrap.arc_rel(Convert.ToInt32(-Tmp_Center_Y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(Tmp_Center_X * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToDouble(o.Angle));
                }
                else if (o.Type == 13)//jump_abs
                {
                    RTC5Wrap.jump_abs(Convert.ToInt32(-Tmp_End_Y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(Tmp_End_X * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                }
                else if (o.Type == 14)//jump_rel
                {
                    RTC5Wrap.jump_rel(Convert.ToInt32(-Tmp_End_Y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(Tmp_End_X * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                }
                else if (o.Type == 15)//mark_abs
                {
                    RTC5Wrap.mark_abs(Convert.ToInt32(-Tmp_End_Y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(Tmp_End_X * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                }
                else if (o.Type == 16)//mark_rel
                {
                    RTC5Wrap.mark_rel(Convert.ToInt32(-Tmp_End_Y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(Tmp_End_X * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                }
#endif
            }
#if !DEBUG
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
                RTC5Wrap.get_status(out Busy, out uint Position);
            } while (Busy != 0U);
#endif
        }
        /// <summary>
        /// jump跳刀
        /// </summary>
        /// <param name="Rtc_Datas"></param>
        /// <param name="List_No"></param>
        public void Draw_Jump(List<Interpolation_Data> Rtc_Datas, UInt32 List_No)
        {
#if !DEBUG
            //  wait list List_No to be not busy
            //  load_list( List_No, 0) returns 1 if successful, otherwise 0
            //执行到POS 0
            do
            {

            }
            while (RTC5Wrap.load_list(List_No, 0u) == 0);
            // Transmit the following list commands to the list buffer.
            RTC5Wrap.set_start_list(List_No);
#endif


            //生成数据
            foreach (var o in Rtc_Datas)
            {

#if !DEBUG
                if (o.Type == 13)//jump_abs
                {
                    RTC5Wrap.jump_abs(Convert.ToInt32(-o.End_y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(o.End_x * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                }
                else if (o.Type == 14)//jump_rel
                {
                    RTC5Wrap.jump_rel(Convert.ToInt32(-o.End_y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(o.End_x * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                }
#endif
            }
#if !DEBUG
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
                RTC5Wrap.get_status(out Busy, out uint Position);
            } while (Busy != 0U);
#endif
        }

        /// <summary>
        /// Jump 执行 经坐标系匹配的数据
        /// </summary>
        /// <param name="Rtc_Datas"></param>
        /// <param name="List_No"></param>
        public void Draw_Jump_Axis(List<Interpolation_Data> Rtc_Datas, UInt32 List_No)
        {
#if !DEBUG
            //  wait list List_No to be not busy
            //  load_list( List_No, 0) returns 1 if successful, otherwise 0
            //执行到POS 0
            do
            {

            }
            while (RTC5Wrap.load_list(List_No, 0u) == 0);
            // Transmit the following list commands to the list buffer.
            RTC5Wrap.set_start_list(List_No);
#endif


            //生成数据
            foreach (var o in Rtc_Datas)
            {

#if !DEBUG
                if (o.Type == 13)//jump_abs
                {
                    RTC5Wrap.jump_abs(Convert.ToInt32(-o.End_y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(o.End_x * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                }
                else if (o.Type == 14)//jump_rel
                {
                    RTC5Wrap.jump_rel(Convert.ToInt32(-o.End_y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(o.End_x * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                }
#endif
            }
#if !DEBUG
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
                RTC5Wrap.get_status(out Busy, out uint Position);
            } while (Busy != 0U);
#endif
        }

        /// <summary>
        /// jump执行 未经任何矫正的数据，包括坐标系匹配，用于原始振镜坐标系输出，进行桶形矫正图形加工
        /// </summary>
        /// <param name="Rtc_Datas"></param>
        /// <param name="List_No"></param>
        public void Draw_Jump_Origin(List<Interpolation_Data> Rtc_Datas, UInt32 List_No)
        {
#if !DEBUG
            //  wait list List_No to be not busy
            //  load_list( List_No, 0) returns 1 if successful, otherwise 0
            //执行到POS 0
            do
            {

            }
            while (RTC5Wrap.load_list(List_No, 0u) == 0);
            // Transmit the following list commands to the list buffer.
            RTC5Wrap.set_start_list(List_No);
#endif


            //生成数据
            foreach (var o in Rtc_Datas)
            {

#if !DEBUG
                if (o.Type == 13)//jump_abs
                {
                    RTC5Wrap.jump_abs(Convert.ToInt32(o.End_x * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(o.End_y * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                }
                else if (o.Type == 14)//jump_rel
                {
                    RTC5Wrap.jump_rel(Convert.ToInt32(o.End_x * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(o.End_y * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                }
#endif
            }
#if !DEBUG
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
                RTC5Wrap.get_status(out Busy, out uint Position);
            } while (Busy != 0U);
#endif
        }
        /// <summary>
        /// jump跳刀
        /// </summary>
        /// <param name="Rtc_Datas"></param>
        /// <param name="List_No"></param>
        public void Draw_Jump_Angle(List<Interpolation_Data> Rtc_Datas, UInt32 List_No)
        {
            //定义处理的变量
            Vector Tmp_Point = new Vector();
            decimal Tmp_End_X = 0.0m;
            decimal Tmp_End_Y = 0.0m;
#if !DEBUG
            //  wait list List_No to be not busy
            //  load_list( List_No, 0) returns 1 if successful, otherwise 0
            //执行到POS 0
            do
            {

            }
            while (RTC5Wrap.load_list(List_No, 0u) == 0);
            // Transmit the following list commands to the list buffer.
            RTC5Wrap.set_start_list(List_No);
#endif


            //生成数据
            foreach (var o in Rtc_Datas)
            {
                //Tmp_Point = new Vector(Rtc_Cal_Data_Resolve.Correct_Rtc_Axes(o.End_x, o.End_y));
                Tmp_Point = new Vector(Rtc_Cal_Data_Resolve.Angle_Correct_Rtc_Axes(o.End_x, o.End_y));
                Tmp_End_X = Tmp_Point.X;
                Tmp_End_Y = Tmp_Point.Y;
#if !DEBUG
                if (o.Type == 13)//jump_abs
                {
                    RTC5Wrap.jump_abs(Convert.ToInt32(-Tmp_End_Y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(Tmp_End_X * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                }
                else if (o.Type == 14)//jump_rel
                {
                    RTC5Wrap.jump_rel(Convert.ToInt32(-Tmp_End_Y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(Tmp_End_X * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                }
#endif
            }
#if !DEBUG
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
                RTC5Wrap.get_status(out Busy, out uint Position);
            } while (Busy != 0U);
#endif
        }
        /// <summary>
        /// jump跳刀
        /// </summary>
        /// <param name="Rtc_Datas"></param>
        /// <param name="List_No"></param>
        public void Draw_Jump_AFF(List<Interpolation_Data> Rtc_Datas, UInt32 List_No)
        {
            //定义处理的变量
            Vector Tmp_Point = new Vector();
            decimal Tmp_End_X = 0.0m;
            decimal Tmp_End_Y = 0.0m;
#if !DEBUG
            //  wait list List_No to be not busy
            //  load_list( List_No, 0) returns 1 if successful, otherwise 0
            //执行到POS 0
            do
            {

            }
            while (RTC5Wrap.load_list(List_No, 0u) == 0);
            // Transmit the following list commands to the list buffer.
            RTC5Wrap.set_start_list(List_No);
#endif


            //生成数据
            foreach (var o in Rtc_Datas)
            {
                Tmp_Point = new Vector(Rtc_Cal_Data_Resolve.AFF_Correct_Rtc_Axes(o.End_x, o.End_y));
                Tmp_End_X = Tmp_Point.X;
                Tmp_End_Y = Tmp_Point.Y;
#if !DEBUG
                if (o.Type == 13)//jump_abs
                {
                    RTC5Wrap.jump_abs(Convert.ToInt32(-Tmp_End_Y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(Tmp_End_X * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                }
                else if (o.Type == 14)//jump_rel
                {
                    RTC5Wrap.jump_rel(Convert.ToInt32(-Tmp_End_Y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(Tmp_End_X * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                }
#endif
            }
#if !DEBUG

            //设置List结束位置
            RTC5Wrap.set_end_of_list();

            //启动执行
            RTC5Wrap.execute_list(1u);

            //Busy 运行等待结束
            uint Busy;
            do
            {
                RTC5Wrap.get_status(out Busy, out uint Position);
            } while (Busy != 0U);
#endif
        }
        /// <summary>
        /// jump跳刀
        /// </summary>
        /// <param name="Rtc_Datas"></param>
        /// <param name="List_No"></param>
        public void Draw_Jump_Matrix(List<Interpolation_Data> Rtc_Datas, UInt32 List_No)
        {
            //定义处理的变量
            Vector Tmp_Point = new Vector();
            decimal Tmp_End_X = 0.0m;
            decimal Tmp_End_Y = 0.0m;
#if !DEBUG
            //  wait list List_No to be not busy
            //  load_list( List_No, 0) returns 1 if successful, otherwise 0
            //执行到POS 0
            do
            {

            }
            while (RTC5Wrap.load_list(List_No, 0u) == 0);
            // Transmit the following list commands to the list buffer.
            RTC5Wrap.set_start_list(List_No);
#endif


            //生成数据
            foreach (var o in Rtc_Datas)
            {
                if (Program.SystemContainer.SysPara.Rtc_Affinity_Type == 2)
                {
                    //获取数据落点
                    Tmp_Point = new Vector(Rtc_Cal_Data_Resolve.Get_Line_Fit_Coordinate(o.End_x, o.End_y, Fit_Matrices));
                    Tmp_End_X = Tmp_Point.X;
                    Tmp_End_Y = Tmp_Point.Y;
                }
                else
                {
                    //获取数据落点
                    Tmp_Point = new Vector(Rtc_Cal_Data_Resolve.Get_Affinity_Point(0, o.End_x, o.End_y, affinity_Matrices));
                    Tmp_End_X = Tmp_Point.X;
                    Tmp_End_Y = Tmp_Point.Y;
                }
#if !DEBUG
                if (o.Type == 13)//jump_abs
                {
                    RTC5Wrap.jump_abs(Convert.ToInt32(-Tmp_End_Y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(Tmp_End_X * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                }
                else if (o.Type == 14)//jump_rel
                {
                    RTC5Wrap.jump_rel(Convert.ToInt32(-Tmp_End_Y * Program.SystemContainer.SysPara.Rtc_Pos_Reference), Convert.ToInt32(Tmp_End_X * Program.SystemContainer.SysPara.Rtc_Pos_Reference));
                }
#endif
            }
#if !DEBUG

            //设置List结束位置
            RTC5Wrap.set_end_of_list();

            //启动执行
            RTC5Wrap.execute_list(1u);

            //Busy 运行等待结束
            uint Busy;
            do
            {
                RTC5Wrap.get_status(out Busy, out uint Position);
            } while (Busy != 0U);
#endif
        }
    }
}
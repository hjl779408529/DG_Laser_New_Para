using GTS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace DG_Laser
{
    class IO
    {
        public bool EXI1, EXI2, EXI3, EXI4, EXI5, EXI6, EXI7; //定义输入变量
        public bool EXO1, EXO2, EXO3, EXO4, EXO5, EXO6, EXO7, EXO8, EXO9, EXO10, EXO11, EXO12; //定义输出变量
        public bool Axis01_Limit_Up, Axis01_Limit_Down, Axis01_Home, Axis01_Alarm, Axis01_Alarm_Cl, Axis01_MC_Err, Axis01_EN, Axis01_Busy, Axis01_IO_Stop, Axis01_IO_EMG, Axis01_Motor_Posed, Axis01_Upper_Posed;//定义轴1的BOOL变量
        public bool Axis02_Limit_Up, Axis02_Limit_Down, Axis02_Home, Axis02_Alarm, Axis02_Alarm_Cl, Axis02_MC_Err, Axis02_EN, Axis02_Busy, Axis02_IO_Stop, Axis02_IO_EMG, Axis02_Motor_Posed, Axis02_Upper_Posed;//定义轴2的BOOL变量
        public short Cyc_control, Blow_control, Lamp_control, Yellow_lamp, Green_lamp, Red_lamp, Beeze_Control, Button1_Lamp, Button2_Lamp;//定义气缸、吹气、照明、灯塔黄、灯塔绿、灯塔红、蜂鸣、启动按钮1灯、
        public short Axis01_Home_Ex0_Control, Axis02_Home_Ex0_Control;//定义轴1、2回零触发

        //定义读取通用输出、输入的IO值
        public int Exi_16bit, Exo_16bit;
        //定义Axis状态值、Clock值 
        public int Axis01_Sta, Axis02_Sta;
        public uint Axis01_Clk, Axis02_Clk;
        //定义原点开关状态
        public int Axis_Home_Sta;
        //定义到位信号状态
        public int Axis_Posed_Sta;
        //定义报警清除输出状态
        public int Axis_Clear_Sta;

        //定义当前位置
        public double Axis01_prfPos, Axis02_prfPos;
        //定义实际位置
        public double Axis01_encPos, Axis02_encPos;
        //定义当前速度
        public double Axis01_vel, Axis02_vel;
        //定义当前加减速度
        public double Axis01_acc, Axis01_dcc, Axis02_acc, Axis02_dcc;

        //定义运动模式
        public int Axis01_mode, Axis02_mode;

        //定义1s脉冲Flag
        public bool Timer_1s_Flag;
        //定义GTS函数调用返回值
        public short Gts_Return;
        //定义Gts X/Y轴回零标志
        public bool Gts_Home_Flag;

        //清除上位机回零完成标志
        private ValueChangeEvent Axis01_Homed_Status = new ValueChangeEvent();
        private ValueChangeEvent Axis02_Homed_Status = new ValueChangeEvent();

        //构造函数
        public IO() 
        {
            Axis01_Homed_Status.Greater_Than_Change += Axis01_Homed_Change;
            Axis02_Homed_Status.Greater_Than_Change += Axis02_Homed_Change;
        }
        /// <summary>
        /// 刷新状态
        /// </summary>
        public void Refresh_IO(object sender, ElapsedEventArgs e)
        {
            //读取通用输出的值
            Gts_Return = MC.GT_GetDo(12, out Exo_16bit);
            //读取通用输入的值
            Gts_Return = MC.GT_GetDi(4, out Exi_16bit);
            //读取Axis01状态
            Gts_Return = MC.GT_GetSts(1, out Axis01_Sta, 1, out Axis01_Clk);
            //读取Axis02状态
            Gts_Return = MC.GT_GetSts(2, out Axis02_Sta, 1, out Axis02_Clk);
            //读取Axis_Home_Sta状态
            Gts_Return = MC.GT_GetDi(3, out Axis_Home_Sta);
            //读取Axis_Posed_Sta状态
            Gts_Return = MC.GT_GetDi(5, out Axis_Posed_Sta);
            //读取Axis_Clear_Sta状态
            Gts_Return = MC.GT_GetDo(11, out Axis_Clear_Sta);

            //读取规划位置
            Gts_Return = MC.GT_GetPrfPos(1, out Axis01_prfPos, 1, out Axis01_Clk);
            Gts_Return = MC.GT_GetPrfPos(2, out Axis02_prfPos, 1, out Axis02_Clk);

            //读取实际位置
            Gts_Return = MC.GT_GetAxisEncPos(1, out Axis01_encPos, 1, out Axis01_Clk);
            Gts_Return = MC.GT_GetAxisEncPos(2, out Axis02_encPos, 1, out Axis02_Clk);

            //读取当前速度
            Gts_Return = MC.GT_GetVel(1, out Axis01_vel);
            Gts_Return = MC.GT_GetVel(2, out Axis02_vel);

            //读取当前加减速
            Gts_Return = MC.GT_GetAxisPrfAcc(1, out Axis01_acc, 1, out Axis01_Clk);
            Gts_Return = MC.GT_GetAxisPrfAcc(1, out Axis01_dcc, 1, out Axis01_Clk);
            Gts_Return = MC.GT_GetAxisPrfAcc(2, out Axis02_acc, 1, out Axis02_Clk);
            Gts_Return = MC.GT_GetAxisPrfAcc(2, out Axis02_dcc, 1, out Axis02_Clk);

            //读取轴运动模式
            Gts_Return = MC.GT_GetPrfMode(1, out Axis01_mode, 1, out Axis01_Clk);
            Gts_Return = MC.GT_GetPrfMode(2, out Axis02_mode, 1, out Axis02_Clk);

            //刷新数值至相应的IO
            //刷新EXI
            EXI1 = (Exi_16bit & (1 << 1)) == 0;// 急停开关
            EXI2 = (Exi_16bit & (1 << 2)) == 0;// 除尘气缸伸出传感器
            EXI3 = (Exi_16bit & (1 << 3)) == 0;// 除尘气缸退回传感器
            EXI4 = (Exi_16bit & (1 << 4)) == 0;// 左门禁传感器
            EXI5 = (Exi_16bit & (1 << 5)) == 0;// 右门禁传感器
            EXI6 = (Exi_16bit & (1 << 6)) == 0;// 启动按钮1
            EXI7 = (Exi_16bit & (1 << 7)) == 0;// 启动按钮1 

            //输出按钮灯
            if (EXI6) { Button1_Lamp = 1; } else { Button1_Lamp = 0; };
            if (EXI7) { Button2_Lamp = 1; } else { Button2_Lamp = 0; };   

            //输出照明灯
            //if ((!EXI4) || (!EXI5)) { Lamp_control = 1; } else { Lamp_control = 0; };

            //刷新EXO
            EXO1 = (Exo_16bit & (1 << 1)) == 0;// 三色灯塔黄
            EXO2 = (Exo_16bit & (1 << 2)) == 0;// 三色灯塔绿
            EXO3 = (Exo_16bit & (1 << 3)) == 0;// 三色灯塔红
            EXO4 = (Exo_16bit & (1 << 4)) == 0;// 蜂鸣器
            EXO5 = (Exo_16bit & (1 << 5)) == 0;// 除尘气缸伸出
            EXO6 = (Exo_16bit & (1 << 6)) == 0;// 除尘气缸退回
            EXO7 = (Exo_16bit & (1 << 7)) == 0;// 吹气打开
            EXO8 = (Exo_16bit & (1 << 8)) == 0;// 照明灯
            EXO9 = (Exo_16bit & (1 << 9)) == 0;// 启动按钮1灯
            EXO10 = (Exo_16bit & (1 << 10)) == 0;// 启动按钮2灯 
            EXO11 = (Exo_16bit & (1 << 11)) == 0;// X轴回零触发
            EXO12 = (Exo_16bit & (1 << 12)) == 0;// Y轴回零触发

            //刷新Axis01 状态
            Axis01_Limit_Up = (Axis01_Sta & (1 << 5)) != 0;// Axis01轴正限位
            Axis01_Limit_Down = (Axis01_Sta & (1 << 6)) != 0;// Axis01轴负限位
            Axis01_Home = (Axis_Home_Sta & 0x01) != 0;// Axis01轴原点
            Axis01_Alarm = (Axis01_Sta & (1 << 1)) != 0;// Axis01轴报警
            Axis01_Alarm_Cl = (Axis_Clear_Sta & 0x01) == 0;//Axis01轴报警清除
            Axis01_MC_Err = (Axis01_Sta & (1 << 4)) != 0;// Axis01轴板卡报警(跟随误差越限)
            Axis01_EN = (Axis01_Sta & (1 << 9)) != 0;// Axis01轴使能
            Axis01_Busy = (Axis01_Sta & (1 << 10)) != 0;// Axis01轴输出中
            Axis01_IO_Stop = (Axis01_Sta & (1 << 7)) != 0;// Axis01轴IO停止
            Axis01_IO_EMG = (Axis01_Sta & (1 << 8)) != 0;// Axis01轴IO急停
            Axis01_Motor_Posed = (Axis_Posed_Sta & 0x01) != 0;// Axis01轴 电机到位
            Axis01_Upper_Posed = (Axis01_Sta & (1 << 11)) != 0;// Axis01轴 上位机到位

            //刷新Axis02 状态
            Axis02_Limit_Up = (Axis02_Sta & (1 << 5)) != 0;// Axis02轴正限位
            Axis02_Limit_Down = (Axis02_Sta & (1 << 6)) != 0;// Axis02轴负限位
            Axis02_Home = (Axis_Home_Sta & (1 << 1)) != 0;// Axis02轴原点
            Axis02_Alarm = (Axis02_Sta & (1 << 1)) != 0;// Axis02轴报警
            Axis02_Alarm_Cl = (Axis_Clear_Sta & (1 << 1)) == 0;//Axis02轴报警清除
            Axis02_MC_Err = (Axis02_Sta & (1 << 4)) != 0;// Axis02轴板卡报警(跟随误差越限)
            Axis02_EN = (Axis02_Sta & (1 << 9)) != 0;// Axis02轴使能
            Axis02_Busy = (Axis02_Sta & (1 << 10)) != 0;// Axis02轴输出中
            Axis02_IO_Stop = (Axis02_Sta & (1 << 7)) != 0;// Axis02轴IO停止
            Axis02_IO_EMG = (Axis02_Sta & (1 << 8)) != 0;// Axis02轴IO急停
            Axis02_Motor_Posed = (Axis_Posed_Sta & (1 << 1)) != 0; ;// Axis02轴 电机到位
            Axis02_Upper_Posed = (Axis02_Sta & (1 << 11)) != 0;// Axis02轴 上位机到位

            //刷新轴原点状态
            Gts_Home_Flag = !(Axis01_Limit_Up || Axis01_Limit_Down || Axis01_Alarm || Axis01_MC_Err || Axis01_IO_EMG) && Axis01_Home && Program.SystemContainer.GTS_Fun.Axis01_Homed && !(Axis02_Limit_Up || Axis02_Limit_Down || Axis02_Alarm || Axis02_MC_Err || Axis02_IO_EMG) && Axis02_Home && Program.SystemContainer.GTS_Fun.Axis02_Homed;//任意（轴限位、报警、使能关闭、急停），致使原点标志丢失
            //轴1
            if ((Axis01_Limit_Up || Axis01_Limit_Down || Axis01_Alarm || Axis01_MC_Err || Axis01_IO_EMG) && Program.SystemContainer.GTS_Fun.Axis01_Homed)
                Axis01_Homed_Status.Variable = 1;
            else
                Axis01_Homed_Status.Variable = 0;
            //轴2
            if ((Axis02_Limit_Up || Axis02_Limit_Down || Axis02_Alarm || Axis02_MC_Err || Axis02_IO_EMG) && Program.SystemContainer.GTS_Fun.Axis02_Homed)
                Axis02_Homed_Status.Variable = 1;
            else
                Axis02_Homed_Status.Variable = 0;


            //轴1回零触发            
            if (Axis01_Home_Ex0_Control == 1)//轴1回零
            {
                Gts_Return = MC.GT_SetDoBit(12, 12, 0);
            }
            else
            {
                Gts_Return = MC.GT_SetDoBit(12, 12, 1);
            }
            //轴2回零触发  
            if (Axis02_Home_Ex0_Control == 1)//轴2回零
            {
                Gts_Return = MC.GT_SetDoBit(12, 13, 0);
            }
            else
            {
                Gts_Return = MC.GT_SetDoBit(12, 13, 1);
            }
            //输出控制 0-输出，1-关闭输出
            //Cyc_control, Blow_control, Lamp_control;//定义气缸、吹气、照明控制字
            //气缸控制
            if (Cyc_control == 1)//气缸打开
            {
                Gts_Return = MC.GT_SetDoBit(12, 6, 0);
                Gts_Return = MC.GT_SetDoBit(12, 7, 1);
            }
            else
            {
                Gts_Return = MC.GT_SetDoBit(12, 6, 1);
                Gts_Return = MC.GT_SetDoBit(12, 7, 0);
            }
            //吹气控制
            if (Blow_control == 1)//吹气打开
            {
                Gts_Return = MC.GT_SetDoBit(12, 8, 0);
            }
            else
            {
                Gts_Return = MC.GT_SetDoBit(12, 8, 1);
            }
            //照明控制
            if (Lamp_control == 1)//照明打开
            {
                Gts_Return = MC.GT_SetDoBit(12, 9, 0);
            }
            else
            {
                Gts_Return = MC.GT_SetDoBit(12, 9, 1);
            }
            //Yellow_lamp,Green_lamp,Red_lamp,Beeze_Control,Button1_Lamp, Button2_Lamp;//定义灯塔黄、灯塔绿、灯塔红、蜂鸣控制字
            //灯塔黄控制
            if (Yellow_lamp == 1)
            {
                Gts_Return = MC.GT_SetDoBit(12, 2, 0);
            }
            else
            {
                Gts_Return = MC.GT_SetDoBit(12, 2, 1);
            }
            //灯塔绿控制
            if (Green_lamp == 1)
            {
                Gts_Return = MC.GT_SetDoBit(12, 3, 0);
            }
            else
            {
                Gts_Return = MC.GT_SetDoBit(12, 3, 1);
            }
            //灯塔红控制
            if (Red_lamp == 1)
            {
                Gts_Return = MC.GT_SetDoBit(12, 4, 0);
            }
            else
            {
                Gts_Return = MC.GT_SetDoBit(12, 4, 1);
            }
            //蜂鸣器控制
            if (Beeze_Control == 1)
            {
                if (Timer_1s_Flag)
                {
                    Gts_Return = MC.GT_SetDoBit(12, 5, 0);
                }
                else
                {
                    Gts_Return = MC.GT_SetDoBit(12, 5, 1);
                }
            }
            else
            {
                Gts_Return = MC.GT_SetDoBit(12, 5, 1);
            }
            //Button1_Lamp, Button2_Lamp;//定义启动按钮1灯、启动按钮2灯控制字
            //启动按钮1灯
            if (Button1_Lamp == 1)
            {
                Gts_Return = MC.GT_SetDoBit(12, 10, 0);
            }
            else
            {
                Gts_Return = MC.GT_SetDoBit(12, 10, 1);
            }
            //启动按钮2灯
            if (Button2_Lamp == 1)
            {
                Gts_Return = MC.GT_SetDoBit(12, 11, 0);
            }
            else
            {
                Gts_Return = MC.GT_SetDoBit(12, 11, 1);
            }

            //刷新双启按钮状态
            if (EXI4 && EXI5 && EXI6 && EXI7 && Gts_Home_Flag)
                MainForm.Start_Button.Variable = 1;
            else
                MainForm.Start_Button.Variable = 0;

        }

        private void Axis01_Homed_Change()
        {
            if (Program.SystemContainer.GTS_Fun.Axis01_Homed) Program.SystemContainer.GTS_Fun.Axis01_Homed = false;
        }
        private void Axis02_Homed_Change()
        {
            if (Program.SystemContainer.GTS_Fun.Axis02_Homed) Program.SystemContainer.GTS_Fun.Axis02_Homed = false;
        }
        public void Timer_1s(object sender, ElapsedEventArgs e)
        {
            Timer_1s_Flag = !Timer_1s_Flag;
        }
        /// <summary>
        /// 状态清除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Clear(object sender, EventArgs e)
        {
            Timer_1s_Flag = false;
        }
    }
}

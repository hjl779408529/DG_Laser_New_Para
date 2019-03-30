using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using GTS;

namespace DG_Laser
{
     
    //复位
    class GTS_Fun 
    {
        public bool Axis01_Homed = false;
        public bool Axis02_Homed = false;
        //定义GTS函数调用返回值
        private short Gts_Return;
        //接收数据数组
        public event LogErrshort LogErr;
        public event LogInfo LogInfo;
        public event Work RefreshPoint;//更新虚拟平台坐标
        //仿射矫正矩阵数据匹配标志
        public bool AffinityCountOK = false;
        /// <summary>
        /// 构造函数
        /// </summary>
        public GTS_Fun()
        {
            //轴回零完成信号
            Axis01_Homed = false;
            Axis02_Homed = false;
            
            AffinityCountOK = false;//清除 仿射矫正矩阵数据匹配标志
        }
        /// <summary>
        /// Gts控制卡初始化
        /// </summary>
        public void Reset()
        {           
            //复位运动控制器
            Gts_Return = MC.GT_Reset();
            LogErr?.Invoke("Gts_Initial---GT_Reset", Gts_Return);
            //延时
            Thread.Sleep(200);
            //配置运动控制器
            Gts_Return = MC.GT_LoadConfig("Axis.cfg");
            LogErr?.Invoke("Gts_Initial--GT_LoadConfig", Gts_Return);
            //清除各轴的报警和限位
            Gts_Return = MC.GT_ClrSts(1, 4);
            LogErr?.Invoke("Gts_Initial--清除各轴的报警和限位", Gts_Return);
            //轴使能
            Gts_Return = MC.GT_AxisOn(1);
            Gts_Return = MC.GT_AxisOn(2);
            //延时
            Thread.Sleep(200);

            //设置X轴误差带
            Gts_Return = MC.GT_SetAxisBand(1, Program.SystemContainer.SysPara.Axis_X_Band, 4 * Program.SystemContainer.SysPara.Axis_X_Time);//20-0.1um,4*2-250us
            LogErr?.Invoke("X轴到位误差带", Gts_Return);

            //设置Y轴误差带
            Gts_Return = MC.GT_SetAxisBand(2, Program.SystemContainer.SysPara.Axis_Y_Band, 4 * Program.SystemContainer.SysPara.Axis_Y_Time);//20-0.1um,4*2-250us
            LogErr?.Invoke("Y轴到位误差带", Gts_Return);

            //设置X轴软件限位
            Gts_Return = MC.GT_SetSoftLimit(1, Program.SystemContainer.SysPara.AxisXSoftLimitPositive * (int)Program.SystemContainer.SysPara.Gts_Pos_reference, Program.SystemContainer.SysPara.AxisXSoftLimitNegative * (int)Program.SystemContainer.SysPara.Gts_Pos_reference);
            LogErr?.Invoke("设置X轴软件限位", Gts_Return);
            
            //设置Y轴软件限位
            Gts_Return = MC.GT_SetSoftLimit(2, Program.SystemContainer.SysPara.AxisYSoftLimitPositive * (int)Program.SystemContainer.SysPara.Gts_Pos_reference, Program.SystemContainer.SysPara.AxisYSoftLimitNegative * (int)Program.SystemContainer.SysPara.Gts_Pos_reference);
            LogErr?.Invoke("设置Y轴软件限位", Gts_Return);

            //轴回零完成信号
            Axis01_Homed = false;
            Axis02_Homed = false;
    }

        /// <summary>
        /// 释放Gts控制卡
        /// </summary>
        public void Free()
        {
            //关闭运动控制器
            Gts_Return = MC.GT_Close();
            LogErr?.Invoke("Gts_Initial---GT_Close", Gts_Return);
        }

        /// <summary>
        /// 清除轴状态
        /// </summary>
        /// <param name="axis"></param>
        public void StatusClear(short axis)
        {
            Gts_Return = MC.GT_ClrSts(axis, 1);
            LogErr?.Invoke("GT_ClrSts", Gts_Return);
        }

        /// <summary>
        /// 清除轴位置
        /// </summary>
        /// <param name="axis"></param>
        public void PosClear(short axis)
        {
            //清除轴规划位置、实际位置
            Gts_Return = MC.GT_ZeroPos(axis, 1);
            LogErr?.Invoke("Menu_5_Axis_Handle_Gts_return_GT_ZeroPos", Gts_Return);
        }
        /// <summary>
        /// Axis ON
        /// </summary>
        /// <param name="axis"></param>
        public void AxisON(short axis)
        {
            Gts_Return = MC.GT_AxisOn(axis);
            LogErr?.Invoke("GT_AxisOn", Gts_Return);
        }

        /// <summary>
        /// Axis OFF
        /// </summary>
        /// <param name="axis"></param>
        public void AxisOFF(short axis)
        {
            Gts_Return = MC.GT_AxisOff(axis);
            LogErr?.Invoke("GT_AxisOff", Gts_Return); 
        }

        /// <summary>
        /// 清除轴报警 ON
        /// </summary>
        /// <param name="axis"></param>
        public void AlarmClearON(short axis)
        {
            //使能Alarm信号输出
            Gts_Return = MC.GT_SetDoBit(11, axis, 0);
            LogErr?.Invoke("GT_SetDoBit ON", Gts_Return);
        }

        /// <summary>
        /// 清除轴报警 OFF
        /// </summary>
        /// <param name="axis"></param>
        public void AlarmClearOFF(short axis) 
        {
            //关闭Alarm清除信号输出
            Gts_Return = MC.GT_SetDoBit(11, axis, 1);
            LogErr?.Invoke("GT_SetDoBit OFF", Gts_Return);
        }
        /// <summary>
        /// Gts工控卡 上位机Axes回零
        /// </summary>
        /// <param name="Axis"></param>
        /// <returns></returns>
        public int Home_Upper_Monitor(short Axis)
        {
            //命令返回值
            short Gts_Return;
            short Capture;//捕获状态值
            MC.TTrapPrm Home_TrapPrm = new MC.TTrapPrm();
            int Axis_Sta;//轴状态
            uint Axis_Pclock;//轴时钟
            Int32 Axis_Pos;//回零是触发Home开关时的轴位置
            double prfPos;//回零运动过程中规划位置
            //定义时钟
            uint pclock;

            //停止轴运动
            Gts_Return = MC.GT_Stop(1 << (Axis - 1), 0); //平滑停止轴运动
            LogErr?.Invoke("Motion--停止轴运动", Gts_Return);

            //清除指定轴报警和限位
            Gts_Return = MC.GT_ClrSts(Axis, 1);
            LogErr?.Invoke("Axis_Home----GT_ClrSts", Gts_Return);

            //回零准备，向正方向前进20mm，后触发回零
            //切换到点动模式
            Gts_Return = MC.GT_PrfTrap(Axis);
            LogErr?.Invoke("Axis_Home----GT_PrfTrap", Gts_Return);

            //读取点动模式运动参数
            Gts_Return = MC.GT_GetTrapPrm(Axis, out Home_TrapPrm);
            LogErr?.Invoke("Axis_Home----GT_GetTrapPrm", Gts_Return);

            //设置点动模式运动参数
            Home_TrapPrm.acc = Convert.ToDouble(Program.SystemContainer.SysPara.Home_acc / Program.SystemContainer.SysPara.Gts_Acc_reference);
            Home_TrapPrm.dec = Convert.ToDouble(Program.SystemContainer.SysPara.Home_dcc / Program.SystemContainer.SysPara.Gts_Acc_reference);
            Home_TrapPrm.smoothTime = Program.SystemContainer.SysPara.Home_smoothTime;

            //设置点动模式运动参数
            Gts_Return = MC.GT_SetTrapPrm(Axis, ref Home_TrapPrm);
            LogErr?.Invoke("Axis_Home----GT_SetTrapPrm", Gts_Return);

            //设置点动模式目标速度，即回原点速度
            Gts_Return = MC.GT_SetVel(Axis, Convert.ToDouble(Program.SystemContainer.SysPara.Home_High_Speed / Program.SystemContainer.SysPara.Gts_Vel_reference));
            LogErr?.Invoke("Axis_Home----GT_SetVel", Gts_Return);

            //读取当前规划位置
            Gts_Return = MC.GT_GetPrfPos(Axis, out prfPos, 1, out pclock);
            LogErr?.Invoke("Motion--读取轴当前规划位置", Gts_Return);

            //设置点动模式目标位置，即原点准备距离 20mm
            Gts_Return = MC.GT_SetPos(Axis, Convert.ToInt32(Convert.ToDouble(20 * Program.SystemContainer.SysPara.Gts_Pos_reference) + prfPos));
            LogErr?.Invoke("Motion--设置目标位置", Gts_Return);

            //启动运动
            Gts_Return = MC.GT_Update(1 << (Axis - 1));
            LogErr?.Invoke("Axis_Home----GT_Update", Gts_Return);

            do
            {
                //读取轴状态
                Gts_Return = MC.GT_GetSts(Axis, out Axis_Sta, 1, out Axis_Pclock);

            } while ((Axis_Sta & 0x400) != 0);

            //停止轴运动
            Gts_Return = MC.GT_Stop(1 << (Axis - 1), 0); //平滑停止轴运动
            LogErr?.Invoke("Motion--停止轴运动", Gts_Return);

            //延时一段时间，等待电机稳定
            Thread.Sleep(200);//200ms

            //触发回零
            //启动Home捕捉
            Gts_Return = MC.GT_SetCaptureMode(Axis, MC.CAPTURE_HOME);
            LogErr?.Invoke("Axis_Home----GT_SetCaptureMode", Gts_Return);

            //切换到点动模式
            Gts_Return = MC.GT_PrfTrap(Axis);
            LogErr?.Invoke("Axis_Home----GT_PrfTrap", Gts_Return);

            //读取点动模式运动参数
            Gts_Return = MC.GT_GetTrapPrm(Axis, out Home_TrapPrm);
            LogErr?.Invoke("Axis_Home----GT_GetTrapPrm", Gts_Return);

            //设置点动模式运动参数
            Home_TrapPrm.acc = Convert.ToDouble(Program.SystemContainer.SysPara.Home_acc / Program.SystemContainer.SysPara.Gts_Acc_reference);
            Home_TrapPrm.dec = Convert.ToDouble(Program.SystemContainer.SysPara.Home_dcc / Program.SystemContainer.SysPara.Gts_Acc_reference);
            Home_TrapPrm.smoothTime = Program.SystemContainer.SysPara.Home_smoothTime;

            //设置点动模式运动参数
            Gts_Return = MC.GT_SetTrapPrm(Axis, ref Home_TrapPrm);
            LogErr?.Invoke("Axis_Home----GT_SetTrapPrm", Gts_Return);

            //设置点动模式目标速度，即回原点速度
            Gts_Return = MC.GT_SetVel(Axis, Convert.ToDouble(Program.SystemContainer.SysPara.Home_High_Speed / Program.SystemContainer.SysPara.Gts_Vel_reference));
            LogErr?.Invoke("Axis_Home----GT_SetVel", Gts_Return);

            //设置点动模式目标位置，即原点搜索距离
            Gts_Return = MC.GT_SetPos(Axis, Convert.ToInt32(Program.SystemContainer.SysPara.Search_Home * Program.SystemContainer.SysPara.Gts_Pos_reference));
            LogErr?.Invoke("Axis_Home----GT_SetPos", Gts_Return);

            //启动运动
            Gts_Return = MC.GT_Update(1 << (Axis - 1));
            LogErr?.Invoke("Axis_Home----GT_Update", Gts_Return);


            do
            {
                //读取轴状态
                Gts_Return = MC.GT_GetSts(Axis, out Axis_Sta, 1, out Axis_Pclock);
                //读取捕获状态
                Gts_Return = MC.GT_GetCaptureStatus(Axis, out Capture, out Axis_Pos, 1, out Axis_Pclock);
                //读取编码器位置
                //Gts_Return = MC.GT_GetEncPos(Axis, out encPos, 1, out Axis_Pclock);
                //如果运动停止，返回出错信息
                if (0 == (Axis_Sta & 0x400))
                {
                    LogErr?.Invoke("Axis_Home----No Home found!!", 1);
                    return 1;//整个过程Home信号一直没有触发，返回值为1                    
                }
            } while (Capture == 0);

            /********************************待评估***********************************/
            /*
            //清除捕捉状态
            //Gts_Return = MC.GT_ClearCaptureStatus(Axis);
            //LogErr?.Invoke("Axis_Home----清除捕捉状态", Gts_Return);

            //设置捕捉Home 下降沿
            //Gts_Return = MC.GT_SetCaptureSense(Axis, MC.CAPTURE_HOME, 0);
            //LogErr?.Invoke("Axis_Home----设置捕捉Home 下降沿", Gts_Return);

            //设定目标位置为捕获位置+偏移量
            Gts_Return = MC.GT_SetPos(Axis, Axis_Pos + Home_OffSet);
            LogErr?.Invoke("Axis_Home----GT_SetPos", Gts_Return);

            //在运动状态下更新目标位置
            Gts_Return = MC.GT_Update(1 << (Axis - 1));
            LogErr?.Invoke("Axis_Home----GT_Update", Gts_Return);              

            do
            {
                //读取轴状态
                Gts_Return = MC.GT_GetSts(Axis, out Axis_Sta, 1, out Axis_Pclock);
                //读取捕获状态
                Gts_Return = MC.GT_GetCaptureStatus(Axis, out Capture, out Axis_Pos, 1, out Axis_Pclock);
                //读取编码器位置
                //Gts_Return = MC.GT_GetEncPos(Axis, out encPos, 1, out Axis_Pclock);
                //如果运动停止，返回出错信息
                if (0 == (Axis_Sta & 0x400))
                {
                    LogErr?.Invoke("Axis_Home----No Home found!!", 1);
                    //反转回零标志
                    Homing_Flag = !Homing_Flag;
                    return 1;//整个过程Home信号一直没有触发，返回值为1                    
                }
            } while (Capture ==0);
            */
            /********************************待评估***********************************/

            //停止轴运动
            Gts_Return = MC.GT_Stop(1 << (Axis - 1), 0); //平滑停止轴运动
            LogErr?.Invoke("Motion--停止轴运动", Gts_Return);

            //延时一段时间，等待电机稳定
            Thread.Sleep(500);//200ms
            //位置清零            
            Gts_Return = MC.GT_ZeroPos(Axis, 1);
            LogErr?.Invoke("Axis_Home----GT_ZeroPos", Gts_Return);

            /***************************Home_Offset偏置距离 开始********************************************/

            if (Program.SystemContainer.SysPara.Home_OffSet !=0)
            {
                //切换到点动模式
                Gts_Return = MC.GT_PrfTrap(Axis);
                LogErr?.Invoke("Axis_Home----GT_PrfTrap", Gts_Return);

                //读取点动模式运动参数
                Gts_Return = MC.GT_GetTrapPrm(Axis, out Home_TrapPrm);
                LogErr?.Invoke("Axis_Home----GT_GetTrapPrm", Gts_Return);

                //设置点动模式运动参数
                Home_TrapPrm.acc = Convert.ToDouble(Program.SystemContainer.SysPara.Home_acc / Program.SystemContainer.SysPara.Gts_Acc_reference);
                Home_TrapPrm.dec = Convert.ToDouble(Program.SystemContainer.SysPara.Home_dcc / Program.SystemContainer.SysPara.Gts_Acc_reference);
                Home_TrapPrm.smoothTime = Program.SystemContainer.SysPara.Home_smoothTime;

                //设置点动模式运动参数
                Gts_Return = MC.GT_SetTrapPrm(Axis, ref Home_TrapPrm);
                LogErr?.Invoke("Axis_Home----GT_SetTrapPrm", Gts_Return);

                //设置点动模式目标速度，即回原点速度
                Gts_Return = MC.GT_SetVel(Axis, Convert.ToDouble(Program.SystemContainer.SysPara.Home_High_Speed / Program.SystemContainer.SysPara.Gts_Vel_reference));
                LogErr?.Invoke("Axis_Home----GT_SetVel", Gts_Return);

                //设置点动模式目标位置，即原点搜索距离
                Gts_Return = MC.GT_SetPos(Axis, Convert.ToInt32(Program.SystemContainer.SysPara.Home_OffSet * Program.SystemContainer.SysPara.Gts_Pos_reference));
                LogErr?.Invoke("Axis_Home----GT_SetPos", Gts_Return);

                //启动运动
                Gts_Return = MC.GT_Update(1 << (Axis - 1));
                LogErr?.Invoke("Axis_Home----GT_Update", Gts_Return);

                do
                {
                    //读取轴状态
                    Gts_Return = MC.GT_GetSts(Axis, out Axis_Sta, 1, out Axis_Pclock);
                    //读取规划位置
                    Gts_Return = MC.GT_GetPrfPos(Axis, out prfPos, 1, out Axis_Pclock);
                    //读取编码器位置
                    //Gts_Return = MC.GT_GetEncPos(Axis, out encPos, 1, out Axis_Pclock);

                } while ((Axis_Sta & 0x400) != 0);

                //检查是否到达 Home_OffSet
                if (prfPos != Convert.ToInt32(Program.SystemContainer.SysPara.Home_OffSet * Program.SystemContainer.SysPara.Gts_Pos_reference))
                {
                    LogErr?.Invoke("Axis_Home----Move to Home_OffSet err!!", 1);
                    return 2;
                }
                /***************************Home_Offset偏置距离 结束********************************************/
            }
            //延时一段时间，等待电机稳定
            Thread.Sleep(500);//200ms
            //位置清零            
            Gts_Return = MC.GT_ZeroPos(Axis, 1);
            LogErr?.Invoke("Axis_Home----GT_ZeroPos", Gts_Return);
            return 0;
        }
        /// <summary>
        /// 轴自身Axes01 X轴回零 返回值：0 - 回零完成呢；1 - Busy；2 - 超时；3 - 轴错误
        /// </summary>
        /// <param name="Axis"></param>
        /// <returns></returns>
        public int Axis01_Home_Down_Motor()
        {
            Axis01_Homed = false;//归零完成标志清除
            //命令返回值
            short Gts_Return = 0;

            //轴运行中，退出
            if (Program.SystemContainer.IO.Axis01_Busy)
            {
                return 1;
            }

            //停止轴运动
            Gts_Return = MC.GT_Stop(1 << 0, 0); //平滑停止轴运动
            LogErr?.Invoke("Motion--停止轴运动", Gts_Return);

            //清除指定轴报警和限位
            Gts_Return = MC.GT_ClrSts(1, 1);
            LogErr?.Invoke("Axis_Home----GT_ClrSts", Gts_Return);

            //位置清零            
            Gts_Return = MC.GT_ZeroPos(1, 1);
            LogErr?.Invoke("Axis_Home----GT_ZeroPos", Gts_Return);

            //触发回零外部信号
            if (Program.SystemContainer.IO.Axis01_Home_Ex0_Control != 1) Program.SystemContainer.IO.Axis01_Home_Ex0_Control = 1;

            //延时一段时间,等待信号生效
            Thread.Sleep(500); 

            //清除回零外部信号
            if (Program.SystemContainer.IO.Axis01_Home_Ex0_Control != 0) Program.SystemContainer.IO.Axis01_Home_Ex0_Control = 0;

            //捕获原点触发信号
            //等待完成
            Task.Factory.StartNew(() => {
                do
                {
                    //延时
                    Thread.Sleep(100);

                } while (!Program.SystemContainer.IO.Axis01_Home);
            }).Wait(120 * 1000);//回零超时时长120s 2min
            if (!Program.SystemContainer.IO.Axis01_Home)
            {
                MessageBox.Show("X轴回零超时！！！");
                return 2;
            }
            //清除回零外部信号
            if (Program.SystemContainer.IO.Axis01_Home_Ex0_Control != 0) Program.SystemContainer.IO.Axis01_Home_Ex0_Control = 0;

            //延时一段时间，等待电机稳定
            Thread.Sleep(200);//200ms
            
            //位置清零            
            Gts_Return = MC.GT_ZeroPos(1, 1);
            LogErr?.Invoke("Axis_Home----GT_ZeroPos", Gts_Return);

            //清除指定轴报警和限位
            Gts_Return = MC.GT_ClrSts(1, 1);
            LogErr?.Invoke("Axis_Home----GT_ClrSts", Gts_Return);

            //检测是否有错误发生
            if (Program.SystemContainer.IO.Axis01_Err_Occur)
            {
                return 3;
            }
            else
            {
                Axis01_Homed = true;//归零完成标志
                return 0;
            }
        }
        /// <summary>
        /// 轴自身Axes02 Y轴回零 返回值：0 - 回零完成呢；1 - Busy；2 - 超时；3 - 轴错误
        /// </summary>
        /// <param name="Axis"></param>
        /// <returns></returns>
        public int Axis02_Home_Down_Motor()
        {
            Axis02_Homed = false;//归零完成标志清除

            //命令返回值
            short Gts_Return = 0;

            //轴运行中，退出
            if (Program.SystemContainer.IO.Axis02_Busy)
            {
                return 1;
            }

            //停止轴运动
            Gts_Return = MC.GT_Stop(1 << 1, 0); //平滑停止轴运动
            LogErr?.Invoke("Motion--停止轴运动", Gts_Return);

            //清除指定轴报警和限位
            Gts_Return = MC.GT_ClrSts(2, 1);
            LogErr?.Invoke("Axis_Home----GT_ClrSts", Gts_Return);

            //位置清零            
            Gts_Return = MC.GT_ZeroPos(2, 1);
            LogErr?.Invoke("Axis_Home----GT_ZeroPos", Gts_Return);

            //触发回零外部信号
            if (Program.SystemContainer.IO.Axis02_Home_Ex0_Control != 1) Program.SystemContainer.IO.Axis02_Home_Ex0_Control = 1;

            //延时一段时间,等待信号生效
            Thread.Sleep(500);

            //清除回零外部信号
            if (Program.SystemContainer.IO.Axis02_Home_Ex0_Control != 0) Program.SystemContainer.IO.Axis02_Home_Ex0_Control = 0;

            //捕获原点触发信号
            //等待完成
            Task.Factory.StartNew(() => {
                do
                {
                    //延时
                    Thread.Sleep(100);
                } while (!Program.SystemContainer.IO.Axis02_Home);
            }).Wait(120 * 1000);//回零超时时长120s 2min
            if (!Program.SystemContainer.IO.Axis02_Home)
            {
                MessageBox.Show("Y轴回零超时！！！");
                return 2;
            }
            //清除回零外部信号
            if (Program.SystemContainer.IO.Axis02_Home_Ex0_Control != 0) Program.SystemContainer.IO.Axis02_Home_Ex0_Control = 0;

            //延时一段时间，等待电机稳定
            Thread.Sleep(20);//200ms

            //位置清零            
            Gts_Return = MC.GT_ZeroPos(2, 1);
            LogErr?.Invoke("Axis_Home----GT_ZeroPos", Gts_Return);

            //清除指定轴报警和限位
            Gts_Return = MC.GT_ClrSts(2, 1);
            LogErr?.Invoke("Axis_Home----GT_ClrSts", Gts_Return);

            //检测是否有错误发生
            if (Program.SystemContainer.IO.Axis02_Err_Occur)
            {
                return 3;
            }
            else
            {
                Axis02_Homed = true;//归零完成标志
                return 0;
            }
        }

        /// <summary>
        /// 绝对定位
        /// </summary>
        /// <param name="Axis"></param>
        /// <param name="acc"></param>
        /// <param name="dcc"></param>
        /// <param name="smoothTime"></param>
        /// <param name="pos"></param>
        /// <param name="vel"></param>
        public void Abs(short Axis, decimal acc, decimal dcc, short smoothTime, decimal pos, decimal vel)
        {
            //定义点位运动参数变量
            MC.TTrapPrm trapPrm = new MC.TTrapPrm();
            //定义当前位置变量
            double prfpos;
            //定义时钟
            uint pclock;
            //定义轴状态
            int sts;
            //将轴设置为点位运动模式
            Gts_Return = MC.GT_PrfTrap(Axis);
            LogErr?.Invoke("Motion--将轴设置为点位运动模式", Gts_Return);
            //读取点位运动运动参数
            Gts_Return = MC.GT_GetTrapPrm(Axis, out trapPrm);
            LogErr?.Invoke("Motion--读取轴点位运动运动参数", Gts_Return);
            //设置要修改的参数
            trapPrm.acc = Convert.ToDouble(acc / Program.SystemContainer.SysPara.Gts_Acc_reference);
            trapPrm.dec = Convert.ToDouble(dcc / Program.SystemContainer.SysPara.Gts_Acc_reference);
            trapPrm.smoothTime = smoothTime;
            //设置点位运动参数
            Gts_Return = MC.GT_SetTrapPrm(Axis, ref trapPrm);
            LogErr?.Invoke("Motion--读取轴设置点位运动参数", Gts_Return);

            //读取当前规划位置
            Gts_Return = MC.GT_GetPrfPos(Axis, out prfpos, 1, out pclock);
            LogErr?.Invoke("Motion--读取轴当前规划位置", Gts_Return);

            //设置目标位置
            Gts_Return = MC.GT_SetPos(Axis, Convert.ToInt32(pos * Program.SystemContainer.SysPara.Gts_Pos_reference));
            LogErr?.Invoke("Motion--设置目标位置", Gts_Return);

            //设置目标速度
            Gts_Return = MC.GT_SetVel(Axis, Convert.ToDouble(vel / Program.SystemContainer.SysPara.Gts_Vel_reference));
            LogErr?.Invoke("Motion--设置目标速度", Gts_Return);

            //启动轴运动
            Gts_Return = MC.GT_Update(1 << (Axis - 1));
            LogErr?.Invoke("Motion--启动轴运动", Gts_Return);

            do
            {
                //读取轴状态
                Gts_Return = MC.GT_GetSts(Axis, out sts, 1, out pclock);
                LogErr?.Invoke("Motion--读取轴状态", Gts_Return);
            } while ((sts & 0x400) != 0);//等待Axis规划停止
        }
        /// <summary>
        /// 相对定位
        /// </summary>
        /// <param name="Axis"></param>
        /// <param name="acc"></param>
        /// <param name="dcc"></param>
        /// <param name="smoothTime"></param>
        /// <param name="pos"></param>
        /// <param name="vel"></param>
        public void Inc(short Axis, decimal acc, decimal dcc, short smoothTime, decimal pos, decimal vel)
        {
            //定义点位运动参数变量
            MC.TTrapPrm trapPrm = new MC.TTrapPrm();
            //定义当前位置变量
            double prfpos;
            //定义时钟
            uint pclock;
            //定义轴状态
            int sts;
            //将轴设置为点位运动模式
            Gts_Return = MC.GT_PrfTrap(Axis);
            LogErr?.Invoke("Motion--将轴设置为点位运动模式", Gts_Return);
            //读取点位运动运动参数
            Gts_Return = MC.GT_GetTrapPrm(Axis, out trapPrm);
            LogErr?.Invoke("Motion--读取轴点位运动运动参数", Gts_Return);
            //设置要修改的参数
            trapPrm.acc = Convert.ToDouble(acc / Program.SystemContainer.SysPara.Gts_Acc_reference);
            trapPrm.dec = Convert.ToDouble(dcc / Program.SystemContainer.SysPara.Gts_Acc_reference);
            trapPrm.smoothTime = smoothTime;
            //设置点位运动参数
            Gts_Return = MC.GT_SetTrapPrm(Axis, ref trapPrm);
            LogErr?.Invoke("Motion--读取轴设置点位运动参数", Gts_Return);

            //读取当前规划位置
            Gts_Return = MC.GT_GetPrfPos(Axis, out prfpos, 1, out pclock);
            LogErr?.Invoke("Motion--读取轴当前规划位置", Gts_Return);

            //设置目标位置
            Gts_Return = MC.GT_SetPos(Axis, Convert.ToInt32(Convert.ToDouble(pos * Program.SystemContainer.SysPara.Gts_Pos_reference) + prfpos));
            LogErr?.Invoke("Motion--设置目标位置", Gts_Return);

            //设置目标速度
            Gts_Return = MC.GT_SetVel(Axis, Convert.ToDouble(vel / Program.SystemContainer.SysPara.Gts_Vel_reference));
            LogErr?.Invoke("Motion--设置目标速度", Gts_Return);

            //启动轴运动
            Gts_Return = MC.GT_Update(1 << (Axis - 1));
            LogErr?.Invoke("Motion--启动轴运动", Gts_Return);

            do
            {
                //读取轴状态
                Gts_Return = MC.GT_GetSts(Axis, out sts, 1, out pclock);
                LogErr?.Invoke("Motion--读取轴状态", Gts_Return);
            } while ((sts & 0x400) != 0);//等待Axis规划停止


        }
        /// <summary>
        /// Jog
        /// </summary>
        /// <param name="Axis"></param>
        /// <param name="dir"></param>
        /// <param name="JogVel"></param>
        /// <param name="JogAcc"></param>
        /// <param name="JogDcc"></param>
        public void Jog(short Axis, short dir, decimal JogVel, decimal JogAcc, decimal JogDcc)
        {
            //定义Jog运动参数变量
            MC.TJogPrm prfJog = new MC.TJogPrm();
            //将轴设置为Jog模式
            Gts_Return = MC.GT_PrfJog(Axis);
            LogErr?.Invoke("Motion--将轴设置为Jog模式", Gts_Return);
            //读取轴jog运动参数
            Gts_Return = MC.GT_GetJogPrm(Axis, out prfJog);
            LogErr?.Invoke("Motion--读取轴jog运动参数", Gts_Return);

            //设置要修改的参数
            prfJog.acc = Convert.ToDouble(JogAcc / Program.SystemContainer.SysPara.Gts_Acc_reference);//加速度
            prfJog.dec = Convert.ToDouble(JogDcc / Program.SystemContainer.SysPara.Gts_Acc_reference);//减速度

            //设置jog运动参数
            Gts_Return = MC.GT_SetJogPrm(Axis, ref prfJog);
            LogErr?.Invoke("Motion--设置jog运动参数", Gts_Return);

            //设置轴Jog运行速度
            if (dir == 0) //Jog+
            {
                Gts_Return = MC.GT_SetVel(Axis, Convert.ToDouble(JogVel / Program.SystemContainer.SysPara.Gts_Vel_reference));
                LogErr?.Invoke("Motion--设置轴Jog运行速度", Gts_Return);
            }
            else    // Jog-
            {
                Gts_Return = MC.GT_SetVel(Axis, Convert.ToDouble(-JogVel / Program.SystemContainer.SysPara.Gts_Vel_reference));
                LogErr?.Invoke("Motion--设置轴Jog运行速度", Gts_Return);
            }

            //启动轴运动
            Gts_Return = MC.GT_Update(1 << (Axis - 1));
            LogErr?.Invoke("Motion--启动轴运动", Gts_Return);
        }
        /// <summary>
        /// 平滑停止轴运动
        /// </summary>
        /// <param name="Axis"></param>
        public void SmoothStop(short Axis)
        {
            //停止轴运动
            Gts_Return = MC.GT_Stop(1 << (Axis - 1), 0); //平滑停止轴运动
            LogErr?.Invoke("Motion--停止轴运动", Gts_Return);
        }
        
        /// <summary>
        /// 紧急停止轴运动
        /// </summary>
        /// <param name="Axis"></param>
        public void EmgStop(short Axis)
        {
            //停止轴运动
            Gts_Return = MC.GT_Stop(1 << (Axis - 1), 1 << (Axis - 1)); //紧急停止轴运动
            LogErr?.Invoke("Motion--停止轴运动", Gts_Return);
        }

        /********************************************************/
        /**以下是坐标系运动**/
        public short run;//插补运行状态
        private int segment;//插补剩余个数
        private MC.TCrdData[] crdData = new MC.TCrdData[4096];
        static IntPtr Crd_IntPtr = new IntPtr();
        uint pClock;
        public List<Affinity_Matrix> affinity_Matrices = new List<Affinity_Matrix>();//校准数据集合
        
        /// <summary>
        /// 加载矫正数组
        /// </summary>
        public void Load_Affinity_Matrix()
        {
            AffinityCountOK = false;//清除 仿射矫正矩阵数据匹配标志
            string File_Name = "Correct_File/Gts_Affinity_Matrix_Three.xml";
            //file path
            string File_Path = @"./\Config/" + File_Name;
            //read file
            if (File.Exists(File_Path))
            {
                //获取矫正数据
                affinity_Matrices = new List<Affinity_Matrix>(Common_Collect.Reserialize<Affinity_Matrix>(File_Path));
                if (affinity_Matrices.Count != Program.SystemContainer.SysPara.Gts_Affinity_Col_X * Program.SystemContainer.SysPara.Gts_Affinity_Row_Y)
                {
                    affinity_Matrices = new List<Affinity_Matrix>();
                    LogInfo?.Invoke("Gts Affinity 矫正文件文件不匹配！！！，禁止加工，请检查！");
                    return;
                }
                AffinityCountOK = true;//置位 仿射矫正矩阵数据匹配标志
                LogInfo?.Invoke("Gts Affinity 矫正文件加载成功！！！,数据数量：" + affinity_Matrices.Count);
            }
            else
            {
                affinity_Matrices = new List<Affinity_Matrix>();
                LogInfo?.Invoke("Gts Affinity 矫正文件文件不存在！！！，禁止加工，请检查！");
            }           
        }
        /// <summary>
        /// 加载矫正数组
        /// </summary>
        public bool Load_Affinity_Matrix(string File_Name)
        {
            AffinityCountOK = false;//清除 仿射矫正矩阵数据匹配标志
            //file path
            string File_Path = @"./\Config/" + File_Name;
            //read file
            if (File.Exists(File_Path))
            {
                //获取矫正数据
                affinity_Matrices = new List<Affinity_Matrix>(Serialize_Data.Reserialize_Affinity_Matrix(File_Path));
                if (affinity_Matrices.Count != Program.SystemContainer.SysPara.Gts_Affinity_Col_X * Program.SystemContainer.SysPara.Gts_Affinity_Row_Y)
                {
                    affinity_Matrices = new List<Affinity_Matrix>();
                    LogInfo?.Invoke("Gts Affinity 矫正文件文件不匹配！！！，禁止加工，请检查！");
                    return false;
                }
                LogInfo?.Invoke("Gts Affinity 矫正文件加载成功！！！,数据数量：" + affinity_Matrices.Count);
                AffinityCountOK = true;//置位 仿射矫正矩阵数据匹配标志
                return true;
            }
            else
            {
                affinity_Matrices = new List<Affinity_Matrix>();
                LogInfo?.Invoke("Gts Affinity 矫正文件文件不存在！！！，禁止加工，请检查！");
                return false;
            }
        }
        /// <summary>
        /// 加载矫正数组
        /// </summary>
        public bool Load_Affinity_MatrixBySpecificfile(string File_Path)
        {
            AffinityCountOK = false;//清除 仿射矫正矩阵数据匹配标志
            //read file
            if (File.Exists(File_Path))
            {
                //获取矫正数据
                affinity_Matrices = new List<Affinity_Matrix>(Serialize_Data.Reserialize_Affinity_Matrix(File_Path));
                if (affinity_Matrices.Count != Program.SystemContainer.SysPara.Gts_Affinity_Col_X * Program.SystemContainer.SysPara.Gts_Affinity_Row_Y)
                {
                    affinity_Matrices = new List<Affinity_Matrix>();
                    LogInfo?.Invoke("Gts Affinity 矫正文件文件不匹配！！！，禁止加工，请检查！");
                    return false;
                }
                LogInfo?.Invoke("Gts Affinity 矫正文件加载成功！！！,数据数量：" + affinity_Matrices.Count);
                AffinityCountOK = true;//置位 仿射矫正矩阵数据匹配标志
                return true;
            }
            else
            {
                affinity_Matrices = new List<Affinity_Matrix>();
                LogInfo?.Invoke("Gts Affinity 矫正文件文件不存在！！！，禁止加工，请检查！");
                return false;
            }
        } 
        /// <summary>
        /// 获取当前点的坐标系坐标 0 - NO COMPENSATION;1 - AFFINITY COMPENSATION;
        /// </summary>
        /// <param name="type"></param>
        /// 0 - NO COMPENSATION
        /// 1 - AFFINITY COMPENSATION
        /// 2 - LINE COMPENSATION
        /// <returns></returns>
        public Vector Get_Coordinate(int type)
        {
            Vector Result = new Vector(0, 0);
            Vector Tem_Pos = new Vector(0, 0);

            /***********人为单轴拆分***************/
            double Current_Pos_X, Current_Pos_Y;
            MC.GT_GetPrfPos(1,out Current_Pos_X, 1,out uint pXClock);//读取X轴当前位置
            MC.GT_GetPrfPos(2, out Current_Pos_Y, 1, out uint pYClock);//读取Y轴当前位置
            Tem_Pos = new Vector(Program.SystemContainer.SysPara.Work.X - (decimal)Current_Pos_X / Program.SystemContainer.SysPara.Gts_Pos_reference, Program.SystemContainer.SysPara.Work.Y - (decimal)Current_Pos_Y / Program.SystemContainer.SysPara.Gts_Pos_reference);
            /***********输出结果***************/
            if (type == 0)
            {
                Result = new Vector(Tem_Pos);
            }
            else
            {
                Result = new Vector(Gts_Cal_Data_Resolve.Get_Affinity_Point(1, Tem_Pos.X, Tem_Pos.Y));
            }
            return Result;
        }

        /// <summary>
        /// 单轴运动
        /// </summary>
        public void Interpolation_Start(decimal PosX,decimal PosY)
        {
            //设置X轴误差带
            Gts_Return = MC.GT_SetAxisBand(1, Program.SystemContainer.SysPara.Axis_X_Band, 4 * Program.SystemContainer.SysPara.Axis_X_Time);//20-0.1um,4*2-250us
            LogErr?.Invoke("X轴到位误差带", Gts_Return);
            //设置Y轴误差带
            Gts_Return = MC.GT_SetAxisBand(2, Program.SystemContainer.SysPara.Axis_Y_Band, 4 * Program.SystemContainer.SysPara.Axis_Y_Time);//20-0.1um,4*2-250us
            LogErr?.Invoke("Y轴到位误差带", Gts_Return);


            //急停按钮按下终止运行
            if (Program.SystemContainer.IO.GlobalEMG)
            {
                Interpolation_Stop();
                return;
            }

            //二轴单独控制运动
            //1、计算二轴规划位置
            decimal GoX = (Program.SystemContainer.SysPara.Work.X - PosX) * Program.SystemContainer.SysPara.Gts_Pos_reference;
            decimal GoY = (Program.SystemContainer.SysPara.Work.Y - PosY) * Program.SystemContainer.SysPara.Gts_Pos_reference;
            //2、设置运行参数
            SetAxisPara(1, Program.SystemContainer.SysPara.AxisXAcc, Program.SystemContainer.SysPara.AxisXDcc, Program.SystemContainer.SysPara.AxisXSmoothTime, GoX, Program.SystemContainer.SysPara.AxisXVelocity);//X轴运行参数
            SetAxisPara(2, Program.SystemContainer.SysPara.AxisYAcc, Program.SystemContainer.SysPara.AxisYDcc, Program.SystemContainer.SysPara.AxisYSmoothTime, GoY, Program.SystemContainer.SysPara.AxisYVelocity);//Y轴运行参数
            //3、启动运动
            Gts_Return = MC.GT_Update(1 << (1 - 1));//启动X轴运动
            Gts_Return = MC.GT_Update(1 << (2 - 1));//启动Y轴运动
            //4、等待运动结束
            int stsX, stsY;
            do
            {
                //急停按钮按下终止运行
                if (Program.SystemContainer.IO.GlobalEMG)
                {
                    Interpolation_Stop();
                    return;
                }
                Gts_Return = MC.GT_GetSts(1, out stsX, 1, out pClock);//读取X轴状态
                Gts_Return = MC.GT_GetSts(2, out stsY, 1, out pClock);//读取Y轴状态
                Thread.Sleep(100);
            } while (((stsX & 0x400) != 0) || ((stsY & 0x400) != 0));//等待两轴规划停止

            //到位检测
            do
            {
                //延时
                Thread.Sleep(Program.SystemContainer.SysPara.Posed_Time);
            } while (!Program.SystemContainer.IO.Axis01_Motor_Posed || !(Program.SystemContainer.IO.Axis02_Motor_Posed));
        }
        /// <summary>
        /// 设置轴运行参数
        /// </summary>
        /// <param name="Axis"></param>
        /// <param name="acc"></param>
        /// <param name="dcc"></param>
        /// <param name="smoothTime"></param>
        /// <param name="pos"></param>
        /// <param name="vel"></param>
        public void SetAxisPara(short Axis, decimal acc, decimal dcc, short smoothTime, decimal pos, decimal vel)
        {
            //定义点位运动参数变量
            MC.TTrapPrm trapPrm = new MC.TTrapPrm();
            //定义当前位置变量
            double prfpos;
            //定义时钟
            uint pclock;
            //定义轴状态
            int sts;
            //将轴设置为点位运动模式
            Gts_Return = MC.GT_PrfTrap(Axis);
            LogErr?.Invoke("Motion--将轴设置为点位运动模式", Gts_Return);
            //读取点位运动运动参数
            Gts_Return = MC.GT_GetTrapPrm(Axis, out trapPrm);
            LogErr?.Invoke("Motion--读取轴点位运动运动参数", Gts_Return);
            //设置要修改的参数
            trapPrm.acc = Convert.ToDouble(acc / Program.SystemContainer.SysPara.Gts_Acc_reference);
            trapPrm.dec = Convert.ToDouble(dcc / Program.SystemContainer.SysPara.Gts_Acc_reference);
            trapPrm.smoothTime = smoothTime;
            //设置点位运动参数
            Gts_Return = MC.GT_SetTrapPrm(Axis, ref trapPrm);
            LogErr?.Invoke("Motion--读取轴设置点位运动参数", Gts_Return);

            //读取当前规划位置
            Gts_Return = MC.GT_GetPrfPos(Axis, out prfpos, 1, out pclock);
            LogErr?.Invoke("Motion--读取轴当前规划位置", Gts_Return);

            //设置目标位置
            Gts_Return = MC.GT_SetPos(Axis, Convert.ToInt32(pos));
            LogErr?.Invoke("Motion--设置目标位置", Gts_Return);

            //设置目标速度
            Gts_Return = MC.GT_SetVel(Axis, Convert.ToDouble(vel / Program.SystemContainer.SysPara.Gts_Vel_reference));
            LogErr?.Invoke("Motion--设置目标速度", Gts_Return);
        }
        /// <summary>
        /// 停止轴运动
        /// </summary>
        public void Interpolation_Stop()
        {
            //停止轴规划运动，停止坐标系运动
            Gts_Return = MC.GT_Stop(15, 0);//783-1-4轴全停止，坐标系1、2均停止,15-1-4轴全停止；0-平滑停止运动，783-急停运动
            LogErr?.Invoke("Establish_Coordinationg--GT_Stop", Gts_Return);
        }
        
        /// <summary>
        /// 定位到指定点，type：0 - 不矫正，1 - 矫正
        /// </summary>
        /// <param name="Point"></param>
        /// <param name="type"></param>
        public bool Gts_Point_Go(Vector Point, int type)
        {
            //平台安全防护
            if (Program.SystemContainer.SysPara.Safe_moveEntrench == 1)//0 - 不启用运动安全防护；其他 - 启用
            {
                if (Program.SystemContainer.IO.SafeSensorCheck.Equals(1))
                {
                    MessageBox.Show("运动安全防护触发，请移除障碍物！！！");
                    return false;
                }
            }
#if !DEBUG
            //数据矫正
            Vector Tmp_Point = new Vector();
            //定义处理的变量
            decimal Tmp_X = 0.0m;
            decimal Tmp_Y = 0.0m;
            //终点计算
            if (type == 0)
            {
                Tmp_X = Point.X;
                Tmp_Y = Point.Y;
            }
            else if (type == 1)
            {
                //数据矫正
                Tmp_Point = new Vector(Gts_Cal_Data_Resolve.Get_Affinity_Point(0, Point.X, Point.Y));
                Tmp_X = Tmp_Point.X;
                Tmp_Y = Tmp_Point.Y;
            }
            //坐标极限判断
            if ((Tmp_X > Program.SystemContainer.SysPara.Work.X) || (Tmp_X < -2) || (Tmp_Y > Program.SystemContainer.SysPara.Work.Y) || (Tmp_Y < -(Program.SystemContainer.SysPara.Rtc_Org.Y + 1)))
            {
                MessageBox.Show(string.Format("坐标({0},{1})超出平台定位极限！！！", Tmp_X, Tmp_Y));
                return false;
            }

            //启动定位
            Interpolation_Start(Tmp_X, Tmp_Y);

            //刷新坐标
            RefreshPoint?.Invoke();
#endif
            //检测是否有错误发生
            if (Program.SystemContainer.IO.Axis01_Err_Occur || Program.SystemContainer.IO.Axis02_Err_Occur)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 平台坐标系Jog运动
        /// </summary>
        /// <param name="DeltaX"></param>
        /// <param name="DeltaY"></param>
        public bool Gts_Coordinate_Jog(decimal DeltaX,decimal DeltaY)
        {
            Vector Tem = Get_Coordinate(1);
            Tem = new Vector(Tem.X + DeltaX,Tem.Y + DeltaY);
            //极限判断
            if ((Tem.X > Program.SystemContainer.SysPara.Work.X) || (Tem.X < -2) || (Tem.Y > Program.SystemContainer.SysPara.Work.Y) || (Tem.Y < -Program.SystemContainer.SysPara.Rtc_Org.Y))
            {
                MessageBox.Show(string.Format("坐标({0},{1})超出平台定位极限！！！", Tem.X, Tem.Y));
                return false;
            }
            return Gts_Point_Go(Tem,1);
        }
    }

}

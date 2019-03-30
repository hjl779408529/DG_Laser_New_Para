using GTS;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace DG_Laser
{
    /// <summary>
    /// GTS手动操作页面
    /// </summary>
    partial class MainForm
    {
        /****************************************/
        //变量
        //定义Menu_5_Axis_Handle窗口刷新定时器
        System.Timers.Timer Axis_Handle_Timer = new System.Timers.Timer(200);

        //定义当前窗口所需变量
        decimal acc = 500m, dcc = 500m, mannualVel = 100m;
        decimal step = 10m;//默认值10mm 

        //定义点动/连动切换变量
        short Point_Con;

        //定义轴号选择
        short Axis_No = 1;

        /// <summary>
        /// 轴手动操作初始化
        /// </summary>
        private void manualGTSInitial()
        {
#if !DEBUG
            //启用定时器
            Axis_Handle_Timer.Elapsed += Axis_Handle_Timer_Elapsed;
            Axis_Handle_Timer.AutoReset = true;
            Axis_Handle_Timer.Enabled = true;
            Axis_Handle_Timer.Start();
#endif

            //初始化显示
            AxisSelect.Value = Axis_No;
            //加速度
            ManualACC.Text = Convert.ToString(acc);
            //减速度
            ManualDCC.Text = Convert.ToString(dcc);
            //步长
            ManualStep.Text = Convert.ToString(step);//当前1pluse-10um,转化为mm需除以100
            //手动速度
            ManualSpeed.Text = Convert.ToString(mannualVel);

            //原点回归参数
            //回零速度
            HomeSpeed.Text = Convert.ToString(Program.SystemContainer.SysPara.Home_High_Speed);
            //回零加速度
            HomeACC.Text = Convert.ToString(Program.SystemContainer.SysPara.Home_acc);
            //回零减速度
            HomeDCC.Text = Convert.ToString(Program.SystemContainer.SysPara.Home_dcc);
            //回零平滑时间
            HomeSmoothTime.Text = Convert.ToString(Program.SystemContainer.SysPara.Home_smoothTime);
            //原点偏移
            HomeDeviation.Text = Convert.ToString(Program.SystemContainer.SysPara.Home_OffSet);
        }
        /// <summary>
        /// 轴操作页面刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Axis_Handle_Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (this.IsHandleCreated) this.Invoke((EventHandler)delegate
            {
                if (Axis_No == 1)
                {
                    if (Program.SystemContainer.IO.Axis01_Limit_Up) { PositveLimit.BackColor = Color.Red; } else { PositveLimit.BackColor = SystemColors.Control; }//Axis01轴正限位
                    if (Program.SystemContainer.IO.Axis01_Limit_Down) { NegativeLimit.BackColor = Color.Red; } else { NegativeLimit.BackColor = SystemColors.Control; }//Axis01轴负限位
                    if (Program.SystemContainer.IO.Axis01_Home) { HomeSensor.BackColor = Color.Green; } else { HomeSensor.BackColor = SystemColors.Control; }// Axis01轴原点
                    if (Program.SystemContainer.IO.Axis01_Alarm) { DriverAlarm.BackColor = Color.Green; } else { DriverAlarm.BackColor = SystemColors.Control; }//Axis01轴报警
                    if (Program.SystemContainer.IO.Axis01_Alarm_Cl) { AlarmClear.BackColor = Color.Green; } else { AlarmClear.BackColor = SystemColors.Control; }//Axis01轴报警清除
                    if (Program.SystemContainer.IO.Axis01_MC_Err) { BoardAlarm.BackColor = Color.Green; } else { BoardAlarm.BackColor = SystemColors.Control; }//Axis01轴板卡报警(跟随误差越限)
                    if (Program.SystemContainer.IO.Axis01_EN) { ServoON.BackColor = Color.Green; ServoON.Text = "使能打开"; } else { ServoON.BackColor = SystemColors.Control; ServoON.Text = "使能关闭"; }//Axis01轴使能
                    if (Program.SystemContainer.IO.Axis01_Busy) { DriveBusy.BackColor = Color.Green; } else { DriveBusy.BackColor = SystemColors.Control; }//Axis01轴输出中
                                                                                                                                                           //if (Program.SystemContainer.IO.Axis01_IO_Stop  ) { buttonx.BackColor = Color.Green;  } else { buttonx.BackColor = SystemColors.Control; }//Axis01轴IO停止
                                                                                                                                                           //if (Program.SystemContainer.IO.Axis01_IO_EMG) { buttonx.BackColor = Color.Green;  } else { buttonx.BackColor = SystemColors.Control; }//Axis01轴IO急停
                    if (Program.SystemContainer.IO.Axis01_Motor_Posed) { Motor_Posed.BackColor = Color.Green; } else { Motor_Posed.BackColor = SystemColors.Control; }//Axis01轴 Motor到位
                    if (Program.SystemContainer.IO.Axis01_Upper_Posed) { Upper_Posed.BackColor = Color.Green; } else { Upper_Posed.BackColor = SystemColors.Control; }//Axis01轴 Upper到位
                                                                                                                                                                      //规划位置指示
                    CurrentPos.Text = Convert.ToString(Convert.ToDecimal(Program.SystemContainer.IO.Axis01_prfPos) / Program.SystemContainer.SysPara.Gts_Pos_reference);
                    //实际位置指示
                    ActualPos.Text = Convert.ToString(Convert.ToDecimal(Program.SystemContainer.IO.Axis01_encPos) / Program.SystemContainer.SysPara.Gts_Pos_reference);
                    //加速度指示
                    ActualACC.Text = Convert.ToString(Convert.ToDecimal(Program.SystemContainer.IO.Axis01_acc) * Program.SystemContainer.SysPara.Gts_Acc_reference);
                    //减速度指示
                    ActualDCC.Text = Convert.ToString(Convert.ToDecimal(Program.SystemContainer.IO.Axis01_dcc) * Program.SystemContainer.SysPara.Gts_Acc_reference);
                    //速度指示
                    ActualSpeed.Text = Convert.ToString(Convert.ToDecimal(Program.SystemContainer.IO.Axis01_vel) * Program.SystemContainer.SysPara.Gts_Vel_reference);
                    //模式指示
                    switch (Program.SystemContainer.IO.Axis01_mode)
                    {
                        case 0:
                            ActualMode.Text = "点位运动";
                            break;
                        case 1:
                            ActualMode.Text = "Jog模式";
                            break;
                        case 2:
                            ActualMode.Text = "PT模式";
                            break;
                        case 3:
                            ActualMode.Text = "电子齿轮模式";
                            break;
                        case 4:
                            ActualMode.Text = "Follow模式";
                            break;
                        case 5:
                            ActualMode.Text = "插补模式";
                            break;
                        case 6:
                            ActualMode.Text = "Pvt模式";
                            break;
                        default:
                            ActualMode.Text = "  ";
                            break;
                    }
                }
                else if (Axis_No == 2)
                {
                    if (Program.SystemContainer.IO.Axis02_Limit_Up) { PositveLimit.BackColor = Color.Red; } else { PositveLimit.BackColor = SystemColors.Control; }//Axis02轴正限位
                    if (Program.SystemContainer.IO.Axis02_Limit_Down) { NegativeLimit.BackColor = Color.Red; } else { NegativeLimit.BackColor = SystemColors.Control; }//Axis02轴负限位
                    if (Program.SystemContainer.IO.Axis02_Home) { HomeSensor.BackColor = Color.Green; } else { HomeSensor.BackColor = SystemColors.Control; }// Axis02轴原点
                    if (Program.SystemContainer.IO.Axis02_Alarm) { DriverAlarm.BackColor = Color.Green; } else { DriverAlarm.BackColor = SystemColors.Control; }//Axis02轴报警
                    if (Program.SystemContainer.IO.Axis02_Alarm_Cl) { AlarmClear.BackColor = Color.Green; } else { AlarmClear.BackColor = SystemColors.Control; }//Axis02轴报警清除
                    if (Program.SystemContainer.IO.Axis02_MC_Err) { BoardAlarm.BackColor = Color.Green; } else { BoardAlarm.BackColor = SystemColors.Control; }//Axis02轴板卡报警(跟随误差越限)
                    if (Program.SystemContainer.IO.Axis02_EN) { ServoON.BackColor = Color.Green; ServoON.Text = "使能打开"; } else { ServoON.BackColor = SystemColors.Control; ServoON.Text = "使能关闭"; }//Axis02轴使能
                    if (Program.SystemContainer.IO.Axis02_Busy) { DriveBusy.BackColor = Color.Green; } else { DriveBusy.BackColor = SystemColors.Control; }//Axis02轴输出中
                                                                                                                                                           //if (Program.SystemContainer.IO.Axis02_IO_Stop  ) { buttonx.BackColor = Color.Green;  } else { buttonx.BackColor = SystemColors.Control; }//Axis02轴IO停止
                                                                                                                                                           //if (Program.SystemContainer.IO.Axis02_IO_EMG) { buttonx.BackColor = Color.Green;  } else { buttonx.BackColor = SystemColors.Control; }//Axis02轴IO急停
                    if (Program.SystemContainer.IO.Axis02_Motor_Posed) { Motor_Posed.BackColor = Color.Green; } else { Motor_Posed.BackColor = SystemColors.Control; }//Axis02轴 Motor到位
                    if (Program.SystemContainer.IO.Axis02_Upper_Posed) { Upper_Posed.BackColor = Color.Green; } else { Upper_Posed.BackColor = SystemColors.Control; }//Axis02轴 Upper到位

                    //规划位置指示
                    CurrentPos.Text = Convert.ToString(Convert.ToDecimal(Program.SystemContainer.IO.Axis02_prfPos) / Program.SystemContainer.SysPara.Gts_Pos_reference);
                    //实际位置指示
                    ActualPos.Text = Convert.ToString(Convert.ToDecimal(Program.SystemContainer.IO.Axis02_encPos) / Program.SystemContainer.SysPara.Gts_Pos_reference);
                    //加速度指示
                    ActualACC.Text = Convert.ToString(Convert.ToDecimal(Program.SystemContainer.IO.Axis02_acc) * Program.SystemContainer.SysPara.Gts_Acc_reference);
                    //减速度指示
                    ActualDCC.Text = Convert.ToString(Convert.ToDecimal(Program.SystemContainer.IO.Axis02_dcc) * Program.SystemContainer.SysPara.Gts_Acc_reference);
                    //速度指示
                    ActualSpeed.Text = Convert.ToString(Convert.ToDecimal(Program.SystemContainer.IO.Axis02_vel) * Program.SystemContainer.SysPara.Gts_Vel_reference);
                    //模式指示
                    switch (Program.SystemContainer.IO.Axis02_mode)
                    {
                        case 0:
                            ActualMode.Text = "点位运动";
                            break;
                        case 1:
                            ActualMode.Text = "Jog模式";
                            break;
                        case 2:
                            ActualMode.Text = "PT模式";
                            break;
                        case 3:
                            ActualMode.Text = "电子齿轮模式";
                            break;
                        case 4:
                            ActualMode.Text = "Follow模式";
                            break;
                        case 5:
                            ActualMode.Text = "插补模式";
                            break;
                        case 6:
                            ActualMode.Text = "Pvt模式";
                            break;
                        default:
                            ActualMode.Text = "  ";
                            break;
                    }
                }
                //点动/连动模式按钮指示
                if (Point_Con == 0) { JogDot.Text = "连动模式"; } else { JogDot.Text = "点动模式"; };
                //标题操作指示
                if (Axis_No == 1) { gtsManual.Caption = "X轴手动操作"; } else if (Axis_No == 2) { gtsManual.Caption = "Y轴手动操作"; } else { gtsManual.Caption = "平台手动操作"; };
        
            });
        }
        /// <summary>
        /// 板卡复位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GtsReset_Click(object sender, EventArgs e)
        {
            Program.SystemContainer.GTS_Fun.Reset();
        }
        /// <summary>
        /// JOG+ 按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JogPositive_MouseDown(object sender, MouseEventArgs e)
        {
            if (Axis_No == 1)
            {
                if (Program.SystemContainer.IO.Axis01_EN)
                {
                    if (Point_Con == 0)//连动模式
                    {
                        Program.SystemContainer.GTS_Fun.Jog(Axis_No, 0, mannualVel, acc, dcc);
                    }
                    else//点动模式
                    {
                        Program.SystemContainer.GTS_Fun.Inc(Axis_No, acc, dcc, 20, step, mannualVel);
                    }
                }
            }
            else if (Axis_No == 2)
            {
                if (Program.SystemContainer.IO.Axis02_EN)
                {
                    if (Point_Con == 0)//连动模式
                    {
                        Program.SystemContainer.GTS_Fun.Jog(Axis_No, 0, mannualVel, acc, dcc);
                    }
                    else//点动模式
                    {
                        Program.SystemContainer.GTS_Fun.Inc(Axis_No, acc, dcc, 20, step, mannualVel);
                    }
                }
            }
        }
        /// <summary>
        /// JOG+ 抬起
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JogPositive_MouseUp(object sender, MouseEventArgs e)
        {
            Program.SystemContainer.GTS_Fun.SmoothStop(Axis_No); ;//停止轴
        }
        /// <summary>
        /// JOG- 按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JogNegative_MouseDown(object sender, MouseEventArgs e)
        {
            if (Axis_No == 1)
            {
                if (Program.SystemContainer.IO.Axis01_EN)
                {
                    if (Point_Con == 0)//连动模式
                    {
                        Program.SystemContainer.GTS_Fun.Jog(Axis_No, 1, mannualVel, acc, dcc);
                    }
                    else//点动模式
                    {
                        Program.SystemContainer.GTS_Fun.Inc(Axis_No, acc, dcc, 20, -step, mannualVel);
                    }
                }
            }
            else if (Axis_No == 2)
            {
                if (Program.SystemContainer.IO.Axis02_EN)
                {
                    if (Point_Con == 0)//连动模式
                    {
                        Program.SystemContainer.GTS_Fun.Jog(Axis_No, 1, mannualVel, acc, dcc);
                    }
                    else//点动模式
                    {
                        Program.SystemContainer.GTS_Fun.Inc(Axis_No, acc, dcc, 20, -step, mannualVel);
                    }
                }
            }
        }

        /// <summary>
        /// jog- 抬起
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JogNegative_MouseUp(object sender, MouseEventArgs e)
        {
            Program.SystemContainer.GTS_Fun.SmoothStop(Axis_No); ;//停止轴
        }
        /// <summary>
        /// 轴报警清除 按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AlarmClear_MouseDown(object sender, MouseEventArgs e)
        {
            if (Axis_No == 1)
            {
                Program.SystemContainer.GTS_Fun.AlarmClearON(Axis_No);
            }
            else if (Axis_No == 2)
            {
                Program.SystemContainer.GTS_Fun.AlarmClearON(Axis_No);
            }

        }
        /// <summary>
        /// 轴报警清除 抬起
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AlarmClear_MouseUp(object sender, MouseEventArgs e)
        {
            if (Axis_No == 1)
            {
                Program.SystemContainer.GTS_Fun.AlarmClearOFF(Axis_No);
            }
            else if (Axis_No == 2)
            {
                Program.SystemContainer.GTS_Fun.AlarmClearOFF(Axis_No);
            }
        }
        /// <summary>
        /// 伺服使能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ServoON_Click(object sender, EventArgs e)
        {
            if (Axis_No == 1)
            {
                if (Program.SystemContainer.IO.Axis01_EN)
                {
                    //伺服使能 OFF
                    Program.SystemContainer.GTS_Fun.AxisOFF(Axis_No);
                }
                else
                {
                    //伺服使能 ON
                    Program.SystemContainer.GTS_Fun.AxisON(Axis_No);
                }
            }
            else if (Axis_No == 2)
            {
                if (Program.SystemContainer.IO.Axis02_EN)
                {
                    //伺服使能 OFF
                    Program.SystemContainer.GTS_Fun.AxisOFF(Axis_No);
                }
                else
                {
                    //伺服使能 ON
                    Program.SystemContainer.GTS_Fun.AxisON(Axis_No);
                }
            }
        }
        /// <summary>
        /// 轴状态清除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StatusClear_Click(object sender, EventArgs e)
        {
            Program.SystemContainer.GTS_Fun.StatusClear(Axis_No);
        }
        /// <summary>
        /// 轴位置清零
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PosClear_Click(object sender, EventArgs e)
        {
            Program.SystemContainer.GTS_Fun.PosClear(Axis_No);
        }
        /// <summary>
        /// 点动和连动切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JogDot_Click(object sender, EventArgs e)
        {
            if (Point_Con == 0)
            {
                Point_Con = 1;//切换至点动
            }
            else
            {
                Point_Con = 0;//切换至连动
            }
        }
        /// <summary>
        /// 机械回零
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MechanicHome_Click(object sender, EventArgs e)
        {
            Thread home_thread = new Thread(this.Home_Thread);
            home_thread.Start();
        }
        /// <summary>
        /// 机械回零线程
        /// </summary>
        private void Home_Thread()
        {
            if (Axis_No == 1)
            {
                if (Program.SystemContainer.IO.Axis01_EN)
                {
                    if (Program.SystemContainer.GTS_Fun.Axis01_Home_Down_Motor() == 0)
                    {
                        MessageBox.Show("X轴归零完成！！！");
                    }
                    else
                    {
                        MessageBox.Show("X轴归零失败！！！");
                    }
                }
            }
            else if (Axis_No == 2)
            {
                if (Program.SystemContainer.IO.Axis02_EN)
                {
                    if (Program.SystemContainer.GTS_Fun.Axis02_Home_Down_Motor() == 0)
                    {
                        MessageBox.Show("Y轴归零完成！！！");
                    }
                    else
                    {
                        MessageBox.Show("Y轴归零失败！！！");
                    }
                }
            }
        }

        /// <summary>
        /// 平滑停止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SmoothStop_Click(object sender, EventArgs e)
        {
            Program.SystemContainer.GTS_Fun.SmoothStop(Axis_No);
        }
        /// <summary>
        /// 轴紧急停止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmgStop_Click(object sender, EventArgs e)
        {
            Program.SystemContainer.GTS_Fun.EmgStop(Axis_No);
        }
        /// <summary>
        /// 切换轴
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AxisSelect_ValueChanged(object sender, EventArgs e)
        {
            Axis_No = Convert.ToInt16(AxisSelect.Value);
        }
        /// <summary>
        /// 手动加速度修正
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManualACC_TextChanged(object sender, EventArgs e)
        {
            if (!decimal.TryParse(ManualACC.Text, out decimal tmp))
            {
                MessageBox.Show("请正确输入数字");
                return;
            }
            acc = tmp;
        }
        /// <summary>
        /// 手动减速度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManualDCC_TextChanged(object sender, EventArgs e)
        {           
            if (!decimal.TryParse(ManualDCC.Text, out decimal tmp))
            {
                MessageBox.Show("请正确输入数字");
                return;
            }
            dcc = tmp;
        }
        /// <summary>
        /// 步长
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManualStep_TextChanged(object sender, EventArgs e)
        {
            if (!decimal.TryParse(ManualStep.Text, out decimal tmp))
            {
                MessageBox.Show("请正确输入数字");
                return;
            }
            step = tmp;
        }
        /// <summary>
        /// 手动速度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManualSpeed_TextChanged(object sender, EventArgs e)
        {
            if (!decimal.TryParse(ManualSpeed.Text, out decimal tmp))
            {
                MessageBox.Show("请正确输入数字");
                return;
            }
            mannualVel = (tmp);
        }
        /// <summary>
        /// 回零速度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HomeSpeed_TextChanged(object sender, EventArgs e)
        {
            if (!decimal.TryParse(HomeSpeed.Text, out decimal tmp))
            {
                MessageBox.Show("请正确输入数字");
                return;
            }
            Program.SystemContainer.SysPara.Home_High_Speed = tmp;
        }
        /// <summary>
        /// 回零加速度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HomeACC_TextChanged(object sender, EventArgs e)
        {
            if (!decimal.TryParse(HomeACC.Text, out decimal tmp))
            {
                MessageBox.Show("请正确输入数字");
                return;
            }
            Program.SystemContainer.SysPara.Home_acc = tmp;
        }
        /// <summary>
        /// 回零减速度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HomeDCC_TextChanged(object sender, EventArgs e)
        {
            if (!decimal.TryParse(HomeDCC.Text, out decimal tmp))
            {
                MessageBox.Show("请正确输入数字");
                return;
            }
            Program.SystemContainer.SysPara.Home_dcc = tmp;
          
        }
        /// <summary>
        /// 回零平滑时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HomeSmoothTime_TextChanged(object sender, EventArgs e)
        {
            if (!Int16.TryParse(HomeSmoothTime.Text, out Int16 tmp))
            {
                MessageBox.Show("请正确输入数字");
                return;
            }
            Program.SystemContainer.SysPara.Home_smoothTime = tmp;
        }
        /// <summary>
        /// 原点偏移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HomeDeviation_TextChanged(object sender, EventArgs e)
        {
            if (!decimal.TryParse(HomeDeviation.Text, out decimal tmp))
            {
                MessageBox.Show("请正确输入数字");
                return;
            }
            Program.SystemContainer.SysPara.Home_OffSet = tmp;
        }
    }
}

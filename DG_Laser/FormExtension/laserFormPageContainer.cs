using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DG_Laser
{
    /// <summary>
    /// 激光控制页面
    /// </summary>
    partial class MainForm
    {
        bool WRFlag = false;//读写标志
        bool LaserParaWRFlag = false;//手动调试参数变量读写标志
        bool LCLoadFlag = false;
        /// <summary>
        /// 激光页面初始化数据
        /// </summary>
        private void laserFormPageContainerInitial()
        {
            LaserControlInitial();//激光控制初始化
            LaserWattInitial();//激光功率检测初始化
            Thread.Sleep(30);
        }
        /// <summary>
        /// 主界面激光操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LaserOperateButton_Click(object sender, EventArgs e)
        {
            LaserOperateButton.Enabled = false;//禁用主页面激光操作按钮    
            LaserReady = false;
            if (!Program.SystemContainer.Laser_Control_Com.Open)//激光串口未打开
            {
                MessageBox.Show("激光器控制串口未打开，请进入激光页面，打开正确的串口");
                LaserOperateButton.Enabled = true;//启用主页面激光操作按钮
                return;
            }
            //检测是否开启机关控制电源
            //读取状态
            Program.SystemContainer.Laser_Operation_00.Read("00", "0F");
            //PowerOn
            if ((Program.SystemContainer.Laser_Operation_00.Resolve_Rec.StatusD1 & 0x01) == 0)
            {
                MessageBox.Show("激光器电源未打开！！！");
                LaserOperateButton.Enabled = true;//启用主页面激光操作按钮
                return;
            }
            //Key Switch
            if ((Program.SystemContainer.Laser_Operation_00.Resolve_Rec.StatusD1 & (1 << 2)) == 0)
            {
                MessageBox.Show("激光器未插入钥匙！！！");
                LaserOperateButton.Enabled = true;//启用主页面激光操作按钮
                return;
            }
            ////检测电流
            //decimal Seed_Current = 0;//Seed电流
            //decimal Amp1_Current = 0;//Amp1电流
            //decimal Amp2_Current = 0;//Amp2电流 
            ////读取Seed电流
            //Program.SystemContainer.Laser_Operation_00.Read("00", "12");
            //Seed_Current = Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num / 100m;
            ////读取Amp1电流
            //Program.SystemContainer.Laser_Operation_00.Read("01", "12");
            //Amp1_Current = Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num / 100m;
            ////读取Amp2电流
            //Program.SystemContainer.Laser_Operation_00.Read("02", "12");
            //Amp2_Current = Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num / 100m;
            //判断分支进程
            if (LaserOperateButton.Text != "激光器Ready")//激光器未准备OK
            {
                //进入开机程序
                Thread LC_Power_On_Thread = new Thread(LC_Power_On_Thread_Fun);
                LC_Power_On_Thread.Start();
            }
            else
            {
                //进入关机程序
                Thread LC_Power_Off_Thread = new Thread(LC_Power_Off_Thread_Fun);
                LC_Power_Off_Thread.Start();
            }
        }
        /**********************************************************/
        /// <summary>
        /// 激光控制初始化
        /// </summary>
        private void LaserControlInitial()
        {
            LCLoadFlag = true;
            //状态
            LC_Status.AppendText("Running" + "\r\n");
            LC_Status.AppendText("PowerOn" + "\r\n");
            LC_Status.AppendText("Shutter Enabled" + "\r\n");
            LC_Status.AppendText("Key Switch On" + "\r\n");
            LC_Status.AppendText("LDD On" + "\r\n");
            LC_Status.AppendText("QSW On" + "\r\n");
            LC_Status.AppendText("Shutter Interlock" + "\r\n");
            LC_Status.AppendText("LDD Interlock" + "\r\n");
            //电流
            LC_Seed_Current.Text = "0.00";
            LC_Amp1_Current.Text = "0.00";
            LC_Amp2_Current.Text = "0.00";            
            
            RefreshLaserHandlePara();//刷新激光页参数数据
            //绑定事件
            LC_Seed_SetnumericUpDown.ValueChanged += UpdateLaserHandlePara;
            LC_Amp1_SetnumericUpDown.ValueChanged += UpdateLaserHandlePara;
            LC_Amp2_SetnumericUpDown.ValueChanged += UpdateLaserHandlePara;
            LC_PEC_Set_ValuenumericUpDown.ValueChanged += UpdateLaserHandlePara;
            LC_PRF_Set_ValuenumericUpDown.ValueChanged += UpdateLaserHandlePara;
            //初始化通讯端口列表
            LC_Com_List.Items.AddRange(Program.SystemContainer.Laser_Control_Com.PortName.ToArray());
            //初始化默认的Com端口
            if ((Program.SystemContainer.Laser_Control_Com.PortName.Count >= 1) && (Program.SystemContainer.SysPara.Laser_Control_Com_No < Program.SystemContainer.Laser_Control_Com.PortName.Count)) LC_Com_List.SelectedIndex = Program.SystemContainer.SysPara.Laser_Control_Com_No;
            
            //状态刷新
            if (!Program.SystemContainer.Laser_Control_Com.Open)
            {
                LC_Re_connect.Text = "打开串口";
                LC_Com_Status.BackgroundImage = Properties.Resources.red;
                //按钮禁用
                LC_Power_OFF.Enabled = false;
                LC_Power_On.Enabled = false;
                LC_Refresh_Status.Enabled = false;
                LC_Reset_Laser.Enabled = false;
                LC_PEC_Confirm.Enabled = false;
                LC_PRF_Confirm.Enabled = false;
            }
            else
            {
                //按钮启用
                LC_Power_OFF.Enabled = true;
                LC_Power_On.Enabled = true;
                LC_Refresh_Status.Enabled = true;
                LC_Reset_Laser.Enabled = true;
                LC_PEC_Confirm.Enabled = true;
                LC_PRF_Confirm.Enabled = true;
                LC_Re_connect.Text = "关闭串口";
                LC_Com_Status.BackgroundImage = Properties.Resources.green;
                //刷新状态
                Refresh_All_Status();
            }
            LCLoadFlag = false;
        }
        /// <summary>
        /// 刷新激光页参数值
        /// </summary>
        private void RefreshLaserHandlePara()
        {
            //设定电流值
            LaserParaWRFlag = true;
            Thread.Sleep(30);
            //变更值
            LC_Seed_SetnumericUpDown.Value = Program.SystemContainer.SysPara.Seed_Current;
            LC_Amp1_SetnumericUpDown.Value = Program.SystemContainer.SysPara.Amp1_Current;
            LC_Amp2_SetnumericUpDown.Value = Program.SystemContainer.SysPara.Amp2_Current;
            LC_PEC_Set_ValuenumericUpDown.Value = Program.SystemContainer.SysPara.PEC;
            LC_PRF_Set_ValuenumericUpDown.Value = Program.SystemContainer.SysPara.PRF;//单位KHz
            SeedTemperaturenumericUpDown.Value = Program.SystemContainer.SysPara.Seed_Temperature;//Seed温度 单位摄氏度
            AmpTemperaturenumericUpDown.Value = Program.SystemContainer.SysPara.Amp_Temperature;//Amp温度 单位摄氏度
            Thread.Sleep(30);
            LaserParaWRFlag = false;
        }
        /// <summary>
        /// 设置激光手动参数
        /// </summary>
        private void UpdateLaserHandlePara(object sender, EventArgs e)
        {
            if (LaserParaWRFlag) return;
            Program.SystemContainer.SysPara.Seed_Current = LC_Seed_SetnumericUpDown.Value;
            Program.SystemContainer.SysPara.Amp1_Current = LC_Amp1_SetnumericUpDown.Value;
            Program.SystemContainer.SysPara.Amp2_Current = LC_Amp2_SetnumericUpDown.Value;
            Program.SystemContainer.SysPara.PEC = LC_PEC_Set_ValuenumericUpDown.Value;
            Program.SystemContainer.SysPara.PRF = LC_PRF_Set_ValuenumericUpDown.Value;//单位KHz
            Program.SystemContainer.SysPara.Seed_Temperature = SeedTemperaturenumericUpDown.Value;//Seed温度 单位摄氏度
            Program.SystemContainer.SysPara.Amp_Temperature = AmpTemperaturenumericUpDown.Value;//Amp温度 单位摄氏度
        }
        /// <summary>
        /// 更新激光控制串口列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LC_Refresh_List_Click(object sender, EventArgs e)
        {
            //刷新列表
            Program.SystemContainer.Laser_Control_Com.Refresh_Com_List();
            //初始化通讯端口列表
            LC_Com_List.Items.Clear();
            LC_Com_List.Items.AddRange(Program.SystemContainer.Laser_Control_Com.PortName.ToArray());
        }
        /// <summary>
        /// 开关串口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LC_Re_connect_Click(object sender, EventArgs e)
        {
            if (Program.SystemContainer.SysPara.Laser_Control_Com_No < Program.SystemContainer.Laser_Control_Com.PortName.Count)
            {
                ChangeLCComONOFF();
            }
            else
            {
                LaserReady = false;
                MessageBox.Show("激光控制器通讯串口端口编号异常，请在激光控制面板选择正确的串口编号！！！");
                return;
            }
        }
        /// <summary>
        /// 改变激光控制端口号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LC_Com_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LCLoadFlag) return;
            if (Program.SystemContainer.Laser_Control_Com.Open == true)
            {
                ChangeLCComONOFF();
            }
            Program.SystemContainer.SysPara.Laser_Control_Com_No = LC_Com_List.SelectedIndex;
        }
        /// <summary>
        /// 切换激光串口开关
        /// </summary>
        private void ChangeLCComONOFF()
        {
            if (Program.SystemContainer.Laser_Control_Com.Open_Com(Program.SystemContainer.SysPara.Laser_Control_Com_No))
            {
                //按钮启用
                LC_Power_OFF.Enabled = true;
                LC_Power_On.Enabled = true;
                LC_Refresh_Status.Enabled = true;
                LC_Reset_Laser.Enabled = true;
                LC_PEC_Confirm.Enabled = true;
                LC_PRF_Confirm.Enabled = true;
                //状态刷新
                LC_Re_connect.Text = "关闭串口";
                LC_Com_Status.BackgroundImage = Properties.Resources.green;
            }
            else
            {
                //按钮禁用
                LC_Power_OFF.Enabled = false;
                LC_Power_On.Enabled = false;
                LC_Refresh_Status.Enabled = false;
                LC_Reset_Laser.Enabled = false;
                LC_PEC_Confirm.Enabled = false;
                LC_PRF_Confirm.Enabled = false;
                //状态刷新
                LC_Re_connect.Text = "打开串口";
                LC_Com_Status.BackgroundImage = Properties.Resources.red;
                //激光准备状态
                LaserReady = false;
            }
        }
        /// <summary>
        /// 一键开机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LC_Power_On_Click(object sender, EventArgs e)
        {
            Thread LC_Power_On_Thread = new Thread(LC_Power_On_Thread_Fun);
            LC_Power_On_Thread.Start();
        }
        /// <summary>
        /// 一键关机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LC_Power_OFF_Click(object sender, EventArgs e)
        {
            Thread LC_Power_Off_Thread = new Thread(LC_Power_Off_Thread_Fun);
            LC_Power_Off_Thread.Start();
        }
        /// <summary>
        /// 状态刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LC_Refresh_Status_Click(object sender, EventArgs e)
        {
            Refresh_All_Status();
        }
        /// <summary>
        /// 复位激光控制器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LC_Reset_Laser_Click(object sender, EventArgs e)
        {
            if (WRFlag) return;
            WRFlag = true;
            //复位
            Program.SystemContainer.Laser_Operation_00.Write("00", "07", "");
            WRFlag = false;
        }
        /// <summary>
        /// 功率写入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LC_PEC_Confirm_Click(object sender, EventArgs e)
        {
            if (WRFlag) return;
            WRFlag = true;
            Program.SystemContainer.Laser_Operation_00.Change_Pec(Program.SystemContainer.SysPara.PEC);
            WRFlag = false;
        }
        /// <summary>
        /// 频率写入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LC_PRF_Confirm_Click(object sender, EventArgs e)
        {
            if (WRFlag) return;
            WRFlag = true;
            Program.SystemContainer.Laser_Operation_00.Write("00", "21", Program.SystemContainer.Laser_Operation_00.PRF_To_Str((UInt32)(Program.SystemContainer.SysPara.PRF * 1000)));
            WRFlag = false;
        }
        /// <summary>
        /// 一键开机功能
        /// </summary>
        private void LC_Power_On_Thread_Fun() 
        {
            LaserReady = false;
            if (LC_One_Key_ON())
            {
                this.Invoke((EventHandler)delegate
                {
                    LC_Power_On.Enabled = false;//禁用一键开机按钮
                    LC_Power_OFF.Enabled = true;//启用一键关机按钮
                    LC_Refresh_Status.Enabled = true;//启用状态更新按钮
                    LC_Reset_Laser.Enabled = true;//启用复位按钮
                    LC_PEC_Confirm.Enabled = true;//启用功率写入按钮
                    LC_PRF_Confirm.Enabled = true;//启用频率写入按钮
                    LC_Re_connect.Enabled = true;//启用串口开关按钮
                    LaserOperateButton.Enabled = true;//主界面操作按钮启用
                    LaserOperateButton.Text = "激光器Ready";
                    LaserOperateButton.ForeColor = Color.Green;
                });
                LaserReady = true;
            }
            else
            {
                this.Invoke((EventHandler)delegate
                {
                    LC_Power_On.Enabled = true;//启用一键开机按钮
                    LC_Power_OFF.Enabled = false;//禁用一键关机按钮
                    LC_Refresh_Status.Enabled = true;//启用状态更新按钮
                    LC_Reset_Laser.Enabled = true;//启用复位按钮
                    LC_PEC_Confirm.Enabled = true;//启用功率写入按钮
                    LC_PRF_Confirm.Enabled = true;//启用频率写入按钮
                    LC_Re_connect.Enabled = true;//启用串口开关按钮
                    LaserOperateButton.Enabled = true;//主界面操作按钮启用
                    LaserOperateButton.Text = "激光器初始化";
                    LaserOperateButton.ForeColor = Color.Black;
                });                
            }            
        }
        /// <summary>
        /// 一键关机功能
        /// </summary>
        private void LC_Power_Off_Thread_Fun()
        {
            LaserReady = false;
            if (LC_One_Key_OFF())
            {
                this.Invoke((EventHandler)delegate
                {
                    LC_Power_On.Enabled = true;//启用一键开机按钮
                    LC_Power_OFF.Enabled = false;//禁用一键关机按钮
                    LC_Refresh_Status.Enabled = true;//启用状态更新按钮
                    LC_Reset_Laser.Enabled = true;//启用复位按钮
                    LC_PEC_Confirm.Enabled = true;//启用功率写入按钮
                    LC_PRF_Confirm.Enabled = true;//启用频率写入按钮
                    LC_Re_connect.Enabled = true;//启用串口开关按钮
                    LaserOperateButton.Enabled = true;//主界面操作按钮启用
                    LaserOperateButton.Text = "激光器关闭";
                    LaserOperateButton.ForeColor = Color.Black;
                });
            }
            else
            {
                this.Invoke((EventHandler)delegate
                {
                    LC_Power_On.Enabled = false;//禁用一键开机按钮
                    LC_Power_OFF.Enabled = true;//启用一键关机按钮
                    LC_Refresh_Status.Enabled = true;//启用状态更新按钮
                    LC_Reset_Laser.Enabled = true;//启用复位按钮
                    LC_PEC_Confirm.Enabled = true;//启用功率写入按钮
                    LC_PRF_Confirm.Enabled = true;//启用频率写入按钮
                    LC_Re_connect.Enabled = true;//启用串口开关按钮
                    LaserOperateButton.Enabled = true;//主界面操作按钮启用
                    LaserOperateButton.Text = "激光器关闭失败";
                    LaserOperateButton.ForeColor = Color.Black;
                });
            }
        }

        /// <summary>
        /// 一键开机 程序
        /// </summary>
        /// <returns></returns>
        private bool LC_One_Key_ON()
        {
            //状态变量
            decimal Seed_Current = 0;//Seed电流
            decimal Amp1_Current = 0;//Amp1电流
            decimal Amp2_Current = 0;//Amp2电流 
            byte Status = 0x00;
            //按钮状态
            this.Invoke((EventHandler) delegate
            {
                LC_Power_On.Enabled = false;//禁用一键开机按钮
                LC_Power_OFF.Enabled = false;//禁用一键关机按钮
                LC_Refresh_Status.Enabled = false;//禁用状态更新按钮
                LC_Reset_Laser.Enabled = false;//禁用复位按钮
                LC_PEC_Confirm.Enabled = false;//禁用功率写入按钮
                LC_PRF_Confirm.Enabled = false;//禁用频率写入按钮
                LC_Re_connect.Enabled = false;//禁用串口开关按钮
                LaserOperateButton.Text = "激光器开机中";
                LaserOperateButton.ForeColor = Color.Black;
            });

            /**************Seed Ldd***************/
            //读取Seed电流
            Program.SystemContainer.Laser_Operation_00.Read("00", "12");
            Seed_Current = (Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num / 100m);
            //打开Seed Ldd
            if (Seed_Current < 0.2m) Program.SystemContainer.Laser_Operation_00.Write("00", "10", "01");
            //状态判断
            Task.Factory.StartNew(() =>
            {
                do
                {
                    //打开Seed Ldd
                    //if (Seed_Current < 0.2m) Program.SystemContainer.Laser_Operation_00.Write("00", "10", "01");
                    Thread.Sleep(300);//等待300ms
                    //读取Seed电流
                    Program.SystemContainer.Laser_Operation_00.Read("00", "12");
                    Seed_Current = (Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num / 100m);
                    this.Invoke((EventHandler)delegate
                    {
                        //更新Seed电流
                        LC_Seed_Current.Text = Seed_Current.ToString();
                    });                    
                } while ((Program.SystemContainer.SysPara.Seed_Current - Seed_Current) > 0.02m);
            }).Wait(120 * 1000);//2 * 1000,ms,该时间范围内：代码段完成 或 超出该时间范围 返回并继续向下执行
            //读取Seed电流
            Program.SystemContainer.Laser_Operation_00.Read("00", "12");
            Seed_Current = (Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num / 100m);
            if ((Program.SystemContainer.SysPara.Seed_Current - Seed_Current) > 0.02m) return false;
            //等待1500ms
            Thread.Sleep(1500);

            /**************Seed Shutter Status***************/
            //读取Seed Shutter
            Program.SystemContainer.Laser_Operation_00.Read("00", "04");
            Status = (byte)Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num;
            //打开Seed Shutter
            if (!Bit_Value.GetBitValue(Status, 0)) Program.SystemContainer.Laser_Operation_00.Write("00", "04", "01");
            Task.Factory.StartNew(() =>
            {
                do
                {
                    //打开Seed Shutter
                    //if (!Bit_Value.GetBitValue(Status, 0)) Program.SystemContainer.Laser_Operation_00.Write("00", "04", "01");
                    Thread.Sleep(300);//等待300ms
                    //读取Seed Shutter
                    Program.SystemContainer.Laser_Operation_00.Read("00", "04");
                    Status = (byte)Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num;
                } while (!Bit_Value.GetBitValue(Status, 0));
            }).Wait(5 * 1000);//2 * 1000,ms,该时间范围内：代码段完成 或 超出该时间范围 返回并继续向下执行
            //读取Seed Shutter
            Program.SystemContainer.Laser_Operation_00.Read("00", "04");
            Status = (byte)Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num;
            if (!Bit_Value.GetBitValue(Status, 0)) return false;
            //等待1500ms
            Thread.Sleep(1500);

            /**************PP Pulse Status***************/
            //读取PP Pulse
            Program.SystemContainer.Laser_Operation_00.Read("00", "65");
            Status = (byte)Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num;
            //打开PP Pulse
            if (!Bit_Value.GetBitValue(Status, 0)) Program.SystemContainer.Laser_Operation_00.Write("00", "65", "01");
            Task.Factory.StartNew(() =>
            {
                do
                {
                    //打开PP Pulse
                    //if (!Bit_Value.GetBitValue(Status, 0)) Program.SystemContainer.Laser_Operation_00.Write("00", "65", "01");
                    Thread.Sleep(300);//等待300ms
                    //读取PP Pulse
                    Program.SystemContainer.Laser_Operation_00.Read("00", "65");
                    Status = (byte)Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num;
                } while (!Bit_Value.GetBitValue(Status, 0));

            }).Wait(5 * 1000);//2 * 1000,ms,该时间范围内：代码段完成 或 超出该时间范围 返回并继续向下执行
            //读取PP Pulse
            Program.SystemContainer.Laser_Operation_00.Read("00", "65");
            Status = (byte)Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num;
            if (!Bit_Value.GetBitValue(Status, 0)) return false;
            //等待1500ms
            Thread.Sleep(1500);

            /**************AOM Pulse Status***************/
            //读取AOM Pulse
            Program.SystemContainer.Laser_Operation_00.Read("00", "66");
            Status = (byte)Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num;
            //打开AOM Pulse
            if (!Bit_Value.GetBitValue(Status, 0)) Program.SystemContainer.Laser_Operation_00.Write("00", "66", "01");
            Task.Factory.StartNew(() =>
            {
                do
                {
                    //打开AOM Pulse
                    //if (!Bit_Value.GetBitValue(Status, 0)) Program.SystemContainer.Laser_Operation_00.Write("00", "66", "01");
                    Thread.Sleep(300);//等待300ms
                    //读取AOM Pulse
                    Program.SystemContainer.Laser_Operation_00.Read("00", "66");
                    Status = (byte)Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num;
                } while (!Bit_Value.GetBitValue(Status, 0));

            }).Wait(5 * 1000);//2 * 1000,ms,该时间范围内：代码段完成 或 超出该时间范围 返回并继续向下执行
            //读取AOM Pulse
            Program.SystemContainer.Laser_Operation_00.Read("00", "66");
            Status = (byte)Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num;
            if (!Bit_Value.GetBitValue(Status, 0)) return false;
            //等待1500ms
            Thread.Sleep(1500);

            /**************AMP1 Ldd***************/
            //读取AMP1电流
            Program.SystemContainer.Laser_Operation_00.Read("01", "12");
            Amp1_Current = (Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num / 100m);
            //打开AMP1 Ldd
            if (Amp1_Current < 0.2m) Program.SystemContainer.Laser_Operation_00.Write("01", "10", "01");
            Task.Factory.StartNew(() =>
            {
                do
                {
                    //打开AMP1 Ldd
                    //if (Amp1_Current < 0.2m) Program.SystemContainer.Laser_Operation_00.Write("01", "10", "01");
                    Thread.Sleep(300);//等待300ms
                    //读取AMP1电流
                    Program.SystemContainer.Laser_Operation_00.Read("01", "12");
                    Amp1_Current = (Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num / 100m);
                    this.Invoke((EventHandler)delegate
                    {
                        //更新Amp1电流
                        LC_Amp1_Current.Text = Amp1_Current.ToString();
                    });                    
                } while ((Program.SystemContainer.SysPara.Amp1_Current - Amp1_Current) > 0.02m);
            }).Wait(120 * 1000);//2 * 1000,ms,该时间范围内：代码段完成 或 超出该时间范围 返回并继续向下执行
            //读取AMP1电流
            Program.SystemContainer.Laser_Operation_00.Read("01", "12");
            Amp1_Current = (Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num / 100m);
            if ((Program.SystemContainer.SysPara.Amp1_Current - Amp1_Current) > 0.02m) return false;
            //等待1500ms
            Thread.Sleep(1500);

            /**************AMP1 Shutter Status***************/
            //读取AMP1 Shutter
            Program.SystemContainer.Laser_Operation_00.Read("01", "04");
            Status = (byte)Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num;
            //打开AMP1 Shutter
            if (!Bit_Value.GetBitValue(Status, 0)) Program.SystemContainer.Laser_Operation_00.Write("01", "04", "01");
            Task.Factory.StartNew(() =>
            {
                do
                {
                    //打开AMP1 Shutter
                    //if (!Bit_Value.GetBitValue(Status, 0)) Program.SystemContainer.Laser_Operation_00.Write("01", "04", "01");
                    Thread.Sleep(300);//等待300ms
                    //读取AMP1 Shutter
                    Program.SystemContainer.Laser_Operation_00.Read("01", "04");
                    Status = (byte)Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num;
                } while (!Bit_Value.GetBitValue(Status, 0));

            }).Wait(5 * 1000);//2 * 1000,ms,该时间范围内：代码段完成 或 超出该时间范围 返回并继续向下执行
            //读取AMP1 Shutter
            Program.SystemContainer.Laser_Operation_00.Read("01", "04");
            Status = (byte)Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num;
            if (!Bit_Value.GetBitValue(Status, 0)) return false;
            //等待1500ms
            Thread.Sleep(1500);

            /**************AMP2 Ldd***************/
            //读取AMP2电流
            Program.SystemContainer.Laser_Operation_00.Read("02", "12");
            Amp2_Current = (Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num / 100m);
            //打开AMP2 Ldd
            if (Amp2_Current < 0.2m) Program.SystemContainer.Laser_Operation_00.Write("02", "10", "01");
            Task.Factory.StartNew(() =>
            {
                do
                {
                    //打开AMP2 Ldd
                    //if (Amp2_Current < 0.2m) Program.SystemContainer.Laser_Operation_00.Write("02", "10", "01");
                    Thread.Sleep(300);//等待300ms
                    //读取AMP2电流
                    Program.SystemContainer.Laser_Operation_00.Read("02", "12");
                    Amp2_Current = (Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num / 100m);
                    this.Invoke((EventHandler)delegate
                    {
                        //更新Amp2电流
                        LC_Amp2_Current.Text = Amp2_Current.ToString();
                    });
                                      
                } while ((Program.SystemContainer.SysPara.Amp2_Current - Amp2_Current) > 0.02m);
            }).Wait(120 * 1000);//2 * 1000,ms,该时间范围内：代码段完成 或 超出该时间范围 返回并继续向下执行
            //读取AMP2电流
            Program.SystemContainer.Laser_Operation_00.Read("02", "12");
            Amp2_Current = (Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num / 100m);
            if ((Program.SystemContainer.SysPara.Amp2_Current - Amp2_Current) > 0.02m) return false;
            //等待1500ms
            Thread.Sleep(1500);

            //更新文本状态框
            RefreshTextBox();

            //返回True
            return true;
        }
        /// <summary>
        /// 一键关机程序
        /// </summary>
        /// <returns></returns>
        private bool LC_One_Key_OFF()
        {
            //状态变量
            decimal Seed_Current = 0;//Seed电流
            decimal Amp1_Current = 0;//Amp1电流
            decimal Amp2_Current = 0;//Amp2电流 
            byte Status = 0x00;
            //按钮禁用
            this.Invoke((EventHandler)delegate
            {
                LC_Power_On.Enabled = false;//禁用一键开机按钮
                LC_Power_OFF.Enabled = false;//禁用一键关机按钮
                LC_Refresh_Status.Enabled = false;//禁用状态更新按钮
                LC_Reset_Laser.Enabled = false;//禁用复位按钮
                LC_PEC_Confirm.Enabled = false;//禁用功率写入按钮
                LC_PRF_Confirm.Enabled = false;//禁用频率写入按钮
                LC_Re_connect.Enabled = false;//禁用串口开关按钮
                LaserOperateButton.Text = "激光器关闭中";
                LaserOperateButton.ForeColor = Color.Black;
            });
            /**************AMP2 Ldd***************/
            //读取AMP2电流
            Program.SystemContainer.Laser_Operation_00.Read("02", "12");
            Amp2_Current = (Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num / 100m);
            //关闭AMP2 Ldd
            if (Amp2_Current > 0.02m) Program.SystemContainer.Laser_Operation_00.Write("02", "10", "00");
            Task.Factory.StartNew(() =>
            {
                do
                {
                    //关闭AMP2 Ldd
                    //if (Amp2_Current > 0.02m) Program.SystemContainer.Laser_Operation_00.Write("02", "10", "00");
                    Thread.Sleep(300);//等待500ms
                    //读取AMP2电流
                    Program.SystemContainer.Laser_Operation_00.Read("02", "12");
                    Amp2_Current = (Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num / 100m);
                    this.Invoke((EventHandler)delegate
                    {
                        //更新Amp2电流
                        LC_Amp2_Current.Text = Amp2_Current.ToString();
                    });
                } while (Amp2_Current > 0.02m);
            }).Wait(120 * 1000);//2 * 1000,ms,该时间范围内：代码段完成 或 超出该时间范围 返回并继续向下执行
            //读取AMP2电流
            Program.SystemContainer.Laser_Operation_00.Read("02", "12");
            Amp2_Current = (Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num / 100m);
            if (Amp2_Current > 0.02m) return false;
            //等待1500ms
            Thread.Sleep(1500);

            /**************AMP1 Ldd***************/
            //读取AMP1电流
            Program.SystemContainer.Laser_Operation_00.Read("01", "12");
            Amp1_Current = (Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num / 100m);
            //关闭AMP1 Ldd
            if (Amp1_Current > 0.04m) Program.SystemContainer.Laser_Operation_00.Write("01", "10", "00");
            Task.Factory.StartNew(() =>
            {
                do
                {
                    //关闭AMP1 Ldd
                    //if (Amp1_Current > 0.04m) Program.SystemContainer.Laser_Operation_00.Write("01", "10", "00");
                    Thread.Sleep(300);//等待300ms
                    //读取AMP1电流
                    Program.SystemContainer.Laser_Operation_00.Read("01", "12");
                    Amp1_Current = (Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num / 100m);
                    this.Invoke((EventHandler)delegate
                    {
                        //更新Amp1电流
                        LC_Amp1_Current.Text = Amp1_Current.ToString();
                    });                                        
                } while (Amp1_Current > 0.04m);
            }).Wait(120 * 1000);//2 * 1000,ms,该时间范围内：代码段完成 或 超出该时间范围 返回并继续向下执行
            //读取AMP1电流
            Program.SystemContainer.Laser_Operation_00.Read("01", "12");
            Amp1_Current = (Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num / 100m);
            if (Amp1_Current > 0.04m) return false;
            //等待1500ms
            Thread.Sleep(1500);

            /**************AOM Pulse Status***************/
            //读取AOM Pulse
            Program.SystemContainer.Laser_Operation_00.Read("00", "66");
            Status = (byte)Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num;
            //关闭AOM Pulse
            if (Bit_Value.GetBitValue(Status, 0)) Program.SystemContainer.Laser_Operation_00.Write("00", "66", "00");
            Task.Factory.StartNew(() =>
            {
                do
                {
                    //关闭AOM Pulse
                    //if (Bit_Value.GetBitValue(Status, 0)) Program.SystemContainer.Laser_Operation_00.Write("00", "66", "00");
                    Thread.Sleep(300);//等待300ms
                    //读取AOM Pulse
                    Program.SystemContainer.Laser_Operation_00.Read("00", "66");
                    Status = (byte)Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num;
                } while (Bit_Value.GetBitValue(Status, 0));
            }).Wait(5 * 1000);//2 * 1000,ms,该时间范围内：代码段完成 或 超出该时间范围 返回并继续向下执行
            //读取AOM Pulse
            Program.SystemContainer.Laser_Operation_00.Read("00", "66");
            Status = (byte)Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num;
            if (Bit_Value.GetBitValue(Status, 0)) return false;
            //等待1500ms
            Thread.Sleep(1500);

            /**************PP Pulse Status***************/
            //读取PP Pulse
            Program.SystemContainer.Laser_Operation_00.Read("00", "65");
            Status = (byte)Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num;
            //关闭PP Pulse
            if (Bit_Value.GetBitValue(Status, 0)) Program.SystemContainer.Laser_Operation_00.Write("00", "65", "00");
            Task.Factory.StartNew(() =>
            {
                do
                {
                    //关闭PP Pulse
                    //if (Bit_Value.GetBitValue(Status, 0)) Program.SystemContainer.Laser_Operation_00.Write("00", "65", "00");
                    Thread.Sleep(300);//等待300ms
                    //读取PP Pulse
                    Program.SystemContainer.Laser_Operation_00.Read("00", "65");
                    Status = (byte)Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num;
                } while (Bit_Value.GetBitValue(Status, 0));
            }).Wait(5 * 1000);//2 * 1000,ms,该时间范围内：代码段完成 或 超出该时间范围 返回并继续向下执行
            //读取PP Pulse
            Program.SystemContainer.Laser_Operation_00.Read("00", "65");
            Status = (byte)Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num;
            if (Bit_Value.GetBitValue(Status, 0)) return false;
            //等待1500ms
            Thread.Sleep(1500);

            /**************Seed Shutter Status***************/
            //读取Seed Shutter
            Program.SystemContainer.Laser_Operation_00.Read("00", "04");
            Status = (byte)Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num;
            //关闭Seed Shutter
            if (Bit_Value.GetBitValue(Status, 0)) Program.SystemContainer.Laser_Operation_00.Write("00", "04", "00");
            Task.Factory.StartNew(() =>
            {
                do
                {
                    //关闭Seed Shutter
                    //if (Bit_Value.GetBitValue(Status, 0)) Program.SystemContainer.Laser_Operation_00.Write("00", "04", "00");
                    Thread.Sleep(300);//等待300ms
                    //读取Seed Shutter
                    Program.SystemContainer.Laser_Operation_00.Read("00", "04");
                    Status = (byte)Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num;
                } while (Bit_Value.GetBitValue(Status, 0));
            }).Wait(5 * 1000);//2 * 1000,ms,该时间范围内：代码段完成 或 超出该时间范围 返回并继续向下执行
            //读取Seed Shutter
            Program.SystemContainer.Laser_Operation_00.Read("00", "04");
            Status = (byte)Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num;
            if (Bit_Value.GetBitValue(Status, 0)) return false;
            //等待1500ms
            Thread.Sleep(1500);

            /**************Seed Ldd***************/
            //读取Seed电流
            Program.SystemContainer.Laser_Operation_00.Read("00", "12");
            Seed_Current = (Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num / 100m);
            //关闭Seed Ldd
            if (Seed_Current > 0.12m) Program.SystemContainer.Laser_Operation_00.Write("00", "10", "00");
            //状态判断
            Task.Factory.StartNew(() =>
            {
                do
                {
                    //关闭Seed Ldd
                    //if (Seed_Current > 0.12m) Program.SystemContainer.Laser_Operation_00.Write("00", "10", "00");
                    Thread.Sleep(300);//等待300ms
                    //读取Seed电流
                    Program.SystemContainer.Laser_Operation_00.Read("00", "12");
                    Seed_Current = (Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num / 100m);
                    this.Invoke((EventHandler)delegate
                    {
                        //更新Seed电流
                        LC_Seed_Current.Text = Seed_Current.ToString();
                    });                                    
                } while (Seed_Current > 0.12m);
            }).Wait(120 * 1000);//2 * 1000,ms,该时间范围内：代码段完成 或 超出该时间范围 返回并继续向下执行
            //读取Seed电流
            Program.SystemContainer.Laser_Operation_00.Read("00", "12");
            Seed_Current = (Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num / 100m);
            if (Seed_Current > 0.12m) return false;

            //等待1500ms
            Thread.Sleep(1500);

            //更新文本状态框
            RefreshTextBox();

            //返回True
            return true;
        }
        /// <summary>
        /// 状态刷新
        /// </summary>
        private void Refresh_All_Status()
        {
            this.Invoke((EventHandler)delegate
            {
                //置位读写标志
                if (WRFlag) return;
                WRFlag = true;
                //检测电流
                decimal Seed_Current = 0;//Seed电流
                decimal Amp1_Current = 0;//Amp1电流
                decimal Amp2_Current = 0;//Amp2电流 
                LC_Reset_Laser.Enabled = false;
                //读取Seed电流
                Program.SystemContainer.Laser_Operation_00.Read("00", "12");
                Seed_Current = Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num / 100m;
                LC_Seed_Current.Text = Seed_Current.ToString();
                //读取Amp1电流
                Program.SystemContainer.Laser_Operation_00.Read("01", "12");
                Amp1_Current = Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num / 100m;
                LC_Amp1_Current.Text = Amp1_Current.ToString();
                //读取Amp2电流
                Program.SystemContainer.Laser_Operation_00.Read("02", "12");
                Amp2_Current = Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num / 100m;
                LC_Amp2_Current.Text = Amp2_Current.ToString();
                //读取Seed温度
                Program.SystemContainer.Laser_Operation_00.Read("00", "32");
                decimal Seed_Temperature = Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num / 100m;
                LC_SeedTemperatureTextbox.Text = Seed_Temperature.ToString();
                //读取AMP温度
                Program.SystemContainer.Laser_Operation_00.Read("01", "32");
                decimal Amp_Temperature = Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num / 100m;
                LC_AmpTemperatureTextbox.Text = Amp_Temperature.ToString();
                //更新文本状态框
                RefreshTextBox();
                //清除标志
                WRFlag = false;
                LC_Reset_Laser.Enabled = true;
                //判断电流状态
                if ((Math.Abs(Program.SystemContainer.SysPara.Seed_Current - Seed_Current) > 1) ||
                    (Math.Abs(Program.SystemContainer.SysPara.Amp1_Current - Amp1_Current) > 1) ||
                    (Math.Abs(Program.SystemContainer.SysPara.Amp2_Current - Amp2_Current) > 1))
                {
                    //判断是否激光准备OK
                    LaserReady = false;
                    LaserOperateButton.Enabled = true;//主界面操作按钮启用
                    LaserOperateButton.Text = "激光器初始化";
                    LaserOperateButton.ForeColor = Color.Black;
                }
                else
                {
                    //判断是否激光准备OK
                    LaserReady = true;
                    LaserOperateButton.Enabled = true;//主界面操作按钮启用
                    LaserOperateButton.Text = "激光器Ready";
                    LaserOperateButton.ForeColor = Color.Green;
                }                
            });
        }
        /// <summary>
        /// 刷新文本状态框
        /// </summary>
        private void RefreshTextBox()
        {
            this.Invoke((EventHandler)delegate
            {
                //读取PEC功率值
                Program.SystemContainer.Laser_Operation_00.Read("00", "55");
                if (((Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num / 10m) > LC_PEC_Set_ValuenumericUpDown.Minimum) && ((Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num / 10m) < LC_PEC_Set_ValuenumericUpDown.Maximum))
                    LC_PEC_Set_ValuenumericUpDown.Value = Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num / 10m;
                //读取PRF频率值
                Program.SystemContainer.Laser_Operation_00.Read("00", "21");
                if (((Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num / 1000m) > LC_PRF_Set_ValuenumericUpDown.Minimum) && ((Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num / 1000m) < LC_PRF_Set_ValuenumericUpDown.Maximum))
                    LC_PRF_Set_ValuenumericUpDown.Value = Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num / 1000m;
                //读取状态
                Program.SystemContainer.Laser_Operation_00.Read("00", "0F");
                //PowerOn
                if ((Program.SystemContainer.Laser_Operation_00.Resolve_Rec.StatusD1 & 0x01) != 0)
                {
                    ChangeKeyColor("PowerOn", Color.Green);
                }
                else
                {
                    ChangeKeyColor("PowerOn", Color.Red);
                }
                //Shuter Enabled
                if ((Program.SystemContainer.Laser_Operation_00.Resolve_Rec.StatusD1 & (1 << 1)) != 0)
                {
                    ChangeKeyColor("Shutter Enabled", Color.Green);
                }
                else
                {
                    ChangeKeyColor("Shutter Enabled", Color.Red);
                }
                //Key Switch
                if ((Program.SystemContainer.Laser_Operation_00.Resolve_Rec.StatusD1 & (1 << 2)) != 0)
                {
                    ChangeKeyColor("Key Switch On", Color.Green);
                }
                else
                {
                    ChangeKeyColor("Key Switch On", Color.Red);
                }
                //LDD On
                if ((Program.SystemContainer.Laser_Operation_00.Resolve_Rec.StatusD1 & (1 << 3)) != 0)
                {
                    ChangeKeyColor("LDD On", Color.Green);
                }
                else
                {
                    ChangeKeyColor("LDD On", Color.Red);
                }
                //QSW On
                if ((Program.SystemContainer.Laser_Operation_00.Resolve_Rec.StatusD1 & (1 << 4)) != 0)
                {
                    ChangeKeyColor("QSW On", Color.Green);
                }
                else
                {
                    ChangeKeyColor("QSW On", Color.Red);
                }
                //Shutter Interlock
                if ((Program.SystemContainer.Laser_Operation_00.Resolve_Rec.StatusD1 & (1 << 5)) != 0)
                {
                    ChangeKeyColor("Shutter Interlock", Color.Green);
                }
                else
                {
                    ChangeKeyColor("Shutter Interlock", Color.Red);
                }
                //LDD Interlock
                if ((Program.SystemContainer.Laser_Operation_00.Resolve_Rec.StatusD1 & (1 << 6)) != 0)
                {
                    ChangeKeyColor("LDD Interlock", Color.Green);
                }
                else
                {
                    ChangeKeyColor("LDD Interlock", Color.Red);
                }
            });
        }
        /// <summary>
        /// 更换指定文本颜色
        /// </summary>
        /// <param name="key"></param>
        /// <param name="color"></param>
        public void ChangeKeyColor(string key, Color color)
        {
            this.Invoke((EventHandler)delegate
            {
                Regex regex = new Regex(key);
                //找出内容中所有的要替换的关键字
                MatchCollection collection = regex.Matches(LC_Status.Text);
                //对所有的要替换颜色的关键字逐个替换颜色    
                foreach (Match match in collection)
                {
                    //开始位置、长度、颜色缺一不可
                    LC_Status.SelectionStart = match.Index;
                    LC_Status.SelectionLength = key.Length;
                    LC_Status.SelectionColor = color;
                }
            });
        }
        
        
        /*******************************激光功率计**********************************/
        System.Timers.Timer LW_Refresh_Timer = new System.Timers.Timer(200);//1s刷新一次
        DataTable Laser_Watt_Percent_Data = new DataTable();
        bool LWLoadFlag = false;
        /// <summary>
        /// 激光功率监测初始化
        /// </summary>
        private void LaserWattInitial()
        {
            LWLoadFlag = true;
            Thread.Sleep(200);
            //初始化通讯端口列表
            LW_Com_List.Items.AddRange(Program.SystemContainer.Laser_Watt_Com.PortName.ToArray());
            LW_PEC_Indicate.Text = Program.SystemContainer.SysPara.PEC.ToString();
            //初始化默认的Com端口
            if ((Program.SystemContainer.Laser_Watt_Com.PortName.Count >= 1) && (Program.SystemContainer.SysPara.Laser_Watt_Com_No < Program.SystemContainer.Laser_Watt_Com.PortName.Count)) LW_Com_List.SelectedIndex = Program.SystemContainer.SysPara.Laser_Watt_Com_No;
            if (Program.SystemContainer.Laser_Watt_Com.Open == false)
            {
                LW_Re_Connect.Text = "打开串口";
                LW_Com_Status.BackgroundImage = Properties.Resources.red;
            }
            else
            {
                LW_Re_Connect.Text = "关闭串口";
                LW_Com_Status.BackgroundImage = Properties.Resources.green;
            }
            Laser_Watt_Percent_Data.Columns.Add("激光输出百分比(%)", typeof(decimal));
            Laser_Watt_Percent_Data.Columns.Add("激光功率计显示功率(mw)", typeof(decimal));
            Laser_Watt_Percent_Data.Columns.Add("激光实际功率(mw)", typeof(decimal));
            //启用定时器
            LW_Refresh_Timer.Elapsed += Display_Watt;
            LW_Refresh_Timer.AutoReset = true;
            LW_Refresh_Timer.Enabled = true;
            LW_Refresh_Timer.Start();
            LWLoadFlag = false;

        }
        /// <summary>
        /// 切换激光功率串口开关
        /// </summary>
        private void ChangeLWComONOFF()
        {
            if (Program.SystemContainer.Laser_Watt_Com.Open_Com(Program.SystemContainer.SysPara.Laser_Watt_Com_No, 3))
            {
                LW_Acquisition_Once.Enabled = true;
                //状态刷新
                LW_Re_Connect.Text = "关闭串口";
                LW_Com_Status.BackgroundImage = Properties.Resources.green;
            }
            else
            {
                LW_Acquisition_Once.Enabled = false;
                //状态刷新
                LW_Re_Connect.Text = "打开串口";
                LW_Com_Status.BackgroundImage = Properties.Resources.red;             
            }
        }
        /// <summary>
        /// 激光功率
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LW_Refresh_List_Click(object sender, EventArgs e)
        {
            //刷新列表
            Program.SystemContainer.Laser_Watt_Com.Refresh_Com_List();
            //初始化通讯端口列表
            LW_Com_List.Items.Clear();
            LW_Com_List.Items.AddRange(Program.SystemContainer.Laser_Watt_Com.PortName.ToArray());
        }
        /// <summary>
        /// 更换通讯端口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LW_Com_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LWLoadFlag) return;
            if (Program.SystemContainer.Laser_Watt_Com.Open)
            {
                ChangeLWComONOFF();
            }
            Program.SystemContainer.SysPara.Laser_Watt_Com_No = LW_Com_List.SelectedIndex;
        }
        /// <summary>
        /// 激光功率串口连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LW_Re_Connect_Click(object sender, EventArgs e)
        {
            if (Program.SystemContainer.SysPara.Laser_Watt_Com_No < Program.SystemContainer.Laser_Watt_Com.PortName.Count)
            {
                ChangeLWComONOFF();
            }
            else
            {
                MessageBox.Show("激光功率计通讯串口端口编号异常，请在激光功率计面板选择正确的串口编号！！！");
                return;
            }
        }
        /// <summary>
        /// 采集一次数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LW_Acquisition_Once_Click(object sender, EventArgs e)
        {
            Laser_Watt_Percent_Data.Rows.Add(new object[] { Program.SystemContainer.SysPara.PEC, Program.SystemContainer.Laser_Watt_00.Current_Watt, Laser_Watt_Cal.Watt_To_Watt(Program.SystemContainer.Laser_Watt_00.Current_Watt / 1000m) * 1000m });
        }
        /// <summary>
        /// 保存采集数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LW_Save_Data_Click(object sender, EventArgs e)
        {
            CSV_RW.Save(Laser_Watt_Percent_Data, "Laser_PEC_Watt_Data.csv");
        }
        /// <summary>
        /// 实时功率刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Display_Watt(object sender, EventArgs e)
        {
            if (this.IsHandleCreated) this.Invoke((EventHandler)delegate
            {
                LW_Watt_Indicate.Text = Laser_Watt_Cal.Watt_To_Watt(Program.SystemContainer.Laser_Watt_00.Current_Watt / 1000m).ToString(6);
                LW_PEC_Indicate.Text = Program.SystemContainer.SysPara.PEC.ToString(6);
            });
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DG_Laser
{
    /// <summary>
    /// RTC手动操作页面
    /// </summary>
    partial class MainForm
    {
        //定义变量
        decimal Distence_X = 20;
        decimal Distence_Y = 20;
        decimal Abs_X = 20;
        decimal Abs_Y = 20;
        //定义移动方式
        UInt16 Control_Type = 4;//4-jump,6-mark
        /// <summary>
        /// 手动RTC初始化
        /// </summary>
        private void manualRTCInitial()
        {
            MoveX.Text = Convert.ToString(Distence_X);
            MoveY.Text = Convert.ToString(Distence_Y);
            RtcHomeX.Text = Convert.ToString(Program.SystemContainer.SysPara.Rtc_Home.X);
            RtcHomeY.Text = Convert.ToString(Program.SystemContainer.SysPara.Rtc_Home.Y);
            ABSPosX.Text = Convert.ToString(Abs_X);
            ABSPosY.Text = Convert.ToString(Abs_Y);
            RtcPosReference.Text = Convert.ToString(Program.SystemContainer.SysPara.Rtc_Pos_Reference);
            Mark_Speed.Text = Program.SystemContainer.SysPara.Mark_Speed.ToString();
            Jump_Speed.Text = Program.SystemContainer.SysPara.Jump_Speed.ToString();
            Laser_ON_Delay.Text = Program.SystemContainer.SysPara.Laser_On_Delay.ToString();
            Laser_Off_Delay.Text = Program.SystemContainer.SysPara.Laser_Off_Delay.ToString();
            Jump_Delay.Text = Program.SystemContainer.SysPara.Jump_Delay.ToString();
            Mark_Delay.Text = Program.SystemContainer.SysPara.Mark_Delay.ToString();
            Polygon_Delay.Text = Program.SystemContainer.SysPara.Polygon_Delay.ToString();
            RefreshAutoDelaySwitch();//刷新自动校正按钮文本
            refreshMode();
        }
        /// <summary>
        /// 定位Home
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RtcHome_Click(object sender, EventArgs e)
        {
            Program.SystemContainer.RTC_Fun.Home();
        }
        /// <summary>
        /// 绝对定位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ABSPos_Click(object sender, EventArgs e)
        {
            Program.SystemContainer.RTC_Fun.Abs_XY(Abs_X, Abs_Y, Control_Type, 1);
        }
        /// <summary>
        /// 模式切换文字刷新
        /// </summary>
        private void refreshMode()
        {
            if (Control_Type == 4)
            {
                MoveMode.Text = "Jump";
            }
            else if (Control_Type == 6)
            {
                MoveMode.Text = "Mark";
            }
        }
        /// <summary>
        /// 切换模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveMode_Click(object sender, EventArgs e)
        {
            if (Control_Type == 4)
            {
                Control_Type = 6;
            }
            else if (Control_Type == 6)
            {
                Control_Type = 4;
            }
            else
            {
                Control_Type = 4;
            }
            refreshMode();
        }
        /// <summary>
        /// X+
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RtcXJogPositive_Click(object sender, EventArgs e)
        {
            Program.SystemContainer.RTC_Fun.Inc_X(Distence_X, Control_Type, 1);
        }
        /// <summary>
        /// x-
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RtcXJogNegative_Click(object sender, EventArgs e)
        {
            Program.SystemContainer.RTC_Fun.Inc_X(-Distence_X, Control_Type, 1);
        }
        /// <summary>
        /// Y+
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RtcYJogPositive_Click(object sender, EventArgs e)
        {
            Program.SystemContainer.RTC_Fun.Inc_Y(Distence_Y, Control_Type, 1);
        }
        /// <summary>
        /// Y-
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RtcYJogNegative_Click(object sender, EventArgs e)
        {
            Program.SystemContainer.RTC_Fun.Inc_Y(-Distence_Y, Control_Type, 1);
        }
        /// <summary>
        /// 参数生效
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Change_Para_List_Click(object sender, EventArgs e)
        {
            Program.SystemContainer.RTC_Fun.Change_Para();
        }
        /// <summary>
        /// 激光开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LaserON_Click(object sender, EventArgs e)
        {
            Program.SystemContainer.RTC_Fun.Open_Laser();
        }
        /// <summary>
        /// 激光关
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void LaserOFF_Click(object sender, EventArgs e)
        {
            Program.SystemContainer.RTC_Fun.Close_Laser();
        }
        /// <summary>
        /// 延时自动校正切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AutoDelaySwitch_Click(object sender, EventArgs e)
        {
            Program.SystemContainer.SysPara.RtcAutoDelayCorrect = !Program.SystemContainer.SysPara.RtcAutoDelayCorrect;
            RefreshAutoDelaySwitch();//刷新自动校正按钮文本
        }
        /// <summary>
        /// 刷新自动校正按钮文本
        /// </summary>
        private void RefreshAutoDelaySwitch()
        {
            if (Program.SystemContainer.SysPara.RtcAutoDelayCorrect)
            {
                AutoDelaySwitch.Text = "自动延时校正ON";
            }
            else
            {
                AutoDelaySwitch.Text = "自动延时校正OFF";
            }
        }
        /// <summary>
        /// 复位RTC控制卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Reset_Rtc_Click(object sender, EventArgs e)
        {
            Program.SystemContainer.RTC_Fun.Load_Correct_File(Program.SystemContainer.SysPara.RtcAutoDelayCorrect);
        }
        /// <summary>
        /// HomeX
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RtcHomeX_TextChanged(object sender, EventArgs e)
        {
            if (!decimal.TryParse(RtcHomeX.Text, out decimal tmp))
            {
                MessageBox.Show("请正确输入数字");
                return;
            }
            Program.SystemContainer.SysPara.Rtc_Home = new Vector(tmp, Program.SystemContainer.SysPara.Rtc_Home.Y);
        }
        /// <summary>
        /// HomeY
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void RtcHomeY_TextChanged(object sender, EventArgs e)
        {
            if (!decimal.TryParse(RtcHomeY.Text, out decimal tmp))
            {
                MessageBox.Show("请正确输入数字");
                return;
            }
            Program.SystemContainer.SysPara.Rtc_Home = new Vector(Program.SystemContainer.SysPara.Rtc_Home.X,tmp);
        }

        /// <summary>
        /// AbsX
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ABSPosX_TextChanged(object sender, EventArgs e)
        {
            if (!decimal.TryParse(ABSPosX.Text, out Abs_X))
            {
                MessageBox.Show("请正确输入数字");
                return;
            }
        }
        /// <summary>
        /// AbsY
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ABSPosY_TextChanged(object sender, EventArgs e)
        {
            if (!decimal.TryParse(ABSPosY.Text, out Abs_Y))
            {
                MessageBox.Show("请正确输入数字");
                return;
            }
        }
        /// <summary>
        /// MoveX
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveX_TextChanged(object sender, EventArgs e)
        {
            if (!decimal.TryParse(MoveX.Text, out Distence_X))
            {
                MessageBox.Show("请正确输入数字");
                return;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveY_TextChanged(object sender, EventArgs e)
        {
            if (!decimal.TryParse(MoveY.Text, out Distence_Y))
            {
                MessageBox.Show("请正确输入数字");
                return;
            }
        }
        /// <summary>
        /// Mark_Speed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mark_Speed_TextChanged(object sender, EventArgs e)
        {
            if (!double.TryParse(Mark_Speed.Text, out double tem))
            {
                MessageBox.Show("请正确输入数字");
                return;
            }
            Program.SystemContainer.SysPara.Mark_Speed = tem;
        }
        /// <summary>
        /// Laser_ON_Delay
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Laser_ON_Delay_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(Laser_ON_Delay.Text, out int tem))
            {
                MessageBox.Show("请正确输入数字");
                return;
            }
            Program.SystemContainer.SysPara.Laser_On_Delay = tem;
        }
        /// <summary>
        /// Laser_Off_Delay
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Laser_Off_Delay_TextChanged(object sender, EventArgs e)
        {
            if (!uint.TryParse(Laser_Off_Delay.Text, out uint tem))
            {
                MessageBox.Show("请正确输入数字");
                return;
            }
            Program.SystemContainer.SysPara.Laser_Off_Delay = tem;
        }
        /// <summary>
        /// Polygon_Delay
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Polygon_Delay_TextChanged(object sender, EventArgs e)
        {
            if (!uint.TryParse(Polygon_Delay.Text, out uint tem))
            {
                MessageBox.Show("请正确输入数字");
                return;
            }
            Program.SystemContainer.SysPara.Polygon_Delay = tem;
        }
        /// <summary>
        /// Jump_Speed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Jump_Speed_TextChanged(object sender, EventArgs e)
        {
            if (!double.TryParse(Jump_Speed.Text, out double tem))
            {
                MessageBox.Show("请正确输入数字");
                return;
            }
            Program.SystemContainer.SysPara.Jump_Speed = tem;
        }
        /// <summary>
        /// Jump_Delay
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Jump_Delay_TextChanged(object sender, EventArgs e)
        {
            if (!uint.TryParse(Jump_Delay.Text, out uint tem))
            {
                MessageBox.Show("请正确输入数字");
                return;
            }
            Program.SystemContainer.SysPara.Jump_Delay = tem;
        }
        /// <summary>
        /// Mark_Delay
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mark_Delay_TextChanged(object sender, EventArgs e)
        {
            if (!uint.TryParse(Mark_Delay.Text, out uint tem))
            {
                MessageBox.Show("请正确输入数字");
                return;
            }
            Program.SystemContainer.SysPara.Mark_Delay = tem;
        }
        /// <summary>
        /// RtcPosReference
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RtcPosReference_TextChanged(object sender, EventArgs e)
        {
            if (!decimal.TryParse(RtcPosReference.Text, out decimal tem))
            {
                MessageBox.Show("请正确输入数字");
                return;
            }
            Program.SystemContainer.SysPara.Rtc_Pos_Reference = tem;
        }
    }
}

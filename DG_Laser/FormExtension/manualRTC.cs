using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        bool RTCMannualFlag = false;
        //定义移动方式
        UInt16 Control_Type = 4;//4-jump,6-mark
        /// <summary>
        /// 手动RTC初始化
        /// </summary>
        private void manualRTCInitial()
        {
            RefreshRtcPara();//更新RTC页面参数
            //绑定事件
            RtcHomeXnumericUpDown.ValueChanged += UpdateRtcPara;
            RtcHomeYnumericUpDown.ValueChanged += UpdateRtcPara;
            ABSPosYnumericUpDown.ValueChanged += UpdateRtcPara;
            ABSPosXnumericUpDown.ValueChanged += UpdateRtcPara;
            MoveXnumericUpDown.ValueChanged += UpdateRtcPara;
            MoveYnumericUpDown.ValueChanged += UpdateRtcPara;
            Mark_SpeednumericUpDown.ValueChanged += UpdateRtcPara;
            Jump_SpeednumericUpDown.ValueChanged += UpdateRtcPara;
            Laser_ON_DelaynumericUpDown.ValueChanged += UpdateRtcPara;
            Laser_Off_DelaynumericUpDown.ValueChanged += UpdateRtcPara;
            Jump_DelaynumericUpDown.ValueChanged += UpdateRtcPara;
            Mark_DelaynumericUpDown.ValueChanged += UpdateRtcPara;
            Polygon_DelaynumericUpDown.ValueChanged += UpdateRtcPara;
            RtcPosReferencenumericUpDown.ValueChanged += UpdateRtcPara;
        }
        /// <summary>
        /// 更新RTC页面参数
        /// </summary>
        private void RefreshRtcPara()
        {
            RTCMannualFlag = true;
            Thread.Sleep(30);
            RtcHomeXnumericUpDown.Value = Program.SystemContainer.SysPara.Rtc_Home.X;
            RtcHomeYnumericUpDown.Value = Program.SystemContainer.SysPara.Rtc_Home.Y;
            ABSPosYnumericUpDown.Value = Abs_X;
            ABSPosXnumericUpDown.Value = Abs_Y;
            MoveXnumericUpDown.Value = Distence_X;
            MoveYnumericUpDown.Value = Distence_Y;
            Mark_SpeednumericUpDown.Value = (decimal)Program.SystemContainer.SysPara.Mark_Speed;
            Jump_SpeednumericUpDown.Value = (decimal)Program.SystemContainer.SysPara.Jump_Speed;
            Laser_ON_DelaynumericUpDown.Value = Program.SystemContainer.SysPara.Laser_On_Delay;
            Laser_Off_DelaynumericUpDown.Value = Program.SystemContainer.SysPara.Laser_Off_Delay;
            Jump_DelaynumericUpDown.Value = Program.SystemContainer.SysPara.Jump_Delay;
            Mark_DelaynumericUpDown.Value = Program.SystemContainer.SysPara.Mark_Delay;
            Polygon_DelaynumericUpDown.Value = Program.SystemContainer.SysPara.Polygon_Delay;
            RtcPosReferencenumericUpDown.Value = Program.SystemContainer.SysPara.Rtc_Pos_Reference;
            Txt_RtcFilename.Text = Program.SystemContainer.SysPara.RtcCt5CorrectFilePath;//振镜矫正文件目录
            RefreshAutoDelaySwitch();//刷新自动校正按钮文本
            refreshMode();
            Thread.Sleep(30);
            RTCMannualFlag = false;
        }
        /// <summary>
        /// 保存修改数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateRtcPara(object sender, EventArgs e)
        {
            if (RTCMannualFlag) return;
            Program.SystemContainer.SysPara.Rtc_Home.X = RtcHomeXnumericUpDown.Value;
            Program.SystemContainer.SysPara.Rtc_Home.Y = RtcHomeYnumericUpDown.Value;
            Abs_X = ABSPosYnumericUpDown.Value;
            Abs_Y = ABSPosXnumericUpDown.Value;
            Distence_X = MoveXnumericUpDown.Value;
            Distence_Y = MoveYnumericUpDown.Value;
            Program.SystemContainer.SysPara.Mark_Speed = (double)Mark_SpeednumericUpDown.Value;
            Program.SystemContainer.SysPara.Jump_Speed = (double)Jump_SpeednumericUpDown.Value;
            Program.SystemContainer.SysPara.Laser_On_Delay = Laser_ON_DelaynumericUpDown.Value;
            Program.SystemContainer.SysPara.Laser_Off_Delay = Laser_Off_DelaynumericUpDown.Value;
            Program.SystemContainer.SysPara.Jump_Delay = Jump_DelaynumericUpDown.Value;
            Program.SystemContainer.SysPara.Mark_Delay = Mark_DelaynumericUpDown.Value;
            Program.SystemContainer.SysPara.Polygon_Delay = Polygon_DelaynumericUpDown.Value;
            Program.SystemContainer.SysPara.Rtc_Pos_Reference = RtcPosReferencenumericUpDown.Value;
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
        /// 选择振镜校准文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Rtc_openFile_Click(object sender, EventArgs e)
        {
            // 获取文件名       
            OpenFileDialog openfile = new OpenFileDialog
            {
                Filter = "ct5 文件(*.ct5)|*.ct5"
            };
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                Program.SystemContainer.SysPara.RtcCt5CorrectFilePath = openfile.FileName;
                Program.SystemContainer.SysPara.RtcCt5CorrectFile = System.IO.Path.GetFileName(openfile.FileName);
                Txt_RtcFilename.Text = Program.SystemContainer.SysPara.RtcCt5CorrectFilePath;
            }
        }
        /// <summary>
        /// 振镜校准文件生效
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Rtc_Use_Click(object sender, EventArgs e)
        {
            if (Program.SystemContainer.RTC_Fun.Load_CorrectFile(Program.SystemContainer.SysPara.RtcCt5CorrectFilePath))
            {
                MessageBox.Show("振镜校准文件加载成功！！！");
            }
            else
            {
                MessageBox.Show("振镜校准文件加载失败！！！");
            }
        }
    }
}

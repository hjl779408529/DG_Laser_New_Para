using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace DG_Laser
{
     /// <summary>
     /// 状态指示页面
     /// </summary>
    partial class MainForm
    {
        //定义IO_Monitor窗口刷新定时器
        System.Timers.Timer IO_Monitor_Timer = new System.Timers.Timer(200);
        /// <summary>
        /// 状态刷新页面初始化
        /// </summary>
        private void statusFormPageContainerInitial()
        {
            //启用定时器
            IO_Monitor_Timer.Elapsed += IO_Monitor_Timer_Elapsed;
            IO_Monitor_Timer.AutoReset = true;
            IO_Monitor_Timer.Enabled = true;
            IO_Monitor_Timer.Start();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IO_Monitor_Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if(this.IsHandleCreated) this.Invoke((EventHandler)delegate
            {
                if (Program.SystemContainer.IO.EXI1) { EXI1_Status.BackColor = Color.Green; } else { EXI1_Status.BackColor = SystemColors.Control; }//急停开关
                if (Program.SystemContainer.IO.EXI2) { EXI2_Status.BackColor = Color.Green; } else { EXI2_Status.BackColor = SystemColors.Control; }//除尘气缸伸出传感器
                if (Program.SystemContainer.IO.EXI3) { EXI3_Status.BackColor = Color.Green; } else { EXI3_Status.BackColor = SystemColors.Control; }//除尘气缸退回传感器
                if (Program.SystemContainer.IO.EXI4) { EXI4_Status.BackColor = Color.Green; } else { EXI4_Status.BackColor = SystemColors.Control; }//左门禁传感器
                if (Program.SystemContainer.IO.EXI5) { EXI5_Status.BackColor = Color.Green; } else { EXI5_Status.BackColor = SystemColors.Control; }//右门禁传感器
                if (Program.SystemContainer.IO.EXI6) { EXI6_Status.BackColor = Color.Green; } else { EXI6_Status.BackColor = SystemColors.Control; }//启动按钮1
                if (Program.SystemContainer.IO.EXI7) { EXI7_Status.BackColor = Color.Green; } else { EXI7_Status.BackColor = SystemColors.Control; }//启动按钮2
                if (Program.SystemContainer.IO.Gts_Home_Flag) { Homed_Status.BackColor = Color.Green; } else { Homed_Status.BackColor = SystemColors.Control; }//XY均已归零
                if (Program.SystemContainer.IO.EXO1) { EXO1_Status.BackColor = Color.Green; } else { EXO1_Status.BackColor = SystemColors.Control; }//三色灯塔黄
                if (Program.SystemContainer.IO.EXO2) { EXO2_Status.BackColor = Color.Green; } else { EXO2_Status.BackColor = SystemColors.Control; }//三色灯塔绿
                if (Program.SystemContainer.IO.EXO3) { EXO3_Status.BackColor = Color.Green; } else { EXO3_Status.BackColor = SystemColors.Control; }//三色灯塔红
                if (Program.SystemContainer.IO.EXO4) { EXO4_Status.BackColor = Color.Green; } else { EXO4_Status.BackColor = SystemColors.Control; }//蜂鸣器
                if (Program.SystemContainer.IO.EXO5) { EXO5_Status.BackColor = Color.Green; } else { EXO5_Status.BackColor = SystemColors.Control; }//除尘气缸伸出
                if (Program.SystemContainer.IO.EXO6) { EXO6_Status.BackColor = Color.Green; } else { EXO6_Status.BackColor = SystemColors.Control; }//除尘气缸退回
                if (Program.SystemContainer.IO.EXO7) { EXO7_Status.BackColor = Color.Green; } else { EXO7_Status.BackColor = SystemColors.Control; }//吹气打开
                if (Program.SystemContainer.IO.EXO8) { EXO8_Status.BackColor = Color.Green; } else { EXO8_Status.BackColor = SystemColors.Control; }//照明灯
                if (Program.SystemContainer.IO.EXO9) { EXO9_Status.BackColor = Color.Green; } else { EXO9_Status.BackColor = SystemColors.Control; }//启动按钮1灯
                if (Program.SystemContainer.IO.EXO10) { EXO10_Status.BackColor = Color.Green; } else { EXO10_Status.BackColor = SystemColors.Control; }//启动按钮2灯
            });
        }
    }
}

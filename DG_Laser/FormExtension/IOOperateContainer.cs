using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DG_Laser
{
    /// <summary>
    /// IO手动操作页面
    /// </summary>
    partial class MainForm
    {
        /// <summary>
        /// IO操作初始化
        /// </summary>
        private void IOOperateContainerInitial()
        {

        }
        /// <summary>
        /// 照明灯操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Lamp_Click(object sender, EventArgs e)
        {
            this.Invoke((EventHandler)delegate
            {
                //读取通用输出的值            
                if (Program.SystemContainer.IO.Lamp_control == 0)
                {
                    Program.SystemContainer.IO.Lamp_control = 1;
                    Lamp.Text = "照明打开";
                }
                else
                {
                    Program.SystemContainer.IO.Lamp_control = 0;
                    Lamp.Text = "照明关闭";
                }
            });
        }
        /// <summary>
        /// 气缸操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cylinder_Click(object sender, EventArgs e)
        {
            this.Invoke((EventHandler)delegate
            {
                if (Program.SystemContainer.IO.Cyc_control == 0)
                {
                    Program.SystemContainer.IO.Cyc_control = 1;
                    Cylinder.Text = "气缸伸出";
                }
                else
                {
                    Program.SystemContainer.IO.Cyc_control = 0;
                    Cylinder.Text = "气缸退回";
                }
            });
        }
        /// <summary>
        /// 吹气操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Blow_Click(object sender, EventArgs e)
        {
            this.Invoke((EventHandler)delegate
            {
                if (Program.SystemContainer.IO.Blow_control == 0)
                {
                    Program.SystemContainer.IO.Blow_control = 1;
                    Blow.Text = "吹气打开";
                }
                else
                {
                    Program.SystemContainer.IO.Blow_control = 0;
                    Blow.Text = "吹气关闭";
                }
            });
        }
        /// <summary>
        /// 等灯塔黄
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BeaconYellow_Click(object sender, EventArgs e)
        {
            this.Invoke((EventHandler)delegate
            {
                if (Program.SystemContainer.IO.Yellow_lamp == 0)
                {
                    Program.SystemContainer.IO.Yellow_lamp = 1;
                    BeaconYellow.Text = "灯塔黄打开";
                }
                else
                {
                    Program.SystemContainer.IO.Yellow_lamp = 0;
                    BeaconYellow.Text = "灯塔黄关闭";
                }
            });
        }
        /// <summary>
        /// 灯塔绿
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BeaconGreen_Click(object sender, EventArgs e)
        {
            this.Invoke((EventHandler)delegate
            {
                if (Program.SystemContainer.IO.Green_lamp == 0)
                {
                    Program.SystemContainer.IO.Green_lamp = 1;
                    BeaconGreen.Text = "灯塔绿打开";
                }
                else
                {
                    Program.SystemContainer.IO.Green_lamp = 0;
                    BeaconGreen.Text = "灯塔绿关闭";
                }
            });
        }
        /// <summary>
        /// 灯塔红
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BeaconRed_Click(object sender, EventArgs e)
        {
            this.Invoke((EventHandler)delegate
            {
                if (Program.SystemContainer.IO.Red_lamp == 0)
                {
                    Program.SystemContainer.IO.Red_lamp = 1;
                    BeaconRed.Text = "灯塔红打开";
                }
                else
                {
                    Program.SystemContainer.IO.Red_lamp = 0;
                    BeaconRed.Text = "灯塔红关闭";
                }
            });
        }
        /// <summary>
        /// 蜂鸣器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Buzzer_Click(object sender, EventArgs e)
        {
            this.Invoke((EventHandler)delegate
            {
                if (Program.SystemContainer.IO.Beeze_Control == 0)
                {
                    Program.SystemContainer.IO.Beeze_Control = 1;
                    Buzzer.Text = "蜂鸣器打开";
                }
                else
                {
                    Program.SystemContainer.IO.Beeze_Control = 0;
                    Buzzer.Text = "蜂鸣器关闭";
                }
            });
        }
    }
}

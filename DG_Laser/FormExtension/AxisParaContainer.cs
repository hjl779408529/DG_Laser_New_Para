using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DG_Laser
{
    /// <summary>
    /// 轴参数
    /// </summary>
    public partial class MainForm
    {
        bool AxisParaWRFlag = false;
        /// <summary>
        /// 参数页面初始化
        /// </summary>
        public void AxisParaContainerInitial()
        {

            RefreshAXisPara();
            //绑定事件
            AxisSelectcomboBox.SelectedValueChanged += SwitchAXisPara;
            numUD_AxisPositiveLimit.ValueChanged += UpdateAXisPara;
            numUD_AxisNegativeLimit.ValueChanged += UpdateAXisPara;
            AxisAccnumericUpDown.ValueChanged += UpdateAXisPara;
            AxisDccnumericUpDown.ValueChanged += UpdateAXisPara;
            AxisVelocitynumericUpDown.ValueChanged += UpdateAXisPara;
            AxisSmoothTimenumericUpDown.ValueChanged += UpdateAXisPara;

        }
        /// <summary>
        /// 刷新修正值
        /// </summary>
        private void RefreshAXisPara()
        {
            AxisParaWRFlag = true;
            Thread.Sleep(30);
            //初始化参数
            AxisSelectcomboBox.SelectedIndex = Program.SystemContainer.SysPara.AxisIndicate;
            //各轴参数初始化
            switch (AxisSelectcomboBox.SelectedIndex)
            {
                case 0://X轴
                    numUD_AxisPositiveLimit.Value = Program.SystemContainer.SysPara.AxisXSoftLimitPositive;
                    numUD_AxisNegativeLimit.Value = Program.SystemContainer.SysPara.AxisXSoftLimitNegative;
                    AxisAccnumericUpDown.Value = Program.SystemContainer.SysPara.AxisXAcc;
                    AxisDccnumericUpDown.Value = Program.SystemContainer.SysPara.AxisXDcc;
                    AxisVelocitynumericUpDown.Value = Program.SystemContainer.SysPara.AxisXVelocity;
                    AxisSmoothTimenumericUpDown.Value = Program.SystemContainer.SysPara.AxisXSmoothTime;
                    break;
                case 1://
                    numUD_AxisPositiveLimit.Value = Program.SystemContainer.SysPara.AxisYSoftLimitPositive;
                    numUD_AxisNegativeLimit.Value = Program.SystemContainer.SysPara.AxisYSoftLimitNegative;
                    AxisAccnumericUpDown.Value = Program.SystemContainer.SysPara.AxisYAcc;
                    AxisDccnumericUpDown.Value = Program.SystemContainer.SysPara.AxisYDcc;
                    AxisVelocitynumericUpDown.Value = Program.SystemContainer.SysPara.AxisYVelocity;
                    AxisSmoothTimenumericUpDown.Value = Program.SystemContainer.SysPara.AxisYSmoothTime;
                    break;
                case 2://Z轴
                    numUD_AxisPositiveLimit.Value = Program.SystemContainer.SysPara.AxisZSoftLimitPositive;
                    numUD_AxisNegativeLimit.Value = Program.SystemContainer.SysPara.AxisZSoftLimitNegative;
                    AxisAccnumericUpDown.Value = Program.SystemContainer.SysPara.AxisZAcc;
                    AxisDccnumericUpDown.Value = Program.SystemContainer.SysPara.AxisZDcc;
                    AxisVelocitynumericUpDown.Value = Program.SystemContainer.SysPara.AxisZVelocity;
                    AxisSmoothTimenumericUpDown.Value = Program.SystemContainer.SysPara.AxisZSmoothTime;
                    break;
                default:
                    break;
            }
            Thread.Sleep(30);
            AxisParaWRFlag = false;
        }
        /// <summary>
        /// 切换修正值
        /// </summary>
        private void SwitchAXisPara(object sender, EventArgs e)
        {
            AxisParaWRFlag = true;
            Thread.Sleep(30);
            //初始化参数
            Program.SystemContainer.SysPara.AxisIndicate = AxisSelectcomboBox.SelectedIndex;
            //各轴参数初始化
            switch (AxisSelectcomboBox.SelectedIndex)
            {
                case 0://X轴
                    numUD_AxisPositiveLimit.Value = Program.SystemContainer.SysPara.AxisXSoftLimitPositive;
                    numUD_AxisNegativeLimit.Value = Program.SystemContainer.SysPara.AxisXSoftLimitNegative;
                    AxisAccnumericUpDown.Value = Program.SystemContainer.SysPara.AxisXAcc;
                    AxisDccnumericUpDown.Value = Program.SystemContainer.SysPara.AxisXDcc;
                    AxisVelocitynumericUpDown.Value = Program.SystemContainer.SysPara.AxisXVelocity;
                    AxisSmoothTimenumericUpDown.Value = Program.SystemContainer.SysPara.AxisXSmoothTime;
                    break;
                case 1://
                    numUD_AxisPositiveLimit.Value = Program.SystemContainer.SysPara.AxisYSoftLimitPositive;
                    numUD_AxisNegativeLimit.Value = Program.SystemContainer.SysPara.AxisYSoftLimitNegative;
                    AxisAccnumericUpDown.Value = Program.SystemContainer.SysPara.AxisYAcc;
                    AxisDccnumericUpDown.Value = Program.SystemContainer.SysPara.AxisYDcc;
                    AxisVelocitynumericUpDown.Value = Program.SystemContainer.SysPara.AxisYVelocity;
                    AxisSmoothTimenumericUpDown.Value = Program.SystemContainer.SysPara.AxisYSmoothTime;
                    break;
                case 2://Z轴
                    numUD_AxisPositiveLimit.Value = Program.SystemContainer.SysPara.AxisZSoftLimitPositive;
                    numUD_AxisNegativeLimit.Value = Program.SystemContainer.SysPara.AxisZSoftLimitNegative;
                    AxisAccnumericUpDown.Value = Program.SystemContainer.SysPara.AxisZAcc;
                    AxisDccnumericUpDown.Value = Program.SystemContainer.SysPara.AxisZDcc;
                    AxisVelocitynumericUpDown.Value = Program.SystemContainer.SysPara.AxisZVelocity;
                    AxisSmoothTimenumericUpDown.Value = Program.SystemContainer.SysPara.AxisZSmoothTime;
                    break;
                default:
                    break;
            }
            Thread.Sleep(30);
            AxisParaWRFlag = false;
        }
        /// <summary>
        /// 更新修正值
        /// </summary>
        private void UpdateAXisPara(object sender, EventArgs e)
        {
            if (AxisParaWRFlag) return;
            //初始化参数
            Program.SystemContainer.SysPara.AxisIndicate = AxisSelectcomboBox.SelectedIndex;
            //各轴参数初始化
            switch (AxisSelectcomboBox.SelectedIndex)
            {
                case 0://X轴
                    Program.SystemContainer.SysPara.AxisXSoftLimitPositive = (int)numUD_AxisPositiveLimit.Value;
                    Program.SystemContainer.SysPara.AxisXSoftLimitNegative = (int)numUD_AxisNegativeLimit.Value;
                    Program.SystemContainer.SysPara.AxisXAcc = AxisAccnumericUpDown.Value;
                    Program.SystemContainer.SysPara.AxisXDcc = AxisDccnumericUpDown.Value;
                    Program.SystemContainer.SysPara.AxisXVelocity = AxisVelocitynumericUpDown.Value;
                    Program.SystemContainer.SysPara.AxisXSmoothTime = (short)AxisSmoothTimenumericUpDown.Value;
                    break;
                case 1://
                    Program.SystemContainer.SysPara.AxisYSoftLimitPositive = (int)numUD_AxisPositiveLimit.Value;
                    Program.SystemContainer.SysPara.AxisYSoftLimitNegative = (int)numUD_AxisNegativeLimit.Value;
                    Program.SystemContainer.SysPara.AxisYAcc = AxisAccnumericUpDown.Value;
                    Program.SystemContainer.SysPara.AxisYDcc = AxisDccnumericUpDown.Value;
                    Program.SystemContainer.SysPara.AxisYVelocity = AxisVelocitynumericUpDown.Value;
                    Program.SystemContainer.SysPara.AxisYSmoothTime = (short)AxisSmoothTimenumericUpDown.Value;
                    break;
                case 2://Z轴
                    Program.SystemContainer.SysPara.AxisZSoftLimitPositive = (int)numUD_AxisPositiveLimit.Value;
                    Program.SystemContainer.SysPara.AxisZSoftLimitNegative = (int)numUD_AxisNegativeLimit.Value;
                    Program.SystemContainer.SysPara.AxisZAcc = AxisAccnumericUpDown.Value;
                    Program.SystemContainer.SysPara.AxisZDcc = AxisDccnumericUpDown.Value;
                    Program.SystemContainer.SysPara.AxisZVelocity = AxisVelocitynumericUpDown.Value;
                    Program.SystemContainer.SysPara.AxisZSmoothTime = (short)AxisSmoothTimenumericUpDown.Value;
                    break;
                default:
                    break;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DG_Laser
{
    public delegate void TransInfo(String context);//传递信息
    public partial class InputForm : Form
    {
        
        public InputForm()
        {
            InitializeComponent();
        }
        public event TransInfo SentText;
        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Confirm_Click(object sender, EventArgs e)
        {
            SentText?.Invoke(InputTextBox.Text);
            this.Close();//关闭窗口
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();//关闭窗口
        }
        /// <summary>
        /// 输入内容更改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InputTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 窗口初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetInput_Load(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// 刷新Input
        /// </summary>
        public void RefreshInput(string Input)
        {
            InputTextBox.Text = Input;
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using LaserVision_info;
namespace DG_Laser
{
    public partial class CameraConfigForm : Form
    {
        //相机参数信息
        FileInfo_data ini_cam = new FileInfo_data("\\cam\\data\\Sys\\Sys.ini");
        public CameraConfigForm()
        {
            InitializeComponent();
            Init_CamParam();    //相机参数
        }
        //相机界面
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_CamSet_Save_Click(object sender, EventArgs e)
        {
            //保存数据
            changeCamInfo();
            
        }
        /// <summary>
        /// 提去输入参数到文件（\\cam\\data\\Sys\\Sys.ini）
        /// </summary>
        private void changeCamInfo()
        {
            ini_cam.Write("Sys", "MarkType", ComBox__CamSet_Marktypelist.SelectedIndex.ToString());
            //0：圆 1：矩形 2; 十字
            //int MarkType = tabControl_CamSet_Mark.SelectedIndex;
            //颜色
            if (Rtn_CamSet_Black.Checked)
            {
                ini_cam.Write("Sys", "MarkCol", "1");
            }
            else
            {
                ini_cam.Write("Sys", "MarkCol", "0");
            }
            //圆
            ini_cam.Write("Sys", "MarkRadio", CamSet_CircleRadiusnumericUpDown.Value.ToString());
            //矩形
            long Area = (long)(CamSet_MarkWidthnumericUpDown.Value * CamSet_MarkLengthnumericUpDown.Value);
            ini_cam.Write("Sys", "MarkRect_W", CamSet_MarkWidthnumericUpDown.Value.ToString());
            ini_cam.Write("Sys", "MarkRect_L", CamSet_MarkLengthnumericUpDown.Value.ToString());
            ini_cam.Write("Sys", "MarkRect_Area", Area.ToString());
            //十字   

            if (Rtn_CamSet_SaveYes.Checked)
            {
                ini_cam.Write("Sys", "IsSave", "1");
            }
            else
            {
                ini_cam.Write("Sys", "IsSave", "0");
            }
            Thread.Sleep(50);
            //发送数据TCP
            Program.SystemContainer.T_Client.Send_Data(40);
        }
        /// <summary>
        /// 初始化控件内容
        /// </summary>
        private void Init_CamParam()
        {
            //颜色
            if (int.Parse(ini_cam.ReadValue("Sys", "MarkCol")).Equals(1))
            {
                Rtn_CamSet_Black.Checked = true;
                Rtn_CamSet_White.Checked = false;
            }
            else
            {
                Rtn_CamSet_Black.Checked = false;
                Rtn_CamSet_White.Checked = true;
            }
            //圆
            CamSet_CircleRadiusnumericUpDown.Text = ini_cam.ReadValue("Sys", "MarkRadio");
            //矩形
            CamSet_MarkWidthnumericUpDown.Text = ini_cam.ReadValue("Sys", "MarkRect_W");
            CamSet_MarkLengthnumericUpDown.Text = ini_cam.ReadValue("Sys", "MarkRect_L");
            //十字
            //图片保存
            if (int.Parse(ini_cam.ReadValue("Sys", "IsSave")).Equals(1))
            {
                Rtn_CamSet_SaveYes.Checked = true;
                Rtn_CamSet_SaveNo.Checked = false;
            }
            else
            {
                Rtn_CamSet_SaveYes.Checked = false;
                Rtn_CamSet_SaveNo.Checked = true;
            }
        }
        //设置文本框仅输入数字（属性（MaxLength）中设置 最大6位数）
        private void Txt_CamSet_MarkLength_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
        /// <summary>
        /// 截获关闭对话框消息保存信息
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(CancelEventArgs e)
        {
            DialogResult result = MessageBox.Show("是否确认关闭-并保存数据信息？", "警告",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //关闭后保存信息
            if (result == DialogResult.Yes)
            {
                changeCamInfo();
            }
            e.Cancel = result != DialogResult.Yes;
            base.OnClosing(e);
        }
       
        #region 控件响应函数
        /// <summary>
        /// 打开相机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenCambutton_Click(object sender, EventArgs e)
        {
            if (Process_Operate.StartApp("CellLocation"))//打开相机
            {
                Thread.Sleep(2000);
                Program.SystemContainer.T_Client.TCP_Start(Program.SystemContainer.SysPara.Server_Ip, Program.SystemContainer.SysPara.Server_Port);
                UpdateCamButtonStatus();//刷新状态
                if (!Program.SystemContainer.T_Client.ConnectOk)//连接失败
                {
                    DialogResult dr = MessageBox.Show(string.Format("确定关闭相机，取消退出窗口"), "确认窗口", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.OK)
                    {
                        Process_Operate.KillApp("CellLocation");
                    }
                }
            }
            else
            {
                MessageBox.Show("相机打开失败!!!");
            }
        }
        /// <summary>
        /// 触发拍照
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_CamSet_trigger_Click(object sender, EventArgs e)
        {
            Vector Tmp = Program.SystemContainer.T_Client.Get_Cam_Actual_Pixel(Program.SystemContainer.SysPara.Camera_Intrigue_Num);//触发拍照 
            Vector Cor_Data = Program.SystemContainer.T_Client.Get_Coordinate_Corrrect_Point(Tmp.X, Tmp.Y);
            MessageBox.Show(string.Format("相机坐标：({0},{1})，实际坐标：({2},{3})", Tmp.X, Tmp.Y, Cor_Data.X, Cor_Data.Y));

        }
        /// <summary>
        /// 重连相机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_CamSet_Reconnect_Click(object sender, EventArgs e)
        {
            Program.SystemContainer.T_Client.TCP_Start(Program.SystemContainer.SysPara.Server_Ip, Program.SystemContainer.SysPara.Server_Port);
        }
        /// <summary>
        /// 断开相机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_CamSet_offconnect_Click(object sender, EventArgs e)
        {
            Program.SystemContainer.T_Client.Stop_Connect();
        }
        /// <summary>
        /// Mark点选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void ComBox__CamSet_Marktypelist_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.SystemContainer.SysPara.Camera_Mark_Type = ComBox__CamSet_Marktypelist.SelectedIndex;
            if (Rtn_CamSet_Black.Checked)//黑色Mark
            {
                //10 - 黑色圆白背景
                //11 - 黑色矩形白背景
                //12 - 黑色十字白背景
                //23 - 模板
                Program.SystemContainer.SysPara.Camera_Intrigue_Sequence = (ushort)(10 + ComBox__CamSet_Marktypelist.SelectedIndex);
            }
            if(Rtn_CamSet_White.Checked) //白色Mark
            {
                //20 - 白色圆黑背景
                //21 - 白色矩形黑背景
                //22 - 白色十字黑背景
                //23 - 模板
                Program.SystemContainer.SysPara.Camera_Intrigue_Sequence = (ushort)(20 + ComBox__CamSet_Marktypelist.SelectedIndex);
            }
        }
        /// <summary>
        /// 触发代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numUD_CamSet_num_ValueChanged(object sender, EventArgs e)
        {
            Program.SystemContainer.SysPara.Camera_Intrigue_Num = (int)numUD_CamSet_num.Value;
        }
        #endregion
        /// <summary>
        /// 更新像素K值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CameraKnumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            Program.SystemContainer.SysPara.Cam_Reference = CameraKnumericUpDown.Value;
        }
        /// <summary>
        /// 窗口加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CameraConfigForm_Load(object sender, EventArgs e)
        {
            ComBox__CamSet_Marktypelist.SelectedIndex = Program.SystemContainer.SysPara.Camera_Mark_Type;
            CameraKnumericUpDown.Value = Program.SystemContainer.SysPara.Cam_Reference;
            numUD_CamSet_num.Value = Program.SystemContainer.SysPara.Camera_Intrigue_Num;
            CameraCentreXnumericUpDown.Value = Program.SystemContainer.SysPara.CameraCentreX;
            CameraCentreYnumericUpDown.Value = Program.SystemContainer.SysPara.CameraCentreY;
            if ((MainForm.usmen != "") && (MainForm.usmen == "管理员"))
            {
                PixelCentregroupBox.Enabled = true;
                CameraKnumericUpDown.Enabled = true;
            }
            else
            {
                PixelCentregroupBox.Enabled = false;
                CameraKnumericUpDown.Enabled = false;
            }
            UpdateCamButtonStatus();//刷新状态
        }
        /// <summary>
        /// 更新相机按钮状态
        /// </summary>
        private void UpdateCamButtonStatus()
        {
            this.Invoke((EventHandler)delegate
            {
                if (Program.SystemContainer.T_Client.ConnectOk)//连接OK
                {
                    OpenCambutton.Text = "相机Ready";
                    OpenCambutton.ForeColor = Color.Green;
                }
                else
                {
                    OpenCambutton.Text = "打开相机";
                    OpenCambutton.ForeColor = Color.Black;
                }
            });
            
        }
        /// <summary>
        /// 相机像素中心X
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CameraCentreXnumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            Program.SystemContainer.SysPara.CameraCentreX = CameraCentreXnumericUpDown.Value;

        }
        /// <summary>
        /// 相机像素中心Y
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CameraCentreYnumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            Program.SystemContainer.SysPara.CameraCentreY = CameraCentreYnumericUpDown.Value;
        }
        /// <summary>
        /// 白色Mark选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rtn_CamSet_White_CheckedChanged(object sender, EventArgs e)
        {
            Program.SystemContainer.SysPara.Camera_Mark_Type = ComBox__CamSet_Marktypelist.SelectedIndex;
            if (Rtn_CamSet_Black.Checked)//黑色Mark
            {
                //10 - 黑色圆白背景
                //11 - 黑色矩形白背景
                //12 - 黑色十字白背景
                //23 - 模板
                Program.SystemContainer.SysPara.Camera_Intrigue_Sequence = (ushort)(10 + ComBox__CamSet_Marktypelist.SelectedIndex);
            }
            if (Rtn_CamSet_White.Checked) //白色Mark
            {
                //20 - 白色圆黑背景
                //21 - 白色矩形黑背景
                //22 - 白色十字黑背景
                //23 - 模板
                Program.SystemContainer.SysPara.Camera_Intrigue_Sequence = (ushort)(20 + ComBox__CamSet_Marktypelist.SelectedIndex);
            }
        }
        /// <summary>
        /// 黑色Mark选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rtn_CamSet_Black_CheckedChanged(object sender, EventArgs e)
        {
            Program.SystemContainer.SysPara.Camera_Mark_Type = ComBox__CamSet_Marktypelist.SelectedIndex;
            if (Rtn_CamSet_Black.Checked)//黑色Mark
            {
                //10 - 黑色圆白背景
                //11 - 黑色矩形白背景
                //12 - 黑色十字白背景
                //23 - 模板
                Program.SystemContainer.SysPara.Camera_Intrigue_Sequence = (ushort)(10 + ComBox__CamSet_Marktypelist.SelectedIndex);
            }
            if (Rtn_CamSet_White.Checked) //白色Mark
            {
                //20 - 白色圆黑背景
                //21 - 白色矩形黑背景
                //22 - 白色十字黑背景
                //23 - 模板
                Program.SystemContainer.SysPara.Camera_Intrigue_Sequence = (ushort)(20 + ComBox__CamSet_Marktypelist.SelectedIndex);
            }
        }
    }

}
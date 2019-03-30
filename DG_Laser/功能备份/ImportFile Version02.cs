using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DG_Laser.FormExtension
{
    public partial class ImportFile : Form
    {
        public delegate void TransDat(FileConfig fileConfig);
        public ImportFile()
        {
            InitializeComponent();
            LaserWidth.ValueChanged += RTCLimit_ValueXChanged;
            LaserHeight.ValueChanged += RTCLimit_ValueYChanged;
        }
        FileConfig NewFile = new FileConfig();
        public event TransDat SendData;
        public event TransProject SendProject;
        /// <summary>
        /// 窗口加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImportFile_Load(object sender, EventArgs e)
        {
            //文件格式选项
            LmdType.Enabled = false;
            GerberType.Enabled = false;
            NCType.Enabled = false;
            DxfType.Checked = true;
            //首图档初始位置
            materialCentre.Checked = true;
            //数据保留位
            BeforePoint.Value = 2;
            AfterPoint.Value = 4;
            //振镜尺寸
            LaserWidth.Value = Program.SystemContainer.SysPara.Rtc_Limit.X;
            LaserHeight.Value = Program.SystemContainer.SysPara.Rtc_Limit.Y;
            //刀具列表更新
            RefreshScissorsStrorageListCombox();
        }
        /// <summary>
        /// 刷新刀具库刀具列表
        /// </summary>
        private void RefreshScissorsStrorageListCombox()
        {
            ScissorsStrorageListCombox.Items.AddRange(Program.SystemContainer.ScissorList.Select(o => o.Scissors_Name).ToArray());
            ScissorsStrorageListCombox.SelectedIndex = 0;//默认第一个
        }
        /// <summary>
        /// 导入文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectFile_Click(object sender, EventArgs e)
        {
            // 获取文件名       
            OpenFileDialog openfile = new OpenFileDialog
            {
                Filter = "dxf 文件(*.dxf)|*.dxf"
            };
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                NewFile.Name = System.IO.Path.GetFileName(openfile.FileName);
                NewFile.Path = openfile.FileName;
                Program.SystemContainer.SysPara.DxfFileName = openfile.FileName;
            }
            else
            {
                return;
            }
            Cam_Data_Resolve TemResolve = new Cam_Data_Resolve();
            List<string> LayerList = TemResolve.GetLayerList(Program.SystemContainer.SysPara.DxfFileName);//获取Dxf图层列表
            if (LayerList == null)//图层读取失败
            {
                MessageBox.Show("图层读取失败！！！");
                return;
            }            
            //配置图层参数
            foreach (var o in LayerList)
            {
                NewFile.LayerScissor.Add(new LayerScissor(o,new List<string>(),false,false));
            }
            //刷新图层列表
            LayerListCombox.Items.AddRange(NewFile.LayerScissor.Select(o => o.Layer).ToArray());
            LayerListCombox.SelectedIndex = 0;
        }
        /// <summary>
        /// 修改振镜加工范围 X
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void RTCLimit_ValueXChanged(object sender, EventArgs e)
        {
            Program.SystemContainer.SysPara.Rtc_Limit = new Vector(LaserWidth.Value, Program.SystemContainer.SysPara.Rtc_Limit.Y);
        }
        /// <summary>
        /// 修改振镜加工范围 Y
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void RTCLimit_ValueYChanged(object sender, EventArgs e)
        {
            Program.SystemContainer.SysPara.Rtc_Limit = new Vector(Program.SystemContainer.SysPara.Rtc_Limit.X, LaserHeight.Value);
        }
        /// <summary>
        /// 确定按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Confirm_Click(object sender, EventArgs e)
        {
            if (NewFile.Name != "")
            {
                SendData?.Invoke(NewFile);
            }            
            this.Close();//关闭窗口
        }
        /// <summary>
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();//关闭窗口
        }
        /// <summary>
        /// 图层列表显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LayerListCombox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshLayerScissorComboBox();
            LaserradioButton.Checked = NewFile.LayerScissor[GetIndex()].Laser;
            MarkradioButton.Checked = NewFile.LayerScissor[GetIndex()].Mark;
        }
        /// <summary>
        /// 刷新图层刀具列表
        /// </summary>
        private void RefreshLayerScissorComboBox()
        {
            LayerScissorComboBox.Items.Clear();
            if (NewFile.LayerScissor[GetIndex()].Scissor.Count() > 0)//当前图层已有刀具
            {
                LayerScissorComboBox.Items.AddRange(NewFile.LayerScissor[GetIndex()].Scissor.ToArray());
            }
            else
            {
                LayerScissorComboBox.Items.Add("未指派刀具");
            }
            LayerScissorComboBox.SelectedIndex = 0;
        }
        /// <summary>
        /// 是否激光加工显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LaserradioButton_CheckedChanged(object sender, EventArgs e)
        {
            NewFile.LayerScissor[GetIndex()].Laser = LaserradioButton.Checked;
        }
        /// <summary>
        /// 是否Mark对位层
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MarkradioButton_CheckedChanged(object sender, EventArgs e)
        {
            NewFile.LayerScissor[GetIndex()].Mark = MarkradioButton.Checked;
        }
        /// <summary>
        /// 获取索引
        /// </summary>
        /// <returns></returns>
        private int GetIndex()
        {
            return NewFile.LayerScissor.FindIndex(o => o.Layer == LayerListCombox.SelectedItem.ToString());
        }
        /// <summary>
        /// 追加刀具
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PushScissorToLeft_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(string.Format("确定向图层\"{0}\"指派刀具\"{1}\"",LayerListCombox.SelectedItem.ToString(), ScissorsStrorageListCombox.SelectedItem.ToString()), "指派刀具", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                NewFile.LayerScissor[GetIndex()].Scissor.Add(ScissorsStrorageListCombox.SelectedItem.ToString());
                RefreshLayerScissorComboBox();
            }
        }
        /// <summary>
        /// 删除刀具
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DelScissorFromLeft_Click(object sender, EventArgs e)
        {
            if ((LayerScissorComboBox.SelectedItem.ToString() == "未指派")  || (LayerScissorComboBox.SelectedItem.ToString() == "")) return;
            DialogResult dr = MessageBox.Show(string.Format("确定删除图层\"{0}\"指派的刀具\"{1}\"", LayerListCombox.SelectedItem.ToString(), LayerScissorComboBox.SelectedItem.ToString()), "删除指派刀具", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                NewFile.LayerScissor[GetIndex()].Scissor.RemoveAt(NewFile.LayerScissor[GetIndex()].Scissor.FindIndex(o => o == LayerScissorComboBox.SelectedItem.ToString()));
                RefreshLayerScissorComboBox();
            }
        }
        /// <summary>
        /// 刀具库显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScissorStorageForm_Click(object sender, EventArgs e)
        {
            ScissorStorageForm ScissorForm = new ScissorStorageForm();            
            ScissorForm.ShowDialog();
        }

        
    }
}

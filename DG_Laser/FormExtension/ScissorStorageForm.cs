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
    public delegate void TransProject(LaserProject MainLaserProject);
    public partial class ScissorStorageForm : Form
    {
        public ScissorStorageForm()
        {
            InitializeComponent();

        }
        Tech_Parameter ScissorParaShow = new Tech_Parameter();
        public event TransProject SendData;
        public event Work FormCloseEvent;//窗口关闭事件
        LaserProject ScissorFormProject = new LaserProject();
        bool ScissorWriteFlag = false;//刀具参数写入标志
        bool ProjectWriteFlag = false;//项目参数写入标志
        /// <summary>
        /// 窗口初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScissorStorageForm_Load(object sender, EventArgs e)
        {
            RefreshScissorListBox();
            if (Program.SystemContainer.ScissorList.Count > 0)
                ScissorListBox.SelectedIndex = 0;//选中第一个
            else
                ScissorParaShow.Original();

            //项目管理部分数据事件绑定
            ThicknessnumericUpDown.ValueChanged += ModifyPara;
            TotalPiecesnumericUpDown.ValueChanged += ModifyPara;
            StartPiecesnumericUpDown.ValueChanged += ModifyPara;
            AlarmPiecesnumericUpDown.ValueChanged += ModifyPara;

            //数据修改绑定事件
            Scissor_RpeatTimes.ValueChanged += ScissorListSave;
            Scisssor_FocusOffset.ValueChanged += ScissorListSave;
            Scissor_FocusCompensation.ValueChanged += ScissorListSave;
            Scissor_FocusCompensationTimes.ValueChanged += ScissorListSave;
            Scissor_DelayCompensation.ValueChanged += ScissorListSave;
            Scissor_DelayCompensationTimes.ValueChanged += ScissorListSave;
            Scissor_Blow.CheckedChanged += ScissorListSave;
            Scisssor_PEC.ValueChanged += ScissorListSave;
            Scissor_PRF.ValueChanged += ScissorListSave;
            Scisssor_JSpeed.ValueChanged += ScissorListSave;
            Scisssor_MSpeed.ValueChanged += ScissorListSave;
            Scisssor_LaserOnDelay.ValueChanged += ScissorListSave;
            Scisssor_LaserOffDelay.ValueChanged += ScissorListSave;
            Scisssor_JDelay.ValueChanged += ScissorListSave;
            Scisssor_MDelay.ValueChanged += ScissorListSave;
            Scisssor_PyDelay.ValueChanged += ScissorListSave;
            Scisssor_Period.ValueChanged += ScissorListSave;
            Scisssor_LeftCriteriaPos.ValueChanged += ScissorListSave;
            Scisssor_LeftMaterialPos.ValueChanged += ScissorListSave;
            Scisssor_RightCriteriaPos.ValueChanged += ScissorListSave;
            Scisssor_RightMaterialPos.ValueChanged += ScissorListSave;

            //调试用刀具
            DebugScissortextBox.Text = Program.SystemContainer.SysPara.Calibrate_Mark_Scissor;

            if ((MainForm.usmen != "") && (MainForm.usmen == "管理员"))
            {
                //显示 调试刀具
                DebugScissorgroupBox.Visible = true;

                //允许 刀具配置
                ScissorDetailgroupBox.Enabled = true;
            }
            else
            {
                //显示 调试刀具
                DebugScissorgroupBox.Visible = false;

                //允许 刀具配置
                ScissorDetailgroupBox.Enabled = false;
            }


        }
        
        /// <summary>
        /// 获取当前项目参数
        /// </summary>
        /// <param name="Indata"></param>
        public void GetProject(LaserProject Indata)
        {
            ScissorFormProject = new LaserProject(Indata);
            //刷新产品名称列表
            RefreshProductNamecomboBox();
            //刷新文档信息
            RefreshDocument();
        }
        /// <summary>
        /// 刷新产品名称列表
        /// </summary>
        private void RefreshProductNamecomboBox()
        {
            //产品名称列表刷新
            ProductNamecomboBox.Items.Clear();
            ProductNamecomboBox.Items.AddRange(Program.SystemContainer.MaterialStorageList.Select(o => o.ProductName).Distinct().ToArray());
            if (ProductNamecomboBox.Items.Count > 0)
            {
                int index = ProductNamecomboBox.Items.IndexOf(ScissorFormProject.ProductName);
                if (index >= 0)
                {
                    ProductNamecomboBox.SelectedIndex = index;
                }
                else
                {
                    ProductNamecomboBox.SelectedIndex = 0;//默认第一列
                }
            }
            else
            {
                ProductNamecomboBox.SelectedIndex = -1;//清除选择
                MessageBox.Show("请进入\"物料配置页面\"，配置物料清单！！！");
            }
        }
        /// <summary>
        /// 刷新材料清单
        /// </summary>
        private void RefreshMaterialNamecomboBox()
        {
            MaterialNamecomboBox.Items.Clear();
            int Productindex = Program.SystemContainer.MaterialStorageList.FindIndex(o => o.ProductName == ScissorFormProject.ProductName);
            if (Productindex == -1)
            {
                MessageBox.Show("材料库无该产品！！！");
                return;
            }
            if (Program.SystemContainer.MaterialStorageList[Productindex].MaterialList.Count < 0)
            {
                MessageBox.Show("材料库中该产品无材料！！！");
                return;
            }
            MaterialNamecomboBox.Items.AddRange(Program.SystemContainer.MaterialStorageList[Productindex].MaterialList.Select(o => o.MaterialName).ToArray());
            if (MaterialNamecomboBox.Items.Count > 0)
            {
                int index = MaterialNamecomboBox.Items.IndexOf(ScissorFormProject.MaterialName);
                if (index >= 0)
                {
                    MaterialNamecomboBox.SelectedIndex = index;
                }
                else
                {
                    MaterialNamecomboBox.SelectedIndex = 0;//默认第一列
                }
            }
        }
        /// <summary>
        /// 刷新厚度信息
        /// </summary>
        private void RefreshThickness()
        {
            int Productindex = Program.SystemContainer.MaterialStorageList.FindIndex(o => o.ProductName == ScissorFormProject.ProductName);
            if (Productindex == -1)
            {
                MessageBox.Show("材料库无该产品！！！");
                return;
            }
            int Materialindex = Program.SystemContainer.MaterialStorageList[Productindex].MaterialList.FindIndex(o => o.MaterialName == ScissorFormProject.MaterialName);
            if (Materialindex == -1)
            {
                ThicknessnumericUpDown.Value = 0m;
                MessageBox.Show("材料库无该材料！！！");
                return;
            }
            ThicknessnumericUpDown.Value = Program.SystemContainer.MaterialStorageList[Productindex].MaterialList[Materialindex].Thickness;
        }
        /// <summary>
        /// 刷新计数信息
        /// </summary>
        private void RefreshPieces()
        {
            int Productindex = Program.SystemContainer.MaterialStorageList.FindIndex(o => o.ProductName == ScissorFormProject.ProductName);
            if (Productindex == -1)
            {
                MessageBox.Show("材料库无该产品！！！");
                return;
            }
            int Materialindex = Program.SystemContainer.MaterialStorageList[Productindex].MaterialList.FindIndex(o => o.MaterialName == ScissorFormProject.MaterialName); 
            if (Materialindex == -1)
            {
                TotalPiecesnumericUpDown.Value = 0;
                StartPiecesnumericUpDown.Value = 0;
                AlarmPiecesnumericUpDown.Value = 0;
                MessageBox.Show("材料库无该材料！！！");
                return;
            }
            TotalPiecesnumericUpDown.Value = Program.SystemContainer.MaterialStorageList[Productindex].MaterialList[Materialindex].TotalPieces;
            StartPiecesnumericUpDown.Value = Program.SystemContainer.MaterialStorageList[Productindex].MaterialList[Materialindex].StartPieces;
            AlarmPiecesnumericUpDown.Value = Program.SystemContainer.MaterialStorageList[Productindex].MaterialList[Materialindex].AlarmPieces;
        }
        /// <summary>
        /// 修改厚度和计数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModifyPara(object sender, EventArgs e)
        {
            if (ProjectWriteFlag) return;
            int Productindex = Program.SystemContainer.MaterialStorageList.FindIndex(o => o.ProductName == ScissorFormProject.ProductName);
            if (Productindex == -1)
            {
                MessageBox.Show("材料库无该产品！！！");
                return;
            }
            int Materialindex = Program.SystemContainer.MaterialStorageList[Productindex].MaterialList.FindIndex(o => o.MaterialName == ScissorFormProject.MaterialName);
            if (Materialindex == -1)
            {
                MessageBox.Show("材料库无该材料！！！");
                return;
            }
            Program.SystemContainer.MaterialStorageList[Productindex].MaterialList[Materialindex].Thickness = ThicknessnumericUpDown.Value;
            Program.SystemContainer.MaterialStorageList[Productindex].MaterialList[Materialindex].TotalPieces = (int)TotalPiecesnumericUpDown.Value;
            Program.SystemContainer.MaterialStorageList[Productindex].MaterialList[Materialindex].StartPieces = (int)StartPiecesnumericUpDown.Value;
            Program.SystemContainer.MaterialStorageList[Productindex].MaterialList[Materialindex].AlarmPieces = (int)AlarmPiecesnumericUpDown.Value;
           
        }
        /// <summary>
        /// 产品修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProductNamecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshMaterialNamecomboBox();//刷新材料列表
        }
        /// <summary>
        /// 厚度信息更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaterialNamecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshThickness();//刷新厚度信息
            ProjectWriteFlag = true;
            RefreshPieces();//刷新计数值
            ProjectWriteFlag = false;
        }
        /// <summary>
        /// 刷新文档信息
        /// </summary>
        private void RefreshDocument()
        {
            DocumentcomboBox.Items.AddRange(ScissorFormProject.FileList.Select(o => o.Name).ToArray());//刷新文档信息
            if (DocumentcomboBox.Items.Count > 0)
            {
                DocumentcomboBox.SelectedIndex = 0;//默认第一个
            }
        }
        /// <summary>
        /// 文件 切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DocumentcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshLayerList();
        }
        /// <summary>
        /// 刷新图层信息
        /// </summary>
        private void RefreshLayerList()
        {
            int index = ScissorFormProject.FileList.FindIndex(o => o.Name == DocumentcomboBox.SelectedItem.ToString());//获取索引
            LayerListCombox.Items.Clear();
            if (index == -1) return;
            LayerListCombox.Items.AddRange(ScissorFormProject.FileList[index].LayerScissor.Select(o => o.Layer).ToArray());
            LayerListCombox.SelectedIndex = 0;
        }
        /// <summary>
        /// 刷新图层对应的刀具列表
        /// </summary>
        private void RefreshLayerScissorComboBox()
        {
            //判断文件是否存在
            int FileIndex = ScissorFormProject.FileList.FindIndex(o =>o.Name == DocumentcomboBox.SelectedItem.ToString());//获取索引
            LayerScissorComboBox.Items.Clear();
            if (FileIndex == -1) return;
            //判断当前图层的刀具
            int LayerIndex = ScissorFormProject.FileList[FileIndex].LayerScissor.FindIndex(o =>o.Layer == LayerListCombox.SelectedItem.ToString());
            if (LayerIndex == -1) return;
            if (ScissorFormProject.FileList[FileIndex].LayerScissor[LayerIndex].Scissor.Count() > 0)//当前图层已有刀具
            {
                LayerScissorComboBox.Items.AddRange(ScissorFormProject.FileList[FileIndex].LayerScissor[LayerIndex].Scissor.ToArray());
            }
            else
            {
                LayerScissorComboBox.Items.Add("未指派刀具");
            }
            LayerScissorComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// 图层索引改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LayerListCombox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //判断文件是否存在
            int FileIndex = ScissorFormProject.FileList.FindIndex(o => o.Name == DocumentcomboBox.SelectedItem.ToString());//获取索引
            if (FileIndex == -1) return;
            //判断当前图层的刀具
            int LayerIndex = ScissorFormProject.FileList[FileIndex].LayerScissor.FindIndex(o => o.Layer == LayerListCombox.SelectedItem.ToString());
            if (LayerIndex == -1) return;
            RefreshLayerScissorComboBox();//刷新图层对应的刀具列表
            LaserradioButton.Checked = ScissorFormProject.FileList[FileIndex].LayerScissor[LayerIndex].Laser;
            MarkradioButton.Checked = ScissorFormProject.FileList[FileIndex].LayerScissor[LayerIndex].Mark;
        }
        /// <summary>
        /// Mark层 radioButton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MarkradioButton_CheckedChanged(object sender, EventArgs e)
        {
            //判断文件是否存在
            int FileIndex = ScissorFormProject.FileList.FindIndex(o => o.Name == DocumentcomboBox.SelectedItem.ToString());//获取索引
            if (FileIndex == -1) return;
            //判断当前图层的刀具
            int LayerIndex = ScissorFormProject.FileList[FileIndex].LayerScissor.FindIndex(o => o.Layer == LayerListCombox.SelectedItem.ToString());
            if (LayerIndex == -1) return;
            ScissorFormProject.FileList[FileIndex].LayerScissor[LayerIndex].Mark = MarkradioButton.Checked;
        }
        /// <summary>
        /// 激光层 radioButton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LaserradioButton_CheckedChanged(object sender, EventArgs e)
        {
            //判断文件是否存在
            int FileIndex = ScissorFormProject.FileList.FindIndex(o => o.Name == DocumentcomboBox.SelectedItem.ToString());//获取索引
            if (FileIndex == -1) return;
            //判断当前图层的刀具
            int LayerIndex = ScissorFormProject.FileList[FileIndex].LayerScissor.FindIndex(o => o.Layer == LayerListCombox.SelectedItem.ToString());
            if (LayerIndex == -1) return;
            ScissorFormProject.FileList[FileIndex].LayerScissor[LayerIndex].Laser = LaserradioButton.Checked;
        }

        /// <summary>
        /// 向指定图层添加 指定刀具
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PushScissorToLeft_Click(object sender, EventArgs e)
        {
            //判断文件是否存在
            int FileIndex = ScissorFormProject.FileList.FindIndex(o => o.Name == DocumentcomboBox.SelectedItem.ToString());//获取索引
            if (FileIndex == -1) return;
            //判断当前图层的刀具
            int LayerIndex = ScissorFormProject.FileList[FileIndex].LayerScissor.FindIndex(o => o.Layer == LayerListCombox.SelectedItem.ToString());
            if (LayerIndex == -1) return;
            DialogResult dr = MessageBox.Show(string.Format("确定向图层\"{0}\"指派刀具\"{1}\"", LayerListCombox.SelectedItem.ToString(), ScissorListBox.SelectedItem.ToString()), "指派刀具", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                ScissorFormProject.FileList[FileIndex].LayerScissor[LayerIndex].Scissor.Add(ScissorListBox.SelectedItem.ToString());
                RefreshLayerScissorComboBox();
            }
        }
        /// <summary>
        /// 删除当前图层刀具 选中的刀具
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DelScissorFromLeft_Click(object sender, EventArgs e)
        {
            //判断文件是否存在
            int FileIndex = ScissorFormProject.FileList.FindIndex(o => o.Name == DocumentcomboBox.SelectedItem.ToString());//获取索引
            if (FileIndex == -1) return;
            //判断当前图层的刀具
            int LayerIndex = ScissorFormProject.FileList[FileIndex].LayerScissor.FindIndex(o => o.Layer == LayerListCombox.SelectedItem.ToString());
            if (LayerIndex == -1) return;
            if ((LayerScissorComboBox.SelectedItem.ToString() == "未指派刀具") || (LayerScissorComboBox.SelectedItem.ToString() == "")) return;
            DialogResult dr = MessageBox.Show(string.Format("确定删除图层\"{0}\"指派的刀具\"{1}\"", LayerListCombox.SelectedItem.ToString(), LayerScissorComboBox.SelectedItem.ToString()), "删除指派刀具", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                ScissorFormProject.FileList[FileIndex].LayerScissor[LayerIndex].Scissor.RemoveAt(ScissorFormProject.FileList[FileIndex].LayerScissor[LayerIndex].Scissor.FindIndex(o => o == LayerScissorComboBox.SelectedItem.ToString()));
                RefreshLayerScissorComboBox();
            }
        }

        /// <summary>
        /// 刷新刀具列表
        /// </summary>
        private void RefreshScissorListBox()
        {
            //刷新刀具列表
            ScissorListBox.Items.Clear();
            ScissorListBox.Items.AddRange(Program.SystemContainer.ScissorList.Select(o => o.Scissors_Name).ToArray());
        }

        /// <summary>
        /// 新增刀具
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddScissor_Click(object sender, EventArgs e)
        {
            InputForm inputForm = new InputForm();
            inputForm.RefreshInput("新刀具");
            inputForm.SentText += NewScissor;
            inputForm.ShowDialog();
        }
        /// <summary>
        /// 新刀具
        /// </summary>
        /// <param name="Name"></param>
        private void NewScissor(String Name)
        {
            if (Name == "")
            {
                return;
            }
            else
            {
                if (ScissorListBox.Items.Contains(Name))//存在条目
                {
                    MessageBox.Show("刀具已存在！！！");
                }
                else
                {
                    ScissorListBox.SelectedIndex = -1;//取消选中状态、
                    ScissorParaShow.Original();//初始化刀具参数
                    ScissorParaShow.Scissors_Name = Name;//更新刀具名
                    Program.SystemContainer.ScissorList.Add(new Tech_Parameter(ScissorParaShow));//追加新刀具
                    //刷新刀具列表
                    RefreshScissorListBox();
                    ScissorListBox.SelectedIndex = ScissorListBox.Items.Count - 1;
                }
            }
        }
        /// <summary>
        /// 删除刀具
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DelScissor_Click(object sender, EventArgs e)
        {
            if (ScissorListBox.SelectedIndex == -1)//没有选中项
            {
                MessageBox.Show("未选中刀具！！！");
            }
            else
            {
                DialogResult dr = MessageBox.Show(string.Format("删除刀具\"{0}\"", ScissorListBox.SelectedItem.ToString()), "刀具删除", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    //点确定的代码
                    Program.SystemContainer.ScissorList.RemoveAt(Program.SystemContainer.ScissorList.FindIndex(o => o.Scissors_Name == ScissorListBox.SelectedItem.ToString()));
                    RefreshScissorListBox();//刷新刀具列表
                }
            }
        }
        /// <summary>
        /// 刀具参数保存
        /// </summary>
        private void ScissorListSave(object sender, EventArgs e)
        {
            if (!ScissorWriteFlag)
            {
                //采集分数据
                ScissorParaShow.Scissors_Name = ScissorListBox.SelectedItem.ToString();
                ScissorParaShow.RepeatTime = (int)Scissor_RpeatTimes.Value;
                ScissorParaShow.FocusOffSet = Scisssor_FocusOffset.Value;
                ScissorParaShow.FocusCompensation = Scissor_FocusCompensation.Value;
                ScissorParaShow.FocusCompensationTimes = (int)Scissor_FocusCompensationTimes.Value;
                ScissorParaShow.DelayCompensation = (int)Scissor_DelayCompensation.Value;
                ScissorParaShow.DelayCompensationTimes = (int)Scissor_DelayCompensationTimes.Value;
                ScissorParaShow.Blow = Scissor_Blow.Checked;
                ScissorParaShow.PEC = Scisssor_PEC.Value;
                ScissorParaShow.PRF = Scissor_PRF.Value;
                ScissorParaShow.Jump_Speed = (double)Scisssor_JSpeed.Value;
                ScissorParaShow.Mark_Speed = (double)Scisssor_MSpeed.Value;
                ScissorParaShow.Laser_On_Delay = Scisssor_LaserOnDelay.Value;
                ScissorParaShow.Laser_Off_Delay = Scisssor_LaserOffDelay.Value;
                ScissorParaShow.Jump_Delay = Scisssor_JDelay.Value;
                ScissorParaShow.Mark_Delay = Scisssor_MDelay.Value;
                ScissorParaShow.Polygon_Delay = Scisssor_PyDelay.Value;
                //检查是否选中状态
                if (ScissorListBox.SelectedIndex != -1)//未选中状态
                {
                    //将修改应用于选中的刀具
                    Program.SystemContainer.ScissorList[Program.SystemContainer.ScissorList.FindIndex(o => o.Scissors_Name == ScissorListBox.SelectedItem.ToString())] = new Tech_Parameter(ScissorParaShow);
                }
            }            
        }
        /// <summary>
        /// 刀具参数显示刷新
        /// </summary>
        private void ScissorShowRefresh()
        {
            Scissor_RpeatTimes.Value = ScissorParaShow.RepeatTime;
            Scisssor_FocusOffset.Value = ScissorParaShow.FocusOffSet;
            Scissor_FocusCompensation.Value = ScissorParaShow.FocusCompensation;
            Scissor_FocusCompensationTimes.Value = ScissorParaShow.FocusCompensationTimes;
            Scissor_DelayCompensation.Value = ScissorParaShow.DelayCompensation;
            Scissor_DelayCompensationTimes.Value = ScissorParaShow.DelayCompensationTimes;
            Scissor_Blow.Checked = ScissorParaShow.Blow;
            Scisssor_PEC.Value = ScissorParaShow.PEC;
            Scissor_PRF.Value = ScissorParaShow.PRF;
            Scisssor_JSpeed.Value = (decimal)ScissorParaShow.Jump_Speed;
            Scisssor_MSpeed.Value = (decimal)ScissorParaShow.Mark_Speed;
            Scisssor_LaserOnDelay.Value = ScissorParaShow.Laser_On_Delay;
            Scisssor_LaserOffDelay.Value = ScissorParaShow.Laser_Off_Delay;
            Scisssor_JDelay.Value = ScissorParaShow.Jump_Delay;
            Scisssor_MDelay.Value = ScissorParaShow.Mark_Delay;
            Scisssor_PyDelay.Value = ScissorParaShow.Polygon_Delay;
        }
        /// <summary>
        /// 修改了刀具名称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScissorListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            InputForm inputForm = new InputForm();
            inputForm.RefreshInput(ScissorListBox.SelectedItem.ToString());
            inputForm.SentText += ChangeScissorName;
            inputForm.ShowDialog();
        }
        /// <summary>
        /// 修改刀具名
        /// </summary>
        private void ChangeScissorName(string Name)
        {
            if (Name == "")
            {
                return;
            }
            else if (Name == ScissorListBox.SelectedItem.ToString())
            {
                return;
            }
            else
            {
                if (ScissorListBox.Items.Contains(Name))//存在条目
                {
                    MessageBox.Show("刀具已存在！！！");
                }
                else
                {
                    Program.SystemContainer.ScissorList[Program.SystemContainer.ScissorList.FindIndex(o => o.Scissors_Name == ScissorListBox.SelectedItem.ToString())].Scissors_Name = Name;
                    //刷新刀具列表
                    RefreshScissorListBox();
                }
            }
        }
        /// <summary>
        /// 刀具切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScissorListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ScissorListBox.SelectedIndex !=-1)
            {
                ScissorParaShow = new Tech_Parameter(Program.SystemContainer.ScissorList[Program.SystemContainer.ScissorList.FindIndex(o => o.Scissors_Name == ScissorListBox.SelectedItem.ToString())]);
                ScissorWriteFlag = true;
                ScissorShowRefresh();
                ScissorWriteFlag = false;
            }            
        }
        /// <summary>
        /// 保存修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Confirm_Click(object sender, EventArgs e)
        {
            if (ScissorFormProject.ProjectName != "")
            {
                SendData?.Invoke(ScissorFormProject);
            }
            this.Close();
        }
        /// <summary>
        /// 取消并关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScissorStorageForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormCloseEvent?.Invoke();
        }
        /// <summary>
        /// 修改调试用刀具
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DebugScissorAddbutton_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(string.Format("确定将\"{0}\"指派为：\"{1}\"","调试用刀" , ScissorListBox.SelectedItem.ToString()), "指派刀具", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                Program.SystemContainer.SysPara.Calibrate_Mark_Scissor = ScissorListBox.SelectedItem.ToString();
            }
            DebugScissortextBox.Text = Program.SystemContainer.SysPara.Calibrate_Mark_Scissor;

        }
        private void LaserradioButton_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete) LaserradioButton.Checked = false;
        }

        private void MarkradioButton_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Delete) MarkradioButton.Checked = false;
        }
    }
}

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
    public delegate void TransData(string ProjectName,string ProductName,string MaterialName);
    public partial class ProjectConfig : Form
    {
        public ProjectConfig()
        {
            InitializeComponent();
        }
        public event TransData SendData; 
        /// <summary>
        /// 项目加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProjectConfig_Load(object sender, EventArgs e)
        {
            ProjectNametextBox.Text = "新项目";
            RefreshProductNamecomboBox();//刷新产品名称列表
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
                ProductNamecomboBox.SelectedIndex = 0;//默认第一列
            }
            else
            {
                ProductNamecomboBox.SelectedIndex = -1;//清除选择
                MessageBox.Show("请点击\"物料配置\"按钮，配置物料清单！！！");
            }            
        }
        /// <summary>
        /// 刷新材料清单
        /// </summary>
        private void RefreshMaterialNamecomboBox()
        {
            MaterialNamecomboBox.Items.Clear();
            int Productindex = Program.SystemContainer.MaterialStorageList.FindIndex(o => o.ProductName == ProductNamecomboBox.SelectedItem.ToString());
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
            if (MaterialNamecomboBox.Items.Count>0)
            {
                MaterialNamecomboBox.SelectedIndex = 0;//默认第一项
            }            
        }
        /// <summary>
        /// 确定按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Confirm_Click(object sender, EventArgs e)
        {
            SendData?.Invoke(ProjectNametextBox.Text,ProductNamecomboBox.SelectedItem.ToString(),MaterialNamecomboBox.SelectedItem.ToString());//发送项目配置文件
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
        /// 物料配置按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaterialConfig_Click(object sender, EventArgs e)
        {
            if (Program.SystemContainer.MSForm == null)
            {
                Program.SystemContainer.MSForm = new MaterialStorageForm();
                Program.SystemContainer.MSForm.Show();
            }
            else
            {
                if (Program.SystemContainer.MSForm.IsDisposed) //若子窗体关闭 则打开新子窗体 并显示
                {
                    Program.SystemContainer.MSForm = new MaterialStorageForm();
                    Program.SystemContainer.MSForm.Show();
                }
                else
                {
                    Program.SystemContainer.MSForm.Activate(); //使子窗体获得焦点
                }
            }
        }
        /// <summary>
        /// 产品名选择更改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProductNamecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshMaterialNamecomboBox();
        }
        /// <summary>
        /// 材料名选择更改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaterialNamecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

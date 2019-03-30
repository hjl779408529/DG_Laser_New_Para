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

namespace DG_Laser
{
    public partial class MaterialStorageForm : Form
    {
        public MaterialStorageForm()
        {
            InitializeComponent();
        }
        //定义变量
        string ShowProductName = "Default";
        Material ShowMaterial = new Material();//展示材料变量
        bool ShowParaWRFlag = false;//展示变量正在读写中标志
        /// <summary>
        /// 窗口加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaterialStorageForm_Load(object sender, EventArgs e)
        {
            //更新
            InitTree();//初始化物料库
            //绑定事件
            ProductNametextBox.TextChanged += UpdateShowPara;
            MaterialNametextBox.TextChanged += UpdateShowPara;
            ThicknessnumericUpDown.ValueChanged += UpdateShowPara;
            HeightnumericUpDown.ValueChanged += UpdateShowPara;
            WidthnumericUpDown.ValueChanged += UpdateShowPara;
            PosXnumericUpDown.ValueChanged += UpdateShowPara;
            PosYnumericUpDown.ValueChanged += UpdateShowPara;
            PosXRnumericUpDown.ValueChanged += UpdateShowPara;
            PosYRnumericUpDown.ValueChanged += UpdateShowPara;
        }
        /// <summary>
        /// 初始化材料库默认值
        /// </summary>
        private void InitialShowPara()
        {
            ShowMaterial = new Material()
            {
                MaterialName = "新材料",
                Thickness = 0.00m,
                TotalPieces = 0,
                StartPieces = 0,
                AlarmPieces = 0,
                Width = 0,
                Height = 0,
                Point = new Vector(0, 0),
                Angle = new Vector(0, 0)
            };
            ShowProductName = "新产品";

        }
        /// <summary>
        /// 初始化显示值为ShowPara
        /// </summary>
        private void ShowParaDisplay() 
        {
            ShowParaWRFlag = true;
            Thread.Sleep(30);
            ProductNametextBox.Text = ShowProductName;
            MaterialNametextBox.Text = ShowMaterial.MaterialName;
            ThicknessnumericUpDown.Value = ShowMaterial.Thickness;
            HeightnumericUpDown.Value = ShowMaterial.Height;
            WidthnumericUpDown.Value = ShowMaterial.Width;
            PosXnumericUpDown.Value = ShowMaterial.Point.X;
            PosYnumericUpDown.Value = ShowMaterial.Point.Y;
            PosXRnumericUpDown.Value = ShowMaterial.Angle.X;
            PosYRnumericUpDown.Value = ShowMaterial.Angle.Y;            
            Thread.Sleep(30);
            ShowParaWRFlag = false;
        }
        /// <summary>
        /// 更新ShowPara
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateShowPara (object sender, EventArgs e)
        {
            if (ShowParaWRFlag) return;
            //刷新数据
            ShowProductName = ProductNametextBox.Text;
            ShowMaterial.MaterialName = MaterialNametextBox.Text;
            ShowMaterial.Thickness = ThicknessnumericUpDown.Value;
            ShowMaterial.Height = HeightnumericUpDown.Value;
            ShowMaterial.Width = WidthnumericUpDown.Value;
            ShowMaterial.Point = new Vector(PosXnumericUpDown.Value, PosYnumericUpDown.Value);
            ShowMaterial.Angle = new Vector(PosXRnumericUpDown.Value, PosYRnumericUpDown.Value);
            //校验数据           
            if (string.IsNullOrEmpty(ShowProductName))
            {
                //MessageBox.Show("产品名为空");
                return;
            }
            if (string.IsNullOrEmpty(ShowMaterial.MaterialName))
            {
                //MessageBox.Show("材料名为空");
                return;
            }
            //校验Treeview选择项
            
            if (MaterialStoragetreeView.SelectedNode == null)//是否有选中，无可修改数据
            {
                return;
            }
            if (MaterialStoragetreeView.SelectedNode.Parent == null)//父节点为空，意味着值选中父节点
            {
                return;
            }
            string ProductName = MaterialStoragetreeView.SelectedNode.Parent.Text;
            string MaterialName = MaterialStoragetreeView.SelectedNode.Text;
            int Productindex = Program.SystemContainer.MaterialStorageList.FindIndex(o => o.ProductName == ProductName);
            if (Productindex == -1)
            {
                return;
            }
            //校验是否有重复产品名
            if (ShowProductName != ProductName)//新产品名 不等于 旧名
            {
                int ProductCertifyindex = Program.SystemContainer.MaterialStorageList.FindIndex(o => o.ProductName == ShowProductName);
                if (ProductCertifyindex != -1)
                {
                    MessageBox.Show(string.Format("产品名重复！！！"));
                    return;
                }
            }
            int MaterialIndex = Program.SystemContainer.MaterialStorageList[Productindex].MaterialList.FindIndex(o => o.MaterialName == MaterialName);
            if (MaterialIndex == -1)
            {
                return;
            }
            //校验是否有重复材料名
            if (ShowMaterial.MaterialName != MaterialName)
            {
                int MaterialCertifyindex = Program.SystemContainer.MaterialStorageList[Productindex].MaterialList.FindIndex(o => o.MaterialName == ShowMaterial.MaterialName);
                if (MaterialCertifyindex != -1)
                {
                    MessageBox.Show(string.Format("产品名重复！！！"));
                    return;
                }
            }
            //确认数据
            Program.SystemContainer.MaterialStorageList[Productindex].ProductName = ShowProductName;
            Program.SystemContainer.MaterialStorageList[Productindex].MaterialList[MaterialIndex] = new Material(ShowMaterial);
            //刷新TreeView
            InitTree();
            Thread.Sleep(30);
            //刷新选中
            SelectNodes(ShowProductName, ShowMaterial.MaterialName);
        }
        /// <summary>
        /// 新建产品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateProductbutton_Click(object sender, EventArgs e)
        {
            string TempPName = "新产品_" + (Program.SystemContainer.MaterialStorageList.Count + 1).ToString();
            MaterialStorage TempMStorage = new MaterialStorage()
            {
                ProductName = TempPName,
                MaterialList = new List<Material>()
            };
            Program.SystemContainer.MaterialStorageList.Add(new MaterialStorage(TempMStorage));
            InitTree();
        }
        /// <summary>
        /// 删除产品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteProductbutton_Click(object sender, EventArgs e)
        {
            if (MaterialStoragetreeView.SelectedNode == null) return;//校验当前节点是否为空
            string ProductName = MaterialStoragetreeView.SelectedNode.Text;
            int Productindex = Program.SystemContainer.MaterialStorageList.FindIndex(o => o.ProductName == ProductName);
            if (Productindex == -1)
            {
                return;
            }
            //确认窗口
            DialogResult dr = MessageBox.Show(string.Format("确认删除产品:{0}", ProductName), "删除产品", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                Program.SystemContainer.MaterialStorageList.RemoveAt(Productindex);
                InitTree();
            }
        }
        /// <summary>
        /// 新建材料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateMaterialbutton_Click(object sender, EventArgs e)
        {
            if (MaterialStoragetreeView.SelectedNode == null) return;//校验当前节点是否为空
            string ProductName = MaterialStoragetreeView.SelectedNode.Text;//获取产品名
            int Productindex = Program.SystemContainer.MaterialStorageList.FindIndex(o => o.ProductName == ProductName);
            if (Productindex == -1)
            {
                return;
            }
            string MName = "新材料_" + (Program.SystemContainer.MaterialStorageList[Productindex].MaterialList.Count + 1).ToString();
            Material TempMaterial = new Material() 
            {
                MaterialName = MName,
                Thickness = 0.00m,
                TotalPieces = 0,
                StartPieces = 0,
                AlarmPieces = 0,
                Width = 0,
                Height = 0,
                Point = new Vector(0, 0),
                Angle = new Vector(0, 0)
            };
            Program.SystemContainer.MaterialStorageList[Productindex].MaterialList.Add(new Material(TempMaterial));
            InitTree();//刷新节点
            Thread.Sleep(30);
            //刷新选中
            SelectNodes(ProductName, MName);
        }
        /// <summary>
        /// 删除材料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteMaterialbutton_Click(object sender, EventArgs e)
        {
            if (MaterialStoragetreeView.SelectedNode.Parent == null) return;//父节点为空
            if (MaterialStoragetreeView.SelectedNode == null) return;//子节点为空
            string ProductName = MaterialStoragetreeView.SelectedNode.Parent.Text;
            string MaterialName = MaterialStoragetreeView.SelectedNode.Text;
            int Productindex = Program.SystemContainer.MaterialStorageList.FindIndex(o => o.ProductName == ProductName);
            if (Productindex == -1)
            {
                return;
            }
            int MaterialIndex = Program.SystemContainer.MaterialStorageList[Productindex].MaterialList.FindIndex(o => o.MaterialName == MaterialName);
            if (MaterialIndex == -1)
            {
                return;
            }
            //确认窗口
            DialogResult dr = MessageBox.Show(string.Format("确认删除产品:{0}中的:{1}材料", ProductName,MaterialName), "删除材料", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                Program.SystemContainer.MaterialStorageList[Productindex].MaterialList.RemoveAt(MaterialIndex);
                InitTree();
            }
        }
        /****************************/
        //节点树

        /// <summary>
        /// 初始化树结构
        /// </summary>
        private void InitTree()
        {
            MaterialStoragetreeView.Nodes.Clear();
            List<string> FatherNodeName = Program.SystemContainer.MaterialStorageList.Select(o => o.ProductName).Distinct().ToList();//获取父节点名称
            foreach (var o in FatherNodeName)
            {
                TreeNode Father = new TreeNode();
                Father.Text = o;
                LoadChildNode(o, Father);
                MaterialStoragetreeView.Nodes.Add(Father);
            }
        }
        /// <summary>
        /// 向指定父节点添加子节点
        /// </summary>
        /// <param name="Fname"></param>
        /// <param name="FtreeNode"></param>
        private void LoadChildNode(string Fname,TreeNode FtreeNode)
        {
            int Productindex = Program.SystemContainer.MaterialStorageList.FindIndex(o => o.ProductName == Fname);
            if (Productindex == -1)
            {
                return;
            }
            if (Program.SystemContainer.MaterialStorageList[Productindex].MaterialList.Count < 0)
            {
                return;
            }
            List<string> ChildNodeName = Program.SystemContainer.MaterialStorageList[Productindex].MaterialList.Select(o => o.MaterialName).ToList();//获取子节点名称
            foreach (var o in ChildNodeName)
            {
                TreeNode Child = new TreeNode();
                Child.Text = o;
                FtreeNode.Nodes.Add(Child);
            }
        }
        /// <summary>
        /// 节点选中事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaterialStoragetreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ShowParaWRFlag = true;
            Thread.Sleep(30);
            if (e.Node.Parent == null)//父节点为空,未选中子节点
            {
                FatherNodeSelectEvent();
                //MessageBox.Show(string.Format("父节点:null,子节点:{0}", e.Node.Text));
            }
            else//父节点不为空,选中子节点
            {
                ChildNodeSelectEvent();
                //MessageBox.Show(string.Format("父节点:{0},子节点:{1}", e.Node.Parent.Text, e.Node.Text));
            }
            Thread.Sleep(30);
            ShowParaWRFlag = false;            
        }
        /// <summary>
        /// 父节点选中事件
        /// </summary>
        private void FatherNodeSelectEvent()
        {
            DeleteProductbutton.Enabled = true;//删除产品按钮 启用
            CreateMaterialbutton.Enabled = true;//新建材料按钮 启用
            DeleteMaterialbutton.Enabled = false;//删除材料按钮 禁用
            //更新右侧产品名称
            ProductNametextBox.Text = MaterialStoragetreeView.SelectedNode.Text;
        }
        /// <summary>
        /// 子节点选中事件
        /// </summary>
        private void ChildNodeSelectEvent()
        {
            DeleteProductbutton.Enabled = false;//删除产品按钮 禁用
            CreateMaterialbutton.Enabled = false;//新建材料按钮 禁用
            DeleteMaterialbutton.Enabled = true;//删除材料按钮 启用
            //更新右侧产品名称
            ProductNametextBox.Text = MaterialStoragetreeView.SelectedNode.Parent.Text;
            //更新右侧材料参数
            MaterialNametextBox.Text = MaterialStoragetreeView.SelectedNode.Text;
            string ProductName = MaterialStoragetreeView.SelectedNode.Parent.Text;
            string MaterialName = MaterialStoragetreeView.SelectedNode.Text;
            int Productindex = Program.SystemContainer.MaterialStorageList.FindIndex(o => o.ProductName == ProductName);
            if (Productindex == -1)
            {
                return;
            }
            int MaterialIndex = Program.SystemContainer.MaterialStorageList[Productindex].MaterialList.FindIndex(o => o.MaterialName == MaterialName);
            if (MaterialIndex == -1)
            {
                return;
            }
            //更新材料展示参数
            ShowProductName = ProductName;
            ShowMaterial =new Material(Program.SystemContainer.MaterialStorageList[Productindex].MaterialList[MaterialIndex]);
            //展示数据
            ShowParaDisplay();
        }
        /// <summary>
        /// 选中指定的节点
        /// </summary>
        /// <param name="Father"></param>
        /// <param name="Child"></param>
        private void SelectNodes(string Father,string Child)
        {
            if (MaterialStoragetreeView.Nodes.Count <= 0) return;//无节点
            int FIndex = FindIndex(MaterialStoragetreeView.Nodes,Father);//父节点索引            
            if (FIndex == -1) return;
            MaterialStoragetreeView.Nodes[FIndex].Expand();
            if (MaterialStoragetreeView.Nodes[FIndex].Nodes.Count <= 0) return;//无父节点
            int CIndex = FindIndex(MaterialStoragetreeView.Nodes[FIndex].Nodes,Child);//父节点索引
            if (CIndex == -1) return;
            MaterialStoragetreeView.SelectedNode = MaterialStoragetreeView.Nodes[FIndex].Nodes[CIndex];
        }
        /// <summary>
        /// 查找索引
        /// </summary>
        /// <param name="TNode"></param>
        /// <param name="matchText"></param>
        /// <returns></returns>
        private int FindIndex(TreeNodeCollection NodeList,string matchText)
        {
            bool Flag = false;
            int Result = 0;
            for (int i = 0; i < NodeList.Count;i++)
            {
                if (NodeList[i].Text.Equals(matchText))
                {
                    Flag = true;
                    Result = i;
                    break;
                }
            }
            if (Flag)
                return Result;
            else
                return -1;
        }
    }
}

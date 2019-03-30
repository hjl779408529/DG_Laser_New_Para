using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DG_Laser.FormExtension;
using netDxf;

namespace DG_Laser
{
    public partial class MarkConfig : Form
    {
        public delegate void GoSpecificPoint(Vector Point);
        public MarkConfig()
        {
            InitializeComponent();
            LeftDownX.ValueChanged += ConfirmLeftDownPoint;
            LeftDownY.ValueChanged += ConfirmLeftDownPoint;

        }
        LaserProject MarkConfigProject = new LaserProject();
        Cam_Data_Resolve DataResolve = new Cam_Data_Resolve();
        List<Vector> DxfMarkInfo = new List<Vector>();
        List<Vector> PlatFormMarkInfo = new List<Vector>();
        public event TransProject SendData;//传送修改好Mark的项目文件
        public event GoSpecificPoint GoMarkPoint;//定位到指定位置
        public event GoSpecificPoint CheckMarkPoint;//校验Mark序列
        public event Work FormCloseEvent;//窗口关闭事件
        bool WriteFlag = false;
        /// <summary>
        /// 窗口初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MarkConfig_Load(object sender, EventArgs e)
        {
            //设置上下限
            LeftDownX.Maximum = 350;
            LeftDownX.Minimum = Program.SystemContainer.SysPara.Rtc_Org.X;
            LeftDownY.Maximum = 350;
            LeftDownY.Minimum = 0;
            //刷新下标坐标
            RefreshLeftDownPoint(Program.SystemContainer.SysPara.LeftDownPoint);
        }
        /// <summary>
        /// 获取当前项目参数
        /// </summary>
        /// <param name="Indata"></param>
        public void GetProject(LaserProject Indata)
        {
            MarkConfigProject = new LaserProject(Indata);
            //刷新产品名称列表
            RefreshDocumentcomboBox(); 
        }
        /// <summary>
        /// 刷新产品名称列表
        /// </summary>
        private void RefreshDocumentcomboBox()
        {
            //产品名称列表刷新
            DocumentcomboBox.Items.Clear();
            DocumentcomboBox.Items.AddRange(MarkConfigProject.FileList.Select(o => o.Name).ToArray());
            if (DocumentcomboBox.Items.Count <=0)//无文件
            {
                MessageBox.Show("无可用文件！！！");
            }
            else
            {
                DocumentcomboBox.SelectedIndex = 0;//默认第一个文件
            }
        }
        /// <summary>
        /// 更新文档的Mark信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshMarkList_Click(object sender, EventArgs e)
        {
            if ((DocumentcomboBox.SelectedItem.ToString() == "") || (DocumentcomboBox.SelectedItem.ToString() == null))
            {
                MessageBox.Show("无可用文件！！！");
                return;
            }
            //正常更新Mark List
            int FileIndex = MarkConfigProject.FileList.FindIndex(o =>o.Name == DocumentcomboBox.SelectedItem.ToString());
            if (FileIndex == -1)
            {
                MessageBox.Show("无效文件！！！");
                return;
            }
            //更新列表
            //读取DXF文件
            DxfDocument dxf = DataResolve.Read_File(MarkConfigProject.FileList[FileIndex].Path);
            if (dxf == null)
            {
                MessageBox.Show(string.Format("{0}数据读取失败！！！", MarkConfigProject.FileList[FileIndex].Name));
                return;
            }
            //提取Mark信息
            DxfMarkInfo = DataResolve.DistractMark(dxf, "Mark");//mark信息
            if (DxfMarkInfo.Count <= 0)
            {
                MessageBox.Show("Mark信息为空！！！");
                return;
            }
            //刷新DxfMarkInfoListBox
            DxfMarkInfoListBox.Items.Clear();
            foreach (var o in DxfMarkInfo)
            {
                string Tem = string.Format("({0},{1})",o.X.ToString(4),o.Y.ToString(4));
                DxfMarkInfoListBox.Items.Add(Tem);
            }
        }
        /// <summary>
        /// 当前平台坐标赋值给左下坐标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfirmMark_Click(object sender, EventArgs e)
        {
            Vector Tem = Program.SystemContainer.GTS_Fun.Get_Coordinate(1);//获取当前平台坐标
            Tem = new Vector(Tem + Program.SystemContainer.SysPara.Rtc_Org);//转换为相机对准坐标
            RefreshLeftDownPoint(Tem);
        }
        /// <summary>
        /// 更新左下角坐标
        /// </summary>
        /// <param name="Point"></param>
        private void RefreshLeftDownPoint(Vector Point)
        {
            WriteFlag = true;
            LeftDownX.Value = Point.X;
            LeftDownY.Value = Point.Y;
            WriteFlag = false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfirmLeftDownPoint(object sender, EventArgs e)
        {
            if (WriteFlag) return;
            RefreshData();
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        private void RefreshData()
        {
            Program.SystemContainer.SysPara.LeftDownPoint = new Vector(LeftDownX.Value, LeftDownY.Value);
            int FileIndex = MarkConfigProject.FileList.FindIndex(o => o.Name == DocumentcomboBox.SelectedItem.ToString());
            if (FileIndex == -1)
            {
                MessageBox.Show("无效文件！！！");
                return;
            }
            MarkConfigProject.FileList[FileIndex].PlatFormPos = new Vector(LeftDownX.Value, LeftDownY.Value);
        }
        /// <summary>
        /// 更新平台坐标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshPlatForm_Click(object sender, EventArgs e)
        {
            if (DxfMarkInfo.Count <= 0)
            {
                MessageBox.Show("Mark信息为空！！！");
                return;
            }
            //刷新DxfMarkInfoListBox
            PlatformlistBox.Items.Clear();
            PlatFormMarkInfo.Clear();
            foreach (var o in DxfMarkInfo)
            {
                Vector Point = new Vector(o.X + LeftDownX.Value, o.Y + LeftDownY.Value);//更新Mark点
                string Tem = string.Format("({0},{1})", Point.X.ToString(4), Point.Y.ToString(4));
                PlatFormMarkInfo.Add(new Vector(Point));
                PlatformlistBox.Items.Add(Tem);
            }
            if (PlatformlistBox.Items.Count <= 0) return;
            PlatformlistBox.SelectedIndex = 0;//默认选中第一个
        }
        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Confirm_Click(object sender, EventArgs e)
        {
            RefreshData();//更新数据
            SendData?.Invoke(MarkConfigProject);//传送配置好的项目
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
        /// 定位到指定点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoPoint_Click(object sender, EventArgs e)
        {
            int index = PlatformlistBox.SelectedIndex;
            if ((index >= 0) && (index < PlatFormMarkInfo.Count))
            {
                GoMarkPoint?.Invoke(PlatFormMarkInfo[index]);
            }
            else
            {
                MessageBox.Show("无效坐标！！！");
            }
        }
        /// <summary>
        /// 窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MarkConfig_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormCloseEvent?.Invoke();
        }
        /// <summary>
        /// 校验Mark序列
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CertifyMarkbutton_Click(object sender, EventArgs e)
        {

        }
    }
}

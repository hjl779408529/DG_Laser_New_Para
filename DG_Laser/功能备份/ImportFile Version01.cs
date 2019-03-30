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
            LaserWidth.ValueChanged += RTCLimit_ValueChanged;
            LaserHeight.ValueChanged += RTCLimit_ValueChanged;
        }
        DataTable data = new DataTable();
        FileConfig NewFile = new FileConfig();
        public event TransDat SendData;
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
                NewFile.LayerScissor.Add(new LayerScissor(o,new List<string>(),false));
            }
            data = Common_Collect.ListToDt<LayerScissor>(NewFile.LayerScissor);
            //刷新显示
            LayerListdataGridView.DataSource = null;
            LayerListdataGridView.DataSource = data;
        }
        /// <summary>
        /// 修改振镜加工范围
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void RTCLimit_ValueChanged(object sender, EventArgs e)
        {
            Program.SystemContainer.SysPara.Rtc_Limit = new Vector(LaserWidth.Value, LaserHeight.Value);
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
                NewFile.LayerScissor = new List<LayerScissor>();
                NewFile.LayerScissor = Common_Collect.DtToList<LayerScissor>.ConvertToModel((DataTable)LayerListdataGridView.DataSource);
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
    }
}

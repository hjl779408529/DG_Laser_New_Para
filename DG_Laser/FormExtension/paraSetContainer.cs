using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DG_Laser
{
     /// <summary>
     /// 参数页面
     /// </summary>
    partial class MainForm
    {
        //定义变量
        public bool SysParaWRFlag = false;
        /// <summary>
        /// paraSetContainerInitial
        /// </summary>
        private void paraSetContainerInitial()
        {
            RefreshSysPara();// 刷新系统参数页面
            //绑定值修改事件
            RtcOrgDistanceXnumericUpDown.ValueChanged += UpdateSysPara;
            RtcOrgDistanceYnumericUpDown.ValueChanged += UpdateSysPara;
            WorkXnumericUpDown.ValueChanged += UpdateSysPara;
            WorkYnumericUpDown.ValueChanged += UpdateSysPara;
            GtsCorrectFilePathtextBox.TextChanged += UpdateSysPara;
            MarkJumpcheckBox.CheckedChanged += UpdateSysPara;
            CamEncheckBox.CheckedChanged += UpdateSysPara;            
            ShieldbeepTimenumericUpDown.ValueChanged += UpdateSysPara;
            //绑定事件
            CalibrationSelectcomboBox.SelectedIndexChanged += SwitchCalibrationSelectcomboBox;
            CorrectMethodcomboBox.SelectedIndexChanged += UpdateSysPara;
            YCellnumericUpDown.ValueChanged += UpdateSysPara;
            XCellnumericUpDown.ValueChanged += UpdateSysPara;
            YLengthnumericUpDown.ValueChanged += UpdateSysPara;
            XLengthnumericUpDown.ValueChanged += UpdateSysPara;
            RtcMarkTypecomboBox.SelectedIndexChanged += UpdateSysPara;
            RtcAligncheckBox.CheckedChanged += UpdateSysPara;
            RtcCircleRadiusnumericUpDown.ValueChanged += UpdateSysPara;
            PointListRepeatTimesnumericUpDown.ValueChanged += UpdateSysPara;
        }
        /// <summary>
        /// 刷新系统参数页面
        /// </summary>
        private void RefreshSysPara()
        {
            //置位标志
            SysParaWRFlag = true;
            Thread.Sleep(30);
            //参数
            RtcOrgDistanceXnumericUpDown.Value = Program.SystemContainer.SysPara.Rtc_Org.X;
            RtcOrgDistanceYnumericUpDown.Value = Program.SystemContainer.SysPara.Rtc_Org.Y;
            WorkXnumericUpDown.Value = Program.SystemContainer.SysPara.Work.X;
            WorkYnumericUpDown.Value = Program.SystemContainer.SysPara.Work.Y;
            GtsCorrectFilePathtextBox.Text = Program.SystemContainer.SysPara.GtsCorrectFile;
            MarkJumpcheckBox.Checked = Program.SystemContainer.SysPara.MarkJump;
            CamEncheckBox.Checked = Program.SystemContainer.SysPara.CamEn;            
            ShieldbeepTimenumericUpDown.Value = Program.SystemContainer.SysPara.ShieldBeepTime;
            //校准
            CalibrationSelectcomboBox.SelectedIndex = Program.SystemContainer.SysPara.CalibrationSelect;
            switch (CalibrationSelectcomboBox.SelectedIndex)
            {
                case 0:
                    CorrectMethodcomboBox.SelectedIndex = Program.SystemContainer.SysPara.Gts_Calibration_Method == 3 ? 0 : 1;
                    XLengthnumericUpDown.Value = Program.SystemContainer.SysPara.Gts_Calibration_X_Len;
                    YLengthnumericUpDown.Value = Program.SystemContainer.SysPara.Gts_Calibration_Y_Len;
                    XCellnumericUpDown.Value = Program.SystemContainer.SysPara.Gts_Calibration_X_Cell != 0 ? Program.SystemContainer.SysPara.Gts_Calibration_X_Cell : 1;
                    YCellnumericUpDown.Value = Program.SystemContainer.SysPara.Gts_Calibration_Y_Cell != 0 ? Program.SystemContainer.SysPara.Gts_Calibration_Y_Cell : 1;
                    Program.SystemContainer.SysPara.Gts_Affinity_Col_X = Program.SystemContainer.SysPara.Gts_Calibration_X_Cell != 0 ? (int)(Program.SystemContainer.SysPara.Gts_Calibration_X_Len / Program.SystemContainer.SysPara.Gts_Calibration_X_Cell) : 1;
                    Program.SystemContainer.SysPara.Gts_Affinity_Row_Y = Program.SystemContainer.SysPara.Gts_Calibration_Y_Cell != 0 ? (int)(Program.SystemContainer.SysPara.Gts_Calibration_Y_Len / Program.SystemContainer.SysPara.Gts_Calibration_Y_Cell) : 1;
                    Program.SystemContainer.SysPara.Gts_Calibration_Col_X = Program.SystemContainer.SysPara.Gts_Affinity_Col_X + 1;
                    Program.SystemContainer.SysPara.Gts_Calibration_Row_Y = Program.SystemContainer.SysPara.Gts_Affinity_Row_Y + 1;
                    XCalibratetextBox.Text = Program.SystemContainer.SysPara.Gts_Calibration_Col_X.ToString();
                    YCalibratetextBox.Text = Program.SystemContainer.SysPara.Gts_Calibration_Row_Y.ToString();
                    XAffinitytextBox.Text = Program.SystemContainer.SysPara.Gts_Affinity_Col_X.ToString();
                    YAffinitytextBox.Text = Program.SystemContainer.SysPara.Gts_Affinity_Row_Y.ToString();
                    RtcMarkParagroupBox.Enabled = false;
                    break;
                case 1:
                    CorrectMethodcomboBox.SelectedIndex = Program.SystemContainer.SysPara.Rtc_Calibration_Method == 3 ? 0 : 1;
                    XLengthnumericUpDown.Value = Program.SystemContainer.SysPara.Rtc_Calibration_X_Len;
                    YLengthnumericUpDown.Value = Program.SystemContainer.SysPara.Rtc_Calibration_Y_Len;
                    XCellnumericUpDown.Value = Program.SystemContainer.SysPara.Rtc_Calibration_X_Cell != 0 ? Program.SystemContainer.SysPara.Rtc_Calibration_X_Cell : 1;
                    YCellnumericUpDown.Value = Program.SystemContainer.SysPara.Rtc_Calibration_Y_Cell != 0 ? Program.SystemContainer.SysPara.Rtc_Calibration_Y_Cell : 1;
                    Program.SystemContainer.SysPara.Rtc_Affinity_Col_X = Program.SystemContainer.SysPara.Rtc_Calibration_X_Cell != 0 ? (int)(Program.SystemContainer.SysPara.Rtc_Calibration_X_Len / Program.SystemContainer.SysPara.Rtc_Calibration_X_Cell) : 1;
                    Program.SystemContainer.SysPara.Rtc_Affinity_Row_Y = Program.SystemContainer.SysPara.Rtc_Calibration_Y_Cell != 0 ? (int)(Program.SystemContainer.SysPara.Rtc_Calibration_Y_Len / Program.SystemContainer.SysPara.Rtc_Calibration_Y_Cell) : 1;
                    Program.SystemContainer.SysPara.Rtc_Calibration_Col_X = Program.SystemContainer.SysPara.Rtc_Affinity_Col_X + 1;
                    Program.SystemContainer.SysPara.Rtc_Calibration_Row_Y = Program.SystemContainer.SysPara.Rtc_Affinity_Row_Y + 1;
                    XCalibratetextBox.Text = Program.SystemContainer.SysPara.Rtc_Calibration_Col_X.ToString();
                    YCalibratetextBox.Text = Program.SystemContainer.SysPara.Rtc_Calibration_Row_Y.ToString();
                    XAffinitytextBox.Text = Program.SystemContainer.SysPara.Rtc_Affinity_Col_X.ToString();
                    YAffinitytextBox.Text = Program.SystemContainer.SysPara.Rtc_Affinity_Row_Y.ToString();
                    RtcMarkTypecomboBox.SelectedIndex = Program.SystemContainer.SysPara.Rtc_Distortion_Data_Type;
                    RtcAligncheckBox.Checked = Program.SystemContainer.SysPara.Rtc_Get_Data_Align == 0 ? false : true;
                    RtcCorrectTypecheckBox.Checked = Program.SystemContainer.SysPara.RtcCorrectType == 0 ? false : true;
                    switch (Program.SystemContainer.SysPara.Rtc_Distortion_Data_Type)
                    {
                        case 0://0 - 圆
                            RtcCircleRadiusLabel.Visible = true;
                            RtcCircleRadiusnumericUpDown.Visible = true;
                            RtcCircleRadiusnumericUpDown.Value = Program.SystemContainer.SysPara.Rtc_Distortion_Data_Radius;
                            break;
                        default://其他 - 直线
                            RtcCircleRadiusLabel.Visible = false;
                            RtcCircleRadiusnumericUpDown.Visible = false;
                            break;
                    }                    
                    RtcMarkParagroupBox.Enabled = true;
                    break;
                default:
                    break;
            }
            RtcXmlCorrectFilePathtextBox.Text = Program.SystemContainer.SysPara.RtcXmlCorrectFilePath;//振镜坐标系Xml矫正文件路径
            GtsCorrectFilePathtextBox.Text = Program.SystemContainer.SysPara.GtsCorrectFilePath;//平台Xml校准文件路径
            PointListRepeatTimesnumericUpDown.Value = Program.SystemContainer.SysPara.PointListRepeatTimes;
            //取消标志
            Thread.Sleep(30);
            SysParaWRFlag = false;
        }
        /// <summary>
        /// 切换标定位置
        /// </summary>
        private void SwitchCalibrationSelectcomboBox(object sender, EventArgs e)
        {   
            //置位标志
            SysParaWRFlag = true;
            Thread.Sleep(30);
            //校准
            Program.SystemContainer.SysPara.CalibrationSelect = CalibrationSelectcomboBox.SelectedIndex;
            switch (CalibrationSelectcomboBox.SelectedIndex)
            {
                case 0:
                    CorrectMethodcomboBox.SelectedIndex = Program.SystemContainer.SysPara.Gts_Calibration_Method == 3 ? 0 : 1;
                    XLengthnumericUpDown.Value = Program.SystemContainer.SysPara.Gts_Calibration_X_Len;
                    YLengthnumericUpDown.Value = Program.SystemContainer.SysPara.Gts_Calibration_Y_Len;
                    XCellnumericUpDown.Value = Program.SystemContainer.SysPara.Gts_Calibration_X_Cell != 0 ? Program.SystemContainer.SysPara.Gts_Calibration_X_Cell : 1;
                    YCellnumericUpDown.Value = Program.SystemContainer.SysPara.Gts_Calibration_Y_Cell != 0 ? Program.SystemContainer.SysPara.Gts_Calibration_Y_Cell : 1;
                    Program.SystemContainer.SysPara.Gts_Affinity_Col_X = Program.SystemContainer.SysPara.Gts_Calibration_X_Cell != 0 ? (int)(Program.SystemContainer.SysPara.Gts_Calibration_X_Len / Program.SystemContainer.SysPara.Gts_Calibration_X_Cell) : 1;
                    Program.SystemContainer.SysPara.Gts_Affinity_Row_Y = Program.SystemContainer.SysPara.Gts_Calibration_Y_Cell != 0 ? (int)(Program.SystemContainer.SysPara.Gts_Calibration_Y_Len / Program.SystemContainer.SysPara.Gts_Calibration_Y_Cell) : 1;
                    Program.SystemContainer.SysPara.Gts_Calibration_Col_X = Program.SystemContainer.SysPara.Gts_Affinity_Col_X + 1;
                    Program.SystemContainer.SysPara.Gts_Calibration_Row_Y = Program.SystemContainer.SysPara.Gts_Affinity_Row_Y + 1;
                    XCalibratetextBox.Text = Program.SystemContainer.SysPara.Gts_Calibration_Col_X.ToString();
                    YCalibratetextBox.Text = Program.SystemContainer.SysPara.Gts_Calibration_Row_Y.ToString();
                    XAffinitytextBox.Text = Program.SystemContainer.SysPara.Gts_Affinity_Col_X.ToString();
                    YAffinitytextBox.Text = Program.SystemContainer.SysPara.Gts_Affinity_Row_Y.ToString();
                    RtcMarkParagroupBox.Enabled = false;
                    break;
                case 1:
                    CorrectMethodcomboBox.SelectedIndex = Program.SystemContainer.SysPara.Rtc_Calibration_Method == 3 ? 0 : 1;
                    XLengthnumericUpDown.Value = Program.SystemContainer.SysPara.Rtc_Calibration_X_Len;
                    YLengthnumericUpDown.Value = Program.SystemContainer.SysPara.Rtc_Calibration_Y_Len;
                    XCellnumericUpDown.Value = Program.SystemContainer.SysPara.Rtc_Calibration_X_Cell != 0 ? Program.SystemContainer.SysPara.Rtc_Calibration_X_Cell : 1;
                    YCellnumericUpDown.Value = Program.SystemContainer.SysPara.Rtc_Calibration_Y_Cell != 0 ? Program.SystemContainer.SysPara.Rtc_Calibration_Y_Cell : 1;
                    Program.SystemContainer.SysPara.Rtc_Affinity_Col_X = Program.SystemContainer.SysPara.Rtc_Calibration_X_Cell != 0 ? (int)(Program.SystemContainer.SysPara.Rtc_Calibration_X_Len / Program.SystemContainer.SysPara.Rtc_Calibration_X_Cell) : 1;
                    Program.SystemContainer.SysPara.Rtc_Affinity_Row_Y = Program.SystemContainer.SysPara.Rtc_Calibration_Y_Cell != 0 ? (int)(Program.SystemContainer.SysPara.Rtc_Calibration_Y_Len / Program.SystemContainer.SysPara.Rtc_Calibration_Y_Cell) : 1;
                    Program.SystemContainer.SysPara.Rtc_Calibration_Col_X = Program.SystemContainer.SysPara.Rtc_Affinity_Col_X + 1;
                    Program.SystemContainer.SysPara.Rtc_Calibration_Row_Y = Program.SystemContainer.SysPara.Rtc_Affinity_Row_Y + 1;
                    XCalibratetextBox.Text = Program.SystemContainer.SysPara.Rtc_Calibration_Col_X.ToString();
                    YCalibratetextBox.Text = Program.SystemContainer.SysPara.Rtc_Calibration_Row_Y.ToString();
                    XAffinitytextBox.Text = Program.SystemContainer.SysPara.Rtc_Affinity_Col_X.ToString();
                    YAffinitytextBox.Text = Program.SystemContainer.SysPara.Rtc_Affinity_Row_Y.ToString();
                    RtcMarkTypecomboBox.SelectedIndex = Program.SystemContainer.SysPara.Rtc_Distortion_Data_Type;
                    RtcAligncheckBox.Checked = Program.SystemContainer.SysPara.Rtc_Get_Data_Align == 0 ? false : true;
                    RtcCorrectTypecheckBox.Checked = Program.SystemContainer.SysPara.RtcCorrectType == 0 ? false : true;
                    switch (Program.SystemContainer.SysPara.Rtc_Distortion_Data_Type)
                    {
                        case 0://0 - 圆
                            RtcCircleRadiusLabel.Visible = true;
                            RtcCircleRadiusnumericUpDown.Visible = true;
                            RtcCircleRadiusnumericUpDown.Value = Program.SystemContainer.SysPara.Rtc_Distortion_Data_Radius;
                            break;
                        default://其他 - 直线
                            RtcCircleRadiusLabel.Visible = false;
                            RtcCircleRadiusnumericUpDown.Visible = false;
                            break;
                    }
                    RtcMarkParagroupBox.Enabled = true;
                    break;
                default:
                    break;
            }
            //取消标志
            Thread.Sleep(30);
            SysParaWRFlag = false;
        }
        /// <summary>
        /// 刷新振镜与Org距离
        /// </summary>
        private void RefreshRtcOrgDistance()
        {
            SysParaWRFlag = true;
            Thread.Sleep(30);
            RtcOrgDistanceXnumericUpDown.Value = Program.SystemContainer.SysPara.Rtc_Org.X;
            RtcOrgDistanceYnumericUpDown.Value = Program.SystemContainer.SysPara.Rtc_Org.Y;
            Thread.Sleep(30);
            SysParaWRFlag = false;
        }
        /// <summary>
        /// 刷新工作坐标
        /// </summary>
        private void RefreshWork()
        {
            SysParaWRFlag = true;
            Thread.Sleep(30);
            WorkXnumericUpDown.Value = Program.SystemContainer.SysPara.Work.X;
            WorkYnumericUpDown.Value = Program.SystemContainer.SysPara.Work.Y;
            Thread.Sleep(30);
            SysParaWRFlag = false;
        }
        /// <summary>
        /// 更新系统参数
        /// </summary>
        private void UpdateSysPara(object sender, EventArgs e)
        {
            if (SysParaWRFlag) return;
            Program.SystemContainer.SysPara.Rtc_Org = new Vector(RtcOrgDistanceXnumericUpDown.Value, RtcOrgDistanceYnumericUpDown.Value);
            Program.SystemContainer.SysPara.Work = new Vector(WorkXnumericUpDown.Value, WorkYnumericUpDown.Value);
            Program.SystemContainer.SysPara.GtsCorrectFile = GtsCorrectFilePathtextBox.Text;
            Program.SystemContainer.SysPara.MarkJump = MarkJumpcheckBox.Checked;
            Program.SystemContainer.SysPara.CamEn = CamEncheckBox.Checked;            
            Program.SystemContainer.SysPara.ShieldBeepTime = (int)ShieldbeepTimenumericUpDown.Value;
            //更新校准参数
            Program.SystemContainer.SysPara.CalibrationSelect = CalibrationSelectcomboBox.SelectedIndex;
            switch (CalibrationSelectcomboBox.SelectedIndex)
            {
                case 0:
                    Program.SystemContainer.SysPara.Gts_Calibration_Method = CorrectMethodcomboBox.SelectedIndex == 0 ? 3 : 4;
                    Program.SystemContainer.SysPara.Gts_Calibration_X_Len = XLengthnumericUpDown.Value;
                    Program.SystemContainer.SysPara.Gts_Calibration_Y_Len = YLengthnumericUpDown.Value;
                    Program.SystemContainer.SysPara.Gts_Calibration_X_Cell = XCellnumericUpDown.Value;
                    Program.SystemContainer.SysPara.Gts_Calibration_Y_Cell = YCellnumericUpDown.Value;
                    Program.SystemContainer.SysPara.Gts_Affinity_Col_X = Program.SystemContainer.SysPara.Gts_Calibration_X_Cell != 0 ? (int)(Program.SystemContainer.SysPara.Gts_Calibration_X_Len / Program.SystemContainer.SysPara.Gts_Calibration_X_Cell) : 1;
                    Program.SystemContainer.SysPara.Gts_Affinity_Row_Y = Program.SystemContainer.SysPara.Gts_Calibration_Y_Cell != 0 ? (int)(Program.SystemContainer.SysPara.Gts_Calibration_Y_Len / Program.SystemContainer.SysPara.Gts_Calibration_Y_Cell) : 1;
                    Program.SystemContainer.SysPara.Gts_Calibration_Col_X = Program.SystemContainer.SysPara.Gts_Affinity_Col_X + 1;
                    Program.SystemContainer.SysPara.Gts_Calibration_Row_Y = Program.SystemContainer.SysPara.Gts_Affinity_Row_Y + 1;
                    XCalibratetextBox.Text = Program.SystemContainer.SysPara.Gts_Calibration_Col_X.ToString();
                    YCalibratetextBox.Text = Program.SystemContainer.SysPara.Gts_Calibration_Row_Y.ToString();
                    XAffinitytextBox.Text = Program.SystemContainer.SysPara.Gts_Affinity_Col_X.ToString();
                    YAffinitytextBox.Text = Program.SystemContainer.SysPara.Gts_Affinity_Row_Y.ToString();
                    RtcMarkParagroupBox.Enabled = false;
                    break;
                case 1:
                    Program.SystemContainer.SysPara.Rtc_Calibration_Method = CorrectMethodcomboBox.SelectedIndex == 0 ? 3 : 4;
                    Program.SystemContainer.SysPara.Rtc_Calibration_X_Len = XLengthnumericUpDown.Value;
                    Program.SystemContainer.SysPara.Rtc_Calibration_Y_Len = YLengthnumericUpDown.Value;
                    Program.SystemContainer.SysPara.Rtc_Calibration_X_Cell = XCellnumericUpDown.Value;
                    Program.SystemContainer.SysPara.Rtc_Calibration_Y_Cell = YCellnumericUpDown.Value;
                    Program.SystemContainer.SysPara.Rtc_Affinity_Col_X = Program.SystemContainer.SysPara.Rtc_Calibration_X_Cell != 0 ? (int)(Program.SystemContainer.SysPara.Rtc_Calibration_X_Len / Program.SystemContainer.SysPara.Rtc_Calibration_X_Cell) : 1;
                    Program.SystemContainer.SysPara.Rtc_Affinity_Row_Y = Program.SystemContainer.SysPara.Rtc_Calibration_Y_Cell != 0 ? (int)(Program.SystemContainer.SysPara.Rtc_Calibration_Y_Len / Program.SystemContainer.SysPara.Rtc_Calibration_Y_Cell) : 1;
                    Program.SystemContainer.SysPara.Rtc_Calibration_Col_X = Program.SystemContainer.SysPara.Rtc_Affinity_Col_X + 1;
                    Program.SystemContainer.SysPara.Rtc_Calibration_Row_Y = Program.SystemContainer.SysPara.Rtc_Affinity_Row_Y + 1;
                    XCalibratetextBox.Text = Program.SystemContainer.SysPara.Rtc_Calibration_Col_X.ToString();
                    YCalibratetextBox.Text = Program.SystemContainer.SysPara.Rtc_Calibration_Row_Y.ToString();
                    XAffinitytextBox.Text = Program.SystemContainer.SysPara.Rtc_Affinity_Col_X.ToString();
                    YAffinitytextBox.Text = Program.SystemContainer.SysPara.Rtc_Affinity_Row_Y.ToString();
                    Program.SystemContainer.SysPara.Rtc_Distortion_Data_Type = RtcMarkTypecomboBox.SelectedIndex;
                    Program.SystemContainer.SysPara.Rtc_Get_Data_Align = RtcAligncheckBox.Checked ? 1 : 0;
                    Program.SystemContainer.SysPara.RtcCorrectType = RtcCorrectTypecheckBox.Checked ? 1 : 0;
                    switch (Program.SystemContainer.SysPara.Rtc_Distortion_Data_Type)
                    {
                        case 0://0 - 圆
                            RtcCircleRadiusLabel.Visible = true;
                            RtcCircleRadiusnumericUpDown.Visible = true;
                            Program.SystemContainer.SysPara.Rtc_Distortion_Data_Radius = RtcCircleRadiusnumericUpDown.Value;
                            break;
                        default://其他 - 直线
                            RtcCircleRadiusLabel.Visible = false;
                            RtcCircleRadiusnumericUpDown.Visible = false;
                            break;
                    }
                    RtcMarkParagroupBox.Enabled = true;
                    break;
                default:
                    break;
            }
            Program.SystemContainer.SysPara.PointListRepeatTimes = (int)PointListRepeatTimesnumericUpDown.Value;
        }
       
        /// <summary>
        /// 系统参数保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SysParaSave_Click(object sender, EventArgs e)
        {
            OperatePara.SaveParaXml("Para", Program.SystemContainer.SysPara);
        }
        /// <summary>
        /// 系统参数读取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SyaParaRead_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确认覆盖当前系统参数？", "系统参数覆盖", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                Program.SystemContainer.SysPara = OperatePara.LoadParaXml("Para");
                //更新数据
                RefreshSysPara();// 刷新系统参数页面
                RefreshWorkPara();//刷新WorkPara参数
                RefreshAXisPara();//轴参数页面参数更新
                RefreshLaserHandlePara();//刷新激光页参数数据
                RefreshMainContainerPara();//刷新主页面参数
                RefreshMannualGtsPara();//刷新Gts页面参数值
                RefreshRtcPara();//更新RTC页面参数
            }           
        }       
        
        /// <summary>
        /// 选择平台校准文件Xml
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectGtsCorrectFilebutton_Click(object sender, EventArgs e)
        {
            // 获取文件名       
            OpenFileDialog openfile = new OpenFileDialog
            {
                Filter = "xml 文件(*.xml)|*.xml"
            };
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                Program.SystemContainer.SysPara.GtsCorrectFilePath = openfile.FileName;
                Program.SystemContainer.SysPara.GtsCorrectFile = System.IO.Path.GetFileName(openfile.FileName);
                GtsCorrectFilePathtextBox.Text = Program.SystemContainer.SysPara.GtsCorrectFilePath;//平台Xml校准文件路径
            }
        }
        /// <summary>
        /// 应用平台校准文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ApplyGtsCorrectFilebutton_Click(object sender, EventArgs e)
        {
            if (Program.SystemContainer.GTS_Fun.Load_Affinity_MatrixBySpecificfile(Program.SystemContainer.SysPara.GtsCorrectFilePath))
                MessageBox.Show("平台校准文件加载完成！！！");
            else
                MessageBox.Show("平台校准文件加载失败！！！");
        }
        /// <summary>
        /// 选择振镜坐标系校准文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectRtcCorrectFilebutton_Click(object sender, EventArgs e)
        {
            // 获取文件名       
            OpenFileDialog openfile = new OpenFileDialog
            {
                Filter = "xml 文件(*.xml)|*.xml"
            };
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                Program.SystemContainer.SysPara.RtcXmlCorrectFilePath = openfile.FileName;
                Program.SystemContainer.SysPara.RtcXmlCorrectFile = System.IO.Path.GetFileName(openfile.FileName);
                RtcXmlCorrectFilePathtextBox.Text = Program.SystemContainer.SysPara.RtcXmlCorrectFilePath;
            }
        }
        /// <summary>
        /// 应用振镜坐标系矫正文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ApplyRtcCorrectFilebutton_Click(object sender, EventArgs e)
        {
            if (Program.SystemContainer.RTC_Fun.Load_Affinity_MatrixBySpecificfile(Program.SystemContainer.SysPara.RtcXmlCorrectFilePath))
                MessageBox.Show("振镜Xml校准文件加载完成！！！");
            else
                MessageBox.Show("振镜Xml校准文件加载失败！！！");
        }
    }
}

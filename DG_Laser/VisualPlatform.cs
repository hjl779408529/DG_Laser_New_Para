using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace DG_Laser
{
    

    /// <summary>
    /// 虚拟平台坐标刷新
    /// </summary>
    partial class MainForm
    {
        //定义变量
        public Bitmap m_bmp = Properties.Resources.Cam;
        Point m_ptCanvas = new Point(0,0);           //画布原点在设备上的坐标
        Point m_ptBmp = new Point(0, 0);              //图像位于画布坐标系中的坐标
        string m_strMousePt = "";        //鼠标当前位置对应的坐标
        float m_nScale = 1.0F;      //缩放比例
        Point PlatFormOrigin = new Point(25,375);
        Point MousePos = new Point(0,0);
        Vector GoPos = new Vector(0,0);
        bool PosFlag = false;//定位指定点标志
        /// <summary>
        /// 重绘PictureBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlantFormpictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (e.Graphics == null) return;
            Graphics g = e.Graphics;                                 //读入传入的图像
            g.TranslateTransform(m_ptCanvas.X, m_ptCanvas.Y);       //设置坐标偏移
            g.ScaleTransform(m_nScale, m_nScale);                   //设置缩放比
            g.DrawImage(m_bmp, m_ptBmp);         //绘制图像
            g.ResetTransform(); 
            //获取红光坐标

            //计算屏幕左上角 和 右下角 对应画布上的坐标
            Size szTemp = PlantFormpictureBox.Size - (Size)m_ptCanvas;
            PointF ptCanvasOnShowRectLT = new PointF(
                -m_ptCanvas.X / m_nScale, -m_ptCanvas.Y / m_nScale);
            PointF ptCanvasOnShowRectRB = new PointF(
                szTemp.Width / m_nScale, szTemp.Height / m_nScale);
            //显示文字信息
            //string strDraw = "缩放比: " + m_nScale.ToString("F1") +
            //    "\n图像原点: " + string.Format("({0},{1})", m_ptCanvas.X, m_ptCanvas.Y) +
            //    "\n左上角: " + string.Format("({0},{1})", Point.Round(ptCanvasOnShowRectLT).X, Point.Round(ptCanvasOnShowRectLT).Y) +
            //    "\n右下角: " + string.Format("({0},{1})", Point.Round(ptCanvasOnShowRectRB).X, Point.Round(ptCanvasOnShowRectRB).Y) +
            //    "\n平台原点: " + string.Format("({0},{1})", PlatFormOrigin.X, PlatFormOrigin.Y) +
            //    "\n鼠标坐标: "+ string.Format("({0},{1})", MousePos.X, MousePos.Y) + 
            //    "\n定位坐标: " + string.Format("({0},{1})", GoPos.X, GoPos.Y);
            string strDraw = "定位坐标: " + string.Format("({0},{1})", GoPos.X, GoPos.Y);
            Size strSize = TextRenderer.MeasureText(strDraw, this.Font);
            //绘制文字信息
            SolidBrush sb = new SolidBrush(Color.FromArgb(125, 0, 0, 0));
            g.FillRectangle(sb, 0, 0, strSize.Width, strSize.Height);
            g.DrawString(strDraw, this.Font, Brushes.Yellow, 0, 0);
            strSize = TextRenderer.MeasureText(m_strMousePt, this.Font);
            g.FillRectangle(sb, PlantFormpictureBox.Width - strSize.Width, 0, strSize.Width, strSize.Height);
            g.DrawString(m_strMousePt, this.Font, Brushes.Yellow, PlantFormpictureBox.Width - strSize.Width, 0);
            sb.Dispose();
        }
        /// <summary>
        /// 鼠标移动事件，更新坐标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlantFormpictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            MousePos = e.Location;
            GoPos = new Vector(MousePos.X - PlatFormOrigin.X, PlatFormOrigin.Y - MousePos.Y);
            PlantFormpictureBox.Invalidate();
        }
        /// <summary>
        /// 鼠标单击定位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlantFormpictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (!PosFlag) return;
            //判断定位坐标是否合适
            Vector MarkPoint = GoPos - Program.SystemContainer.SysPara.Rtc_Org;
            //判断坐标是否超出定位范围
            if (!DeterminePoint(MarkPoint)) return;
            //定位坐标
            if (!GtsRunningFlag)
            {
                GtsRunningFlag = true;
                ButtonDisable();
                SectionWorkThread = new Thread(delegate ()
                {
                    Program.SystemContainer.GTS_Fun.Gts_Point_Go(MarkPoint, 1);
                    ButtonEnable();
                    GtsRunningFlag = false;
                    RefreshGoMousePosbutton();
                });
                SectionWorkThread.Start();
            }
        }
        /// <summary>
        /// 定位至鼠标指定位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoMousePosbutton_Click(object sender, EventArgs e)
        {
            RefreshGoMousePosbutton();
        }
        /// <summary>
        /// 刷新定位至鼠标指定位置按钮
        /// </summary>
        private void RefreshGoMousePosbutton()
        {
            this.Invoke((EventHandler)delegate
            {
                PosFlag = !PosFlag;//切换标志位
                if (PosFlag)
                {
                    GoMousePosbutton.ForeColor = Color.Green;
                }
                else
                {
                    GoMousePosbutton.ForeColor = Color.Black;
                }
            });
        }
        /// <summary>
        /// 切换至相机位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SwitchToCambutton_Click(object sender, EventArgs e)
        {
            Vector CurrentPos = Program.SystemContainer.GTS_Fun.Get_Coordinate(1);
            //判断定位坐标是否合适
            Vector MarkPoint = CurrentPos + Program.SystemContainer.SysPara.Rtc_Org;
            //判断坐标是否超出定位范围
            if (!DeterminePoint(MarkPoint)) return;
            //定位坐标
            if (!GtsRunningFlag)
            {
                GtsRunningFlag = true;
                ButtonDisable();
                SectionWorkThread = new Thread(delegate ()
                {
                    Program.SystemContainer.GTS_Fun.Gts_Point_Go(MarkPoint, 1);
                    ButtonEnable();
                    GtsRunningFlag = false;
                });
                SectionWorkThread.Start();
            }
        }        
        /// <summary>
        /// 定位指定坐标，相机Mark对位界面使用
        /// </summary>
        private void GoPointRun(Vector Point)
        {
            if (!GtsRunningFlag)
            {
                GtsRunningFlag = true;
                ButtonDisable();
                SectionWorkThread = new Thread(delegate ()
                {
                    Program.SystemContainer.GTS_Fun.Gts_Point_Go(Point, 1);
                    ButtonEnable();
                    GtsRunningFlag = false;
                });
                SectionWorkThread.Start();
            };
        }
        /// <summary>
        /// 校验Mark序列是否可以看到所有点
        /// </summary>
        private void CheckMarkPointList(Vector Point)
        {
            if (!GtsRunningFlag)
            {
                GtsRunningFlag = true;
                ButtonDisable();
                SectionWorkThread = new Thread(delegate ()
                {

                    //校验Mark序列
                    Mark_Certify(Point);
                    //结束恢复个按钮状态
                    ButtonEnable();
                    GtsRunningFlag = false;
                });
                SectionWorkThread.Start();
            };
        }
        /// <summary>
        /// 判断坐标是否在平台定位范围内
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        private bool DeterminePoint(Vector point)
        {
            if ((point.X < -2) || (point.X > Program.SystemContainer.SysPara.Work.X) || (point.Y < -(Program.SystemContainer.SysPara.Rtc_Org.Y + 1)) || (point.Y > Program.SystemContainer.SysPara.Work.Y))
            {
                MessageBox.Show(string.Format("当前坐标:({0},{1})超出平台定位范围！！！", point.X, point.Y));
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// X+步进
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainXJogPositive_Click(object sender, EventArgs e)
        {
            if (!GtsRunningFlag)
            {
                GtsRunningFlag = true;
                ButtonDisable();
                SectionWorkThread = new Thread(delegate ()
                {
                    Program.SystemContainer.GTS_Fun.Gts_Coordinate_Jog(Program.SystemContainer.SysPara.CoordinateJogStep, 0);
                    ButtonEnable();
                    GtsRunningFlag = false;
                });
                SectionWorkThread.Start();
            }
        }
        /// <summary>
        /// X-步进
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainXJogNegative_Click(object sender, EventArgs e)
        {
            if (!GtsRunningFlag)
            {
                GtsRunningFlag = true;
                ButtonDisable();
                SectionWorkThread = new Thread(delegate ()
                {
                    Program.SystemContainer.GTS_Fun.Gts_Coordinate_Jog(-Program.SystemContainer.SysPara.CoordinateJogStep, 0);
                    ButtonEnable();
                    GtsRunningFlag = false;
                });
                SectionWorkThread.Start();
            }
        }
        /// <summary>
        /// Y+步进
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainYJogPositive_Click(object sender, EventArgs e)
        {
            if (!GtsRunningFlag)
            {
                GtsRunningFlag = true;
                ButtonDisable();
                SectionWorkThread = new Thread(delegate ()
                {
                    Program.SystemContainer.GTS_Fun.Gts_Coordinate_Jog(0, Program.SystemContainer.SysPara.CoordinateJogStep);
                    ButtonEnable();
                    GtsRunningFlag = false;
                });
                SectionWorkThread.Start();
            }
        }
        /// <summary>
        /// Y-步进
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainYJogNegative_Click(object sender, EventArgs e)
        {
            if (!GtsRunningFlag)
            {
                GtsRunningFlag = true;
                ButtonDisable();
                SectionWorkThread = new Thread(delegate ()
                {
                    Program.SystemContainer.GTS_Fun.Gts_Coordinate_Jog(0, -Program.SystemContainer.SysPara.CoordinateJogStep);
                    ButtonEnable();
                    GtsRunningFlag = false;
                });
                SectionWorkThread.Start();
            }
        }
        /// <summary>
        /// 方向控制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainFormPageContainer_KeyUp(object sender, KeyEventArgs e)
        {
            if ((!GtsRunningFlag) && (tabFormControl.TabForm.Name == "主页"))
            {
                GtsRunningFlag = true;
                ButtonDisable();
                SectionWorkThread = new Thread(delegate ()
                {
                    switch (e.KeyCode)
                    {
                        case Keys.Left://X负方向
                            Program.SystemContainer.GTS_Fun.Gts_Coordinate_Jog(-Program.SystemContainer.SysPara.CoordinateJogStep, 0);//X-
                            break;
                        case Keys.Right://X正方向
                            Program.SystemContainer.GTS_Fun.Gts_Coordinate_Jog(Program.SystemContainer.SysPara.CoordinateJogStep, 0);//X+
                            break;
                        case Keys.Up://Y负方向
                            Program.SystemContainer.GTS_Fun.Gts_Coordinate_Jog(0, -Program.SystemContainer.SysPara.CoordinateJogStep);//Y-
                            break;
                        case Keys.Down://Y正方向
                            Program.SystemContainer.GTS_Fun.Gts_Coordinate_Jog(0, Program.SystemContainer.SysPara.CoordinateJogStep);//Y+
                            break;
                        default:
                            break;
                    }
                    ButtonEnable();
                    GtsRunningFlag = false;
                });
                SectionWorkThread.Start();
            }
        }
        
       
        /// <summary>
        /// 点位选择切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SwitchPointListSelectcomboBox(object sender, EventArgs e)
        {
            MainContainerParaWRFlag = true;
            Thread.Sleep(30);
            Vector Temp = new Vector(0,0);
            Program.SystemContainer.SysPara.PointListIndex = PointListSelectcomboBox.SelectedIndex;
            switch (Program.SystemContainer.SysPara.PointListIndex)
            {
                case 0://自由点位
                    Temp =new Vector(Program.SystemContainer.SysPara.FreedomPoint);
                    break;
                case 1://待机点位
                    Temp = new Vector(Program.SystemContainer.SysPara.StandbyPoint);
                    break;
                case 2://指定点位
                    Temp = new Vector(Program.SystemContainer.SysPara.ResignationPoint);
                    break;
                case 3://左暂停位
                    Temp = new Vector(Program.SystemContainer.SysPara.LeftPausePoint);
                    break;
                case 4://右暂停位
                    Temp = new Vector(Program.SystemContainer.SysPara.RightPausePoint);
                    break;
                case 5://下料点位
                    Temp = new Vector(Program.SystemContainer.SysPara.Upload_Point);
                    break;
                case 6://调试点位
                    Temp = new Vector(Program.SystemContainer.SysPara.Debug_Gts_Basis);
                    break;
                default:
                    break;
            }
            //刷新显示值
            PointListXnumericUpDown.Value = Temp.X;
            PointListYnumericUpDown.Value = Temp.Y;
            Thread.Sleep(30);
            MainContainerParaWRFlag = false;           
        }
        /// <summary>
        /// 刷新主页面参数
        /// </summary>
        private void RefreshMainContainerPara()
        {
            MainContainerParaWRFlag = true;//MainContainerPara主界面参数变化初始化标志
            Thread.Sleep(30);
            //单步Jog
            MainCoordinateJogDistance.Value = Program.SystemContainer.SysPara.CoordinateJogStep;
            //选择起始加工位置
            Start_Pos_Sel.SelectedIndex = Program.SystemContainer.SysPara.Calibration_Type;

            //点位选择List
            Vector Temp = new Vector(0, 0);
            PointListSelectcomboBox.SelectedIndex = Program.SystemContainer.SysPara.PointListIndex;
            switch (Program.SystemContainer.SysPara.PointListIndex)
            {
                case 0://自由点位
                    Temp = new Vector(Program.SystemContainer.SysPara.FreedomPoint);
                    break;
                case 1://待机点位
                    Temp = new Vector(Program.SystemContainer.SysPara.StandbyPoint);
                    break;
                case 2://指定点位
                    Temp = new Vector(Program.SystemContainer.SysPara.ResignationPoint);
                    break;
                case 3://左暂停位
                    Temp = new Vector(Program.SystemContainer.SysPara.LeftPausePoint);
                    break;
                case 4://右暂停位
                    Temp = new Vector(Program.SystemContainer.SysPara.RightPausePoint);
                    break;
                case 5://下料点位
                    Temp = new Vector(Program.SystemContainer.SysPara.Upload_Point);
                    break;
                case 6://调试点位
                    Temp = new Vector(Program.SystemContainer.SysPara.Debug_Gts_Basis);
                    break;
                default:
                    break;
            }
            //刷新显示值
            PointListXnumericUpDown.Value = Temp.X;
            PointListYnumericUpDown.Value = Temp.Y;   
            //解除标志
            Thread.Sleep(30);
            MainContainerParaWRFlag = false;
        }
        /// <summary>
        /// 更新主页面参数值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateMainContainerPara(object sender, EventArgs e)
        {
            if (MainContainerParaWRFlag) return;
            //加工起始位选择
            Program.SystemContainer.SysPara.Calibration_Type = (UInt16)Start_Pos_Sel.SelectedIndex;
            //加工方式选择
            Program.SystemContainer.SysPara.Work_Type_Select = Work_Type_Select_List.SelectedIndex;
            //步进值更新
            Program.SystemContainer.SysPara.CoordinateJogStep = MainCoordinateJogDistance.Value;
            //点位数据更新
            Vector MarkPoint = new Vector(PointListXnumericUpDown.Value, PointListYnumericUpDown.Value);
            switch (Program.SystemContainer.SysPara.PointListIndex)
            {
                case 0://自由点位
                    Program.SystemContainer.SysPara.FreedomPoint = new Vector(MarkPoint);
                    break;
                case 1://待机点位
                    Program.SystemContainer.SysPara.StandbyPoint = new Vector(MarkPoint);
                    break;
                case 2://指定点位
                    Program.SystemContainer.SysPara.ResignationPoint = new Vector(MarkPoint);
                    break;
                case 3://左暂停位
                    Program.SystemContainer.SysPara.LeftPausePoint = new Vector(MarkPoint);
                    break;
                case 4://右暂停位
                    Program.SystemContainer.SysPara.RightPausePoint = new Vector(MarkPoint);
                    break;
                case 5://下料点位
                    Program.SystemContainer.SysPara.Upload_Point = new Vector(MarkPoint);
                    break;
                case 6://调试点位
                    Program.SystemContainer.SysPara.Debug_Gts_Basis = new Vector(MarkPoint);
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 将PointListSelectcomboBox 选定坐标 设置为当前激光照射坐标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetPointListbutton_Click(object sender, EventArgs e)
        {
            Vector Tmp = Program.SystemContainer.GTS_Fun.Get_Coordinate(1);//获取当前平台坐标
            //判断定位坐标是否合适
            Vector MarkPoint = Tmp + Program.SystemContainer.SysPara.Rtc_Org;
            //判断坐标是否超出定位范围
            if (!DeterminePoint(MarkPoint)) return;
            MainContainerParaWRFlag = true;
            Thread.Sleep(30);
            switch (Program.SystemContainer.SysPara.PointListIndex)
            {
                case 0://自由点位
                    Program.SystemContainer.SysPara.FreedomPoint = new Vector(MarkPoint);
                    break;
                case 1://待机点位
                    Program.SystemContainer.SysPara.StandbyPoint = new Vector(MarkPoint);
                    break;
                case 2://指定点位
                    Program.SystemContainer.SysPara.ResignationPoint = new Vector(MarkPoint);
                    break;
                case 3://左暂停位
                    Program.SystemContainer.SysPara.LeftPausePoint = new Vector(MarkPoint);
                    break;
                case 4://右暂停位
                    Program.SystemContainer.SysPara.RightPausePoint = new Vector(MarkPoint);
                    break;
                case 5://下料点位
                    Program.SystemContainer.SysPara.Upload_Point = new Vector(MarkPoint);
                    break;
                case 6://调试点位
                    Program.SystemContainer.SysPara.Debug_Gts_Basis = new Vector(MarkPoint);
                    break;
                default:
                    break;
            }
            PointListXnumericUpDown.Value = MarkPoint.X;
            PointListYnumericUpDown.Value = MarkPoint.Y;
            Thread.Sleep(30);
            MainContainerParaWRFlag = false;
        }
        /// <summary>
        /// 定位至PointListSelectcomboBox 选定坐标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoPointListbutton_Click(object sender, EventArgs e)
        {
            Vector Temp = new Vector(0, 0);
            switch (Program.SystemContainer.SysPara.PointListIndex)
            {
                case 0://自由点位
                    Temp = new Vector(Program.SystemContainer.SysPara.FreedomPoint);
                    break;
                case 1://待机点位
                    Temp = new Vector(Program.SystemContainer.SysPara.StandbyPoint);
                    break;
                case 2://指定点位
                    Temp = new Vector(Program.SystemContainer.SysPara.ResignationPoint);
                    break;
                case 3://左暂停位
                    Temp = new Vector(Program.SystemContainer.SysPara.LeftPausePoint);
                    break;
                case 4://右暂停位
                    Temp = new Vector(Program.SystemContainer.SysPara.RightPausePoint);
                    break;
                case 5://下料点位
                    Temp = new Vector(Program.SystemContainer.SysPara.Upload_Point);
                    break;
                case 6://调试点位
                    Temp = new Vector(Program.SystemContainer.SysPara.Debug_Gts_Basis);
                    break;
                default:
                    break;
            }
            //判断定位坐标是否合适
            Vector MarkPoint = Temp - Program.SystemContainer.SysPara.Rtc_Org;
            //判断坐标是否超出定位范围
            if (!DeterminePoint(MarkPoint)) return;
            //去指定点位
            GoPointRun(MarkPoint);
        }
    }
}

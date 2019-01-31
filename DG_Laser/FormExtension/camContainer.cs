using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DG_Laser
{
    /// <summary>
    /// 相机视图部分
    /// </summary>
    partial class MainForm
    {
        CameraCapture cameraDisplay;//相机视图显示界面
        short Intrigue = 1;//触发数据
        /// <summary>
        /// camContainerInitial
        /// </summary>
        private void camContainerInitial() 
        {
            //相机操作
            IntrigueType.Value = (short)Intrigue;
            //Mark识别类型
            Mark_Type_List.SelectedIndex = (Program.SystemContainer.SysPara.Camera_Mark_Type - 1);
        }
        /// <summary>
        /// 重新连接相机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Re_Connect_Click(object sender, EventArgs e)
        {
            Program.SystemContainer.T_Client.TCP_Start(Program.SystemContainer.SysPara.Server_Ip, Program.SystemContainer.SysPara.Server_Port);
        }
        /// <summary>
        /// 断开相机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Disconnect_Tcp_Click(object sender, EventArgs e)
        {
            Program.SystemContainer.T_Client.Stop_Connect();
        }
        /// <summary>
        /// 触发代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IntrigueType_ValueChanged(object sender, EventArgs e)
        {
            Intrigue = (short)IntrigueType.Value;
        }
        /// <summary>
        /// 触发拍照
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IntrigueTakePicture_Click(object sender, EventArgs e)
        {
            Vector Tmp = Program.SystemContainer.T_Client.Get_Cam_Actual_Pixel(Intrigue);//触发拍照 
            Vector Cor_Data = Program.SystemContainer.T_Client.Get_Coordinate_Corrrect_Point(Tmp.X, Tmp.Y);
            MessageBox.Show(string.Format("相机坐标：({0},{1})，实际坐标：({2},{3})", Tmp.X, Tmp.Y, Cor_Data.X, Cor_Data.Y));
        }

        /// <summary>
        /// Mark类型选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mark_Type_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.SystemContainer.SysPara.Camera_Mark_Type = (UInt16)(Mark_Type_List.SelectedIndex + 1);
        }
        /// <summary>
        /// 相机视图显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CamDisplay_Click(object sender, EventArgs e)
        {
            CameraCpatureView();
        }
        /// <summary>
        /// 相机视图显示调用
        /// </summary>
        private void CameraCpatureView()
        {
            if (cameraDisplay == null)
            {
                cameraDisplay = new CameraCapture();
                cameraDisplay.Show();
            }
            else
            {
                if (cameraDisplay.IsDisposed) //若子窗体关闭 则打开新子窗体 并显示
                {
                    cameraDisplay = new CameraCapture();
                    cameraDisplay.Show();
                }
                else
                {
                    cameraDisplay.Activate(); //使子窗体获得焦点
                }
            }
        }
        /// <summary>
        /// 刷新相机显示窗口图片
        /// </summary>
        public void RefreshCameraDisplay(Bitmap bitmap)
        {
            if (cameraDisplay != null)//cameraDisplay已经建立并显示
            {
                cameraDisplay.PictureBoxImgRefresh(bitmap);          
            }
        }
        /// <summary>
        /// 测试图像处理效果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Mat img = CvInvoke.Imread("./Pic/2.bmp");            
            CvInvoke.Imshow("src", img);
            Mat grayImg = new Mat();
            CvInvoke.CvtColor(img, grayImg, ColorConversion.Bgr2Gray);
            CvInvoke.Threshold(grayImg, grayImg, 80, 255, ThresholdType.BinaryInv);
            Mat element = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(3, 3), new Point(-1, -1));
            CvInvoke.Dilate(grayImg, grayImg, element, new Point(-1, -1), 3, BorderType.Default, new MCvScalar());
            CvInvoke.Erode(grayImg, grayImg, element, new Point(-1, -1), 3, BorderType.Default, new MCvScalar());
            CvInvoke.Imshow("gray", grayImg);
            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            CvInvoke.FindContours(grayImg, contours, null, RetrType.External, ChainApproxMethod.ChainApproxNone);
            //CvInvoke.DrawContours(img, contours, -1, new MCvScalar(0, 255, 0), 1);
            CircleF circle0 = new CircleF();
            CircleF circle1 = new CircleF();
            double distance = 0, temDistance = 0;
            for (int i = 0;i < contours.Size;i++)
            {                
                circle0 = CvInvoke.MinEnclosingCircle(contours[i]);
                if (circle0.Radius >= 100)
                {                   
                    distance = Math.Sqrt((circle0.Center.X - img.Width / 2) * (circle0.Center.X - img.Width / 2) + (circle0.Center.Y - img.Height / 2) * (circle0.Center.Y - img.Height / 2));
                    if (temDistance == 0) temDistance = distance;
                    if (temDistance > distance)
                    {
                        circle1 = circle0;
                        temDistance = distance;
                        if (temDistance == 0) break;//等于零，Mark点对中，结束寻找
                        continue;//继续
                    }
                    else if(temDistance == distance)
                    {
                        if ((circle0.Center.X <= circle1.Center.X) || (circle0.Center.Y <= circle1.Center.Y))
                        {
                            circle1 = circle0;
                            temDistance = distance;
                            if (temDistance == 0) break;//等于零，Mark点对中，结束寻找
                        }
                    }
                }                
            }
            CvInvoke.Circle(img, new Point((int)circle1.Center.X, (int)circle1.Center.Y), (int)circle1.Radius, new MCvScalar(0, 255, 255), 1);
            DrawCross(img, new Point((int)circle1.Center.X, (int)circle1.Center.Y), new MCvScalar(0, 255, 0), (int)circle1.Radius / 4, 1);            
            //图像处理
            DrawCross(img,new Point(img.Width / 2, img.Height / 2), new MCvScalar(0, 255, 0),20,1);
            //刷新图像
            Image<Bgr, Byte> srcImg = img.ToImage<Bgr, Byte>();
            RefreshCameraDisplay(srcImg.ToBitmap());
        }
        /// <summary> 
        /// 绘制十字光标
        /// </summary>
        /// <param name="img"></param>
        /// <param name="point"></param>
        /// <param name="color"></param>
        /// <param name="size"></param>
        /// <param name="thickness"></param>
        private void DrawCross(Mat img, Point point, MCvScalar color, int size, int thickness)
        {
            //绘制横线
            CvInvoke.Line(img, new Point(point.X - size / 2, point.Y), new Point(point.X + size / 2, point.Y), color, thickness, LineType.EightConnected, 0);
            //绘制竖线
            CvInvoke.Line(img, new Point(point.X, point.Y - size / 2), new Point(point.X, point.Y + size / 2), color, thickness, LineType.EightConnected, 0);
        }
    }
}

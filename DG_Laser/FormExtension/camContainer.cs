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
        }
        /// <summary>
        /// 重新连接相机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Re_Connect_Click(object sender, EventArgs e)
        {
            if(Program.SystemContainer.SysPara.CamEn)
                Program.SystemContainer.T_Client.TCP_Start(Program.SystemContainer.SysPara.Server_Ip, Program.SystemContainer.SysPara.Server_Port);
        }
        /// <summary>
        /// 断开相机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Disconnect_Tcp_Click(object sender, EventArgs e)
        {
            if (Program.SystemContainer.SysPara.CamEn)
                Program.SystemContainer.T_Client.Stop_Connect();
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

        
    }
}

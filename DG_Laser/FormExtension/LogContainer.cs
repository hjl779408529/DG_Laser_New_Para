using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DG_Laser
{
    /// <summary>
    /// 日志记录页面
    /// </summary>
    partial class MainForm
    {
        /// <summary>
        /// 日志记录页面初始化
        /// </summary>
        private void LogContainerInitial()
        {
            //绑定Cam_Data_Cal的日志事件
            DataResolve.LogInfo += new LogInfo(Info);
        }
        /// <summary>
        /// 日志记录带时间戳
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        public void appendInfo(string info)
        {
            this.Invoke((EventHandler)delegate
            {
                //Debug_Info_Display.AppendText(Cal_Elapse_Time.Get_Current_Time(1) + "\r\n");
                //Debug_Info_Display.AppendText(info + "\r\n");

                Debug_Info_Display.AppendText(Cal_Elapse_Time.Get_Current_Time(1) + "  ----  " + info + "\r\n");
            });
        }
        /// <summary>
        /// 日志记录
        /// </summary>
        /// <param name="info"></param>
        public void Info(string info)
        {
            this.Invoke((EventHandler)delegate
            {
                Debug_Info_Display.AppendText(info + "\r\n");
            });

        }
    }
}

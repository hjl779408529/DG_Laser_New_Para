using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;

namespace DG_Laser
{
    static class Program
    {

        public static Initial SystemContainer;//系统全局参数
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //初始化
            SystemContainer = new Initial();
            SystemContainer.Common_Initial();//参数和用户初始化
            SystemContainer.Load_Repeat_Para();//重复参数初始化
            SystemContainer.Load_Scissor_Para();//刀具参数初始化
            SystemContainer.RS232_Initial();//232初始化
            SystemContainer.Tcp_Initial();//Tcp初始化
            SystemContainer.Gts_Initial();//Gts工控卡初始化
            SystemContainer.Rtc_Initial();//Rtc工控卡初始化
            SystemContainer.TimerEN();//定时器启动

            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            new MainForm().Show();
            Application.Run();
        }
    }
}

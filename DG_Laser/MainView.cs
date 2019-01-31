using DevExpress.XtraBars;
using SharpConfig;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DG_Laser
{
    public partial class MainForm : DevExpress.XtraBars.TabForm
    {
        
        bool FirstSign = false;   
        public MainForm()
        {
            InitializeComponent();            
            paraSetContainerInitial();//参数页面设置初始化数据
            ScissorListContainerInitial();//刀具列表初始化
            RepeatListContainerInitial();//重复参数列表初始化
            mainContainerInitial();//主页初始化
            loginFormPageContainerInitial();//登录页面初始化数据
            laserFormPageContainerInitial();//激光页面初始化数据
            manualGTSInitial();//GTS手动操作页面
            manualRTCInitial();//RTC手动操作页面
            statusFormPageContainerInitial();//状态刷新页面显示


        }
        void OnOuterFormCreating(object sender, OuterFormCreatingEventArgs e)
        {
            MainForm form = new MainForm();
            form.TabFormControl.Pages.Clear();
            e.Form = form;
            OpenFormCount++;
        }
        static int OpenFormCount = 1;
        /// <summary>
        /// 窗口退出关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainView_FormClosed(object sender, FormClosedEventArgs e)
        {
            IO_Monitor_Timer.Dispose();//状态监视定时器释放
            LW_Refresh_Timer.Dispose();//激光功率检测定时器关闭
            Axis_Handle_Timer.Dispose();//轴手动操作定时器关闭
            OperatePara.SaveParaXml("Para", Program.SystemContainer.SysPara);
            Program.SystemContainer.Save_Repeat_Para();
            Program.SystemContainer.Save_Scissor_Para();
            Program.SystemContainer.TimerOFF();
        }

    }
    
}

using DevExpress.XtraBars;
using DG_Laser.FormExtension;
using netDxf;
using SharpConfig;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        /// 主窗口加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            
            LogContainerInitial();//日志记录初始化
            mainContainerInitial();//主页初始化
            loginFormPageContainerInitial();//登录页面初始化数据
            laserFormPageContainerInitial();//激光页面初始化数据
            manualGTSInitial();//GTS手动操作页面
            manualRTCInitial();//RTC手动操作页面
            WorkParaInitial();//加工参数页面初始化
            camContainerInitial();//相机参数初始化
            paraSetContainerInitial();//参数页面设置初始化数据
            SectionWorkInitial();//分区加工数据初始化
            AxisParaContainerInitial();//轴参数页面初始化
            statusFormPageContainerInitial();//状态刷新页面显示

        }
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
            Program.SystemContainer.IO.ClearShieldBeepTimer.Dispose();//蜂鸣器屏蔽取消
            if (Program.SystemContainer.SysPara.CamEn) Program.SystemContainer.T_Client.Send_Data(30);//关闭摄像头软件
            OperatePara.SaveParaXml("Para", Program.SystemContainer.SysPara);
            Program.SystemContainer.Save_Scissor_Para();
            Program.SystemContainer.Save_Material_Storage();//保存材料库
            Program.SystemContainer.TimerOFF();
        }
        /// <summary>
        /// 复位设备
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetEquipment_Click(object sender, EventArgs e)
        {
            if (Program.SystemContainer.IO.Axis01_Err_Occur || Program.SystemContainer.IO.Axis02_Err_Occur)
            {
                Program.SystemContainer.GTS_Fun.Reset();//复位Gts控制卡
                MessageBox.Show("设备已复位，请重新归零设备！！！");
            }
        }
    }
    
}

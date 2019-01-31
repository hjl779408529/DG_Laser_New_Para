namespace DG_Laser
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
            if (--OpenFormCount == 0) System.Windows.Forms.Application.Exit();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabFormControl = new DevExpress.XtraBars.TabFormControl();
            this.barUserIndicate = new DevExpress.XtraBars.BarHeaderItem();
            this.tabFormDefaultManager1 = new DevExpress.XtraBars.TabFormDefaultManager();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.LoginFormPage = new DevExpress.XtraBars.TabFormPage();
            this.loginFormPageContainer = new DevExpress.XtraBars.TabFormContentContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Cancel_Button = new DevExpress.XtraEditors.SimpleButton();
            this.Confirm_Button = new DevExpress.XtraEditors.SimpleButton();
            this.Password_Input = new DevExpress.XtraEditors.TextEdit();
            this.User_List = new DevExpress.XtraEditors.ComboBoxEdit();
            this.User_Password = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.User_Name = new DevExpress.XtraEditors.LabelControl();
            this.workFormPage = new DevExpress.XtraBars.TabFormPage();
            this.mainFormPageContainer = new DevExpress.XtraBars.TabFormContentContainer();
            this.Debug_Info_Display = new System.Windows.Forms.RichTextBox();
            this.groupBox27 = new System.Windows.Forms.GroupBox();
            this.GoPoint = new System.Windows.Forms.Button();
            this.Cam_Work_Stop = new System.Windows.Forms.Button();
            this.Cam_Work_Start = new System.Windows.Forms.Button();
            this.GetFileName = new System.Windows.Forms.Button();
            this.EstablishCoordinate = new System.Windows.Forms.Button();
            this.AxisHome = new System.Windows.Forms.Button();
            this.groupBox26 = new System.Windows.Forms.GroupBox();
            this.label88 = new System.Windows.Forms.Label();
            this.Start_Pos_Sel = new System.Windows.Forms.ComboBox();
            this.label86 = new System.Windows.Forms.Label();
            this.BackY = new System.Windows.Forms.TextBox();
            this.label87 = new System.Windows.Forms.Label();
            this.BackX = new System.Windows.Forms.TextBox();
            this.label84 = new System.Windows.Forms.Label();
            this.Back_Pos_Select = new System.Windows.Forms.ComboBox();
            this.label85 = new System.Windows.Forms.Label();
            this.Work_Type_Select_List = new System.Windows.Forms.ComboBox();
            this.manualFormPage = new DevExpress.XtraBars.TabFormPage();
            this.manualFormPageContainer = new DevExpress.XtraBars.TabFormContentContainer();
            this.manualTabPane = new DevExpress.XtraBars.Navigation.TabPane();
            this.gtsManual = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.HomeSmoothTime = new System.Windows.Forms.TextBox();
            this.label49 = new System.Windows.Forms.Label();
            this.HomeDCC = new System.Windows.Forms.TextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.HomeACC = new System.Windows.Forms.TextBox();
            this.label51 = new System.Windows.Forms.Label();
            this.HomeSpeed = new System.Windows.Forms.TextBox();
            this.HomeDeviation = new System.Windows.Forms.TextBox();
            this.label52 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.Upper_Posed = new System.Windows.Forms.Button();
            this.Motor_Posed = new System.Windows.Forms.Button();
            this.MechanicHome = new System.Windows.Forms.Button();
            this.BoardAlarm = new System.Windows.Forms.Button();
            this.DriveBusy = new System.Windows.Forms.Button();
            this.ActualMode = new System.Windows.Forms.Label();
            this.EmgStop = new System.Windows.Forms.Button();
            this.ActualSpeed = new System.Windows.Forms.Label();
            this.ActualDCC = new System.Windows.Forms.Label();
            this.SmoothStop = new System.Windows.Forms.Button();
            this.ActualACC = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.JogDot = new System.Windows.Forms.Button();
            this.ManualSpeed = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.ServoON = new System.Windows.Forms.Button();
            this.PosClear = new System.Windows.Forms.Button();
            this.StatusClear = new System.Windows.Forms.Button();
            this.ManualStep = new System.Windows.Forms.TextBox();
            this.AlarmClear = new System.Windows.Forms.Button();
            this.label46 = new System.Windows.Forms.Label();
            this.DriverAlarm = new System.Windows.Forms.Button();
            this.ManualDCC = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.ManualACC = new System.Windows.Forms.TextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.GtsReset = new System.Windows.Forms.Button();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.ActualPos = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.CurrentPos = new System.Windows.Forms.Label();
            this.JogNegative = new System.Windows.Forms.Button();
            this.JogPositive = new System.Windows.Forms.Button();
            this.label35 = new System.Windows.Forms.Label();
            this.NegativeLimit = new System.Windows.Forms.Button();
            this.HomeSensor = new System.Windows.Forms.Button();
            this.PositveLimit = new System.Windows.Forms.Button();
            this.label31 = new System.Windows.Forms.Label();
            this.AxisSelect = new System.Windows.Forms.NumericUpDown();
            this.rtcManual = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.AutoDelaySwitch = new System.Windows.Forms.Button();
            this.Reset_Rtc = new System.Windows.Forms.Button();
            this.label32 = new System.Windows.Forms.Label();
            this.RtcPosReference = new System.Windows.Forms.TextBox();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.LaserOFF = new System.Windows.Forms.Button();
            this.LaserON = new System.Windows.Forms.Button();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.MoveMode = new System.Windows.Forms.Button();
            this.label34 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.MoveY = new System.Windows.Forms.TextBox();
            this.MoveX = new System.Windows.Forms.TextBox();
            this.RtcYJogNegative = new System.Windows.Forms.Button();
            this.RtcYJogPositive = new System.Windows.Forms.Button();
            this.RtcXJogNegative = new System.Windows.Forms.Button();
            this.RtcXJogPositive = new System.Windows.Forms.Button();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.label37 = new System.Windows.Forms.Label();
            this.Polygon_Delay = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.Jump_Delay = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.Mark_Delay = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.Laser_Off_Delay = new System.Windows.Forms.TextBox();
            this.label54 = new System.Windows.Forms.Label();
            this.Jump_Speed = new System.Windows.Forms.TextBox();
            this.label55 = new System.Windows.Forms.Label();
            this.Laser_ON_Delay = new System.Windows.Forms.TextBox();
            this.Change_Para_List = new System.Windows.Forms.Button();
            this.label56 = new System.Windows.Forms.Label();
            this.Mark_Speed = new System.Windows.Forms.TextBox();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.label57 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.ABSPosY = new System.Windows.Forms.TextBox();
            this.ABSPosX = new System.Windows.Forms.TextBox();
            this.ABSPos = new System.Windows.Forms.Button();
            this.groupBox20 = new System.Windows.Forms.GroupBox();
            this.label59 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.RtcHomeY = new System.Windows.Forms.TextBox();
            this.RtcHomeX = new System.Windows.Forms.TextBox();
            this.RtcHome = new System.Windows.Forms.Button();
            this.IOOperate = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.Buzzer = new System.Windows.Forms.Button();
            this.BeaconRed = new System.Windows.Forms.Button();
            this.BeaconGreen = new System.Windows.Forms.Button();
            this.BeaconYellow = new System.Windows.Forms.Button();
            this.Blow = new System.Windows.Forms.Button();
            this.Cylinder = new System.Windows.Forms.Button();
            this.Lamp = new System.Windows.Forms.Button();
            this.statusFormPage = new DevExpress.XtraBars.TabFormPage();
            this.statusFormPageContainer = new DevExpress.XtraBars.TabFormContentContainer();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.EXO10_Status = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.EXO9_Status = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.EXO8_Status = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.EXO7_Status = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.EXO6_Status = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.EXO5_Status = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.EXO4_Status = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.EXO3_Status = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.EXO2_Status = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.EXO1_Status = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.Homed_Status = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.EXI7_Status = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.EXI6_Status = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.EXI5_Status = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.EXI4_Status = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.EXI3_Status = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.EXI2_Status = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.EXI1_Status = new System.Windows.Forms.Button();
            this.laserFormPage = new DevExpress.XtraBars.TabFormPage();
            this.laserFormPageContainer = new DevExpress.XtraBars.TabFormContentContainer();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.LW_Re_Connect = new System.Windows.Forms.Button();
            this.LW_Refresh_List = new System.Windows.Forms.Button();
            this.LW_Com_List = new System.Windows.Forms.ComboBox();
            this.LW_Com_Status = new System.Windows.Forms.PictureBox();
            this.LW_Save_Data = new System.Windows.Forms.Button();
            this.LW_Acquisition_Once = new System.Windows.Forms.Button();
            this.Laser_Current_Watt_Label = new System.Windows.Forms.Label();
            this.Laser_Percent_Label = new System.Windows.Forms.Label();
            this.LW_PEC_Indicate = new System.Windows.Forms.TextBox();
            this.LW_Watt_Indicate = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.LC_Refresh_List = new System.Windows.Forms.Button();
            this.LC_Com_List = new System.Windows.Forms.ComboBox();
            this.LC_Re_connect = new System.Windows.Forms.Button();
            this.LC_Com_Status = new System.Windows.Forms.PictureBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.LC_Amp2_Set = new System.Windows.Forms.TextBox();
            this.LC_PRF_Confirm = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.LC_PEC_Confirm = new System.Windows.Forms.Button();
            this.LC_Amp1_Set = new System.Windows.Forms.TextBox();
            this.LC_PRF_Set_Value = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.LC_Seed_Set = new System.Windows.Forms.TextBox();
            this.LC_PEC_Set_Value = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.LC_Status = new System.Windows.Forms.RichTextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label26 = new System.Windows.Forms.Label();
            this.LC_Reset_Laser = new System.Windows.Forms.Button();
            this.LC_Refresh_Status = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.LC_Amp2_Current = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.LC_Amp1_Current = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.LC_Seed_Current = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.LC_Power_OFF = new System.Windows.Forms.Button();
            this.LC_Power_On = new System.Windows.Forms.Button();
            this.setFormPage = new DevExpress.XtraBars.TabFormPage();
            this.setFormPageContainer = new DevExpress.XtraBars.TabFormContentContainer();
            this.setTabPane = new DevExpress.XtraBars.Navigation.TabPane();
            this.paraSet = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.groupBox23 = new System.Windows.Forms.GroupBox();
            this.SyaParaRead = new System.Windows.Forms.Button();
            this.SysParaSave = new System.Windows.Forms.Button();
            this.label73 = new System.Windows.Forms.Label();
            this.ArcEndVelocitySet = new System.Windows.Forms.TextBox();
            this.label74 = new System.Windows.Forms.Label();
            this.LineEndVelocitySet = new System.Windows.Forms.TextBox();
            this.label75 = new System.Windows.Forms.Label();
            this.SmoothTimeSet = new System.Windows.Forms.TextBox();
            this.label76 = new System.Windows.Forms.Label();
            this.ArcACCSet = new System.Windows.Forms.TextBox();
            this.label77 = new System.Windows.Forms.Label();
            this.ArcVelocitySet = new System.Windows.Forms.TextBox();
            this.label78 = new System.Windows.Forms.Label();
            this.LineVelocitySet = new System.Windows.Forms.TextBox();
            this.label79 = new System.Windows.Forms.Label();
            this.LineACCSet = new System.Windows.Forms.TextBox();
            this.label80 = new System.Windows.Forms.Label();
            this.WorkY = new System.Windows.Forms.TextBox();
            this.label81 = new System.Windows.Forms.Label();
            this.WorkX = new System.Windows.Forms.TextBox();
            this.groupBox22 = new System.Windows.Forms.GroupBox();
            this.label69 = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.RtcOrgDistanceY = new System.Windows.Forms.TextBox();
            this.label71 = new System.Windows.Forms.Label();
            this.Set_txt_valueK = new System.Windows.Forms.TextBox();
            this.RtcOrgDistanceX = new System.Windows.Forms.TextBox();
            this.Mark_Group = new System.Windows.Forms.GroupBox();
            this.GoMark4 = new System.Windows.Forms.Button();
            this.Set_txt_markY4 = new System.Windows.Forms.TextBox();
            this.Set_txt_markX4 = new System.Windows.Forms.TextBox();
            this.label63 = new System.Windows.Forms.Label();
            this.GoMark3 = new System.Windows.Forms.Button();
            this.GoMark2 = new System.Windows.Forms.Button();
            this.GoMark1 = new System.Windows.Forms.Button();
            this.Set_txt_markX1 = new System.Windows.Forms.TextBox();
            this.Set_txt_markY3 = new System.Windows.Forms.TextBox();
            this.label64 = new System.Windows.Forms.Label();
            this.Set_txt_markX3 = new System.Windows.Forms.TextBox();
            this.label65 = new System.Windows.Forms.Label();
            this.Set_txt_markY2 = new System.Windows.Forms.TextBox();
            this.label66 = new System.Windows.Forms.Label();
            this.Set_txt_markX2 = new System.Windows.Forms.TextBox();
            this.label67 = new System.Windows.Forms.Label();
            this.Set_txt_markY1 = new System.Windows.Forms.TextBox();
            this.label68 = new System.Windows.Forms.Label();
            this.ScissorList = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.ScissorListView = new System.Windows.Forms.DataGridView();
            this.groupBox24 = new System.Windows.Forms.GroupBox();
            this.ScissorListLoad = new System.Windows.Forms.Button();
            this.ScissorListSave = new System.Windows.Forms.Button();
            this.label72 = new System.Windows.Forms.Label();
            this.Scissor_List = new System.Windows.Forms.ComboBox();
            this.RePeatList = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.RepeatListView = new System.Windows.Forms.DataGridView();
            this.groupBox25 = new System.Windows.Forms.GroupBox();
            this.RepeatListSaveLoad = new System.Windows.Forms.Button();
            this.label83 = new System.Windows.Forms.Label();
            this.Repeat_Times_UpDown = new System.Windows.Forms.NumericUpDown();
            this.RepeatListSave = new System.Windows.Forms.Button();
            this.label82 = new System.Windows.Forms.Label();
            this.Repeat_List = new System.Windows.Forms.ComboBox();
            this.CameraPara = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.groupBox28 = new System.Windows.Forms.GroupBox();
            this.IlluminateText = new System.Windows.Forms.TextBox();
            this.ExposureText = new System.Windows.Forms.TextBox();
            this.SizeText = new System.Windows.Forms.TextBox();
            this.ThreshHoldText = new System.Windows.Forms.TextBox();
            this.label92 = new System.Windows.Forms.Label();
            this.label91 = new System.Windows.Forms.Label();
            this.label90 = new System.Windows.Forms.Label();
            this.label89 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.Mark_Type_List = new System.Windows.Forms.ComboBox();
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.label61 = new System.Windows.Forms.Label();
            this.IntrigueType = new System.Windows.Forms.NumericUpDown();
            this.Disconnect_Tcp = new System.Windows.Forms.Button();
            this.IntrigueTakePicture = new System.Windows.Forms.Button();
            this.Re_Connect = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.CamDisplay = new System.Windows.Forms.Button();
            this.manualFormPag = new DevExpress.XtraBars.TabFormPage();
            this.tabFormContentContainer4 = new DevExpress.XtraBars.TabFormContentContainer();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.tabFormControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabFormDefaultManager1)).BeginInit();
            this.loginFormPageContainer.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Password_Input.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.User_List.Properties)).BeginInit();
            this.mainFormPageContainer.SuspendLayout();
            this.groupBox27.SuspendLayout();
            this.groupBox26.SuspendLayout();
            this.manualFormPageContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.manualTabPane)).BeginInit();
            this.manualTabPane.SuspendLayout();
            this.gtsManual.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AxisSelect)).BeginInit();
            this.rtcManual.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.groupBox19.SuspendLayout();
            this.groupBox20.SuspendLayout();
            this.IOOperate.SuspendLayout();
            this.statusFormPageContainer.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.laserFormPageContainer.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LW_Com_Status)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LC_Com_Status)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.setFormPageContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.setTabPane)).BeginInit();
            this.setTabPane.SuspendLayout();
            this.paraSet.SuspendLayout();
            this.groupBox23.SuspendLayout();
            this.groupBox22.SuspendLayout();
            this.Mark_Group.SuspendLayout();
            this.ScissorList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScissorListView)).BeginInit();
            this.groupBox24.SuspendLayout();
            this.RePeatList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RepeatListView)).BeginInit();
            this.groupBox25.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Repeat_Times_UpDown)).BeginInit();
            this.CameraPara.SuspendLayout();
            this.groupBox28.SuspendLayout();
            this.groupBox21.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IntrigueType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabFormControl
            // 
            this.tabFormControl.AllowMoveTabs = false;
            this.tabFormControl.AllowMoveTabsToOuterForm = false;
            this.tabFormControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barUserIndicate});
            this.tabFormControl.Location = new System.Drawing.Point(0, 0);
            this.tabFormControl.Manager = this.tabFormDefaultManager1;
            this.tabFormControl.Margin = new System.Windows.Forms.Padding(5);
            this.tabFormControl.Name = "tabFormControl";
            this.tabFormControl.Pages.Add(this.LoginFormPage);
            this.tabFormControl.Pages.Add(this.workFormPage);
            this.tabFormControl.Pages.Add(this.manualFormPage);
            this.tabFormControl.Pages.Add(this.statusFormPage);
            this.tabFormControl.Pages.Add(this.laserFormPage);
            this.tabFormControl.Pages.Add(this.setFormPage);
            this.tabFormControl.SelectedPage = this.workFormPage;
            this.tabFormControl.ShowAddPageButton = false;
            this.tabFormControl.ShowTabCloseButtons = false;
            this.tabFormControl.Size = new System.Drawing.Size(1356, 70);
            this.tabFormControl.TabForm = this;
            this.tabFormControl.TabIndex = 0;
            this.tabFormControl.TabRightItemLinks.Add(this.barUserIndicate);
            this.tabFormControl.TabStop = false;
            this.tabFormControl.SelectedPageChanging += new DevExpress.XtraBars.TabFormSelectedPageChangingEventHandler(this.tabFormControl_SelectedPageChanging);
            this.tabFormControl.OuterFormCreating += new DevExpress.XtraBars.OuterFormCreatingEventHandler(this.OnOuterFormCreating);
            // 
            // barUserIndicate
            // 
            this.barUserIndicate.Id = 0;
            this.barUserIndicate.Name = "barUserIndicate";
            // 
            // tabFormDefaultManager1
            // 
            this.tabFormDefaultManager1.DockControls.Add(this.barDockControlTop);
            this.tabFormDefaultManager1.DockControls.Add(this.barDockControlBottom);
            this.tabFormDefaultManager1.DockControls.Add(this.barDockControlLeft);
            this.tabFormDefaultManager1.DockControls.Add(this.barDockControlRight);
            this.tabFormDefaultManager1.DockingEnabled = false;
            this.tabFormDefaultManager1.Form = this;
            this.tabFormDefaultManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barUserIndicate});
            this.tabFormDefaultManager1.MaxItemId = 1;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 70);
            this.barDockControlTop.Manager = null;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(5);
            this.barDockControlTop.Size = new System.Drawing.Size(1356, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 763);
            this.barDockControlBottom.Manager = null;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(5);
            this.barDockControlBottom.Size = new System.Drawing.Size(1356, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 70);
            this.barDockControlLeft.Manager = null;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(5);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 693);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1356, 70);
            this.barDockControlRight.Manager = null;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(5);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 693);
            // 
            // LoginFormPage
            // 
            this.LoginFormPage.ContentContainer = this.loginFormPageContainer;
            this.LoginFormPage.Name = "LoginFormPage";
            this.LoginFormPage.ShowCloseButton = DevExpress.Utils.DefaultBoolean.False;
            this.LoginFormPage.Text = "登录";
            // 
            // loginFormPageContainer
            // 
            this.loginFormPageContainer.Controls.Add(this.groupBox1);
            this.loginFormPageContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loginFormPageContainer.Location = new System.Drawing.Point(0, 70);
            this.loginFormPageContainer.Margin = new System.Windows.Forms.Padding(5);
            this.loginFormPageContainer.Name = "loginFormPageContainer";
            this.loginFormPageContainer.Size = new System.Drawing.Size(1356, 693);
            this.loginFormPageContainer.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.Cancel_Button);
            this.groupBox1.Controls.Add(this.Confirm_Button);
            this.groupBox1.Controls.Add(this.Password_Input);
            this.groupBox1.Controls.Add(this.User_List);
            this.groupBox1.Controls.Add(this.User_Password);
            this.groupBox1.Controls.Add(this.labelControl1);
            this.groupBox1.Controls.Add(this.User_Name);
            this.groupBox1.Location = new System.Drawing.Point(356, 142);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(645, 409);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cancel_Button.Appearance.Options.UseFont = true;
            this.Cancel_Button.Location = new System.Drawing.Point(397, 302);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(165, 56);
            this.Cancel_Button.TabIndex = 5;
            this.Cancel_Button.Text = "清  除";
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Confirm_Button
            // 
            this.Confirm_Button.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Confirm_Button.Appearance.Options.UseFont = true;
            this.Confirm_Button.Location = new System.Drawing.Point(86, 302);
            this.Confirm_Button.Name = "Confirm_Button";
            this.Confirm_Button.Size = new System.Drawing.Size(165, 56);
            this.Confirm_Button.TabIndex = 4;
            this.Confirm_Button.Text = "登  录";
            this.Confirm_Button.Click += new System.EventHandler(this.Confirm_Button_Click);
            // 
            // Password_Input
            // 
            this.Password_Input.Location = new System.Drawing.Point(309, 189);
            this.Password_Input.Name = "Password_Input";
            this.Password_Input.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password_Input.Properties.Appearance.Options.UseFont = true;
            this.Password_Input.Properties.PasswordChar = '*';
            this.Password_Input.Size = new System.Drawing.Size(221, 48);
            this.Password_Input.TabIndex = 3;
            this.Password_Input.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Password_Input_KeyDown);
            // 
            // User_List
            // 
            this.User_List.Location = new System.Drawing.Point(309, 71);
            this.User_List.Name = "User_List";
            this.User_List.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.User_List.Properties.Appearance.Options.UseFont = true;
            this.User_List.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.User_List.Properties.Items.AddRange(new object[] {
            "操作员",
            "管理员"});
            this.User_List.Size = new System.Drawing.Size(221, 42);
            this.User_List.TabIndex = 2;
            // 
            // User_Password
            // 
            this.User_Password.Appearance.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.User_Password.Appearance.Options.UseFont = true;
            this.User_Password.Location = new System.Drawing.Point(136, 189);
            this.User_Password.Name = "User_Password";
            this.User_Password.Size = new System.Drawing.Size(172, 48);
            this.User_Password.TabIndex = 1;
            this.User_Password.Text = "密    码：";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(136, 68);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(172, 48);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "用    户：";
            // 
            // User_Name
            // 
            this.User_Name.Appearance.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.User_Name.Appearance.Options.UseFont = true;
            this.User_Name.Location = new System.Drawing.Point(132, 71);
            this.User_Name.Name = "User_Name";
            this.User_Name.Size = new System.Drawing.Size(145, 48);
            this.User_Name.TabIndex = 0;
            this.User_Name.Text = "用    户 ";
            // 
            // workFormPage
            // 
            this.workFormPage.ContentContainer = this.mainFormPageContainer;
            this.workFormPage.Name = "workFormPage";
            this.workFormPage.ShowCloseButton = DevExpress.Utils.DefaultBoolean.False;
            this.workFormPage.Text = "主页";
            // 
            // mainFormPageContainer
            // 
            this.mainFormPageContainer.Controls.Add(this.numericUpDown1);
            this.mainFormPageContainer.Controls.Add(this.Debug_Info_Display);
            this.mainFormPageContainer.Controls.Add(this.groupBox27);
            this.mainFormPageContainer.Controls.Add(this.groupBox26);
            this.mainFormPageContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainFormPageContainer.Location = new System.Drawing.Point(0, 70);
            this.mainFormPageContainer.Name = "mainFormPageContainer";
            this.mainFormPageContainer.Size = new System.Drawing.Size(1356, 693);
            this.mainFormPageContainer.TabIndex = 4;
            // 
            // Debug_Info_Display
            // 
            this.Debug_Info_Display.BackColor = System.Drawing.SystemColors.Menu;
            this.Debug_Info_Display.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Debug_Info_Display.Dock = System.Windows.Forms.DockStyle.Right;
            this.Debug_Info_Display.Location = new System.Drawing.Point(640, 0);
            this.Debug_Info_Display.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Debug_Info_Display.Name = "Debug_Info_Display";
            this.Debug_Info_Display.Size = new System.Drawing.Size(716, 693);
            this.Debug_Info_Display.TabIndex = 161;
            this.Debug_Info_Display.Text = "";
            // 
            // groupBox27
            // 
            this.groupBox27.Controls.Add(this.GoPoint);
            this.groupBox27.Controls.Add(this.Cam_Work_Stop);
            this.groupBox27.Controls.Add(this.Cam_Work_Start);
            this.groupBox27.Controls.Add(this.GetFileName);
            this.groupBox27.Controls.Add(this.EstablishCoordinate);
            this.groupBox27.Controls.Add(this.AxisHome);
            this.groupBox27.Location = new System.Drawing.Point(382, 52);
            this.groupBox27.Name = "groupBox27";
            this.groupBox27.Size = new System.Drawing.Size(210, 464);
            this.groupBox27.TabIndex = 160;
            this.groupBox27.TabStop = false;
            this.groupBox27.Text = "加工操作";
            // 
            // GoPoint
            // 
            this.GoPoint.Location = new System.Drawing.Point(26, 256);
            this.GoPoint.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GoPoint.Name = "GoPoint";
            this.GoPoint.Size = new System.Drawing.Size(154, 50);
            this.GoPoint.TabIndex = 156;
            this.GoPoint.Text = "定位坐标点";
            this.GoPoint.UseVisualStyleBackColor = true;
            this.GoPoint.Click += new System.EventHandler(this.GoPoint_Click);
            // 
            // Cam_Work_Stop
            // 
            this.Cam_Work_Stop.Location = new System.Drawing.Point(26, 398);
            this.Cam_Work_Stop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Cam_Work_Stop.Name = "Cam_Work_Stop";
            this.Cam_Work_Stop.Size = new System.Drawing.Size(154, 50);
            this.Cam_Work_Stop.TabIndex = 147;
            this.Cam_Work_Stop.Text = "加工终止";
            this.Cam_Work_Stop.UseVisualStyleBackColor = true;
            this.Cam_Work_Stop.Click += new System.EventHandler(this.Cam_Work_Stop_Click);
            // 
            // Cam_Work_Start
            // 
            this.Cam_Work_Start.Location = new System.Drawing.Point(26, 327);
            this.Cam_Work_Start.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Cam_Work_Start.Name = "Cam_Work_Start";
            this.Cam_Work_Start.Size = new System.Drawing.Size(154, 50);
            this.Cam_Work_Start.TabIndex = 146;
            this.Cam_Work_Start.Text = "加工启动";
            this.Cam_Work_Start.UseVisualStyleBackColor = true;
            this.Cam_Work_Start.Click += new System.EventHandler(this.Cam_Work_Start_Click);
            // 
            // GetFileName
            // 
            this.GetFileName.Location = new System.Drawing.Point(26, 43);
            this.GetFileName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GetFileName.Name = "GetFileName";
            this.GetFileName.Size = new System.Drawing.Size(154, 50);
            this.GetFileName.TabIndex = 38;
            this.GetFileName.Text = "加载Dxf文件";
            this.GetFileName.UseVisualStyleBackColor = true;
            this.GetFileName.Click += new System.EventHandler(this.GetFileName_Click);
            // 
            // EstablishCoordinate
            // 
            this.EstablishCoordinate.Location = new System.Drawing.Point(26, 185);
            this.EstablishCoordinate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EstablishCoordinate.Name = "EstablishCoordinate";
            this.EstablishCoordinate.Size = new System.Drawing.Size(154, 50);
            this.EstablishCoordinate.TabIndex = 37;
            this.EstablishCoordinate.Text = "建立直角坐标系";
            this.EstablishCoordinate.UseVisualStyleBackColor = true;
            this.EstablishCoordinate.Click += new System.EventHandler(this.EstablishCoordinate_Click);
            // 
            // AxisHome
            // 
            this.AxisHome.Location = new System.Drawing.Point(26, 114);
            this.AxisHome.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AxisHome.Name = "AxisHome";
            this.AxisHome.Size = new System.Drawing.Size(154, 50);
            this.AxisHome.TabIndex = 36;
            this.AxisHome.Text = "两轴回零";
            this.AxisHome.UseVisualStyleBackColor = true;
            this.AxisHome.Click += new System.EventHandler(this.AxisHome_Click);
            // 
            // groupBox26
            // 
            this.groupBox26.Controls.Add(this.label88);
            this.groupBox26.Controls.Add(this.Start_Pos_Sel);
            this.groupBox26.Controls.Add(this.label86);
            this.groupBox26.Controls.Add(this.BackY);
            this.groupBox26.Controls.Add(this.label87);
            this.groupBox26.Controls.Add(this.BackX);
            this.groupBox26.Controls.Add(this.label84);
            this.groupBox26.Controls.Add(this.Back_Pos_Select);
            this.groupBox26.Controls.Add(this.label85);
            this.groupBox26.Controls.Add(this.Work_Type_Select_List);
            this.groupBox26.Location = new System.Drawing.Point(25, 52);
            this.groupBox26.Name = "groupBox26";
            this.groupBox26.Size = new System.Drawing.Size(334, 373);
            this.groupBox26.TabIndex = 159;
            this.groupBox26.TabStop = false;
            this.groupBox26.Text = "加工参数";
            // 
            // label88
            // 
            this.label88.AutoSize = true;
            this.label88.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label88.Location = new System.Drawing.Point(102, 114);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(129, 20);
            this.label88.TabIndex = 158;
            this.label88.Text = "起始位置选择";
            // 
            // Start_Pos_Sel
            // 
            this.Start_Pos_Sel.FormattingEnabled = true;
            this.Start_Pos_Sel.Items.AddRange(new object[] {
            "原点起始",
            "Mark矫正",
            "Mark重矫正"});
            this.Start_Pos_Sel.Location = new System.Drawing.Point(34, 142);
            this.Start_Pos_Sel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Start_Pos_Sel.Name = "Start_Pos_Sel";
            this.Start_Pos_Sel.Size = new System.Drawing.Size(264, 30);
            this.Start_Pos_Sel.TabIndex = 157;
            this.Start_Pos_Sel.SelectedIndexChanged += new System.EventHandler(this.Start_Pos_Sel_SelectedIndexChanged);
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.Location = new System.Drawing.Point(202, 40);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(93, 22);
            this.label86.TabIndex = 155;
            this.label86.Text = "Y坐标/mm";
            // 
            // BackY
            // 
            this.BackY.Location = new System.Drawing.Point(198, 68);
            this.BackY.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BackY.Name = "BackY";
            this.BackY.Size = new System.Drawing.Size(100, 29);
            this.BackY.TabIndex = 154;
            this.BackY.TextChanged += new System.EventHandler(this.BackY_TextChanged);
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.Location = new System.Drawing.Point(38, 39);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(93, 22);
            this.label87.TabIndex = 153;
            this.label87.Text = "X坐标/mm";
            // 
            // BackX
            // 
            this.BackX.Location = new System.Drawing.Point(34, 68);
            this.BackX.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BackX.Name = "BackX";
            this.BackX.Size = new System.Drawing.Size(100, 29);
            this.BackX.TabIndex = 152;
            this.BackX.TextChanged += new System.EventHandler(this.BackX_TextChanged);
            // 
            // label84
            // 
            this.label84.AutoSize = true;
            this.label84.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label84.Location = new System.Drawing.Point(102, 199);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(129, 20);
            this.label84.TabIndex = 151;
            this.label84.Text = "回退位置选择";
            // 
            // Back_Pos_Select
            // 
            this.Back_Pos_Select.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Back_Pos_Select.FormattingEnabled = true;
            this.Back_Pos_Select.Items.AddRange(new object[] {
            "加工结束点",
            "坐标系原点",
            "上下料位置"});
            this.Back_Pos_Select.Location = new System.Drawing.Point(34, 228);
            this.Back_Pos_Select.Name = "Back_Pos_Select";
            this.Back_Pos_Select.Size = new System.Drawing.Size(264, 28);
            this.Back_Pos_Select.TabIndex = 150;
            this.Back_Pos_Select.SelectedIndexChanged += new System.EventHandler(this.Back_Pos_Select_SelectedIndexChanged);
            // 
            // label85
            // 
            this.label85.AutoSize = true;
            this.label85.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label85.Location = new System.Drawing.Point(102, 284);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(129, 20);
            this.label85.TabIndex = 149;
            this.label85.Text = "加工方式选择";
            // 
            // Work_Type_Select_List
            // 
            this.Work_Type_Select_List.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Work_Type_Select_List.FormattingEnabled = true;
            this.Work_Type_Select_List.Items.AddRange(new object[] {
            "振镜空白和平台未补偿",
            "振镜空白和平台已补偿",
            "振镜仿射和平台未补偿",
            "振镜仿射和平台已补偿",
            "振镜旋转和平台已补偿",
            "振镜矩阵和平台已补偿",
            "振镜桶形畸变图形加工",
            "振镜桶形畸变数据采集",
            "振镜仿射矩阵图形加工",
            "振镜仿射矩阵数据采集",
            "Mark坐标定位矫正",
            "Mark坐标定位重矫正",
            "相机坐标系标定(打标)",
            "相机坐标系标定(标定板)",
            "矫正振镜坐标系偏转角",
            "振镜与ORG距离校准",
            "坐标系原点坐标校准",
            "计算标定板旋转参数",
            "标定板原始校准数据",
            "标定板二次校准验证"});
            this.Work_Type_Select_List.Location = new System.Drawing.Point(34, 312);
            this.Work_Type_Select_List.Name = "Work_Type_Select_List";
            this.Work_Type_Select_List.Size = new System.Drawing.Size(264, 28);
            this.Work_Type_Select_List.TabIndex = 148;
            this.Work_Type_Select_List.SelectedIndexChanged += new System.EventHandler(this.Work_Type_Select_List_SelectedIndexChanged);
            // 
            // manualFormPage
            // 
            this.manualFormPage.ContentContainer = this.manualFormPageContainer;
            this.manualFormPage.Name = "manualFormPage";
            this.manualFormPage.ShowCloseButton = DevExpress.Utils.DefaultBoolean.False;
            this.manualFormPage.Text = "手动";
            // 
            // manualFormPageContainer
            // 
            this.manualFormPageContainer.Controls.Add(this.manualTabPane);
            this.manualFormPageContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.manualFormPageContainer.Location = new System.Drawing.Point(0, 70);
            this.manualFormPageContainer.Name = "manualFormPageContainer";
            this.manualFormPageContainer.Size = new System.Drawing.Size(1356, 693);
            this.manualFormPageContainer.TabIndex = 7;
            // 
            // manualTabPane
            // 
            this.manualTabPane.AllowCollapse = DevExpress.Utils.DefaultBoolean.Default;
            this.manualTabPane.Controls.Add(this.gtsManual);
            this.manualTabPane.Controls.Add(this.rtcManual);
            this.manualTabPane.Controls.Add(this.IOOperate);
            this.manualTabPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.manualTabPane.Location = new System.Drawing.Point(0, 0);
            this.manualTabPane.Name = "manualTabPane";
            this.manualTabPane.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.gtsManual,
            this.rtcManual,
            this.IOOperate});
            this.manualTabPane.RegularSize = new System.Drawing.Size(1356, 693);
            this.manualTabPane.SelectedPage = this.gtsManual;
            this.manualTabPane.Size = new System.Drawing.Size(1356, 693);
            this.manualTabPane.TabIndex = 0;
            this.manualTabPane.Text = "mannualTabPane";
            // 
            // gtsManual
            // 
            this.gtsManual.Caption = "平台手动操作";
            this.gtsManual.Controls.Add(this.groupBox14);
            this.gtsManual.Controls.Add(this.groupBox12);
            this.gtsManual.Controls.Add(this.groupBox13);
            this.gtsManual.Controls.Add(this.GtsReset);
            this.gtsManual.Controls.Add(this.groupBox11);
            this.gtsManual.Controls.Add(this.label31);
            this.gtsManual.Controls.Add(this.AxisSelect);
            this.gtsManual.Name = "gtsManual";
            this.gtsManual.Size = new System.Drawing.Size(1356, 651);
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.HomeSmoothTime);
            this.groupBox14.Controls.Add(this.label49);
            this.groupBox14.Controls.Add(this.HomeDCC);
            this.groupBox14.Controls.Add(this.label50);
            this.groupBox14.Controls.Add(this.HomeACC);
            this.groupBox14.Controls.Add(this.label51);
            this.groupBox14.Controls.Add(this.HomeSpeed);
            this.groupBox14.Controls.Add(this.HomeDeviation);
            this.groupBox14.Controls.Add(this.label52);
            this.groupBox14.Controls.Add(this.label53);
            this.groupBox14.Location = new System.Drawing.Point(919, 218);
            this.groupBox14.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox14.Size = new System.Drawing.Size(230, 415);
            this.groupBox14.TabIndex = 35;
            this.groupBox14.TabStop = false;
            this.groupBox14.Visible = false;
            // 
            // HomeSmoothTime
            // 
            this.HomeSmoothTime.Location = new System.Drawing.Point(48, 290);
            this.HomeSmoothTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HomeSmoothTime.Name = "HomeSmoothTime";
            this.HomeSmoothTime.Size = new System.Drawing.Size(134, 28);
            this.HomeSmoothTime.TabIndex = 31;
            this.HomeSmoothTime.TextChanged += new System.EventHandler(this.HomeSmoothTime_TextChanged);
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(38, 265);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(152, 18);
            this.label49.TabIndex = 30;
            this.label49.Text = "回零平滑时间(ms)";
            // 
            // HomeDCC
            // 
            this.HomeDCC.Location = new System.Drawing.Point(48, 211);
            this.HomeDCC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HomeDCC.Name = "HomeDCC";
            this.HomeDCC.Size = new System.Drawing.Size(134, 28);
            this.HomeDCC.TabIndex = 29;
            this.HomeDCC.TextChanged += new System.EventHandler(this.HomeDCC_TextChanged);
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(28, 186);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(170, 18);
            this.label50.TabIndex = 28;
            this.label50.Text = "回零减速度 (mm/s²)";
            // 
            // HomeACC
            // 
            this.HomeACC.Location = new System.Drawing.Point(48, 132);
            this.HomeACC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HomeACC.Name = "HomeACC";
            this.HomeACC.Size = new System.Drawing.Size(134, 28);
            this.HomeACC.TabIndex = 27;
            this.HomeACC.TextChanged += new System.EventHandler(this.HomeACC_TextChanged);
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(28, 107);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(170, 18);
            this.label51.TabIndex = 26;
            this.label51.Text = "回零加速度 (mm/s²)";
            // 
            // HomeSpeed
            // 
            this.HomeSpeed.Location = new System.Drawing.Point(48, 53);
            this.HomeSpeed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HomeSpeed.Name = "HomeSpeed";
            this.HomeSpeed.Size = new System.Drawing.Size(134, 28);
            this.HomeSpeed.TabIndex = 24;
            this.HomeSpeed.TextChanged += new System.EventHandler(this.HomeSpeed_TextChanged);
            // 
            // HomeDeviation
            // 
            this.HomeDeviation.Location = new System.Drawing.Point(48, 369);
            this.HomeDeviation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HomeDeviation.Name = "HomeDeviation";
            this.HomeDeviation.Size = new System.Drawing.Size(134, 28);
            this.HomeDeviation.TabIndex = 24;
            this.HomeDeviation.TextChanged += new System.EventHandler(this.HomeDeviation_TextChanged);
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(42, 28);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(143, 18);
            this.label52.TabIndex = 23;
            this.label52.Text = "回零速度 (mm/s)";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(52, 344);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(116, 18);
            this.label53.TabIndex = 23;
            this.label53.Text = "原点偏移(mm)";
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.Upper_Posed);
            this.groupBox12.Controls.Add(this.Motor_Posed);
            this.groupBox12.Controls.Add(this.MechanicHome);
            this.groupBox12.Controls.Add(this.BoardAlarm);
            this.groupBox12.Controls.Add(this.DriveBusy);
            this.groupBox12.Controls.Add(this.ActualMode);
            this.groupBox12.Controls.Add(this.EmgStop);
            this.groupBox12.Controls.Add(this.ActualSpeed);
            this.groupBox12.Controls.Add(this.ActualDCC);
            this.groupBox12.Controls.Add(this.SmoothStop);
            this.groupBox12.Controls.Add(this.ActualACC);
            this.groupBox12.Controls.Add(this.label40);
            this.groupBox12.Controls.Add(this.label41);
            this.groupBox12.Controls.Add(this.label42);
            this.groupBox12.Controls.Add(this.label43);
            this.groupBox12.Location = new System.Drawing.Point(402, 213);
            this.groupBox12.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox12.Size = new System.Drawing.Size(452, 415);
            this.groupBox12.TabIndex = 30;
            this.groupBox12.TabStop = false;
            // 
            // Upper_Posed
            // 
            this.Upper_Posed.Location = new System.Drawing.Point(264, 357);
            this.Upper_Posed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Upper_Posed.Name = "Upper_Posed";
            this.Upper_Posed.Size = new System.Drawing.Size(130, 38);
            this.Upper_Posed.TabIndex = 36;
            this.Upper_Posed.Text = "Upper 到位";
            this.Upper_Posed.UseVisualStyleBackColor = true;
            // 
            // Motor_Posed
            // 
            this.Motor_Posed.Location = new System.Drawing.Point(264, 302);
            this.Motor_Posed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Motor_Posed.Name = "Motor_Posed";
            this.Motor_Posed.Size = new System.Drawing.Size(130, 38);
            this.Motor_Posed.TabIndex = 35;
            this.Motor_Posed.Text = "Motor 到位";
            this.Motor_Posed.UseVisualStyleBackColor = true;
            // 
            // MechanicHome
            // 
            this.MechanicHome.Location = new System.Drawing.Point(264, 137);
            this.MechanicHome.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MechanicHome.Name = "MechanicHome";
            this.MechanicHome.Size = new System.Drawing.Size(130, 38);
            this.MechanicHome.TabIndex = 33;
            this.MechanicHome.Text = "机械回零";
            this.MechanicHome.UseVisualStyleBackColor = true;
            this.MechanicHome.Click += new System.EventHandler(this.MechanicHome_Click);
            // 
            // BoardAlarm
            // 
            this.BoardAlarm.Location = new System.Drawing.Point(264, 82);
            this.BoardAlarm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BoardAlarm.Name = "BoardAlarm";
            this.BoardAlarm.Size = new System.Drawing.Size(130, 38);
            this.BoardAlarm.TabIndex = 32;
            this.BoardAlarm.Text = "板卡报警";
            this.BoardAlarm.UseVisualStyleBackColor = true;
            // 
            // DriveBusy
            // 
            this.DriveBusy.Location = new System.Drawing.Point(264, 27);
            this.DriveBusy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DriveBusy.Name = "DriveBusy";
            this.DriveBusy.Size = new System.Drawing.Size(130, 38);
            this.DriveBusy.TabIndex = 31;
            this.DriveBusy.Text = "脉冲输出中";
            this.DriveBusy.UseVisualStyleBackColor = true;
            // 
            // ActualMode
            // 
            this.ActualMode.AutoSize = true;
            this.ActualMode.Location = new System.Drawing.Point(52, 350);
            this.ActualMode.Name = "ActualMode";
            this.ActualMode.Size = new System.Drawing.Size(116, 18);
            this.ActualMode.TabIndex = 30;
            this.ActualMode.Text = "当前模式指示";
            this.ActualMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EmgStop
            // 
            this.EmgStop.Location = new System.Drawing.Point(264, 247);
            this.EmgStop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EmgStop.Name = "EmgStop";
            this.EmgStop.Size = new System.Drawing.Size(130, 38);
            this.EmgStop.TabIndex = 23;
            this.EmgStop.Text = "紧急停止";
            this.EmgStop.UseVisualStyleBackColor = true;
            this.EmgStop.Click += new System.EventHandler(this.EmgStop_Click);
            // 
            // ActualSpeed
            // 
            this.ActualSpeed.AutoSize = true;
            this.ActualSpeed.Location = new System.Drawing.Point(52, 262);
            this.ActualSpeed.Name = "ActualSpeed";
            this.ActualSpeed.Size = new System.Drawing.Size(116, 18);
            this.ActualSpeed.TabIndex = 29;
            this.ActualSpeed.Text = "当前速度指示";
            this.ActualSpeed.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ActualDCC
            // 
            this.ActualDCC.AutoSize = true;
            this.ActualDCC.Location = new System.Drawing.Point(44, 174);
            this.ActualDCC.Name = "ActualDCC";
            this.ActualDCC.Size = new System.Drawing.Size(134, 18);
            this.ActualDCC.TabIndex = 28;
            this.ActualDCC.Text = "当前减速度指示";
            this.ActualDCC.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // SmoothStop
            // 
            this.SmoothStop.Location = new System.Drawing.Point(264, 192);
            this.SmoothStop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SmoothStop.Name = "SmoothStop";
            this.SmoothStop.Size = new System.Drawing.Size(130, 38);
            this.SmoothStop.TabIndex = 22;
            this.SmoothStop.Text = "平滑停止";
            this.SmoothStop.UseVisualStyleBackColor = true;
            this.SmoothStop.Click += new System.EventHandler(this.SmoothStop_Click);
            // 
            // ActualACC
            // 
            this.ActualACC.AutoSize = true;
            this.ActualACC.Location = new System.Drawing.Point(44, 86);
            this.ActualACC.Name = "ActualACC";
            this.ActualACC.Size = new System.Drawing.Size(134, 18);
            this.ActualACC.TabIndex = 27;
            this.ActualACC.Text = "当前加速度指示";
            this.ActualACC.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(52, 324);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(116, 18);
            this.label40.TabIndex = 9;
            this.label40.Text = "当前运动模式";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(39, 236);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(143, 18);
            this.label41.TabIndex = 7;
            this.label41.Text = "当前速度 (mm/s)";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(26, 148);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(170, 18);
            this.label42.TabIndex = 5;
            this.label42.Text = "当前减速度 (mm/s²)";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(26, 60);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(170, 18);
            this.label43.TabIndex = 3;
            this.label43.Text = "当前加速度 (mm/s²)";
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.JogDot);
            this.groupBox13.Controls.Add(this.ManualSpeed);
            this.groupBox13.Controls.Add(this.label44);
            this.groupBox13.Controls.Add(this.ServoON);
            this.groupBox13.Controls.Add(this.PosClear);
            this.groupBox13.Controls.Add(this.StatusClear);
            this.groupBox13.Controls.Add(this.ManualStep);
            this.groupBox13.Controls.Add(this.AlarmClear);
            this.groupBox13.Controls.Add(this.label46);
            this.groupBox13.Controls.Add(this.DriverAlarm);
            this.groupBox13.Controls.Add(this.ManualDCC);
            this.groupBox13.Controls.Add(this.label47);
            this.groupBox13.Controls.Add(this.ManualACC);
            this.groupBox13.Controls.Add(this.label48);
            this.groupBox13.Location = new System.Drawing.Point(30, 209);
            this.groupBox13.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox13.Size = new System.Drawing.Size(336, 415);
            this.groupBox13.TabIndex = 29;
            this.groupBox13.TabStop = false;
            // 
            // JogDot
            // 
            this.JogDot.Location = new System.Drawing.Point(190, 358);
            this.JogDot.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.JogDot.Name = "JogDot";
            this.JogDot.Size = new System.Drawing.Size(130, 38);
            this.JogDot.TabIndex = 22;
            this.JogDot.Text = "点动/连动";
            this.JogDot.UseVisualStyleBackColor = true;
            this.JogDot.Click += new System.EventHandler(this.JogDot_Click);
            // 
            // ManualSpeed
            // 
            this.ManualSpeed.Location = new System.Drawing.Point(26, 358);
            this.ManualSpeed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ManualSpeed.Name = "ManualSpeed";
            this.ManualSpeed.Size = new System.Drawing.Size(134, 28);
            this.ManualSpeed.TabIndex = 12;
            this.ManualSpeed.TextChanged += new System.EventHandler(this.ManualSpeed_TextChanged);
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(21, 329);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(143, 18);
            this.label44.TabIndex = 11;
            this.label44.Text = "手动速度 (mm/s)";
            // 
            // ServoON
            // 
            this.ServoON.Location = new System.Drawing.Point(190, 160);
            this.ServoON.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ServoON.Name = "ServoON";
            this.ServoON.Size = new System.Drawing.Size(130, 38);
            this.ServoON.TabIndex = 21;
            this.ServoON.Text = "伺服使能";
            this.ServoON.UseVisualStyleBackColor = true;
            this.ServoON.Click += new System.EventHandler(this.ServoON_Click);
            // 
            // PosClear
            // 
            this.PosClear.Location = new System.Drawing.Point(190, 292);
            this.PosClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PosClear.Name = "PosClear";
            this.PosClear.Size = new System.Drawing.Size(130, 38);
            this.PosClear.TabIndex = 20;
            this.PosClear.Text = "位置清零";
            this.PosClear.UseVisualStyleBackColor = true;
            this.PosClear.Click += new System.EventHandler(this.PosClear_Click);
            // 
            // StatusClear
            // 
            this.StatusClear.Location = new System.Drawing.Point(190, 226);
            this.StatusClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StatusClear.Name = "StatusClear";
            this.StatusClear.Size = new System.Drawing.Size(130, 38);
            this.StatusClear.TabIndex = 19;
            this.StatusClear.Text = "状态清除";
            this.StatusClear.UseVisualStyleBackColor = true;
            this.StatusClear.Click += new System.EventHandler(this.StatusClear_Click);
            // 
            // ManualStep
            // 
            this.ManualStep.Location = new System.Drawing.Point(26, 256);
            this.ManualStep.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ManualStep.Name = "ManualStep";
            this.ManualStep.Size = new System.Drawing.Size(134, 28);
            this.ManualStep.TabIndex = 8;
            this.ManualStep.TextChanged += new System.EventHandler(this.ManualStep_TextChanged);
            // 
            // AlarmClear
            // 
            this.AlarmClear.Location = new System.Drawing.Point(190, 94);
            this.AlarmClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AlarmClear.Name = "AlarmClear";
            this.AlarmClear.Size = new System.Drawing.Size(130, 38);
            this.AlarmClear.TabIndex = 18;
            this.AlarmClear.Text = "报警清除";
            this.AlarmClear.UseVisualStyleBackColor = true;
            this.AlarmClear.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AlarmClear_MouseDown);
            this.AlarmClear.MouseUp += new System.Windows.Forms.MouseEventHandler(this.AlarmClear_MouseUp);
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(48, 228);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(89, 18);
            this.label46.TabIndex = 7;
            this.label46.Text = "步长 (mm)";
            // 
            // DriverAlarm
            // 
            this.DriverAlarm.Location = new System.Drawing.Point(190, 28);
            this.DriverAlarm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DriverAlarm.Name = "DriverAlarm";
            this.DriverAlarm.Size = new System.Drawing.Size(130, 38);
            this.DriverAlarm.TabIndex = 17;
            this.DriverAlarm.Text = "驱动报警";
            this.DriverAlarm.UseVisualStyleBackColor = true;
            // 
            // ManualDCC
            // 
            this.ManualDCC.Location = new System.Drawing.Point(26, 154);
            this.ManualDCC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ManualDCC.Name = "ManualDCC";
            this.ManualDCC.Size = new System.Drawing.Size(134, 28);
            this.ManualDCC.TabIndex = 6;
            this.ManualDCC.TextChanged += new System.EventHandler(this.ManualDCC_TextChanged);
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(26, 127);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(134, 18);
            this.label47.TabIndex = 5;
            this.label47.Text = "减速度 (mm/s²)";
            // 
            // ManualACC
            // 
            this.ManualACC.Location = new System.Drawing.Point(26, 52);
            this.ManualACC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ManualACC.Name = "ManualACC";
            this.ManualACC.Size = new System.Drawing.Size(134, 28);
            this.ManualACC.TabIndex = 4;
            this.ManualACC.TextChanged += new System.EventHandler(this.ManualACC_TextChanged);
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(26, 26);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(134, 18);
            this.label48.TabIndex = 3;
            this.label48.Text = "加速度 (mm/s²)";
            // 
            // GtsReset
            // 
            this.GtsReset.Location = new System.Drawing.Point(631, 19);
            this.GtsReset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GtsReset.Name = "GtsReset";
            this.GtsReset.Size = new System.Drawing.Size(130, 38);
            this.GtsReset.TabIndex = 34;
            this.GtsReset.Text = "复位";
            this.GtsReset.UseVisualStyleBackColor = true;
            this.GtsReset.Click += new System.EventHandler(this.GtsReset_Click);
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.ActualPos);
            this.groupBox11.Controls.Add(this.label33);
            this.groupBox11.Controls.Add(this.CurrentPos);
            this.groupBox11.Controls.Add(this.JogNegative);
            this.groupBox11.Controls.Add(this.JogPositive);
            this.groupBox11.Controls.Add(this.label35);
            this.groupBox11.Controls.Add(this.NegativeLimit);
            this.groupBox11.Controls.Add(this.HomeSensor);
            this.groupBox11.Controls.Add(this.PositveLimit);
            this.groupBox11.Location = new System.Drawing.Point(30, 59);
            this.groupBox11.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox11.Size = new System.Drawing.Size(824, 144);
            this.groupBox11.TabIndex = 28;
            this.groupBox11.TabStop = false;
            // 
            // ActualPos
            // 
            this.ActualPos.AutoSize = true;
            this.ActualPos.Location = new System.Drawing.Point(332, 105);
            this.ActualPos.Name = "ActualPos";
            this.ActualPos.Size = new System.Drawing.Size(116, 18);
            this.ActualPos.TabIndex = 28;
            this.ActualPos.Text = "当前位置指示";
            this.ActualPos.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(328, 79);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(125, 18);
            this.label33.TabIndex = 27;
            this.label33.Text = "实际位置 (mm)";
            // 
            // CurrentPos
            // 
            this.CurrentPos.AutoSize = true;
            this.CurrentPos.Location = new System.Drawing.Point(332, 42);
            this.CurrentPos.Name = "CurrentPos";
            this.CurrentPos.Size = new System.Drawing.Size(116, 18);
            this.CurrentPos.TabIndex = 26;
            this.CurrentPos.Text = "当前位置指示";
            this.CurrentPos.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // JogNegative
            // 
            this.JogNegative.Location = new System.Drawing.Point(526, 79);
            this.JogNegative.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.JogNegative.Name = "JogNegative";
            this.JogNegative.Size = new System.Drawing.Size(130, 38);
            this.JogNegative.TabIndex = 25;
            this.JogNegative.Text = "Jog-";
            this.JogNegative.UseVisualStyleBackColor = true;
            this.JogNegative.MouseDown += new System.Windows.Forms.MouseEventHandler(this.JogNegative_MouseDown);
            this.JogNegative.MouseUp += new System.Windows.Forms.MouseEventHandler(this.JogNegative_MouseUp);
            // 
            // JogPositive
            // 
            this.JogPositive.Location = new System.Drawing.Point(104, 79);
            this.JogPositive.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.JogPositive.Name = "JogPositive";
            this.JogPositive.Size = new System.Drawing.Size(130, 38);
            this.JogPositive.TabIndex = 24;
            this.JogPositive.Text = "Jog+";
            this.JogPositive.UseVisualStyleBackColor = true;
            this.JogPositive.MouseDown += new System.Windows.Forms.MouseEventHandler(this.JogPositive_MouseDown);
            this.JogPositive.MouseUp += new System.Windows.Forms.MouseEventHandler(this.JogPositive_MouseUp);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(328, 16);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(125, 18);
            this.label35.TabIndex = 13;
            this.label35.Text = "规划位置 (mm)";
            // 
            // NegativeLimit
            // 
            this.NegativeLimit.Location = new System.Drawing.Point(712, 29);
            this.NegativeLimit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NegativeLimit.Name = "NegativeLimit";
            this.NegativeLimit.Size = new System.Drawing.Size(80, 35);
            this.NegativeLimit.TabIndex = 2;
            this.NegativeLimit.Text = "负限位";
            this.NegativeLimit.UseVisualStyleBackColor = true;
            // 
            // HomeSensor
            // 
            this.HomeSensor.Location = new System.Drawing.Point(578, 29);
            this.HomeSensor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HomeSensor.Name = "HomeSensor";
            this.HomeSensor.Size = new System.Drawing.Size(80, 35);
            this.HomeSensor.TabIndex = 1;
            this.HomeSensor.Text = "原点";
            this.HomeSensor.UseVisualStyleBackColor = true;
            // 
            // PositveLimit
            // 
            this.PositveLimit.Location = new System.Drawing.Point(34, 29);
            this.PositveLimit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PositveLimit.Name = "PositveLimit";
            this.PositveLimit.Size = new System.Drawing.Size(80, 35);
            this.PositveLimit.TabIndex = 0;
            this.PositveLimit.Text = "正限位";
            this.PositveLimit.UseVisualStyleBackColor = true;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(268, 27);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(62, 18);
            this.label31.TabIndex = 27;
            this.label31.Text = "轴编号";
            // 
            // AxisSelect
            // 
            this.AxisSelect.InterceptArrowKeys = false;
            this.AxisSelect.Location = new System.Drawing.Point(357, 24);
            this.AxisSelect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AxisSelect.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.AxisSelect.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AxisSelect.Name = "AxisSelect";
            this.AxisSelect.Size = new System.Drawing.Size(120, 28);
            this.AxisSelect.TabIndex = 26;
            this.AxisSelect.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AxisSelect.ValueChanged += new System.EventHandler(this.AxisSelect_ValueChanged);
            // 
            // rtcManual
            // 
            this.rtcManual.Caption = "振镜手动操作";
            this.rtcManual.Controls.Add(this.groupBox15);
            this.rtcManual.Controls.Add(this.groupBox16);
            this.rtcManual.Controls.Add(this.groupBox17);
            this.rtcManual.Controls.Add(this.groupBox18);
            this.rtcManual.Controls.Add(this.groupBox19);
            this.rtcManual.Controls.Add(this.groupBox20);
            this.rtcManual.Name = "rtcManual";
            this.rtcManual.Size = new System.Drawing.Size(1356, 651);
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.AutoDelaySwitch);
            this.groupBox15.Controls.Add(this.Reset_Rtc);
            this.groupBox15.Controls.Add(this.label32);
            this.groupBox15.Controls.Add(this.RtcPosReference);
            this.groupBox15.Location = new System.Drawing.Point(546, 424);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(469, 113);
            this.groupBox15.TabIndex = 52;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "打标参数 mm/bit";
            // 
            // AutoDelaySwitch
            // 
            this.AutoDelaySwitch.Location = new System.Drawing.Point(267, 21);
            this.AutoDelaySwitch.Name = "AutoDelaySwitch";
            this.AutoDelaySwitch.Size = new System.Drawing.Size(158, 37);
            this.AutoDelaySwitch.TabIndex = 44;
            this.AutoDelaySwitch.Text = "延时校正";
            this.AutoDelaySwitch.UseVisualStyleBackColor = true;
            this.AutoDelaySwitch.Click += new System.EventHandler(this.AutoDelaySwitch_Click);
            // 
            // Reset_Rtc
            // 
            this.Reset_Rtc.Location = new System.Drawing.Point(267, 64);
            this.Reset_Rtc.Name = "Reset_Rtc";
            this.Reset_Rtc.Size = new System.Drawing.Size(158, 37);
            this.Reset_Rtc.TabIndex = 43;
            this.Reset_Rtc.Text = "复位Rtc控制卡";
            this.Reset_Rtc.UseVisualStyleBackColor = true;
            this.Reset_Rtc.Click += new System.EventHandler(this.Reset_Rtc_Click);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(17, 44);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(161, 18);
            this.label32.TabIndex = 16;
            this.label32.Text = "Rtc_Pos_Reference";
            // 
            // RtcPosReference
            // 
            this.RtcPosReference.Location = new System.Drawing.Point(35, 72);
            this.RtcPosReference.Name = "RtcPosReference";
            this.RtcPosReference.Size = new System.Drawing.Size(125, 28);
            this.RtcPosReference.TabIndex = 15;
            this.RtcPosReference.TextChanged += new System.EventHandler(this.RtcPosReference_TextChanged);
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.LaserOFF);
            this.groupBox16.Controls.Add(this.LaserON);
            this.groupBox16.Location = new System.Drawing.Point(546, 313);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(470, 98);
            this.groupBox16.TabIndex = 51;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "激光操作";
            // 
            // LaserOFF
            // 
            this.LaserOFF.Location = new System.Drawing.Point(326, 37);
            this.LaserOFF.Name = "LaserOFF";
            this.LaserOFF.Size = new System.Drawing.Size(115, 37);
            this.LaserOFF.TabIndex = 20;
            this.LaserOFF.Text = "激光关";
            this.LaserOFF.UseVisualStyleBackColor = true;
            this.LaserOFF.Click += new System.EventHandler(this.LaserOFF_Click);
            // 
            // LaserON
            // 
            this.LaserON.Location = new System.Drawing.Point(40, 37);
            this.LaserON.Name = "LaserON";
            this.LaserON.Size = new System.Drawing.Size(115, 37);
            this.LaserON.TabIndex = 19;
            this.LaserON.Text = "激光开";
            this.LaserON.UseVisualStyleBackColor = true;
            this.LaserON.Click += new System.EventHandler(this.LaserON_Click);
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.MoveMode);
            this.groupBox17.Controls.Add(this.label34);
            this.groupBox17.Controls.Add(this.label36);
            this.groupBox17.Controls.Add(this.MoveY);
            this.groupBox17.Controls.Add(this.MoveX);
            this.groupBox17.Controls.Add(this.RtcYJogNegative);
            this.groupBox17.Controls.Add(this.RtcYJogPositive);
            this.groupBox17.Controls.Add(this.RtcXJogNegative);
            this.groupBox17.Controls.Add(this.RtcXJogPositive);
            this.groupBox17.Location = new System.Drawing.Point(55, 299);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(463, 239);
            this.groupBox17.TabIndex = 50;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "光斑移动";
            // 
            // MoveMode
            // 
            this.MoveMode.Location = new System.Drawing.Point(174, 27);
            this.MoveMode.Name = "MoveMode";
            this.MoveMode.Size = new System.Drawing.Size(115, 37);
            this.MoveMode.TabIndex = 15;
            this.MoveMode.Text = "移动方式";
            this.MoveMode.UseVisualStyleBackColor = true;
            this.MoveMode.Click += new System.EventHandler(this.MoveMode_Click);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(326, 60);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(80, 18);
            this.label34.TabIndex = 8;
            this.label34.Text = "Y步距/mm";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(46, 60);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(80, 18);
            this.label36.TabIndex = 7;
            this.label36.Text = "X步距/mm";
            // 
            // MoveY
            // 
            this.MoveY.Location = new System.Drawing.Point(315, 84);
            this.MoveY.Name = "MoveY";
            this.MoveY.Size = new System.Drawing.Size(115, 28);
            this.MoveY.TabIndex = 6;
            this.MoveY.TextChanged += new System.EventHandler(this.MoveY_TextChanged);
            // 
            // MoveX
            // 
            this.MoveX.Location = new System.Drawing.Point(35, 84);
            this.MoveX.Name = "MoveX";
            this.MoveX.Size = new System.Drawing.Size(115, 28);
            this.MoveX.TabIndex = 5;
            this.MoveX.TextChanged += new System.EventHandler(this.MoveX_TextChanged);
            // 
            // RtcYJogNegative
            // 
            this.RtcYJogNegative.Location = new System.Drawing.Point(315, 187);
            this.RtcYJogNegative.Name = "RtcYJogNegative";
            this.RtcYJogNegative.Size = new System.Drawing.Size(115, 37);
            this.RtcYJogNegative.TabIndex = 4;
            this.RtcYJogNegative.Text = "Y-";
            this.RtcYJogNegative.UseVisualStyleBackColor = true;
            this.RtcYJogNegative.Click += new System.EventHandler(this.RtcYJogNegative_Click);
            // 
            // RtcYJogPositive
            // 
            this.RtcYJogPositive.Location = new System.Drawing.Point(315, 125);
            this.RtcYJogPositive.Name = "RtcYJogPositive";
            this.RtcYJogPositive.Size = new System.Drawing.Size(115, 37);
            this.RtcYJogPositive.TabIndex = 3;
            this.RtcYJogPositive.Text = "Y+";
            this.RtcYJogPositive.UseVisualStyleBackColor = true;
            this.RtcYJogPositive.Click += new System.EventHandler(this.RtcYJogPositive_Click);
            // 
            // RtcXJogNegative
            // 
            this.RtcXJogNegative.Location = new System.Drawing.Point(35, 187);
            this.RtcXJogNegative.Name = "RtcXJogNegative";
            this.RtcXJogNegative.Size = new System.Drawing.Size(115, 37);
            this.RtcXJogNegative.TabIndex = 2;
            this.RtcXJogNegative.Text = "X-";
            this.RtcXJogNegative.UseVisualStyleBackColor = true;
            this.RtcXJogNegative.Click += new System.EventHandler(this.RtcXJogNegative_Click);
            // 
            // RtcXJogPositive
            // 
            this.RtcXJogPositive.Location = new System.Drawing.Point(35, 125);
            this.RtcXJogPositive.Name = "RtcXJogPositive";
            this.RtcXJogPositive.Size = new System.Drawing.Size(115, 37);
            this.RtcXJogPositive.TabIndex = 1;
            this.RtcXJogPositive.Text = "X+";
            this.RtcXJogPositive.UseVisualStyleBackColor = true;
            this.RtcXJogPositive.Click += new System.EventHandler(this.RtcXJogPositive_Click);
            // 
            // groupBox18
            // 
            this.groupBox18.Controls.Add(this.label37);
            this.groupBox18.Controls.Add(this.Polygon_Delay);
            this.groupBox18.Controls.Add(this.label38);
            this.groupBox18.Controls.Add(this.Jump_Delay);
            this.groupBox18.Controls.Add(this.label39);
            this.groupBox18.Controls.Add(this.Mark_Delay);
            this.groupBox18.Controls.Add(this.label45);
            this.groupBox18.Controls.Add(this.Laser_Off_Delay);
            this.groupBox18.Controls.Add(this.label54);
            this.groupBox18.Controls.Add(this.Jump_Speed);
            this.groupBox18.Controls.Add(this.label55);
            this.groupBox18.Controls.Add(this.Laser_ON_Delay);
            this.groupBox18.Controls.Add(this.Change_Para_List);
            this.groupBox18.Controls.Add(this.label56);
            this.groupBox18.Controls.Add(this.Mark_Speed);
            this.groupBox18.Location = new System.Drawing.Point(546, 47);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(470, 230);
            this.groupBox18.TabIndex = 49;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "激光参数";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(321, 30);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(134, 18);
            this.label37.TabIndex = 42;
            this.label37.Text = "Polygon延时 ms";
            // 
            // Polygon_Delay
            // 
            this.Polygon_Delay.Location = new System.Drawing.Point(331, 54);
            this.Polygon_Delay.Name = "Polygon_Delay";
            this.Polygon_Delay.Size = new System.Drawing.Size(115, 28);
            this.Polygon_Delay.TabIndex = 41;
            this.Polygon_Delay.TextChanged += new System.EventHandler(this.Polygon_Delay_TextChanged);
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(179, 98);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(107, 18);
            this.label38.TabIndex = 40;
            this.label38.Text = "Jump延时 ms";
            // 
            // Jump_Delay
            // 
            this.Jump_Delay.Location = new System.Drawing.Point(175, 121);
            this.Jump_Delay.Name = "Jump_Delay";
            this.Jump_Delay.Size = new System.Drawing.Size(115, 28);
            this.Jump_Delay.TabIndex = 39;
            this.Jump_Delay.TextChanged += new System.EventHandler(this.Jump_Delay_TextChanged);
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(179, 161);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(107, 18);
            this.label39.TabIndex = 38;
            this.label39.Text = "Mark延时 ms";
            // 
            // Mark_Delay
            // 
            this.Mark_Delay.Location = new System.Drawing.Point(175, 188);
            this.Mark_Delay.Name = "Mark_Delay";
            this.Mark_Delay.Size = new System.Drawing.Size(115, 28);
            this.Mark_Delay.TabIndex = 37;
            this.Mark_Delay.TextChanged += new System.EventHandler(this.Mark_Delay_TextChanged);
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(179, 32);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(107, 18);
            this.label45.TabIndex = 36;
            this.label45.Text = "关光延时 ms";
            // 
            // Laser_Off_Delay
            // 
            this.Laser_Off_Delay.Location = new System.Drawing.Point(175, 54);
            this.Laser_Off_Delay.Name = "Laser_Off_Delay";
            this.Laser_Off_Delay.Size = new System.Drawing.Size(115, 28);
            this.Laser_Off_Delay.TabIndex = 35;
            this.Laser_Off_Delay.TextChanged += new System.EventHandler(this.Laser_Off_Delay_TextChanged);
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(14, 96);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(125, 18);
            this.label54.TabIndex = 34;
            this.label54.Text = "Jump速度 mm/s";
            // 
            // Jump_Speed
            // 
            this.Jump_Speed.Location = new System.Drawing.Point(19, 121);
            this.Jump_Speed.Name = "Jump_Speed";
            this.Jump_Speed.Size = new System.Drawing.Size(115, 28);
            this.Jump_Speed.TabIndex = 33;
            this.Jump_Speed.TextChanged += new System.EventHandler(this.Jump_Speed_TextChanged);
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(23, 159);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(107, 18);
            this.label55.TabIndex = 28;
            this.label55.Text = "开光延时 ms";
            // 
            // Laser_ON_Delay
            // 
            this.Laser_ON_Delay.Location = new System.Drawing.Point(19, 188);
            this.Laser_ON_Delay.Name = "Laser_ON_Delay";
            this.Laser_ON_Delay.Size = new System.Drawing.Size(115, 28);
            this.Laser_ON_Delay.TabIndex = 27;
            this.Laser_ON_Delay.TextChanged += new System.EventHandler(this.Laser_ON_Delay_TextChanged);
            // 
            // Change_Para_List
            // 
            this.Change_Para_List.Location = new System.Drawing.Point(331, 182);
            this.Change_Para_List.Name = "Change_Para_List";
            this.Change_Para_List.Size = new System.Drawing.Size(115, 37);
            this.Change_Para_List.TabIndex = 15;
            this.Change_Para_List.Text = "参数生效";
            this.Change_Para_List.UseVisualStyleBackColor = true;
            this.Change_Para_List.Click += new System.EventHandler(this.Change_Para_List_Click);
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(14, 30);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(125, 18);
            this.label56.TabIndex = 16;
            this.label56.Text = "Mark速度 mm/s";
            // 
            // Mark_Speed
            // 
            this.Mark_Speed.Location = new System.Drawing.Point(19, 54);
            this.Mark_Speed.Name = "Mark_Speed";
            this.Mark_Speed.Size = new System.Drawing.Size(115, 28);
            this.Mark_Speed.TabIndex = 15;
            this.Mark_Speed.TextChanged += new System.EventHandler(this.Mark_Speed_TextChanged);
            // 
            // groupBox19
            // 
            this.groupBox19.Controls.Add(this.label57);
            this.groupBox19.Controls.Add(this.label58);
            this.groupBox19.Controls.Add(this.ABSPosY);
            this.groupBox19.Controls.Add(this.ABSPosX);
            this.groupBox19.Controls.Add(this.ABSPos);
            this.groupBox19.Location = new System.Drawing.Point(55, 173);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(464, 104);
            this.groupBox19.TabIndex = 48;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "绝对定位";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(338, 29);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(80, 18);
            this.label57.TabIndex = 14;
            this.label57.Text = "Y坐标/mm";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(185, 29);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(80, 18);
            this.label58.TabIndex = 13;
            this.label58.Text = "X坐标/mm";
            // 
            // ABSPosY
            // 
            this.ABSPosY.Location = new System.Drawing.Point(327, 53);
            this.ABSPosY.Name = "ABSPosY";
            this.ABSPosY.Size = new System.Drawing.Size(115, 28);
            this.ABSPosY.TabIndex = 12;
            this.ABSPosY.TextChanged += new System.EventHandler(this.ABSPosY_TextChanged);
            // 
            // ABSPosX
            // 
            this.ABSPosX.Location = new System.Drawing.Point(174, 53);
            this.ABSPosX.Name = "ABSPosX";
            this.ABSPosX.Size = new System.Drawing.Size(115, 28);
            this.ABSPosX.TabIndex = 11;
            this.ABSPosX.TextChanged += new System.EventHandler(this.ABSPosX_TextChanged);
            // 
            // ABSPos
            // 
            this.ABSPos.Location = new System.Drawing.Point(21, 49);
            this.ABSPos.Name = "ABSPos";
            this.ABSPos.Size = new System.Drawing.Size(115, 37);
            this.ABSPos.TabIndex = 0;
            this.ABSPos.Text = "绝对定位";
            this.ABSPos.UseVisualStyleBackColor = true;
            this.ABSPos.Click += new System.EventHandler(this.ABSPos_Click);
            // 
            // groupBox20
            // 
            this.groupBox20.Controls.Add(this.label59);
            this.groupBox20.Controls.Add(this.label60);
            this.groupBox20.Controls.Add(this.RtcHomeY);
            this.groupBox20.Controls.Add(this.RtcHomeX);
            this.groupBox20.Controls.Add(this.RtcHome);
            this.groupBox20.Location = new System.Drawing.Point(55, 47);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Size = new System.Drawing.Size(464, 104);
            this.groupBox20.TabIndex = 47;
            this.groupBox20.TabStop = false;
            this.groupBox20.Text = "原点指定";
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(328, 29);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(89, 18);
            this.label59.TabIndex = 14;
            this.label59.Text = "Home_Y/mm";
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(175, 29);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(89, 18);
            this.label60.TabIndex = 13;
            this.label60.Text = "Home_X/mm";
            // 
            // RtcHomeY
            // 
            this.RtcHomeY.Location = new System.Drawing.Point(327, 53);
            this.RtcHomeY.Name = "RtcHomeY";
            this.RtcHomeY.Size = new System.Drawing.Size(115, 28);
            this.RtcHomeY.TabIndex = 12;
            this.RtcHomeY.TextChanged += new System.EventHandler(this.RtcHomeY_TextChanged);
            // 
            // RtcHomeX
            // 
            this.RtcHomeX.Location = new System.Drawing.Point(174, 53);
            this.RtcHomeX.Name = "RtcHomeX";
            this.RtcHomeX.Size = new System.Drawing.Size(115, 28);
            this.RtcHomeX.TabIndex = 11;
            this.RtcHomeX.TextChanged += new System.EventHandler(this.RtcHomeX_TextChanged);
            // 
            // RtcHome
            // 
            this.RtcHome.Location = new System.Drawing.Point(21, 49);
            this.RtcHome.Name = "RtcHome";
            this.RtcHome.Size = new System.Drawing.Size(115, 37);
            this.RtcHome.TabIndex = 0;
            this.RtcHome.Text = "Home";
            this.RtcHome.UseVisualStyleBackColor = true;
            this.RtcHome.Click += new System.EventHandler(this.RtcHome_Click);
            // 
            // IOOperate
            // 
            this.IOOperate.Caption = "IO操作";
            this.IOOperate.Controls.Add(this.Buzzer);
            this.IOOperate.Controls.Add(this.BeaconRed);
            this.IOOperate.Controls.Add(this.BeaconGreen);
            this.IOOperate.Controls.Add(this.BeaconYellow);
            this.IOOperate.Controls.Add(this.Blow);
            this.IOOperate.Controls.Add(this.Cylinder);
            this.IOOperate.Controls.Add(this.Lamp);
            this.IOOperate.Name = "IOOperate";
            this.IOOperate.Size = new System.Drawing.Size(1356, 651);
            // 
            // Buzzer
            // 
            this.Buzzer.Location = new System.Drawing.Point(80, 449);
            this.Buzzer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Buzzer.Name = "Buzzer";
            this.Buzzer.Size = new System.Drawing.Size(140, 46);
            this.Buzzer.TabIndex = 22;
            this.Buzzer.Text = "蜂鸣器";
            this.Buzzer.UseVisualStyleBackColor = true;
            this.Buzzer.Click += new System.EventHandler(this.Buzzer_Click);
            // 
            // BeaconRed
            // 
            this.BeaconRed.Location = new System.Drawing.Point(80, 381);
            this.BeaconRed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BeaconRed.Name = "BeaconRed";
            this.BeaconRed.Size = new System.Drawing.Size(140, 46);
            this.BeaconRed.TabIndex = 21;
            this.BeaconRed.Text = "灯塔红";
            this.BeaconRed.UseVisualStyleBackColor = true;
            this.BeaconRed.Click += new System.EventHandler(this.BeaconRed_Click);
            // 
            // BeaconGreen
            // 
            this.BeaconGreen.Location = new System.Drawing.Point(80, 312);
            this.BeaconGreen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BeaconGreen.Name = "BeaconGreen";
            this.BeaconGreen.Size = new System.Drawing.Size(140, 46);
            this.BeaconGreen.TabIndex = 20;
            this.BeaconGreen.Text = "灯塔绿";
            this.BeaconGreen.UseVisualStyleBackColor = true;
            this.BeaconGreen.Click += new System.EventHandler(this.BeaconGreen_Click);
            // 
            // BeaconYellow
            // 
            this.BeaconYellow.Location = new System.Drawing.Point(80, 245);
            this.BeaconYellow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BeaconYellow.Name = "BeaconYellow";
            this.BeaconYellow.Size = new System.Drawing.Size(140, 46);
            this.BeaconYellow.TabIndex = 19;
            this.BeaconYellow.Text = "灯塔黄";
            this.BeaconYellow.UseVisualStyleBackColor = true;
            this.BeaconYellow.Click += new System.EventHandler(this.BeaconYellow_Click);
            // 
            // Blow
            // 
            this.Blow.Location = new System.Drawing.Point(80, 177);
            this.Blow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Blow.Name = "Blow";
            this.Blow.Size = new System.Drawing.Size(140, 46);
            this.Blow.TabIndex = 18;
            this.Blow.Text = "吹气";
            this.Blow.UseVisualStyleBackColor = true;
            this.Blow.Click += new System.EventHandler(this.Blow_Click);
            // 
            // Cylinder
            // 
            this.Cylinder.Location = new System.Drawing.Point(80, 108);
            this.Cylinder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Cylinder.Name = "Cylinder";
            this.Cylinder.Size = new System.Drawing.Size(140, 46);
            this.Cylinder.TabIndex = 17;
            this.Cylinder.Text = "气缸";
            this.Cylinder.UseVisualStyleBackColor = true;
            this.Cylinder.Click += new System.EventHandler(this.Cylinder_Click);
            // 
            // Lamp
            // 
            this.Lamp.Location = new System.Drawing.Point(80, 41);
            this.Lamp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Lamp.Name = "Lamp";
            this.Lamp.Size = new System.Drawing.Size(140, 46);
            this.Lamp.TabIndex = 16;
            this.Lamp.Text = "照明";
            this.Lamp.UseVisualStyleBackColor = true;
            this.Lamp.Click += new System.EventHandler(this.Lamp_Click);
            // 
            // statusFormPage
            // 
            this.statusFormPage.ContentContainer = this.statusFormPageContainer;
            this.statusFormPage.Name = "statusFormPage";
            this.statusFormPage.ShowCloseButton = DevExpress.Utils.DefaultBoolean.False;
            this.statusFormPage.Text = "状态";
            // 
            // statusFormPageContainer
            // 
            this.statusFormPageContainer.Controls.Add(this.label9);
            this.statusFormPageContainer.Controls.Add(this.label8);
            this.statusFormPageContainer.Controls.Add(this.groupBox3);
            this.statusFormPageContainer.Controls.Add(this.groupBox2);
            this.statusFormPageContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusFormPageContainer.Location = new System.Drawing.Point(0, 70);
            this.statusFormPageContainer.Name = "statusFormPageContainer";
            this.statusFormPageContainer.Size = new System.Drawing.Size(1356, 693);
            this.statusFormPageContainer.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(623, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 24);
            this.label9.TabIndex = 19;
            this.label9.Text = "输出信号";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(170, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 24);
            this.label8.TabIndex = 18;
            this.label8.Text = "输入信号";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.EXO10_Status);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.EXO9_Status);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.EXO8_Status);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.EXO7_Status);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.EXO6_Status);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.EXO5_Status);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.EXO4_Status);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.EXO3_Status);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.EXO2_Status);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.EXO1_Status);
            this.groupBox3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(483, 36);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox3.Size = new System.Drawing.Size(387, 646);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(140, 589);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(142, 24);
            this.label19.TabIndex = 19;
            this.label19.Text = "启动按钮2灯";
            // 
            // EXO10_Status
            // 
            this.EXO10_Status.BackColor = System.Drawing.SystemColors.Control;
            this.EXO10_Status.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EXO10_Status.ForeColor = System.Drawing.Color.Black;
            this.EXO10_Status.Location = new System.Drawing.Point(44, 582);
            this.EXO10_Status.Name = "EXO10_Status";
            this.EXO10_Status.Size = new System.Drawing.Size(90, 40);
            this.EXO10_Status.TabIndex = 18;
            this.EXO10_Status.Text = "EXO10";
            this.EXO10_Status.UseVisualStyleBackColor = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(140, 511);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(142, 24);
            this.label18.TabIndex = 17;
            this.label18.Text = "启动按钮1灯";
            // 
            // EXO9_Status
            // 
            this.EXO9_Status.BackColor = System.Drawing.SystemColors.Control;
            this.EXO9_Status.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EXO9_Status.ForeColor = System.Drawing.Color.Black;
            this.EXO9_Status.Location = new System.Drawing.Point(44, 512);
            this.EXO9_Status.Name = "EXO9_Status";
            this.EXO9_Status.Size = new System.Drawing.Size(90, 40);
            this.EXO9_Status.TabIndex = 16;
            this.EXO9_Status.Text = "EXO9";
            this.EXO9_Status.UseVisualStyleBackColor = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(140, 457);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(82, 24);
            this.label17.TabIndex = 15;
            this.label17.Text = "照明灯";
            // 
            // EXO8_Status
            // 
            this.EXO8_Status.BackColor = System.Drawing.SystemColors.Control;
            this.EXO8_Status.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EXO8_Status.ForeColor = System.Drawing.Color.Black;
            this.EXO8_Status.Location = new System.Drawing.Point(44, 449);
            this.EXO8_Status.Name = "EXO8_Status";
            this.EXO8_Status.Size = new System.Drawing.Size(90, 40);
            this.EXO8_Status.TabIndex = 14;
            this.EXO8_Status.Text = "EXO8";
            this.EXO8_Status.UseVisualStyleBackColor = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(140, 397);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 24);
            this.label10.TabIndex = 13;
            this.label10.Text = "吹气打开";
            // 
            // EXO7_Status
            // 
            this.EXO7_Status.BackColor = System.Drawing.SystemColors.Control;
            this.EXO7_Status.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EXO7_Status.ForeColor = System.Drawing.Color.Black;
            this.EXO7_Status.Location = new System.Drawing.Point(44, 389);
            this.EXO7_Status.Name = "EXO7_Status";
            this.EXO7_Status.Size = new System.Drawing.Size(90, 40);
            this.EXO7_Status.TabIndex = 12;
            this.EXO7_Status.Text = "EXO7";
            this.EXO7_Status.UseVisualStyleBackColor = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(140, 337);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(154, 24);
            this.label11.TabIndex = 11;
            this.label11.Text = "除尘气缸退回";
            // 
            // EXO6_Status
            // 
            this.EXO6_Status.BackColor = System.Drawing.SystemColors.Control;
            this.EXO6_Status.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EXO6_Status.ForeColor = System.Drawing.Color.Black;
            this.EXO6_Status.Location = new System.Drawing.Point(44, 329);
            this.EXO6_Status.Name = "EXO6_Status";
            this.EXO6_Status.Size = new System.Drawing.Size(90, 40);
            this.EXO6_Status.TabIndex = 10;
            this.EXO6_Status.Text = "EXO6";
            this.EXO6_Status.UseVisualStyleBackColor = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(140, 277);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(154, 24);
            this.label12.TabIndex = 9;
            this.label12.Text = "除尘气缸伸出";
            // 
            // EXO5_Status
            // 
            this.EXO5_Status.BackColor = System.Drawing.SystemColors.Control;
            this.EXO5_Status.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EXO5_Status.ForeColor = System.Drawing.Color.Black;
            this.EXO5_Status.Location = new System.Drawing.Point(44, 269);
            this.EXO5_Status.Name = "EXO5_Status";
            this.EXO5_Status.Size = new System.Drawing.Size(90, 40);
            this.EXO5_Status.TabIndex = 8;
            this.EXO5_Status.Text = "EXO5";
            this.EXO5_Status.UseVisualStyleBackColor = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(140, 217);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 24);
            this.label13.TabIndex = 7;
            this.label13.Text = "蜂鸣器";
            // 
            // EXO4_Status
            // 
            this.EXO4_Status.BackColor = System.Drawing.SystemColors.Control;
            this.EXO4_Status.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EXO4_Status.ForeColor = System.Drawing.Color.Black;
            this.EXO4_Status.Location = new System.Drawing.Point(44, 209);
            this.EXO4_Status.Name = "EXO4_Status";
            this.EXO4_Status.Size = new System.Drawing.Size(90, 40);
            this.EXO4_Status.TabIndex = 6;
            this.EXO4_Status.Text = "EXO4";
            this.EXO4_Status.UseVisualStyleBackColor = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(140, 157);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(130, 24);
            this.label14.TabIndex = 5;
            this.label14.Text = "三色灯塔红";
            // 
            // EXO3_Status
            // 
            this.EXO3_Status.BackColor = System.Drawing.SystemColors.Control;
            this.EXO3_Status.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EXO3_Status.ForeColor = System.Drawing.Color.Black;
            this.EXO3_Status.Location = new System.Drawing.Point(44, 149);
            this.EXO3_Status.Name = "EXO3_Status";
            this.EXO3_Status.Size = new System.Drawing.Size(90, 40);
            this.EXO3_Status.TabIndex = 4;
            this.EXO3_Status.Text = "EXO3";
            this.EXO3_Status.UseVisualStyleBackColor = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(140, 97);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(130, 24);
            this.label15.TabIndex = 3;
            this.label15.Text = "三色灯塔绿";
            // 
            // EXO2_Status
            // 
            this.EXO2_Status.BackColor = System.Drawing.SystemColors.Control;
            this.EXO2_Status.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EXO2_Status.ForeColor = System.Drawing.Color.Black;
            this.EXO2_Status.Location = new System.Drawing.Point(44, 89);
            this.EXO2_Status.Name = "EXO2_Status";
            this.EXO2_Status.Size = new System.Drawing.Size(90, 40);
            this.EXO2_Status.TabIndex = 2;
            this.EXO2_Status.Text = "EXO2";
            this.EXO2_Status.UseVisualStyleBackColor = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(140, 37);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(130, 24);
            this.label16.TabIndex = 1;
            this.label16.Text = "三色灯塔黄";
            // 
            // EXO1_Status
            // 
            this.EXO1_Status.BackColor = System.Drawing.SystemColors.Control;
            this.EXO1_Status.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EXO1_Status.ForeColor = System.Drawing.Color.Black;
            this.EXO1_Status.Location = new System.Drawing.Point(44, 29);
            this.EXO1_Status.Name = "EXO1_Status";
            this.EXO1_Status.Size = new System.Drawing.Size(90, 40);
            this.EXO1_Status.TabIndex = 0;
            this.EXO1_Status.Text = "EXO1";
            this.EXO1_Status.UseVisualStyleBackColor = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.Homed_Status);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.EXI7_Status);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.EXI6_Status);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.EXI5_Status);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.EXI4_Status);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.EXI3_Status);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.EXI2_Status);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.EXI1_Status);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(30, 32);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox2.Size = new System.Drawing.Size(387, 650);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.Location = new System.Drawing.Point(140, 457);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(130, 24);
            this.label20.TabIndex = 15;
            this.label20.Text = "XY均已回零";
            // 
            // Homed_Status
            // 
            this.Homed_Status.BackColor = System.Drawing.SystemColors.Control;
            this.Homed_Status.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Homed_Status.ForeColor = System.Drawing.Color.Black;
            this.Homed_Status.Location = new System.Drawing.Point(44, 449);
            this.Homed_Status.Name = "Homed_Status";
            this.Homed_Status.Size = new System.Drawing.Size(90, 40);
            this.Homed_Status.TabIndex = 14;
            this.Homed_Status.Text = "Homed";
            this.Homed_Status.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(140, 397);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 24);
            this.label7.TabIndex = 13;
            this.label7.Text = "启动按钮2";
            // 
            // EXI7_Status
            // 
            this.EXI7_Status.BackColor = System.Drawing.SystemColors.Control;
            this.EXI7_Status.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EXI7_Status.ForeColor = System.Drawing.Color.Black;
            this.EXI7_Status.Location = new System.Drawing.Point(44, 389);
            this.EXI7_Status.Name = "EXI7_Status";
            this.EXI7_Status.Size = new System.Drawing.Size(90, 40);
            this.EXI7_Status.TabIndex = 12;
            this.EXI7_Status.Text = "EXI7";
            this.EXI7_Status.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(140, 337);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 24);
            this.label6.TabIndex = 11;
            this.label6.Text = "启动按钮1";
            // 
            // EXI6_Status
            // 
            this.EXI6_Status.BackColor = System.Drawing.SystemColors.Control;
            this.EXI6_Status.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EXI6_Status.ForeColor = System.Drawing.Color.Black;
            this.EXI6_Status.Location = new System.Drawing.Point(44, 329);
            this.EXI6_Status.Name = "EXI6_Status";
            this.EXI6_Status.Size = new System.Drawing.Size(90, 40);
            this.EXI6_Status.TabIndex = 10;
            this.EXI6_Status.Text = "EXI6";
            this.EXI6_Status.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(140, 277);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 24);
            this.label5.TabIndex = 9;
            this.label5.Text = "右门禁传感器";
            // 
            // EXI5_Status
            // 
            this.EXI5_Status.BackColor = System.Drawing.SystemColors.Control;
            this.EXI5_Status.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EXI5_Status.ForeColor = System.Drawing.Color.Black;
            this.EXI5_Status.Location = new System.Drawing.Point(44, 269);
            this.EXI5_Status.Name = "EXI5_Status";
            this.EXI5_Status.Size = new System.Drawing.Size(90, 40);
            this.EXI5_Status.TabIndex = 8;
            this.EXI5_Status.Text = "EXI5";
            this.EXI5_Status.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(140, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "左门禁传感器";
            // 
            // EXI4_Status
            // 
            this.EXI4_Status.BackColor = System.Drawing.SystemColors.Control;
            this.EXI4_Status.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EXI4_Status.ForeColor = System.Drawing.Color.Black;
            this.EXI4_Status.Location = new System.Drawing.Point(44, 209);
            this.EXI4_Status.Name = "EXI4_Status";
            this.EXI4_Status.Size = new System.Drawing.Size(90, 40);
            this.EXI4_Status.TabIndex = 6;
            this.EXI4_Status.Text = "EXI4";
            this.EXI4_Status.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(140, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(226, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "除尘气缸退回传感器";
            // 
            // EXI3_Status
            // 
            this.EXI3_Status.BackColor = System.Drawing.SystemColors.Control;
            this.EXI3_Status.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EXI3_Status.ForeColor = System.Drawing.Color.Black;
            this.EXI3_Status.Location = new System.Drawing.Point(44, 149);
            this.EXI3_Status.Name = "EXI3_Status";
            this.EXI3_Status.Size = new System.Drawing.Size(90, 40);
            this.EXI3_Status.TabIndex = 4;
            this.EXI3_Status.Text = "EXI3";
            this.EXI3_Status.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(140, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(226, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "除尘气缸伸出传感器";
            // 
            // EXI2_Status
            // 
            this.EXI2_Status.BackColor = System.Drawing.SystemColors.Control;
            this.EXI2_Status.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EXI2_Status.ForeColor = System.Drawing.Color.Black;
            this.EXI2_Status.Location = new System.Drawing.Point(44, 89);
            this.EXI2_Status.Name = "EXI2_Status";
            this.EXI2_Status.Size = new System.Drawing.Size(90, 40);
            this.EXI2_Status.TabIndex = 2;
            this.EXI2_Status.Text = "EXI2";
            this.EXI2_Status.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(140, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "急停开关";
            // 
            // EXI1_Status
            // 
            this.EXI1_Status.BackColor = System.Drawing.SystemColors.Control;
            this.EXI1_Status.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EXI1_Status.ForeColor = System.Drawing.Color.Black;
            this.EXI1_Status.Location = new System.Drawing.Point(44, 29);
            this.EXI1_Status.Name = "EXI1_Status";
            this.EXI1_Status.Size = new System.Drawing.Size(90, 40);
            this.EXI1_Status.TabIndex = 0;
            this.EXI1_Status.Text = "EXI1";
            this.EXI1_Status.UseVisualStyleBackColor = false;
            // 
            // laserFormPage
            // 
            this.laserFormPage.ContentContainer = this.laserFormPageContainer;
            this.laserFormPage.Name = "laserFormPage";
            this.laserFormPage.ShowCloseButton = DevExpress.Utils.DefaultBoolean.False;
            this.laserFormPage.Text = "激光";
            // 
            // laserFormPageContainer
            // 
            this.laserFormPageContainer.Controls.Add(this.groupBox10);
            this.laserFormPageContainer.Controls.Add(this.groupBox7);
            this.laserFormPageContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.laserFormPageContainer.Location = new System.Drawing.Point(0, 70);
            this.laserFormPageContainer.Name = "laserFormPageContainer";
            this.laserFormPageContainer.Size = new System.Drawing.Size(1356, 693);
            this.laserFormPageContainer.TabIndex = 6;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.groupBox9);
            this.groupBox10.Controls.Add(this.LW_Save_Data);
            this.groupBox10.Controls.Add(this.LW_Acquisition_Once);
            this.groupBox10.Controls.Add(this.Laser_Current_Watt_Label);
            this.groupBox10.Controls.Add(this.Laser_Percent_Label);
            this.groupBox10.Controls.Add(this.LW_PEC_Indicate);
            this.groupBox10.Controls.Add(this.LW_Watt_Indicate);
            this.groupBox10.Location = new System.Drawing.Point(778, 13);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(566, 336);
            this.groupBox10.TabIndex = 51;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "激光功率";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.LW_Re_Connect);
            this.groupBox9.Controls.Add(this.LW_Refresh_List);
            this.groupBox9.Controls.Add(this.LW_Com_List);
            this.groupBox9.Controls.Add(this.LW_Com_Status);
            this.groupBox9.Location = new System.Drawing.Point(16, 43);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(536, 83);
            this.groupBox9.TabIndex = 41;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "端口";
            // 
            // LW_Re_Connect
            // 
            this.LW_Re_Connect.Location = new System.Drawing.Point(315, 29);
            this.LW_Re_Connect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LW_Re_Connect.Name = "LW_Re_Connect";
            this.LW_Re_Connect.Size = new System.Drawing.Size(122, 35);
            this.LW_Re_Connect.TabIndex = 42;
            this.LW_Re_Connect.Text = "打开串口";
            this.LW_Re_Connect.UseVisualStyleBackColor = true;
            this.LW_Re_Connect.Click += new System.EventHandler(this.LW_Re_Connect_Click);
            // 
            // LW_Refresh_List
            // 
            this.LW_Refresh_List.Location = new System.Drawing.Point(20, 29);
            this.LW_Refresh_List.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LW_Refresh_List.Name = "LW_Refresh_List";
            this.LW_Refresh_List.Size = new System.Drawing.Size(122, 35);
            this.LW_Refresh_List.TabIndex = 51;
            this.LW_Refresh_List.Text = "更新列表";
            this.LW_Refresh_List.UseVisualStyleBackColor = true;
            this.LW_Refresh_List.Click += new System.EventHandler(this.LW_Refresh_List_Click);
            // 
            // LW_Com_List
            // 
            this.LW_Com_List.FormattingEnabled = true;
            this.LW_Com_List.Location = new System.Drawing.Point(168, 31);
            this.LW_Com_List.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LW_Com_List.Name = "LW_Com_List";
            this.LW_Com_List.Size = new System.Drawing.Size(121, 26);
            this.LW_Com_List.TabIndex = 43;
            this.LW_Com_List.SelectedIndexChanged += new System.EventHandler(this.LW_Com_List_SelectedIndexChanged);
            // 
            // LW_Com_Status
            // 
            this.LW_Com_Status.Location = new System.Drawing.Point(463, 30);
            this.LW_Com_Status.Margin = new System.Windows.Forms.Padding(0);
            this.LW_Com_Status.Name = "LW_Com_Status";
            this.LW_Com_Status.Size = new System.Drawing.Size(32, 32);
            this.LW_Com_Status.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.LW_Com_Status.TabIndex = 44;
            this.LW_Com_Status.TabStop = false;
            // 
            // LW_Save_Data
            // 
            this.LW_Save_Data.Location = new System.Drawing.Point(324, 250);
            this.LW_Save_Data.Name = "LW_Save_Data";
            this.LW_Save_Data.Size = new System.Drawing.Size(136, 42);
            this.LW_Save_Data.TabIndex = 50;
            this.LW_Save_Data.Text = "保存采集数据";
            this.LW_Save_Data.UseVisualStyleBackColor = true;
            this.LW_Save_Data.Click += new System.EventHandler(this.LW_Save_Data_Click);
            // 
            // LW_Acquisition_Once
            // 
            this.LW_Acquisition_Once.Location = new System.Drawing.Point(64, 250);
            this.LW_Acquisition_Once.Name = "LW_Acquisition_Once";
            this.LW_Acquisition_Once.Size = new System.Drawing.Size(136, 42);
            this.LW_Acquisition_Once.TabIndex = 49;
            this.LW_Acquisition_Once.Text = "采集一次";
            this.LW_Acquisition_Once.UseVisualStyleBackColor = true;
            this.LW_Acquisition_Once.Click += new System.EventHandler(this.LW_Acquisition_Once_Click);
            // 
            // Laser_Current_Watt_Label
            // 
            this.Laser_Current_Watt_Label.AutoSize = true;
            this.Laser_Current_Watt_Label.Location = new System.Drawing.Point(316, 166);
            this.Laser_Current_Watt_Label.Name = "Laser_Current_Watt_Label";
            this.Laser_Current_Watt_Label.Size = new System.Drawing.Size(152, 18);
            this.Laser_Current_Watt_Label.TabIndex = 48;
            this.Laser_Current_Watt_Label.Text = "激光实时功率(mw)";
            // 
            // Laser_Percent_Label
            // 
            this.Laser_Percent_Label.AutoSize = true;
            this.Laser_Percent_Label.Location = new System.Drawing.Point(52, 166);
            this.Laser_Percent_Label.Name = "Laser_Percent_Label";
            this.Laser_Percent_Label.Size = new System.Drawing.Size(161, 18);
            this.Laser_Percent_Label.TabIndex = 47;
            this.Laser_Percent_Label.Text = "激光输出百分比(%)";
            // 
            // LW_PEC_Indicate
            // 
            this.LW_PEC_Indicate.Location = new System.Drawing.Point(72, 197);
            this.LW_PEC_Indicate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LW_PEC_Indicate.Name = "LW_PEC_Indicate";
            this.LW_PEC_Indicate.Size = new System.Drawing.Size(121, 28);
            this.LW_PEC_Indicate.TabIndex = 46;
            // 
            // LW_Watt_Indicate
            // 
            this.LW_Watt_Indicate.Location = new System.Drawing.Point(332, 197);
            this.LW_Watt_Indicate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LW_Watt_Indicate.Name = "LW_Watt_Indicate";
            this.LW_Watt_Indicate.Size = new System.Drawing.Size(121, 28);
            this.LW_Watt_Indicate.TabIndex = 45;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.groupBox8);
            this.groupBox7.Controls.Add(this.groupBox4);
            this.groupBox7.Controls.Add(this.LC_Status);
            this.groupBox7.Controls.Add(this.groupBox5);
            this.groupBox7.Controls.Add(this.groupBox6);
            this.groupBox7.Controls.Add(this.LC_Power_OFF);
            this.groupBox7.Controls.Add(this.LC_Power_On);
            this.groupBox7.Location = new System.Drawing.Point(12, 13);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(749, 671);
            this.groupBox7.TabIndex = 41;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "激光控制";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.LC_Refresh_List);
            this.groupBox8.Controls.Add(this.LC_Com_List);
            this.groupBox8.Controls.Add(this.LC_Re_connect);
            this.groupBox8.Controls.Add(this.LC_Com_Status);
            this.groupBox8.Location = new System.Drawing.Point(130, 20);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(536, 83);
            this.groupBox8.TabIndex = 40;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "端口";
            // 
            // LC_Refresh_List
            // 
            this.LC_Refresh_List.Location = new System.Drawing.Point(23, 30);
            this.LC_Refresh_List.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LC_Refresh_List.Name = "LC_Refresh_List";
            this.LC_Refresh_List.Size = new System.Drawing.Size(122, 35);
            this.LC_Refresh_List.TabIndex = 40;
            this.LC_Refresh_List.Text = "更新列表";
            this.LC_Refresh_List.UseVisualStyleBackColor = true;
            this.LC_Refresh_List.Click += new System.EventHandler(this.LC_Refresh_List_Click);
            // 
            // LC_Com_List
            // 
            this.LC_Com_List.FormattingEnabled = true;
            this.LC_Com_List.Location = new System.Drawing.Point(171, 32);
            this.LC_Com_List.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LC_Com_List.Name = "LC_Com_List";
            this.LC_Com_List.Size = new System.Drawing.Size(121, 26);
            this.LC_Com_List.TabIndex = 37;
            this.LC_Com_List.SelectedIndexChanged += new System.EventHandler(this.LC_Com_List_SelectedIndexChanged);
            // 
            // LC_Re_connect
            // 
            this.LC_Re_connect.Location = new System.Drawing.Point(318, 30);
            this.LC_Re_connect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LC_Re_connect.Name = "LC_Re_connect";
            this.LC_Re_connect.Size = new System.Drawing.Size(122, 35);
            this.LC_Re_connect.TabIndex = 33;
            this.LC_Re_connect.Text = "打开串口";
            this.LC_Re_connect.UseVisualStyleBackColor = true;
            this.LC_Re_connect.Click += new System.EventHandler(this.LC_Re_connect_Click);
            // 
            // LC_Com_Status
            // 
            this.LC_Com_Status.Location = new System.Drawing.Point(466, 31);
            this.LC_Com_Status.Margin = new System.Windows.Forms.Padding(0);
            this.LC_Com_Status.Name = "LC_Com_Status";
            this.LC_Com_Status.Size = new System.Drawing.Size(32, 32);
            this.LC_Com_Status.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.LC_Com_Status.TabIndex = 38;
            this.LC_Com_Status.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.LC_Amp2_Set);
            this.groupBox4.Controls.Add(this.LC_PRF_Confirm);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Controls.Add(this.LC_PEC_Confirm);
            this.groupBox4.Controls.Add(this.LC_Amp1_Set);
            this.groupBox4.Controls.Add(this.LC_PRF_Set_Value);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.label23);
            this.groupBox4.Controls.Add(this.LC_Seed_Set);
            this.groupBox4.Controls.Add(this.LC_PEC_Set_Value);
            this.groupBox4.Controls.Add(this.label24);
            this.groupBox4.Controls.Add(this.label25);
            this.groupBox4.Location = new System.Drawing.Point(193, 345);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Size = new System.Drawing.Size(538, 305);
            this.groupBox4.TabIndex = 39;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "激光参数";
            // 
            // LC_Amp2_Set
            // 
            this.LC_Amp2_Set.Location = new System.Drawing.Point(228, 260);
            this.LC_Amp2_Set.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LC_Amp2_Set.Name = "LC_Amp2_Set";
            this.LC_Amp2_Set.Size = new System.Drawing.Size(100, 28);
            this.LC_Amp2_Set.TabIndex = 17;
            // 
            // LC_PRF_Confirm
            // 
            this.LC_PRF_Confirm.Location = new System.Drawing.Point(364, 92);
            this.LC_PRF_Confirm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LC_PRF_Confirm.Name = "LC_PRF_Confirm";
            this.LC_PRF_Confirm.Size = new System.Drawing.Size(122, 35);
            this.LC_PRF_Confirm.TabIndex = 19;
            this.LC_PRF_Confirm.Text = "频率写入";
            this.LC_PRF_Confirm.UseVisualStyleBackColor = true;
            this.LC_PRF_Confirm.Click += new System.EventHandler(this.LC_PRF_Confirm_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(24, 266);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(188, 18);
            this.label21.TabIndex = 16;
            this.label21.Text = "Amp2 电流 设置值(A):";
            // 
            // LC_PEC_Confirm
            // 
            this.LC_PEC_Confirm.Location = new System.Drawing.Point(364, 38);
            this.LC_PEC_Confirm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LC_PEC_Confirm.Name = "LC_PEC_Confirm";
            this.LC_PEC_Confirm.Size = new System.Drawing.Size(122, 35);
            this.LC_PEC_Confirm.TabIndex = 18;
            this.LC_PEC_Confirm.Text = "功率写入";
            this.LC_PEC_Confirm.UseVisualStyleBackColor = true;
            this.LC_PEC_Confirm.Click += new System.EventHandler(this.LC_PEC_Confirm_Click);
            // 
            // LC_Amp1_Set
            // 
            this.LC_Amp1_Set.Location = new System.Drawing.Point(228, 206);
            this.LC_Amp1_Set.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LC_Amp1_Set.Name = "LC_Amp1_Set";
            this.LC_Amp1_Set.Size = new System.Drawing.Size(100, 28);
            this.LC_Amp1_Set.TabIndex = 15;
            // 
            // LC_PRF_Set_Value
            // 
            this.LC_PRF_Set_Value.Location = new System.Drawing.Point(228, 96);
            this.LC_PRF_Set_Value.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LC_PRF_Set_Value.Name = "LC_PRF_Set_Value";
            this.LC_PRF_Set_Value.Size = new System.Drawing.Size(100, 28);
            this.LC_PRF_Set_Value.TabIndex = 15;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(24, 211);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(188, 18);
            this.label22.TabIndex = 14;
            this.label22.Text = "Amp1 电流 设置值(A):";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(24, 101);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(143, 18);
            this.label23.TabIndex = 14;
            this.label23.Text = "激光频率 (KHz):";
            // 
            // LC_Seed_Set
            // 
            this.LC_Seed_Set.Location = new System.Drawing.Point(228, 151);
            this.LC_Seed_Set.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LC_Seed_Set.Name = "LC_Seed_Set";
            this.LC_Seed_Set.Size = new System.Drawing.Size(100, 28);
            this.LC_Seed_Set.TabIndex = 13;
            // 
            // LC_PEC_Set_Value
            // 
            this.LC_PEC_Set_Value.Location = new System.Drawing.Point(228, 41);
            this.LC_PEC_Set_Value.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LC_PEC_Set_Value.Name = "LC_PEC_Set_Value";
            this.LC_PEC_Set_Value.Size = new System.Drawing.Size(100, 28);
            this.LC_PEC_Set_Value.TabIndex = 13;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(24, 156);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(188, 18);
            this.label24.TabIndex = 12;
            this.label24.Text = "Seed 电流 设置值(A):";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(24, 46);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(125, 18);
            this.label25.TabIndex = 12;
            this.label25.Text = "激光功率 (%):";
            // 
            // LC_Status
            // 
            this.LC_Status.BackColor = System.Drawing.SystemColors.Menu;
            this.LC_Status.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LC_Status.Location = new System.Drawing.Point(9, 208);
            this.LC_Status.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LC_Status.Name = "LC_Status";
            this.LC_Status.Size = new System.Drawing.Size(165, 358);
            this.LC_Status.TabIndex = 36;
            this.LC_Status.Text = "";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label26);
            this.groupBox5.Controls.Add(this.LC_Reset_Laser);
            this.groupBox5.Controls.Add(this.LC_Refresh_Status);
            this.groupBox5.Location = new System.Drawing.Point(193, 120);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Size = new System.Drawing.Size(249, 217);
            this.groupBox5.TabIndex = 35;
            this.groupBox5.TabStop = false;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(15, 2);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(80, 18);
            this.label26.TabIndex = 4;
            this.label26.Text = "手动操作";
            // 
            // LC_Reset_Laser
            // 
            this.LC_Reset_Laser.Location = new System.Drawing.Point(34, 132);
            this.LC_Reset_Laser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LC_Reset_Laser.Name = "LC_Reset_Laser";
            this.LC_Reset_Laser.Size = new System.Drawing.Size(183, 58);
            this.LC_Reset_Laser.TabIndex = 3;
            this.LC_Reset_Laser.Text = "复    位";
            this.LC_Reset_Laser.UseVisualStyleBackColor = true;
            this.LC_Reset_Laser.Click += new System.EventHandler(this.LC_Reset_Laser_Click);
            // 
            // LC_Refresh_Status
            // 
            this.LC_Refresh_Status.Location = new System.Drawing.Point(34, 54);
            this.LC_Refresh_Status.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LC_Refresh_Status.Name = "LC_Refresh_Status";
            this.LC_Refresh_Status.Size = new System.Drawing.Size(183, 58);
            this.LC_Refresh_Status.TabIndex = 2;
            this.LC_Refresh_Status.Text = "状态更新";
            this.LC_Refresh_Status.UseVisualStyleBackColor = true;
            this.LC_Refresh_Status.Click += new System.EventHandler(this.LC_Refresh_Status_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.LC_Amp2_Current);
            this.groupBox6.Controls.Add(this.label27);
            this.groupBox6.Controls.Add(this.LC_Amp1_Current);
            this.groupBox6.Controls.Add(this.label28);
            this.groupBox6.Controls.Add(this.LC_Seed_Current);
            this.groupBox6.Controls.Add(this.label29);
            this.groupBox6.Controls.Add(this.label30);
            this.groupBox6.Location = new System.Drawing.Point(458, 121);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox6.Size = new System.Drawing.Size(273, 217);
            this.groupBox6.TabIndex = 34;
            this.groupBox6.TabStop = false;
            // 
            // LC_Amp2_Current
            // 
            this.LC_Amp2_Current.Location = new System.Drawing.Point(148, 170);
            this.LC_Amp2_Current.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LC_Amp2_Current.Name = "LC_Amp2_Current";
            this.LC_Amp2_Current.Size = new System.Drawing.Size(100, 28);
            this.LC_Amp2_Current.TabIndex = 11;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(17, 175);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(125, 18);
            this.label27.TabIndex = 10;
            this.label27.Text = "Amp2 电流(A):";
            // 
            // LC_Amp1_Current
            // 
            this.LC_Amp1_Current.Location = new System.Drawing.Point(148, 110);
            this.LC_Amp1_Current.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LC_Amp1_Current.Name = "LC_Amp1_Current";
            this.LC_Amp1_Current.Size = new System.Drawing.Size(100, 28);
            this.LC_Amp1_Current.TabIndex = 9;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(17, 115);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(125, 18);
            this.label28.TabIndex = 8;
            this.label28.Text = "Amp1 电流(A):";
            // 
            // LC_Seed_Current
            // 
            this.LC_Seed_Current.Location = new System.Drawing.Point(148, 50);
            this.LC_Seed_Current.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LC_Seed_Current.Name = "LC_Seed_Current";
            this.LC_Seed_Current.Size = new System.Drawing.Size(100, 28);
            this.LC_Seed_Current.TabIndex = 7;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(17, 55);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(125, 18);
            this.label29.TabIndex = 6;
            this.label29.Text = "Seed 电流(A):";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(-2, 4);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(116, 18);
            this.label30.TabIndex = 5;
            this.label30.Text = "实时电流信息";
            // 
            // LC_Power_OFF
            // 
            this.LC_Power_OFF.Location = new System.Drawing.Point(9, 591);
            this.LC_Power_OFF.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LC_Power_OFF.Name = "LC_Power_OFF";
            this.LC_Power_OFF.Size = new System.Drawing.Size(165, 58);
            this.LC_Power_OFF.TabIndex = 32;
            this.LC_Power_OFF.Text = "一键关机";
            this.LC_Power_OFF.UseVisualStyleBackColor = true;
            this.LC_Power_OFF.Click += new System.EventHandler(this.LC_Power_OFF_Click);
            // 
            // LC_Power_On
            // 
            this.LC_Power_On.Location = new System.Drawing.Point(9, 125);
            this.LC_Power_On.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LC_Power_On.Name = "LC_Power_On";
            this.LC_Power_On.Size = new System.Drawing.Size(165, 58);
            this.LC_Power_On.TabIndex = 31;
            this.LC_Power_On.Text = "一键开机";
            this.LC_Power_On.UseVisualStyleBackColor = true;
            this.LC_Power_On.Click += new System.EventHandler(this.LC_Power_On_Click);
            // 
            // setFormPage
            // 
            this.setFormPage.ContentContainer = this.setFormPageContainer;
            this.setFormPage.Name = "setFormPage";
            this.setFormPage.ShowCloseButton = DevExpress.Utils.DefaultBoolean.False;
            this.setFormPage.Text = "设置";
            // 
            // setFormPageContainer
            // 
            this.setFormPageContainer.Controls.Add(this.setTabPane);
            this.setFormPageContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setFormPageContainer.Location = new System.Drawing.Point(0, 70);
            this.setFormPageContainer.Name = "setFormPageContainer";
            this.setFormPageContainer.Size = new System.Drawing.Size(1356, 693);
            this.setFormPageContainer.TabIndex = 5;
            // 
            // setTabPane
            // 
            this.setTabPane.AllowCollapse = DevExpress.Utils.DefaultBoolean.Default;
            this.setTabPane.Controls.Add(this.paraSet);
            this.setTabPane.Controls.Add(this.ScissorList);
            this.setTabPane.Controls.Add(this.RePeatList);
            this.setTabPane.Controls.Add(this.CameraPara);
            this.setTabPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setTabPane.Location = new System.Drawing.Point(0, 0);
            this.setTabPane.Name = "setTabPane";
            this.setTabPane.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.paraSet,
            this.ScissorList,
            this.RePeatList,
            this.CameraPara});
            this.setTabPane.RegularSize = new System.Drawing.Size(1356, 693);
            this.setTabPane.SelectedPage = this.paraSet;
            this.setTabPane.Size = new System.Drawing.Size(1356, 693);
            this.setTabPane.TabIndex = 0;
            this.setTabPane.Text = "setTabPane";
            // 
            // paraSet
            // 
            this.paraSet.Caption = "参数设置";
            this.paraSet.Controls.Add(this.groupBox23);
            this.paraSet.Controls.Add(this.groupBox22);
            this.paraSet.Controls.Add(this.Mark_Group);
            this.paraSet.Name = "paraSet";
            this.paraSet.Size = new System.Drawing.Size(1356, 651);
            // 
            // groupBox23
            // 
            this.groupBox23.Controls.Add(this.SyaParaRead);
            this.groupBox23.Controls.Add(this.SysParaSave);
            this.groupBox23.Controls.Add(this.label73);
            this.groupBox23.Controls.Add(this.ArcEndVelocitySet);
            this.groupBox23.Controls.Add(this.label74);
            this.groupBox23.Controls.Add(this.LineEndVelocitySet);
            this.groupBox23.Controls.Add(this.label75);
            this.groupBox23.Controls.Add(this.SmoothTimeSet);
            this.groupBox23.Controls.Add(this.label76);
            this.groupBox23.Controls.Add(this.ArcACCSet);
            this.groupBox23.Controls.Add(this.label77);
            this.groupBox23.Controls.Add(this.ArcVelocitySet);
            this.groupBox23.Controls.Add(this.label78);
            this.groupBox23.Controls.Add(this.LineVelocitySet);
            this.groupBox23.Controls.Add(this.label79);
            this.groupBox23.Controls.Add(this.LineACCSet);
            this.groupBox23.Controls.Add(this.label80);
            this.groupBox23.Controls.Add(this.WorkY);
            this.groupBox23.Controls.Add(this.label81);
            this.groupBox23.Controls.Add(this.WorkX);
            this.groupBox23.Location = new System.Drawing.Point(724, 31);
            this.groupBox23.Name = "groupBox23";
            this.groupBox23.Size = new System.Drawing.Size(564, 467);
            this.groupBox23.TabIndex = 131;
            this.groupBox23.TabStop = false;
            this.groupBox23.Text = "加工参数";
            // 
            // SyaParaRead
            // 
            this.SyaParaRead.Location = new System.Drawing.Point(381, 392);
            this.SyaParaRead.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SyaParaRead.Name = "SyaParaRead";
            this.SyaParaRead.Size = new System.Drawing.Size(154, 50);
            this.SyaParaRead.TabIndex = 72;
            this.SyaParaRead.Text = "参数读取";
            this.SyaParaRead.UseVisualStyleBackColor = true;
            this.SyaParaRead.Click += new System.EventHandler(this.SyaParaRead_Click);
            // 
            // SysParaSave
            // 
            this.SysParaSave.Location = new System.Drawing.Point(35, 392);
            this.SysParaSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SysParaSave.Name = "SysParaSave";
            this.SysParaSave.Size = new System.Drawing.Size(154, 50);
            this.SysParaSave.TabIndex = 71;
            this.SysParaSave.Text = "参数保存";
            this.SysParaSave.UseVisualStyleBackColor = true;
            this.SysParaSave.Click += new System.EventHandler(this.SysParaSave_Click);
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Location = new System.Drawing.Point(372, 215);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(152, 18);
            this.label73.TabIndex = 65;
            this.label73.Text = "圆弧终止速度mm/s";
            // 
            // ArcEndVelocitySet
            // 
            this.ArcEndVelocitySet.Location = new System.Drawing.Point(386, 250);
            this.ArcEndVelocitySet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ArcEndVelocitySet.Name = "ArcEndVelocitySet";
            this.ArcEndVelocitySet.Size = new System.Drawing.Size(135, 28);
            this.ArcEndVelocitySet.TabIndex = 64;
            this.ArcEndVelocitySet.TextChanged += new System.EventHandler(this.ArcEndVelocitySet_TextChanged);
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.Location = new System.Drawing.Point(372, 133);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(152, 18);
            this.label74.TabIndex = 63;
            this.label74.Text = "直线终止速度mm/s";
            // 
            // LineEndVelocitySet
            // 
            this.LineEndVelocitySet.Location = new System.Drawing.Point(386, 168);
            this.LineEndVelocitySet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LineEndVelocitySet.Name = "LineEndVelocitySet";
            this.LineEndVelocitySet.Size = new System.Drawing.Size(135, 28);
            this.LineEndVelocitySet.TabIndex = 62;
            this.LineEndVelocitySet.TextChanged += new System.EventHandler(this.LineEndVelocitySet_TextChanged);
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.Location = new System.Drawing.Point(379, 45);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(143, 18);
            this.label75.TabIndex = 61;
            this.label75.Text = "运动平滑系数/ms";
            // 
            // SmoothTimeSet
            // 
            this.SmoothTimeSet.Location = new System.Drawing.Point(386, 80);
            this.SmoothTimeSet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SmoothTimeSet.Name = "SmoothTimeSet";
            this.SmoothTimeSet.Size = new System.Drawing.Size(135, 28);
            this.SmoothTimeSet.TabIndex = 60;
            this.SmoothTimeSet.TextChanged += new System.EventHandler(this.SmoothTimeSet_TextChanged);
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.Location = new System.Drawing.Point(203, 215);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(143, 18);
            this.label76.TabIndex = 48;
            this.label76.Text = "圆弧加速度mm/s²";
            // 
            // ArcACCSet
            // 
            this.ArcACCSet.Location = new System.Drawing.Point(213, 250);
            this.ArcACCSet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ArcACCSet.Name = "ArcACCSet";
            this.ArcACCSet.Size = new System.Drawing.Size(135, 28);
            this.ArcACCSet.TabIndex = 47;
            this.ArcACCSet.TextChanged += new System.EventHandler(this.ArcACCSet_TextChanged);
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.Location = new System.Drawing.Point(44, 215);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(116, 18);
            this.label77.TabIndex = 46;
            this.label77.Text = "圆弧速度mm/s";
            // 
            // ArcVelocitySet
            // 
            this.ArcVelocitySet.Location = new System.Drawing.Point(40, 250);
            this.ArcVelocitySet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ArcVelocitySet.Name = "ArcVelocitySet";
            this.ArcVelocitySet.Size = new System.Drawing.Size(135, 28);
            this.ArcVelocitySet.TabIndex = 45;
            this.ArcVelocitySet.TextChanged += new System.EventHandler(this.ArcVelocitySet_TextChanged);
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.Location = new System.Drawing.Point(44, 130);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(116, 18);
            this.label78.TabIndex = 44;
            this.label78.Text = "直线速度mm/s";
            // 
            // LineVelocitySet
            // 
            this.LineVelocitySet.Location = new System.Drawing.Point(40, 165);
            this.LineVelocitySet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LineVelocitySet.Name = "LineVelocitySet";
            this.LineVelocitySet.Size = new System.Drawing.Size(135, 28);
            this.LineVelocitySet.TabIndex = 43;
            this.LineVelocitySet.TextChanged += new System.EventHandler(this.LineVelocitySet_TextChanged);
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.Location = new System.Drawing.Point(203, 137);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(143, 18);
            this.label79.TabIndex = 42;
            this.label79.Text = "直线加速度mm/s²";
            // 
            // LineACCSet
            // 
            this.LineACCSet.Location = new System.Drawing.Point(213, 172);
            this.LineACCSet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LineACCSet.Name = "LineACCSet";
            this.LineACCSet.Size = new System.Drawing.Size(135, 28);
            this.LineACCSet.TabIndex = 41;
            this.LineACCSet.TextChanged += new System.EventHandler(this.LineACCSet_TextChanged);
            // 
            // label80
            // 
            this.label80.AutoSize = true;
            this.label80.Location = new System.Drawing.Point(207, 45);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(134, 18);
            this.label80.TabIndex = 34;
            this.label80.Text = "加工坐标系Y/mm";
            // 
            // WorkY
            // 
            this.WorkY.Location = new System.Drawing.Point(213, 80);
            this.WorkY.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.WorkY.Name = "WorkY";
            this.WorkY.Size = new System.Drawing.Size(135, 28);
            this.WorkY.TabIndex = 33;
            this.WorkY.TextChanged += new System.EventHandler(this.WorkY_TextChanged);
            // 
            // label81
            // 
            this.label81.AutoSize = true;
            this.label81.Location = new System.Drawing.Point(34, 45);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(134, 18);
            this.label81.TabIndex = 32;
            this.label81.Text = "加工坐标系X/mm\r\n";
            // 
            // WorkX
            // 
            this.WorkX.Location = new System.Drawing.Point(40, 80);
            this.WorkX.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.WorkX.Name = "WorkX";
            this.WorkX.Size = new System.Drawing.Size(135, 28);
            this.WorkX.TabIndex = 31;
            this.WorkX.TextChanged += new System.EventHandler(this.WorkX_TextChanged);
            // 
            // groupBox22
            // 
            this.groupBox22.Controls.Add(this.label69);
            this.groupBox22.Controls.Add(this.label70);
            this.groupBox22.Controls.Add(this.RtcOrgDistanceY);
            this.groupBox22.Controls.Add(this.label71);
            this.groupBox22.Controls.Add(this.Set_txt_valueK);
            this.groupBox22.Controls.Add(this.RtcOrgDistanceX);
            this.groupBox22.Location = new System.Drawing.Point(29, 370);
            this.groupBox22.Name = "groupBox22";
            this.groupBox22.Size = new System.Drawing.Size(650, 128);
            this.groupBox22.TabIndex = 108;
            this.groupBox22.TabStop = false;
            this.groupBox22.Text = "偏差矫正";
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Location = new System.Drawing.Point(437, 36);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(179, 18);
            this.label69.TabIndex = 97;
            this.label69.Text = "振镜与ORG 距离 Y/mm";
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Location = new System.Drawing.Point(38, 36);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(152, 18);
            this.label70.TabIndex = 5;
            this.label70.Text = "像素K值 mm/pixel";
            // 
            // RtcOrgDistanceY
            // 
            this.RtcOrgDistanceY.Location = new System.Drawing.Point(459, 69);
            this.RtcOrgDistanceY.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RtcOrgDistanceY.Name = "RtcOrgDistanceY";
            this.RtcOrgDistanceY.Size = new System.Drawing.Size(150, 28);
            this.RtcOrgDistanceY.TabIndex = 96;
            this.RtcOrgDistanceY.TextChanged += new System.EventHandler(this.RtcOrgDistanceY_TextChanged);
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Location = new System.Drawing.Point(217, 36);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(179, 18);
            this.label71.TabIndex = 95;
            this.label71.Text = "振镜与ORG 距离 X/mm";
            // 
            // Set_txt_valueK
            // 
            this.Set_txt_valueK.Location = new System.Drawing.Point(40, 69);
            this.Set_txt_valueK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Set_txt_valueK.Name = "Set_txt_valueK";
            this.Set_txt_valueK.Size = new System.Drawing.Size(150, 28);
            this.Set_txt_valueK.TabIndex = 1;
            this.Set_txt_valueK.TextChanged += new System.EventHandler(this.Set_txt_valueK_TextChanged);
            // 
            // RtcOrgDistanceX
            // 
            this.RtcOrgDistanceX.Location = new System.Drawing.Point(246, 69);
            this.RtcOrgDistanceX.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RtcOrgDistanceX.Name = "RtcOrgDistanceX";
            this.RtcOrgDistanceX.Size = new System.Drawing.Size(150, 28);
            this.RtcOrgDistanceX.TabIndex = 94;
            this.RtcOrgDistanceX.TextChanged += new System.EventHandler(this.RtcOrgDistanceX_TextChanged);
            // 
            // Mark_Group
            // 
            this.Mark_Group.Controls.Add(this.GoMark4);
            this.Mark_Group.Controls.Add(this.Set_txt_markY4);
            this.Mark_Group.Controls.Add(this.Set_txt_markX4);
            this.Mark_Group.Controls.Add(this.label63);
            this.Mark_Group.Controls.Add(this.GoMark3);
            this.Mark_Group.Controls.Add(this.GoMark2);
            this.Mark_Group.Controls.Add(this.GoMark1);
            this.Mark_Group.Controls.Add(this.Set_txt_markX1);
            this.Mark_Group.Controls.Add(this.Set_txt_markY3);
            this.Mark_Group.Controls.Add(this.label64);
            this.Mark_Group.Controls.Add(this.Set_txt_markX3);
            this.Mark_Group.Controls.Add(this.label65);
            this.Mark_Group.Controls.Add(this.Set_txt_markY2);
            this.Mark_Group.Controls.Add(this.label66);
            this.Mark_Group.Controls.Add(this.Set_txt_markX2);
            this.Mark_Group.Controls.Add(this.label67);
            this.Mark_Group.Controls.Add(this.Set_txt_markY1);
            this.Mark_Group.Controls.Add(this.label68);
            this.Mark_Group.Location = new System.Drawing.Point(29, 31);
            this.Mark_Group.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Mark_Group.Name = "Mark_Group";
            this.Mark_Group.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Mark_Group.Size = new System.Drawing.Size(650, 303);
            this.Mark_Group.TabIndex = 107;
            this.Mark_Group.TabStop = false;
            this.Mark_Group.Text = "Mark参数";
            // 
            // GoMark4
            // 
            this.GoMark4.Location = new System.Drawing.Point(545, 238);
            this.GoMark4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GoMark4.Name = "GoMark4";
            this.GoMark4.Size = new System.Drawing.Size(91, 40);
            this.GoMark4.TabIndex = 11;
            this.GoMark4.Text = "定位";
            this.GoMark4.UseVisualStyleBackColor = true;
            this.GoMark4.Click += new System.EventHandler(this.GoMark4_Click);
            // 
            // Set_txt_markY4
            // 
            this.Set_txt_markY4.Location = new System.Drawing.Point(367, 244);
            this.Set_txt_markY4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Set_txt_markY4.Name = "Set_txt_markY4";
            this.Set_txt_markY4.Size = new System.Drawing.Size(148, 28);
            this.Set_txt_markY4.TabIndex = 9;
            this.Set_txt_markY4.TextChanged += new System.EventHandler(this.Set_txt_markY4_TextChanged);
            // 
            // Set_txt_markX4
            // 
            this.Set_txt_markX4.Location = new System.Drawing.Point(169, 244);
            this.Set_txt_markX4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Set_txt_markX4.Name = "Set_txt_markX4";
            this.Set_txt_markX4.Size = new System.Drawing.Size(148, 28);
            this.Set_txt_markX4.TabIndex = 10;
            this.Set_txt_markX4.TextChanged += new System.EventHandler(this.Set_txt_markX4_TextChanged);
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(15, 249);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(152, 18);
            this.label63.TabIndex = 8;
            this.label63.Text = "Mark 点4（右下）";
            // 
            // GoMark3
            // 
            this.GoMark3.Location = new System.Drawing.Point(544, 177);
            this.GoMark3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GoMark3.Name = "GoMark3";
            this.GoMark3.Size = new System.Drawing.Size(91, 40);
            this.GoMark3.TabIndex = 7;
            this.GoMark3.Text = "定位";
            this.GoMark3.UseVisualStyleBackColor = true;
            this.GoMark3.Click += new System.EventHandler(this.GoMark3_Click);
            // 
            // GoMark2
            // 
            this.GoMark2.Location = new System.Drawing.Point(544, 116);
            this.GoMark2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GoMark2.Name = "GoMark2";
            this.GoMark2.Size = new System.Drawing.Size(91, 40);
            this.GoMark2.TabIndex = 6;
            this.GoMark2.Text = "定位";
            this.GoMark2.UseVisualStyleBackColor = true;
            this.GoMark2.Click += new System.EventHandler(this.GoMark2_Click);
            // 
            // GoMark1
            // 
            this.GoMark1.Location = new System.Drawing.Point(544, 55);
            this.GoMark1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GoMark1.Name = "GoMark1";
            this.GoMark1.Size = new System.Drawing.Size(91, 40);
            this.GoMark1.TabIndex = 5;
            this.GoMark1.Text = "定位";
            this.GoMark1.UseVisualStyleBackColor = true;
            this.GoMark1.Click += new System.EventHandler(this.GoMark1_Click);
            // 
            // Set_txt_markX1
            // 
            this.Set_txt_markX1.Location = new System.Drawing.Point(168, 61);
            this.Set_txt_markX1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Set_txt_markX1.Name = "Set_txt_markX1";
            this.Set_txt_markX1.Size = new System.Drawing.Size(148, 28);
            this.Set_txt_markX1.TabIndex = 3;
            this.Set_txt_markX1.TextChanged += new System.EventHandler(this.Set_txt_markX1_TextChanged);
            // 
            // Set_txt_markY3
            // 
            this.Set_txt_markY3.Location = new System.Drawing.Point(366, 183);
            this.Set_txt_markY3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Set_txt_markY3.Name = "Set_txt_markY3";
            this.Set_txt_markY3.Size = new System.Drawing.Size(148, 28);
            this.Set_txt_markY3.TabIndex = 3;
            this.Set_txt_markY3.TextChanged += new System.EventHandler(this.Set_txt_markY3_TextChanged);
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(14, 66);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(152, 18);
            this.label64.TabIndex = 2;
            this.label64.Text = "Mark 点1（左下）";
            // 
            // Set_txt_markX3
            // 
            this.Set_txt_markX3.Location = new System.Drawing.Point(168, 183);
            this.Set_txt_markX3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Set_txt_markX3.Name = "Set_txt_markX3";
            this.Set_txt_markX3.Size = new System.Drawing.Size(148, 28);
            this.Set_txt_markX3.TabIndex = 3;
            this.Set_txt_markX3.TextChanged += new System.EventHandler(this.Set_txt_markX3_TextChanged);
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(231, 30);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(26, 18);
            this.label65.TabIndex = 2;
            this.label65.Text = "X ";
            // 
            // Set_txt_markY2
            // 
            this.Set_txt_markY2.Location = new System.Drawing.Point(366, 122);
            this.Set_txt_markY2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Set_txt_markY2.Name = "Set_txt_markY2";
            this.Set_txt_markY2.Size = new System.Drawing.Size(148, 28);
            this.Set_txt_markY2.TabIndex = 3;
            this.Set_txt_markY2.TextChanged += new System.EventHandler(this.Set_txt_markY2_TextChanged);
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Location = new System.Drawing.Point(433, 30);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(17, 18);
            this.label66.TabIndex = 2;
            this.label66.Text = "Y";
            // 
            // Set_txt_markX2
            // 
            this.Set_txt_markX2.Location = new System.Drawing.Point(168, 122);
            this.Set_txt_markX2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Set_txt_markX2.Name = "Set_txt_markX2";
            this.Set_txt_markX2.Size = new System.Drawing.Size(148, 28);
            this.Set_txt_markX2.TabIndex = 3;
            this.Set_txt_markX2.TextChanged += new System.EventHandler(this.Set_txt_markX2_TextChanged);
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Location = new System.Drawing.Point(14, 127);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(152, 18);
            this.label67.TabIndex = 2;
            this.label67.Text = "Mark 点2（左上）";
            // 
            // Set_txt_markY1
            // 
            this.Set_txt_markY1.Location = new System.Drawing.Point(366, 61);
            this.Set_txt_markY1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Set_txt_markY1.Name = "Set_txt_markY1";
            this.Set_txt_markY1.Size = new System.Drawing.Size(148, 28);
            this.Set_txt_markY1.TabIndex = 3;
            this.Set_txt_markY1.TextChanged += new System.EventHandler(this.Set_txt_markY1_TextChanged);
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Location = new System.Drawing.Point(14, 188);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(152, 18);
            this.label68.TabIndex = 2;
            this.label68.Text = "Mark 点3（右上）";
            // 
            // ScissorList
            // 
            this.ScissorList.Caption = "刀具参数列表";
            this.ScissorList.Controls.Add(this.ScissorListView);
            this.ScissorList.Controls.Add(this.groupBox24);
            this.ScissorList.Name = "ScissorList";
            this.ScissorList.Size = new System.Drawing.Size(1356, 651);
            // 
            // ScissorListView
            // 
            this.ScissorListView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.ScissorListView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ScissorListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScissorListView.Location = new System.Drawing.Point(0, 0);
            this.ScissorListView.Name = "ScissorListView";
            this.ScissorListView.RowHeadersVisible = false;
            this.ScissorListView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.ScissorListView.RowTemplate.Height = 30;
            this.ScissorListView.Size = new System.Drawing.Size(1356, 566);
            this.ScissorListView.TabIndex = 0;
            // 
            // groupBox24
            // 
            this.groupBox24.Controls.Add(this.ScissorListLoad);
            this.groupBox24.Controls.Add(this.ScissorListSave);
            this.groupBox24.Controls.Add(this.label72);
            this.groupBox24.Controls.Add(this.Scissor_List);
            this.groupBox24.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox24.Location = new System.Drawing.Point(0, 566);
            this.groupBox24.Name = "groupBox24";
            this.groupBox24.Size = new System.Drawing.Size(1356, 85);
            this.groupBox24.TabIndex = 1;
            this.groupBox24.TabStop = false;
            // 
            // ScissorListLoad
            // 
            this.ScissorListLoad.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScissorListLoad.Location = new System.Drawing.Point(733, 21);
            this.ScissorListLoad.Name = "ScissorListLoad";
            this.ScissorListLoad.Size = new System.Drawing.Size(188, 51);
            this.ScissorListLoad.TabIndex = 6;
            this.ScissorListLoad.TabStop = false;
            this.ScissorListLoad.Text = "刀具参数读取";
            this.ScissorListLoad.UseVisualStyleBackColor = true;
            this.ScissorListLoad.Click += new System.EventHandler(this.ScissorListLoad_Click);
            // 
            // ScissorListSave
            // 
            this.ScissorListSave.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScissorListSave.Location = new System.Drawing.Point(497, 21);
            this.ScissorListSave.Name = "ScissorListSave";
            this.ScissorListSave.Size = new System.Drawing.Size(188, 51);
            this.ScissorListSave.TabIndex = 5;
            this.ScissorListSave.TabStop = false;
            this.ScissorListSave.Text = "刀具参数保存";
            this.ScissorListSave.UseVisualStyleBackColor = true;
            this.ScissorListSave.Click += new System.EventHandler(this.ScissorListSave_Click);
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label72.Location = new System.Drawing.Point(18, 34);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(130, 24);
            this.label72.TabIndex = 4;
            this.label72.Text = "刀具选择：";
            // 
            // Scissor_List
            // 
            this.Scissor_List.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Scissor_List.FormattingEnabled = true;
            this.Scissor_List.Items.AddRange(new object[] {
            "钻孔刀具列表",
            "圆弧刀具列表",
            "折线刀具列表"});
            this.Scissor_List.Location = new System.Drawing.Point(185, 30);
            this.Scissor_List.Name = "Scissor_List";
            this.Scissor_List.Size = new System.Drawing.Size(198, 32);
            this.Scissor_List.TabIndex = 3;
            this.Scissor_List.SelectedIndexChanged += new System.EventHandler(this.Scissor_List_SelectedIndexChanged);
            // 
            // RePeatList
            // 
            this.RePeatList.Caption = "重复参数列表";
            this.RePeatList.Controls.Add(this.RepeatListView);
            this.RePeatList.Controls.Add(this.groupBox25);
            this.RePeatList.Name = "RePeatList";
            this.RePeatList.Size = new System.Drawing.Size(1356, 651);
            // 
            // RepeatListView
            // 
            this.RepeatListView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.RepeatListView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.RepeatListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RepeatListView.Location = new System.Drawing.Point(0, 0);
            this.RepeatListView.Name = "RepeatListView";
            this.RepeatListView.RowHeadersVisible = false;
            this.RepeatListView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.RepeatListView.RowTemplate.Height = 30;
            this.RepeatListView.Size = new System.Drawing.Size(1356, 558);
            this.RepeatListView.TabIndex = 0;
            // 
            // groupBox25
            // 
            this.groupBox25.Controls.Add(this.RepeatListSaveLoad);
            this.groupBox25.Controls.Add(this.label83);
            this.groupBox25.Controls.Add(this.Repeat_Times_UpDown);
            this.groupBox25.Controls.Add(this.RepeatListSave);
            this.groupBox25.Controls.Add(this.label82);
            this.groupBox25.Controls.Add(this.Repeat_List);
            this.groupBox25.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox25.Location = new System.Drawing.Point(0, 558);
            this.groupBox25.Name = "groupBox25";
            this.groupBox25.Size = new System.Drawing.Size(1356, 93);
            this.groupBox25.TabIndex = 2;
            this.groupBox25.TabStop = false;
            // 
            // RepeatListSaveLoad
            // 
            this.RepeatListSaveLoad.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RepeatListSaveLoad.Location = new System.Drawing.Point(1023, 27);
            this.RepeatListSaveLoad.Name = "RepeatListSaveLoad";
            this.RepeatListSaveLoad.Size = new System.Drawing.Size(226, 51);
            this.RepeatListSaveLoad.TabIndex = 8;
            this.RepeatListSaveLoad.TabStop = false;
            this.RepeatListSaveLoad.Text = "Repeat参数读取";
            this.RepeatListSaveLoad.UseVisualStyleBackColor = true;
            this.RepeatListSaveLoad.Click += new System.EventHandler(this.RepeatListSaveLoad_Click);
            // 
            // label83
            // 
            this.label83.AutoSize = true;
            this.label83.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label83.Location = new System.Drawing.Point(448, 40);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(130, 24);
            this.label83.TabIndex = 7;
            this.label83.Text = "加工次数：";
            // 
            // Repeat_Times_UpDown
            // 
            this.Repeat_Times_UpDown.Location = new System.Drawing.Point(584, 38);
            this.Repeat_Times_UpDown.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.Repeat_Times_UpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Repeat_Times_UpDown.Name = "Repeat_Times_UpDown";
            this.Repeat_Times_UpDown.Size = new System.Drawing.Size(78, 28);
            this.Repeat_Times_UpDown.TabIndex = 6;
            this.Repeat_Times_UpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Repeat_Times_UpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Repeat_Times_UpDown.ValueChanged += new System.EventHandler(this.Repeat_Times_UpDown_ValueChanged);
            // 
            // RepeatListSave
            // 
            this.RepeatListSave.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RepeatListSave.Location = new System.Drawing.Point(744, 27);
            this.RepeatListSave.Name = "RepeatListSave";
            this.RepeatListSave.Size = new System.Drawing.Size(226, 51);
            this.RepeatListSave.TabIndex = 5;
            this.RepeatListSave.TabStop = false;
            this.RepeatListSave.Text = "Repeat参数保存";
            this.RepeatListSave.UseVisualStyleBackColor = true;
            this.RepeatListSave.Click += new System.EventHandler(this.RepeatListSave_Click);
            // 
            // label82
            // 
            this.label82.AutoSize = true;
            this.label82.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label82.Location = new System.Drawing.Point(18, 40);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(130, 24);
            this.label82.TabIndex = 4;
            this.label82.Text = "类型选择：";
            // 
            // Repeat_List
            // 
            this.Repeat_List.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Repeat_List.FormattingEnabled = true;
            this.Repeat_List.Items.AddRange(new object[] {
            "钻孔刀具列表",
            "圆弧刀具列表",
            "折线刀具列表"});
            this.Repeat_List.Location = new System.Drawing.Point(185, 36);
            this.Repeat_List.Name = "Repeat_List";
            this.Repeat_List.Size = new System.Drawing.Size(198, 32);
            this.Repeat_List.TabIndex = 3;
            this.Repeat_List.SelectedIndexChanged += new System.EventHandler(this.Repeat_List_SelectedIndexChanged);
            // 
            // CameraPara
            // 
            this.CameraPara.Caption = "相机参数";
            this.CameraPara.Controls.Add(this.groupBox28);
            this.CameraPara.Controls.Add(this.label62);
            this.CameraPara.Controls.Add(this.Mark_Type_List);
            this.CameraPara.Controls.Add(this.groupBox21);
            this.CameraPara.Controls.Add(this.button1);
            this.CameraPara.Controls.Add(this.CamDisplay);
            this.CameraPara.Name = "CameraPara";
            this.CameraPara.Size = new System.Drawing.Size(1356, 651);
            // 
            // groupBox28
            // 
            this.groupBox28.Controls.Add(this.IlluminateText);
            this.groupBox28.Controls.Add(this.ExposureText);
            this.groupBox28.Controls.Add(this.SizeText);
            this.groupBox28.Controls.Add(this.ThreshHoldText);
            this.groupBox28.Controls.Add(this.label92);
            this.groupBox28.Controls.Add(this.label91);
            this.groupBox28.Controls.Add(this.label90);
            this.groupBox28.Controls.Add(this.label89);
            this.groupBox28.Location = new System.Drawing.Point(47, 255);
            this.groupBox28.Name = "groupBox28";
            this.groupBox28.Size = new System.Drawing.Size(650, 291);
            this.groupBox28.TabIndex = 138;
            this.groupBox28.TabStop = false;
            this.groupBox28.Text = "Mark参数";
            // 
            // IlluminateText
            // 
            this.IlluminateText.Location = new System.Drawing.Point(185, 216);
            this.IlluminateText.Name = "IlluminateText";
            this.IlluminateText.Size = new System.Drawing.Size(138, 28);
            this.IlluminateText.TabIndex = 147;
            // 
            // ExposureText
            // 
            this.ExposureText.Location = new System.Drawing.Point(185, 166);
            this.ExposureText.Name = "ExposureText";
            this.ExposureText.Size = new System.Drawing.Size(138, 28);
            this.ExposureText.TabIndex = 146;
            // 
            // SizeText
            // 
            this.SizeText.Location = new System.Drawing.Point(185, 116);
            this.SizeText.Name = "SizeText";
            this.SizeText.Size = new System.Drawing.Size(138, 28);
            this.SizeText.TabIndex = 145;
            // 
            // ThreshHoldText
            // 
            this.ThreshHoldText.Location = new System.Drawing.Point(185, 66);
            this.ThreshHoldText.Name = "ThreshHoldText";
            this.ThreshHoldText.Size = new System.Drawing.Size(138, 28);
            this.ThreshHoldText.TabIndex = 144;
            // 
            // label92
            // 
            this.label92.AutoSize = true;
            this.label92.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label92.Location = new System.Drawing.Point(38, 220);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(69, 20);
            this.label92.TabIndex = 143;
            this.label92.Text = "背光值";
            // 
            // label91
            // 
            this.label91.AutoSize = true;
            this.label91.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label91.Location = new System.Drawing.Point(38, 170);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(69, 20);
            this.label91.TabIndex = 142;
            this.label91.Text = "曝光值";
            // 
            // label90
            // 
            this.label90.AutoSize = true;
            this.label90.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label90.Location = new System.Drawing.Point(23, 120);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(99, 20);
            this.label90.TabIndex = 140;
            this.label90.Text = "面积/角度";
            // 
            // label89
            // 
            this.label89.AutoSize = true;
            this.label89.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label89.Location = new System.Drawing.Point(18, 70);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(109, 20);
            this.label89.TabIndex = 139;
            this.label89.Text = "二值化阈值";
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label62.Location = new System.Drawing.Point(178, 208);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(129, 20);
            this.label62.TabIndex = 137;
            this.label62.Text = "Mark类型选择";
            // 
            // Mark_Type_List
            // 
            this.Mark_Type_List.FormattingEnabled = true;
            this.Mark_Type_List.Items.AddRange(new object[] {
            "黑色圆白背景",
            "白色圆黑背景",
            "黑色矩形白背景",
            "黑色十字白背景"});
            this.Mark_Type_List.Location = new System.Drawing.Point(324, 204);
            this.Mark_Type_List.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Mark_Type_List.Name = "Mark_Type_List";
            this.Mark_Type_List.Size = new System.Drawing.Size(185, 26);
            this.Mark_Type_List.TabIndex = 136;
            this.Mark_Type_List.SelectedIndexChanged += new System.EventHandler(this.Mark_Type_List_SelectedIndexChanged);
            // 
            // groupBox21
            // 
            this.groupBox21.Controls.Add(this.label61);
            this.groupBox21.Controls.Add(this.IntrigueType);
            this.groupBox21.Controls.Add(this.Disconnect_Tcp);
            this.groupBox21.Controls.Add(this.IntrigueTakePicture);
            this.groupBox21.Controls.Add(this.Re_Connect);
            this.groupBox21.Location = new System.Drawing.Point(47, 43);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Size = new System.Drawing.Size(650, 121);
            this.groupBox21.TabIndex = 135;
            this.groupBox21.TabStop = false;
            this.groupBox21.Text = "相机操作";
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label61.Location = new System.Drawing.Point(300, 59);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(118, 24);
            this.label61.TabIndex = 104;
            this.label61.Text = "触发代码:";
            // 
            // IntrigueType
            // 
            this.IntrigueType.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.IntrigueType.Location = new System.Drawing.Point(425, 54);
            this.IntrigueType.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.IntrigueType.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.IntrigueType.Name = "IntrigueType";
            this.IntrigueType.Size = new System.Drawing.Size(48, 35);
            this.IntrigueType.TabIndex = 98;
            this.IntrigueType.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.IntrigueType.ValueChanged += new System.EventHandler(this.IntrigueType_ValueChanged);
            // 
            // Disconnect_Tcp
            // 
            this.Disconnect_Tcp.Location = new System.Drawing.Point(153, 45);
            this.Disconnect_Tcp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Disconnect_Tcp.Name = "Disconnect_Tcp";
            this.Disconnect_Tcp.Size = new System.Drawing.Size(109, 52);
            this.Disconnect_Tcp.TabIndex = 100;
            this.Disconnect_Tcp.Text = "断开相机";
            this.Disconnect_Tcp.UseVisualStyleBackColor = true;
            this.Disconnect_Tcp.Click += new System.EventHandler(this.Disconnect_Tcp_Click);
            // 
            // IntrigueTakePicture
            // 
            this.IntrigueTakePicture.Location = new System.Drawing.Point(503, 45);
            this.IntrigueTakePicture.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.IntrigueTakePicture.Name = "IntrigueTakePicture";
            this.IntrigueTakePicture.Size = new System.Drawing.Size(109, 52);
            this.IntrigueTakePicture.TabIndex = 8;
            this.IntrigueTakePicture.Text = "触发拍照";
            this.IntrigueTakePicture.UseVisualStyleBackColor = true;
            this.IntrigueTakePicture.Click += new System.EventHandler(this.IntrigueTakePicture_Click);
            // 
            // Re_Connect
            // 
            this.Re_Connect.Location = new System.Drawing.Point(20, 45);
            this.Re_Connect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Re_Connect.Name = "Re_Connect";
            this.Re_Connect.Size = new System.Drawing.Size(109, 52);
            this.Re_Connect.TabIndex = 99;
            this.Re_Connect.Text = "重连相机";
            this.Re_Connect.UseVisualStyleBackColor = true;
            this.Re_Connect.Click += new System.EventHandler(this.Re_Connect_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(944, 92);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 50);
            this.button1.TabIndex = 134;
            this.button1.Text = "图像处理";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CamDisplay
            // 
            this.CamDisplay.Location = new System.Drawing.Point(737, 92);
            this.CamDisplay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CamDisplay.Name = "CamDisplay";
            this.CamDisplay.Size = new System.Drawing.Size(154, 50);
            this.CamDisplay.TabIndex = 133;
            this.CamDisplay.Text = "相机视图显示";
            this.CamDisplay.UseVisualStyleBackColor = true;
            this.CamDisplay.Click += new System.EventHandler(this.CamDisplay_Click);
            // 
            // manualFormPag
            // 
            this.manualFormPag.ContentContainer = this.tabFormContentContainer4;
            this.manualFormPag.Name = "manualFormPag";
            this.manualFormPag.Text = "手动";
            // 
            // tabFormContentContainer4
            // 
            this.tabFormContentContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabFormContentContainer4.Location = new System.Drawing.Point(0, 70);
            this.tabFormContentContainer4.Name = "tabFormContentContainer4";
            this.tabFormContentContainer4.Size = new System.Drawing.Size(1356, 693);
            this.tabFormContentContainer4.TabIndex = 6;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 3;
            this.numericUpDown1.Increment = new decimal(new int[] {
            5,
            0,
            0,
            196608});
            this.numericUpDown1.Location = new System.Drawing.Point(59, 516);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 29);
            this.numericUpDown1.TabIndex = 162;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1356, 763);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Controls.Add(this.mainFormPageContainer);
            this.Controls.Add(this.tabFormControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "MainForm";
            this.TabFormControl = this.tabFormControl;
            this.Text = "激光切割机";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainView_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.tabFormControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabFormDefaultManager1)).EndInit();
            this.loginFormPageContainer.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Password_Input.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.User_List.Properties)).EndInit();
            this.mainFormPageContainer.ResumeLayout(false);
            this.groupBox27.ResumeLayout(false);
            this.groupBox26.ResumeLayout(false);
            this.groupBox26.PerformLayout();
            this.manualFormPageContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.manualTabPane)).EndInit();
            this.manualTabPane.ResumeLayout(false);
            this.gtsManual.ResumeLayout(false);
            this.gtsManual.PerformLayout();
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AxisSelect)).EndInit();
            this.rtcManual.ResumeLayout(false);
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.groupBox16.ResumeLayout(false);
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            this.groupBox19.ResumeLayout(false);
            this.groupBox19.PerformLayout();
            this.groupBox20.ResumeLayout(false);
            this.groupBox20.PerformLayout();
            this.IOOperate.ResumeLayout(false);
            this.statusFormPageContainer.ResumeLayout(false);
            this.statusFormPageContainer.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.laserFormPageContainer.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LW_Com_Status)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LC_Com_Status)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.setFormPageContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.setTabPane)).EndInit();
            this.setTabPane.ResumeLayout(false);
            this.paraSet.ResumeLayout(false);
            this.groupBox23.ResumeLayout(false);
            this.groupBox23.PerformLayout();
            this.groupBox22.ResumeLayout(false);
            this.groupBox22.PerformLayout();
            this.Mark_Group.ResumeLayout(false);
            this.Mark_Group.PerformLayout();
            this.ScissorList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ScissorListView)).EndInit();
            this.groupBox24.ResumeLayout(false);
            this.groupBox24.PerformLayout();
            this.RePeatList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RepeatListView)).EndInit();
            this.groupBox25.ResumeLayout(false);
            this.groupBox25.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Repeat_Times_UpDown)).EndInit();
            this.CameraPara.ResumeLayout(false);
            this.CameraPara.PerformLayout();
            this.groupBox28.ResumeLayout(false);
            this.groupBox28.PerformLayout();
            this.groupBox21.ResumeLayout(false);
            this.groupBox21.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IntrigueType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.TabFormControl tabFormControl;
        private DevExpress.XtraBars.TabFormDefaultManager tabFormDefaultManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.TabFormContentContainer loginFormPageContainer;
        private DevExpress.XtraBars.TabFormPage LoginFormPage;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.SimpleButton Cancel_Button;
        private DevExpress.XtraEditors.SimpleButton Confirm_Button;
        private DevExpress.XtraEditors.TextEdit Password_Input;
        private DevExpress.XtraEditors.ComboBoxEdit User_List;
        private DevExpress.XtraEditors.LabelControl User_Password;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl User_Name;
        private DevExpress.XtraBars.TabFormContentContainer setFormPageContainer;
        private DevExpress.XtraBars.TabFormPage workFormPage;
        private DevExpress.XtraBars.TabFormContentContainer mainFormPageContainer;
        private DevExpress.XtraBars.TabFormPage setFormPage;
        private DevExpress.XtraBars.BarHeaderItem barUserIndicate;
        private DevExpress.XtraBars.TabFormPage statusFormPage;
        private DevExpress.XtraBars.TabFormContentContainer statusFormPageContainer;
        private DevExpress.XtraBars.TabFormPage laserFormPage;
        private DevExpress.XtraBars.TabFormContentContainer laserFormPageContainer;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button EXO10_Status;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button EXO9_Status;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button EXO8_Status;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button EXO7_Status;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button EXO6_Status;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button EXO5_Status;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button EXO4_Status;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button EXO3_Status;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button EXO2_Status;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button EXO1_Status;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button Homed_Status;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button EXI7_Status;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button EXI6_Status;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button EXI5_Status;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button EXI4_Status;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button EXI3_Status;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button EXI2_Status;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button EXI1_Status;
        private DevExpress.XtraBars.TabFormPage manualFormPag;
        private DevExpress.XtraBars.TabFormContentContainer tabFormContentContainer4;
        private DevExpress.XtraBars.Navigation.TabPane setTabPane;
        private DevExpress.XtraBars.Navigation.TabNavigationPage paraSet;
        private DevExpress.XtraBars.Navigation.TabNavigationPage ScissorList;
        private DevExpress.XtraBars.Navigation.TabNavigationPage RePeatList;
        private DevExpress.XtraBars.TabFormContentContainer manualFormPageContainer;
        private DevExpress.XtraBars.TabFormPage manualFormPage;
        private System.Windows.Forms.GroupBox groupBox7;
        public System.Windows.Forms.Button LC_Refresh_List;
        public System.Windows.Forms.GroupBox groupBox4;
        public System.Windows.Forms.TextBox LC_Amp2_Set;
        public System.Windows.Forms.Button LC_PRF_Confirm;
        public System.Windows.Forms.Label label21;
        public System.Windows.Forms.Button LC_PEC_Confirm;
        public System.Windows.Forms.TextBox LC_Amp1_Set;
        public System.Windows.Forms.TextBox LC_PRF_Set_Value;
        public System.Windows.Forms.Label label22;
        public System.Windows.Forms.Label label23;
        public System.Windows.Forms.TextBox LC_Seed_Set;
        public System.Windows.Forms.TextBox LC_PEC_Set_Value;
        public System.Windows.Forms.Label label24;
        public System.Windows.Forms.Label label25;
        public System.Windows.Forms.PictureBox LC_Com_Status;
        public System.Windows.Forms.Button LC_Re_connect;
        public System.Windows.Forms.ComboBox LC_Com_List;
        public System.Windows.Forms.RichTextBox LC_Status;
        public System.Windows.Forms.GroupBox groupBox5;
        public System.Windows.Forms.Label label26;
        public System.Windows.Forms.Button LC_Reset_Laser;
        public System.Windows.Forms.Button LC_Refresh_Status;
        public System.Windows.Forms.GroupBox groupBox6;
        public System.Windows.Forms.TextBox LC_Amp2_Current;
        public System.Windows.Forms.Label label27;
        public System.Windows.Forms.TextBox LC_Amp1_Current;
        public System.Windows.Forms.Label label28;
        public System.Windows.Forms.TextBox LC_Seed_Current;
        public System.Windows.Forms.Label label29;
        public System.Windows.Forms.Label label30;
        public System.Windows.Forms.Button LC_Power_OFF;
        public System.Windows.Forms.Button LC_Power_On;
        public System.Windows.Forms.GroupBox groupBox10;
        public System.Windows.Forms.GroupBox groupBox9;
        public System.Windows.Forms.Button LW_Re_Connect;
        public System.Windows.Forms.Button LW_Refresh_List;
        public System.Windows.Forms.ComboBox LW_Com_List;
        public System.Windows.Forms.PictureBox LW_Com_Status;
        public System.Windows.Forms.Button LW_Save_Data;
        public System.Windows.Forms.Button LW_Acquisition_Once;
        public System.Windows.Forms.Label Laser_Current_Watt_Label;
        public System.Windows.Forms.Label Laser_Percent_Label;
        public System.Windows.Forms.TextBox LW_PEC_Indicate;
        public System.Windows.Forms.TextBox LW_Watt_Indicate;
        public System.Windows.Forms.GroupBox groupBox8;
        private DevExpress.XtraBars.Navigation.TabPane manualTabPane;
        private DevExpress.XtraBars.Navigation.TabNavigationPage gtsManual;
        private DevExpress.XtraBars.Navigation.TabNavigationPage rtcManual;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.Button Upper_Posed;
        private System.Windows.Forms.Button Motor_Posed;
        private System.Windows.Forms.Button GtsReset;
        private System.Windows.Forms.Button MechanicHome;
        private System.Windows.Forms.Button BoardAlarm;
        private System.Windows.Forms.Button DriveBusy;
        private System.Windows.Forms.Label ActualMode;
        private System.Windows.Forms.Button EmgStop;
        private System.Windows.Forms.Label ActualSpeed;
        private System.Windows.Forms.Label ActualDCC;
        private System.Windows.Forms.Button SmoothStop;
        private System.Windows.Forms.Label ActualACC;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.Button JogDot;
        private System.Windows.Forms.TextBox ManualSpeed;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Button ServoON;
        private System.Windows.Forms.Button PosClear;
        private System.Windows.Forms.Button StatusClear;
        private System.Windows.Forms.TextBox ManualStep;
        private System.Windows.Forms.Button AlarmClear;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Button DriverAlarm;
        private System.Windows.Forms.TextBox ManualDCC;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.TextBox ManualACC;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Label ActualPos;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label CurrentPos;
        private System.Windows.Forms.Button JogNegative;
        private System.Windows.Forms.Button JogPositive;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Button NegativeLimit;
        private System.Windows.Forms.Button HomeSensor;
        private System.Windows.Forms.Button PositveLimit;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.NumericUpDown AxisSelect;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.TextBox HomeSmoothTime;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.TextBox HomeDCC;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.TextBox HomeACC;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.TextBox HomeSpeed;
        private System.Windows.Forms.TextBox HomeDeviation;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.GroupBox groupBox15;
        private System.Windows.Forms.Button Reset_Rtc;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox RtcPosReference;
        private System.Windows.Forms.GroupBox groupBox16;
        private System.Windows.Forms.Button LaserOFF;
        private System.Windows.Forms.Button LaserON;
        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.Button MoveMode;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox MoveY;
        private System.Windows.Forms.TextBox MoveX;
        private System.Windows.Forms.Button RtcYJogNegative;
        private System.Windows.Forms.Button RtcYJogPositive;
        private System.Windows.Forms.Button RtcXJogNegative;
        private System.Windows.Forms.Button RtcXJogPositive;
        private System.Windows.Forms.GroupBox groupBox18;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TextBox Polygon_Delay;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.TextBox Jump_Delay;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.TextBox Mark_Delay;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.TextBox Laser_Off_Delay;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.TextBox Jump_Speed;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.TextBox Laser_ON_Delay;
        private System.Windows.Forms.Button Change_Para_List;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.TextBox Mark_Speed;
        private System.Windows.Forms.GroupBox groupBox19;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.TextBox ABSPosY;
        private System.Windows.Forms.TextBox ABSPosX;
        private System.Windows.Forms.Button ABSPos;
        private System.Windows.Forms.GroupBox groupBox20;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.TextBox RtcHomeY;
        private System.Windows.Forms.TextBox RtcHomeX;
        private System.Windows.Forms.Button RtcHome;
        private System.Windows.Forms.GroupBox Mark_Group;
        private System.Windows.Forms.Button GoMark4;
        private System.Windows.Forms.TextBox Set_txt_markY4;
        private System.Windows.Forms.TextBox Set_txt_markX4;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.Button GoMark3;
        private System.Windows.Forms.Button GoMark2;
        private System.Windows.Forms.Button GoMark1;
        private System.Windows.Forms.TextBox Set_txt_markX1;
        private System.Windows.Forms.TextBox Set_txt_markY3;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.TextBox Set_txt_markX3;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.TextBox Set_txt_markY2;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.TextBox Set_txt_markX2;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.TextBox Set_txt_markY1;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.GroupBox groupBox22;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.TextBox RtcOrgDistanceY;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.TextBox Set_txt_valueK;
        private System.Windows.Forms.TextBox RtcOrgDistanceX;
        private System.Windows.Forms.GroupBox groupBox23;
        private System.Windows.Forms.Button SyaParaRead;
        private System.Windows.Forms.Button SysParaSave;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.TextBox ArcEndVelocitySet;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.TextBox LineEndVelocitySet;
        private System.Windows.Forms.Label label75;
        private System.Windows.Forms.TextBox SmoothTimeSet;
        private System.Windows.Forms.Label label76;
        private System.Windows.Forms.TextBox ArcACCSet;
        private System.Windows.Forms.Label label77;
        private System.Windows.Forms.TextBox ArcVelocitySet;
        private System.Windows.Forms.Label label78;
        private System.Windows.Forms.TextBox LineVelocitySet;
        private System.Windows.Forms.Label label79;
        private System.Windows.Forms.TextBox LineACCSet;
        private System.Windows.Forms.Label label80;
        private System.Windows.Forms.TextBox WorkY;
        private System.Windows.Forms.Label label81;
        private System.Windows.Forms.TextBox WorkX;
        private System.Windows.Forms.DataGridView ScissorListView;
        private System.Windows.Forms.DataGridView RepeatListView;
        private System.Windows.Forms.GroupBox groupBox24;
        private System.Windows.Forms.Button ScissorListSave;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.ComboBox Scissor_List;
        private System.Windows.Forms.GroupBox groupBox25;
        private System.Windows.Forms.Button RepeatListSave;
        private System.Windows.Forms.Label label82;
        private System.Windows.Forms.ComboBox Repeat_List;
        private System.Windows.Forms.Label label83;
        private System.Windows.Forms.NumericUpDown Repeat_Times_UpDown;
        private DevExpress.XtraBars.Navigation.TabNavigationPage IOOperate;
        private System.Windows.Forms.Button Buzzer;
        private System.Windows.Forms.Button BeaconRed;
        private System.Windows.Forms.Button BeaconGreen;
        private System.Windows.Forms.Button BeaconYellow;
        private System.Windows.Forms.Button Blow;
        private System.Windows.Forms.Button Cylinder;
        private System.Windows.Forms.Button Lamp;
        private System.Windows.Forms.Label label88;
        private System.Windows.Forms.ComboBox Start_Pos_Sel;
        private System.Windows.Forms.Button GoPoint;
        private System.Windows.Forms.Label label86;
        private System.Windows.Forms.TextBox BackY;
        private System.Windows.Forms.Label label87;
        private System.Windows.Forms.TextBox BackX;
        private System.Windows.Forms.Label label84;
        private System.Windows.Forms.ComboBox Back_Pos_Select;
        private System.Windows.Forms.Label label85;
        private System.Windows.Forms.ComboBox Work_Type_Select_List;
        private System.Windows.Forms.Button Cam_Work_Stop;
        private System.Windows.Forms.Button Cam_Work_Start;
        private System.Windows.Forms.Button GetFileName;
        private System.Windows.Forms.Button EstablishCoordinate;
        private System.Windows.Forms.Button AxisHome;
        private System.Windows.Forms.RichTextBox Debug_Info_Display;
        private System.Windows.Forms.GroupBox groupBox27;
        private System.Windows.Forms.GroupBox groupBox26;
        private System.Windows.Forms.Button AutoDelaySwitch;
        private System.Windows.Forms.Button ScissorListLoad;
        private System.Windows.Forms.Button RepeatListSaveLoad;
        private DevExpress.XtraBars.Navigation.TabNavigationPage CameraPara;
        private System.Windows.Forms.GroupBox groupBox21;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.NumericUpDown IntrigueType;
        private System.Windows.Forms.Button Disconnect_Tcp;
        private System.Windows.Forms.Button IntrigueTakePicture;
        private System.Windows.Forms.Button Re_Connect;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button CamDisplay;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.ComboBox Mark_Type_List;
        private System.Windows.Forms.GroupBox groupBox28;
        private System.Windows.Forms.TextBox IlluminateText;
        private System.Windows.Forms.TextBox ExposureText;
        private System.Windows.Forms.TextBox SizeText;
        private System.Windows.Forms.TextBox ThreshHoldText;
        private System.Windows.Forms.Label label92;
        private System.Windows.Forms.Label label91;
        private System.Windows.Forms.Label label90;
        private System.Windows.Forms.Label label89;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
    
}


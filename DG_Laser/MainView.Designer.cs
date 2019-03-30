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
            this.components = new System.ComponentModel.Container();
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
            this.MainFormDebuggroupBox = new System.Windows.Forms.GroupBox();
            this.label85 = new System.Windows.Forms.Label();
            this.Work_Type_Select_List = new System.Windows.Forms.ComboBox();
            this.PointListConfiggroupBox = new System.Windows.Forms.GroupBox();
            this.label99 = new System.Windows.Forms.Label();
            this.PointListSelectcomboBox = new System.Windows.Forms.ComboBox();
            this.GoPointListbutton = new System.Windows.Forms.Button();
            this.SetPointListbutton = new System.Windows.Forms.Button();
            this.label98 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.PointListYnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.PointListXnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.ResetEquipment = new System.Windows.Forms.Button();
            this.PlantFormpictureBox = new System.Windows.Forms.PictureBox();
            this.EmgStopButton = new System.Windows.Forms.Button();
            this.PlatFormShiftgroupBox = new System.Windows.Forms.GroupBox();
            this.GoMousePosbutton = new System.Windows.Forms.Button();
            this.SwitchToCambutton = new System.Windows.Forms.Button();
            this.MainCoordinateJogDistance = new System.Windows.Forms.NumericUpDown();
            this.MainYJogNegative = new System.Windows.Forms.Button();
            this.MainYJogPositive = new System.Windows.Forms.Button();
            this.MainXJogPositive = new System.Windows.Forms.Button();
            this.MainXJogNegative = new System.Windows.Forms.Button();
            this.ProjectgroupBox = new System.Windows.Forms.GroupBox();
            this.CamConfigbutton = new System.Windows.Forms.Button();
            this.MaterialManagebutton = new System.Windows.Forms.Button();
            this.MarKCoordinateConfig = new System.Windows.Forms.Button();
            this.ConfigProject = new System.Windows.Forms.Button();
            this.CloseProject = new System.Windows.Forms.Button();
            this.SaveProjectAs = new System.Windows.Forms.Button();
            this.SaveProject = new System.Windows.Forms.Button();
            this.ImportFile = new System.Windows.Forms.Button();
            this.OpenProject = new System.Windows.Forms.Button();
            this.CreateProject = new System.Windows.Forms.Button();
            this.WorkOperategroupBox = new System.Windows.Forms.GroupBox();
            this.LaserOperateButton = new System.Windows.Forms.Button();
            this.FileMarkStop = new System.Windows.Forms.Button();
            this.FileMarkRun = new System.Windows.Forms.Button();
            this.AxisHome = new System.Windows.Forms.Button();
            this.WorkParagroupBox = new System.Windows.Forms.GroupBox();
            this.label88 = new System.Windows.Forms.Label();
            this.Start_Pos_Sel = new System.Windows.Forms.ComboBox();
            this.manualFormPage = new DevExpress.XtraBars.TabFormPage();
            this.manualFormPageContainer = new DevExpress.XtraBars.TabFormContentContainer();
            this.manualTabPane = new DevExpress.XtraBars.Navigation.TabPane();
            this.gtsManual = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.HomeSmoothTimenumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.HomeDeviationnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.HomeDCCnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label49 = new System.Windows.Forms.Label();
            this.HomeACCnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label50 = new System.Windows.Forms.Label();
            this.HomeSpeednumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label51 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.MechanicHome = new System.Windows.Forms.Button();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.Upper_Posed = new System.Windows.Forms.Button();
            this.Motor_Posed = new System.Windows.Forms.Button();
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
            this.ManualSpeednumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.ManualACCnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.ManualDCCnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.ManualStep = new System.Windows.Forms.NumericUpDown();
            this.JogDot = new System.Windows.Forms.Button();
            this.label44 = new System.Windows.Forms.Label();
            this.ServoON = new System.Windows.Forms.Button();
            this.PosClear = new System.Windows.Forms.Button();
            this.StatusClear = new System.Windows.Forms.Button();
            this.AlarmClear = new System.Windows.Forms.Button();
            this.label46 = new System.Windows.Forms.Label();
            this.DriverAlarm = new System.Windows.Forms.Button();
            this.label47 = new System.Windows.Forms.Label();
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
            this.groupBox_JZ = new System.Windows.Forms.GroupBox();
            this.Btn_Rtc_Use = new System.Windows.Forms.Button();
            this.Btn_Rtc_openFile = new System.Windows.Forms.Button();
            this.Txt_RtcFilename = new System.Windows.Forms.TextBox();
            this.RtcPosReferencenumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AutoDelaySwitch = new System.Windows.Forms.Button();
            this.Reset_Rtc = new System.Windows.Forms.Button();
            this.label32 = new System.Windows.Forms.Label();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.LaserOFF = new System.Windows.Forms.Button();
            this.LaserON = new System.Windows.Forms.Button();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.MoveYnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.MoveMode = new System.Windows.Forms.Button();
            this.MoveXnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label34 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.RtcYJogNegative = new System.Windows.Forms.Button();
            this.RtcYJogPositive = new System.Windows.Forms.Button();
            this.RtcXJogNegative = new System.Windows.Forms.Button();
            this.RtcXJogPositive = new System.Windows.Forms.Button();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.Mark_SpeednumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.Jump_SpeednumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.Laser_ON_DelaynumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.Mark_DelaynumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.Jump_DelaynumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.Laser_Off_DelaynumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.Polygon_DelaynumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.Change_Para_List = new System.Windows.Forms.Button();
            this.label56 = new System.Windows.Forms.Label();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.ABSPosYnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label57 = new System.Windows.Forms.Label();
            this.ABSPosXnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label58 = new System.Windows.Forms.Label();
            this.ABSPos = new System.Windows.Forms.Button();
            this.groupBox20 = new System.Windows.Forms.GroupBox();
            this.label59 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.RtcHomeYnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.RtcHomeXnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.RtcHome = new System.Windows.Forms.Button();
            this.IOOperate = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.RedLaserButton = new System.Windows.Forms.Button();
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
            this.label97 = new System.Windows.Forms.Label();
            this.label96 = new System.Windows.Forms.Label();
            this.EXO13_Status = new System.Windows.Forms.Button();
            this.EXO12_Status = new System.Windows.Forms.Button();
            this.label95 = new System.Windows.Forms.Label();
            this.EXO11_Status = new System.Windows.Forms.Button();
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
            this.label94 = new System.Windows.Forms.Label();
            this.GlobalErrbutton = new System.Windows.Forms.Button();
            this.label67 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.AxisYErrbutton = new System.Windows.Forms.Button();
            this.AxisXErrbutton = new System.Windows.Forms.Button();
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
            this.label65 = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.AmpTemperaturenumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.SeedTemperaturenumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.LC_Amp2_SetnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.LC_PRF_Confirm = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.LC_PEC_Confirm = new System.Windows.Forms.Button();
            this.LC_Amp1_SetnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.LC_PRF_Set_ValuenumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.LC_Seed_SetnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.LC_PEC_Set_ValuenumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.LC_Status = new System.Windows.Forms.RichTextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label26 = new System.Windows.Forms.Label();
            this.LC_Reset_Laser = new System.Windows.Forms.Button();
            this.LC_Refresh_Status = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.LC_AmpTemperatureTextbox = new System.Windows.Forms.TextBox();
            this.label84 = new System.Windows.Forms.Label();
            this.LC_SeedTemperatureTextbox = new System.Windows.Forms.TextBox();
            this.label68 = new System.Windows.Forms.Label();
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
            this.PlatFormPara = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.CertifyRepeatPrecisiongroupBox = new System.Windows.Forms.GroupBox();
            this.label87 = new System.Windows.Forms.Label();
            this.PointListRepeatTimesnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.groupBox24 = new System.Windows.Forms.GroupBox();
            this.CalibrationgroupBox = new System.Windows.Forms.GroupBox();
            this.CorrectMethodcomboBox = new System.Windows.Forms.ComboBox();
            this.label86 = new System.Windows.Forms.Label();
            this.CalibrationSelectcomboBox = new System.Windows.Forms.ComboBox();
            this.label93 = new System.Windows.Forms.Label();
            this.RtcMarkParagroupBox = new System.Windows.Forms.GroupBox();
            this.RtcCorrectTypecheckBox = new System.Windows.Forms.CheckBox();
            this.RtcCircleRadiusLabel = new System.Windows.Forms.Label();
            this.RtcMarkTypecomboBox = new System.Windows.Forms.ComboBox();
            this.RtcCircleRadiusnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label92 = new System.Windows.Forms.Label();
            this.RtcAligncheckBox = new System.Windows.Forms.CheckBox();
            this.YAffinitytextBox = new System.Windows.Forms.TextBox();
            this.label90 = new System.Windows.Forms.Label();
            this.YCalibratetextBox = new System.Windows.Forms.TextBox();
            this.label91 = new System.Windows.Forms.Label();
            this.XAffinitytextBox = new System.Windows.Forms.TextBox();
            this.label89 = new System.Windows.Forms.Label();
            this.XCalibratetextBox = new System.Windows.Forms.TextBox();
            this.label83 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.YCellnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label70 = new System.Windows.Forms.Label();
            this.XCellnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label72 = new System.Windows.Forms.Label();
            this.YLengthnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label82 = new System.Windows.Forms.Label();
            this.XLengthnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.groupBox25 = new System.Windows.Forms.GroupBox();
            this.MarkJumpcheckBox = new System.Windows.Forms.CheckBox();
            this.CamEncheckBox = new System.Windows.Forms.CheckBox();
            this.label64 = new System.Windows.Forms.Label();
            this.ShieldbeepTimenumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.DebugMenugroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox23 = new System.Windows.Forms.GroupBox();
            this.ApplyRtcXmlCorrectFilebutton = new System.Windows.Forms.Button();
            this.SelectRtcXmlCorrectFilebutton = new System.Windows.Forms.Button();
            this.RtcXmlCorrectFilePathtextBox = new System.Windows.Forms.TextBox();
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.ApplyGtsCorrectFilebutton = new System.Windows.Forms.Button();
            this.SelectGtsCorrectFilebutton = new System.Windows.Forms.Button();
            this.GtsCorrectFilePathtextBox = new System.Windows.Forms.TextBox();
            this.SysParaSave = new System.Windows.Forms.Button();
            this.SyaParaRead = new System.Windows.Forms.Button();
            this.CoordinategroupBox = new System.Windows.Forms.GroupBox();
            this.label81 = new System.Windows.Forms.Label();
            this.label80 = new System.Windows.Forms.Label();
            this.RtcOrgDistanceYnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.WorkXnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.WorkYnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.RtcOrgDistanceXnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label69 = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.WorkPara = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.groupBox_safety = new System.Windows.Forms.GroupBox();
            this.CBox_SysSet_Safe_MoveEntrench = new System.Windows.Forms.CheckBox();
            this.CBox_SysSet_Safe_Baffle = new System.Windows.Forms.CheckBox();
            this.CBox_SysSet_Safe_prpcessingDoor = new System.Windows.Forms.CheckBox();
            this.CBox_SysSet_Safe_CloseDoorEntrench = new System.Windows.Forms.CheckBox();
            this.CBox_SysSet_Safe_OpenDoorEntrench = new System.Windows.Forms.CheckBox();
            this.groupBox_convention = new System.Windows.Forms.GroupBox();
            this.CBox_SysSet_Convention_prpcessEndAlarm = new System.Windows.Forms.CheckBox();
            this.CBox_SysSet_Convention_ChillerTem = new System.Windows.Forms.CheckBox();
            this.CBox_SysSet_Convention_prpcessEndDlg = new System.Windows.Forms.CheckBox();
            this.CBox_SysSet_Convention_Laserstate = new System.Windows.Forms.CheckBox();
            this.CBox_SysSet_Convention_Autolight = new System.Windows.Forms.CheckBox();
            this.groupBox_vacuo = new System.Windows.Forms.GroupBox();
            this.NumUD_SysSet_vacuum_Enddelayed = new System.Windows.Forms.NumericUpDown();
            this.CBox_SysSet_Vacuum_Pressure = new System.Windows.Forms.CheckBox();
            this.NumUD_SysSet_vacuum_Stadelayed = new System.Windows.Forms.NumericUpDown();
            this.CBox_SysSet_Vacuum_AutoOpenCleaner = new System.Windows.Forms.CheckBox();
            this.laber_vacuumendlayed = new System.Windows.Forms.Label();
            this.CBox_SysSet_Vacuum_AutoCloseCleaner = new System.Windows.Forms.CheckBox();
            this.label_vacuumstalayed = new System.Windows.Forms.Label();
            this.groupBox_Door = new System.Windows.Forms.GroupBox();
            this.numUD_SysSet_Door_delayed = new System.Windows.Forms.NumericUpDown();
            this.numUD_SysSet_Door_timelimit = new System.Windows.Forms.NumericUpDown();
            this.label_delay = new System.Windows.Forms.Label();
            this.label_timelimit = new System.Windows.Forms.Label();
            this.CBox_SysSet_Door_Auto = new System.Windows.Forms.CheckBox();
            this.groupBox_Scissor = new System.Windows.Forms.GroupBox();
            this.Rtn_SysSet_Scissor_RtcToScissor = new System.Windows.Forms.RadioButton();
            this.Rtn_SysSet_Scissor_ScissorToRtc = new System.Windows.Forms.RadioButton();
            this.groupBox_count = new System.Windows.Forms.GroupBox();
            this.CBox_SysSet_Count_pieces = new System.Windows.Forms.CheckBox();
            this.CBox_SysSet_Count_num = new System.Windows.Forms.CheckBox();
            this.groupBox_Z = new System.Windows.Forms.GroupBox();
            this.Rtn_SysSet_Z_None = new System.Windows.Forms.RadioButton();
            this.Rtn_SysSet_Z_Fastpostion = new System.Windows.Forms.RadioButton();
            this.Rtn_SysSet_Z_ProFastpostion = new System.Windows.Forms.RadioButton();
            this.groupBox_PrpcessEnd = new System.Windows.Forms.GroupBox();
            this.Rtn_SysSet_processEnd_Leftpostion = new System.Windows.Forms.RadioButton();
            this.Rtn_SysSet_processEnd_Fastpostion = new System.Windows.Forms.RadioButton();
            this.Rtn_SysSet_processEnd_Rightpostion = new System.Windows.Forms.RadioButton();
            this.Rtn_SysSet_processEnd_Zero = new System.Windows.Forms.RadioButton();
            this.Rtn_SysSet_processEnd_None = new System.Windows.Forms.RadioButton();
            this.AxisPara = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.AxisParagroupBox = new System.Windows.Forms.GroupBox();
            this.label103 = new System.Windows.Forms.Label();
            this.AxisSelectcomboBox = new System.Windows.Forms.ComboBox();
            this.AxisDccnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.numUD_AxisNegativeLimit = new System.Windows.Forms.NumericUpDown();
            this.label100 = new System.Windows.Forms.Label();
            this.numUD_AxisPositiveLimit = new System.Windows.Forms.NumericUpDown();
            this.AxisAccnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label101 = new System.Windows.Forms.Label();
            this.label_lowLimit = new System.Windows.Forms.Label();
            this.AxisSmoothTimenumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label_highLimit = new System.Windows.Forms.Label();
            this.AxisVelocitynumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label102 = new System.Windows.Forms.Label();
            this.CameraPara = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.LogInfoFormPage = new DevExpress.XtraBars.TabFormPage();
            this.LogInfo = new DevExpress.XtraBars.TabFormContentContainer();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.Debug_Info_Display = new System.Windows.Forms.RichTextBox();
            this.manualFormPag = new DevExpress.XtraBars.TabFormPage();
            this.tabFormContentContainer4 = new DevExpress.XtraBars.TabFormContentContainer();
            this.MainFormtoolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tabFormControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabFormDefaultManager1)).BeginInit();
            this.loginFormPageContainer.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Password_Input.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.User_List.Properties)).BeginInit();
            this.mainFormPageContainer.SuspendLayout();
            this.MainFormDebuggroupBox.SuspendLayout();
            this.PointListConfiggroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PointListYnumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PointListXnumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlantFormpictureBox)).BeginInit();
            this.PlatFormShiftgroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainCoordinateJogDistance)).BeginInit();
            this.ProjectgroupBox.SuspendLayout();
            this.WorkOperategroupBox.SuspendLayout();
            this.WorkParagroupBox.SuspendLayout();
            this.manualFormPageContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.manualTabPane)).BeginInit();
            this.manualTabPane.SuspendLayout();
            this.gtsManual.SuspendLayout();
            this.groupBox14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HomeSmoothTimenumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HomeDeviationnumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HomeDCCnumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HomeACCnumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HomeSpeednumericUpDown)).BeginInit();
            this.groupBox12.SuspendLayout();
            this.groupBox13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ManualSpeednumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ManualACCnumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ManualDCCnumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ManualStep)).BeginInit();
            this.groupBox11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AxisSelect)).BeginInit();
            this.rtcManual.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.groupBox_JZ.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RtcPosReferencenumericUpDown)).BeginInit();
            this.groupBox16.SuspendLayout();
            this.groupBox17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MoveYnumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoveXnumericUpDown)).BeginInit();
            this.groupBox18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Mark_SpeednumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Jump_SpeednumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Laser_ON_DelaynumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mark_DelaynumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Jump_DelaynumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Laser_Off_DelaynumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Polygon_DelaynumericUpDown)).BeginInit();
            this.groupBox19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ABSPosYnumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ABSPosXnumericUpDown)).BeginInit();
            this.groupBox20.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RtcHomeYnumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RtcHomeXnumericUpDown)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.AmpTemperaturenumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SeedTemperaturenumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LC_Amp2_SetnumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LC_Amp1_SetnumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LC_PRF_Set_ValuenumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LC_Seed_SetnumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LC_PEC_Set_ValuenumericUpDown)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.setFormPageContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.setTabPane)).BeginInit();
            this.setTabPane.SuspendLayout();
            this.PlatFormPara.SuspendLayout();
            this.CertifyRepeatPrecisiongroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PointListRepeatTimesnumericUpDown)).BeginInit();
            this.CalibrationgroupBox.SuspendLayout();
            this.RtcMarkParagroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RtcCircleRadiusnumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YCellnumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XCellnumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YLengthnumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XLengthnumericUpDown)).BeginInit();
            this.groupBox25.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShieldbeepTimenumericUpDown)).BeginInit();
            this.DebugMenugroupBox.SuspendLayout();
            this.groupBox23.SuspendLayout();
            this.groupBox21.SuspendLayout();
            this.CoordinategroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RtcOrgDistanceYnumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorkXnumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorkYnumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RtcOrgDistanceXnumericUpDown)).BeginInit();
            this.WorkPara.SuspendLayout();
            this.groupBox_safety.SuspendLayout();
            this.groupBox_convention.SuspendLayout();
            this.groupBox_vacuo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUD_SysSet_vacuum_Enddelayed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUD_SysSet_vacuum_Stadelayed)).BeginInit();
            this.groupBox_Door.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_SysSet_Door_delayed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_SysSet_Door_timelimit)).BeginInit();
            this.groupBox_Scissor.SuspendLayout();
            this.groupBox_count.SuspendLayout();
            this.groupBox_Z.SuspendLayout();
            this.groupBox_PrpcessEnd.SuspendLayout();
            this.AxisPara.SuspendLayout();
            this.AxisParagroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AxisDccnumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_AxisNegativeLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_AxisPositiveLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AxisAccnumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AxisSmoothTimenumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AxisVelocitynumericUpDown)).BeginInit();
            this.LogInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabFormControl
            // 
            this.tabFormControl.AllowMoveTabs = false;
            this.tabFormControl.AllowMoveTabsToOuterForm = false;
            this.tabFormControl.AllowTabAnimation = false;
            this.tabFormControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barUserIndicate});
            this.tabFormControl.Location = new System.Drawing.Point(0, 0);
            this.tabFormControl.Manager = this.tabFormDefaultManager1;
            this.tabFormControl.Name = "tabFormControl";
            this.tabFormControl.Pages.Add(this.LoginFormPage);
            this.tabFormControl.Pages.Add(this.workFormPage);
            this.tabFormControl.Pages.Add(this.manualFormPage);
            this.tabFormControl.Pages.Add(this.statusFormPage);
            this.tabFormControl.Pages.Add(this.laserFormPage);
            this.tabFormControl.Pages.Add(this.setFormPage);
            this.tabFormControl.Pages.Add(this.LogInfoFormPage);
            this.tabFormControl.SelectedPage = this.setFormPage;
            this.tabFormControl.ShowAddPageButton = false;
            this.tabFormControl.ShowTabCloseButtons = false;
            this.tabFormControl.Size = new System.Drawing.Size(1356, 51);
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
            this.barDockControlTop.Location = new System.Drawing.Point(0, 51);
            this.barDockControlTop.Manager = null;
            this.barDockControlTop.Size = new System.Drawing.Size(1356, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 715);
            this.barDockControlBottom.Manager = null;
            this.barDockControlBottom.Size = new System.Drawing.Size(1356, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 51);
            this.barDockControlLeft.Manager = null;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 664);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1356, 51);
            this.barDockControlRight.Manager = null;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 664);
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
            this.loginFormPageContainer.Location = new System.Drawing.Point(0, 51);
            this.loginFormPageContainer.Margin = new System.Windows.Forms.Padding(5);
            this.loginFormPageContainer.Name = "loginFormPageContainer";
            this.loginFormPageContainer.Size = new System.Drawing.Size(1356, 664);
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
            this.groupBox1.Location = new System.Drawing.Point(356, 128);
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
            this.Password_Input.Size = new System.Drawing.Size(221, 32);
            this.Password_Input.TabIndex = 3;
            this.Password_Input.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Password_Input_KeyDown);
            // 
            // User_List
            // 
            this.User_List.Location = new System.Drawing.Point(309, 71);
            this.User_List.Name = "User_List";
            this.User_List.Properties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.True;
            this.User_List.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.User_List.Properties.Appearance.Options.UseFont = true;
            this.User_List.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.User_List.Properties.Items.AddRange(new object[] {
            "操作员",
            "管理员"});
            this.User_List.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.User_List.Size = new System.Drawing.Size(221, 30);
            this.User_List.TabIndex = 2;
            // 
            // User_Password
            // 
            this.User_Password.Appearance.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.User_Password.Appearance.Options.UseFont = true;
            this.User_Password.Location = new System.Drawing.Point(136, 189);
            this.User_Password.Name = "User_Password";
            this.User_Password.Size = new System.Drawing.Size(113, 33);
            this.User_Password.TabIndex = 1;
            this.User_Password.Text = "密    码：";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(136, 68);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(113, 33);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "用    户：";
            // 
            // User_Name
            // 
            this.User_Name.Appearance.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.User_Name.Appearance.Options.UseFont = true;
            this.User_Name.Location = new System.Drawing.Point(132, 71);
            this.User_Name.Name = "User_Name";
            this.User_Name.Size = new System.Drawing.Size(94, 33);
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
            this.mainFormPageContainer.Controls.Add(this.MainFormDebuggroupBox);
            this.mainFormPageContainer.Controls.Add(this.PointListConfiggroupBox);
            this.mainFormPageContainer.Controls.Add(this.ResetEquipment);
            this.mainFormPageContainer.Controls.Add(this.PlantFormpictureBox);
            this.mainFormPageContainer.Controls.Add(this.EmgStopButton);
            this.mainFormPageContainer.Controls.Add(this.PlatFormShiftgroupBox);
            this.mainFormPageContainer.Controls.Add(this.ProjectgroupBox);
            this.mainFormPageContainer.Controls.Add(this.WorkOperategroupBox);
            this.mainFormPageContainer.Controls.Add(this.WorkParagroupBox);
            this.mainFormPageContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainFormPageContainer.Location = new System.Drawing.Point(0, 51);
            this.mainFormPageContainer.Margin = new System.Windows.Forms.Padding(2);
            this.mainFormPageContainer.Name = "mainFormPageContainer";
            this.mainFormPageContainer.Size = new System.Drawing.Size(1356, 664);
            this.mainFormPageContainer.TabIndex = 4;
            this.mainFormPageContainer.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mainFormPageContainer_KeyUp);
            // 
            // MainFormDebuggroupBox
            // 
            this.MainFormDebuggroupBox.Controls.Add(this.label85);
            this.MainFormDebuggroupBox.Controls.Add(this.Work_Type_Select_List);
            this.MainFormDebuggroupBox.Location = new System.Drawing.Point(183, 171);
            this.MainFormDebuggroupBox.Name = "MainFormDebuggroupBox";
            this.MainFormDebuggroupBox.Size = new System.Drawing.Size(261, 103);
            this.MainFormDebuggroupBox.TabIndex = 178;
            this.MainFormDebuggroupBox.TabStop = false;
            this.MainFormDebuggroupBox.Text = "调试选项";
            // 
            // label85
            // 
            this.label85.AutoSize = true;
            this.label85.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label85.Location = new System.Drawing.Point(86, 34);
            this.label85.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(91, 14);
            this.label85.TabIndex = 149;
            this.label85.Text = "加工方式选择";
            // 
            // Work_Type_Select_List
            // 
            this.Work_Type_Select_List.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.Work_Type_Select_List.Location = new System.Drawing.Point(39, 59);
            this.Work_Type_Select_List.Margin = new System.Windows.Forms.Padding(2);
            this.Work_Type_Select_List.Name = "Work_Type_Select_List";
            this.Work_Type_Select_List.Size = new System.Drawing.Size(186, 22);
            this.Work_Type_Select_List.TabIndex = 148;
            // 
            // PointListConfiggroupBox
            // 
            this.PointListConfiggroupBox.Controls.Add(this.label99);
            this.PointListConfiggroupBox.Controls.Add(this.PointListSelectcomboBox);
            this.PointListConfiggroupBox.Controls.Add(this.GoPointListbutton);
            this.PointListConfiggroupBox.Controls.Add(this.SetPointListbutton);
            this.PointListConfiggroupBox.Controls.Add(this.label98);
            this.PointListConfiggroupBox.Controls.Add(this.label61);
            this.PointListConfiggroupBox.Controls.Add(this.PointListYnumericUpDown);
            this.PointListConfiggroupBox.Controls.Add(this.PointListXnumericUpDown);
            this.PointListConfiggroupBox.Location = new System.Drawing.Point(904, 31);
            this.PointListConfiggroupBox.Name = "PointListConfiggroupBox";
            this.PointListConfiggroupBox.Size = new System.Drawing.Size(229, 196);
            this.PointListConfiggroupBox.TabIndex = 177;
            this.PointListConfiggroupBox.TabStop = false;
            this.PointListConfiggroupBox.Text = "点位配置";
            // 
            // label99
            // 
            this.label99.AutoSize = true;
            this.label99.Location = new System.Drawing.Point(21, 30);
            this.label99.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(29, 12);
            this.label99.TabIndex = 190;
            this.label99.Text = "点位";
            // 
            // PointListSelectcomboBox
            // 
            this.PointListSelectcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PointListSelectcomboBox.FormattingEnabled = true;
            this.PointListSelectcomboBox.Items.AddRange(new object[] {
            "自由点位",
            "待机点位",
            "指定点位",
            "左暂停位",
            "右暂停位",
            "下料点位",
            "调试点位"});
            this.PointListSelectcomboBox.Location = new System.Drawing.Point(83, 26);
            this.PointListSelectcomboBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.PointListSelectcomboBox.Name = "PointListSelectcomboBox";
            this.PointListSelectcomboBox.Size = new System.Drawing.Size(119, 20);
            this.PointListSelectcomboBox.TabIndex = 159;
            // 
            // GoPointListbutton
            // 
            this.GoPointListbutton.Location = new System.Drawing.Point(125, 141);
            this.GoPointListbutton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.GoPointListbutton.Name = "GoPointListbutton";
            this.GoPointListbutton.Size = new System.Drawing.Size(77, 32);
            this.GoPointListbutton.TabIndex = 189;
            this.GoPointListbutton.Text = "定    位";
            this.GoPointListbutton.UseVisualStyleBackColor = true;
            this.GoPointListbutton.Click += new System.EventHandler(this.GoPointListbutton_Click);
            // 
            // SetPointListbutton
            // 
            this.SetPointListbutton.Location = new System.Drawing.Point(17, 141);
            this.SetPointListbutton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.SetPointListbutton.Name = "SetPointListbutton";
            this.SetPointListbutton.Size = new System.Drawing.Size(77, 32);
            this.SetPointListbutton.TabIndex = 185;
            this.SetPointListbutton.Text = "赋    值";
            this.SetPointListbutton.UseVisualStyleBackColor = true;
            this.SetPointListbutton.Click += new System.EventHandler(this.SetPointListbutton_Click);
            // 
            // label98
            // 
            this.label98.AutoSize = true;
            this.label98.Location = new System.Drawing.Point(21, 104);
            this.label98.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(35, 12);
            this.label98.TabIndex = 188;
            this.label98.Text = "Y坐标";
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(21, 70);
            this.label61.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(35, 12);
            this.label61.TabIndex = 187;
            this.label61.Text = "X坐标";
            // 
            // PointListYnumericUpDown
            // 
            this.PointListYnumericUpDown.DecimalPlaces = 3;
            this.PointListYnumericUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            196608});
            this.PointListYnumericUpDown.Location = new System.Drawing.Point(89, 98);
            this.PointListYnumericUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.PointListYnumericUpDown.Maximum = new decimal(new int[] {
            350,
            0,
            0,
            0});
            this.PointListYnumericUpDown.Name = "PointListYnumericUpDown";
            this.PointListYnumericUpDown.Size = new System.Drawing.Size(76, 21);
            this.PointListYnumericUpDown.TabIndex = 186;
            this.PointListYnumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            // 
            // PointListXnumericUpDown
            // 
            this.PointListXnumericUpDown.DecimalPlaces = 3;
            this.PointListXnumericUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            196608});
            this.PointListXnumericUpDown.Location = new System.Drawing.Point(89, 65);
            this.PointListXnumericUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.PointListXnumericUpDown.Maximum = new decimal(new int[] {
            350,
            0,
            0,
            0});
            this.PointListXnumericUpDown.Name = "PointListXnumericUpDown";
            this.PointListXnumericUpDown.Size = new System.Drawing.Size(76, 21);
            this.PointListXnumericUpDown.TabIndex = 185;
            this.PointListXnumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            // 
            // ResetEquipment
            // 
            this.ResetEquipment.Location = new System.Drawing.Point(1185, 85);
            this.ResetEquipment.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.ResetEquipment.Name = "ResetEquipment";
            this.ResetEquipment.Size = new System.Drawing.Size(108, 32);
            this.ResetEquipment.TabIndex = 159;
            this.ResetEquipment.Text = "异常复位";
            this.ResetEquipment.UseVisualStyleBackColor = true;
            this.ResetEquipment.Click += new System.EventHandler(this.ResetEquipment_Click);
            // 
            // PlantFormpictureBox
            // 
            this.PlantFormpictureBox.Location = new System.Drawing.Point(473, 8);
            this.PlantFormpictureBox.Name = "PlantFormpictureBox";
            this.PlantFormpictureBox.Size = new System.Drawing.Size(400, 400);
            this.PlantFormpictureBox.TabIndex = 176;
            this.PlantFormpictureBox.TabStop = false;
            this.PlantFormpictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.PlantFormpictureBox_Paint);
            this.PlantFormpictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PlantFormpictureBox_MouseClick);
            this.PlantFormpictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PlantFormpictureBox_MouseMove);
            // 
            // EmgStopButton
            // 
            this.EmgStopButton.ForeColor = System.Drawing.Color.Black;
            this.EmgStopButton.Location = new System.Drawing.Point(1185, 35);
            this.EmgStopButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.EmgStopButton.Name = "EmgStopButton";
            this.EmgStopButton.Size = new System.Drawing.Size(108, 32);
            this.EmgStopButton.TabIndex = 160;
            this.EmgStopButton.Text = "急停";
            this.EmgStopButton.UseVisualStyleBackColor = true;
            this.EmgStopButton.Click += new System.EventHandler(this.EmgStopButton_Click);
            // 
            // PlatFormShiftgroupBox
            // 
            this.PlatFormShiftgroupBox.Controls.Add(this.GoMousePosbutton);
            this.PlatFormShiftgroupBox.Controls.Add(this.SwitchToCambutton);
            this.PlatFormShiftgroupBox.Controls.Add(this.MainCoordinateJogDistance);
            this.PlatFormShiftgroupBox.Controls.Add(this.MainYJogNegative);
            this.PlatFormShiftgroupBox.Controls.Add(this.MainYJogPositive);
            this.PlatFormShiftgroupBox.Controls.Add(this.MainXJogPositive);
            this.PlatFormShiftgroupBox.Controls.Add(this.MainXJogNegative);
            this.PlatFormShiftgroupBox.Location = new System.Drawing.Point(473, 412);
            this.PlatFormShiftgroupBox.Name = "PlatFormShiftgroupBox";
            this.PlatFormShiftgroupBox.Size = new System.Drawing.Size(400, 164);
            this.PlatFormShiftgroupBox.TabIndex = 175;
            this.PlatFormShiftgroupBox.TabStop = false;
            this.PlatFormShiftgroupBox.Text = "平台平移";
            // 
            // GoMousePosbutton
            // 
            this.GoMousePosbutton.Location = new System.Drawing.Point(286, 43);
            this.GoMousePosbutton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.GoMousePosbutton.Name = "GoMousePosbutton";
            this.GoMousePosbutton.Size = new System.Drawing.Size(97, 32);
            this.GoMousePosbutton.TabIndex = 175;
            this.GoMousePosbutton.Text = "定位指定点";
            this.MainFormtoolTip.SetToolTip(this.GoMousePosbutton, "定位到鼠标指定位置");
            this.GoMousePosbutton.UseVisualStyleBackColor = true;
            this.GoMousePosbutton.Click += new System.EventHandler(this.GoMousePosbutton_Click);
            // 
            // SwitchToCambutton
            // 
            this.SwitchToCambutton.Location = new System.Drawing.Point(286, 97);
            this.SwitchToCambutton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.SwitchToCambutton.Name = "SwitchToCambutton";
            this.SwitchToCambutton.Size = new System.Drawing.Size(97, 32);
            this.SwitchToCambutton.TabIndex = 177;
            this.SwitchToCambutton.Text = "切换到相机位";
            this.MainFormtoolTip.SetToolTip(this.SwitchToCambutton, "切换至相机下");
            this.SwitchToCambutton.UseVisualStyleBackColor = true;
            this.SwitchToCambutton.Click += new System.EventHandler(this.SwitchToCambutton_Click);
            // 
            // MainCoordinateJogDistance
            // 
            this.MainCoordinateJogDistance.DecimalPlaces = 3;
            this.MainCoordinateJogDistance.Increment = new decimal(new int[] {
            5,
            0,
            0,
            196608});
            this.MainCoordinateJogDistance.Location = new System.Drawing.Point(95, 75);
            this.MainCoordinateJogDistance.Margin = new System.Windows.Forms.Padding(2);
            this.MainCoordinateJogDistance.Maximum = new decimal(new int[] {
            350,
            0,
            0,
            0});
            this.MainCoordinateJogDistance.Name = "MainCoordinateJogDistance";
            this.MainCoordinateJogDistance.Size = new System.Drawing.Size(76, 21);
            this.MainCoordinateJogDistance.TabIndex = 169;
            this.MainCoordinateJogDistance.Value = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            // 
            // MainYJogNegative
            // 
            this.MainYJogNegative.Location = new System.Drawing.Point(93, 101);
            this.MainYJogNegative.Margin = new System.Windows.Forms.Padding(2);
            this.MainYJogNegative.Name = "MainYJogNegative";
            this.MainYJogNegative.Size = new System.Drawing.Size(80, 24);
            this.MainYJogNegative.TabIndex = 168;
            this.MainYJogNegative.Text = "Y-";
            this.MainYJogNegative.UseVisualStyleBackColor = true;
            this.MainYJogNegative.Click += new System.EventHandler(this.MainYJogNegative_Click);
            // 
            // MainYJogPositive
            // 
            this.MainYJogPositive.Location = new System.Drawing.Point(93, 47);
            this.MainYJogPositive.Margin = new System.Windows.Forms.Padding(2);
            this.MainYJogPositive.Name = "MainYJogPositive";
            this.MainYJogPositive.Size = new System.Drawing.Size(80, 24);
            this.MainYJogPositive.TabIndex = 167;
            this.MainYJogPositive.Text = "Y+";
            this.MainYJogPositive.UseVisualStyleBackColor = true;
            this.MainYJogPositive.Click += new System.EventHandler(this.MainYJogPositive_Click);
            // 
            // MainXJogPositive
            // 
            this.MainXJogPositive.Location = new System.Drawing.Point(175, 74);
            this.MainXJogPositive.Margin = new System.Windows.Forms.Padding(2);
            this.MainXJogPositive.Name = "MainXJogPositive";
            this.MainXJogPositive.Size = new System.Drawing.Size(80, 24);
            this.MainXJogPositive.TabIndex = 165;
            this.MainXJogPositive.Text = "X+";
            this.MainXJogPositive.UseVisualStyleBackColor = true;
            this.MainXJogPositive.Click += new System.EventHandler(this.MainXJogPositive_Click);
            // 
            // MainXJogNegative
            // 
            this.MainXJogNegative.Location = new System.Drawing.Point(11, 74);
            this.MainXJogNegative.Margin = new System.Windows.Forms.Padding(2);
            this.MainXJogNegative.Name = "MainXJogNegative";
            this.MainXJogNegative.Size = new System.Drawing.Size(80, 24);
            this.MainXJogNegative.TabIndex = 166;
            this.MainXJogNegative.Text = "X-";
            this.MainXJogNegative.UseVisualStyleBackColor = true;
            this.MainXJogNegative.Click += new System.EventHandler(this.MainXJogNegative_Click);
            // 
            // ProjectgroupBox
            // 
            this.ProjectgroupBox.Controls.Add(this.CamConfigbutton);
            this.ProjectgroupBox.Controls.Add(this.MaterialManagebutton);
            this.ProjectgroupBox.Controls.Add(this.MarKCoordinateConfig);
            this.ProjectgroupBox.Controls.Add(this.ConfigProject);
            this.ProjectgroupBox.Controls.Add(this.CloseProject);
            this.ProjectgroupBox.Controls.Add(this.SaveProjectAs);
            this.ProjectgroupBox.Controls.Add(this.SaveProject);
            this.ProjectgroupBox.Controls.Add(this.ImportFile);
            this.ProjectgroupBox.Controls.Add(this.OpenProject);
            this.ProjectgroupBox.Controls.Add(this.CreateProject);
            this.ProjectgroupBox.Location = new System.Drawing.Point(10, 36);
            this.ProjectgroupBox.Name = "ProjectgroupBox";
            this.ProjectgroupBox.Size = new System.Drawing.Size(150, 614);
            this.ProjectgroupBox.TabIndex = 166;
            this.ProjectgroupBox.TabStop = false;
            this.ProjectgroupBox.Text = "项目操作";
            // 
            // CamConfigbutton
            // 
            this.CamConfigbutton.Location = new System.Drawing.Point(21, 321);
            this.CamConfigbutton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.CamConfigbutton.Name = "CamConfigbutton";
            this.CamConfigbutton.Size = new System.Drawing.Size(108, 41);
            this.CamConfigbutton.TabIndex = 169;
            this.CamConfigbutton.Text = "相机配置";
            this.CamConfigbutton.UseVisualStyleBackColor = true;
            this.CamConfigbutton.Click += new System.EventHandler(this.CamConfigbutton_Click);
            // 
            // MaterialManagebutton
            // 
            this.MaterialManagebutton.Location = new System.Drawing.Point(21, 263);
            this.MaterialManagebutton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.MaterialManagebutton.Name = "MaterialManagebutton";
            this.MaterialManagebutton.Size = new System.Drawing.Size(108, 41);
            this.MaterialManagebutton.TabIndex = 168;
            this.MaterialManagebutton.Text = "物料管理";
            this.MaterialManagebutton.UseVisualStyleBackColor = true;
            this.MaterialManagebutton.Click += new System.EventHandler(this.MaterialManagebutton_Click);
            // 
            // MarKCoordinateConfig
            // 
            this.MarKCoordinateConfig.Location = new System.Drawing.Point(21, 379);
            this.MarKCoordinateConfig.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.MarKCoordinateConfig.Name = "MarKCoordinateConfig";
            this.MarKCoordinateConfig.Size = new System.Drawing.Size(108, 41);
            this.MarKCoordinateConfig.TabIndex = 167;
            this.MarKCoordinateConfig.Text = "Mark坐标配置";
            this.MarKCoordinateConfig.UseVisualStyleBackColor = true;
            this.MarKCoordinateConfig.Click += new System.EventHandler(this.MarKCoordinateConfig_Click);
            // 
            // ConfigProject
            // 
            this.ConfigProject.Location = new System.Drawing.Point(21, 205);
            this.ConfigProject.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.ConfigProject.Name = "ConfigProject";
            this.ConfigProject.Size = new System.Drawing.Size(108, 41);
            this.ConfigProject.TabIndex = 166;
            this.ConfigProject.Text = "刀具库";
            this.ConfigProject.UseVisualStyleBackColor = true;
            this.ConfigProject.Click += new System.EventHandler(this.ConfigProject_Click);
            // 
            // CloseProject
            // 
            this.CloseProject.Location = new System.Drawing.Point(21, 553);
            this.CloseProject.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.CloseProject.Name = "CloseProject";
            this.CloseProject.Size = new System.Drawing.Size(108, 41);
            this.CloseProject.TabIndex = 165;
            this.CloseProject.Text = "关闭项目";
            this.CloseProject.UseVisualStyleBackColor = true;
            this.CloseProject.Click += new System.EventHandler(this.CloseProject_Click);
            // 
            // SaveProjectAs
            // 
            this.SaveProjectAs.Location = new System.Drawing.Point(21, 495);
            this.SaveProjectAs.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.SaveProjectAs.Name = "SaveProjectAs";
            this.SaveProjectAs.Size = new System.Drawing.Size(108, 41);
            this.SaveProjectAs.TabIndex = 164;
            this.SaveProjectAs.Text = "另存项目";
            this.SaveProjectAs.UseVisualStyleBackColor = true;
            this.SaveProjectAs.Click += new System.EventHandler(this.SaveProjectAs_Click);
            // 
            // SaveProject
            // 
            this.SaveProject.Location = new System.Drawing.Point(21, 437);
            this.SaveProject.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.SaveProject.Name = "SaveProject";
            this.SaveProject.Size = new System.Drawing.Size(108, 41);
            this.SaveProject.TabIndex = 163;
            this.SaveProject.Text = "保存项目";
            this.SaveProject.UseVisualStyleBackColor = true;
            this.SaveProject.Click += new System.EventHandler(this.SaveProject_Click);
            // 
            // ImportFile
            // 
            this.ImportFile.Location = new System.Drawing.Point(21, 147);
            this.ImportFile.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.ImportFile.Name = "ImportFile";
            this.ImportFile.Size = new System.Drawing.Size(108, 41);
            this.ImportFile.TabIndex = 162;
            this.ImportFile.Text = "导入文件";
            this.ImportFile.UseVisualStyleBackColor = true;
            this.ImportFile.Click += new System.EventHandler(this.ImportFile_Click);
            // 
            // OpenProject
            // 
            this.OpenProject.Location = new System.Drawing.Point(21, 89);
            this.OpenProject.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.OpenProject.Name = "OpenProject";
            this.OpenProject.Size = new System.Drawing.Size(108, 41);
            this.OpenProject.TabIndex = 161;
            this.OpenProject.Text = "打开项目";
            this.OpenProject.UseVisualStyleBackColor = true;
            this.OpenProject.Click += new System.EventHandler(this.OpenProject_Click);
            // 
            // CreateProject
            // 
            this.CreateProject.Location = new System.Drawing.Point(21, 31);
            this.CreateProject.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.CreateProject.Name = "CreateProject";
            this.CreateProject.Size = new System.Drawing.Size(108, 41);
            this.CreateProject.TabIndex = 157;
            this.CreateProject.Text = "新建项目";
            this.CreateProject.UseVisualStyleBackColor = true;
            this.CreateProject.Click += new System.EventHandler(this.CreateProject_Click);
            // 
            // WorkOperategroupBox
            // 
            this.WorkOperategroupBox.Controls.Add(this.LaserOperateButton);
            this.WorkOperategroupBox.Controls.Add(this.FileMarkStop);
            this.WorkOperategroupBox.Controls.Add(this.FileMarkRun);
            this.WorkOperategroupBox.Controls.Add(this.AxisHome);
            this.WorkOperategroupBox.Location = new System.Drawing.Point(183, 425);
            this.WorkOperategroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.WorkOperategroupBox.Name = "WorkOperategroupBox";
            this.WorkOperategroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.WorkOperategroupBox.Size = new System.Drawing.Size(261, 151);
            this.WorkOperategroupBox.TabIndex = 160;
            this.WorkOperategroupBox.TabStop = false;
            this.WorkOperategroupBox.Text = "加工操作";
            // 
            // LaserOperateButton
            // 
            this.LaserOperateButton.Location = new System.Drawing.Point(16, 37);
            this.LaserOperateButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.LaserOperateButton.Name = "LaserOperateButton";
            this.LaserOperateButton.Size = new System.Drawing.Size(108, 41);
            this.LaserOperateButton.TabIndex = 159;
            this.LaserOperateButton.Text = "激光初始化";
            this.LaserOperateButton.UseVisualStyleBackColor = true;
            this.LaserOperateButton.Click += new System.EventHandler(this.LaserOperateButton_Click);
            // 
            // FileMarkStop
            // 
            this.FileMarkStop.Location = new System.Drawing.Point(140, 93);
            this.FileMarkStop.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.FileMarkStop.Name = "FileMarkStop";
            this.FileMarkStop.Size = new System.Drawing.Size(108, 41);
            this.FileMarkStop.TabIndex = 158;
            this.FileMarkStop.Text = "终  止";
            this.FileMarkStop.UseVisualStyleBackColor = true;
            this.FileMarkStop.Click += new System.EventHandler(this.FileMarkStop_Click);
            // 
            // FileMarkRun
            // 
            this.FileMarkRun.Location = new System.Drawing.Point(16, 93);
            this.FileMarkRun.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.FileMarkRun.Name = "FileMarkRun";
            this.FileMarkRun.Size = new System.Drawing.Size(108, 41);
            this.FileMarkRun.TabIndex = 157;
            this.FileMarkRun.Text = "启  动";
            this.FileMarkRun.UseVisualStyleBackColor = true;
            this.FileMarkRun.Click += new System.EventHandler(this.FileMarkRun_Click);
            // 
            // AxisHome
            // 
            this.AxisHome.Location = new System.Drawing.Point(140, 37);
            this.AxisHome.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.AxisHome.Name = "AxisHome";
            this.AxisHome.Size = new System.Drawing.Size(108, 41);
            this.AxisHome.TabIndex = 36;
            this.AxisHome.Text = "平台初始化";
            this.AxisHome.UseVisualStyleBackColor = true;
            this.AxisHome.Click += new System.EventHandler(this.AxisHome_Click);
            // 
            // WorkParagroupBox
            // 
            this.WorkParagroupBox.Controls.Add(this.label88);
            this.WorkParagroupBox.Controls.Add(this.Start_Pos_Sel);
            this.WorkParagroupBox.Location = new System.Drawing.Point(183, 31);
            this.WorkParagroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.WorkParagroupBox.Name = "WorkParagroupBox";
            this.WorkParagroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.WorkParagroupBox.Size = new System.Drawing.Size(261, 103);
            this.WorkParagroupBox.TabIndex = 159;
            this.WorkParagroupBox.TabStop = false;
            this.WorkParagroupBox.Text = "加工参数";
            // 
            // label88
            // 
            this.label88.AutoSize = true;
            this.label88.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label88.Location = new System.Drawing.Point(71, 31);
            this.label88.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(119, 14);
            this.label88.TabIndex = 158;
            this.label88.Text = "加工起始位置选择";
            // 
            // Start_Pos_Sel
            // 
            this.Start_Pos_Sel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Start_Pos_Sel.FormattingEnabled = true;
            this.Start_Pos_Sel.Items.AddRange(new object[] {
            "原点起始",
            "Mark矫正",
            "指定点起始"});
            this.Start_Pos_Sel.Location = new System.Drawing.Point(37, 57);
            this.Start_Pos_Sel.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Start_Pos_Sel.Name = "Start_Pos_Sel";
            this.Start_Pos_Sel.Size = new System.Drawing.Size(186, 20);
            this.Start_Pos_Sel.TabIndex = 157;
            // 
            // manualFormPage
            // 
            this.manualFormPage.ContentContainer = this.manualFormPageContainer;
            this.manualFormPage.Name = "manualFormPage";
            this.manualFormPage.ShowCloseButton = DevExpress.Utils.DefaultBoolean.False;
            this.manualFormPage.Text = "手动";
            this.manualFormPage.Visible = false;
            // 
            // manualFormPageContainer
            // 
            this.manualFormPageContainer.Controls.Add(this.manualTabPane);
            this.manualFormPageContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.manualFormPageContainer.Location = new System.Drawing.Point(0, 51);
            this.manualFormPageContainer.Name = "manualFormPageContainer";
            this.manualFormPageContainer.Size = new System.Drawing.Size(1356, 664);
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
            this.manualTabPane.RegularSize = new System.Drawing.Size(1356, 664);
            this.manualTabPane.SelectedPage = this.gtsManual;
            this.manualTabPane.Size = new System.Drawing.Size(1356, 664);
            this.manualTabPane.TabIndex = 0;
            this.manualTabPane.Text = "mannualTabPane";
            // 
            // gtsManual
            // 
            this.gtsManual.Caption = "轴调试";
            this.gtsManual.Controls.Add(this.groupBox14);
            this.gtsManual.Controls.Add(this.MechanicHome);
            this.gtsManual.Controls.Add(this.groupBox12);
            this.gtsManual.Controls.Add(this.groupBox13);
            this.gtsManual.Controls.Add(this.GtsReset);
            this.gtsManual.Controls.Add(this.groupBox11);
            this.gtsManual.Controls.Add(this.label31);
            this.gtsManual.Controls.Add(this.AxisSelect);
            this.gtsManual.Name = "gtsManual";
            this.gtsManual.Size = new System.Drawing.Size(1356, 636);
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.HomeSmoothTimenumericUpDown);
            this.groupBox14.Controls.Add(this.HomeDeviationnumericUpDown);
            this.groupBox14.Controls.Add(this.HomeDCCnumericUpDown);
            this.groupBox14.Controls.Add(this.label49);
            this.groupBox14.Controls.Add(this.HomeACCnumericUpDown);
            this.groupBox14.Controls.Add(this.label50);
            this.groupBox14.Controls.Add(this.HomeSpeednumericUpDown);
            this.groupBox14.Controls.Add(this.label51);
            this.groupBox14.Controls.Add(this.label52);
            this.groupBox14.Controls.Add(this.label53);
            this.groupBox14.Location = new System.Drawing.Point(919, 198);
            this.groupBox14.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox14.Size = new System.Drawing.Size(230, 415);
            this.groupBox14.TabIndex = 35;
            this.groupBox14.TabStop = false;
            this.groupBox14.Visible = false;
            // 
            // HomeSmoothTimenumericUpDown
            // 
            this.HomeSmoothTimenumericUpDown.DecimalPlaces = 3;
            this.HomeSmoothTimenumericUpDown.Location = new System.Drawing.Point(45, 286);
            this.HomeSmoothTimenumericUpDown.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.HomeSmoothTimenumericUpDown.Name = "HomeSmoothTimenumericUpDown";
            this.HomeSmoothTimenumericUpDown.Size = new System.Drawing.Size(134, 21);
            this.HomeSmoothTimenumericUpDown.TabIndex = 170;
            // 
            // HomeDeviationnumericUpDown
            // 
            this.HomeDeviationnumericUpDown.DecimalPlaces = 3;
            this.HomeDeviationnumericUpDown.Location = new System.Drawing.Point(45, 363);
            this.HomeDeviationnumericUpDown.Name = "HomeDeviationnumericUpDown";
            this.HomeDeviationnumericUpDown.Size = new System.Drawing.Size(134, 21);
            this.HomeDeviationnumericUpDown.TabIndex = 171;
            // 
            // HomeDCCnumericUpDown
            // 
            this.HomeDCCnumericUpDown.DecimalPlaces = 3;
            this.HomeDCCnumericUpDown.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.HomeDCCnumericUpDown.Location = new System.Drawing.Point(45, 209);
            this.HomeDCCnumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.HomeDCCnumericUpDown.Name = "HomeDCCnumericUpDown";
            this.HomeDCCnumericUpDown.Size = new System.Drawing.Size(134, 21);
            this.HomeDCCnumericUpDown.TabIndex = 169;
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(60, 259);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(101, 12);
            this.label49.TabIndex = 30;
            this.label49.Text = "回零平滑时间(ms)";
            // 
            // HomeACCnumericUpDown
            // 
            this.HomeACCnumericUpDown.DecimalPlaces = 3;
            this.HomeACCnumericUpDown.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.HomeACCnumericUpDown.Location = new System.Drawing.Point(45, 132);
            this.HomeACCnumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.HomeACCnumericUpDown.Name = "HomeACCnumericUpDown";
            this.HomeACCnumericUpDown.Size = new System.Drawing.Size(134, 21);
            this.HomeACCnumericUpDown.TabIndex = 168;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(54, 182);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(113, 12);
            this.label50.TabIndex = 28;
            this.label50.Text = "回零减速度 (mm/s²)";
            // 
            // HomeSpeednumericUpDown
            // 
            this.HomeSpeednumericUpDown.DecimalPlaces = 3;
            this.HomeSpeednumericUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.HomeSpeednumericUpDown.Location = new System.Drawing.Point(45, 55);
            this.HomeSpeednumericUpDown.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.HomeSpeednumericUpDown.Name = "HomeSpeednumericUpDown";
            this.HomeSpeednumericUpDown.Size = new System.Drawing.Size(134, 21);
            this.HomeSpeednumericUpDown.TabIndex = 167;
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(54, 105);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(113, 12);
            this.label51.TabIndex = 26;
            this.label51.Text = "回零加速度 (mm/s²)";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(63, 28);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(95, 12);
            this.label52.TabIndex = 23;
            this.label52.Text = "回零速度 (mm/s)";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(70, 336);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(77, 12);
            this.label53.TabIndex = 23;
            this.label53.Text = "原点偏移(mm)";
            // 
            // MechanicHome
            // 
            this.MechanicHome.Location = new System.Drawing.Point(724, 18);
            this.MechanicHome.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MechanicHome.Name = "MechanicHome";
            this.MechanicHome.Size = new System.Drawing.Size(130, 38);
            this.MechanicHome.TabIndex = 33;
            this.MechanicHome.Text = "机械回零";
            this.MechanicHome.UseVisualStyleBackColor = true;
            this.MechanicHome.Click += new System.EventHandler(this.MechanicHome_Click);
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.Upper_Posed);
            this.groupBox12.Controls.Add(this.Motor_Posed);
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
            this.Motor_Posed.Location = new System.Drawing.Point(264, 291);
            this.Motor_Posed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Motor_Posed.Name = "Motor_Posed";
            this.Motor_Posed.Size = new System.Drawing.Size(130, 38);
            this.Motor_Posed.TabIndex = 35;
            this.Motor_Posed.Text = "Motor 到位";
            this.Motor_Posed.UseVisualStyleBackColor = true;
            // 
            // BoardAlarm
            // 
            this.BoardAlarm.Location = new System.Drawing.Point(264, 93);
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
            this.ActualMode.Size = new System.Drawing.Size(77, 12);
            this.ActualMode.TabIndex = 30;
            this.ActualMode.Text = "当前模式指示";
            this.ActualMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EmgStop
            // 
            this.EmgStop.Location = new System.Drawing.Point(264, 225);
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
            this.ActualSpeed.Size = new System.Drawing.Size(77, 12);
            this.ActualSpeed.TabIndex = 29;
            this.ActualSpeed.Text = "当前速度指示";
            this.ActualSpeed.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ActualDCC
            // 
            this.ActualDCC.AutoSize = true;
            this.ActualDCC.Location = new System.Drawing.Point(44, 174);
            this.ActualDCC.Name = "ActualDCC";
            this.ActualDCC.Size = new System.Drawing.Size(89, 12);
            this.ActualDCC.TabIndex = 28;
            this.ActualDCC.Text = "当前减速度指示";
            this.ActualDCC.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // SmoothStop
            // 
            this.SmoothStop.Location = new System.Drawing.Point(264, 159);
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
            this.ActualACC.Size = new System.Drawing.Size(89, 12);
            this.ActualACC.TabIndex = 27;
            this.ActualACC.Text = "当前加速度指示";
            this.ActualACC.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(52, 324);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(77, 12);
            this.label40.TabIndex = 9;
            this.label40.Text = "当前运动模式";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(39, 236);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(95, 12);
            this.label41.TabIndex = 7;
            this.label41.Text = "当前速度 (mm/s)";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(26, 148);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(113, 12);
            this.label42.TabIndex = 5;
            this.label42.Text = "当前减速度 (mm/s²)";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(26, 60);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(113, 12);
            this.label43.TabIndex = 3;
            this.label43.Text = "当前加速度 (mm/s²)";
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.ManualSpeednumericUpDown);
            this.groupBox13.Controls.Add(this.ManualACCnumericUpDown);
            this.groupBox13.Controls.Add(this.ManualDCCnumericUpDown);
            this.groupBox13.Controls.Add(this.ManualStep);
            this.groupBox13.Controls.Add(this.JogDot);
            this.groupBox13.Controls.Add(this.label44);
            this.groupBox13.Controls.Add(this.ServoON);
            this.groupBox13.Controls.Add(this.PosClear);
            this.groupBox13.Controls.Add(this.StatusClear);
            this.groupBox13.Controls.Add(this.AlarmClear);
            this.groupBox13.Controls.Add(this.label46);
            this.groupBox13.Controls.Add(this.DriverAlarm);
            this.groupBox13.Controls.Add(this.label47);
            this.groupBox13.Controls.Add(this.label48);
            this.groupBox13.Location = new System.Drawing.Point(30, 209);
            this.groupBox13.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox13.Size = new System.Drawing.Size(336, 415);
            this.groupBox13.TabIndex = 29;
            this.groupBox13.TabStop = false;
            // 
            // ManualSpeednumericUpDown
            // 
            this.ManualSpeednumericUpDown.DecimalPlaces = 3;
            this.ManualSpeednumericUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.ManualSpeednumericUpDown.Location = new System.Drawing.Point(26, 358);
            this.ManualSpeednumericUpDown.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.ManualSpeednumericUpDown.Name = "ManualSpeednumericUpDown";
            this.ManualSpeednumericUpDown.Size = new System.Drawing.Size(134, 21);
            this.ManualSpeednumericUpDown.TabIndex = 166;
            // 
            // ManualACCnumericUpDown
            // 
            this.ManualACCnumericUpDown.DecimalPlaces = 3;
            this.ManualACCnumericUpDown.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.ManualACCnumericUpDown.Location = new System.Drawing.Point(26, 54);
            this.ManualACCnumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ManualACCnumericUpDown.Name = "ManualACCnumericUpDown";
            this.ManualACCnumericUpDown.Size = new System.Drawing.Size(134, 21);
            this.ManualACCnumericUpDown.TabIndex = 166;
            // 
            // ManualDCCnumericUpDown
            // 
            this.ManualDCCnumericUpDown.DecimalPlaces = 3;
            this.ManualDCCnumericUpDown.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.ManualDCCnumericUpDown.Location = new System.Drawing.Point(26, 156);
            this.ManualDCCnumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ManualDCCnumericUpDown.Name = "ManualDCCnumericUpDown";
            this.ManualDCCnumericUpDown.Size = new System.Drawing.Size(134, 21);
            this.ManualDCCnumericUpDown.TabIndex = 165;
            // 
            // ManualStep
            // 
            this.ManualStep.DecimalPlaces = 3;
            this.ManualStep.Increment = new decimal(new int[] {
            5,
            0,
            0,
            196608});
            this.ManualStep.Location = new System.Drawing.Point(26, 262);
            this.ManualStep.Maximum = new decimal(new int[] {
            350,
            0,
            0,
            0});
            this.ManualStep.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.ManualStep.Name = "ManualStep";
            this.ManualStep.Size = new System.Drawing.Size(134, 21);
            this.ManualStep.TabIndex = 163;
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
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(44, 329);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(95, 12);
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
            this.label46.Location = new System.Drawing.Point(61, 228);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(59, 12);
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
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(47, 127);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(89, 12);
            this.label47.TabIndex = 5;
            this.label47.Text = "减速度 (mm/s²)";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(47, 26);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(89, 12);
            this.label48.TabIndex = 3;
            this.label48.Text = "加速度 (mm/s²)";
            // 
            // GtsReset
            // 
            this.GtsReset.Location = new System.Drawing.Point(558, 18);
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
            this.ActualPos.Size = new System.Drawing.Size(77, 12);
            this.ActualPos.TabIndex = 28;
            this.ActualPos.Text = "当前位置指示";
            this.ActualPos.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(328, 79);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(83, 12);
            this.label33.TabIndex = 27;
            this.label33.Text = "实际位置 (mm)";
            // 
            // CurrentPos
            // 
            this.CurrentPos.AutoSize = true;
            this.CurrentPos.Location = new System.Drawing.Point(332, 42);
            this.CurrentPos.Name = "CurrentPos";
            this.CurrentPos.Size = new System.Drawing.Size(77, 12);
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
            this.label35.Size = new System.Drawing.Size(83, 12);
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
            this.label31.Size = new System.Drawing.Size(41, 12);
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
            this.AxisSelect.Size = new System.Drawing.Size(120, 21);
            this.AxisSelect.TabIndex = 26;
            this.AxisSelect.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // rtcManual
            // 
            this.rtcManual.Caption = "振镜调试";
            this.rtcManual.Controls.Add(this.groupBox15);
            this.rtcManual.Controls.Add(this.groupBox16);
            this.rtcManual.Controls.Add(this.groupBox17);
            this.rtcManual.Controls.Add(this.groupBox18);
            this.rtcManual.Controls.Add(this.groupBox19);
            this.rtcManual.Controls.Add(this.groupBox20);
            this.rtcManual.Name = "rtcManual";
            this.rtcManual.Size = new System.Drawing.Size(1356, 636);
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.groupBox_JZ);
            this.groupBox15.Controls.Add(this.RtcPosReferencenumericUpDown);
            this.groupBox15.Controls.Add(this.AutoDelaySwitch);
            this.groupBox15.Controls.Add(this.Reset_Rtc);
            this.groupBox15.Controls.Add(this.label32);
            this.groupBox15.Location = new System.Drawing.Point(546, 411);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(469, 172);
            this.groupBox15.TabIndex = 52;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "打标参数 mm/bit";
            // 
            // groupBox_JZ
            // 
            this.groupBox_JZ.Controls.Add(this.Btn_Rtc_Use);
            this.groupBox_JZ.Controls.Add(this.Btn_Rtc_openFile);
            this.groupBox_JZ.Controls.Add(this.Txt_RtcFilename);
            this.groupBox_JZ.Location = new System.Drawing.Point(13, 72);
            this.groupBox_JZ.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox_JZ.Name = "groupBox_JZ";
            this.groupBox_JZ.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox_JZ.Size = new System.Drawing.Size(230, 94);
            this.groupBox_JZ.TabIndex = 9;
            this.groupBox_JZ.TabStop = false;
            this.groupBox_JZ.Text = "校正文件（*ct5）";
            // 
            // Btn_Rtc_Use
            // 
            this.Btn_Rtc_Use.Location = new System.Drawing.Point(145, 59);
            this.Btn_Rtc_Use.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_Rtc_Use.Name = "Btn_Rtc_Use";
            this.Btn_Rtc_Use.Size = new System.Drawing.Size(66, 29);
            this.Btn_Rtc_Use.TabIndex = 1;
            this.Btn_Rtc_Use.Text = "应用";
            this.Btn_Rtc_Use.UseVisualStyleBackColor = true;
            this.Btn_Rtc_Use.Click += new System.EventHandler(this.Btn_Rtc_Use_Click);
            // 
            // Btn_Rtc_openFile
            // 
            this.Btn_Rtc_openFile.Location = new System.Drawing.Point(12, 59);
            this.Btn_Rtc_openFile.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_Rtc_openFile.Name = "Btn_Rtc_openFile";
            this.Btn_Rtc_openFile.Size = new System.Drawing.Size(66, 29);
            this.Btn_Rtc_openFile.TabIndex = 1;
            this.Btn_Rtc_openFile.Text = "open";
            this.Btn_Rtc_openFile.UseVisualStyleBackColor = true;
            this.Btn_Rtc_openFile.Click += new System.EventHandler(this.Btn_Rtc_openFile_Click);
            // 
            // Txt_RtcFilename
            // 
            this.Txt_RtcFilename.Location = new System.Drawing.Point(12, 26);
            this.Txt_RtcFilename.Margin = new System.Windows.Forms.Padding(2);
            this.Txt_RtcFilename.Name = "Txt_RtcFilename";
            this.Txt_RtcFilename.ReadOnly = true;
            this.Txt_RtcFilename.Size = new System.Drawing.Size(202, 21);
            this.Txt_RtcFilename.TabIndex = 0;
            // 
            // RtcPosReferencenumericUpDown
            // 
            this.RtcPosReferencenumericUpDown.Increment = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.RtcPosReferencenumericUpDown.Location = new System.Drawing.Point(128, 31);
            this.RtcPosReferencenumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.RtcPosReferencenumericUpDown.Name = "RtcPosReferencenumericUpDown";
            this.RtcPosReferencenumericUpDown.Size = new System.Drawing.Size(115, 21);
            this.RtcPosReferencenumericUpDown.TabIndex = 172;
            // 
            // AutoDelaySwitch
            // 
            this.AutoDelaySwitch.Location = new System.Drawing.Point(326, 24);
            this.AutoDelaySwitch.Name = "AutoDelaySwitch";
            this.AutoDelaySwitch.Size = new System.Drawing.Size(115, 37);
            this.AutoDelaySwitch.TabIndex = 44;
            this.AutoDelaySwitch.Text = "延时校正";
            this.AutoDelaySwitch.UseVisualStyleBackColor = true;
            this.AutoDelaySwitch.Click += new System.EventHandler(this.AutoDelaySwitch_Click);
            // 
            // Reset_Rtc
            // 
            this.Reset_Rtc.Location = new System.Drawing.Point(325, 108);
            this.Reset_Rtc.Name = "Reset_Rtc";
            this.Reset_Rtc.Size = new System.Drawing.Size(115, 37);
            this.Reset_Rtc.TabIndex = 43;
            this.Reset_Rtc.Text = "复位Rtc控制卡";
            this.Reset_Rtc.UseVisualStyleBackColor = true;
            this.Reset_Rtc.Click += new System.EventHandler(this.Reset_Rtc_Click);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(13, 35);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(89, 12);
            this.label32.TabIndex = 16;
            this.label32.Text = "位尺寸(bit/mm)";
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.LaserOFF);
            this.groupBox16.Controls.Add(this.LaserON);
            this.groupBox16.Location = new System.Drawing.Point(546, 299);
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
            this.groupBox17.Controls.Add(this.MoveYnumericUpDown);
            this.groupBox17.Controls.Add(this.MoveMode);
            this.groupBox17.Controls.Add(this.MoveXnumericUpDown);
            this.groupBox17.Controls.Add(this.label34);
            this.groupBox17.Controls.Add(this.label36);
            this.groupBox17.Controls.Add(this.RtcYJogNegative);
            this.groupBox17.Controls.Add(this.RtcYJogPositive);
            this.groupBox17.Controls.Add(this.RtcXJogNegative);
            this.groupBox17.Controls.Add(this.RtcXJogPositive);
            this.groupBox17.Location = new System.Drawing.Point(55, 299);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(463, 284);
            this.groupBox17.TabIndex = 50;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "光斑移动";
            // 
            // MoveYnumericUpDown
            // 
            this.MoveYnumericUpDown.Location = new System.Drawing.Point(315, 91);
            this.MoveYnumericUpDown.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.MoveYnumericUpDown.Name = "MoveYnumericUpDown";
            this.MoveYnumericUpDown.Size = new System.Drawing.Size(115, 21);
            this.MoveYnumericUpDown.TabIndex = 172;
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
            // MoveXnumericUpDown
            // 
            this.MoveXnumericUpDown.Location = new System.Drawing.Point(35, 91);
            this.MoveXnumericUpDown.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.MoveXnumericUpDown.Name = "MoveXnumericUpDown";
            this.MoveXnumericUpDown.Size = new System.Drawing.Size(115, 21);
            this.MoveXnumericUpDown.TabIndex = 171;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(340, 60);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(53, 12);
            this.label34.TabIndex = 8;
            this.label34.Text = "Y步距/mm";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(61, 60);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(53, 12);
            this.label36.TabIndex = 7;
            this.label36.Text = "X步距/mm";
            // 
            // RtcYJogNegative
            // 
            this.RtcYJogNegative.Location = new System.Drawing.Point(315, 207);
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
            this.RtcXJogNegative.Location = new System.Drawing.Point(35, 200);
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
            this.groupBox18.Controls.Add(this.Mark_SpeednumericUpDown);
            this.groupBox18.Controls.Add(this.Jump_SpeednumericUpDown);
            this.groupBox18.Controls.Add(this.Laser_ON_DelaynumericUpDown);
            this.groupBox18.Controls.Add(this.Mark_DelaynumericUpDown);
            this.groupBox18.Controls.Add(this.Jump_DelaynumericUpDown);
            this.groupBox18.Controls.Add(this.Laser_Off_DelaynumericUpDown);
            this.groupBox18.Controls.Add(this.Polygon_DelaynumericUpDown);
            this.groupBox18.Controls.Add(this.label37);
            this.groupBox18.Controls.Add(this.label38);
            this.groupBox18.Controls.Add(this.label39);
            this.groupBox18.Controls.Add(this.label45);
            this.groupBox18.Controls.Add(this.label54);
            this.groupBox18.Controls.Add(this.label55);
            this.groupBox18.Controls.Add(this.Change_Para_List);
            this.groupBox18.Controls.Add(this.label56);
            this.groupBox18.Location = new System.Drawing.Point(546, 47);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(470, 230);
            this.groupBox18.TabIndex = 49;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "激光参数";
            // 
            // Mark_SpeednumericUpDown
            // 
            this.Mark_SpeednumericUpDown.Increment = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.Mark_SpeednumericUpDown.Location = new System.Drawing.Point(16, 63);
            this.Mark_SpeednumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.Mark_SpeednumericUpDown.Name = "Mark_SpeednumericUpDown";
            this.Mark_SpeednumericUpDown.Size = new System.Drawing.Size(115, 21);
            this.Mark_SpeednumericUpDown.TabIndex = 171;
            // 
            // Jump_SpeednumericUpDown
            // 
            this.Jump_SpeednumericUpDown.Increment = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.Jump_SpeednumericUpDown.Location = new System.Drawing.Point(16, 124);
            this.Jump_SpeednumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.Jump_SpeednumericUpDown.Name = "Jump_SpeednumericUpDown";
            this.Jump_SpeednumericUpDown.Size = new System.Drawing.Size(115, 21);
            this.Jump_SpeednumericUpDown.TabIndex = 172;
            // 
            // Laser_ON_DelaynumericUpDown
            // 
            this.Laser_ON_DelaynumericUpDown.Location = new System.Drawing.Point(16, 191);
            this.Laser_ON_DelaynumericUpDown.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.Laser_ON_DelaynumericUpDown.Name = "Laser_ON_DelaynumericUpDown";
            this.Laser_ON_DelaynumericUpDown.Size = new System.Drawing.Size(115, 21);
            this.Laser_ON_DelaynumericUpDown.TabIndex = 175;
            // 
            // Mark_DelaynumericUpDown
            // 
            this.Mark_DelaynumericUpDown.Location = new System.Drawing.Point(167, 191);
            this.Mark_DelaynumericUpDown.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.Mark_DelaynumericUpDown.Name = "Mark_DelaynumericUpDown";
            this.Mark_DelaynumericUpDown.Size = new System.Drawing.Size(115, 21);
            this.Mark_DelaynumericUpDown.TabIndex = 174;
            // 
            // Jump_DelaynumericUpDown
            // 
            this.Jump_DelaynumericUpDown.Location = new System.Drawing.Point(167, 127);
            this.Jump_DelaynumericUpDown.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.Jump_DelaynumericUpDown.Name = "Jump_DelaynumericUpDown";
            this.Jump_DelaynumericUpDown.Size = new System.Drawing.Size(115, 21);
            this.Jump_DelaynumericUpDown.TabIndex = 173;
            // 
            // Laser_Off_DelaynumericUpDown
            // 
            this.Laser_Off_DelaynumericUpDown.Location = new System.Drawing.Point(167, 63);
            this.Laser_Off_DelaynumericUpDown.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.Laser_Off_DelaynumericUpDown.Name = "Laser_Off_DelaynumericUpDown";
            this.Laser_Off_DelaynumericUpDown.Size = new System.Drawing.Size(115, 21);
            this.Laser_Off_DelaynumericUpDown.TabIndex = 172;
            // 
            // Polygon_DelaynumericUpDown
            // 
            this.Polygon_DelaynumericUpDown.Location = new System.Drawing.Point(318, 63);
            this.Polygon_DelaynumericUpDown.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.Polygon_DelaynumericUpDown.Name = "Polygon_DelaynumericUpDown";
            this.Polygon_DelaynumericUpDown.Size = new System.Drawing.Size(115, 21);
            this.Polygon_DelaynumericUpDown.TabIndex = 171;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(329, 35);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(89, 12);
            this.label37.TabIndex = 42;
            this.label37.Text = "Polygon延时 ms";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(177, 98);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(71, 12);
            this.label38.TabIndex = 40;
            this.label38.Text = "Jump延时 ms";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(179, 161);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(71, 12);
            this.label39.TabIndex = 38;
            this.label39.Text = "Mark延时 ms";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(179, 35);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(71, 12);
            this.label45.TabIndex = 36;
            this.label45.Text = "关光延时 ms";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(26, 99);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(83, 12);
            this.label54.TabIndex = 34;
            this.label54.Text = "Jump速度 mm/s";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(36, 163);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(71, 12);
            this.label55.TabIndex = 28;
            this.label55.Text = "开光延时 ms";
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
            this.label56.Location = new System.Drawing.Point(28, 35);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(83, 12);
            this.label56.TabIndex = 16;
            this.label56.Text = "Mark速度 mm/s";
            // 
            // groupBox19
            // 
            this.groupBox19.Controls.Add(this.ABSPosYnumericUpDown);
            this.groupBox19.Controls.Add(this.label57);
            this.groupBox19.Controls.Add(this.ABSPosXnumericUpDown);
            this.groupBox19.Controls.Add(this.label58);
            this.groupBox19.Controls.Add(this.ABSPos);
            this.groupBox19.Location = new System.Drawing.Point(55, 173);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(464, 104);
            this.groupBox19.TabIndex = 48;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "绝对定位";
            // 
            // ABSPosYnumericUpDown
            // 
            this.ABSPosYnumericUpDown.Location = new System.Drawing.Point(335, 56);
            this.ABSPosYnumericUpDown.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.ABSPosYnumericUpDown.Name = "ABSPosYnumericUpDown";
            this.ABSPosYnumericUpDown.Size = new System.Drawing.Size(115, 21);
            this.ABSPosYnumericUpDown.TabIndex = 170;
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(360, 29);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(53, 12);
            this.label57.TabIndex = 14;
            this.label57.Text = "Y坐标/mm";
            // 
            // ABSPosXnumericUpDown
            // 
            this.ABSPosXnumericUpDown.Location = new System.Drawing.Point(166, 56);
            this.ABSPosXnumericUpDown.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.ABSPosXnumericUpDown.Name = "ABSPosXnumericUpDown";
            this.ABSPosXnumericUpDown.Size = new System.Drawing.Size(115, 21);
            this.ABSPosXnumericUpDown.TabIndex = 169;
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(192, 29);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(53, 12);
            this.label58.TabIndex = 13;
            this.label58.Text = "X坐标/mm";
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
            this.groupBox20.Controls.Add(this.RtcHomeYnumericUpDown);
            this.groupBox20.Controls.Add(this.RtcHomeXnumericUpDown);
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
            this.label59.Location = new System.Drawing.Point(344, 29);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(59, 12);
            this.label59.TabIndex = 14;
            this.label59.Text = "Home_Y/mm";
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(192, 29);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(59, 12);
            this.label60.TabIndex = 13;
            this.label60.Text = "Home_X/mm";
            // 
            // RtcHomeYnumericUpDown
            // 
            this.RtcHomeYnumericUpDown.Location = new System.Drawing.Point(326, 56);
            this.RtcHomeYnumericUpDown.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.RtcHomeYnumericUpDown.Name = "RtcHomeYnumericUpDown";
            this.RtcHomeYnumericUpDown.Size = new System.Drawing.Size(115, 21);
            this.RtcHomeYnumericUpDown.TabIndex = 168;
            // 
            // RtcHomeXnumericUpDown
            // 
            this.RtcHomeXnumericUpDown.Location = new System.Drawing.Point(174, 56);
            this.RtcHomeXnumericUpDown.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.RtcHomeXnumericUpDown.Name = "RtcHomeXnumericUpDown";
            this.RtcHomeXnumericUpDown.Size = new System.Drawing.Size(115, 21);
            this.RtcHomeXnumericUpDown.TabIndex = 167;
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
            this.IOOperate.Caption = "IO调试";
            this.IOOperate.Controls.Add(this.RedLaserButton);
            this.IOOperate.Controls.Add(this.Buzzer);
            this.IOOperate.Controls.Add(this.BeaconRed);
            this.IOOperate.Controls.Add(this.BeaconGreen);
            this.IOOperate.Controls.Add(this.BeaconYellow);
            this.IOOperate.Controls.Add(this.Blow);
            this.IOOperate.Controls.Add(this.Cylinder);
            this.IOOperate.Controls.Add(this.Lamp);
            this.IOOperate.Name = "IOOperate";
            this.IOOperate.Size = new System.Drawing.Size(1356, 636);
            // 
            // RedLaserButton
            // 
            this.RedLaserButton.Location = new System.Drawing.Point(680, 67);
            this.RedLaserButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RedLaserButton.Name = "RedLaserButton";
            this.RedLaserButton.Size = new System.Drawing.Size(140, 46);
            this.RedLaserButton.TabIndex = 23;
            this.RedLaserButton.Text = "红色激光";
            this.RedLaserButton.UseVisualStyleBackColor = true;
            this.RedLaserButton.Click += new System.EventHandler(this.RedLaserButton_Click);
            // 
            // Buzzer
            // 
            this.Buzzer.Location = new System.Drawing.Point(680, 180);
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
            this.BeaconRed.Location = new System.Drawing.Point(480, 180);
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
            this.BeaconGreen.Location = new System.Drawing.Point(280, 180);
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
            this.BeaconYellow.Location = new System.Drawing.Point(80, 180);
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
            this.Blow.Location = new System.Drawing.Point(480, 67);
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
            this.Cylinder.Location = new System.Drawing.Point(280, 67);
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
            this.Lamp.Location = new System.Drawing.Point(80, 67);
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
            this.statusFormPageContainer.Location = new System.Drawing.Point(0, 51);
            this.statusFormPageContainer.Name = "statusFormPageContainer";
            this.statusFormPageContainer.Size = new System.Drawing.Size(1356, 664);
            this.statusFormPageContainer.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(623, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 16);
            this.label9.TabIndex = 19;
            this.label9.Text = "输出信号";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(170, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 16);
            this.label8.TabIndex = 18;
            this.label8.Text = "输入信号";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label97);
            this.groupBox3.Controls.Add(this.label96);
            this.groupBox3.Controls.Add(this.EXO13_Status);
            this.groupBox3.Controls.Add(this.EXO12_Status);
            this.groupBox3.Controls.Add(this.label95);
            this.groupBox3.Controls.Add(this.EXO11_Status);
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
            this.groupBox3.Size = new System.Drawing.Size(387, 618);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            // 
            // label97
            // 
            this.label97.AutoSize = true;
            this.label97.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label97.Location = new System.Drawing.Point(154, 483);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(96, 16);
            this.label97.TabIndex = 25;
            this.label97.Text = "X轴回零触发";
            // 
            // label96
            // 
            this.label96.AutoSize = true;
            this.label96.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label96.Location = new System.Drawing.Point(154, 530);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(96, 16);
            this.label96.TabIndex = 24;
            this.label96.Text = "Y轴回零触发";
            // 
            // EXO13_Status
            // 
            this.EXO13_Status.BackColor = System.Drawing.SystemColors.Control;
            this.EXO13_Status.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EXO13_Status.ForeColor = System.Drawing.Color.Black;
            this.EXO13_Status.Location = new System.Drawing.Point(44, 567);
            this.EXO13_Status.Name = "EXO13_Status";
            this.EXO13_Status.Size = new System.Drawing.Size(90, 40);
            this.EXO13_Status.TabIndex = 23;
            this.EXO13_Status.Text = "EXO13";
            this.EXO13_Status.UseVisualStyleBackColor = false;
            // 
            // EXO12_Status
            // 
            this.EXO12_Status.BackColor = System.Drawing.SystemColors.Control;
            this.EXO12_Status.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EXO12_Status.ForeColor = System.Drawing.Color.Black;
            this.EXO12_Status.Location = new System.Drawing.Point(44, 518);
            this.EXO12_Status.Name = "EXO12_Status";
            this.EXO12_Status.Size = new System.Drawing.Size(90, 40);
            this.EXO12_Status.TabIndex = 22;
            this.EXO12_Status.Text = "EXO12";
            this.EXO12_Status.UseVisualStyleBackColor = false;
            // 
            // label95
            // 
            this.label95.AutoSize = true;
            this.label95.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label95.Location = new System.Drawing.Point(154, 579);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(56, 16);
            this.label95.TabIndex = 21;
            this.label95.Text = "红光开";
            // 
            // EXO11_Status
            // 
            this.EXO11_Status.BackColor = System.Drawing.SystemColors.Control;
            this.EXO11_Status.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EXO11_Status.ForeColor = System.Drawing.Color.Black;
            this.EXO11_Status.Location = new System.Drawing.Point(44, 471);
            this.EXO11_Status.Name = "EXO11_Status";
            this.EXO11_Status.Size = new System.Drawing.Size(90, 40);
            this.EXO11_Status.TabIndex = 20;
            this.EXO11_Status.Text = "EXO11";
            this.EXO11_Status.UseVisualStyleBackColor = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(154, 437);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(96, 16);
            this.label19.TabIndex = 19;
            this.label19.Text = "启动按钮2灯";
            // 
            // EXO10_Status
            // 
            this.EXO10_Status.BackColor = System.Drawing.SystemColors.Control;
            this.EXO10_Status.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EXO10_Status.ForeColor = System.Drawing.Color.Black;
            this.EXO10_Status.Location = new System.Drawing.Point(44, 425);
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
            this.label18.Location = new System.Drawing.Point(154, 393);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(96, 16);
            this.label18.TabIndex = 17;
            this.label18.Text = "启动按钮1灯";
            // 
            // EXO9_Status
            // 
            this.EXO9_Status.BackColor = System.Drawing.SystemColors.Control;
            this.EXO9_Status.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EXO9_Status.ForeColor = System.Drawing.Color.Black;
            this.EXO9_Status.Location = new System.Drawing.Point(44, 381);
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
            this.label17.Location = new System.Drawing.Point(154, 349);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 16);
            this.label17.TabIndex = 15;
            this.label17.Text = "照明灯";
            // 
            // EXO8_Status
            // 
            this.EXO8_Status.BackColor = System.Drawing.SystemColors.Control;
            this.EXO8_Status.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EXO8_Status.ForeColor = System.Drawing.Color.Black;
            this.EXO8_Status.Location = new System.Drawing.Point(44, 337);
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
            this.label10.Location = new System.Drawing.Point(154, 305);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 16);
            this.label10.TabIndex = 13;
            this.label10.Text = "吹气打开";
            // 
            // EXO7_Status
            // 
            this.EXO7_Status.BackColor = System.Drawing.SystemColors.Control;
            this.EXO7_Status.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EXO7_Status.ForeColor = System.Drawing.Color.Black;
            this.EXO7_Status.Location = new System.Drawing.Point(44, 293);
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
            this.label11.Location = new System.Drawing.Point(154, 261);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 16);
            this.label11.TabIndex = 11;
            this.label11.Text = "除尘气缸退回";
            // 
            // EXO6_Status
            // 
            this.EXO6_Status.BackColor = System.Drawing.SystemColors.Control;
            this.EXO6_Status.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EXO6_Status.ForeColor = System.Drawing.Color.Black;
            this.EXO6_Status.Location = new System.Drawing.Point(44, 249);
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
            this.label12.Location = new System.Drawing.Point(154, 217);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(104, 16);
            this.label12.TabIndex = 9;
            this.label12.Text = "除尘气缸伸出";
            // 
            // EXO5_Status
            // 
            this.EXO5_Status.BackColor = System.Drawing.SystemColors.Control;
            this.EXO5_Status.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EXO5_Status.ForeColor = System.Drawing.Color.Black;
            this.EXO5_Status.Location = new System.Drawing.Point(44, 205);
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
            this.label13.Location = new System.Drawing.Point(154, 173);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 16);
            this.label13.TabIndex = 7;
            this.label13.Text = "蜂鸣器";
            // 
            // EXO4_Status
            // 
            this.EXO4_Status.BackColor = System.Drawing.SystemColors.Control;
            this.EXO4_Status.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EXO4_Status.ForeColor = System.Drawing.Color.Black;
            this.EXO4_Status.Location = new System.Drawing.Point(44, 161);
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
            this.label14.Location = new System.Drawing.Point(154, 129);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(88, 16);
            this.label14.TabIndex = 5;
            this.label14.Text = "三色灯塔红";
            // 
            // EXO3_Status
            // 
            this.EXO3_Status.BackColor = System.Drawing.SystemColors.Control;
            this.EXO3_Status.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EXO3_Status.ForeColor = System.Drawing.Color.Black;
            this.EXO3_Status.Location = new System.Drawing.Point(44, 117);
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
            this.label15.Location = new System.Drawing.Point(154, 85);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(88, 16);
            this.label15.TabIndex = 3;
            this.label15.Text = "三色灯塔绿";
            // 
            // EXO2_Status
            // 
            this.EXO2_Status.BackColor = System.Drawing.SystemColors.Control;
            this.EXO2_Status.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EXO2_Status.ForeColor = System.Drawing.Color.Black;
            this.EXO2_Status.Location = new System.Drawing.Point(44, 73);
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
            this.label16.Location = new System.Drawing.Point(154, 41);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(88, 16);
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
            this.groupBox2.Controls.Add(this.label94);
            this.groupBox2.Controls.Add(this.GlobalErrbutton);
            this.groupBox2.Controls.Add(this.label67);
            this.groupBox2.Controls.Add(this.label66);
            this.groupBox2.Controls.Add(this.AxisYErrbutton);
            this.groupBox2.Controls.Add(this.AxisXErrbutton);
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
            this.groupBox2.Location = new System.Drawing.Point(30, 36);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox2.Size = new System.Drawing.Size(387, 522);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            // 
            // label94
            // 
            this.label94.AutoSize = true;
            this.label94.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label94.Location = new System.Drawing.Point(153, 481);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(72, 16);
            this.label94.TabIndex = 21;
            this.label94.Text = "全局故障";
            // 
            // GlobalErrbutton
            // 
            this.GlobalErrbutton.BackColor = System.Drawing.SystemColors.Control;
            this.GlobalErrbutton.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GlobalErrbutton.ForeColor = System.Drawing.Color.Black;
            this.GlobalErrbutton.Location = new System.Drawing.Point(44, 469);
            this.GlobalErrbutton.Name = "GlobalErrbutton";
            this.GlobalErrbutton.Size = new System.Drawing.Size(90, 40);
            this.GlobalErrbutton.TabIndex = 20;
            this.GlobalErrbutton.Text = "全局Err";
            this.GlobalErrbutton.UseVisualStyleBackColor = false;
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label67.Location = new System.Drawing.Point(153, 437);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(64, 16);
            this.label67.TabIndex = 19;
            this.label67.Text = "Y轴故障";
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label66.Location = new System.Drawing.Point(153, 393);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(64, 16);
            this.label66.TabIndex = 18;
            this.label66.Text = "X轴故障";
            // 
            // AxisYErrbutton
            // 
            this.AxisYErrbutton.BackColor = System.Drawing.SystemColors.Control;
            this.AxisYErrbutton.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AxisYErrbutton.ForeColor = System.Drawing.Color.Black;
            this.AxisYErrbutton.Location = new System.Drawing.Point(44, 425);
            this.AxisYErrbutton.Name = "AxisYErrbutton";
            this.AxisYErrbutton.Size = new System.Drawing.Size(90, 40);
            this.AxisYErrbutton.TabIndex = 17;
            this.AxisYErrbutton.Text = "Y轴Err";
            this.AxisYErrbutton.UseVisualStyleBackColor = false;
            // 
            // AxisXErrbutton
            // 
            this.AxisXErrbutton.BackColor = System.Drawing.SystemColors.Control;
            this.AxisXErrbutton.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AxisXErrbutton.ForeColor = System.Drawing.Color.Black;
            this.AxisXErrbutton.Location = new System.Drawing.Point(44, 381);
            this.AxisXErrbutton.Name = "AxisXErrbutton";
            this.AxisXErrbutton.Size = new System.Drawing.Size(90, 40);
            this.AxisXErrbutton.TabIndex = 16;
            this.AxisXErrbutton.Text = "X轴Err";
            this.AxisXErrbutton.UseVisualStyleBackColor = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.Location = new System.Drawing.Point(153, 349);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(88, 16);
            this.label20.TabIndex = 15;
            this.label20.Text = "XY均已回零";
            // 
            // Homed_Status
            // 
            this.Homed_Status.BackColor = System.Drawing.SystemColors.Control;
            this.Homed_Status.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Homed_Status.ForeColor = System.Drawing.Color.Black;
            this.Homed_Status.Location = new System.Drawing.Point(44, 337);
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
            this.label7.Location = new System.Drawing.Point(153, 305);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "启动按钮2";
            // 
            // EXI7_Status
            // 
            this.EXI7_Status.BackColor = System.Drawing.SystemColors.Control;
            this.EXI7_Status.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EXI7_Status.ForeColor = System.Drawing.Color.Black;
            this.EXI7_Status.Location = new System.Drawing.Point(44, 293);
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
            this.label6.Location = new System.Drawing.Point(153, 261);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "启动按钮1";
            // 
            // EXI6_Status
            // 
            this.EXI6_Status.BackColor = System.Drawing.SystemColors.Control;
            this.EXI6_Status.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EXI6_Status.ForeColor = System.Drawing.Color.Black;
            this.EXI6_Status.Location = new System.Drawing.Point(44, 249);
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
            this.label5.Location = new System.Drawing.Point(153, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "右门禁传感器";
            // 
            // EXI5_Status
            // 
            this.EXI5_Status.BackColor = System.Drawing.SystemColors.Control;
            this.EXI5_Status.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EXI5_Status.ForeColor = System.Drawing.Color.Black;
            this.EXI5_Status.Location = new System.Drawing.Point(44, 205);
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
            this.label4.Location = new System.Drawing.Point(153, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "左门禁传感器";
            // 
            // EXI4_Status
            // 
            this.EXI4_Status.BackColor = System.Drawing.SystemColors.Control;
            this.EXI4_Status.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EXI4_Status.ForeColor = System.Drawing.Color.Black;
            this.EXI4_Status.Location = new System.Drawing.Point(44, 161);
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
            this.label3.Location = new System.Drawing.Point(153, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "除尘气缸退回传感器";
            // 
            // EXI3_Status
            // 
            this.EXI3_Status.BackColor = System.Drawing.SystemColors.Control;
            this.EXI3_Status.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EXI3_Status.ForeColor = System.Drawing.Color.Black;
            this.EXI3_Status.Location = new System.Drawing.Point(44, 117);
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
            this.label2.Location = new System.Drawing.Point(153, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "除尘气缸伸出传感器";
            // 
            // EXI2_Status
            // 
            this.EXI2_Status.BackColor = System.Drawing.SystemColors.Control;
            this.EXI2_Status.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EXI2_Status.ForeColor = System.Drawing.Color.Black;
            this.EXI2_Status.Location = new System.Drawing.Point(44, 73);
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
            this.label1.Location = new System.Drawing.Point(153, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
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
            this.laserFormPageContainer.Location = new System.Drawing.Point(0, 51);
            this.laserFormPageContainer.Name = "laserFormPageContainer";
            this.laserFormPageContainer.Size = new System.Drawing.Size(1356, 664);
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
            this.groupBox10.Size = new System.Drawing.Size(566, 311);
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
            this.LW_Com_List.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LW_Com_List.FormattingEnabled = true;
            this.LW_Com_List.Location = new System.Drawing.Point(168, 31);
            this.LW_Com_List.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LW_Com_List.Name = "LW_Com_List";
            this.LW_Com_List.Size = new System.Drawing.Size(121, 20);
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
            this.Laser_Current_Watt_Label.Size = new System.Drawing.Size(101, 12);
            this.Laser_Current_Watt_Label.TabIndex = 48;
            this.Laser_Current_Watt_Label.Text = "激光实时功率(mw)";
            // 
            // Laser_Percent_Label
            // 
            this.Laser_Percent_Label.AutoSize = true;
            this.Laser_Percent_Label.Location = new System.Drawing.Point(52, 166);
            this.Laser_Percent_Label.Name = "Laser_Percent_Label";
            this.Laser_Percent_Label.Size = new System.Drawing.Size(107, 12);
            this.Laser_Percent_Label.TabIndex = 47;
            this.Laser_Percent_Label.Text = "激光输出百分比(%)";
            // 
            // LW_PEC_Indicate
            // 
            this.LW_PEC_Indicate.Location = new System.Drawing.Point(72, 197);
            this.LW_PEC_Indicate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LW_PEC_Indicate.Name = "LW_PEC_Indicate";
            this.LW_PEC_Indicate.ReadOnly = true;
            this.LW_PEC_Indicate.Size = new System.Drawing.Size(121, 21);
            this.LW_PEC_Indicate.TabIndex = 46;
            // 
            // LW_Watt_Indicate
            // 
            this.LW_Watt_Indicate.Location = new System.Drawing.Point(332, 197);
            this.LW_Watt_Indicate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LW_Watt_Indicate.Name = "LW_Watt_Indicate";
            this.LW_Watt_Indicate.Size = new System.Drawing.Size(121, 21);
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
            this.groupBox7.Size = new System.Drawing.Size(749, 614);
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
            this.LC_Com_List.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LC_Com_List.FormattingEnabled = true;
            this.LC_Com_List.Location = new System.Drawing.Point(171, 32);
            this.LC_Com_List.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LC_Com_List.Name = "LC_Com_List";
            this.LC_Com_List.Size = new System.Drawing.Size(121, 20);
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
            this.groupBox4.Controls.Add(this.label65);
            this.groupBox4.Controls.Add(this.label63);
            this.groupBox4.Controls.Add(this.AmpTemperaturenumericUpDown);
            this.groupBox4.Controls.Add(this.SeedTemperaturenumericUpDown);
            this.groupBox4.Controls.Add(this.LC_Amp2_SetnumericUpDown);
            this.groupBox4.Controls.Add(this.LC_PRF_Confirm);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Controls.Add(this.LC_PEC_Confirm);
            this.groupBox4.Controls.Add(this.LC_Amp1_SetnumericUpDown);
            this.groupBox4.Controls.Add(this.LC_PRF_Set_ValuenumericUpDown);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.label23);
            this.groupBox4.Controls.Add(this.LC_Seed_SetnumericUpDown);
            this.groupBox4.Controls.Add(this.LC_PEC_Set_ValuenumericUpDown);
            this.groupBox4.Controls.Add(this.label24);
            this.groupBox4.Controls.Add(this.label25);
            this.groupBox4.Location = new System.Drawing.Point(192, 350);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Size = new System.Drawing.Size(538, 253);
            this.groupBox4.TabIndex = 39;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "激光参数";
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(24, 220);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(125, 12);
            this.label65.TabIndex = 28;
            this.label65.Text = "Amp 温度 设置值(度):";
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(24, 189);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(131, 12);
            this.label63.TabIndex = 27;
            this.label63.Text = "Seed 温度 设置值(度):";
            // 
            // AmpTemperaturenumericUpDown
            // 
            this.AmpTemperaturenumericUpDown.DecimalPlaces = 2;
            this.AmpTemperaturenumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.AmpTemperaturenumericUpDown.Location = new System.Drawing.Point(186, 216);
            this.AmpTemperaturenumericUpDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AmpTemperaturenumericUpDown.Name = "AmpTemperaturenumericUpDown";
            this.AmpTemperaturenumericUpDown.Size = new System.Drawing.Size(120, 21);
            this.AmpTemperaturenumericUpDown.TabIndex = 26;
            // 
            // SeedTemperaturenumericUpDown
            // 
            this.SeedTemperaturenumericUpDown.DecimalPlaces = 2;
            this.SeedTemperaturenumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.SeedTemperaturenumericUpDown.Location = new System.Drawing.Point(186, 185);
            this.SeedTemperaturenumericUpDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SeedTemperaturenumericUpDown.Name = "SeedTemperaturenumericUpDown";
            this.SeedTemperaturenumericUpDown.Size = new System.Drawing.Size(120, 21);
            this.SeedTemperaturenumericUpDown.TabIndex = 25;
            // 
            // LC_Amp2_SetnumericUpDown
            // 
            this.LC_Amp2_SetnumericUpDown.DecimalPlaces = 2;
            this.LC_Amp2_SetnumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.LC_Amp2_SetnumericUpDown.Location = new System.Drawing.Point(186, 154);
            this.LC_Amp2_SetnumericUpDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LC_Amp2_SetnumericUpDown.Maximum = new decimal(new int[] {
            825,
            0,
            0,
            131072});
            this.LC_Amp2_SetnumericUpDown.Name = "LC_Amp2_SetnumericUpDown";
            this.LC_Amp2_SetnumericUpDown.Size = new System.Drawing.Size(120, 21);
            this.LC_Amp2_SetnumericUpDown.TabIndex = 24;
            // 
            // LC_PRF_Confirm
            // 
            this.LC_PRF_Confirm.Location = new System.Drawing.Point(364, 70);
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
            this.label21.Location = new System.Drawing.Point(24, 158);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(125, 12);
            this.label21.TabIndex = 16;
            this.label21.Text = "Amp2 电流 设置值(A):";
            // 
            // LC_PEC_Confirm
            // 
            this.LC_PEC_Confirm.Location = new System.Drawing.Point(364, 24);
            this.LC_PEC_Confirm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LC_PEC_Confirm.Name = "LC_PEC_Confirm";
            this.LC_PEC_Confirm.Size = new System.Drawing.Size(122, 35);
            this.LC_PEC_Confirm.TabIndex = 18;
            this.LC_PEC_Confirm.Text = "功率写入";
            this.LC_PEC_Confirm.UseVisualStyleBackColor = true;
            this.LC_PEC_Confirm.Click += new System.EventHandler(this.LC_PEC_Confirm_Click);
            // 
            // LC_Amp1_SetnumericUpDown
            // 
            this.LC_Amp1_SetnumericUpDown.DecimalPlaces = 2;
            this.LC_Amp1_SetnumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.LC_Amp1_SetnumericUpDown.Location = new System.Drawing.Point(186, 123);
            this.LC_Amp1_SetnumericUpDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LC_Amp1_SetnumericUpDown.Maximum = new decimal(new int[] {
            57,
            0,
            0,
            65536});
            this.LC_Amp1_SetnumericUpDown.Name = "LC_Amp1_SetnumericUpDown";
            this.LC_Amp1_SetnumericUpDown.Size = new System.Drawing.Size(120, 21);
            this.LC_Amp1_SetnumericUpDown.TabIndex = 23;
            // 
            // LC_PRF_Set_ValuenumericUpDown
            // 
            this.LC_PRF_Set_ValuenumericUpDown.Location = new System.Drawing.Point(186, 61);
            this.LC_PRF_Set_ValuenumericUpDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LC_PRF_Set_ValuenumericUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.LC_PRF_Set_ValuenumericUpDown.Minimum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.LC_PRF_Set_ValuenumericUpDown.Name = "LC_PRF_Set_ValuenumericUpDown";
            this.LC_PRF_Set_ValuenumericUpDown.Size = new System.Drawing.Size(120, 21);
            this.LC_PRF_Set_ValuenumericUpDown.TabIndex = 21;
            this.LC_PRF_Set_ValuenumericUpDown.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(24, 127);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(125, 12);
            this.label22.TabIndex = 14;
            this.label22.Text = "Amp1 电流 设置值(A):";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(24, 65);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(95, 12);
            this.label23.TabIndex = 14;
            this.label23.Text = "激光频率 (KHz):";
            // 
            // LC_Seed_SetnumericUpDown
            // 
            this.LC_Seed_SetnumericUpDown.DecimalPlaces = 2;
            this.LC_Seed_SetnumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.LC_Seed_SetnumericUpDown.Location = new System.Drawing.Point(186, 92);
            this.LC_Seed_SetnumericUpDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LC_Seed_SetnumericUpDown.Maximum = new decimal(new int[] {
            306,
            0,
            0,
            131072});
            this.LC_Seed_SetnumericUpDown.Name = "LC_Seed_SetnumericUpDown";
            this.LC_Seed_SetnumericUpDown.Size = new System.Drawing.Size(120, 21);
            this.LC_Seed_SetnumericUpDown.TabIndex = 22;
            // 
            // LC_PEC_Set_ValuenumericUpDown
            // 
            this.LC_PEC_Set_ValuenumericUpDown.DecimalPlaces = 1;
            this.LC_PEC_Set_ValuenumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.LC_PEC_Set_ValuenumericUpDown.Location = new System.Drawing.Point(186, 30);
            this.LC_PEC_Set_ValuenumericUpDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LC_PEC_Set_ValuenumericUpDown.Name = "LC_PEC_Set_ValuenumericUpDown";
            this.LC_PEC_Set_ValuenumericUpDown.Size = new System.Drawing.Size(120, 21);
            this.LC_PEC_Set_ValuenumericUpDown.TabIndex = 20;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(24, 96);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(125, 12);
            this.label24.TabIndex = 12;
            this.label24.Text = "Seed 电流 设置值(A):";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(24, 34);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(83, 12);
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
            this.LC_Status.Size = new System.Drawing.Size(165, 275);
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
            this.label26.Location = new System.Drawing.Point(15, 1);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(53, 12);
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
            this.groupBox6.Controls.Add(this.LC_AmpTemperatureTextbox);
            this.groupBox6.Controls.Add(this.label84);
            this.groupBox6.Controls.Add(this.LC_SeedTemperatureTextbox);
            this.groupBox6.Controls.Add(this.label68);
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
            // LC_AmpTemperatureTextbox
            // 
            this.LC_AmpTemperatureTextbox.Location = new System.Drawing.Point(148, 178);
            this.LC_AmpTemperatureTextbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LC_AmpTemperatureTextbox.Name = "LC_AmpTemperatureTextbox";
            this.LC_AmpTemperatureTextbox.ReadOnly = true;
            this.LC_AmpTemperatureTextbox.Size = new System.Drawing.Size(100, 21);
            this.LC_AmpTemperatureTextbox.TabIndex = 15;
            // 
            // label84
            // 
            this.label84.AutoSize = true;
            this.label84.Location = new System.Drawing.Point(17, 182);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(83, 12);
            this.label84.TabIndex = 14;
            this.label84.Text = "Amp 温度(度):";
            // 
            // LC_SeedTemperatureTextbox
            // 
            this.LC_SeedTemperatureTextbox.Location = new System.Drawing.Point(148, 146);
            this.LC_SeedTemperatureTextbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LC_SeedTemperatureTextbox.Name = "LC_SeedTemperatureTextbox";
            this.LC_SeedTemperatureTextbox.ReadOnly = true;
            this.LC_SeedTemperatureTextbox.Size = new System.Drawing.Size(100, 21);
            this.LC_SeedTemperatureTextbox.TabIndex = 13;
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Location = new System.Drawing.Point(17, 150);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(89, 12);
            this.label68.TabIndex = 12;
            this.label68.Text = "Seed 温度(度):";
            // 
            // LC_Amp2_Current
            // 
            this.LC_Amp2_Current.Location = new System.Drawing.Point(148, 114);
            this.LC_Amp2_Current.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LC_Amp2_Current.Name = "LC_Amp2_Current";
            this.LC_Amp2_Current.ReadOnly = true;
            this.LC_Amp2_Current.Size = new System.Drawing.Size(100, 21);
            this.LC_Amp2_Current.TabIndex = 11;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(17, 118);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(83, 12);
            this.label27.TabIndex = 10;
            this.label27.Text = "Amp2 电流(A):";
            // 
            // LC_Amp1_Current
            // 
            this.LC_Amp1_Current.Location = new System.Drawing.Point(148, 82);
            this.LC_Amp1_Current.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LC_Amp1_Current.Name = "LC_Amp1_Current";
            this.LC_Amp1_Current.ReadOnly = true;
            this.LC_Amp1_Current.Size = new System.Drawing.Size(100, 21);
            this.LC_Amp1_Current.TabIndex = 9;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(17, 86);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(83, 12);
            this.label28.TabIndex = 8;
            this.label28.Text = "Amp1 电流(A):";
            // 
            // LC_Seed_Current
            // 
            this.LC_Seed_Current.Location = new System.Drawing.Point(148, 50);
            this.LC_Seed_Current.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LC_Seed_Current.Name = "LC_Seed_Current";
            this.LC_Seed_Current.ReadOnly = true;
            this.LC_Seed_Current.Size = new System.Drawing.Size(100, 21);
            this.LC_Seed_Current.TabIndex = 7;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(17, 54);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(83, 12);
            this.label29.TabIndex = 6;
            this.label29.Text = "Seed 电流(A):";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(-2, 3);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(77, 12);
            this.label30.TabIndex = 5;
            this.label30.Text = "实时电流信息";
            // 
            // LC_Power_OFF
            // 
            this.LC_Power_OFF.Location = new System.Drawing.Point(9, 545);
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
            this.setFormPageContainer.Location = new System.Drawing.Point(0, 51);
            this.setFormPageContainer.Name = "setFormPageContainer";
            this.setFormPageContainer.Size = new System.Drawing.Size(1356, 664);
            this.setFormPageContainer.TabIndex = 5;
            // 
            // setTabPane
            // 
            this.setTabPane.AllowCollapse = DevExpress.Utils.DefaultBoolean.Default;
            this.setTabPane.Controls.Add(this.PlatFormPara);
            this.setTabPane.Controls.Add(this.WorkPara);
            this.setTabPane.Controls.Add(this.AxisPara);
            this.setTabPane.Controls.Add(this.CameraPara);
            this.setTabPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setTabPane.Location = new System.Drawing.Point(0, 0);
            this.setTabPane.Name = "setTabPane";
            this.setTabPane.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.PlatFormPara,
            this.WorkPara,
            this.AxisPara});
            this.setTabPane.RegularSize = new System.Drawing.Size(1356, 664);
            this.setTabPane.SelectedPage = this.PlatFormPara;
            this.setTabPane.Size = new System.Drawing.Size(1356, 664);
            this.setTabPane.TabIndex = 0;
            this.setTabPane.Text = "=45";
            // 
            // PlatFormPara
            // 
            this.PlatFormPara.Caption = "系统参数";
            this.PlatFormPara.Controls.Add(this.CertifyRepeatPrecisiongroupBox);
            this.PlatFormPara.Controls.Add(this.groupBox24);
            this.PlatFormPara.Controls.Add(this.CalibrationgroupBox);
            this.PlatFormPara.Controls.Add(this.groupBox25);
            this.PlatFormPara.Controls.Add(this.DebugMenugroupBox);
            this.PlatFormPara.Controls.Add(this.CoordinategroupBox);
            this.PlatFormPara.Name = "PlatFormPara";
            this.PlatFormPara.Size = new System.Drawing.Size(1356, 636);
            // 
            // CertifyRepeatPrecisiongroupBox
            // 
            this.CertifyRepeatPrecisiongroupBox.Controls.Add(this.label87);
            this.CertifyRepeatPrecisiongroupBox.Controls.Add(this.PointListRepeatTimesnumericUpDown);
            this.CertifyRepeatPrecisiongroupBox.Location = new System.Drawing.Point(348, 9);
            this.CertifyRepeatPrecisiongroupBox.Name = "CertifyRepeatPrecisiongroupBox";
            this.CertifyRepeatPrecisiongroupBox.Size = new System.Drawing.Size(261, 92);
            this.CertifyRepeatPrecisiongroupBox.TabIndex = 178;
            this.CertifyRepeatPrecisiongroupBox.TabStop = false;
            this.CertifyRepeatPrecisiongroupBox.Text = "重复性验证";
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.Location = new System.Drawing.Point(18, 43);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(55, 14);
            this.label87.TabIndex = 162;
            this.label87.Text = "重复次数";
            // 
            // PointListRepeatTimesnumericUpDown
            // 
            this.PointListRepeatTimesnumericUpDown.Increment = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.PointListRepeatTimesnumericUpDown.Location = new System.Drawing.Point(118, 39);
            this.PointListRepeatTimesnumericUpDown.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.PointListRepeatTimesnumericUpDown.Name = "PointListRepeatTimesnumericUpDown";
            this.PointListRepeatTimesnumericUpDown.Size = new System.Drawing.Size(103, 22);
            this.PointListRepeatTimesnumericUpDown.TabIndex = 161;
            // 
            // groupBox24
            // 
            this.groupBox24.Location = new System.Drawing.Point(-20, -96);
            this.groupBox24.Name = "groupBox24";
            this.groupBox24.Size = new System.Drawing.Size(200, 100);
            this.groupBox24.TabIndex = 177;
            this.groupBox24.TabStop = false;
            this.groupBox24.Text = "groupBox24";
            // 
            // CalibrationgroupBox
            // 
            this.CalibrationgroupBox.Controls.Add(this.CorrectMethodcomboBox);
            this.CalibrationgroupBox.Controls.Add(this.label86);
            this.CalibrationgroupBox.Controls.Add(this.CalibrationSelectcomboBox);
            this.CalibrationgroupBox.Controls.Add(this.label93);
            this.CalibrationgroupBox.Controls.Add(this.RtcMarkParagroupBox);
            this.CalibrationgroupBox.Controls.Add(this.YAffinitytextBox);
            this.CalibrationgroupBox.Controls.Add(this.label90);
            this.CalibrationgroupBox.Controls.Add(this.YCalibratetextBox);
            this.CalibrationgroupBox.Controls.Add(this.label91);
            this.CalibrationgroupBox.Controls.Add(this.XAffinitytextBox);
            this.CalibrationgroupBox.Controls.Add(this.label89);
            this.CalibrationgroupBox.Controls.Add(this.XCalibratetextBox);
            this.CalibrationgroupBox.Controls.Add(this.label83);
            this.CalibrationgroupBox.Controls.Add(this.label62);
            this.CalibrationgroupBox.Controls.Add(this.YCellnumericUpDown);
            this.CalibrationgroupBox.Controls.Add(this.label70);
            this.CalibrationgroupBox.Controls.Add(this.XCellnumericUpDown);
            this.CalibrationgroupBox.Controls.Add(this.label72);
            this.CalibrationgroupBox.Controls.Add(this.YLengthnumericUpDown);
            this.CalibrationgroupBox.Controls.Add(this.label82);
            this.CalibrationgroupBox.Controls.Add(this.XLengthnumericUpDown);
            this.CalibrationgroupBox.Location = new System.Drawing.Point(348, 150);
            this.CalibrationgroupBox.Name = "CalibrationgroupBox";
            this.CalibrationgroupBox.Size = new System.Drawing.Size(261, 351);
            this.CalibrationgroupBox.TabIndex = 176;
            this.CalibrationgroupBox.TabStop = false;
            this.CalibrationgroupBox.Text = "校准";
            // 
            // CorrectMethodcomboBox
            // 
            this.CorrectMethodcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CorrectMethodcomboBox.FormattingEnabled = true;
            this.CorrectMethodcomboBox.Items.AddRange(new object[] {
            "3点",
            "4点"});
            this.CorrectMethodcomboBox.Location = new System.Drawing.Point(108, 50);
            this.CorrectMethodcomboBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.CorrectMethodcomboBox.Name = "CorrectMethodcomboBox";
            this.CorrectMethodcomboBox.Size = new System.Drawing.Size(87, 22);
            this.CorrectMethodcomboBox.TabIndex = 178;
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.Location = new System.Drawing.Point(39, 54);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(55, 14);
            this.label86.TabIndex = 179;
            this.label86.Text = "校准方式";
            // 
            // CalibrationSelectcomboBox
            // 
            this.CalibrationSelectcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CalibrationSelectcomboBox.FormattingEnabled = true;
            this.CalibrationSelectcomboBox.Items.AddRange(new object[] {
            "平台",
            "振镜"});
            this.CalibrationSelectcomboBox.Location = new System.Drawing.Point(108, 20);
            this.CalibrationSelectcomboBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.CalibrationSelectcomboBox.Name = "CalibrationSelectcomboBox";
            this.CalibrationSelectcomboBox.Size = new System.Drawing.Size(87, 22);
            this.CalibrationSelectcomboBox.TabIndex = 167;
            // 
            // label93
            // 
            this.label93.AutoSize = true;
            this.label93.Location = new System.Drawing.Point(39, 24);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(55, 14);
            this.label93.TabIndex = 168;
            this.label93.Text = "标定位置";
            // 
            // RtcMarkParagroupBox
            // 
            this.RtcMarkParagroupBox.Controls.Add(this.RtcCorrectTypecheckBox);
            this.RtcMarkParagroupBox.Controls.Add(this.RtcCircleRadiusLabel);
            this.RtcMarkParagroupBox.Controls.Add(this.RtcMarkTypecomboBox);
            this.RtcMarkParagroupBox.Controls.Add(this.RtcCircleRadiusnumericUpDown);
            this.RtcMarkParagroupBox.Controls.Add(this.label92);
            this.RtcMarkParagroupBox.Controls.Add(this.RtcAligncheckBox);
            this.RtcMarkParagroupBox.Location = new System.Drawing.Point(0, 257);
            this.RtcMarkParagroupBox.Name = "RtcMarkParagroupBox";
            this.RtcMarkParagroupBox.Size = new System.Drawing.Size(261, 93);
            this.RtcMarkParagroupBox.TabIndex = 177;
            this.RtcMarkParagroupBox.TabStop = false;
            this.RtcMarkParagroupBox.Text = "打标参数";
            // 
            // RtcCorrectTypecheckBox
            // 
            this.RtcCorrectTypecheckBox.AutoSize = true;
            this.RtcCorrectTypecheckBox.Location = new System.Drawing.Point(181, 61);
            this.RtcCorrectTypecheckBox.Name = "RtcCorrectTypecheckBox";
            this.RtcCorrectTypecheckBox.Size = new System.Drawing.Size(74, 18);
            this.RtcCorrectTypecheckBox.TabIndex = 167;
            this.RtcCorrectTypecheckBox.Text = "仿射校准";
            this.RtcCorrectTypecheckBox.UseVisualStyleBackColor = true;
            // 
            // RtcCircleRadiusLabel
            // 
            this.RtcCircleRadiusLabel.AutoSize = true;
            this.RtcCircleRadiusLabel.Location = new System.Drawing.Point(15, 63);
            this.RtcCircleRadiusLabel.Name = "RtcCircleRadiusLabel";
            this.RtcCircleRadiusLabel.Size = new System.Drawing.Size(43, 14);
            this.RtcCircleRadiusLabel.TabIndex = 166;
            this.RtcCircleRadiusLabel.Text = "圆半径";
            // 
            // RtcMarkTypecomboBox
            // 
            this.RtcMarkTypecomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RtcMarkTypecomboBox.FormattingEnabled = true;
            this.RtcMarkTypecomboBox.Items.AddRange(new object[] {
            "圆",
            "直线"});
            this.RtcMarkTypecomboBox.Location = new System.Drawing.Point(83, 24);
            this.RtcMarkTypecomboBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.RtcMarkTypecomboBox.Name = "RtcMarkTypecomboBox";
            this.RtcMarkTypecomboBox.Size = new System.Drawing.Size(87, 22);
            this.RtcMarkTypecomboBox.TabIndex = 162;
            // 
            // RtcCircleRadiusnumericUpDown
            // 
            this.RtcCircleRadiusnumericUpDown.DecimalPlaces = 2;
            this.RtcCircleRadiusnumericUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.RtcCircleRadiusnumericUpDown.Location = new System.Drawing.Point(83, 59);
            this.RtcCircleRadiusnumericUpDown.Maximum = new decimal(new int[] {
            45,
            0,
            0,
            65536});
            this.RtcCircleRadiusnumericUpDown.Name = "RtcCircleRadiusnumericUpDown";
            this.RtcCircleRadiusnumericUpDown.Size = new System.Drawing.Size(87, 22);
            this.RtcCircleRadiusnumericUpDown.TabIndex = 165;
            this.RtcCircleRadiusnumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label92
            // 
            this.label92.AutoSize = true;
            this.label92.Location = new System.Drawing.Point(15, 28);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(55, 14);
            this.label92.TabIndex = 163;
            this.label92.Text = "打标类型";
            // 
            // RtcAligncheckBox
            // 
            this.RtcAligncheckBox.AutoSize = true;
            this.RtcAligncheckBox.Location = new System.Drawing.Point(181, 26);
            this.RtcAligncheckBox.Name = "RtcAligncheckBox";
            this.RtcAligncheckBox.Size = new System.Drawing.Size(74, 18);
            this.RtcAligncheckBox.TabIndex = 164;
            this.RtcAligncheckBox.Text = "对齐校准";
            this.RtcAligncheckBox.UseVisualStyleBackColor = true;
            // 
            // YAffinitytextBox
            // 
            this.YAffinitytextBox.Location = new System.Drawing.Point(159, 229);
            this.YAffinitytextBox.Name = "YAffinitytextBox";
            this.YAffinitytextBox.ReadOnly = true;
            this.YAffinitytextBox.Size = new System.Drawing.Size(87, 22);
            this.YAffinitytextBox.TabIndex = 15;
            // 
            // label90
            // 
            this.label90.AutoSize = true;
            this.label90.Location = new System.Drawing.Point(170, 211);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(63, 14);
            this.label90.TabIndex = 14;
            this.label90.Text = "Y校准数值";
            // 
            // YCalibratetextBox
            // 
            this.YCalibratetextBox.Location = new System.Drawing.Point(159, 185);
            this.YCalibratetextBox.Name = "YCalibratetextBox";
            this.YCalibratetextBox.ReadOnly = true;
            this.YCalibratetextBox.Size = new System.Drawing.Size(87, 22);
            this.YCalibratetextBox.TabIndex = 13;
            // 
            // label91
            // 
            this.label91.AutoSize = true;
            this.label91.Location = new System.Drawing.Point(171, 167);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(63, 14);
            this.label91.TabIndex = 12;
            this.label91.Text = "Y基准数值";
            // 
            // XAffinitytextBox
            // 
            this.XAffinitytextBox.Location = new System.Drawing.Point(24, 229);
            this.XAffinitytextBox.Name = "XAffinitytextBox";
            this.XAffinitytextBox.ReadOnly = true;
            this.XAffinitytextBox.Size = new System.Drawing.Size(87, 22);
            this.XAffinitytextBox.TabIndex = 11;
            // 
            // label89
            // 
            this.label89.AutoSize = true;
            this.label89.Location = new System.Drawing.Point(35, 211);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(62, 14);
            this.label89.TabIndex = 10;
            this.label89.Text = "X校准数值";
            // 
            // XCalibratetextBox
            // 
            this.XCalibratetextBox.Location = new System.Drawing.Point(24, 185);
            this.XCalibratetextBox.Name = "XCalibratetextBox";
            this.XCalibratetextBox.ReadOnly = true;
            this.XCalibratetextBox.Size = new System.Drawing.Size(87, 22);
            this.XCalibratetextBox.TabIndex = 9;
            // 
            // label83
            // 
            this.label83.AutoSize = true;
            this.label83.Location = new System.Drawing.Point(36, 167);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(62, 14);
            this.label83.TabIndex = 8;
            this.label83.Text = "X基准数值";
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(171, 123);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(63, 14);
            this.label62.TabIndex = 7;
            this.label62.Text = "Y标定间距";
            // 
            // YCellnumericUpDown
            // 
            this.YCellnumericUpDown.DecimalPlaces = 2;
            this.YCellnumericUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.YCellnumericUpDown.Location = new System.Drawing.Point(159, 141);
            this.YCellnumericUpDown.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.YCellnumericUpDown.Name = "YCellnumericUpDown";
            this.YCellnumericUpDown.Size = new System.Drawing.Size(87, 22);
            this.YCellnumericUpDown.TabIndex = 6;
            this.YCellnumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Location = new System.Drawing.Point(35, 123);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(62, 14);
            this.label70.TabIndex = 5;
            this.label70.Text = "X标定间距";
            // 
            // XCellnumericUpDown
            // 
            this.XCellnumericUpDown.DecimalPlaces = 2;
            this.XCellnumericUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.XCellnumericUpDown.Location = new System.Drawing.Point(24, 141);
            this.XCellnumericUpDown.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.XCellnumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.XCellnumericUpDown.Name = "XCellnumericUpDown";
            this.XCellnumericUpDown.Size = new System.Drawing.Size(87, 22);
            this.XCellnumericUpDown.TabIndex = 4;
            this.XCellnumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Location = new System.Drawing.Point(177, 79);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(51, 14);
            this.label72.TabIndex = 3;
            this.label72.Text = "Y轴长度";
            // 
            // YLengthnumericUpDown
            // 
            this.YLengthnumericUpDown.DecimalPlaces = 2;
            this.YLengthnumericUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.YLengthnumericUpDown.Location = new System.Drawing.Point(159, 97);
            this.YLengthnumericUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.YLengthnumericUpDown.Name = "YLengthnumericUpDown";
            this.YLengthnumericUpDown.Size = new System.Drawing.Size(87, 22);
            this.YLengthnumericUpDown.TabIndex = 2;
            this.YLengthnumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label82
            // 
            this.label82.AutoSize = true;
            this.label82.Location = new System.Drawing.Point(41, 79);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(50, 14);
            this.label82.TabIndex = 1;
            this.label82.Text = "X轴长度";
            // 
            // XLengthnumericUpDown
            // 
            this.XLengthnumericUpDown.DecimalPlaces = 2;
            this.XLengthnumericUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.XLengthnumericUpDown.Location = new System.Drawing.Point(24, 97);
            this.XLengthnumericUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.XLengthnumericUpDown.Name = "XLengthnumericUpDown";
            this.XLengthnumericUpDown.Size = new System.Drawing.Size(87, 22);
            this.XLengthnumericUpDown.TabIndex = 0;
            this.XLengthnumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBox25
            // 
            this.groupBox25.Controls.Add(this.MarkJumpcheckBox);
            this.groupBox25.Controls.Add(this.CamEncheckBox);
            this.groupBox25.Controls.Add(this.label64);
            this.groupBox25.Controls.Add(this.ShieldbeepTimenumericUpDown);
            this.groupBox25.Location = new System.Drawing.Point(29, 195);
            this.groupBox25.Name = "groupBox25";
            this.groupBox25.Size = new System.Drawing.Size(261, 109);
            this.groupBox25.TabIndex = 175;
            this.groupBox25.TabStop = false;
            this.groupBox25.Text = "其他参数";
            // 
            // MarkJumpcheckBox
            // 
            this.MarkJumpcheckBox.AutoSize = true;
            this.MarkJumpcheckBox.Location = new System.Drawing.Point(20, 35);
            this.MarkJumpcheckBox.Name = "MarkJumpcheckBox";
            this.MarkJumpcheckBox.Size = new System.Drawing.Size(98, 18);
            this.MarkJumpcheckBox.TabIndex = 132;
            this.MarkJumpcheckBox.Text = "红光加工预览";
            this.MarkJumpcheckBox.UseVisualStyleBackColor = true;
            // 
            // CamEncheckBox
            // 
            this.CamEncheckBox.AutoSize = true;
            this.CamEncheckBox.Location = new System.Drawing.Point(167, 35);
            this.CamEncheckBox.Name = "CamEncheckBox";
            this.CamEncheckBox.Size = new System.Drawing.Size(74, 18);
            this.CamEncheckBox.TabIndex = 133;
            this.CamEncheckBox.Text = "启用相机";
            this.CamEncheckBox.UseVisualStyleBackColor = true;
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(18, 72);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(103, 14);
            this.label64.TabIndex = 160;
            this.label64.Text = "蜂鸣器屏蔽时长/S";
            // 
            // ShieldbeepTimenumericUpDown
            // 
            this.ShieldbeepTimenumericUpDown.Increment = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.ShieldbeepTimenumericUpDown.Location = new System.Drawing.Point(139, 68);
            this.ShieldbeepTimenumericUpDown.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.ShieldbeepTimenumericUpDown.Name = "ShieldbeepTimenumericUpDown";
            this.ShieldbeepTimenumericUpDown.Size = new System.Drawing.Size(103, 22);
            this.ShieldbeepTimenumericUpDown.TabIndex = 159;
            // 
            // DebugMenugroupBox
            // 
            this.DebugMenugroupBox.Controls.Add(this.groupBox23);
            this.DebugMenugroupBox.Controls.Add(this.groupBox21);
            this.DebugMenugroupBox.Controls.Add(this.SysParaSave);
            this.DebugMenugroupBox.Controls.Add(this.SyaParaRead);
            this.DebugMenugroupBox.Location = new System.Drawing.Point(29, 331);
            this.DebugMenugroupBox.Name = "DebugMenugroupBox";
            this.DebugMenugroupBox.Size = new System.Drawing.Size(261, 276);
            this.DebugMenugroupBox.TabIndex = 174;
            this.DebugMenugroupBox.TabStop = false;
            this.DebugMenugroupBox.Text = "调试菜单";
            // 
            // groupBox23
            // 
            this.groupBox23.Controls.Add(this.ApplyRtcXmlCorrectFilebutton);
            this.groupBox23.Controls.Add(this.SelectRtcXmlCorrectFilebutton);
            this.groupBox23.Controls.Add(this.RtcXmlCorrectFilePathtextBox);
            this.groupBox23.Location = new System.Drawing.Point(15, 131);
            this.groupBox23.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox23.Name = "groupBox23";
            this.groupBox23.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox23.Size = new System.Drawing.Size(230, 94);
            this.groupBox23.TabIndex = 163;
            this.groupBox23.TabStop = false;
            this.groupBox23.Text = "加载振镜坐标系校准文件（*xml）";
            // 
            // ApplyRtcXmlCorrectFilebutton
            // 
            this.ApplyRtcXmlCorrectFilebutton.Location = new System.Drawing.Point(145, 59);
            this.ApplyRtcXmlCorrectFilebutton.Margin = new System.Windows.Forms.Padding(2);
            this.ApplyRtcXmlCorrectFilebutton.Name = "ApplyRtcXmlCorrectFilebutton";
            this.ApplyRtcXmlCorrectFilebutton.Size = new System.Drawing.Size(66, 29);
            this.ApplyRtcXmlCorrectFilebutton.TabIndex = 1;
            this.ApplyRtcXmlCorrectFilebutton.Text = "应用";
            this.ApplyRtcXmlCorrectFilebutton.UseVisualStyleBackColor = true;
            this.ApplyRtcXmlCorrectFilebutton.Click += new System.EventHandler(this.ApplyRtcCorrectFilebutton_Click);
            // 
            // SelectRtcXmlCorrectFilebutton
            // 
            this.SelectRtcXmlCorrectFilebutton.Location = new System.Drawing.Point(12, 59);
            this.SelectRtcXmlCorrectFilebutton.Margin = new System.Windows.Forms.Padding(2);
            this.SelectRtcXmlCorrectFilebutton.Name = "SelectRtcXmlCorrectFilebutton";
            this.SelectRtcXmlCorrectFilebutton.Size = new System.Drawing.Size(66, 29);
            this.SelectRtcXmlCorrectFilebutton.TabIndex = 1;
            this.SelectRtcXmlCorrectFilebutton.Text = "open";
            this.SelectRtcXmlCorrectFilebutton.UseVisualStyleBackColor = true;
            this.SelectRtcXmlCorrectFilebutton.Click += new System.EventHandler(this.SelectRtcCorrectFilebutton_Click);
            // 
            // RtcXmlCorrectFilePathtextBox
            // 
            this.RtcXmlCorrectFilePathtextBox.Location = new System.Drawing.Point(12, 26);
            this.RtcXmlCorrectFilePathtextBox.Margin = new System.Windows.Forms.Padding(2);
            this.RtcXmlCorrectFilePathtextBox.Name = "RtcXmlCorrectFilePathtextBox";
            this.RtcXmlCorrectFilePathtextBox.ReadOnly = true;
            this.RtcXmlCorrectFilePathtextBox.Size = new System.Drawing.Size(202, 22);
            this.RtcXmlCorrectFilePathtextBox.TabIndex = 0;
            // 
            // groupBox21
            // 
            this.groupBox21.Controls.Add(this.ApplyGtsCorrectFilebutton);
            this.groupBox21.Controls.Add(this.SelectGtsCorrectFilebutton);
            this.groupBox21.Controls.Add(this.GtsCorrectFilePathtextBox);
            this.groupBox21.Location = new System.Drawing.Point(15, 25);
            this.groupBox21.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox21.Size = new System.Drawing.Size(230, 94);
            this.groupBox21.TabIndex = 162;
            this.groupBox21.TabStop = false;
            this.groupBox21.Text = "加载平台校准文件（*xml）";
            // 
            // ApplyGtsCorrectFilebutton
            // 
            this.ApplyGtsCorrectFilebutton.Location = new System.Drawing.Point(145, 59);
            this.ApplyGtsCorrectFilebutton.Margin = new System.Windows.Forms.Padding(2);
            this.ApplyGtsCorrectFilebutton.Name = "ApplyGtsCorrectFilebutton";
            this.ApplyGtsCorrectFilebutton.Size = new System.Drawing.Size(66, 29);
            this.ApplyGtsCorrectFilebutton.TabIndex = 1;
            this.ApplyGtsCorrectFilebutton.Text = "应用";
            this.ApplyGtsCorrectFilebutton.UseVisualStyleBackColor = true;
            this.ApplyGtsCorrectFilebutton.Click += new System.EventHandler(this.ApplyGtsCorrectFilebutton_Click);
            // 
            // SelectGtsCorrectFilebutton
            // 
            this.SelectGtsCorrectFilebutton.Location = new System.Drawing.Point(12, 59);
            this.SelectGtsCorrectFilebutton.Margin = new System.Windows.Forms.Padding(2);
            this.SelectGtsCorrectFilebutton.Name = "SelectGtsCorrectFilebutton";
            this.SelectGtsCorrectFilebutton.Size = new System.Drawing.Size(66, 29);
            this.SelectGtsCorrectFilebutton.TabIndex = 1;
            this.SelectGtsCorrectFilebutton.Text = "open";
            this.SelectGtsCorrectFilebutton.UseVisualStyleBackColor = true;
            this.SelectGtsCorrectFilebutton.Click += new System.EventHandler(this.SelectGtsCorrectFilebutton_Click);
            // 
            // GtsCorrectFilePathtextBox
            // 
            this.GtsCorrectFilePathtextBox.Location = new System.Drawing.Point(12, 26);
            this.GtsCorrectFilePathtextBox.Margin = new System.Windows.Forms.Padding(2);
            this.GtsCorrectFilePathtextBox.Name = "GtsCorrectFilePathtextBox";
            this.GtsCorrectFilePathtextBox.ReadOnly = true;
            this.GtsCorrectFilePathtextBox.Size = new System.Drawing.Size(202, 22);
            this.GtsCorrectFilePathtextBox.TabIndex = 0;
            // 
            // SysParaSave
            // 
            this.SysParaSave.Location = new System.Drawing.Point(15, 233);
            this.SysParaSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SysParaSave.Name = "SysParaSave";
            this.SysParaSave.Size = new System.Drawing.Size(102, 36);
            this.SysParaSave.TabIndex = 71;
            this.SysParaSave.Text = "系统参数保存";
            this.SysParaSave.UseVisualStyleBackColor = true;
            this.SysParaSave.Click += new System.EventHandler(this.SysParaSave_Click);
            // 
            // SyaParaRead
            // 
            this.SyaParaRead.Location = new System.Drawing.Point(143, 231);
            this.SyaParaRead.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SyaParaRead.Name = "SyaParaRead";
            this.SyaParaRead.Size = new System.Drawing.Size(102, 36);
            this.SyaParaRead.TabIndex = 72;
            this.SyaParaRead.Text = "系统参数读取";
            this.SyaParaRead.UseVisualStyleBackColor = true;
            this.SyaParaRead.Click += new System.EventHandler(this.SyaParaRead_Click);
            // 
            // CoordinategroupBox
            // 
            this.CoordinategroupBox.Controls.Add(this.label81);
            this.CoordinategroupBox.Controls.Add(this.label80);
            this.CoordinategroupBox.Controls.Add(this.RtcOrgDistanceYnumericUpDown);
            this.CoordinategroupBox.Controls.Add(this.WorkXnumericUpDown);
            this.CoordinategroupBox.Controls.Add(this.WorkYnumericUpDown);
            this.CoordinategroupBox.Controls.Add(this.RtcOrgDistanceXnumericUpDown);
            this.CoordinategroupBox.Controls.Add(this.label69);
            this.CoordinategroupBox.Controls.Add(this.label71);
            this.CoordinategroupBox.Location = new System.Drawing.Point(29, 9);
            this.CoordinategroupBox.Name = "CoordinategroupBox";
            this.CoordinategroupBox.Size = new System.Drawing.Size(261, 159);
            this.CoordinategroupBox.TabIndex = 173;
            this.CoordinategroupBox.TabStop = false;
            this.CoordinategroupBox.Text = "坐标系参数";
            // 
            // label81
            // 
            this.label81.AutoSize = true;
            this.label81.Location = new System.Drawing.Point(15, 27);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(99, 14);
            this.label81.TabIndex = 32;
            this.label81.Text = "加工坐标系X/mm\r\n";
            // 
            // label80
            // 
            this.label80.AutoSize = true;
            this.label80.Location = new System.Drawing.Point(143, 27);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(100, 14);
            this.label80.TabIndex = 34;
            this.label80.Text = "加工坐标系Y/mm";
            // 
            // RtcOrgDistanceYnumericUpDown
            // 
            this.RtcOrgDistanceYnumericUpDown.DecimalPlaces = 8;
            this.RtcOrgDistanceYnumericUpDown.Increment = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.RtcOrgDistanceYnumericUpDown.Location = new System.Drawing.Point(142, 114);
            this.RtcOrgDistanceYnumericUpDown.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.RtcOrgDistanceYnumericUpDown.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.RtcOrgDistanceYnumericUpDown.Name = "RtcOrgDistanceYnumericUpDown";
            this.RtcOrgDistanceYnumericUpDown.Size = new System.Drawing.Size(103, 22);
            this.RtcOrgDistanceYnumericUpDown.TabIndex = 163;
            // 
            // WorkXnumericUpDown
            // 
            this.WorkXnumericUpDown.DecimalPlaces = 8;
            this.WorkXnumericUpDown.Increment = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.WorkXnumericUpDown.Location = new System.Drawing.Point(13, 50);
            this.WorkXnumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.WorkXnumericUpDown.Name = "WorkXnumericUpDown";
            this.WorkXnumericUpDown.Size = new System.Drawing.Size(103, 22);
            this.WorkXnumericUpDown.TabIndex = 164;
            // 
            // WorkYnumericUpDown
            // 
            this.WorkYnumericUpDown.DecimalPlaces = 8;
            this.WorkYnumericUpDown.Increment = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.WorkYnumericUpDown.Location = new System.Drawing.Point(142, 50);
            this.WorkYnumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.WorkYnumericUpDown.Name = "WorkYnumericUpDown";
            this.WorkYnumericUpDown.Size = new System.Drawing.Size(103, 22);
            this.WorkYnumericUpDown.TabIndex = 165;
            // 
            // RtcOrgDistanceXnumericUpDown
            // 
            this.RtcOrgDistanceXnumericUpDown.DecimalPlaces = 8;
            this.RtcOrgDistanceXnumericUpDown.Increment = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.RtcOrgDistanceXnumericUpDown.Location = new System.Drawing.Point(13, 114);
            this.RtcOrgDistanceXnumericUpDown.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.RtcOrgDistanceXnumericUpDown.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.RtcOrgDistanceXnumericUpDown.Name = "RtcOrgDistanceXnumericUpDown";
            this.RtcOrgDistanceXnumericUpDown.Size = new System.Drawing.Size(103, 22);
            this.RtcOrgDistanceXnumericUpDown.TabIndex = 162;
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Location = new System.Drawing.Point(137, 92);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(112, 14);
            this.label69.TabIndex = 97;
            this.label69.Text = "振镜偏心距离Y/mm";
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Location = new System.Drawing.Point(9, 92);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(111, 14);
            this.label71.TabIndex = 95;
            this.label71.Text = "振镜偏心距离X/mm";
            // 
            // WorkPara
            // 
            this.WorkPara.Caption = "加工参数";
            this.WorkPara.Controls.Add(this.groupBox_safety);
            this.WorkPara.Controls.Add(this.groupBox_convention);
            this.WorkPara.Controls.Add(this.groupBox_vacuo);
            this.WorkPara.Controls.Add(this.groupBox_Door);
            this.WorkPara.Controls.Add(this.groupBox_Scissor);
            this.WorkPara.Controls.Add(this.groupBox_count);
            this.WorkPara.Controls.Add(this.groupBox_Z);
            this.WorkPara.Controls.Add(this.groupBox_PrpcessEnd);
            this.WorkPara.Name = "WorkPara";
            this.WorkPara.Size = new System.Drawing.Size(1356, 636);
            // 
            // groupBox_safety
            // 
            this.groupBox_safety.Controls.Add(this.CBox_SysSet_Safe_MoveEntrench);
            this.groupBox_safety.Controls.Add(this.CBox_SysSet_Safe_Baffle);
            this.groupBox_safety.Controls.Add(this.CBox_SysSet_Safe_prpcessingDoor);
            this.groupBox_safety.Controls.Add(this.CBox_SysSet_Safe_CloseDoorEntrench);
            this.groupBox_safety.Controls.Add(this.CBox_SysSet_Safe_OpenDoorEntrench);
            this.groupBox_safety.Location = new System.Drawing.Point(447, 205);
            this.groupBox_safety.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox_safety.Name = "groupBox_safety";
            this.groupBox_safety.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox_safety.Size = new System.Drawing.Size(178, 145);
            this.groupBox_safety.TabIndex = 13;
            this.groupBox_safety.TabStop = false;
            this.groupBox_safety.Text = "安全";
            // 
            // CBox_SysSet_Safe_MoveEntrench
            // 
            this.CBox_SysSet_Safe_MoveEntrench.AutoSize = true;
            this.CBox_SysSet_Safe_MoveEntrench.Location = new System.Drawing.Point(11, 70);
            this.CBox_SysSet_Safe_MoveEntrench.Margin = new System.Windows.Forms.Padding(2);
            this.CBox_SysSet_Safe_MoveEntrench.Name = "CBox_SysSet_Safe_MoveEntrench";
            this.CBox_SysSet_Safe_MoveEntrench.Size = new System.Drawing.Size(122, 18);
            this.CBox_SysSet_Safe_MoveEntrench.TabIndex = 0;
            this.CBox_SysSet_Safe_MoveEntrench.Text = "启用运动安全防护";
            this.CBox_SysSet_Safe_MoveEntrench.UseVisualStyleBackColor = true;
            // 
            // CBox_SysSet_Safe_Baffle
            // 
            this.CBox_SysSet_Safe_Baffle.AutoSize = true;
            this.CBox_SysSet_Safe_Baffle.Location = new System.Drawing.Point(11, 18);
            this.CBox_SysSet_Safe_Baffle.Margin = new System.Windows.Forms.Padding(2);
            this.CBox_SysSet_Safe_Baffle.Name = "CBox_SysSet_Safe_Baffle";
            this.CBox_SysSet_Safe_Baffle.Size = new System.Drawing.Size(122, 18);
            this.CBox_SysSet_Safe_Baffle.TabIndex = 0;
            this.CBox_SysSet_Safe_Baffle.Text = "启用激光挡板功能";
            this.CBox_SysSet_Safe_Baffle.UseVisualStyleBackColor = true;
            // 
            // CBox_SysSet_Safe_prpcessingDoor
            // 
            this.CBox_SysSet_Safe_prpcessingDoor.AutoSize = true;
            this.CBox_SysSet_Safe_prpcessingDoor.Location = new System.Drawing.Point(11, 44);
            this.CBox_SysSet_Safe_prpcessingDoor.Margin = new System.Windows.Forms.Padding(2);
            this.CBox_SysSet_Safe_prpcessingDoor.Name = "CBox_SysSet_Safe_prpcessingDoor";
            this.CBox_SysSet_Safe_prpcessingDoor.Size = new System.Drawing.Size(134, 18);
            this.CBox_SysSet_Safe_prpcessingDoor.TabIndex = 0;
            this.CBox_SysSet_Safe_prpcessingDoor.Text = "加工时检测仓门状态";
            this.CBox_SysSet_Safe_prpcessingDoor.UseVisualStyleBackColor = true;
            // 
            // CBox_SysSet_Safe_CloseDoorEntrench
            // 
            this.CBox_SysSet_Safe_CloseDoorEntrench.AutoSize = true;
            this.CBox_SysSet_Safe_CloseDoorEntrench.Location = new System.Drawing.Point(11, 121);
            this.CBox_SysSet_Safe_CloseDoorEntrench.Margin = new System.Windows.Forms.Padding(2);
            this.CBox_SysSet_Safe_CloseDoorEntrench.Name = "CBox_SysSet_Safe_CloseDoorEntrench";
            this.CBox_SysSet_Safe_CloseDoorEntrench.Size = new System.Drawing.Size(122, 18);
            this.CBox_SysSet_Safe_CloseDoorEntrench.TabIndex = 0;
            this.CBox_SysSet_Safe_CloseDoorEntrench.Text = "启用关门安全防护";
            this.CBox_SysSet_Safe_CloseDoorEntrench.UseVisualStyleBackColor = true;
            // 
            // CBox_SysSet_Safe_OpenDoorEntrench
            // 
            this.CBox_SysSet_Safe_OpenDoorEntrench.AutoSize = true;
            this.CBox_SysSet_Safe_OpenDoorEntrench.Location = new System.Drawing.Point(11, 95);
            this.CBox_SysSet_Safe_OpenDoorEntrench.Margin = new System.Windows.Forms.Padding(2);
            this.CBox_SysSet_Safe_OpenDoorEntrench.Name = "CBox_SysSet_Safe_OpenDoorEntrench";
            this.CBox_SysSet_Safe_OpenDoorEntrench.Size = new System.Drawing.Size(122, 18);
            this.CBox_SysSet_Safe_OpenDoorEntrench.TabIndex = 0;
            this.CBox_SysSet_Safe_OpenDoorEntrench.Text = "启用开门安全防护";
            this.CBox_SysSet_Safe_OpenDoorEntrench.UseVisualStyleBackColor = true;
            // 
            // groupBox_convention
            // 
            this.groupBox_convention.Controls.Add(this.CBox_SysSet_Convention_prpcessEndAlarm);
            this.groupBox_convention.Controls.Add(this.CBox_SysSet_Convention_ChillerTem);
            this.groupBox_convention.Controls.Add(this.CBox_SysSet_Convention_prpcessEndDlg);
            this.groupBox_convention.Controls.Add(this.CBox_SysSet_Convention_Laserstate);
            this.groupBox_convention.Controls.Add(this.CBox_SysSet_Convention_Autolight);
            this.groupBox_convention.Location = new System.Drawing.Point(447, 15);
            this.groupBox_convention.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox_convention.Name = "groupBox_convention";
            this.groupBox_convention.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox_convention.Size = new System.Drawing.Size(178, 154);
            this.groupBox_convention.TabIndex = 14;
            this.groupBox_convention.TabStop = false;
            this.groupBox_convention.Text = "常规";
            // 
            // CBox_SysSet_Convention_prpcessEndAlarm
            // 
            this.CBox_SysSet_Convention_prpcessEndAlarm.AutoSize = true;
            this.CBox_SysSet_Convention_prpcessEndAlarm.Location = new System.Drawing.Point(11, 101);
            this.CBox_SysSet_Convention_prpcessEndAlarm.Margin = new System.Windows.Forms.Padding(2);
            this.CBox_SysSet_Convention_prpcessEndAlarm.Name = "CBox_SysSet_Convention_prpcessEndAlarm";
            this.CBox_SysSet_Convention_prpcessEndAlarm.Size = new System.Drawing.Size(158, 18);
            this.CBox_SysSet_Convention_prpcessEndAlarm.TabIndex = 0;
            this.CBox_SysSet_Convention_prpcessEndAlarm.Text = "启用加工结束后报警提醒";
            this.CBox_SysSet_Convention_prpcessEndAlarm.UseVisualStyleBackColor = true;
            // 
            // CBox_SysSet_Convention_ChillerTem
            // 
            this.CBox_SysSet_Convention_ChillerTem.AutoSize = true;
            this.CBox_SysSet_Convention_ChillerTem.Location = new System.Drawing.Point(11, 22);
            this.CBox_SysSet_Convention_ChillerTem.Margin = new System.Windows.Forms.Padding(2);
            this.CBox_SysSet_Convention_ChillerTem.Name = "CBox_SysSet_Convention_ChillerTem";
            this.CBox_SysSet_Convention_ChillerTem.Size = new System.Drawing.Size(146, 18);
            this.CBox_SysSet_Convention_ChillerTem.TabIndex = 0;
            this.CBox_SysSet_Convention_ChillerTem.Text = "启动后检查冷水机温度";
            this.CBox_SysSet_Convention_ChillerTem.UseVisualStyleBackColor = true;
            // 
            // CBox_SysSet_Convention_prpcessEndDlg
            // 
            this.CBox_SysSet_Convention_prpcessEndDlg.AutoSize = true;
            this.CBox_SysSet_Convention_prpcessEndDlg.Location = new System.Drawing.Point(11, 127);
            this.CBox_SysSet_Convention_prpcessEndDlg.Margin = new System.Windows.Forms.Padding(2);
            this.CBox_SysSet_Convention_prpcessEndDlg.Name = "CBox_SysSet_Convention_prpcessEndDlg";
            this.CBox_SysSet_Convention_prpcessEndDlg.Size = new System.Drawing.Size(170, 18);
            this.CBox_SysSet_Convention_prpcessEndDlg.TabIndex = 0;
            this.CBox_SysSet_Convention_prpcessEndDlg.Text = "启用加工结束后对话框提醒";
            this.CBox_SysSet_Convention_prpcessEndDlg.UseVisualStyleBackColor = true;
            // 
            // CBox_SysSet_Convention_Laserstate
            // 
            this.CBox_SysSet_Convention_Laserstate.AutoSize = true;
            this.CBox_SysSet_Convention_Laserstate.Location = new System.Drawing.Point(11, 74);
            this.CBox_SysSet_Convention_Laserstate.Margin = new System.Windows.Forms.Padding(2);
            this.CBox_SysSet_Convention_Laserstate.Name = "CBox_SysSet_Convention_Laserstate";
            this.CBox_SysSet_Convention_Laserstate.Size = new System.Drawing.Size(146, 18);
            this.CBox_SysSet_Convention_Laserstate.TabIndex = 0;
            this.CBox_SysSet_Convention_Laserstate.Text = "加工前检查激光器状态";
            this.CBox_SysSet_Convention_Laserstate.UseVisualStyleBackColor = true;
            // 
            // CBox_SysSet_Convention_Autolight
            // 
            this.CBox_SysSet_Convention_Autolight.AutoSize = true;
            this.CBox_SysSet_Convention_Autolight.Location = new System.Drawing.Point(11, 48);
            this.CBox_SysSet_Convention_Autolight.Margin = new System.Windows.Forms.Padding(2);
            this.CBox_SysSet_Convention_Autolight.Name = "CBox_SysSet_Convention_Autolight";
            this.CBox_SysSet_Convention_Autolight.Size = new System.Drawing.Size(146, 18);
            this.CBox_SysSet_Convention_Autolight.TabIndex = 0;
            this.CBox_SysSet_Convention_Autolight.Text = "加工时自动开辅助照明";
            this.CBox_SysSet_Convention_Autolight.UseVisualStyleBackColor = true;
            // 
            // groupBox_vacuo
            // 
            this.groupBox_vacuo.Controls.Add(this.NumUD_SysSet_vacuum_Enddelayed);
            this.groupBox_vacuo.Controls.Add(this.CBox_SysSet_Vacuum_Pressure);
            this.groupBox_vacuo.Controls.Add(this.NumUD_SysSet_vacuum_Stadelayed);
            this.groupBox_vacuo.Controls.Add(this.CBox_SysSet_Vacuum_AutoOpenCleaner);
            this.groupBox_vacuo.Controls.Add(this.laber_vacuumendlayed);
            this.groupBox_vacuo.Controls.Add(this.CBox_SysSet_Vacuum_AutoCloseCleaner);
            this.groupBox_vacuo.Controls.Add(this.label_vacuumstalayed);
            this.groupBox_vacuo.Location = new System.Drawing.Point(18, 352);
            this.groupBox_vacuo.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox_vacuo.Name = "groupBox_vacuo";
            this.groupBox_vacuo.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox_vacuo.Size = new System.Drawing.Size(608, 104);
            this.groupBox_vacuo.TabIndex = 12;
            this.groupBox_vacuo.TabStop = false;
            this.groupBox_vacuo.Text = "真空控制";
            // 
            // NumUD_SysSet_vacuum_Enddelayed
            // 
            this.NumUD_SysSet_vacuum_Enddelayed.Location = new System.Drawing.Point(368, 58);
            this.NumUD_SysSet_vacuum_Enddelayed.Margin = new System.Windows.Forms.Padding(2);
            this.NumUD_SysSet_vacuum_Enddelayed.Name = "NumUD_SysSet_vacuum_Enddelayed";
            this.NumUD_SysSet_vacuum_Enddelayed.Size = new System.Drawing.Size(90, 22);
            this.NumUD_SysSet_vacuum_Enddelayed.TabIndex = 3;
            // 
            // CBox_SysSet_Vacuum_Pressure
            // 
            this.CBox_SysSet_Vacuum_Pressure.AutoSize = true;
            this.CBox_SysSet_Vacuum_Pressure.Location = new System.Drawing.Point(22, 78);
            this.CBox_SysSet_Vacuum_Pressure.Margin = new System.Windows.Forms.Padding(2);
            this.CBox_SysSet_Vacuum_Pressure.Name = "CBox_SysSet_Vacuum_Pressure";
            this.CBox_SysSet_Vacuum_Pressure.Size = new System.Drawing.Size(134, 18);
            this.CBox_SysSet_Vacuum_Pressure.TabIndex = 0;
            this.CBox_SysSet_Vacuum_Pressure.Text = "加工时检查真空压力";
            this.CBox_SysSet_Vacuum_Pressure.UseVisualStyleBackColor = true;
            // 
            // NumUD_SysSet_vacuum_Stadelayed
            // 
            this.NumUD_SysSet_vacuum_Stadelayed.Location = new System.Drawing.Point(368, 30);
            this.NumUD_SysSet_vacuum_Stadelayed.Margin = new System.Windows.Forms.Padding(2);
            this.NumUD_SysSet_vacuum_Stadelayed.Name = "NumUD_SysSet_vacuum_Stadelayed";
            this.NumUD_SysSet_vacuum_Stadelayed.Size = new System.Drawing.Size(90, 22);
            this.NumUD_SysSet_vacuum_Stadelayed.TabIndex = 3;
            // 
            // CBox_SysSet_Vacuum_AutoOpenCleaner
            // 
            this.CBox_SysSet_Vacuum_AutoOpenCleaner.AutoSize = true;
            this.CBox_SysSet_Vacuum_AutoOpenCleaner.Location = new System.Drawing.Point(22, 31);
            this.CBox_SysSet_Vacuum_AutoOpenCleaner.Margin = new System.Windows.Forms.Padding(2);
            this.CBox_SysSet_Vacuum_AutoOpenCleaner.Name = "CBox_SysSet_Vacuum_AutoOpenCleaner";
            this.CBox_SysSet_Vacuum_AutoOpenCleaner.Size = new System.Drawing.Size(146, 18);
            this.CBox_SysSet_Vacuum_AutoOpenCleaner.TabIndex = 0;
            this.CBox_SysSet_Vacuum_AutoOpenCleaner.Text = "加工前自动打开吸尘器";
            this.CBox_SysSet_Vacuum_AutoOpenCleaner.UseVisualStyleBackColor = true;
            // 
            // laber_vacuumendlayed
            // 
            this.laber_vacuumendlayed.AutoSize = true;
            this.laber_vacuumendlayed.Location = new System.Drawing.Point(226, 59);
            this.laber_vacuumendlayed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.laber_vacuumendlayed.Name = "laber_vacuumendlayed";
            this.laber_vacuumendlayed.Size = new System.Drawing.Size(144, 14);
            this.laber_vacuumendlayed.TabIndex = 2;
            this.laber_vacuumendlayed.Text = "加工完关真空前延时(ms):";
            // 
            // CBox_SysSet_Vacuum_AutoCloseCleaner
            // 
            this.CBox_SysSet_Vacuum_AutoCloseCleaner.AutoSize = true;
            this.CBox_SysSet_Vacuum_AutoCloseCleaner.Location = new System.Drawing.Point(22, 54);
            this.CBox_SysSet_Vacuum_AutoCloseCleaner.Margin = new System.Windows.Forms.Padding(2);
            this.CBox_SysSet_Vacuum_AutoCloseCleaner.Name = "CBox_SysSet_Vacuum_AutoCloseCleaner";
            this.CBox_SysSet_Vacuum_AutoCloseCleaner.Size = new System.Drawing.Size(158, 18);
            this.CBox_SysSet_Vacuum_AutoCloseCleaner.TabIndex = 0;
            this.CBox_SysSet_Vacuum_AutoCloseCleaner.Text = "加工完成自动关闭吸尘器";
            this.CBox_SysSet_Vacuum_AutoCloseCleaner.UseVisualStyleBackColor = true;
            // 
            // label_vacuumstalayed
            // 
            this.label_vacuumstalayed.AutoSize = true;
            this.label_vacuumstalayed.Location = new System.Drawing.Point(226, 34);
            this.label_vacuumstalayed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_vacuumstalayed.Name = "label_vacuumstalayed";
            this.label_vacuumstalayed.Size = new System.Drawing.Size(144, 14);
            this.label_vacuumstalayed.TabIndex = 1;
            this.label_vacuumstalayed.Text = "加工前开真空后延时(ms):";
            // 
            // groupBox_Door
            // 
            this.groupBox_Door.Controls.Add(this.numUD_SysSet_Door_delayed);
            this.groupBox_Door.Controls.Add(this.numUD_SysSet_Door_timelimit);
            this.groupBox_Door.Controls.Add(this.label_delay);
            this.groupBox_Door.Controls.Add(this.label_timelimit);
            this.groupBox_Door.Controls.Add(this.CBox_SysSet_Door_Auto);
            this.groupBox_Door.Location = new System.Drawing.Point(209, 225);
            this.groupBox_Door.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox_Door.Name = "groupBox_Door";
            this.groupBox_Door.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox_Door.Size = new System.Drawing.Size(232, 126);
            this.groupBox_Door.TabIndex = 11;
            this.groupBox_Door.TabStop = false;
            this.groupBox_Door.Text = "门设置";
            // 
            // numUD_SysSet_Door_delayed
            // 
            this.numUD_SysSet_Door_delayed.Location = new System.Drawing.Point(120, 94);
            this.numUD_SysSet_Door_delayed.Margin = new System.Windows.Forms.Padding(2);
            this.numUD_SysSet_Door_delayed.Name = "numUD_SysSet_Door_delayed";
            this.numUD_SysSet_Door_delayed.Size = new System.Drawing.Size(90, 22);
            this.numUD_SysSet_Door_delayed.TabIndex = 3;
            // 
            // numUD_SysSet_Door_timelimit
            // 
            this.numUD_SysSet_Door_timelimit.Location = new System.Drawing.Point(120, 59);
            this.numUD_SysSet_Door_timelimit.Margin = new System.Windows.Forms.Padding(2);
            this.numUD_SysSet_Door_timelimit.Name = "numUD_SysSet_Door_timelimit";
            this.numUD_SysSet_Door_timelimit.Size = new System.Drawing.Size(90, 22);
            this.numUD_SysSet_Door_timelimit.TabIndex = 3;
            // 
            // label_delay
            // 
            this.label_delay.AutoSize = true;
            this.label_delay.Location = new System.Drawing.Point(13, 96);
            this.label_delay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_delay.Name = "label_delay";
            this.label_delay.Size = new System.Drawing.Size(108, 14);
            this.label_delay.TabIndex = 2;
            this.label_delay.Text = "开门稳定延时(ms):";
            // 
            // label_timelimit
            // 
            this.label_timelimit.AutoSize = true;
            this.label_timelimit.Location = new System.Drawing.Point(13, 61);
            this.label_timelimit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_timelimit.Name = "label_timelimit";
            this.label_timelimit.Size = new System.Drawing.Size(108, 14);
            this.label_timelimit.TabIndex = 1;
            this.label_timelimit.Text = "状态检测时限(ms):";
            // 
            // CBox_SysSet_Door_Auto
            // 
            this.CBox_SysSet_Door_Auto.AutoSize = true;
            this.CBox_SysSet_Door_Auto.Location = new System.Drawing.Point(15, 27);
            this.CBox_SysSet_Door_Auto.Margin = new System.Windows.Forms.Padding(2);
            this.CBox_SysSet_Door_Auto.Name = "CBox_SysSet_Door_Auto";
            this.CBox_SysSet_Door_Auto.Size = new System.Drawing.Size(146, 18);
            this.CBox_SysSet_Door_Auto.TabIndex = 0;
            this.CBox_SysSet_Door_Auto.Text = "加工时启用自动门开关";
            this.CBox_SysSet_Door_Auto.UseVisualStyleBackColor = true;
            // 
            // groupBox_Scissor
            // 
            this.groupBox_Scissor.Controls.Add(this.Rtn_SysSet_Scissor_RtcToScissor);
            this.groupBox_Scissor.Controls.Add(this.Rtn_SysSet_Scissor_ScissorToRtc);
            this.groupBox_Scissor.Location = new System.Drawing.Point(209, 124);
            this.groupBox_Scissor.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox_Scissor.Name = "groupBox_Scissor";
            this.groupBox_Scissor.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox_Scissor.Size = new System.Drawing.Size(232, 85);
            this.groupBox_Scissor.TabIndex = 10;
            this.groupBox_Scissor.TabStop = false;
            this.groupBox_Scissor.Text = "刀具控制";
            // 
            // Rtn_SysSet_Scissor_RtcToScissor
            // 
            this.Rtn_SysSet_Scissor_RtcToScissor.AutoSize = true;
            this.Rtn_SysSet_Scissor_RtcToScissor.Checked = true;
            this.Rtn_SysSet_Scissor_RtcToScissor.Location = new System.Drawing.Point(15, 27);
            this.Rtn_SysSet_Scissor_RtcToScissor.Margin = new System.Windows.Forms.Padding(2);
            this.Rtn_SysSet_Scissor_RtcToScissor.Name = "Rtn_SysSet_Scissor_RtcToScissor";
            this.Rtn_SysSet_Scissor_RtcToScissor.Size = new System.Drawing.Size(121, 18);
            this.Rtn_SysSet_Scissor_RtcToScissor.TabIndex = 0;
            this.Rtn_SysSet_Scissor_RtcToScissor.TabStop = true;
            this.Rtn_SysSet_Scissor_RtcToScissor.Text = "单振镜分刀具加工";
            this.Rtn_SysSet_Scissor_RtcToScissor.UseVisualStyleBackColor = true;
            // 
            // Rtn_SysSet_Scissor_ScissorToRtc
            // 
            this.Rtn_SysSet_Scissor_ScissorToRtc.AutoSize = true;
            this.Rtn_SysSet_Scissor_ScissorToRtc.Location = new System.Drawing.Point(15, 59);
            this.Rtn_SysSet_Scissor_ScissorToRtc.Margin = new System.Windows.Forms.Padding(2);
            this.Rtn_SysSet_Scissor_ScissorToRtc.Name = "Rtn_SysSet_Scissor_ScissorToRtc";
            this.Rtn_SysSet_Scissor_ScissorToRtc.Size = new System.Drawing.Size(121, 18);
            this.Rtn_SysSet_Scissor_ScissorToRtc.TabIndex = 0;
            this.Rtn_SysSet_Scissor_ScissorToRtc.Text = "单刀具分振镜加工";
            this.Rtn_SysSet_Scissor_ScissorToRtc.UseVisualStyleBackColor = true;
            // 
            // groupBox_count
            // 
            this.groupBox_count.Controls.Add(this.CBox_SysSet_Count_pieces);
            this.groupBox_count.Controls.Add(this.CBox_SysSet_Count_num);
            this.groupBox_count.Location = new System.Drawing.Point(209, 15);
            this.groupBox_count.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox_count.Name = "groupBox_count";
            this.groupBox_count.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox_count.Size = new System.Drawing.Size(232, 85);
            this.groupBox_count.TabIndex = 9;
            this.groupBox_count.TabStop = false;
            this.groupBox_count.Text = "加工计数";
            // 
            // CBox_SysSet_Count_pieces
            // 
            this.CBox_SysSet_Count_pieces.AutoSize = true;
            this.CBox_SysSet_Count_pieces.Location = new System.Drawing.Point(15, 49);
            this.CBox_SysSet_Count_pieces.Margin = new System.Windows.Forms.Padding(2);
            this.CBox_SysSet_Count_pieces.Name = "CBox_SysSet_Count_pieces";
            this.CBox_SysSet_Count_pieces.Size = new System.Drawing.Size(122, 18);
            this.CBox_SysSet_Count_pieces.TabIndex = 0;
            this.CBox_SysSet_Count_pieces.Text = "开启片数提醒功能";
            this.CBox_SysSet_Count_pieces.UseVisualStyleBackColor = true;
            // 
            // CBox_SysSet_Count_num
            // 
            this.CBox_SysSet_Count_num.AutoSize = true;
            this.CBox_SysSet_Count_num.Location = new System.Drawing.Point(15, 22);
            this.CBox_SysSet_Count_num.Margin = new System.Windows.Forms.Padding(2);
            this.CBox_SysSet_Count_num.Name = "CBox_SysSet_Count_num";
            this.CBox_SysSet_Count_num.Size = new System.Drawing.Size(122, 18);
            this.CBox_SysSet_Count_num.TabIndex = 0;
            this.CBox_SysSet_Count_num.Text = "开启加工计数功能";
            this.CBox_SysSet_Count_num.UseVisualStyleBackColor = true;
            // 
            // groupBox_Z
            // 
            this.groupBox_Z.Controls.Add(this.Rtn_SysSet_Z_None);
            this.groupBox_Z.Controls.Add(this.Rtn_SysSet_Z_Fastpostion);
            this.groupBox_Z.Controls.Add(this.Rtn_SysSet_Z_ProFastpostion);
            this.groupBox_Z.Location = new System.Drawing.Point(23, 225);
            this.groupBox_Z.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox_Z.Name = "groupBox_Z";
            this.groupBox_Z.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox_Z.Size = new System.Drawing.Size(172, 126);
            this.groupBox_Z.TabIndex = 8;
            this.groupBox_Z.TabStop = false;
            this.groupBox_Z.Text = "平台移动时Z轴动作";
            // 
            // Rtn_SysSet_Z_None
            // 
            this.Rtn_SysSet_Z_None.AutoSize = true;
            this.Rtn_SysSet_Z_None.Checked = true;
            this.Rtn_SysSet_Z_None.Location = new System.Drawing.Point(17, 28);
            this.Rtn_SysSet_Z_None.Margin = new System.Windows.Forms.Padding(2);
            this.Rtn_SysSet_Z_None.Name = "Rtn_SysSet_Z_None";
            this.Rtn_SysSet_Z_None.Size = new System.Drawing.Size(61, 18);
            this.Rtn_SysSet_Z_None.TabIndex = 0;
            this.Rtn_SysSet_Z_None.TabStop = true;
            this.Rtn_SysSet_Z_None.Text = "无动作";
            this.Rtn_SysSet_Z_None.UseVisualStyleBackColor = true;
            // 
            // Rtn_SysSet_Z_Fastpostion
            // 
            this.Rtn_SysSet_Z_Fastpostion.AutoSize = true;
            this.Rtn_SysSet_Z_Fastpostion.Location = new System.Drawing.Point(17, 62);
            this.Rtn_SysSet_Z_Fastpostion.Margin = new System.Windows.Forms.Padding(2);
            this.Rtn_SysSet_Z_Fastpostion.Name = "Rtn_SysSet_Z_Fastpostion";
            this.Rtn_SysSet_Z_Fastpostion.Size = new System.Drawing.Size(73, 18);
            this.Rtn_SysSet_Z_Fastpostion.TabIndex = 0;
            this.Rtn_SysSet_Z_Fastpostion.Text = "至快移位";
            this.Rtn_SysSet_Z_Fastpostion.UseVisualStyleBackColor = true;
            // 
            // Rtn_SysSet_Z_ProFastpostion
            // 
            this.Rtn_SysSet_Z_ProFastpostion.AutoSize = true;
            this.Rtn_SysSet_Z_ProFastpostion.Location = new System.Drawing.Point(17, 95);
            this.Rtn_SysSet_Z_ProFastpostion.Margin = new System.Windows.Forms.Padding(2);
            this.Rtn_SysSet_Z_ProFastpostion.Name = "Rtn_SysSet_Z_ProFastpostion";
            this.Rtn_SysSet_Z_ProFastpostion.Size = new System.Drawing.Size(155, 18);
            this.Rtn_SysSet_Z_ProFastpostion.TabIndex = 0;
            this.Rtn_SysSet_Z_ProFastpostion.Text = "至快移位(仅加工定位前)";
            this.Rtn_SysSet_Z_ProFastpostion.UseVisualStyleBackColor = true;
            // 
            // groupBox_PrpcessEnd
            // 
            this.groupBox_PrpcessEnd.Controls.Add(this.Rtn_SysSet_processEnd_Leftpostion);
            this.groupBox_PrpcessEnd.Controls.Add(this.Rtn_SysSet_processEnd_Fastpostion);
            this.groupBox_PrpcessEnd.Controls.Add(this.Rtn_SysSet_processEnd_Rightpostion);
            this.groupBox_PrpcessEnd.Controls.Add(this.Rtn_SysSet_processEnd_Zero);
            this.groupBox_PrpcessEnd.Controls.Add(this.Rtn_SysSet_processEnd_None);
            this.groupBox_PrpcessEnd.Location = new System.Drawing.Point(23, 15);
            this.groupBox_PrpcessEnd.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox_PrpcessEnd.Name = "groupBox_PrpcessEnd";
            this.groupBox_PrpcessEnd.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox_PrpcessEnd.Size = new System.Drawing.Size(172, 194);
            this.groupBox_PrpcessEnd.TabIndex = 7;
            this.groupBox_PrpcessEnd.TabStop = false;
            this.groupBox_PrpcessEnd.Text = "加工结束后动作";
            // 
            // Rtn_SysSet_processEnd_Leftpostion
            // 
            this.Rtn_SysSet_processEnd_Leftpostion.AutoSize = true;
            this.Rtn_SysSet_processEnd_Leftpostion.Location = new System.Drawing.Point(17, 94);
            this.Rtn_SysSet_processEnd_Leftpostion.Margin = new System.Windows.Forms.Padding(2);
            this.Rtn_SysSet_processEnd_Leftpostion.Name = "Rtn_SysSet_processEnd_Leftpostion";
            this.Rtn_SysSet_processEnd_Leftpostion.Size = new System.Drawing.Size(109, 18);
            this.Rtn_SysSet_processEnd_Leftpostion.TabIndex = 0;
            this.Rtn_SysSet_processEnd_Leftpostion.Text = "至左平台暂停位";
            this.Rtn_SysSet_processEnd_Leftpostion.UseVisualStyleBackColor = true;
            // 
            // Rtn_SysSet_processEnd_Fastpostion
            // 
            this.Rtn_SysSet_processEnd_Fastpostion.AutoSize = true;
            this.Rtn_SysSet_processEnd_Fastpostion.Location = new System.Drawing.Point(17, 160);
            this.Rtn_SysSet_processEnd_Fastpostion.Margin = new System.Windows.Forms.Padding(2);
            this.Rtn_SysSet_processEnd_Fastpostion.Name = "Rtn_SysSet_processEnd_Fastpostion";
            this.Rtn_SysSet_processEnd_Fastpostion.Size = new System.Drawing.Size(85, 18);
            this.Rtn_SysSet_processEnd_Fastpostion.TabIndex = 0;
            this.Rtn_SysSet_processEnd_Fastpostion.Text = "至上下料位";
            this.Rtn_SysSet_processEnd_Fastpostion.UseVisualStyleBackColor = true;
            // 
            // Rtn_SysSet_processEnd_Rightpostion
            // 
            this.Rtn_SysSet_processEnd_Rightpostion.AutoSize = true;
            this.Rtn_SysSet_processEnd_Rightpostion.Location = new System.Drawing.Point(17, 127);
            this.Rtn_SysSet_processEnd_Rightpostion.Margin = new System.Windows.Forms.Padding(2);
            this.Rtn_SysSet_processEnd_Rightpostion.Name = "Rtn_SysSet_processEnd_Rightpostion";
            this.Rtn_SysSet_processEnd_Rightpostion.Size = new System.Drawing.Size(109, 18);
            this.Rtn_SysSet_processEnd_Rightpostion.TabIndex = 0;
            this.Rtn_SysSet_processEnd_Rightpostion.Text = "至右平台暂停位";
            this.Rtn_SysSet_processEnd_Rightpostion.UseVisualStyleBackColor = true;
            // 
            // Rtn_SysSet_processEnd_Zero
            // 
            this.Rtn_SysSet_processEnd_Zero.AutoSize = true;
            this.Rtn_SysSet_processEnd_Zero.Location = new System.Drawing.Point(17, 62);
            this.Rtn_SysSet_processEnd_Zero.Margin = new System.Windows.Forms.Padding(2);
            this.Rtn_SysSet_processEnd_Zero.Name = "Rtn_SysSet_processEnd_Zero";
            this.Rtn_SysSet_processEnd_Zero.Size = new System.Drawing.Size(49, 18);
            this.Rtn_SysSet_processEnd_Zero.TabIndex = 0;
            this.Rtn_SysSet_processEnd_Zero.Text = "归零";
            this.Rtn_SysSet_processEnd_Zero.UseVisualStyleBackColor = true;
            // 
            // Rtn_SysSet_processEnd_None
            // 
            this.Rtn_SysSet_processEnd_None.AutoSize = true;
            this.Rtn_SysSet_processEnd_None.Checked = true;
            this.Rtn_SysSet_processEnd_None.Location = new System.Drawing.Point(17, 29);
            this.Rtn_SysSet_processEnd_None.Margin = new System.Windows.Forms.Padding(2);
            this.Rtn_SysSet_processEnd_None.Name = "Rtn_SysSet_processEnd_None";
            this.Rtn_SysSet_processEnd_None.Size = new System.Drawing.Size(61, 18);
            this.Rtn_SysSet_processEnd_None.TabIndex = 0;
            this.Rtn_SysSet_processEnd_None.TabStop = true;
            this.Rtn_SysSet_processEnd_None.Text = "无动作";
            this.Rtn_SysSet_processEnd_None.UseVisualStyleBackColor = true;
            // 
            // AxisPara
            // 
            this.AxisPara.Caption = "轴参数";
            this.AxisPara.Controls.Add(this.AxisParagroupBox);
            this.AxisPara.Name = "AxisPara";
            this.AxisPara.Size = new System.Drawing.Size(1356, 636);
            // 
            // AxisParagroupBox
            // 
            this.AxisParagroupBox.Controls.Add(this.label103);
            this.AxisParagroupBox.Controls.Add(this.AxisSelectcomboBox);
            this.AxisParagroupBox.Controls.Add(this.AxisDccnumericUpDown);
            this.AxisParagroupBox.Controls.Add(this.numUD_AxisNegativeLimit);
            this.AxisParagroupBox.Controls.Add(this.label100);
            this.AxisParagroupBox.Controls.Add(this.numUD_AxisPositiveLimit);
            this.AxisParagroupBox.Controls.Add(this.AxisAccnumericUpDown);
            this.AxisParagroupBox.Controls.Add(this.label101);
            this.AxisParagroupBox.Controls.Add(this.label_lowLimit);
            this.AxisParagroupBox.Controls.Add(this.AxisSmoothTimenumericUpDown);
            this.AxisParagroupBox.Controls.Add(this.label_highLimit);
            this.AxisParagroupBox.Controls.Add(this.AxisVelocitynumericUpDown);
            this.AxisParagroupBox.Controls.Add(this.label102);
            this.AxisParagroupBox.Location = new System.Drawing.Point(14, 14);
            this.AxisParagroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.AxisParagroupBox.Name = "AxisParagroupBox";
            this.AxisParagroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.AxisParagroupBox.Size = new System.Drawing.Size(273, 356);
            this.AxisParagroupBox.TabIndex = 9;
            this.AxisParagroupBox.TabStop = false;
            this.AxisParagroupBox.Text = "轴参数";
            // 
            // label103
            // 
            this.label103.AutoSize = true;
            this.label103.Location = new System.Drawing.Point(17, 220);
            this.label103.Name = "label103";
            this.label103.Size = new System.Drawing.Size(79, 14);
            this.label103.TabIndex = 177;
            this.label103.Text = "减速度mm/s²";
            // 
            // AxisSelectcomboBox
            // 
            this.AxisSelectcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AxisSelectcomboBox.FormattingEnabled = true;
            this.AxisSelectcomboBox.Items.AddRange(new object[] {
            "X轴",
            "Y轴",
            "Z轴"});
            this.AxisSelectcomboBox.Location = new System.Drawing.Point(25, 32);
            this.AxisSelectcomboBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.AxisSelectcomboBox.Name = "AxisSelectcomboBox";
            this.AxisSelectcomboBox.Size = new System.Drawing.Size(159, 22);
            this.AxisSelectcomboBox.TabIndex = 159;
            // 
            // AxisDccnumericUpDown
            // 
            this.AxisDccnumericUpDown.Increment = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.AxisDccnumericUpDown.Location = new System.Drawing.Point(127, 216);
            this.AxisDccnumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.AxisDccnumericUpDown.Name = "AxisDccnumericUpDown";
            this.AxisDccnumericUpDown.Size = new System.Drawing.Size(103, 22);
            this.AxisDccnumericUpDown.TabIndex = 178;
            // 
            // numUD_AxisNegativeLimit
            // 
            this.numUD_AxisNegativeLimit.Location = new System.Drawing.Point(126, 126);
            this.numUD_AxisNegativeLimit.Margin = new System.Windows.Forms.Padding(2);
            this.numUD_AxisNegativeLimit.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            -2147483648});
            this.numUD_AxisNegativeLimit.Name = "numUD_AxisNegativeLimit";
            this.numUD_AxisNegativeLimit.Size = new System.Drawing.Size(104, 22);
            this.numUD_AxisNegativeLimit.TabIndex = 4;
            // 
            // label100
            // 
            this.label100.AutoSize = true;
            this.label100.Location = new System.Drawing.Point(17, 175);
            this.label100.Name = "label100";
            this.label100.Size = new System.Drawing.Size(79, 14);
            this.label100.TabIndex = 169;
            this.label100.Text = "加速度mm/s²";
            // 
            // numUD_AxisPositiveLimit
            // 
            this.numUD_AxisPositiveLimit.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numUD_AxisPositiveLimit.Location = new System.Drawing.Point(126, 81);
            this.numUD_AxisPositiveLimit.Margin = new System.Windows.Forms.Padding(2);
            this.numUD_AxisPositiveLimit.Maximum = new decimal(new int[] {
            499,
            0,
            0,
            0});
            this.numUD_AxisPositiveLimit.Name = "numUD_AxisPositiveLimit";
            this.numUD_AxisPositiveLimit.Size = new System.Drawing.Size(104, 22);
            this.numUD_AxisPositiveLimit.TabIndex = 4;
            this.numUD_AxisPositiveLimit.Value = new decimal(new int[] {
            450,
            0,
            0,
            0});
            // 
            // AxisAccnumericUpDown
            // 
            this.AxisAccnumericUpDown.Increment = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.AxisAccnumericUpDown.Location = new System.Drawing.Point(127, 171);
            this.AxisAccnumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.AxisAccnumericUpDown.Name = "AxisAccnumericUpDown";
            this.AxisAccnumericUpDown.Size = new System.Drawing.Size(103, 22);
            this.AxisAccnumericUpDown.TabIndex = 175;
            // 
            // label101
            // 
            this.label101.AutoSize = true;
            this.label101.Location = new System.Drawing.Point(17, 265);
            this.label101.Name = "label101";
            this.label101.Size = new System.Drawing.Size(85, 14);
            this.label101.TabIndex = 172;
            this.label101.Text = "运行速度mm/s";
            // 
            // label_lowLimit
            // 
            this.label_lowLimit.AutoSize = true;
            this.label_lowLimit.Location = new System.Drawing.Point(17, 130);
            this.label_lowLimit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_lowLimit.Name = "label_lowLimit";
            this.label_lowLimit.Size = new System.Drawing.Size(63, 14);
            this.label_lowLimit.TabIndex = 3;
            this.label_lowLimit.Text = "负限位mm";
            // 
            // AxisSmoothTimenumericUpDown
            // 
            this.AxisSmoothTimenumericUpDown.Increment = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.AxisSmoothTimenumericUpDown.Location = new System.Drawing.Point(127, 306);
            this.AxisSmoothTimenumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.AxisSmoothTimenumericUpDown.Name = "AxisSmoothTimenumericUpDown";
            this.AxisSmoothTimenumericUpDown.Size = new System.Drawing.Size(103, 22);
            this.AxisSmoothTimenumericUpDown.TabIndex = 173;
            // 
            // label_highLimit
            // 
            this.label_highLimit.AutoSize = true;
            this.label_highLimit.Location = new System.Drawing.Point(17, 85);
            this.label_highLimit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_highLimit.Name = "label_highLimit";
            this.label_highLimit.Size = new System.Drawing.Size(63, 14);
            this.label_highLimit.TabIndex = 3;
            this.label_highLimit.Text = "正限位mm";
            // 
            // AxisVelocitynumericUpDown
            // 
            this.AxisVelocitynumericUpDown.Increment = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.AxisVelocitynumericUpDown.Location = new System.Drawing.Point(127, 261);
            this.AxisVelocitynumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.AxisVelocitynumericUpDown.Name = "AxisVelocitynumericUpDown";
            this.AxisVelocitynumericUpDown.Size = new System.Drawing.Size(103, 22);
            this.AxisVelocitynumericUpDown.TabIndex = 176;
            // 
            // label102
            // 
            this.label102.AutoSize = true;
            this.label102.Location = new System.Drawing.Point(17, 310);
            this.label102.Name = "label102";
            this.label102.Size = new System.Drawing.Size(99, 14);
            this.label102.TabIndex = 171;
            this.label102.Text = "运动平滑系数/ms";
            // 
            // CameraPara
            // 
            this.CameraPara.Name = "CameraPara";
            this.CameraPara.Size = new System.Drawing.Size(1356, 704);
            // 
            // LogInfoFormPage
            // 
            this.LogInfoFormPage.ContentContainer = this.LogInfo;
            this.LogInfoFormPage.Name = "LogInfoFormPage";
            this.LogInfoFormPage.Text = "日志";
            // 
            // LogInfo
            // 
            this.LogInfo.Controls.Add(this.monthCalendar1);
            this.LogInfo.Controls.Add(this.Debug_Info_Display);
            this.LogInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogInfo.Location = new System.Drawing.Point(0, 51);
            this.LogInfo.Name = "LogInfo";
            this.LogInfo.Size = new System.Drawing.Size(1356, 664);
            this.LogInfo.TabIndex = 6;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.monthCalendar1.CalendarDimensions = new System.Drawing.Size(1, 4);
            this.monthCalendar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.monthCalendar1.Location = new System.Drawing.Point(1178, 0);
            this.monthCalendar1.MaximumSize = new System.Drawing.Size(400, 250);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 163;
            // 
            // Debug_Info_Display
            // 
            this.Debug_Info_Display.BackColor = System.Drawing.SystemColors.Menu;
            this.Debug_Info_Display.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Debug_Info_Display.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Debug_Info_Display.Location = new System.Drawing.Point(0, 0);
            this.Debug_Info_Display.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Debug_Info_Display.Name = "Debug_Info_Display";
            this.Debug_Info_Display.Size = new System.Drawing.Size(1356, 664);
            this.Debug_Info_Display.TabIndex = 162;
            this.Debug_Info_Display.Text = "";
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1356, 715);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Controls.Add(this.setFormPageContainer);
            this.Controls.Add(this.tabFormControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.TabFormControl = this.tabFormControl;
            this.Text = "激光切割机";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainView_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabFormControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabFormDefaultManager1)).EndInit();
            this.loginFormPageContainer.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Password_Input.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.User_List.Properties)).EndInit();
            this.mainFormPageContainer.ResumeLayout(false);
            this.MainFormDebuggroupBox.ResumeLayout(false);
            this.MainFormDebuggroupBox.PerformLayout();
            this.PointListConfiggroupBox.ResumeLayout(false);
            this.PointListConfiggroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PointListYnumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PointListXnumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlantFormpictureBox)).EndInit();
            this.PlatFormShiftgroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainCoordinateJogDistance)).EndInit();
            this.ProjectgroupBox.ResumeLayout(false);
            this.WorkOperategroupBox.ResumeLayout(false);
            this.WorkParagroupBox.ResumeLayout(false);
            this.WorkParagroupBox.PerformLayout();
            this.manualFormPageContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.manualTabPane)).EndInit();
            this.manualTabPane.ResumeLayout(false);
            this.gtsManual.ResumeLayout(false);
            this.gtsManual.PerformLayout();
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HomeSmoothTimenumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HomeDeviationnumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HomeDCCnumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HomeACCnumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HomeSpeednumericUpDown)).EndInit();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ManualSpeednumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ManualACCnumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ManualDCCnumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ManualStep)).EndInit();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AxisSelect)).EndInit();
            this.rtcManual.ResumeLayout(false);
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.groupBox_JZ.ResumeLayout(false);
            this.groupBox_JZ.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RtcPosReferencenumericUpDown)).EndInit();
            this.groupBox16.ResumeLayout(false);
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MoveYnumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoveXnumericUpDown)).EndInit();
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Mark_SpeednumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Jump_SpeednumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Laser_ON_DelaynumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mark_DelaynumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Jump_DelaynumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Laser_Off_DelaynumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Polygon_DelaynumericUpDown)).EndInit();
            this.groupBox19.ResumeLayout(false);
            this.groupBox19.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ABSPosYnumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ABSPosXnumericUpDown)).EndInit();
            this.groupBox20.ResumeLayout(false);
            this.groupBox20.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RtcHomeYnumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RtcHomeXnumericUpDown)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.AmpTemperaturenumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SeedTemperaturenumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LC_Amp2_SetnumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LC_Amp1_SetnumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LC_PRF_Set_ValuenumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LC_Seed_SetnumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LC_PEC_Set_ValuenumericUpDown)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.setFormPageContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.setTabPane)).EndInit();
            this.setTabPane.ResumeLayout(false);
            this.PlatFormPara.ResumeLayout(false);
            this.CertifyRepeatPrecisiongroupBox.ResumeLayout(false);
            this.CertifyRepeatPrecisiongroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PointListRepeatTimesnumericUpDown)).EndInit();
            this.CalibrationgroupBox.ResumeLayout(false);
            this.CalibrationgroupBox.PerformLayout();
            this.RtcMarkParagroupBox.ResumeLayout(false);
            this.RtcMarkParagroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RtcCircleRadiusnumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YCellnumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XCellnumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YLengthnumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XLengthnumericUpDown)).EndInit();
            this.groupBox25.ResumeLayout(false);
            this.groupBox25.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShieldbeepTimenumericUpDown)).EndInit();
            this.DebugMenugroupBox.ResumeLayout(false);
            this.groupBox23.ResumeLayout(false);
            this.groupBox23.PerformLayout();
            this.groupBox21.ResumeLayout(false);
            this.groupBox21.PerformLayout();
            this.CoordinategroupBox.ResumeLayout(false);
            this.CoordinategroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RtcOrgDistanceYnumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorkXnumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorkYnumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RtcOrgDistanceXnumericUpDown)).EndInit();
            this.WorkPara.ResumeLayout(false);
            this.groupBox_safety.ResumeLayout(false);
            this.groupBox_safety.PerformLayout();
            this.groupBox_convention.ResumeLayout(false);
            this.groupBox_convention.PerformLayout();
            this.groupBox_vacuo.ResumeLayout(false);
            this.groupBox_vacuo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUD_SysSet_vacuum_Enddelayed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUD_SysSet_vacuum_Stadelayed)).EndInit();
            this.groupBox_Door.ResumeLayout(false);
            this.groupBox_Door.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_SysSet_Door_delayed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_SysSet_Door_timelimit)).EndInit();
            this.groupBox_Scissor.ResumeLayout(false);
            this.groupBox_Scissor.PerformLayout();
            this.groupBox_count.ResumeLayout(false);
            this.groupBox_count.PerformLayout();
            this.groupBox_Z.ResumeLayout(false);
            this.groupBox_Z.PerformLayout();
            this.groupBox_PrpcessEnd.ResumeLayout(false);
            this.groupBox_PrpcessEnd.PerformLayout();
            this.AxisPara.ResumeLayout(false);
            this.AxisParagroupBox.ResumeLayout(false);
            this.AxisParagroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AxisDccnumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_AxisNegativeLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_AxisPositiveLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AxisAccnumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AxisSmoothTimenumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AxisVelocitynumericUpDown)).EndInit();
            this.LogInfo.ResumeLayout(false);
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
        private DevExpress.XtraBars.TabFormContentContainer manualFormPageContainer;
        private DevExpress.XtraBars.TabFormPage manualFormPage;
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
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Button ServoON;
        private System.Windows.Forms.Button PosClear;
        private System.Windows.Forms.Button StatusClear;
        private System.Windows.Forms.Button AlarmClear;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Button DriverAlarm;
        private System.Windows.Forms.Label label47;
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
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.GroupBox groupBox15;
        private System.Windows.Forms.Button Reset_Rtc;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.GroupBox groupBox16;
        private System.Windows.Forms.Button LaserOFF;
        private System.Windows.Forms.Button LaserON;
        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.Button MoveMode;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Button RtcYJogNegative;
        private System.Windows.Forms.Button RtcYJogPositive;
        private System.Windows.Forms.Button RtcXJogNegative;
        private System.Windows.Forms.Button RtcXJogPositive;
        private System.Windows.Forms.GroupBox groupBox18;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Button Change_Para_List;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.GroupBox groupBox19;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Button ABSPos;
        private System.Windows.Forms.GroupBox groupBox20;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.Button RtcHome;
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
        private System.Windows.Forms.Label label85;
        private System.Windows.Forms.ComboBox Work_Type_Select_List;
        private System.Windows.Forms.Button AxisHome;
        private System.Windows.Forms.GroupBox WorkOperategroupBox;
        private System.Windows.Forms.GroupBox WorkParagroupBox;
        private System.Windows.Forms.Button AutoDelaySwitch;
        private DevExpress.XtraBars.TabFormContentContainer LogInfo;
        private DevExpress.XtraBars.TabFormPage LogInfoFormPage;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.RichTextBox Debug_Info_Display;
        private System.Windows.Forms.NumericUpDown ManualStep;
        private System.Windows.Forms.Button CreateProject;
        private System.Windows.Forms.Button SaveProjectAs;
        private System.Windows.Forms.Button SaveProject;
        private System.Windows.Forms.Button ImportFile;
        private System.Windows.Forms.Button OpenProject;
        private System.Windows.Forms.Button CloseProject;
        private System.Windows.Forms.GroupBox ProjectgroupBox;
        private System.Windows.Forms.Button FileMarkStop;
        private System.Windows.Forms.Button FileMarkRun;
        private System.Windows.Forms.Button ConfigProject;
        private System.Windows.Forms.Button MarKCoordinateConfig;
        private System.Windows.Forms.NumericUpDown MainCoordinateJogDistance;
        private System.Windows.Forms.Button MainYJogNegative;
        private System.Windows.Forms.Button MainYJogPositive;
        private System.Windows.Forms.Button MainXJogPositive;
        private System.Windows.Forms.Button MainXJogNegative;
        private System.Windows.Forms.Button ResetEquipment;
        private System.Windows.Forms.GroupBox PlatFormShiftgroupBox;
        private System.Windows.Forms.ToolTip MainFormtoolTip;
        private System.Windows.Forms.Button EmgStopButton;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.Button AxisYErrbutton;
        private System.Windows.Forms.Button AxisXErrbutton;
        private System.Windows.Forms.PictureBox PlantFormpictureBox;
        private System.Windows.Forms.Button GoMousePosbutton;
        private System.Windows.Forms.Button SwitchToCambutton;
        private System.Windows.Forms.Button LaserOperateButton;
        private System.Windows.Forms.NumericUpDown ManualSpeednumericUpDown;
        private System.Windows.Forms.NumericUpDown ManualACCnumericUpDown;
        private System.Windows.Forms.NumericUpDown ManualDCCnumericUpDown;
        private System.Windows.Forms.NumericUpDown HomeSmoothTimenumericUpDown;
        private System.Windows.Forms.NumericUpDown HomeDeviationnumericUpDown;
        private System.Windows.Forms.NumericUpDown HomeDCCnumericUpDown;
        private System.Windows.Forms.NumericUpDown HomeACCnumericUpDown;
        private System.Windows.Forms.NumericUpDown HomeSpeednumericUpDown;
        private System.Windows.Forms.NumericUpDown RtcHomeXnumericUpDown;
        private System.Windows.Forms.NumericUpDown Mark_SpeednumericUpDown;
        private System.Windows.Forms.NumericUpDown ABSPosYnumericUpDown;
        private System.Windows.Forms.NumericUpDown ABSPosXnumericUpDown;
        private System.Windows.Forms.NumericUpDown RtcHomeYnumericUpDown;
        private System.Windows.Forms.NumericUpDown RtcPosReferencenumericUpDown;
        private System.Windows.Forms.NumericUpDown MoveYnumericUpDown;
        private System.Windows.Forms.NumericUpDown MoveXnumericUpDown;
        private System.Windows.Forms.NumericUpDown Jump_SpeednumericUpDown;
        private System.Windows.Forms.NumericUpDown Laser_ON_DelaynumericUpDown;
        private System.Windows.Forms.NumericUpDown Mark_DelaynumericUpDown;
        private System.Windows.Forms.NumericUpDown Jump_DelaynumericUpDown;
        private System.Windows.Forms.NumericUpDown Laser_Off_DelaynumericUpDown;
        private System.Windows.Forms.NumericUpDown Polygon_DelaynumericUpDown;
        private System.Windows.Forms.Button MaterialManagebutton;
        private System.Windows.Forms.Button CamConfigbutton;
        private DevExpress.XtraBars.Navigation.TabPane setTabPane;
        private DevExpress.XtraBars.Navigation.TabNavigationPage PlatFormPara;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.NumericUpDown ShieldbeepTimenumericUpDown;
        private System.Windows.Forms.CheckBox MarkJumpcheckBox;
        private System.Windows.Forms.CheckBox CamEncheckBox;
        private System.Windows.Forms.Button SyaParaRead;
        private System.Windows.Forms.Button SysParaSave;
        private System.Windows.Forms.Label label80;
        private System.Windows.Forms.Label label81;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.Label label71;
        private DevExpress.XtraBars.Navigation.TabNavigationPage WorkPara;
        private System.Windows.Forms.GroupBox groupBox_safety;
        private System.Windows.Forms.CheckBox CBox_SysSet_Safe_MoveEntrench;
        private System.Windows.Forms.CheckBox CBox_SysSet_Safe_Baffle;
        private System.Windows.Forms.CheckBox CBox_SysSet_Safe_prpcessingDoor;
        private System.Windows.Forms.CheckBox CBox_SysSet_Safe_CloseDoorEntrench;
        private System.Windows.Forms.CheckBox CBox_SysSet_Safe_OpenDoorEntrench;
        private System.Windows.Forms.GroupBox groupBox_convention;
        private System.Windows.Forms.CheckBox CBox_SysSet_Convention_prpcessEndAlarm;
        private System.Windows.Forms.CheckBox CBox_SysSet_Convention_ChillerTem;
        private System.Windows.Forms.CheckBox CBox_SysSet_Convention_prpcessEndDlg;
        private System.Windows.Forms.CheckBox CBox_SysSet_Convention_Laserstate;
        private System.Windows.Forms.CheckBox CBox_SysSet_Convention_Autolight;
        private System.Windows.Forms.GroupBox groupBox_vacuo;
        private System.Windows.Forms.NumericUpDown NumUD_SysSet_vacuum_Enddelayed;
        private System.Windows.Forms.CheckBox CBox_SysSet_Vacuum_Pressure;
        private System.Windows.Forms.NumericUpDown NumUD_SysSet_vacuum_Stadelayed;
        private System.Windows.Forms.CheckBox CBox_SysSet_Vacuum_AutoOpenCleaner;
        private System.Windows.Forms.Label laber_vacuumendlayed;
        private System.Windows.Forms.CheckBox CBox_SysSet_Vacuum_AutoCloseCleaner;
        private System.Windows.Forms.Label label_vacuumstalayed;
        private System.Windows.Forms.GroupBox groupBox_Door;
        private System.Windows.Forms.NumericUpDown numUD_SysSet_Door_delayed;
        private System.Windows.Forms.NumericUpDown numUD_SysSet_Door_timelimit;
        private System.Windows.Forms.Label label_delay;
        private System.Windows.Forms.Label label_timelimit;
        private System.Windows.Forms.CheckBox CBox_SysSet_Door_Auto;
        private System.Windows.Forms.GroupBox groupBox_Scissor;
        private System.Windows.Forms.RadioButton Rtn_SysSet_Scissor_RtcToScissor;
        private System.Windows.Forms.RadioButton Rtn_SysSet_Scissor_ScissorToRtc;
        private System.Windows.Forms.GroupBox groupBox_count;
        private System.Windows.Forms.CheckBox CBox_SysSet_Count_pieces;
        private System.Windows.Forms.CheckBox CBox_SysSet_Count_num;
        private System.Windows.Forms.GroupBox groupBox_Z;
        private System.Windows.Forms.RadioButton Rtn_SysSet_Z_None;
        private System.Windows.Forms.RadioButton Rtn_SysSet_Z_Fastpostion;
        private System.Windows.Forms.RadioButton Rtn_SysSet_Z_ProFastpostion;
        private System.Windows.Forms.GroupBox groupBox_PrpcessEnd;
        private System.Windows.Forms.RadioButton Rtn_SysSet_processEnd_Leftpostion;
        private System.Windows.Forms.RadioButton Rtn_SysSet_processEnd_Fastpostion;
        private System.Windows.Forms.RadioButton Rtn_SysSet_processEnd_Rightpostion;
        private System.Windows.Forms.RadioButton Rtn_SysSet_processEnd_Zero;
        private System.Windows.Forms.RadioButton Rtn_SysSet_processEnd_None;
        private DevExpress.XtraBars.Navigation.TabNavigationPage AxisPara;
        private System.Windows.Forms.GroupBox AxisParagroupBox;
        private System.Windows.Forms.NumericUpDown numUD_AxisNegativeLimit;
        private System.Windows.Forms.NumericUpDown numUD_AxisPositiveLimit;
        private System.Windows.Forms.Label label_lowLimit;
        private System.Windows.Forms.Label label_highLimit;
        private DevExpress.XtraBars.Navigation.TabNavigationPage CameraPara;
        private System.Windows.Forms.NumericUpDown RtcOrgDistanceXnumericUpDown;
        private System.Windows.Forms.NumericUpDown WorkYnumericUpDown;
        private System.Windows.Forms.NumericUpDown WorkXnumericUpDown;
        private System.Windows.Forms.NumericUpDown RtcOrgDistanceYnumericUpDown;
        private System.Windows.Forms.GroupBox groupBox_JZ;
        private System.Windows.Forms.Button Btn_Rtc_Use;
        private System.Windows.Forms.Button Btn_Rtc_openFile;
        private System.Windows.Forms.TextBox Txt_RtcFilename;
        private System.Windows.Forms.ComboBox AxisSelectcomboBox;
        private System.Windows.Forms.GroupBox groupBox7;
        public System.Windows.Forms.Button LC_Power_On;
        public System.Windows.Forms.Button LC_Power_OFF;
        public System.Windows.Forms.GroupBox groupBox6;
        public System.Windows.Forms.Label label30;
        public System.Windows.Forms.Label label29;
        public System.Windows.Forms.TextBox LC_Seed_Current;
        public System.Windows.Forms.Label label28;
        public System.Windows.Forms.TextBox LC_Amp1_Current;
        public System.Windows.Forms.Label label27;
        public System.Windows.Forms.TextBox LC_Amp2_Current;
        public System.Windows.Forms.GroupBox groupBox5;
        public System.Windows.Forms.Button LC_Refresh_Status;
        public System.Windows.Forms.Button LC_Reset_Laser;
        public System.Windows.Forms.Label label26;
        public System.Windows.Forms.RichTextBox LC_Status;
        public System.Windows.Forms.GroupBox groupBox4;
        public System.Windows.Forms.Label label25;
        public System.Windows.Forms.Label label24;
        public System.Windows.Forms.Label label23;
        public System.Windows.Forms.Label label22;
        public System.Windows.Forms.Button LC_PEC_Confirm;
        public System.Windows.Forms.Label label21;
        public System.Windows.Forms.Button LC_PRF_Confirm;
        private System.Windows.Forms.NumericUpDown LC_PEC_Set_ValuenumericUpDown;
        private System.Windows.Forms.NumericUpDown LC_PRF_Set_ValuenumericUpDown;
        private System.Windows.Forms.NumericUpDown LC_Seed_SetnumericUpDown;
        private System.Windows.Forms.NumericUpDown LC_Amp1_SetnumericUpDown;
        private System.Windows.Forms.NumericUpDown LC_Amp2_SetnumericUpDown;
        public System.Windows.Forms.GroupBox groupBox8;
        public System.Windows.Forms.PictureBox LC_Com_Status;
        public System.Windows.Forms.Button LC_Re_connect;
        public System.Windows.Forms.ComboBox LC_Com_List;
        public System.Windows.Forms.Button LC_Refresh_List;
        public System.Windows.Forms.GroupBox groupBox10;
        public System.Windows.Forms.TextBox LW_Watt_Indicate;
        public System.Windows.Forms.TextBox LW_PEC_Indicate;
        public System.Windows.Forms.Label Laser_Percent_Label;
        public System.Windows.Forms.Label Laser_Current_Watt_Label;
        public System.Windows.Forms.Button LW_Acquisition_Once;
        public System.Windows.Forms.Button LW_Save_Data;
        public System.Windows.Forms.GroupBox groupBox9;
        public System.Windows.Forms.PictureBox LW_Com_Status;
        public System.Windows.Forms.ComboBox LW_Com_List;
        public System.Windows.Forms.Button LW_Refresh_List;
        public System.Windows.Forms.Button LW_Re_Connect;
        private DevExpress.XtraBars.TabFormPage laserFormPage;
        private DevExpress.XtraBars.TabFormContentContainer laserFormPageContainer;
        private System.Windows.Forms.GroupBox groupBox21;
        private System.Windows.Forms.Button ApplyGtsCorrectFilebutton;
        private System.Windows.Forms.Button SelectGtsCorrectFilebutton;
        private System.Windows.Forms.TextBox GtsCorrectFilePathtextBox;
        private System.Windows.Forms.GroupBox groupBox25;
        private System.Windows.Forms.GroupBox DebugMenugroupBox;
        private System.Windows.Forms.GroupBox CoordinategroupBox;
        private System.Windows.Forms.GroupBox CalibrationgroupBox;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.NumericUpDown YCellnumericUpDown;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.NumericUpDown XCellnumericUpDown;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.NumericUpDown YLengthnumericUpDown;
        private System.Windows.Forms.Label label82;
        private System.Windows.Forms.NumericUpDown XLengthnumericUpDown;
        private System.Windows.Forms.TextBox XCalibratetextBox;
        private System.Windows.Forms.Label label83;
        private System.Windows.Forms.TextBox YAffinitytextBox;
        private System.Windows.Forms.Label label90;
        private System.Windows.Forms.TextBox YCalibratetextBox;
        private System.Windows.Forms.Label label91;
        private System.Windows.Forms.TextBox XAffinitytextBox;
        private System.Windows.Forms.Label label89;
        private System.Windows.Forms.CheckBox RtcAligncheckBox;
        private System.Windows.Forms.Label label92;
        private System.Windows.Forms.ComboBox RtcMarkTypecomboBox;
        private System.Windows.Forms.Label RtcCircleRadiusLabel;
        private System.Windows.Forms.NumericUpDown RtcCircleRadiusnumericUpDown;
        private System.Windows.Forms.GroupBox RtcMarkParagroupBox;
        private System.Windows.Forms.ComboBox CalibrationSelectcomboBox;
        private System.Windows.Forms.Label label93;
        private System.Windows.Forms.CheckBox RtcCorrectTypecheckBox;
        private System.Windows.Forms.Label label94;
        private System.Windows.Forms.Button GlobalErrbutton;
        private System.Windows.Forms.GroupBox groupBox23;
        private System.Windows.Forms.Button ApplyRtcXmlCorrectFilebutton;
        private System.Windows.Forms.Button SelectRtcXmlCorrectFilebutton;
        private System.Windows.Forms.TextBox RtcXmlCorrectFilePathtextBox;
        private System.Windows.Forms.Label label95;
        private System.Windows.Forms.Button EXO11_Status;
        private System.Windows.Forms.Label label97;
        private System.Windows.Forms.Label label96;
        private System.Windows.Forms.Button EXO13_Status;
        private System.Windows.Forms.Button EXO12_Status;
        private System.Windows.Forms.Button RedLaserButton;
        private System.Windows.Forms.GroupBox PointListConfiggroupBox;
        private System.Windows.Forms.Label label99;
        private System.Windows.Forms.ComboBox PointListSelectcomboBox;
        private System.Windows.Forms.Button GoPointListbutton;
        private System.Windows.Forms.Button SetPointListbutton;
        private System.Windows.Forms.Label label98;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.NumericUpDown PointListYnumericUpDown;
        private System.Windows.Forms.NumericUpDown PointListXnumericUpDown;
        public System.Windows.Forms.Label label65;
        public System.Windows.Forms.Label label63;
        private System.Windows.Forms.NumericUpDown AmpTemperaturenumericUpDown;
        private System.Windows.Forms.NumericUpDown SeedTemperaturenumericUpDown;
        public System.Windows.Forms.TextBox LC_AmpTemperatureTextbox;
        public System.Windows.Forms.Label label84;
        public System.Windows.Forms.TextBox LC_SeedTemperatureTextbox;
        public System.Windows.Forms.Label label68;
        private System.Windows.Forms.ComboBox CorrectMethodcomboBox;
        private System.Windows.Forms.Label label86;
        private System.Windows.Forms.Label label103;
        private System.Windows.Forms.NumericUpDown AxisDccnumericUpDown;
        private System.Windows.Forms.Label label100;
        private System.Windows.Forms.NumericUpDown AxisAccnumericUpDown;
        private System.Windows.Forms.Label label101;
        private System.Windows.Forms.NumericUpDown AxisSmoothTimenumericUpDown;
        private System.Windows.Forms.NumericUpDown AxisVelocitynumericUpDown;
        private System.Windows.Forms.Label label102;
        private System.Windows.Forms.GroupBox CertifyRepeatPrecisiongroupBox;
        private System.Windows.Forms.Label label87;
        private System.Windows.Forms.NumericUpDown PointListRepeatTimesnumericUpDown;
        private System.Windows.Forms.GroupBox groupBox24;
        private System.Windows.Forms.GroupBox MainFormDebuggroupBox;
    }
    
}


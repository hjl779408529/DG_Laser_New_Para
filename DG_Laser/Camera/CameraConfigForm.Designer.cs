namespace DG_Laser
{
    partial class CameraConfigForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox_Camparam = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Rtn_CamSet_SaveYes = new System.Windows.Forms.RadioButton();
            this.Rtn_CamSet_SaveNo = new System.Windows.Forms.RadioButton();
            this.groupBox_CamSet_MarkCol = new System.Windows.Forms.GroupBox();
            this.Rtn_CamSet_Black = new System.Windows.Forms.RadioButton();
            this.Rtn_CamSet_White = new System.Windows.Forms.RadioButton();
            this.Btn_CamSet_Save = new System.Windows.Forms.Button();
            this.tabControl_CamSet_Mark = new System.Windows.Forms.TabControl();
            this.tabPage_CamSet_Circle = new System.Windows.Forms.TabPage();
            this.CamSet_CircleRadiusnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label_CamSet_CircleRadio = new System.Windows.Forms.Label();
            this.tabPage_CamSet_Rect = new System.Windows.Forms.TabPage();
            this.CamSet_MarkWidthnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label_CamSet_MarkLength = new System.Windows.Forms.Label();
            this.CamSet_MarkLengthnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label_CamSet_MarkWidth = new System.Windows.Forms.Label();
            this.tabPage_CamSet_Cross = new System.Windows.Forms.TabPage();
            this.label_Markcol = new System.Windows.Forms.Label();
            this.groupBox_CamOperation = new System.Windows.Forms.GroupBox();
            this.PixelCentregroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CameraCentreXnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.CameraCentreYnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.CameraKnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label70 = new System.Windows.Forms.Label();
            this.OpenCambutton = new System.Windows.Forms.Button();
            this.ComBox__CamSet_Marktypelist = new System.Windows.Forms.ComboBox();
            this.label_CamSet_Marktype = new System.Windows.Forms.Label();
            this.Btn_CamSet_trigger = new System.Windows.Forms.Button();
            this.numUD_CamSet_num = new System.Windows.Forms.NumericUpDown();
            this.label_CamSet_num = new System.Windows.Forms.Label();
            this.Btn_CamSet_offconnect = new System.Windows.Forms.Button();
            this.Btn_CamSet_Reconnect = new System.Windows.Forms.Button();
            this.CameraConfigFormtoolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox_Camparam.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox_CamSet_MarkCol.SuspendLayout();
            this.tabControl_CamSet_Mark.SuspendLayout();
            this.tabPage_CamSet_Circle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CamSet_CircleRadiusnumericUpDown)).BeginInit();
            this.tabPage_CamSet_Rect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CamSet_MarkWidthnumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CamSet_MarkLengthnumericUpDown)).BeginInit();
            this.groupBox_CamOperation.SuspendLayout();
            this.PixelCentregroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CameraCentreXnumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CameraCentreYnumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CameraKnumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_CamSet_num)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox_Camparam
            // 
            this.groupBox_Camparam.Controls.Add(this.label4);
            this.groupBox_Camparam.Controls.Add(this.groupBox2);
            this.groupBox_Camparam.Controls.Add(this.groupBox_CamSet_MarkCol);
            this.groupBox_Camparam.Controls.Add(this.Btn_CamSet_Save);
            this.groupBox_Camparam.Controls.Add(this.tabControl_CamSet_Mark);
            this.groupBox_Camparam.Controls.Add(this.label_Markcol);
            this.groupBox_Camparam.Location = new System.Drawing.Point(20, 164);
            this.groupBox_Camparam.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox_Camparam.Name = "groupBox_Camparam";
            this.groupBox_Camparam.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox_Camparam.Size = new System.Drawing.Size(645, 188);
            this.groupBox_Camparam.TabIndex = 1;
            this.groupBox_Camparam.TabStop = false;
            this.groupBox_Camparam.Text = "相机参数";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 158);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 20;
            this.label4.Text = "保存图片:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Rtn_CamSet_SaveYes);
            this.groupBox2.Controls.Add(this.Rtn_CamSet_SaveNo);
            this.groupBox2.Location = new System.Drawing.Point(91, 144);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(103, 32);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            // 
            // Rtn_CamSet_SaveYes
            // 
            this.Rtn_CamSet_SaveYes.AutoSize = true;
            this.Rtn_CamSet_SaveYes.Location = new System.Drawing.Point(12, 13);
            this.Rtn_CamSet_SaveYes.Margin = new System.Windows.Forms.Padding(2);
            this.Rtn_CamSet_SaveYes.Name = "Rtn_CamSet_SaveYes";
            this.Rtn_CamSet_SaveYes.Size = new System.Drawing.Size(35, 16);
            this.Rtn_CamSet_SaveYes.TabIndex = 3;
            this.Rtn_CamSet_SaveYes.TabStop = true;
            this.Rtn_CamSet_SaveYes.Text = "是";
            this.Rtn_CamSet_SaveYes.UseVisualStyleBackColor = true;
            // 
            // Rtn_CamSet_SaveNo
            // 
            this.Rtn_CamSet_SaveNo.AutoSize = true;
            this.Rtn_CamSet_SaveNo.Location = new System.Drawing.Point(62, 13);
            this.Rtn_CamSet_SaveNo.Margin = new System.Windows.Forms.Padding(2);
            this.Rtn_CamSet_SaveNo.Name = "Rtn_CamSet_SaveNo";
            this.Rtn_CamSet_SaveNo.Size = new System.Drawing.Size(35, 16);
            this.Rtn_CamSet_SaveNo.TabIndex = 3;
            this.Rtn_CamSet_SaveNo.TabStop = true;
            this.Rtn_CamSet_SaveNo.Text = "否";
            this.Rtn_CamSet_SaveNo.UseVisualStyleBackColor = true;
            // 
            // groupBox_CamSet_MarkCol
            // 
            this.groupBox_CamSet_MarkCol.Controls.Add(this.Rtn_CamSet_Black);
            this.groupBox_CamSet_MarkCol.Controls.Add(this.Rtn_CamSet_White);
            this.groupBox_CamSet_MarkCol.Location = new System.Drawing.Point(101, 16);
            this.groupBox_CamSet_MarkCol.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox_CamSet_MarkCol.Name = "groupBox_CamSet_MarkCol";
            this.groupBox_CamSet_MarkCol.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox_CamSet_MarkCol.Size = new System.Drawing.Size(130, 32);
            this.groupBox_CamSet_MarkCol.TabIndex = 2;
            this.groupBox_CamSet_MarkCol.TabStop = false;
            // 
            // Rtn_CamSet_Black
            // 
            this.Rtn_CamSet_Black.AutoSize = true;
            this.Rtn_CamSet_Black.Location = new System.Drawing.Point(15, 13);
            this.Rtn_CamSet_Black.Margin = new System.Windows.Forms.Padding(2);
            this.Rtn_CamSet_Black.Name = "Rtn_CamSet_Black";
            this.Rtn_CamSet_Black.Size = new System.Drawing.Size(35, 16);
            this.Rtn_CamSet_Black.TabIndex = 1;
            this.Rtn_CamSet_Black.TabStop = true;
            this.Rtn_CamSet_Black.Text = "黑";
            this.Rtn_CamSet_Black.UseVisualStyleBackColor = true;
            this.Rtn_CamSet_Black.CheckedChanged += new System.EventHandler(this.Rtn_CamSet_Black_CheckedChanged);
            // 
            // Rtn_CamSet_White
            // 
            this.Rtn_CamSet_White.AutoSize = true;
            this.Rtn_CamSet_White.Location = new System.Drawing.Point(76, 13);
            this.Rtn_CamSet_White.Margin = new System.Windows.Forms.Padding(2);
            this.Rtn_CamSet_White.Name = "Rtn_CamSet_White";
            this.Rtn_CamSet_White.Size = new System.Drawing.Size(35, 16);
            this.Rtn_CamSet_White.TabIndex = 1;
            this.Rtn_CamSet_White.TabStop = true;
            this.Rtn_CamSet_White.Text = "白";
            this.Rtn_CamSet_White.UseVisualStyleBackColor = true;
            this.Rtn_CamSet_White.CheckedChanged += new System.EventHandler(this.Rtn_CamSet_White_CheckedChanged);
            // 
            // Btn_CamSet_Save
            // 
            this.Btn_CamSet_Save.Location = new System.Drawing.Point(566, 152);
            this.Btn_CamSet_Save.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_CamSet_Save.Name = "Btn_CamSet_Save";
            this.Btn_CamSet_Save.Size = new System.Drawing.Size(62, 24);
            this.Btn_CamSet_Save.TabIndex = 3;
            this.Btn_CamSet_Save.Text = "保存参数";
            this.Btn_CamSet_Save.UseVisualStyleBackColor = true;
            this.Btn_CamSet_Save.Click += new System.EventHandler(this.Btn_CamSet_Save_Click);
            // 
            // tabControl_CamSet_Mark
            // 
            this.tabControl_CamSet_Mark.Controls.Add(this.tabPage_CamSet_Circle);
            this.tabControl_CamSet_Mark.Controls.Add(this.tabPage_CamSet_Rect);
            this.tabControl_CamSet_Mark.Controls.Add(this.tabPage_CamSet_Cross);
            this.tabControl_CamSet_Mark.Location = new System.Drawing.Point(20, 57);
            this.tabControl_CamSet_Mark.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl_CamSet_Mark.Name = "tabControl_CamSet_Mark";
            this.tabControl_CamSet_Mark.SelectedIndex = 0;
            this.tabControl_CamSet_Mark.Size = new System.Drawing.Size(608, 82);
            this.tabControl_CamSet_Mark.TabIndex = 3;
            // 
            // tabPage_CamSet_Circle
            // 
            this.tabPage_CamSet_Circle.Controls.Add(this.CamSet_CircleRadiusnumericUpDown);
            this.tabPage_CamSet_Circle.Controls.Add(this.label_CamSet_CircleRadio);
            this.tabPage_CamSet_Circle.Location = new System.Drawing.Point(4, 22);
            this.tabPage_CamSet_Circle.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage_CamSet_Circle.Name = "tabPage_CamSet_Circle";
            this.tabPage_CamSet_Circle.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage_CamSet_Circle.Size = new System.Drawing.Size(600, 56);
            this.tabPage_CamSet_Circle.TabIndex = 0;
            this.tabPage_CamSet_Circle.Text = "圆";
            this.tabPage_CamSet_Circle.UseVisualStyleBackColor = true;
            // 
            // CamSet_CircleRadiusnumericUpDown
            // 
            this.CamSet_CircleRadiusnumericUpDown.DecimalPlaces = 3;
            this.CamSet_CircleRadiusnumericUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.CamSet_CircleRadiusnumericUpDown.Location = new System.Drawing.Point(101, 22);
            this.CamSet_CircleRadiusnumericUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.CamSet_CircleRadiusnumericUpDown.Maximum = new decimal(new int[] {
            45,
            0,
            0,
            65536});
            this.CamSet_CircleRadiusnumericUpDown.Name = "CamSet_CircleRadiusnumericUpDown";
            this.CamSet_CircleRadiusnumericUpDown.Size = new System.Drawing.Size(113, 21);
            this.CamSet_CircleRadiusnumericUpDown.TabIndex = 11;
            this.CamSet_CircleRadiusnumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            655360});
            // 
            // label_CamSet_CircleRadio
            // 
            this.label_CamSet_CircleRadio.AutoSize = true;
            this.label_CamSet_CircleRadio.Location = new System.Drawing.Point(30, 26);
            this.label_CamSet_CircleRadio.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_CamSet_CircleRadio.Name = "label_CamSet_CircleRadio";
            this.label_CamSet_CircleRadio.Size = new System.Drawing.Size(65, 12);
            this.label_CamSet_CircleRadio.TabIndex = 0;
            this.label_CamSet_CircleRadio.Text = "半径(mm)：";
            // 
            // tabPage_CamSet_Rect
            // 
            this.tabPage_CamSet_Rect.Controls.Add(this.CamSet_MarkWidthnumericUpDown);
            this.tabPage_CamSet_Rect.Controls.Add(this.label_CamSet_MarkLength);
            this.tabPage_CamSet_Rect.Controls.Add(this.CamSet_MarkLengthnumericUpDown);
            this.tabPage_CamSet_Rect.Controls.Add(this.label_CamSet_MarkWidth);
            this.tabPage_CamSet_Rect.Location = new System.Drawing.Point(4, 22);
            this.tabPage_CamSet_Rect.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage_CamSet_Rect.Name = "tabPage_CamSet_Rect";
            this.tabPage_CamSet_Rect.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage_CamSet_Rect.Size = new System.Drawing.Size(600, 56);
            this.tabPage_CamSet_Rect.TabIndex = 1;
            this.tabPage_CamSet_Rect.Text = "矩形";
            this.tabPage_CamSet_Rect.UseVisualStyleBackColor = true;
            // 
            // CamSet_MarkWidthnumericUpDown
            // 
            this.CamSet_MarkWidthnumericUpDown.DecimalPlaces = 3;
            this.CamSet_MarkWidthnumericUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.CamSet_MarkWidthnumericUpDown.Location = new System.Drawing.Point(276, 22);
            this.CamSet_MarkWidthnumericUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.CamSet_MarkWidthnumericUpDown.Maximum = new decimal(new int[] {
            45,
            0,
            0,
            65536});
            this.CamSet_MarkWidthnumericUpDown.Name = "CamSet_MarkWidthnumericUpDown";
            this.CamSet_MarkWidthnumericUpDown.Size = new System.Drawing.Size(113, 21);
            this.CamSet_MarkWidthnumericUpDown.TabIndex = 23;
            this.CamSet_MarkWidthnumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            655360});
            // 
            // label_CamSet_MarkLength
            // 
            this.label_CamSet_MarkLength.AutoSize = true;
            this.label_CamSet_MarkLength.Location = new System.Drawing.Point(3, 26);
            this.label_CamSet_MarkLength.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_CamSet_MarkLength.Name = "label_CamSet_MarkLength";
            this.label_CamSet_MarkLength.Size = new System.Drawing.Size(65, 12);
            this.label_CamSet_MarkLength.TabIndex = 0;
            this.label_CamSet_MarkLength.Text = "长（mm）：";
            // 
            // CamSet_MarkLengthnumericUpDown
            // 
            this.CamSet_MarkLengthnumericUpDown.DecimalPlaces = 3;
            this.CamSet_MarkLengthnumericUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.CamSet_MarkLengthnumericUpDown.Location = new System.Drawing.Point(72, 22);
            this.CamSet_MarkLengthnumericUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.CamSet_MarkLengthnumericUpDown.Maximum = new decimal(new int[] {
            45,
            0,
            0,
            65536});
            this.CamSet_MarkLengthnumericUpDown.Name = "CamSet_MarkLengthnumericUpDown";
            this.CamSet_MarkLengthnumericUpDown.Size = new System.Drawing.Size(113, 21);
            this.CamSet_MarkLengthnumericUpDown.TabIndex = 22;
            this.CamSet_MarkLengthnumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            655360});
            // 
            // label_CamSet_MarkWidth
            // 
            this.label_CamSet_MarkWidth.AutoSize = true;
            this.label_CamSet_MarkWidth.Location = new System.Drawing.Point(208, 26);
            this.label_CamSet_MarkWidth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_CamSet_MarkWidth.Name = "label_CamSet_MarkWidth";
            this.label_CamSet_MarkWidth.Size = new System.Drawing.Size(65, 12);
            this.label_CamSet_MarkWidth.TabIndex = 0;
            this.label_CamSet_MarkWidth.Text = "宽（mm）：";
            // 
            // tabPage_CamSet_Cross
            // 
            this.tabPage_CamSet_Cross.Location = new System.Drawing.Point(4, 22);
            this.tabPage_CamSet_Cross.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage_CamSet_Cross.Name = "tabPage_CamSet_Cross";
            this.tabPage_CamSet_Cross.Size = new System.Drawing.Size(600, 56);
            this.tabPage_CamSet_Cross.TabIndex = 2;
            this.tabPage_CamSet_Cross.Text = "十字架";
            this.tabPage_CamSet_Cross.UseVisualStyleBackColor = true;
            // 
            // label_Markcol
            // 
            this.label_Markcol.AutoSize = true;
            this.label_Markcol.Location = new System.Drawing.Point(23, 31);
            this.label_Markcol.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Markcol.Name = "label_Markcol";
            this.label_Markcol.Size = new System.Drawing.Size(65, 12);
            this.label_Markcol.TabIndex = 0;
            this.label_Markcol.Text = "Mark颜色：";
            // 
            // groupBox_CamOperation
            // 
            this.groupBox_CamOperation.Controls.Add(this.PixelCentregroupBox);
            this.groupBox_CamOperation.Controls.Add(this.CameraKnumericUpDown);
            this.groupBox_CamOperation.Controls.Add(this.label70);
            this.groupBox_CamOperation.Controls.Add(this.OpenCambutton);
            this.groupBox_CamOperation.Controls.Add(this.ComBox__CamSet_Marktypelist);
            this.groupBox_CamOperation.Controls.Add(this.label_CamSet_Marktype);
            this.groupBox_CamOperation.Controls.Add(this.Btn_CamSet_trigger);
            this.groupBox_CamOperation.Controls.Add(this.numUD_CamSet_num);
            this.groupBox_CamOperation.Controls.Add(this.label_CamSet_num);
            this.groupBox_CamOperation.Controls.Add(this.Btn_CamSet_offconnect);
            this.groupBox_CamOperation.Controls.Add(this.Btn_CamSet_Reconnect);
            this.groupBox_CamOperation.Location = new System.Drawing.Point(20, 27);
            this.groupBox_CamOperation.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox_CamOperation.Name = "groupBox_CamOperation";
            this.groupBox_CamOperation.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox_CamOperation.Size = new System.Drawing.Size(645, 123);
            this.groupBox_CamOperation.TabIndex = 0;
            this.groupBox_CamOperation.TabStop = false;
            this.groupBox_CamOperation.Text = "相机操作";
            // 
            // PixelCentregroupBox
            // 
            this.PixelCentregroupBox.Controls.Add(this.label1);
            this.PixelCentregroupBox.Controls.Add(this.label2);
            this.PixelCentregroupBox.Controls.Add(this.CameraCentreXnumericUpDown);
            this.PixelCentregroupBox.Controls.Add(this.CameraCentreYnumericUpDown);
            this.PixelCentregroupBox.Location = new System.Drawing.Point(479, 0);
            this.PixelCentregroupBox.Name = "PixelCentregroupBox";
            this.PixelCentregroupBox.Size = new System.Drawing.Size(166, 123);
            this.PixelCentregroupBox.TabIndex = 2;
            this.PixelCentregroupBox.TabStop = false;
            this.PixelCentregroupBox.Text = "像素中心";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "相素中心坐标X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "相素中心坐标Y";
            // 
            // CameraCentreXnumericUpDown
            // 
            this.CameraCentreXnumericUpDown.DecimalPlaces = 4;
            this.CameraCentreXnumericUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.CameraCentreXnumericUpDown.Location = new System.Drawing.Point(33, 38);
            this.CameraCentreXnumericUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.CameraCentreXnumericUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.CameraCentreXnumericUpDown.Name = "CameraCentreXnumericUpDown";
            this.CameraCentreXnumericUpDown.Size = new System.Drawing.Size(107, 21);
            this.CameraCentreXnumericUpDown.TabIndex = 12;
            this.CameraCentreXnumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.CameraCentreXnumericUpDown.ValueChanged += new System.EventHandler(this.CameraCentreXnumericUpDown_ValueChanged);
            // 
            // CameraCentreYnumericUpDown
            // 
            this.CameraCentreYnumericUpDown.DecimalPlaces = 4;
            this.CameraCentreYnumericUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.CameraCentreYnumericUpDown.Location = new System.Drawing.Point(33, 90);
            this.CameraCentreYnumericUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.CameraCentreYnumericUpDown.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.CameraCentreYnumericUpDown.Name = "CameraCentreYnumericUpDown";
            this.CameraCentreYnumericUpDown.Size = new System.Drawing.Size(107, 21);
            this.CameraCentreYnumericUpDown.TabIndex = 13;
            this.CameraCentreYnumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.CameraCentreYnumericUpDown.ValueChanged += new System.EventHandler(this.CameraCentreYnumericUpDown_ValueChanged);
            // 
            // CameraKnumericUpDown
            // 
            this.CameraKnumericUpDown.DecimalPlaces = 10;
            this.CameraKnumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            655360});
            this.CameraKnumericUpDown.Location = new System.Drawing.Point(257, 20);
            this.CameraKnumericUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.CameraKnumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.CameraKnumericUpDown.Name = "CameraKnumericUpDown";
            this.CameraKnumericUpDown.Size = new System.Drawing.Size(126, 21);
            this.CameraKnumericUpDown.TabIndex = 10;
            this.CameraKnumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            655360});
            this.CameraKnumericUpDown.ValueChanged += new System.EventHandler(this.CameraKnumericUpDown_ValueChanged);
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Location = new System.Drawing.Point(144, 24);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(107, 12);
            this.label70.TabIndex = 8;
            this.label70.Text = "像素K值(mm/pixel)";
            // 
            // OpenCambutton
            // 
            this.OpenCambutton.Location = new System.Drawing.Point(26, 20);
            this.OpenCambutton.Margin = new System.Windows.Forms.Padding(2);
            this.OpenCambutton.Name = "OpenCambutton";
            this.OpenCambutton.Size = new System.Drawing.Size(93, 24);
            this.OpenCambutton.TabIndex = 7;
            this.OpenCambutton.Text = "打开相机";
            this.OpenCambutton.UseVisualStyleBackColor = true;
            this.OpenCambutton.Click += new System.EventHandler(this.OpenCambutton_Click);
            // 
            // ComBox__CamSet_Marktypelist
            // 
            this.ComBox__CamSet_Marktypelist.FormattingEnabled = true;
            this.ComBox__CamSet_Marktypelist.Items.AddRange(new object[] {
            "圆",
            "矩形",
            "十字",
            "模板匹配"});
            this.ComBox__CamSet_Marktypelist.Location = new System.Drawing.Point(257, 92);
            this.ComBox__CamSet_Marktypelist.Margin = new System.Windows.Forms.Padding(2);
            this.ComBox__CamSet_Marktypelist.Name = "ComBox__CamSet_Marktypelist";
            this.ComBox__CamSet_Marktypelist.Size = new System.Drawing.Size(126, 20);
            this.ComBox__CamSet_Marktypelist.TabIndex = 6;
            this.ComBox__CamSet_Marktypelist.SelectedIndexChanged += new System.EventHandler(this.ComBox__CamSet_Marktypelist_SelectedIndexChanged);
            // 
            // label_CamSet_Marktype
            // 
            this.label_CamSet_Marktype.AutoSize = true;
            this.label_CamSet_Marktype.Location = new System.Drawing.Point(144, 96);
            this.label_CamSet_Marktype.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_CamSet_Marktype.Name = "label_CamSet_Marktype";
            this.label_CamSet_Marktype.Size = new System.Drawing.Size(89, 12);
            this.label_CamSet_Marktype.TabIndex = 5;
            this.label_CamSet_Marktype.Text = "Mark类型选择：";
            // 
            // Btn_CamSet_trigger
            // 
            this.Btn_CamSet_trigger.Location = new System.Drawing.Point(404, 54);
            this.Btn_CamSet_trigger.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_CamSet_trigger.Name = "Btn_CamSet_trigger";
            this.Btn_CamSet_trigger.Size = new System.Drawing.Size(62, 24);
            this.Btn_CamSet_trigger.TabIndex = 4;
            this.Btn_CamSet_trigger.Text = "触发拍照";
            this.Btn_CamSet_trigger.UseVisualStyleBackColor = true;
            this.Btn_CamSet_trigger.Click += new System.EventHandler(this.Btn_CamSet_trigger_Click);
            // 
            // numUD_CamSet_num
            // 
            this.numUD_CamSet_num.Location = new System.Drawing.Point(257, 56);
            this.numUD_CamSet_num.Margin = new System.Windows.Forms.Padding(2);
            this.numUD_CamSet_num.Name = "numUD_CamSet_num";
            this.numUD_CamSet_num.Size = new System.Drawing.Size(126, 21);
            this.numUD_CamSet_num.TabIndex = 3;
            this.CameraConfigFormtoolTip.SetToolTip(this.numUD_CamSet_num, "1 开头黑色Mark，2 开头白色Mark");
            this.numUD_CamSet_num.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUD_CamSet_num.ValueChanged += new System.EventHandler(this.numUD_CamSet_num_ValueChanged);
            // 
            // label_CamSet_num
            // 
            this.label_CamSet_num.AutoSize = true;
            this.label_CamSet_num.Location = new System.Drawing.Point(144, 60);
            this.label_CamSet_num.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_CamSet_num.Name = "label_CamSet_num";
            this.label_CamSet_num.Size = new System.Drawing.Size(65, 12);
            this.label_CamSet_num.TabIndex = 2;
            this.label_CamSet_num.Text = "触发代码：";
            // 
            // Btn_CamSet_offconnect
            // 
            this.Btn_CamSet_offconnect.Location = new System.Drawing.Point(26, 88);
            this.Btn_CamSet_offconnect.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_CamSet_offconnect.Name = "Btn_CamSet_offconnect";
            this.Btn_CamSet_offconnect.Size = new System.Drawing.Size(93, 24);
            this.Btn_CamSet_offconnect.TabIndex = 1;
            this.Btn_CamSet_offconnect.Text = "断开相机";
            this.Btn_CamSet_offconnect.UseVisualStyleBackColor = true;
            this.Btn_CamSet_offconnect.Click += new System.EventHandler(this.Btn_CamSet_offconnect_Click);
            // 
            // Btn_CamSet_Reconnect
            // 
            this.Btn_CamSet_Reconnect.Location = new System.Drawing.Point(26, 54);
            this.Btn_CamSet_Reconnect.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_CamSet_Reconnect.Name = "Btn_CamSet_Reconnect";
            this.Btn_CamSet_Reconnect.Size = new System.Drawing.Size(93, 24);
            this.Btn_CamSet_Reconnect.TabIndex = 0;
            this.Btn_CamSet_Reconnect.Text = "重连相机";
            this.Btn_CamSet_Reconnect.UseVisualStyleBackColor = true;
            this.Btn_CamSet_Reconnect.Click += new System.EventHandler(this.Btn_CamSet_Reconnect_Click);
            // 
            // CameraConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 387);
            this.Controls.Add(this.groupBox_Camparam);
            this.Controls.Add(this.groupBox_CamOperation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CameraConfigForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "相加配置";
            this.Load += new System.EventHandler(this.CameraConfigForm_Load);
            this.groupBox_Camparam.ResumeLayout(false);
            this.groupBox_Camparam.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox_CamSet_MarkCol.ResumeLayout(false);
            this.groupBox_CamSet_MarkCol.PerformLayout();
            this.tabControl_CamSet_Mark.ResumeLayout(false);
            this.tabPage_CamSet_Circle.ResumeLayout(false);
            this.tabPage_CamSet_Circle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CamSet_CircleRadiusnumericUpDown)).EndInit();
            this.tabPage_CamSet_Rect.ResumeLayout(false);
            this.tabPage_CamSet_Rect.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CamSet_MarkWidthnumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CamSet_MarkLengthnumericUpDown)).EndInit();
            this.groupBox_CamOperation.ResumeLayout(false);
            this.groupBox_CamOperation.PerformLayout();
            this.PixelCentregroupBox.ResumeLayout(false);
            this.PixelCentregroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CameraCentreXnumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CameraCentreYnumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CameraKnumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_CamSet_num)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox_Camparam;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton Rtn_CamSet_SaveYes;
        private System.Windows.Forms.RadioButton Rtn_CamSet_SaveNo;
        private System.Windows.Forms.GroupBox groupBox_CamSet_MarkCol;
        private System.Windows.Forms.RadioButton Rtn_CamSet_Black;
        private System.Windows.Forms.RadioButton Rtn_CamSet_White;
        private System.Windows.Forms.Button Btn_CamSet_Save;
        private System.Windows.Forms.TabControl tabControl_CamSet_Mark;
        private System.Windows.Forms.TabPage tabPage_CamSet_Circle;
        private System.Windows.Forms.Label label_CamSet_CircleRadio;
        private System.Windows.Forms.TabPage tabPage_CamSet_Rect;
        private System.Windows.Forms.Label label_CamSet_MarkLength;
        private System.Windows.Forms.Label label_CamSet_MarkWidth;
        private System.Windows.Forms.TabPage tabPage_CamSet_Cross;
        private System.Windows.Forms.Label label_Markcol;
        private System.Windows.Forms.GroupBox groupBox_CamOperation;
        private System.Windows.Forms.ComboBox ComBox__CamSet_Marktypelist;
        private System.Windows.Forms.Label label_CamSet_Marktype;
        private System.Windows.Forms.Button Btn_CamSet_trigger;
        private System.Windows.Forms.NumericUpDown numUD_CamSet_num;
        private System.Windows.Forms.Label label_CamSet_num;
        private System.Windows.Forms.Button Btn_CamSet_offconnect;
        private System.Windows.Forms.Button Btn_CamSet_Reconnect;
        private System.Windows.Forms.Button OpenCambutton;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.NumericUpDown CameraKnumericUpDown;
        private System.Windows.Forms.ToolTip CameraConfigFormtoolTip;
        private System.Windows.Forms.NumericUpDown CamSet_CircleRadiusnumericUpDown;
        private System.Windows.Forms.NumericUpDown CamSet_MarkWidthnumericUpDown;
        private System.Windows.Forms.NumericUpDown CamSet_MarkLengthnumericUpDown;
        private System.Windows.Forms.GroupBox PixelCentregroupBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown CameraCentreXnumericUpDown;
        private System.Windows.Forms.NumericUpDown CameraCentreYnumericUpDown;
    }
}


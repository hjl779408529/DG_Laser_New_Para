namespace DG_Laser.FormExtension
{
    partial class ImportFile
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
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LaserWidth = new System.Windows.Forms.NumericUpDown();
            this.LaserHeight = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.AfterPoint = new System.Windows.Forms.NumericUpDown();
            this.BeforePoint = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.PlatformCentre = new System.Windows.Forms.RadioButton();
            this.materialCentre = new System.Windows.Forms.RadioButton();
            this.SelectFile = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.DxfType = new System.Windows.Forms.RadioButton();
            this.GerberType = new System.Windows.Forms.RadioButton();
            this.NCType = new System.Windows.Forms.RadioButton();
            this.LmdType = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.LayerView = new System.Windows.Forms.ListBox();
            this.Confirm = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.ButtontoolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.LaserWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LaserHeight)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AfterPoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeforePoint)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "长度：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "宽度：";
            // 
            // LaserWidth
            // 
            this.LaserWidth.DecimalPlaces = 2;
            this.LaserWidth.Location = new System.Drawing.Point(60, 24);
            this.LaserWidth.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.LaserWidth.Name = "LaserWidth";
            this.LaserWidth.Size = new System.Drawing.Size(73, 21);
            this.LaserWidth.TabIndex = 2;
            // 
            // LaserHeight
            // 
            this.LaserHeight.DecimalPlaces = 2;
            this.LaserHeight.Location = new System.Drawing.Point(60, 65);
            this.LaserHeight.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.LaserHeight.Name = "LaserHeight";
            this.LaserHeight.Size = new System.Drawing.Size(73, 21);
            this.LaserHeight.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LaserHeight);
            this.groupBox1.Controls.Add(this.LaserWidth);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(24, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(201, 98);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "振镜尺寸";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.AfterPoint);
            this.groupBox2.Controls.Add(this.BeforePoint);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(24, 153);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(201, 98);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "数据保留位";
            // 
            // AfterPoint
            // 
            this.AfterPoint.Location = new System.Drawing.Point(111, 65);
            this.AfterPoint.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.AfterPoint.Name = "AfterPoint";
            this.AfterPoint.Size = new System.Drawing.Size(73, 21);
            this.AfterPoint.TabIndex = 3;
            // 
            // BeforePoint
            // 
            this.BeforePoint.Location = new System.Drawing.Point(111, 24);
            this.BeforePoint.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.BeforePoint.Name = "BeforePoint";
            this.BeforePoint.Size = new System.Drawing.Size(73, 21);
            this.BeforePoint.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "小数点后位数：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "小数点前位数：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.PlatformCentre);
            this.groupBox3.Controls.Add(this.materialCentre);
            this.groupBox3.Location = new System.Drawing.Point(240, 30);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(201, 98);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "首图档初始位";
            // 
            // PlatformCentre
            // 
            this.PlatformCentre.AutoSize = true;
            this.PlatformCentre.Location = new System.Drawing.Point(45, 64);
            this.PlatformCentre.Name = "PlatformCentre";
            this.PlatformCentre.Size = new System.Drawing.Size(71, 16);
            this.PlatformCentre.TabIndex = 9;
            this.PlatformCentre.TabStop = true;
            this.PlatformCentre.Text = "平台中心";
            this.PlatformCentre.UseVisualStyleBackColor = true;
            // 
            // materialCentre
            // 
            this.materialCentre.AutoSize = true;
            this.materialCentre.Location = new System.Drawing.Point(45, 31);
            this.materialCentre.Name = "materialCentre";
            this.materialCentre.Size = new System.Drawing.Size(71, 16);
            this.materialCentre.TabIndex = 8;
            this.materialCentre.TabStop = true;
            this.materialCentre.Text = "材料中心";
            this.materialCentre.UseVisualStyleBackColor = true;
            // 
            // SelectFile
            // 
            this.SelectFile.Location = new System.Drawing.Point(24, 269);
            this.SelectFile.Name = "SelectFile";
            this.SelectFile.Size = new System.Drawing.Size(75, 30);
            this.SelectFile.TabIndex = 8;
            this.SelectFile.Text = "导入";
            this.ButtontoolTip.SetToolTip(this.SelectFile, "导入DXF文件");
            this.SelectFile.UseVisualStyleBackColor = true;
            this.SelectFile.Click += new System.EventHandler(this.SelectFile_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.DxfType);
            this.groupBox4.Controls.Add(this.GerberType);
            this.groupBox4.Controls.Add(this.NCType);
            this.groupBox4.Controls.Add(this.LmdType);
            this.groupBox4.Location = new System.Drawing.Point(240, 153);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(201, 98);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "文件格式";
            // 
            // DxfType
            // 
            this.DxfType.AutoSize = true;
            this.DxfType.Location = new System.Drawing.Point(107, 64);
            this.DxfType.Name = "DxfType";
            this.DxfType.Size = new System.Drawing.Size(41, 16);
            this.DxfType.TabIndex = 11;
            this.DxfType.TabStop = true;
            this.DxfType.Text = "Dxf";
            this.DxfType.UseVisualStyleBackColor = true;
            // 
            // GerberType
            // 
            this.GerberType.AutoSize = true;
            this.GerberType.Location = new System.Drawing.Point(107, 31);
            this.GerberType.Name = "GerberType";
            this.GerberType.Size = new System.Drawing.Size(59, 16);
            this.GerberType.TabIndex = 10;
            this.GerberType.TabStop = true;
            this.GerberType.Text = "Gerber";
            this.GerberType.UseVisualStyleBackColor = true;
            // 
            // NCType
            // 
            this.NCType.AutoSize = true;
            this.NCType.Location = new System.Drawing.Point(45, 64);
            this.NCType.Name = "NCType";
            this.NCType.Size = new System.Drawing.Size(35, 16);
            this.NCType.TabIndex = 9;
            this.NCType.TabStop = true;
            this.NCType.Text = "NC";
            this.NCType.UseVisualStyleBackColor = true;
            // 
            // LmdType
            // 
            this.LmdType.AutoSize = true;
            this.LmdType.Location = new System.Drawing.Point(45, 31);
            this.LmdType.Name = "LmdType";
            this.LmdType.Size = new System.Drawing.Size(41, 16);
            this.LmdType.TabIndex = 8;
            this.LmdType.TabStop = true;
            this.LmdType.Text = "LMD";
            this.LmdType.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.LayerView);
            this.groupBox5.Location = new System.Drawing.Point(21, 314);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(420, 154);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "图层预览";
            // 
            // LayerView
            // 
            this.LayerView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayerView.FormattingEnabled = true;
            this.LayerView.ItemHeight = 12;
            this.LayerView.Location = new System.Drawing.Point(3, 17);
            this.LayerView.Name = "LayerView";
            this.LayerView.Size = new System.Drawing.Size(414, 134);
            this.LayerView.TabIndex = 64;
            // 
            // Confirm
            // 
            this.Confirm.Location = new System.Drawing.Point(195, 269);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(75, 30);
            this.Confirm.TabIndex = 13;
            this.Confirm.Text = "确定";
            this.ButtontoolTip.SetToolTip(this.Confirm, "保存配置并确定");
            this.Confirm.UseVisualStyleBackColor = true;
            this.Confirm.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(366, 269);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 30);
            this.Cancel.TabIndex = 14;
            this.Cancel.Text = "取消";
            this.ButtontoolTip.SetToolTip(this.Cancel, "取消并关闭窗口");
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // ImportFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 474);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.Confirm);
            this.Controls.Add(this.SelectFile);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImportFile";
            this.Text = "导入文件";
            this.Load += new System.EventHandler(this.ImportFile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LaserWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LaserHeight)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AfterPoint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeforePoint)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown LaserWidth;
        private System.Windows.Forms.NumericUpDown LaserHeight;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown AfterPoint;
        private System.Windows.Forms.NumericUpDown BeforePoint;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton materialCentre;
        private System.Windows.Forms.RadioButton PlatformCentre;
        private System.Windows.Forms.Button SelectFile;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton DxfType;
        private System.Windows.Forms.RadioButton GerberType;
        private System.Windows.Forms.RadioButton NCType;
        private System.Windows.Forms.RadioButton LmdType;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button Confirm;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.ToolTip ButtontoolTip;
        private System.Windows.Forms.ListBox LayerView;
    }
}
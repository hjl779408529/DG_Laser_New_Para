namespace DG_Laser
{
    partial class MarkConfig
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
            this.DocumentcomboBox = new System.Windows.Forms.ComboBox();
            this.DxfMarkInfoListBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.RefreshMarkList = new System.Windows.Forms.Button();
            this.LeftDownY = new System.Windows.Forms.NumericUpDown();
            this.LeftDownX = new System.Windows.Forms.NumericUpDown();
            this.label86 = new System.Windows.Forms.Label();
            this.label87 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ConfirmMark = new System.Windows.Forms.Button();
            this.MarkConfigtoolTip = new System.Windows.Forms.ToolTip(this.components);
            this.GoPoint = new System.Windows.Forms.Button();
            this.RefreshPlatForm = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.PlatformlistBox = new System.Windows.Forms.ListBox();
            this.Cancel = new System.Windows.Forms.Button();
            this.Confirm = new System.Windows.Forms.Button();
            this.CertifyMarkbutton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.LeftDownY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftDownX)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "文档名";
            // 
            // DocumentcomboBox
            // 
            this.DocumentcomboBox.FormattingEnabled = true;
            this.DocumentcomboBox.Location = new System.Drawing.Point(79, 36);
            this.DocumentcomboBox.Name = "DocumentcomboBox";
            this.DocumentcomboBox.Size = new System.Drawing.Size(167, 20);
            this.DocumentcomboBox.TabIndex = 11;
            // 
            // DxfMarkInfoListBox
            // 
            this.DxfMarkInfoListBox.FormattingEnabled = true;
            this.DxfMarkInfoListBox.ItemHeight = 12;
            this.DxfMarkInfoListBox.Location = new System.Drawing.Point(25, 102);
            this.DxfMarkInfoListBox.Name = "DxfMarkInfoListBox";
            this.DxfMarkInfoListBox.Size = new System.Drawing.Size(221, 184);
            this.DxfMarkInfoListBox.TabIndex = 64;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 65;
            this.label2.Text = "文档Mark列表";
            // 
            // RefreshMarkList
            // 
            this.RefreshMarkList.Location = new System.Drawing.Point(171, 72);
            this.RefreshMarkList.Name = "RefreshMarkList";
            this.RefreshMarkList.Size = new System.Drawing.Size(75, 23);
            this.RefreshMarkList.TabIndex = 66;
            this.RefreshMarkList.Text = "更新";
            this.RefreshMarkList.UseVisualStyleBackColor = true;
            this.RefreshMarkList.Click += new System.EventHandler(this.RefreshMarkList_Click);
            // 
            // LeftDownY
            // 
            this.LeftDownY.DecimalPlaces = 3;
            this.LeftDownY.Increment = new decimal(new int[] {
            5,
            0,
            0,
            196608});
            this.LeftDownY.Location = new System.Drawing.Point(26, 152);
            this.LeftDownY.Margin = new System.Windows.Forms.Padding(2);
            this.LeftDownY.Maximum = new decimal(new int[] {
            350,
            0,
            0,
            0});
            this.LeftDownY.Name = "LeftDownY";
            this.LeftDownY.Size = new System.Drawing.Size(76, 21);
            this.LeftDownY.TabIndex = 167;
            this.LeftDownY.Value = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            // 
            // LeftDownX
            // 
            this.LeftDownX.DecimalPlaces = 3;
            this.LeftDownX.Increment = new decimal(new int[] {
            5,
            0,
            0,
            196608});
            this.LeftDownX.Location = new System.Drawing.Point(26, 98);
            this.LeftDownX.Margin = new System.Windows.Forms.Padding(2);
            this.LeftDownX.Maximum = new decimal(new int[] {
            350,
            0,
            0,
            0});
            this.LeftDownX.Name = "LeftDownX";
            this.LeftDownX.Size = new System.Drawing.Size(76, 21);
            this.LeftDownX.TabIndex = 166;
            this.LeftDownX.Value = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.Location = new System.Drawing.Point(38, 133);
            this.label86.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(53, 12);
            this.label86.TabIndex = 165;
            this.label86.Text = "Y坐标/mm";
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.Location = new System.Drawing.Point(38, 79);
            this.label87.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(53, 12);
            this.label87.TabIndex = 164;
            this.label87.Text = "X坐标/mm";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ConfirmMark);
            this.groupBox1.Controls.Add(this.LeftDownY);
            this.groupBox1.Controls.Add(this.LeftDownX);
            this.groupBox1.Controls.Add(this.label86);
            this.groupBox1.Controls.Add(this.label87);
            this.groupBox1.Location = new System.Drawing.Point(262, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(127, 186);
            this.groupBox1.TabIndex = 168;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "左下平台坐标";
            // 
            // ConfirmMark
            // 
            this.ConfirmMark.Location = new System.Drawing.Point(27, 37);
            this.ConfirmMark.Name = "ConfirmMark";
            this.ConfirmMark.Size = new System.Drawing.Size(75, 23);
            this.ConfirmMark.TabIndex = 169;
            this.ConfirmMark.Text = "录入";
            this.MarkConfigtoolTip.SetToolTip(this.ConfirmMark, "将当前平台坐标赋值为左下平台坐标");
            this.ConfirmMark.UseVisualStyleBackColor = true;
            this.ConfirmMark.Click += new System.EventHandler(this.ConfirmMark_Click);
            // 
            // GoPoint
            // 
            this.GoPoint.Location = new System.Drawing.Point(651, 108);
            this.GoPoint.Name = "GoPoint";
            this.GoPoint.Size = new System.Drawing.Size(77, 33);
            this.GoPoint.TabIndex = 172;
            this.GoPoint.Text = "定位";
            this.MarkConfigtoolTip.SetToolTip(this.GoPoint, "定位至选中坐标");
            this.GoPoint.UseVisualStyleBackColor = true;
            this.GoPoint.Click += new System.EventHandler(this.GoPoint_Click);
            // 
            // RefreshPlatForm
            // 
            this.RefreshPlatForm.Location = new System.Drawing.Point(559, 72);
            this.RefreshPlatForm.Name = "RefreshPlatForm";
            this.RefreshPlatForm.Size = new System.Drawing.Size(75, 23);
            this.RefreshPlatForm.TabIndex = 171;
            this.RefreshPlatForm.Text = "更新";
            this.RefreshPlatForm.UseVisualStyleBackColor = true;
            this.RefreshPlatForm.Click += new System.EventHandler(this.RefreshPlatForm_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(411, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 170;
            this.label3.Text = "平台实际坐标列表";
            // 
            // PlatformlistBox
            // 
            this.PlatformlistBox.FormattingEnabled = true;
            this.PlatformlistBox.ItemHeight = 12;
            this.PlatformlistBox.Location = new System.Drawing.Point(413, 102);
            this.PlatformlistBox.Name = "PlatformlistBox";
            this.PlatformlistBox.Size = new System.Drawing.Size(221, 184);
            this.PlatformlistBox.TabIndex = 169;
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(651, 225);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(77, 33);
            this.Cancel.TabIndex = 174;
            this.Cancel.Text = "取消";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // Confirm
            // 
            this.Confirm.Location = new System.Drawing.Point(651, 186);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(77, 33);
            this.Confirm.TabIndex = 173;
            this.Confirm.Text = "保存";
            this.Confirm.UseVisualStyleBackColor = true;
            this.Confirm.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // CertifyMarkbutton
            // 
            this.CertifyMarkbutton.Location = new System.Drawing.Point(651, 147);
            this.CertifyMarkbutton.Name = "CertifyMarkbutton";
            this.CertifyMarkbutton.Size = new System.Drawing.Size(77, 33);
            this.CertifyMarkbutton.TabIndex = 175;
            this.CertifyMarkbutton.Text = "校验Mark";
            this.MarkConfigtoolTip.SetToolTip(this.CertifyMarkbutton, "校验Mark序列");
            this.CertifyMarkbutton.UseVisualStyleBackColor = true;
            this.CertifyMarkbutton.Click += new System.EventHandler(this.CertifyMarkbutton_Click);
            // 
            // MarkConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 309);
            this.Controls.Add(this.CertifyMarkbutton);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Confirm);
            this.Controls.Add(this.GoPoint);
            this.Controls.Add(this.RefreshPlatForm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PlatformlistBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.RefreshMarkList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DxfMarkInfoListBox);
            this.Controls.Add(this.DocumentcomboBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MarkConfig";
            this.Text = "MarkConfig";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MarkConfig_FormClosed);
            this.Load += new System.EventHandler(this.MarkConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LeftDownY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftDownX)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox DocumentcomboBox;
        private System.Windows.Forms.ListBox DxfMarkInfoListBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button RefreshMarkList;
        private System.Windows.Forms.NumericUpDown LeftDownY;
        private System.Windows.Forms.NumericUpDown LeftDownX;
        private System.Windows.Forms.Label label86;
        private System.Windows.Forms.Label label87;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ConfirmMark;
        private System.Windows.Forms.ToolTip MarkConfigtoolTip;
        private System.Windows.Forms.Button RefreshPlatForm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox PlatformlistBox;
        private System.Windows.Forms.Button GoPoint;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button Confirm;
        private System.Windows.Forms.Button CertifyMarkbutton;
    }
}
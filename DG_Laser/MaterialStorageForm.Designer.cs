namespace DG_Laser
{
    partial class MaterialStorageForm
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
            this.MaterialStoragetreeView = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.CreateProductbutton = new System.Windows.Forms.Button();
            this.DeleteProductbutton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.PosYRnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.PosXRnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.PosYnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.PosXnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.WidthnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.HeightnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.ThicknessnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.MaterialNametextBox = new System.Windows.Forms.TextBox();
            this.ProductNametextBox = new System.Windows.Forms.TextBox();
            this.CreateMaterialbutton = new System.Windows.Forms.Button();
            this.DeleteMaterialbutton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.PosYRnumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PosXRnumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PosYnumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PosXnumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthnumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightnumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThicknessnumericUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // MaterialStoragetreeView
            // 
            this.MaterialStoragetreeView.Location = new System.Drawing.Point(15, 26);
            this.MaterialStoragetreeView.Name = "MaterialStoragetreeView";
            this.MaterialStoragetreeView.Size = new System.Drawing.Size(193, 412);
            this.MaterialStoragetreeView.TabIndex = 0;
            this.MaterialStoragetreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.MaterialStoragetreeView_AfterSelect);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "物料库";
            // 
            // CreateProductbutton
            // 
            this.CreateProductbutton.Location = new System.Drawing.Point(242, 143);
            this.CreateProductbutton.Name = "CreateProductbutton";
            this.CreateProductbutton.Size = new System.Drawing.Size(99, 33);
            this.CreateProductbutton.TabIndex = 2;
            this.CreateProductbutton.Text = "新建产品";
            this.CreateProductbutton.UseVisualStyleBackColor = true;
            this.CreateProductbutton.Click += new System.EventHandler(this.CreateProductbutton_Click);
            // 
            // DeleteProductbutton
            // 
            this.DeleteProductbutton.Enabled = false;
            this.DeleteProductbutton.Location = new System.Drawing.Point(242, 186);
            this.DeleteProductbutton.Name = "DeleteProductbutton";
            this.DeleteProductbutton.Size = new System.Drawing.Size(99, 33);
            this.DeleteProductbutton.TabIndex = 3;
            this.DeleteProductbutton.Text = "删除产品";
            this.DeleteProductbutton.UseVisualStyleBackColor = true;
            this.DeleteProductbutton.Click += new System.EventHandler(this.DeleteProductbutton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "产品名称";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "材料名称";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "厚度(mm)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "长(mm)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "宽(mm)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "Y(mm)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 12);
            this.label8.TabIndex = 11;
            this.label8.Text = "X(mm)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 112);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 14;
            this.label9.Text = "YR(°)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(25, 83);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 13;
            this.label10.Text = "XR(°)";
            // 
            // PosYRnumericUpDown
            // 
            this.PosYRnumericUpDown.DecimalPlaces = 3;
            this.PosYRnumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.PosYRnumericUpDown.Location = new System.Drawing.Point(81, 108);
            this.PosYRnumericUpDown.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.PosYRnumericUpDown.Name = "PosYRnumericUpDown";
            this.PosYRnumericUpDown.Size = new System.Drawing.Size(67, 21);
            this.PosYRnumericUpDown.TabIndex = 15;
            // 
            // PosXRnumericUpDown
            // 
            this.PosXRnumericUpDown.DecimalPlaces = 3;
            this.PosXRnumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.PosXRnumericUpDown.Location = new System.Drawing.Point(81, 79);
            this.PosXRnumericUpDown.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.PosXRnumericUpDown.Name = "PosXRnumericUpDown";
            this.PosXRnumericUpDown.Size = new System.Drawing.Size(67, 21);
            this.PosXRnumericUpDown.TabIndex = 16;
            // 
            // PosYnumericUpDown
            // 
            this.PosYnumericUpDown.DecimalPlaces = 1;
            this.PosYnumericUpDown.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.PosYnumericUpDown.Location = new System.Drawing.Point(81, 50);
            this.PosYnumericUpDown.Maximum = new decimal(new int[] {
            350,
            0,
            0,
            0});
            this.PosYnumericUpDown.Name = "PosYnumericUpDown";
            this.PosYnumericUpDown.Size = new System.Drawing.Size(67, 21);
            this.PosYnumericUpDown.TabIndex = 17;
            // 
            // PosXnumericUpDown
            // 
            this.PosXnumericUpDown.DecimalPlaces = 1;
            this.PosXnumericUpDown.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.PosXnumericUpDown.Location = new System.Drawing.Point(81, 21);
            this.PosXnumericUpDown.Maximum = new decimal(new int[] {
            350,
            0,
            0,
            0});
            this.PosXnumericUpDown.Name = "PosXnumericUpDown";
            this.PosXnumericUpDown.Size = new System.Drawing.Size(67, 21);
            this.PosXnumericUpDown.TabIndex = 18;
            // 
            // WidthnumericUpDown
            // 
            this.WidthnumericUpDown.DecimalPlaces = 1;
            this.WidthnumericUpDown.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.WidthnumericUpDown.Location = new System.Drawing.Point(82, 50);
            this.WidthnumericUpDown.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.WidthnumericUpDown.Name = "WidthnumericUpDown";
            this.WidthnumericUpDown.Size = new System.Drawing.Size(67, 21);
            this.WidthnumericUpDown.TabIndex = 19;
            // 
            // HeightnumericUpDown
            // 
            this.HeightnumericUpDown.DecimalPlaces = 1;
            this.HeightnumericUpDown.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.HeightnumericUpDown.Location = new System.Drawing.Point(82, 18);
            this.HeightnumericUpDown.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.HeightnumericUpDown.Name = "HeightnumericUpDown";
            this.HeightnumericUpDown.Size = new System.Drawing.Size(67, 21);
            this.HeightnumericUpDown.TabIndex = 20;
            // 
            // ThicknessnumericUpDown
            // 
            this.ThicknessnumericUpDown.DecimalPlaces = 2;
            this.ThicknessnumericUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.ThicknessnumericUpDown.Location = new System.Drawing.Point(108, 97);
            this.ThicknessnumericUpDown.Name = "ThicknessnumericUpDown";
            this.ThicknessnumericUpDown.Size = new System.Drawing.Size(67, 21);
            this.ThicknessnumericUpDown.TabIndex = 21;
            // 
            // MaterialNametextBox
            // 
            this.MaterialNametextBox.Location = new System.Drawing.Point(108, 61);
            this.MaterialNametextBox.Name = "MaterialNametextBox";
            this.MaterialNametextBox.Size = new System.Drawing.Size(100, 21);
            this.MaterialNametextBox.TabIndex = 22;
            // 
            // ProductNametextBox
            // 
            this.ProductNametextBox.Location = new System.Drawing.Point(108, 25);
            this.ProductNametextBox.Name = "ProductNametextBox";
            this.ProductNametextBox.Size = new System.Drawing.Size(100, 21);
            this.ProductNametextBox.TabIndex = 23;
            // 
            // CreateMaterialbutton
            // 
            this.CreateMaterialbutton.Enabled = false;
            this.CreateMaterialbutton.Location = new System.Drawing.Point(242, 229);
            this.CreateMaterialbutton.Name = "CreateMaterialbutton";
            this.CreateMaterialbutton.Size = new System.Drawing.Size(99, 33);
            this.CreateMaterialbutton.TabIndex = 4;
            this.CreateMaterialbutton.Text = "新建材料";
            this.CreateMaterialbutton.UseVisualStyleBackColor = true;
            this.CreateMaterialbutton.Click += new System.EventHandler(this.CreateMaterialbutton_Click);
            // 
            // DeleteMaterialbutton
            // 
            this.DeleteMaterialbutton.Enabled = false;
            this.DeleteMaterialbutton.Location = new System.Drawing.Point(242, 272);
            this.DeleteMaterialbutton.Name = "DeleteMaterialbutton";
            this.DeleteMaterialbutton.Size = new System.Drawing.Size(99, 33);
            this.DeleteMaterialbutton.TabIndex = 5;
            this.DeleteMaterialbutton.Text = "删除材料";
            this.DeleteMaterialbutton.UseVisualStyleBackColor = true;
            this.DeleteMaterialbutton.Click += new System.EventHandler(this.DeleteMaterialbutton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.HeightnumericUpDown);
            this.groupBox1.Controls.Add(this.WidthnumericUpDown);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(26, 148);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(181, 87);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "尺寸";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.PosXnumericUpDown);
            this.groupBox2.Controls.Add(this.PosYnumericUpDown);
            this.groupBox2.Controls.Add(this.PosXRnumericUpDown);
            this.groupBox2.Controls.Add(this.PosYRnumericUpDown);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(26, 259);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(181, 134);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "材料位置(左下角)";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.ProductNametextBox);
            this.groupBox3.Controls.Add(this.MaterialNametextBox);
            this.groupBox3.Controls.Add(this.ThicknessnumericUpDown);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(375, 26);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(235, 412);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "物料属性";
            // 
            // MaterialStorageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 450);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.DeleteMaterialbutton);
            this.Controls.Add(this.CreateMaterialbutton);
            this.Controls.Add(this.DeleteProductbutton);
            this.Controls.Add(this.CreateProductbutton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MaterialStoragetreeView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MaterialStorageForm";
            this.Text = "物料管理";
            this.Load += new System.EventHandler(this.MaterialStorageForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PosYRnumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PosXRnumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PosYnumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PosXnumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthnumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightnumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThicknessnumericUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView MaterialStoragetreeView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CreateProductbutton;
        private System.Windows.Forms.Button DeleteProductbutton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown PosYRnumericUpDown;
        private System.Windows.Forms.NumericUpDown PosXRnumericUpDown;
        private System.Windows.Forms.NumericUpDown PosYnumericUpDown;
        private System.Windows.Forms.NumericUpDown PosXnumericUpDown;
        private System.Windows.Forms.NumericUpDown WidthnumericUpDown;
        private System.Windows.Forms.NumericUpDown HeightnumericUpDown;
        private System.Windows.Forms.NumericUpDown ThicknessnumericUpDown;
        private System.Windows.Forms.TextBox MaterialNametextBox;
        private System.Windows.Forms.TextBox ProductNametextBox;
        private System.Windows.Forms.Button CreateMaterialbutton;
        private System.Windows.Forms.Button DeleteMaterialbutton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}
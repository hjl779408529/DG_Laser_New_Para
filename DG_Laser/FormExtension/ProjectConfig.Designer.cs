namespace DG_Laser.FormExtension
{
    partial class ProjectConfig
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ProjectNametextBox = new System.Windows.Forms.TextBox();
            this.ProductNamecomboBox = new System.Windows.Forms.ComboBox();
            this.MaterialNamecomboBox = new System.Windows.Forms.ComboBox();
            this.Confirm = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.MaterialConfig = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "产品：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "物料：";
            // 
            // ProjectNametextBox
            // 
            this.ProjectNametextBox.Location = new System.Drawing.Point(88, 36);
            this.ProjectNametextBox.Name = "ProjectNametextBox";
            this.ProjectNametextBox.Size = new System.Drawing.Size(135, 21);
            this.ProjectNametextBox.TabIndex = 3;
            // 
            // ProductNamecomboBox
            // 
            this.ProductNamecomboBox.FormattingEnabled = true;
            this.ProductNamecomboBox.Location = new System.Drawing.Point(88, 92);
            this.ProductNamecomboBox.Name = "ProductNamecomboBox";
            this.ProductNamecomboBox.Size = new System.Drawing.Size(135, 20);
            this.ProductNamecomboBox.TabIndex = 4;
            this.ProductNamecomboBox.SelectedIndexChanged += new System.EventHandler(this.ProductNamecomboBox_SelectedIndexChanged);
            // 
            // MaterialNamecomboBox
            // 
            this.MaterialNamecomboBox.FormattingEnabled = true;
            this.MaterialNamecomboBox.Location = new System.Drawing.Point(88, 148);
            this.MaterialNamecomboBox.Name = "MaterialNamecomboBox";
            this.MaterialNamecomboBox.Size = new System.Drawing.Size(135, 20);
            this.MaterialNamecomboBox.TabIndex = 5;
            this.MaterialNamecomboBox.SelectedIndexChanged += new System.EventHandler(this.MaterialNamecomboBox_SelectedIndexChanged);
            // 
            // Confirm
            // 
            this.Confirm.Location = new System.Drawing.Point(267, 31);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(109, 31);
            this.Confirm.TabIndex = 6;
            this.Confirm.Text = "确定";
            this.Confirm.UseVisualStyleBackColor = true;
            this.Confirm.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(267, 87);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(109, 31);
            this.Cancel.TabIndex = 7;
            this.Cancel.Text = "取消";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // MaterialConfig
            // 
            this.MaterialConfig.Location = new System.Drawing.Point(267, 143);
            this.MaterialConfig.Name = "MaterialConfig";
            this.MaterialConfig.Size = new System.Drawing.Size(109, 31);
            this.MaterialConfig.TabIndex = 8;
            this.MaterialConfig.Text = "物料配置";
            this.MaterialConfig.UseVisualStyleBackColor = true;
            this.MaterialConfig.Click += new System.EventHandler(this.MaterialConfig_Click);
            // 
            // ProjectConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 210);
            this.Controls.Add(this.MaterialConfig);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Confirm);
            this.Controls.Add(this.MaterialNamecomboBox);
            this.Controls.Add(this.ProductNamecomboBox);
            this.Controls.Add(this.ProjectNametextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProjectConfig";
            this.Text = "项目配置";
            this.Load += new System.EventHandler(this.ProjectConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ProjectNametextBox;
        private System.Windows.Forms.ComboBox ProductNamecomboBox;
        private System.Windows.Forms.ComboBox MaterialNamecomboBox;
        private System.Windows.Forms.Button Confirm;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button MaterialConfig;
    }
}
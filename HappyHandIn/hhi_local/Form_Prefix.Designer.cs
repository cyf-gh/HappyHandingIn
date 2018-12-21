namespace HappyHandIn {
    partial class Form_Prefix {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.btn_ok = new System.Windows.Forms.Button();
            this.tb_prefixname = new System.Windows.Forms.MaskedTextBox();
            this.tb_start = new System.Windows.Forms.MaskedTextBox();
            this.tb_end = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(208, 129);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(79, 26);
            this.btn_ok.TabIndex = 0;
            this.btn_ok.Text = "完成";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // tb_prefixname
            // 
            this.tb_prefixname.Location = new System.Drawing.Point(71, 12);
            this.tb_prefixname.Name = "tb_prefixname";
            this.tb_prefixname.Size = new System.Drawing.Size(216, 21);
            this.tb_prefixname.TabIndex = 1;
            // 
            // tb_start
            // 
            this.tb_start.Location = new System.Drawing.Point(14, 63);
            this.tb_start.Name = "tb_start";
            this.tb_start.Size = new System.Drawing.Size(273, 21);
            this.tb_start.TabIndex = 2;
            // 
            // tb_end
            // 
            this.tb_end.Location = new System.Drawing.Point(14, 102);
            this.tb_end.Name = "tb_end";
            this.tb_end.Size = new System.Drawing.Size(273, 21);
            this.tb_end.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "预设名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "起始学号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(127, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 12);
            this.label3.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "结束学号";
            // 
            // Form_Prefix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 166);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_end);
            this.Controls.Add(this.tb_start);
            this.Controls.Add(this.tb_prefixname);
            this.Controls.Add(this.btn_ok);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_Prefix";
            this.Text = "添加预设";
            this.Load += new System.EventHandler(this.Form_Prefix_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.MaskedTextBox tb_prefixname;
        private System.Windows.Forms.MaskedTextBox tb_start;
        private System.Windows.Forms.MaskedTextBox tb_end;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}
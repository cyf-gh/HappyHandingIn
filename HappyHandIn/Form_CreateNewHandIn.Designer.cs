namespace HappyHandIn {
    partial class Form_CreateNewHandIn {
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
            this.textbox_workname = new System.Windows.Forms.MaskedTextBox();
            this.btn_ok = new System.Windows.Forms.Button();
            this.combox_prefix = new System.Windows.Forms.ComboBox();
            this.folderBrow = new System.Windows.Forms.FolderBrowserDialog();
            this.checkbox_IsFolder = new System.Windows.Forms.CheckBox();
            this.btn_openpath = new System.Windows.Forms.Button();
            this.static_name = new System.Windows.Forms.Label();
            this.static_path_name = new System.Windows.Forms.Label();
            this.textbox_regex = new System.Windows.Forms.MaskedTextBox();
            this.static_regex = new System.Windows.Forms.Label();
            this.static_prefix = new System.Windows.Forms.Label();
            this.tb_dl = new System.Windows.Forms.MaskedTextBox();
            this.static_dl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textbox_workname
            // 
            this.textbox_workname.Location = new System.Drawing.Point(47, 12);
            this.textbox_workname.Name = "textbox_workname";
            this.textbox_workname.Size = new System.Drawing.Size(285, 21);
            this.textbox_workname.TabIndex = 0;
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(247, 221);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(83, 28);
            this.btn_ok.TabIndex = 1;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // combox_prefix
            // 
            this.combox_prefix.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combox_prefix.FormattingEnabled = true;
            this.combox_prefix.Location = new System.Drawing.Point(47, 39);
            this.combox_prefix.Name = "combox_prefix";
            this.combox_prefix.Size = new System.Drawing.Size(286, 20);
            this.combox_prefix.TabIndex = 3;
            // 
            // folderBrow
            // 
            this.folderBrow.HelpRequest += new System.EventHandler(this.folderBrow_HelpRequest);
            // 
            // checkbox_IsFolder
            // 
            this.checkbox_IsFolder.AutoSize = true;
            this.checkbox_IsFolder.Location = new System.Drawing.Point(14, 140);
            this.checkbox_IsFolder.Name = "checkbox_IsFolder";
            this.checkbox_IsFolder.Size = new System.Drawing.Size(96, 16);
            this.checkbox_IsFolder.TabIndex = 5;
            this.checkbox_IsFolder.Text = "IsItemFolder";
            this.checkbox_IsFolder.UseVisualStyleBackColor = true;
            this.checkbox_IsFolder.CheckedChanged += new System.EventHandler(this.checkbox_IsFolder_CheckedChanged);
            // 
            // btn_openpath
            // 
            this.btn_openpath.Location = new System.Drawing.Point(14, 90);
            this.btn_openpath.Name = "btn_openpath";
            this.btn_openpath.Size = new System.Drawing.Size(75, 23);
            this.btn_openpath.TabIndex = 7;
            this.btn_openpath.Text = "OpenPath";
            this.btn_openpath.UseVisualStyleBackColor = true;
            this.btn_openpath.Click += new System.EventHandler(this.btn_openpath_Click);
            // 
            // static_name
            // 
            this.static_name.AutoSize = true;
            this.static_name.Location = new System.Drawing.Point(12, 15);
            this.static_name.Name = "static_name";
            this.static_name.Size = new System.Drawing.Size(29, 12);
            this.static_name.TabIndex = 8;
            this.static_name.Text = "Name";
            // 
            // static_path_name
            // 
            this.static_path_name.AutoSize = true;
            this.static_path_name.Location = new System.Drawing.Point(12, 73);
            this.static_path_name.Name = "static_path_name";
            this.static_path_name.Size = new System.Drawing.Size(35, 12);
            this.static_path_name.TabIndex = 9;
            this.static_path_name.Text = "Path:";
            // 
            // textbox_regex
            // 
            this.textbox_regex.Location = new System.Drawing.Point(14, 178);
            this.textbox_regex.Name = "textbox_regex";
            this.textbox_regex.Size = new System.Drawing.Size(318, 21);
            this.textbox_regex.TabIndex = 10;
            this.textbox_regex.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.textbox_regex_MaskInputRejected);
            // 
            // static_regex
            // 
            this.static_regex.AutoSize = true;
            this.static_regex.Location = new System.Drawing.Point(12, 163);
            this.static_regex.Name = "static_regex";
            this.static_regex.Size = new System.Drawing.Size(29, 12);
            this.static_regex.TabIndex = 11;
            this.static_regex.Text = "Name";
            // 
            // static_prefix
            // 
            this.static_prefix.AutoSize = true;
            this.static_prefix.Location = new System.Drawing.Point(12, 42);
            this.static_prefix.Name = "static_prefix";
            this.static_prefix.Size = new System.Drawing.Size(29, 12);
            this.static_prefix.TabIndex = 12;
            this.static_prefix.Text = "预设";
            // 
            // tb_dl
            // 
            this.tb_dl.Enabled = false;
            this.tb_dl.Location = new System.Drawing.Point(212, 92);
            this.tb_dl.Name = "tb_dl";
            this.tb_dl.Size = new System.Drawing.Size(100, 21);
            this.tb_dl.TabIndex = 13;
            // 
            // static_dl
            // 
            this.static_dl.AutoSize = true;
            this.static_dl.Location = new System.Drawing.Point(210, 77);
            this.static_dl.Name = "static_dl";
            this.static_dl.Size = new System.Drawing.Size(53, 12);
            this.static_dl.TabIndex = 14;
            this.static_dl.Text = "截止日期";
            // 
            // Form_CreateNewHandIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 261);
            this.Controls.Add(this.static_dl);
            this.Controls.Add(this.tb_dl);
            this.Controls.Add(this.static_prefix);
            this.Controls.Add(this.static_regex);
            this.Controls.Add(this.textbox_regex);
            this.Controls.Add(this.static_path_name);
            this.Controls.Add(this.static_name);
            this.Controls.Add(this.btn_openpath);
            this.Controls.Add(this.checkbox_IsFolder);
            this.Controls.Add(this.combox_prefix);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.textbox_workname);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_CreateNewHandIn";
            this.Text = "Form_CreateNewHandIn";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_CreateOnClose);
            this.Load += new System.EventHandler(this.Form_CreateNewHandIn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox textbox_workname;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.ComboBox combox_prefix;
        private System.Windows.Forms.FolderBrowserDialog folderBrow;
        private System.Windows.Forms.CheckBox checkbox_IsFolder;
        private System.Windows.Forms.Button btn_openpath;
        private System.Windows.Forms.Label static_name;
        private System.Windows.Forms.Label static_path_name;
        private System.Windows.Forms.MaskedTextBox textbox_regex;
        private System.Windows.Forms.Label static_regex;
        private System.Windows.Forms.Label static_prefix;
        private System.Windows.Forms.MaskedTextBox tb_dl;
        private System.Windows.Forms.Label static_dl;
    }
}
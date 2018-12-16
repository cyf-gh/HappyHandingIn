using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HappyHandIn {
    public partial class Form_CreateNewHandIn : Form {
        public Form_CreateNewHandIn() {
            InitializeComponent();
            CenterToScreen();
        }
        private const string default_path = "not a path";
        private bool valiedDataSet = false;
        private void checkbox_IsFolder_CheckedChanged(Object sender, EventArgs e) {
            if ( checkbox_IsFolder.Checked ) {
                textbox_regex.Enabled = true;
            } else {
                textbox_regex.Enabled = false;
            }
        }

        public HHI_HandIn GetData(out bool isvaliedDataSet) {
            isvaliedDataSet = valiedDataSet;
            if (valiedDataSet) {
                return new HHI_HandIn() {
                    name = textbox_workname.Text,
                    isSubItemFolder = textbox_regex.Enabled,
                    path = folderBrow.SelectedPath,
                    regex = textbox_regex.Text,
                    prefix_name = combox_prefix.Text
                };
            } else {
                return new HHI_HandIn();
            }
        }
        private void btn_openpath_Click(Object sender, EventArgs e) {
            folderBrow.ShowDialog();
            static_path_name.Text = "路径：" + folderBrow.SelectedPath;
        }

        private void btn_ok_Click(Object sender, EventArgs e) {
            if (default_path == folderBrow.SelectedPath) {
                MessageBox.Show(cn_strs.err_no_path);
                return;
            }
            if (textbox_workname.Text == null ) {
                MessageBox.Show(cn_strs.err_no_name);
                return;
            }
            foreach (var item in HHI_Module.listHandInData) {
                if (item.name == textbox_workname.Text) {
                    MessageBox.Show("已存在方案 " + item.name);
                    return;
                }
            }
            valiedDataSet = true;
        }

        private void Form_CreateNewHandIn_Load(Object sender, EventArgs e) {
            this.Text = "创新建方案";
            btn_ok.Text = "完成";
            btn_openpath.Text = "选择路径";
            static_name.Text = "名字";
            static_regex.Text = "子文件要求";
            checkbox_IsFolder.Text = "子项是否是文件夹";
            static_path_name.Text = "路径：";
            combox_prefix.DataSource = HHI_Module.listPrefixes;
            combox_prefix.ValueMember = "id";
            combox_prefix.DisplayMember = "name";
            folderBrow.SelectedPath = default_path;
            textbox_workname.Text = null;
            textbox_regex.Text = null;
            textbox_regex.Enabled = false;
        }

        private void Form_CreateOnClose(Object sender, EventArgs e) {
        }

        private void folderBrow_HelpRequest(Object sender, EventArgs e) {
        }

        private void textbox_regex_MaskInputRejected(Object sender, MaskInputRejectedEventArgs e) {

        }
    }
}

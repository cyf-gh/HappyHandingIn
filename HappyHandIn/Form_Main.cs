using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace HappyHandIn {
    public partial class Form_Main : Form {
        public Form_Main() {
            InitializeComponent();
            CenterToScreen();
        }
        private string m_output;
        private string m_log;
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void newHandInToolStripMenuItem_Click(Object sender, EventArgs e) {
            Form_CreateNewHandIn tForm_CreateNewHandIn = new Form_CreateNewHandIn();
            tForm_CreateNewHandIn.ShowDialog();
        }

        private void Form_Main_Load(Object sender, EventArgs e) {
            HHI_Module.LoadPrefixs();
            HHI_Module.LoadHandIns();
            label_resultOutPut.Text = cn_strs.str_weclome;
            static_handIn.Text = cn_strs.str_select_handin;
            fileToolStripMenuItem.Text = "文件";
            newHandInToolStripMenuItem.Text = "创建新方案";
            exitToolStripMenuItem.Text = "退出";
            prefixToolStripMenuItem.Text = "预设";
            saveToolStripMenuItem.Text = "保存...";
            saveHHIToolStripMenuItem.Text = "保存所有新方案";
            savePrefixsToolStripMenuItem.Text = "保存所有预设";
            saveAllToolStripMenuItem.Text = "保存所有";
            btn_check.Text = "检查";
            comboBox_handIns.DataSource = HHI_Module.listHandInData;
            comboBox_handIns.ValueMember = "id";
            comboBox_handIns.DisplayMember = "name";
        }

        private void newToolStripMenuItem_Click(Object sender, EventArgs e) {
            Form_Prefix tForm_prefix = new Form_Prefix();
            tForm_prefix.ShowDialog();
        }

        private void btn_check_Click(Object sender, EventArgs e) {
            m_log += m_output;
            m_output = "";
            ProcessCheck();
        }

        private HHI_HandIn GetCurrentHandIn() {
            foreach (var item in HHI_Module.listHandInData) {
                if (item.name == comboBox_handIns.Text) {
                    return item;
                }
            }
            return null;
        }

        private HHI_Prefix GetCurrentHandInsPrefix() {
            HHI_HandIn hi = GetCurrentHandIn();
            foreach (var prefix in HHI_Module.listPrefixes) {
                if (prefix.name == hi.prefix_name) {
                    return prefix;
                }
            }
            return null;
        }

        private void ProcessCheck() {
            HHI_Prefix tprefix = GetCurrentHandInsPrefix();
            HHI_HandIn hi = GetCurrentHandIn();

            if (!Directory.Exists(hi.path)) {
                MessageBox.Show("错误：作业路径不存在\n"+"当前该方案的路径为"+hi.path+"\n请检查错误");
                return;
            }

            if ( tprefix == null ) {
                m_output += "错误：无该预设\n";
            }

            List<int> digit = HHI_Module.GetUnAttachedWorkIndexs(hi, tprefix);

            m_output += "\n" + "[" + System.DateTime.Now.ToString() + "]" + "\n" + "作业名: " + hi.name + "\n\n";
            // !process file
            if (digit.Count == 0) {
                m_output += "已全部收齐！";
            } else {
                m_output += "以下编号尚未交作业：" + "\n";
                foreach (var d in digit) {
                    m_output += d.ToString() + "   ";
                }
                m_output += "\n" + "共" + digit.Count.ToString() +"人";
            }
                    
            label_resultOutPut.Text = m_output;
            return;

        }

        private void saveToolStripMenuItem_Click(Object sender, EventArgs e) {

        }

        private void savePrefixsToolStripMenuItem_Click(Object sender, EventArgs e) {
            HHI_Module.SavePrefixs();
        }

        private void saveHHIToolStripMenuItem_Click(Object sender, EventArgs e) {
            HHI_Module.SaveHandInDatum();
        }

        private void saveAllToolStripMenuItem_Click(Object sender, EventArgs e) {
            HHI_Module.SavePrefixs();
            HHI_Module.SaveHandInDatum();
        }

        private void 关于ToolStripMenuItem_Click(Object sender, EventArgs e) {

        }

        private void saveLogToolStripMenuItem_Click(Object sender, EventArgs e) {
            HHI_Module.SaveLog(m_log);
        }

        private void btn_attach_Click(object sender, EventArgs e) {
            HHI_HandIn hi = GetCurrentHandIn();
            HHI_Prefix prefix = GetCurrentHandInsPrefix();
            string name;
            string studentIndex;
            string srcPath;

            if (hi.isSubItemFolder) {
                folderBrowserDialog1.ShowDialog();
                srcPath = folderBrowserDialog1.SelectedPath;
                name = folderBrowserDialog1.SelectedPath.Substring(folderBrowserDialog1.SelectedPath.LastIndexOf('\\') + 1);               
            } else {
                openFileDialog1.ShowDialog();
                srcPath = openFileDialog1.FileName;
                name = openFileDialog1.FileName.Substring(openFileDialog1.FileName.LastIndexOf('\\') + 1);
            }
            if (srcPath == "") {
                return;
            }
            studentIndex = HHI_Module.FileNameToIndex(name);
            int nStudentIndex = Convert.ToInt32(studentIndex);
            if (!stUtils.generic.IsIn(HHI_Module.GetPrefixIndexList(prefix), nStudentIndex))
            {
                MessageBox.Show("目前的学号为：" + studentIndex + " 学号有误，请重新检查", "错误");
                return;
            }

            if (stUtils.generic.IsIn(HHI_Module.GetUnAttachedWorkIndexs(hi, prefix), nStudentIndex))
            {
                if (MessageBox.Show("学号: " + studentIndex + " 已经提交，是否要覆盖？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    // Yes
                    stUtils.file.Copy(srcPath, hi.path, hi.isSubItemFolder);
                }
                else
                {
                    // No
                    return;
                }
            }
            else
            {
                stUtils.file.Copy(srcPath, hi.path, hi.isSubItemFolder);
            }
            m_output += "\n" + "[" + System.DateTime.Now.ToString() + "]" + "学号为: " + studentIndex + " 的同学，已提交作业！\n";
            label_resultOutPut.Text = m_output;
            m_log +=  m_output;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            
        }

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("cyf 2018\nMail: cyf-ms@hotmail.com\n本软件遵守类zlib开源协议");
        }

        private void btn_openfolderinexplore_Click(object sender, EventArgs e) {
            HHI_HandIn hi = GetCurrentHandIn();
            if (!Directory.Exists(hi.path)) {
                MessageBox.Show("错误：作业路径不存在\n"+"当前该方案的路径为"+hi.path+"\n请检查错误");
                return;
            }
            System.Diagnostics.Process.Start("explorer.exe", hi.path);
        }

        private void btn_detailsofhhi_Click(object sender, EventArgs e)
        {
            HHI_HandIn hhi = GetCurrentHandIn();
            MessageBox.Show(
                "作业名称：" + hhi.name +
                "\n作业路径：" +hhi.path +
                "\n作业预设方案：" + hhi.prefix_name
                );
        }
    }
}

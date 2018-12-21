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
using stLib_CS;
using stLib_CS.Generic;
using stLib_CS.File;
using hhi_modules;

namespace hhi_local {
    public partial class Form_Main : Form {
        public Form_Main() {
            m_TargetFolder = "";
            InitializeComponent();
            CenterToScreen();
        }
        private FileSystemInfo[] m_fileinfo;
        private string m_output;
        private string m_log;
        private string m_TargetFolder;
        private void exitToolStripMenuItem_Click( object sender, EventArgs e ) {
            Application.Exit();
        }

        private void newHandInToolStripMenuItem_Click( Object sender, EventArgs e ) {
            Form_CreateNewHandIn tForm_CreateNewHandIn = new Form_CreateNewHandIn();
            tForm_CreateNewHandIn.ShowDialog();
        }
        private void ReloadList() {
            HHI_HandIn hi = GetCurrentHandIn();
            DirectoryInfo dir = new DirectoryInfo( hi.Path );
            m_fileinfo = dir.GetFileSystemInfos();
            lb_folder.DataSource = m_fileinfo;
        }
        private void Form_Main_Load( Object sender, EventArgs e ) {
            HHI_Module.LoadPrefixs();
            HHI_Module.LoadHandIns();
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
            ReloadList();
        }

        private void newToolStripMenuItem_Click( Object sender, EventArgs e ) {
            Form_Prefix tForm_prefix = new Form_Prefix();
            tForm_prefix.ShowDialog();
        }

        private void btn_check_Click( Object sender, EventArgs e ) {
            m_log += m_output;
            m_output = "";
            ProcessCheck();
        }

        private HHI_HandIn GetCurrentHandIn() {
            foreach( var item in HHI_Module.listHandInData ) {
                if( item.Name == comboBox_handIns.Text ) {
                    return item;
                }
            }
            return null;
        }

        private HHI_Prefix GetCurrentHandInsPrefix() {
            HHI_HandIn hi = GetCurrentHandIn();
            foreach( var prefix in HHI_Module.listPrefixes ) {
                if( prefix.Name == hi.PrefixName ) {
                    return prefix;
                }
            }
            return null;
        }

        private void ProcessCheck() {
            HHI_Prefix tprefix = GetCurrentHandInsPrefix();
            HHI_HandIn hi = GetCurrentHandIn();

            if( !Directory.Exists( hi.Path ) ) {
                MessageBox.Show( "错误：作业路径不存在\n" + "当前该方案的路径为" + hi.Path + "\n请检查错误" );
                return;
            }

            if( tprefix == null ) {
                m_output += "错误：无该预设\n";
            }

            List<int> digit = HHI_Module.GetUnAttachedWorkIndexs( hi, tprefix );

            m_output += "\n" + "[" + System.DateTime.Now.ToString() + "]" + "\n" + "作业名: " + hi.Name + "\n\n";
            // !process file
            if( digit.Count == 0 ) {
                m_output += "已全部收齐！";
            } else {
                m_output += "以下编号尚未交作业：" + "\n";
                foreach( var d in digit ) {
                    m_output += d.ToString() + "   ";
                }
                m_output += "\n" + "共" + digit.Count.ToString() + "人";
            }

            MessageBox.Show( m_output );
            return;

        }

        private void saveToolStripMenuItem_Click( Object sender, EventArgs e ) {

        }

        private void savePrefixsToolStripMenuItem_Click( Object sender, EventArgs e ) {
            HHI_Module.SavePrefixs();
        }

        private void saveHHIToolStripMenuItem_Click( Object sender, EventArgs e ) {
            HHI_Module.SaveHandInDatum();
        }

        private void saveAllToolStripMenuItem_Click( Object sender, EventArgs e ) {
            HHI_Module.SavePrefixs();
            HHI_Module.SaveHandInDatum();
        }

        private void AboutToolStripMenuItem_Click( Object sender, EventArgs e ) {

        }

        private void saveLogToolStripMenuItem_Click( Object sender, EventArgs e ) {
            HHI_Module.SaveLog( m_log );
        }

        private void btn_attach_Click( object sender, EventArgs e ) {
            HHI_HandIn hi = GetCurrentHandIn();
            HHI_Prefix prefix = GetCurrentHandInsPrefix();
            string name;
            string studentIndex;
            string srcPath;

            if( hi.IsSubItemFolder ) {
                folderBrowserDialog1.ShowDialog();
                srcPath = folderBrowserDialog1.SelectedPath;
                name = folderBrowserDialog1.SelectedPath.Substring( folderBrowserDialog1.SelectedPath.LastIndexOf( '\\' ) + 1 );
            } else {
                openFileDialog1.ShowDialog();
                srcPath = openFileDialog1.FileName;
                name = openFileDialog1.FileName.Substring( openFileDialog1.FileName.LastIndexOf( '\\' ) + 1 );
            }
            if( srcPath == "" ) {
                return;
            }
            if ( !HHI_Module.IndexExist( name, prefix, out studentIndex ) ) {
                return;
            }

            if( !ListHelper.IsIn( HHI_Module.GetUnAttachedWorkIndexs( hi, prefix ), Convert.ToInt32(studentIndex ) ) ) {
                if( MessageBox.Show( "学号: " + studentIndex + " 已经提交，是否要覆盖？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question ) == DialogResult.OK ) {
                    // Yes
                    CopyHelper.Copy( srcPath, hi.Path, hi.IsSubItemFolder );
                } else {
                    // No
                    return;
                }
            } else {
                CopyHelper.Copy( srcPath, hi.Path, hi.IsSubItemFolder );
            }
            ReloadList();
            m_output += "\n" + "[" + System.DateTime.Now.ToString() + "]" + "学号为: " + studentIndex + " 的同学，已提交作业！\n";
            MessageBox.Show( m_output );
            m_log += m_output;
        }

        private void openFileDialog1_FileOk( object sender, CancelEventArgs e ) {

        }

        private void detailsToolStripMenuItem_Click( object sender, EventArgs e ) {
            MessageBox.Show( "cyf 2018\nMail: cyf-ms@hotmail.com\n本软件遵守类zlib开源协议" );
        }

        private void btn_openfolderinexplore_Click( object sender, EventArgs e ) {
            HHI_HandIn hi = GetCurrentHandIn();
            if( !Directory.Exists( hi.Path ) ) {
                MessageBox.Show( "错误：作业路径不存在\n" + "当前该方案的路径为" + hi.Path + "\n请检查错误" );
                return;
            }
            System.Diagnostics.Process.Start( "explorer.exe", hi.Path );
        }

        private void btn_detailsofhhi_Click( object sender, EventArgs e ) {
            HHI_HandIn hhi = GetCurrentHandIn();
            MessageBox.Show(
                "作业名称：" + hhi.Name +
                "\n作业路径：" + hhi.Path +
                "\n作业预设方案：" + hhi.PrefixName
                );
        }

        private void comboBox_handIns_SelectedIndexChanged( Object sender, EventArgs e ) {

        }

        private void lb_folder_SelectedIndexChanged( Object sender, EventArgs e ) {
            // System.Diagnostics.Process.Start( "explorer.exe", m_fileinfo[lb_folder.SelectedIndex].FullName );
            if( m_fileinfo[lb_folder.SelectedIndex] is DirectoryInfo ) {
                return;
            }
            if( stLib_CS.File.FileHelper.IsPicture( m_fileinfo[lb_folder.SelectedIndex].FullName ) ) {
                try { 
                    pictureBox1.Image = Image.FromFile( m_fileinfo[lb_folder.SelectedIndex].FullName );
                } catch {
                }
            }
        }

        private void lb_folder_Click( Object sender, EventArgs e ) {
            // System.Diagnostics.Process.Start( "explorer.exe", m_fileinfo[lb_folder.SelectedIndex].FullName );
            if( m_fileinfo[lb_folder.SelectedIndex] is DirectoryInfo ) {
                return;
            }
            if( stLib_CS.File.FileHelper.IsPicture( m_fileinfo[lb_folder.SelectedIndex].FullName ) ) {
                try { 
                    pictureBox1.Image = Image.FromFile( m_fileinfo[lb_folder.SelectedIndex].FullName );
                } catch {
                    MessageBox.Show("图片有误，尝试使用外部程序打开");
                    System.Diagnostics.Process.Start( m_fileinfo[lb_folder.SelectedIndex].FullName );
                }
            }
        }

        private void btn_back_to_root_Click( Object sender, EventArgs e ) {
            ReloadList();
        }

        private void lb_folder_DoubleClick( Object sender, EventArgs e ) {
            if( m_fileinfo[lb_folder.SelectedIndex] is DirectoryInfo ) {
                m_fileinfo = new DirectoryInfo( m_fileinfo[lb_folder.SelectedIndex].FullName ).GetFileSystemInfos();
                lb_folder.DataSource = m_fileinfo;
            } else {
                if( stLib_CS.File.FileHelper.IsPicture( m_fileinfo[lb_folder.SelectedIndex].FullName ) ) {
                    pictureBox1.Image = Image.FromFile( m_fileinfo[lb_folder.SelectedIndex].FullName );
                } else {
                    System.Diagnostics.Process.Start( m_fileinfo[lb_folder.SelectedIndex].FullName );
                }
            }
        }

        private void menuStrip1_ItemClicked( Object sender, ToolStripItemClickedEventArgs e ) {

        }
    }
}

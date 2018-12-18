using System;  
using System.Collections.Generic;  
using System.ComponentModel;  
using System.Data;  
using System.Drawing;  
using System.Linq;  
using System.Text;  
using System.Windows.Forms;  
using System.Runtime.InteropServices;  
using System.IO;
namespace stUtils {
    class list_operate {
        public static bool IsIn<T>(List<T> list, T item) {
            for( int i = 0; i < list.Count; ++i ) {
                if (list[i].Equals( item )) {
                    return true;
                }
            }
            return false;
        }
        
    }
    class file_opreate {

        public static void Copy(string srcPath, string destPath, bool isFolder) {
            if (isFolder)
            {
                CopyDirectoryByAPI(srcPath, destPath + srcPath.Substring( srcPath.LastIndexOf("\\") ));
            }
            else
            {
                CopyFile(srcPath, destPath);
            }
        }
        public static void CopyDirectory(string srcPath, string destPath)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(srcPath);
                FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();  //获取目录下（不包含子目录）的文件和子目录
                foreach (FileSystemInfo i in fileinfo)
                {
                    if (i is DirectoryInfo)     //判断是否文件夹
                    {
                        if (!Directory.Exists(destPath + "\\" + i.Name))
                        {
                            Directory.CreateDirectory(destPath + "\\" + i.Name);   //目标目录下不存在此文件夹即创建子文件夹
                        }
                        CopyDirectory(i.FullName, destPath + "\\" + i.Name);    //递归调用复制子文件夹
                    }
                    else
                    {
                        File.Copy(i.FullName, destPath + "\\" + i.Name, true);      //不是文件夹即复制文件，true表示可以覆盖同名文件
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public static void CopyDirectoryByAPI(string srcPath, string destPath)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(srcPath);
                FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();  //获取目录下（不包含子目录）的文件和子目录
                foreach (FileSystemInfo i in fileinfo)
                {
                    if (i is DirectoryInfo)     //判断是否文件夹
                    {
                        if (!Directory.Exists(destPath + "\\" + i.Name))
                        {
                            Directory.CreateDirectory(destPath + "\\" + i.Name);   //目标目录下不存在此文件夹即创建子文件夹
                        }
                        CopyDirectory(i.FullName, destPath + "\\" + i.Name);    //递归调用复制子文件夹
                    }
                    else
                    {
                        CopyFile(i.FullName, destPath + "\\" + i.Name);      //不是文件夹即复制文件，true表示可以覆盖同名文件
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
     private const int FO_COPY = 0x0002;  
        private const int FOF_ALLOWUNDO = 0x00044;  
        //显示进度条  0x00044 // 不显示一个进度对话框 0x0100 显示进度对话框单不显示进度条  0x0002显示进度条和对话框  
        private const int FOF_SILENT = 0x0002;//0x0100;  
        //  
        [StructLayout(LayoutKind.Sequential,   CharSet = CharSet.Auto,Pack=0)]    
        public struct SHFILEOPSTRUCT    
        {  
            public IntPtr hwnd;    
            [MarshalAs(UnmanagedType.U4)]    
            public int wFunc;    
            public string pFrom;   
            public string pTo;   
            public short fFlags;    
            [MarshalAs(UnmanagedType.Bool)]    
            public bool fAnyOperationsAborted;   
            public IntPtr hNameMappings;   
            public string lpszProgressTitle;    
        }  
        [DllImport("shell32.dll",   CharSet = CharSet.Auto)]   
        static extern int SHFileOperation(ref SHFILEOPSTRUCT FileOp);    
        public static bool CopyFile(string strSource, string strTarget)   
        {   
            SHFILEOPSTRUCT fileop = new SHFILEOPSTRUCT();  
            fileop.wFunc = FO_COPY;    
            fileop.pFrom = strSource;  
            fileop.lpszProgressTitle = "快乐收作业复制小助手";  
            fileop.pTo = strTarget;   
            //fileop.fFlags = FOF_ALLOWUNDO;  
            fileop.fFlags = FOF_SILENT;  
            return  SHFileOperation(ref  fileop)==0;   
        }   
    }
}

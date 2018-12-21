using System;
using System.Management.Instrumentation;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections;
using System.Diagnostics;
using System.Management;
using System.Net;
using System.Text.RegularExpressions;

namespace stUtils {
    public static class generic {
        public static bool IsIn<T>(List<T> list, T item) {
            for( int i = 0; i < list.Count; ++i ) {
                if (list[i].Equals( item )) {
                    return true;
                }
            }
            return false;
        }
        public static bool RemoveIn<T>(List<T> list, T item) {
            for (int i = 0; i < list.Count; ++i)
            {
                if (list[i].Equals(item))
                {
                    list.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
    }
    public static class file {
        public static void Copy(string srcPath, string destPath, bool isFolder) {
            if (isFolder)
            {
                CopyDirectoryByAPI(srcPath, destPath + srcPath.Substring( srcPath.LastIndexOf("\\") ));
            }
            else
            {
                CopyFileByAPI(srcPath, destPath);
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
                throw e;
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
                        CopyFileByAPI(i.FullName, destPath + "\\" + i.Name);      //不是文件夹即复制文件，true表示可以覆盖同名文件
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
        public static bool CopyFileByAPI(string strSource, string strTarget)   
        {   
            SHFILEOPSTRUCT fileop = new SHFILEOPSTRUCT();  
            fileop.wFunc = FO_COPY;
            fileop.pFrom = strSource;  
            fileop.lpszProgressTitle = "process";  
            fileop.pTo = strTarget;   
            //fileop.fFlags = FOF_ALLOWUNDO;  
            fileop.fFlags = FOF_SILENT;  
            return  SHFileOperation(ref  fileop)==0;   
        }   
    }
    public static class ip
    {
        /// <summary>
        /// 设置IP地址信息
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="submask"></param>
        /// <param name="gatway"></param>
        /// <param name="dns"></param>
        public static void SetIPAddress(string[] ip, string[] submask, string[] gatway, string[] dns)
        {
            System.Management.
            ManagementClass wmi = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = wmi.GetInstances();
            ManagementBaseObject inPar = null;
            ManagementBaseObject outPar = null;
            foreach (ManagementObject mo in moc)
            {
                //如果没有启用IP设置的网络设备则跳过
                if (!(bool)mo["IPEnabled"])
                {
                    continue;
                }
                //设置IP地址和掩码

                if (ip != null && submask != null)
                {
                    inPar = mo.GetMethodParameters("EnableStatic");
                    inPar["IPAddress"] = ip;
                    inPar["SubnetMask"] = submask;
                    outPar = mo.InvokeMethod("EnableStatic", inPar, null);
                }

                //设置网关地址

                if (gatway != null)
                {
                    inPar = mo.GetMethodParameters("SetGateways");
                    inPar["DefaultIPGateway"] = gatway;
                    outPar = mo.InvokeMethod("SetGateways", inPar, null);
                }

                //设置DNS地址

                if (dns != null)
                {
                    inPar = mo.GetMethodParameters("SetDNSServerSearchOrder");
                    inPar["DNSServerSearchOrder"] = dns;
                    outPar = mo.InvokeMethod("SetDNSServerSearchOrder", inPar, null);
                }
            }
        }
        /// <summary>
        /// 开启DHCP
        /// </summary>
        public static void EnableDHCP()
        {
            ManagementClass wmi = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = wmi.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                //如果没有启用IP设置的网络设备则跳过

                if (!(bool)mo["IPEnabled"])
                    continue;

                //重置DNS为空

                mo.InvokeMethod("SetDNSServerSearchOrder", null);
                //开启DHCP

                mo.InvokeMethod("EnableDHCP", null);
            }
        }
        /// <summary>
        /// 判断IP地址的合法性
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIPAddress(string ip)
        {
            string[] arr = ip.Split('.');
            if (arr.Length != 4)
                return false;

            string pattern = @"\d{1,3}";
            for (int i = 0; i < arr.Length; i++)
            {
                string d = arr[i];
                if (i == 0 && d == "0")
                    return false;
                if (!Regex.IsMatch(d, pattern))
                    return false;

                if (d != "0")
                {
                    d = d.TrimStart('0');
                    if (d == "")
                        return false;

                    if (int.Parse(d) > 255)
                        return false;
                }
            }

            return true;
        }
        /// <summary>

        /// 设置DNS

        /// </summary>

        /// <param name="dns"></param>

        public static void SetDNS(string[] dns)
        {
            SetIPAddress(null, null, null, dns);
        }
        /// <summary>

        /// 设置网关

        /// </summary>

        /// <param name="getway"></param>

        public static void SetGetWay(string getway)
        {
            SetIPAddress(null, null, new string[] { getway }, null);
        }
        /// <summary>

        /// 设置网关

        /// </summary>

        /// <param name="getway"></param>

        public static void SetGetWay(string[] getway)
        {
            SetIPAddress(null, null, getway, null);
        }
        /// <summary>

        /// 设置IP地址和掩码

        /// </summary>

        /// <param name="ip"></param>

        /// <param name="submask"></param>

        public static void SetIPAddress(string ip, string submask)
        {
            SetIPAddress(new string[] { ip }, new string[] { submask }, null, null);
        }
        /// <summary>

        /// 设置IP地址，掩码和网关

        /// </summary>

        /// <param name="ip"></param>

        /// <param name="submask"></param>

        /// <param name="getway"></param>

        public static void SetIPAddress(string ip, string submask, string getway)
        {
            SetIPAddress(new string[] { ip }, new string[] { submask }, new string[] { getway }, null);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace DG_Laser
{
    class Process_Operate
    {
        /// <summary>
        /// 获取指定名称的线程信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Process[] GetProcessInformation(string name)
        {
            return Process.GetProcessesByName(name);
        }
        /// <summary>
        /// 启动某个程序
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool StartApp(string name)
        {
            Process[] p = Process.GetProcessesByName(name);
            if (p.Length > 0)//至少存在
            {
                KillApp(name);
                Thread.Sleep(100);
                string filepath = @"./\Cam/" + name + ".exe";
                if (File.Exists(filepath))
                {
                    Process.Start(filepath);
                    Thread.Sleep(1000);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else//无线程存在
            {
                string filepath = @"./\Cam/" + name + ".exe";
                if (File.Exists(filepath))
                {
                    Process.Start(filepath);
                    Thread.Sleep(1000);
                    return true;
                }
                else
                {
                    return false;
                }                
            }           
        }
        /// <summary>
        /// 终止某个线程
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool KillApp(string name)
        {
            Process[] p = Process.GetProcessesByName(name);
            foreach(Process ps in p)
            {
                ps.Kill();
            }
            return true;
        }
    }
}

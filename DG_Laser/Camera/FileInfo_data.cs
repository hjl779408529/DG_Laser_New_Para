using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
namespace LaserVision_info
{
    class FileInfo_data
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retval, int size, string filePath);
        private string spath = null;


        public FileInfo_data(string path)
        {
            this.spath = System.Windows.Forms.Application.StartupPath + path;
        }
        public void Write(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, spath);
        }
        public string ReadValue(string section, string key)
        {
            System.Text.StringBuilder temp = new System.Text.StringBuilder(255);
            GetPrivateProfileString(section, key, "", temp, 255, spath);
            return temp.ToString();
        }
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    Form1 ini = new Form1("F:/config_Qcd.ini");
        //    ini.Write("Setting", "key1", "H_Word1");
        //    ini.Write("Setting", "key2", "H_Word2");
        //}

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    Form1 ini = new Form1("F:/config_Qcd.ini");
        //    string str1 = ini.ReadValue("Setting", "key1");
        //    MessageBox.Show(str1);
        //}
    }
}

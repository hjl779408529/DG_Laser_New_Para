using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DG_Laser
{
    /// <summary>
    /// 重复参数页面
    /// </summary>
    partial class MainForm
    {
        /// <summary>
        /// 刀具列表初始化
        /// </summary>
        private void RepeatListContainerInitial() 
        {
            Repeat_List.SelectedIndex = 0;//默认列表1
            Repeat_Times_UpDown.Value = Program.SystemContainer.SysPara.Work_Repeat_Times;
            Repeat_Times_UpDown.Maximum = Program.SystemContainer.SysPara.Work_Repeat_Limit;
            RepeatListView.DataSource = null;
            RepeatListView.DataSource = Common_Collect.Repeat_Para_To_DT(Program.SystemContainer.Repeat_Drill_Scissor, 0);
            for (int i = Program.SystemContainer.SysPara.Work_Repeat_Times + 1; i < Program.SystemContainer.SysPara.Work_Repeat_Limit + 1; i++)
                RepeatListView.Columns["第" + i + "次"].Visible = false;
        }   
        /// <summary>
        /// 刷新重复参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Repeat_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            Refresh_DataGrid();
        }
        /// <summary>
        /// 刷新Datagrid
        /// </summary>
        private void Refresh_DataGrid()
        {
            switch (Repeat_List.SelectedIndex)
            {
                case 0:
                    RepeatListView.DataSource = null;
                    RepeatListView.DataSource = Common_Collect.Repeat_Para_To_DT(Program.SystemContainer.Repeat_Drill_Scissor, 0);
                    for (int i = Program.SystemContainer.SysPara.Work_Repeat_Times + 1; i < Program.SystemContainer.SysPara.Work_Repeat_Limit + 1; i++)
                        RepeatListView.Columns["第" + i + "次"].Visible = false;
                    break;
                case 1:
                    RepeatListView.DataSource = null;
                    RepeatListView.DataSource = Common_Collect.Repeat_Para_To_DT(Program.SystemContainer.Repeat_Arc_Scissor, 1);
                    for (int i = Program.SystemContainer.SysPara.Work_Repeat_Times + 1; i < Program.SystemContainer.SysPara.Work_Repeat_Limit + 1; i++)
                        RepeatListView.Columns["第" + i + "次"].Visible = false;
                    break;
                case 2:
                    RepeatListView.DataSource = null;
                    RepeatListView.DataSource = Common_Collect.Repeat_Para_To_DT(Program.SystemContainer.Repeat_Line_Scissor, 2);
                    for (int i = Program.SystemContainer.SysPara.Work_Repeat_Times + 1; i < Program.SystemContainer.SysPara.Work_Repeat_Limit + 1; i++)
                        RepeatListView.Columns["第" + i + "次"].Visible = false;
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 保存重复参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RepeatListSave_Click(object sender, EventArgs e)
        {
            switch (Repeat_List.SelectedIndex)
            {
                case 0:
                    Program.SystemContainer.Repeat_Drill_Scissor = Common_Collect.DT_Repeat_Para_To(RepeatListView.DataSource as DataTable);
                    Common_Collect.Serialize<Repeat_Parameter>(Program.SystemContainer.Repeat_Drill_Scissor, "Scissor_Parameter/Repeat_Drill_Para.xml");//钻孔线型重复加工参数 保存
                    break;
                case 1:
                    Program.SystemContainer.Repeat_Arc_Scissor = Common_Collect.DT_Repeat_Para_To(RepeatListView.DataSource as DataTable);
                    Common_Collect.Serialize<Repeat_Parameter>(Program.SystemContainer.Repeat_Arc_Scissor, "Scissor_Parameter/Repeat_Arc_Para.xml");//圆弧线型重复加工参数 保存
                    break;
                case 2:
                    Program.SystemContainer.Repeat_Line_Scissor = Common_Collect.DT_Repeat_Para_To(RepeatListView.DataSource as DataTable);
                    Common_Collect.Serialize<Repeat_Parameter>(Program.SystemContainer.Repeat_Line_Scissor, "Scissor_Parameter/Repeat_Line_Para.xml");//线段线型重复加工参数 保存
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 重复次数修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Repeat_Times_UpDown_ValueChanged(object sender, EventArgs e)
        {
            Program.SystemContainer.SysPara.Work_Repeat_Times = (byte)Repeat_Times_UpDown.Value;//获取重复次数数值
            Refresh_DataGrid();
        }
        /// <summary>
        /// 重复参数读取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RepeatListSaveLoad_Click(object sender, EventArgs e)
        {
            string File_Name1 = "Scissor_Parameter/Repeat_Drill_Para.xml";
            string File_Name2 = "Scissor_Parameter/Repeat_Arc_Para.xml";
            string File_Name3 = "Scissor_Parameter/Repeat_Line_Para.xml";
            string File_Path1 = @"./\Config/" + File_Name1;
            string File_Path2 = @"./\Config/" + File_Name2;
            string File_Path3 = @"./\Config/" + File_Name3;  
            switch (Repeat_List.SelectedIndex)
            {
                case 0:
                    if (File.Exists(File_Path1)) Program.SystemContainer.Repeat_Drill_Scissor = Common_Collect.Reserialize<Repeat_Parameter>(File_Name1);//钻孔线型重复加工参数 读取
                    RepeatListView.DataSource = null;
                    RepeatListView.DataSource = Common_Collect.Repeat_Para_To_DT(Program.SystemContainer.Repeat_Drill_Scissor, 0);
                    for (int i = Program.SystemContainer.SysPara.Work_Repeat_Times + 1; i < Program.SystemContainer.SysPara.Work_Repeat_Limit + 1; i++)
                        RepeatListView.Columns["第" + i + "次"].Visible = false;
                    break;
                case 1:
                    if (File.Exists(File_Path2)) Program.SystemContainer.Repeat_Arc_Scissor = Common_Collect.Reserialize<Repeat_Parameter>(File_Name2);//圆弧线型重复加工参数 读取
                    RepeatListView.DataSource = null;
                    RepeatListView.DataSource = Common_Collect.Repeat_Para_To_DT(Program.SystemContainer.Repeat_Arc_Scissor, 1);
                    for (int i = Program.SystemContainer.SysPara.Work_Repeat_Times + 1; i < Program.SystemContainer.SysPara.Work_Repeat_Limit + 1; i++)
                        RepeatListView.Columns["第" + i + "次"].Visible = false;
                    break;
                case 2:
                    if (File.Exists(File_Path3)) Program.SystemContainer.Repeat_Line_Scissor = Common_Collect.Reserialize<Repeat_Parameter>(File_Name3);//直线线型重复加工参数 读取
                    RepeatListView.DataSource = null;
                    RepeatListView.DataSource = Common_Collect.Repeat_Para_To_DT(Program.SystemContainer.Repeat_Line_Scissor, 2);
                    for (int i = Program.SystemContainer.SysPara.Work_Repeat_Times + 1; i < Program.SystemContainer.SysPara.Work_Repeat_Limit + 1; i++)
                        RepeatListView.Columns["第" + i + "次"].Visible = false;
                    break;
                default:
                    break;
            }
        }
    }
}

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
    /// 刀具参数页面
    /// </summary>
    partial class MainForm
    {
        /// <summary>
        /// 刀具列表初始化
        /// </summary>
        private void ScissorListContainerInitial()
        {
            Scissor_List.SelectedIndex = 0;//默认列表1
            ScissorListView.DataSource = null;
            ScissorListView.DataSource = Common_Collect.ListToDt(Program.SystemContainer.Drill_Scissor);
        }
        /// <summary>
        /// 刷新刀具列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Scissor_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Scissor_List.SelectedIndex)
            {
                case 0:
                    ScissorListView.DataSource = null;
                    ScissorListView.DataSource = Common_Collect.ListToDt(Program.SystemContainer.Drill_Scissor);
                    break;
                case 1:
                    ScissorListView.DataSource = null;
                    ScissorListView.DataSource = Common_Collect.ListToDt(Program.SystemContainer.Arc_Scissor);
                    ScissorListView.Columns["Cutter_Type"].Visible = false;
                    ScissorListView.Columns["Cutter_Radius"].Visible = false;
                    break;
                case 2:
                    ScissorListView.DataSource = null;
                    ScissorListView.DataSource = Common_Collect.ListToDt(Program.SystemContainer.Line_Scissor);
                    ScissorListView.Columns["Cutter_Type"].Visible = false;
                    ScissorListView.Columns["Cutter_Radius"].Visible = false;
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 刀具参数保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScissorListSave_Click(object sender, EventArgs e)
        {
            
            switch (Scissor_List.SelectedIndex)
            {
                case 0:
                    Program.SystemContainer.Drill_Scissor = Common_Collect.DtToList<Tech_Parameter>.ConvertToModel(ScissorListView.DataSource as DataTable);
                    CSV_RW.SaveCSV_NoDate(Common_Collect.ListToDt<Tech_Parameter>(Program.SystemContainer.Drill_Scissor), "Scissor_Parameter/Drill_Para.csv");//钻孔刀具参数 保存
                    break;
                case 1:
                    Program.SystemContainer.Arc_Scissor = Common_Collect.DtToList<Tech_Parameter>.ConvertToModel(ScissorListView.DataSource as DataTable);
                    CSV_RW.SaveCSV_NoDate(Common_Collect.ListToDt<Tech_Parameter>(Program.SystemContainer.Arc_Scissor), "Scissor_Parameter/Arc_Para.csv");//圆弧刀具参数 保存
                    break;
                case 2:
                    Program.SystemContainer.Line_Scissor = Common_Collect.DtToList<Tech_Parameter>.ConvertToModel(ScissorListView.DataSource as DataTable);
                    CSV_RW.SaveCSV_NoDate(Common_Collect.ListToDt<Tech_Parameter>(Program.SystemContainer.Line_Scissor), "Scissor_Parameter/Line_Para.csv");//线段刀具参数 保存
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 刀具参数读取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScissorListLoad_Click(object sender, EventArgs e)
        {
            string File_Path1 = @"./\Config/" + "Scissor_Parameter/Drill_Para.csv";
            string File_Path2 = @"./\Config/" + "Scissor_Parameter/Arc_Para.csv";
            string File_Path3 = @"./\Config/" + "Scissor_Parameter/Line_Para.csv";
            switch (Scissor_List.SelectedIndex)
            {
                case 0:
                    if (File.Exists(File_Path1)) Program.SystemContainer.Drill_Scissor = Common_Collect.DtToList<Tech_Parameter>.ConvertToModel(CSV_RW.OpenCSV(File_Path1));//钻孔刀具参数 读取;
                    ScissorListView.DataSource = null;
                    ScissorListView.DataSource = Common_Collect.ListToDt(Program.SystemContainer.Drill_Scissor);
                    break;
                case 1:
                    if (File.Exists(File_Path2)) Program.SystemContainer.Arc_Scissor = Common_Collect.DtToList<Tech_Parameter>.ConvertToModel(CSV_RW.OpenCSV(File_Path2));//圆弧刀具参数 读取;
                    ScissorListView.DataSource = null;
                    ScissorListView.DataSource = Common_Collect.ListToDt(Program.SystemContainer.Arc_Scissor);
                    ScissorListView.Columns["Cutter_Type"].Visible = false;
                    ScissorListView.Columns["Cutter_Radius"].Visible = false;
                    break;
                case 2:
                    if (File.Exists(File_Path3)) Program.SystemContainer.Line_Scissor = Common_Collect.DtToList<Tech_Parameter>.ConvertToModel(CSV_RW.OpenCSV(File_Path3));//线段刀具参数 读取;
                    ScissorListView.DataSource = null;
                    ScissorListView.DataSource = Common_Collect.ListToDt(Program.SystemContainer.Line_Scissor);
                    ScissorListView.Columns["Cutter_Type"].Visible = false;
                    ScissorListView.Columns["Cutter_Radius"].Visible = false;
                    break;
                default:
                    break;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DG_Laser
{
    
         

    /// <summary>
    /// 工作参数
    /// </summary>
    partial class MainForm
    {
        //定义变量
        bool WorkParaWRFlag = false;
        /// <summary>
        /// 初始化参数
        /// </summary>
        private void WorkParaInitial()
        {
            RefreshWorkPara();//刷新WorkPara参数
            //绑定事件
            Rtn_SysSet_processEnd_Leftpostion.CheckedChanged += UpdateWorkPara;
            Rtn_SysSet_processEnd_Fastpostion.CheckedChanged += UpdateWorkPara;
            Rtn_SysSet_processEnd_Rightpostion.CheckedChanged += UpdateWorkPara;
            Rtn_SysSet_processEnd_Zero.CheckedChanged += UpdateWorkPara;
            Rtn_SysSet_processEnd_None.CheckedChanged += UpdateWorkPara;
            Rtn_SysSet_Z_None.CheckedChanged += UpdateWorkPara;
            Rtn_SysSet_Z_Fastpostion.CheckedChanged += UpdateWorkPara;
            Rtn_SysSet_Z_ProFastpostion.CheckedChanged += UpdateWorkPara;
            Rtn_SysSet_Scissor_RtcToScissor.CheckedChanged += UpdateWorkPara;
            Rtn_SysSet_Scissor_ScissorToRtc.CheckedChanged += UpdateWorkPara;
            CBox_SysSet_Count_pieces.CheckedChanged += UpdateWorkPara;
            CBox_SysSet_Count_num.CheckedChanged += UpdateWorkPara;
            CBox_SysSet_Door_Auto.CheckedChanged += UpdateWorkPara;
            CBox_SysSet_Vacuum_AutoCloseCleaner.CheckedChanged += UpdateWorkPara;
            CBox_SysSet_Vacuum_AutoOpenCleaner.CheckedChanged += UpdateWorkPara;
            CBox_SysSet_Vacuum_Pressure.CheckedChanged += UpdateWorkPara;
            CBox_SysSet_Convention_prpcessEndAlarm.CheckedChanged += UpdateWorkPara;
            CBox_SysSet_Convention_ChillerTem.CheckedChanged += UpdateWorkPara;
            CBox_SysSet_Convention_prpcessEndDlg.CheckedChanged += UpdateWorkPara;
            CBox_SysSet_Convention_Laserstate.CheckedChanged += UpdateWorkPara;
            CBox_SysSet_Convention_Autolight.CheckedChanged += UpdateWorkPara;
            CBox_SysSet_Safe_MoveEntrench.CheckedChanged += UpdateWorkPara;
            CBox_SysSet_Safe_Baffle.CheckedChanged += UpdateWorkPara;
            CBox_SysSet_Safe_prpcessingDoor.CheckedChanged += UpdateWorkPara;
            CBox_SysSet_Safe_CloseDoorEntrench.CheckedChanged += UpdateWorkPara;
            CBox_SysSet_Safe_OpenDoorEntrench.CheckedChanged += UpdateWorkPara;
            numUD_SysSet_Door_delayed.ValueChanged += UpdateWorkPara;
            numUD_SysSet_Door_timelimit.ValueChanged += UpdateWorkPara;
            NumUD_SysSet_vacuum_Stadelayed.ValueChanged += UpdateWorkPara;
            NumUD_SysSet_vacuum_Enddelayed.ValueChanged += UpdateWorkPara;
        }
        /// <summary>
        /// 刷新WorkPara参数
        /// </summary>
        private void RefreshWorkPara()
        {
            WorkParaWRFlag = true;
            Thread.Sleep(30);
            //动作后
            switch (Program.SystemContainer.SysPara.PrecessEnd)
            {
                case 0:
                    Rtn_SysSet_processEnd_None.Checked = true; break;
                case 1:
                    Rtn_SysSet_processEnd_Zero.Checked = true; break;
                case 2:
                    Rtn_SysSet_processEnd_Leftpostion.Checked = true; break;
                case 3:
                    Rtn_SysSet_processEnd_Rightpostion.Checked = true; break;
                case 4:
                    Rtn_SysSet_processEnd_Fastpostion.Checked = true; break;
            }
            //Z轴
            switch (Program.SystemContainer.SysPara.Move_Z)
            {
                case 0:
                    Rtn_SysSet_Z_None.Checked = true; break;
                case 1:
                    Rtn_SysSet_Z_Fastpostion.Checked = true; break;
                case 2:
                    Rtn_SysSet_Z_ProFastpostion.Checked = true; break;
            }
            //计数
            if (Program.SystemContainer.SysPara.Count_nnum.Equals(1))
            {
                CBox_SysSet_Count_num.Checked = true;
            }
            else
            {
                CBox_SysSet_Count_num.Checked = false;
            }
            if (Program.SystemContainer.SysPara.Count_pieces.Equals(1))
            {
                CBox_SysSet_Count_pieces.Checked = true;
            }
            else
            {
                CBox_SysSet_Count_pieces.Checked = false;
            }
            //刀具控制
            Rtn_SysSet_Scissor_RtcToScissor.Checked = Program.SystemContainer.SysPara.SectionWorkType.Equals(0)? true : false;
            //门
            if (Program.SystemContainer.SysPara.Door_use.Equals(1))
            {
                CBox_SysSet_Door_Auto.Checked = true;
            }
            else
            {
                CBox_SysSet_Door_Auto.Checked = false;
            }
            numUD_SysSet_Door_timelimit.Value = Program.SystemContainer.SysPara.Door_timelimit;
            numUD_SysSet_Door_delayed.Value = Program.SystemContainer.SysPara.Door_delay;
            //常规
            if (Program.SystemContainer.SysPara.Con_chillerTem.Equals(1))
            {
                CBox_SysSet_Convention_ChillerTem.Checked = true;
            }
            else
            {
                CBox_SysSet_Convention_ChillerTem.Checked = false;
            }
            if (Program.SystemContainer.SysPara.Con_light.Equals(1))
            {
                CBox_SysSet_Convention_Autolight.Checked = true;
            }
            else
            {
                CBox_SysSet_Convention_Autolight.Checked = false;
            }
            if (Program.SystemContainer.SysPara.Con_lasersta.Equals(1))
            {
                CBox_SysSet_Convention_Laserstate.Checked = true;
            }
            else
            {
                CBox_SysSet_Convention_Laserstate.Checked = false;
            }
            if (Program.SystemContainer.SysPara.Con_endAlarm.Equals(1))
            {
                CBox_SysSet_Convention_prpcessEndAlarm.Checked = true;
            }
            else
            {
                CBox_SysSet_Convention_prpcessEndAlarm.Checked = false;
            }
            if (Program.SystemContainer.SysPara.Con_endDlg.Equals(1))
            {
                CBox_SysSet_Convention_prpcessEndDlg.Checked = true;
            }
            else
            {
                CBox_SysSet_Convention_prpcessEndDlg.Checked = false;
            }
            if (Program.SystemContainer.SysPara.Safe_Baffle.Equals(1))
            {
                CBox_SysSet_Safe_Baffle.Checked = true;
            }
            else
            {
                CBox_SysSet_Safe_Baffle.Checked = false;
            }
            if (Program.SystemContainer.SysPara.Safe_door.Equals(1))
            {
                CBox_SysSet_Safe_prpcessingDoor.Checked = true;
            }
            else
            {
                CBox_SysSet_Safe_prpcessingDoor.Checked = false;
            }
            if (Program.SystemContainer.SysPara.Safe_moveEntrench.Equals(1))
            {
                CBox_SysSet_Safe_MoveEntrench.Checked = true;
            }
            else
            {
                CBox_SysSet_Safe_MoveEntrench.Checked = false;
            }
            if (Program.SystemContainer.SysPara.Safe_openEntrench.Equals(1))
            {
                CBox_SysSet_Safe_OpenDoorEntrench.Checked = true;
            }
            else
            {
                CBox_SysSet_Safe_OpenDoorEntrench.Checked = false;
            }
            if (Program.SystemContainer.SysPara.Safe_closeEntrench.Equals(1))
            {
                CBox_SysSet_Safe_CloseDoorEntrench.Checked = true;
            }
            else
            {
                CBox_SysSet_Safe_CloseDoorEntrench.Checked = false;
            }
            if (Program.SystemContainer.SysPara.Vacuum_openCleaner.Equals(1))
            {
                CBox_SysSet_Vacuum_AutoOpenCleaner.Checked = true;
            }
            else
            {
                CBox_SysSet_Vacuum_AutoOpenCleaner.Checked = false;
            }
            if (Program.SystemContainer.SysPara.Vacuum_closeCleaner.Equals(1))
            {
                CBox_SysSet_Vacuum_AutoCloseCleaner.Checked = true;
            }
            else
            {
                CBox_SysSet_Vacuum_AutoCloseCleaner.Checked = false;
            }
            if (Program.SystemContainer.SysPara.Vacuum_PressCheck.Equals(1))
            {
                CBox_SysSet_Vacuum_Pressure.Checked = true;
            }
            else
            {
                CBox_SysSet_Vacuum_Pressure.Checked = false;
            }
            NumUD_SysSet_vacuum_Stadelayed.Value = Program.SystemContainer.SysPara.Vacuum_opendelay;
            NumUD_SysSet_vacuum_Enddelayed.Value = Program.SystemContainer.SysPara.Vacuum_closedelay;

            Thread.Sleep(30);
            WorkParaWRFlag = false;
        }
        /// <summary>
        /// 更新WorkPara页面更改
        /// </summary>
        private void UpdateWorkPara(object sender, EventArgs e)
        {
            if (WorkParaWRFlag) return;
            //动作后
            if (Rtn_SysSet_processEnd_None.Checked)
                Program.SystemContainer.SysPara.PrecessEnd = 0;
            if (Rtn_SysSet_processEnd_Zero.Checked)
                Program.SystemContainer.SysPara.PrecessEnd = 1;
            if (Rtn_SysSet_processEnd_Leftpostion.Checked)
                Program.SystemContainer.SysPara.PrecessEnd = 2;
            if (Rtn_SysSet_processEnd_Rightpostion.Checked)
                Program.SystemContainer.SysPara.PrecessEnd = 3;
            if (Rtn_SysSet_processEnd_Fastpostion.Checked)
                Program.SystemContainer.SysPara.PrecessEnd = 4;
            //Z轴
            if (Rtn_SysSet_Z_None.Checked)
                Program.SystemContainer.SysPara.Move_Z = 0;
            if (Rtn_SysSet_Z_Fastpostion.Checked)
                Program.SystemContainer.SysPara.Move_Z = 1;
            if (Rtn_SysSet_Z_ProFastpostion.Checked)
                Program.SystemContainer.SysPara.Move_Z = 2;
            //计数
            if (CBox_SysSet_Count_num.Checked)
            {
                Program.SystemContainer.SysPara.Count_nnum = 1;
            }
            else
            {
                Program.SystemContainer.SysPara.Count_nnum = 0;
            }
            if (CBox_SysSet_Count_pieces.Checked)
            {
                Program.SystemContainer.SysPara.Count_pieces = 1;
            }
            else
            {
                Program.SystemContainer.SysPara.Count_pieces = 0;
            }
            //刀具控制
            Program.SystemContainer.SysPara.SectionWorkType = Rtn_SysSet_Scissor_RtcToScissor.Checked ? 0 : 1;
            //门
            if (CBox_SysSet_Door_Auto.Checked)
            {
                Program.SystemContainer.SysPara.Door_use = 1;
            }
            else
            {
                Program.SystemContainer.SysPara.Door_use = 0;
            }
            Program.SystemContainer.SysPara.Door_timelimit = (int)numUD_SysSet_Door_timelimit.Value;
            Program.SystemContainer.SysPara.Door_delay = (int)numUD_SysSet_Door_delayed.Value;
            //常规
            if (CBox_SysSet_Convention_ChillerTem.Checked)
            {
                Program.SystemContainer.SysPara.Con_chillerTem = 1;
            }
            else
            {
                Program.SystemContainer.SysPara.Con_chillerTem = 0;
            }
            if (CBox_SysSet_Convention_Autolight.Checked)
            {
                Program.SystemContainer.SysPara.Con_light = 1;
            }
            else
            {
                Program.SystemContainer.SysPara.Con_light = 0;
            }
            if (CBox_SysSet_Convention_Laserstate.Checked)
            {
                Program.SystemContainer.SysPara.Con_lasersta = 1;
            }
            else
            {
                Program.SystemContainer.SysPara.Con_lasersta = 0;
            }
            if (CBox_SysSet_Convention_prpcessEndAlarm.Checked)
            {
                Program.SystemContainer.SysPara.Con_endAlarm = 1;
            }
            else
            {
                Program.SystemContainer.SysPara.Con_endAlarm = 0;
            }
            if (CBox_SysSet_Convention_prpcessEndDlg.Checked)
            {
                Program.SystemContainer.SysPara.Con_endDlg = 1;
            }
            else
            {
                Program.SystemContainer.SysPara.Con_endDlg = 0;
            }
            //安全
            if (CBox_SysSet_Safe_Baffle.Checked)
            {
                Program.SystemContainer.SysPara.Safe_Baffle = 1;
            }
            else
            {
                Program.SystemContainer.SysPara.Safe_Baffle = 0;
            }
            if (CBox_SysSet_Safe_prpcessingDoor.Checked)
            {
                Program.SystemContainer.SysPara.Safe_door = 1;
            }
            else
            {
                Program.SystemContainer.SysPara.Safe_door = 0;
            }
            if (CBox_SysSet_Safe_MoveEntrench.Checked)
            {
                Program.SystemContainer.SysPara.Safe_moveEntrench = 1;
            }
            else
            {
                Program.SystemContainer.SysPara.Safe_moveEntrench = 0;
            }
            if (CBox_SysSet_Safe_OpenDoorEntrench.Checked)
            {
                Program.SystemContainer.SysPara.Safe_openEntrench = 1;
            }
            else
            {
                Program.SystemContainer.SysPara.Safe_openEntrench = 0;
            }
            if (CBox_SysSet_Safe_CloseDoorEntrench.Checked)
            {
                Program.SystemContainer.SysPara.Safe_closeEntrench = 1;
            }
            else
            {
                Program.SystemContainer.SysPara.Safe_closeEntrench = 0;
            }
            //真空控制
            if (CBox_SysSet_Vacuum_AutoOpenCleaner.Checked)
            {
                Program.SystemContainer.SysPara.Vacuum_openCleaner = 1;
            }
            else
            {
                Program.SystemContainer.SysPara.Vacuum_openCleaner = 0;
            }
            if (CBox_SysSet_Vacuum_AutoCloseCleaner.Checked)
            {
                Program.SystemContainer.SysPara.Vacuum_closeCleaner = 1;
            }
            else
            {
                Program.SystemContainer.SysPara.Vacuum_closeCleaner = 0;
            }
            if (CBox_SysSet_Vacuum_Pressure.Checked)
            {
                Program.SystemContainer.SysPara.Vacuum_PressCheck = 1;
            }
            else
            {
                Program.SystemContainer.SysPara.Vacuum_PressCheck = 0;
            }
            Program.SystemContainer.SysPara.Vacuum_opendelay = (int)NumUD_SysSet_vacuum_Stadelayed.Value;
            Program.SystemContainer.SysPara.Vacuum_closedelay = (int)NumUD_SysSet_vacuum_Enddelayed.Value;
        }
    }
}

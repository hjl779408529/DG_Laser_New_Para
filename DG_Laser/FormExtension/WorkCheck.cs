using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DG_Laser
{
    /// <summary>
    /// 加工前后的动作
    /// </summary>
    partial class MainForm
    {
        /// <summary>
        /// Z轴动作 0 - 常规，1 - 加工前
        /// </summary>
        /// <returns></returns>
        private bool Axis_Z_Move(int Type)
        {
            //获取Z轴移动距离
            switch (Program.SystemContainer.SysPara.Move_Z)
            {
                case 0://无动作
                    break;
                case 1://至快速移动位
                    break;
                case 2://至快速移动位(仅加工定位前)
                    break;
                default:
                    break;
            }
            //Z轴移动动作
            return true;
        }
        /// <summary>
        /// 加工前真空控制
        /// </summary>
        /// <returns></returns>
        private void VacuumControlBeforStart()
        {
            if (Program.SystemContainer.SysPara.Vacuum_openCleaner == 0) return;//0 - 不打开，其他 - 打开
            //建立延时定时器
            System.Threading.Timer DelayOpenVacuum = new System.Threading.Timer(delegate (object Sender) { Thread.Sleep(1000); }, null, Timeout.Infinite, Timeout.Infinite);
            //修改定时器
            DelayOpenVacuum = new System.Threading.Timer(
                delegate (object Sender) 
                {
                    Program.SystemContainer.IO.Blow_control = 1;//打开吸尘器
                    DelayOpenVacuum.Dispose();//释放定时器资源
                }, 
                null, 
                0,
                Program.SystemContainer.SysPara.Vacuum_opendelay);
        }
        /// <summary>
        /// 加工结束后真空控制
        /// </summary>
        /// <returns></returns>
        private void VacuumControlBeforEnd()
        {
            if (Program.SystemContainer.SysPara.Vacuum_closeCleaner == 0) return;//0 - 不关闭，其他 - 关闭
            //建立延时定时器
            System.Threading.Timer DelayOpenVacuum = new System.Threading.Timer(delegate (object Sender) { Thread.Sleep(1000); }, null, Timeout.Infinite, Timeout.Infinite);
            //修改定时器
            DelayOpenVacuum = new System.Threading.Timer(
                delegate (object Sender)
                {
                    Program.SystemContainer.IO.Blow_control = 0;//关闭吸尘器
                    DelayOpenVacuum.Dispose();//释放定时器资源
                },
                null,
                0,
                Program.SystemContainer.SysPara.Vacuum_closedelay);
        }
        /// <summary>
        /// 检查真空压力
        /// </summary>
        /// <returns></returns>
        private bool CheckVacuumPressure()
        {
            if (Program.SystemContainer.SysPara.Vacuum_PressCheck == 0) return true;//0 - 不检查，其他 - 检查
            //判断真空压力
            return Program.SystemContainer.IO.EXI8 ? true : false;
        }
        /// <summary>
        /// 门开关检测
        /// </summary>
        /// <returns></returns>
        private bool DoorOpenCheck()
        {
            //清除计数值
            Thread.Sleep(Program.SystemContainer.SysPara.Door_delay);//开门稳定延时
            Program.SystemContainer.IO.DoorSensorCheck.Clear();
            Thread.Sleep(Program.SystemContainer.SysPara.Door_timelimit);//开门信号滤波延时
            return Program.SystemContainer.IO.DoorSensorCheck.Counting == 0 ? true:false;
        }
        /// <summary>
        /// 冷水机温度检测
        /// </summary>
        /// <returns></returns>
        private bool ColdWaterCheck()
        {
            if (Program.SystemContainer.SysPara.Con_chillerTem == 0) return true;//0 - 不检查，其他 - 检查
            //读取Seed温度
            Program.SystemContainer.Laser_Operation_00.Read("00", "32");
            decimal Seed_Temperature = Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num / 100m;
            //读取AMP温度
            Program.SystemContainer.Laser_Operation_00.Read("01", "32");
            decimal Amp_Temperature = Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num / 100m;
            //判断温度是否合适
            return ((Seed_Temperature + 1 <= Program.SystemContainer.SysPara.Seed_Temperature) && (Amp_Temperature + 1 <= Program.SystemContainer.SysPara.Amp_Temperature)) ? true : false;
        }
        /// <summary>
        /// 加工时照明打开
        /// </summary>
        private void IlluminateOpen()
        {
            if (Program.SystemContainer.SysPara.Con_light == 0) return;
            Program.SystemContainer.IO.Lamp_control = 1;
        }
        /// <summary>
        /// 加工时照明关闭
        /// </summary>
        private void IlluminateClose()
        {
            if (Program.SystemContainer.SysPara.Con_light == 0) return;
            Program.SystemContainer.IO.Lamp_control = 0;
        }
        /// <summary>
        /// 激光状态判断
        /// </summary>
        /// <returns></returns>
        private bool LaserStatusCheck()
        {
            if (Program.SystemContainer.SysPara.Con_lasersta == 0) return true;//0 - 不检查，其他 - 检测
            if (!Program.SystemContainer.Laser_Control_Com.Open) return false;
            //检测电流
            decimal Seed_Current = 0;//Seed电流
            decimal Amp1_Current = 0;//Amp1电流
            decimal Amp2_Current = 0;//Amp2电流 
            //读取Seed电流
            Program.SystemContainer.Laser_Operation_00.Read("00", "12");
            Seed_Current = Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num / 100m;
            //读取Amp1电流
            Program.SystemContainer.Laser_Operation_00.Read("01", "12");
            Amp1_Current = Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num / 100m;
            //读取Amp2电流
            Program.SystemContainer.Laser_Operation_00.Read("02", "12");
            Amp2_Current = Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Num / 100m;
            //判断分支进程
            if ((Math.Abs(Program.SystemContainer.SysPara.Seed_Current - Seed_Current) < 0.5m) ||
                (Math.Abs(Program.SystemContainer.SysPara.Amp1_Current - Amp1_Current) < 0.5m) ||
                (Math.Abs(Program.SystemContainer.SysPara.Amp2_Current - Amp2_Current) < 0.5m))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 激光挡板 伸出
        /// </summary>
        private void WindCoverUp()
        {
            if (Program.SystemContainer.SysPara.Safe_Baffle == 0) return;//0 - 不伸出；其他 - 伸出
            Program.SystemContainer.IO.Cyc_control = 1;
        }
        /// <summary>
        /// 激光挡板 退回
        /// </summary>
        private void WindCoverDown()
        {
            if (Program.SystemContainer.SysPara.Safe_Baffle == 0) return;//0 - 不伸出；其他 - 伸出
            Program.SystemContainer.IO.Cyc_control = 0;
        }
        /// <summary>
        /// 门状态检测
        /// </summary>
        /// <returns></returns>
        private bool DoorStatusCheck()
        {
            if (Program.SystemContainer.SysPara.Safe_door == 0) return true;//0 - 不检测；其他 - 检测
            return Program.SystemContainer.IO.DoorSensorCheck.Variable.Equals(1) ? true : false;
        }
        /// <summary>
        /// 打开门
        /// </summary>
        private void DoorOpen()
        {
            if(Program.SystemContainer.SysPara.Safe_openEntrench.Equals(0))//0 - 不启用门开安全防护；其他 - 启用
            {
                if (Program.SystemContainer.IO.SafeSensorCheck.Equals(1))
                {
                    MessageBox.Show("门打开安全防护触发，请移除障碍物！！！");
                    return;
                }
                else
                {
                    Program.SystemContainer.IO.Door_Control = 1;
                }
            }
            else
            {
                Program.SystemContainer.IO.Door_Control = 1;
            }
        }
        /// <summary>
        /// 关闭门
        /// </summary>
        private void DoorClose()
        {
            if (Program.SystemContainer.SysPara.Safe_closeEntrench.Equals(0))//0 - 不启用门关安全防护；其他 - 启用
            {
                if (Program.SystemContainer.IO.SafeSensorCheck.Equals(1))
                {
                    MessageBox.Show("门关闭安全防护触发，请移除障碍物！！！");
                    return;
                }
                else
                {
                    Program.SystemContainer.IO.Door_Control = 0;
                }
            }
            else
            {
                Program.SystemContainer.IO.Door_Control = 0;
            }
        }
    }
}

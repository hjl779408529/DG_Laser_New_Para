using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DG_Laser
{
     /// <summary>
     /// RTC手动操作页面
     /// </summary>
    partial class MainForm
    {
       
        /// <summary>
        /// paraSetContainerInitial
        /// </summary>
        private void paraSetContainerInitial()
        {            
            //Mark点相关          
            Set_txt_markX1.Text = Program.SystemContainer.SysPara.Mark1.X.ToString();
            Set_txt_markY1.Text = Program.SystemContainer.SysPara.Mark1.Y.ToString();
            Set_txt_markX2.Text = Program.SystemContainer.SysPara.Mark2.X.ToString();
            Set_txt_markY2.Text = Program.SystemContainer.SysPara.Mark2.Y.ToString();
            Set_txt_markX3.Text = Program.SystemContainer.SysPara.Mark3.X.ToString();
            Set_txt_markY3.Text = Program.SystemContainer.SysPara.Mark3.Y.ToString();
            Set_txt_markX4.Text = Program.SystemContainer.SysPara.Mark4.X.ToString();
            Set_txt_markY4.Text = Program.SystemContainer.SysPara.Mark4.Y.ToString();
            
            //偏差矫正
            Set_txt_valueK.Text = Program.SystemContainer.SysPara.Cam_Reference.ToString();
            RefreshRtcOrgDistance();
            //加工参数
            //工件坐标系偏移
            RefreshWork();
            //直线插补
            LineVelocitySet.Text = Program.SystemContainer.SysPara.Line_synVel.ToString(6);
            LineACCSet.Text = Program.SystemContainer.SysPara.Line_synAcc.ToString(6);
            //圆弧插补
            ArcVelocitySet.Text = Program.SystemContainer.SysPara.Circle_synVel.ToString(6);
            ArcACCSet.Text = Program.SystemContainer.SysPara.Circle_synAcc.ToString(6);
            //坐标运动平滑系数
            SmoothTimeSet.Text = Program.SystemContainer.SysPara.Syn_EvenTime.ToString(6);
            //插补终止速度
            LineEndVelocitySet.Text = Program.SystemContainer.SysPara.Line_endVel.ToString(6);
            ArcEndVelocitySet.Text = Program.SystemContainer.SysPara.Circle_endVel.ToString(6);
        }
        /// <summary>
        /// 舒心振镜与Org距离
        /// </summary>
        private void RefreshRtcOrgDistance()
        {
            RtcOrgDistanceX.Text = Program.SystemContainer.SysPara.Rtc_Org.X.ToString(6);
            RtcOrgDistanceY.Text = Program.SystemContainer.SysPara.Rtc_Org.Y.ToString(6);
        }
        /// <summary>
        /// 刷新工作坐标
        /// </summary>
        private void RefreshWork()
        {
            WorkX.Text = Program.SystemContainer.SysPara.Work.X.ToString(6);
            WorkY.Text = Program.SystemContainer.SysPara.Work.Y.ToString(6);
        }
        
        /// <summary>
        /// Mark1X
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Set_txt_markX1_TextChanged(object sender, EventArgs e)
        {
            if (!decimal.TryParse(Set_txt_markX1.Text, out decimal tmp))
            {
                MessageBox.Show("请正确输入数字");
                return;
            }
            if ((tmp >= 0) && (tmp <= 350))
            {
                Program.SystemContainer.SysPara.Mark1 = new Vector(tmp, Program.SystemContainer.SysPara.Mark1.Y);
            }
            else
            {
                MessageBox.Show("请确认数值在0-350范围内");
                return;
            }
        }
        /// <summary>
        /// Mark1Y
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Set_txt_markY1_TextChanged(object sender, EventArgs e)
        {
            if (!decimal.TryParse(Set_txt_markY1.Text, out decimal tmp))
            {
                MessageBox.Show("请正确输入数字");
                return;
            }
            if ((tmp >= 0) && (tmp <= 350))
            {
                Program.SystemContainer.SysPara.Mark1 = new Vector(Program.SystemContainer.SysPara.Mark1.X,tmp);
            }
            else
            {
                MessageBox.Show("请确认数值在0-350范围内");
                return;
            }
        }
        /// <summary>
        /// Mark2X
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Set_txt_markX2_TextChanged(object sender, EventArgs e)
        {
            if (!decimal.TryParse(Set_txt_markX2.Text, out decimal tmp))
            {
                MessageBox.Show("请正确输入数字");
                return;
            }
            if ((tmp >= 0) && (tmp <= 350))
            {
                Program.SystemContainer.SysPara.Mark2 = new Vector(tmp, Program.SystemContainer.SysPara.Mark2.Y);
            }
            else
            {
                MessageBox.Show("请确认数值在0-350范围内");
                return;
            }
        }
        /// <summary>
        /// Mark2Y
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Set_txt_markY2_TextChanged(object sender, EventArgs e)
        {
            if (!decimal.TryParse(Set_txt_markY2.Text, out decimal tmp))
            {
                MessageBox.Show("请正确输入数字");
                return;
            }
            if ((tmp >= 0) && (tmp <= 350))
            {
                Program.SystemContainer.SysPara.Mark2 = new Vector(Program.SystemContainer.SysPara.Mark2.X, tmp);
            }
            else
            {
                MessageBox.Show("请确认数值在0-350范围内");
                return;
            }
        }
        /// <summary>
        /// Mark3X
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Set_txt_markX3_TextChanged(object sender, EventArgs e)
        {
            if (!decimal.TryParse(Set_txt_markX3.Text, out decimal tmp))
            {
                MessageBox.Show("请正确输入数字");
                return;
            }
            if ((tmp >= 0) && (tmp <= 350))
            {
                Program.SystemContainer.SysPara.Mark3 = new Vector(tmp, Program.SystemContainer.SysPara.Mark3.Y);
            }
            else
            {
                MessageBox.Show("请确认数值在0-350范围内");
                return;
            }
        }
        /// <summary>
        /// Mark3Y
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Set_txt_markY3_TextChanged(object sender, EventArgs e)
        {
            if (!decimal.TryParse(Set_txt_markY3.Text, out decimal tmp))
            {
                MessageBox.Show("请正确输入数字");
                return;
            }
            if ((tmp >= 0) && (tmp <= 350))
            {
                Program.SystemContainer.SysPara.Mark3 = new Vector(Program.SystemContainer.SysPara.Mark3.X, tmp);
            }
            else
            {
                MessageBox.Show("请确认数值在0-350范围内");
                return;
            }
        }
        /// <summary>
        /// Mark4X
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Set_txt_markX4_TextChanged(object sender, EventArgs e)
        {
            if (!decimal.TryParse(Set_txt_markX4.Text, out decimal tmp))
            {
                MessageBox.Show("请正确输入数字");
                return;
            }
            if ((tmp >= 0) && (tmp <= 350))
            {
                Program.SystemContainer.SysPara.Mark4 = new Vector(tmp, Program.SystemContainer.SysPara.Mark4.Y);
            }
            else
            {
                MessageBox.Show("请确认数值在0-350范围内");
                return;
            }
        }
        /// <summary>
        /// Mark4Y
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Set_txt_markY4_TextChanged(object sender, EventArgs e)
        {
            if (!decimal.TryParse(Set_txt_markY4.Text, out decimal tmp))
            {
                MessageBox.Show("请正确输入数字");
                return;
            }
            if ((tmp >= 0) && (tmp <= 350))
            {
                Program.SystemContainer.SysPara.Mark4 = new Vector(Program.SystemContainer.SysPara.Mark4.X, tmp);
            }
            else
            {
                MessageBox.Show("请确认数值在0-350范围内");
                return;
            }
        }
        /// <summary>
        /// 定位至Mark1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoMark1_Click(object sender, EventArgs e)
        {
            Program.SystemContainer.GTS_Fun.Gts_Ready_Correct(Program.SystemContainer.SysPara.Mark1);
        }
        /// <summary>
        /// 定位至Mark2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoMark2_Click(object sender, EventArgs e)
        {
            Program.SystemContainer.GTS_Fun.Gts_Ready_Correct(Program.SystemContainer.SysPara.Mark2);
        }
        /// <summary>
        /// 定位至Mark3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoMark3_Click(object sender, EventArgs e)
        {
            Program.SystemContainer.GTS_Fun.Gts_Ready_Correct(Program.SystemContainer.SysPara.Mark3);
        }
        /// <summary>
        /// 定位至Mark4
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoMark4_Click(object sender, EventArgs e)
        {
            Program.SystemContainer.GTS_Fun.Gts_Ready_Correct(Program.SystemContainer.SysPara.Mark4);
        }
        /// <summary>
        /// 像素分辨率
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Set_txt_valueK_TextChanged(object sender, EventArgs e)
        {
            if (!decimal.TryParse(Set_txt_valueK.Text, out decimal tmp))
            {
                MessageBox.Show("请正确输入数字");
                return;
            }
            Program.SystemContainer.SysPara.Cam_Reference = tmp;
        }
        /// <summary>
        /// 振镜与坐标原点距离X
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RtcOrgDistanceX_TextChanged(object sender, EventArgs e)
        {
            if (!decimal.TryParse(RtcOrgDistanceX.Text, out decimal tmp))
            {
                MessageBox.Show("请正确输入数字");
                return;
            }
            Program.SystemContainer.SysPara.Rtc_Org = new Vector(tmp, Program.SystemContainer.SysPara.Rtc_Org.Y);
        }
        /// <summary>
        /// 振镜与坐标原点距离Y
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void RtcOrgDistanceY_TextChanged(object sender, EventArgs e)
        {
            if (!decimal.TryParse(RtcOrgDistanceY.Text, out decimal tmp))
            {
                MessageBox.Show("请正确输入数字");
                return;
            }
            Program.SystemContainer.SysPara.Rtc_Org = new Vector(Program.SystemContainer.SysPara.Rtc_Org.X,tmp);
        }
        /// <summary>
        /// 加工坐标系X
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WorkX_TextChanged(object sender, EventArgs e)
        {
            if (!decimal.TryParse(WorkX.Text, out decimal tmp))
            {
                MessageBox.Show("请正确输入数字");
                return;
            }
            Program.SystemContainer.SysPara.Work = new Vector(tmp, Program.SystemContainer.SysPara.Work.Y);
        }
        /// <summary>
        /// 加工坐标系Y
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WorkY_TextChanged(object sender, EventArgs e)
        {
            if (!decimal.TryParse(WorkY.Text, out decimal tmp))
            {
                MessageBox.Show("请正确输入数字");
                return;
            }
            Program.SystemContainer.SysPara.Work = new Vector(Program.SystemContainer.SysPara.Work.X,tmp);
        }
        /// <summary>
        /// 合成平滑时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SmoothTimeSet_TextChanged(object sender, EventArgs e)
        {
            if (!decimal.TryParse(SmoothTimeSet.Text, out decimal tmp))
            {
                MessageBox.Show("请正确输入数字");
                return;
            }
            Program.SystemContainer.SysPara.Syn_EvenTime = tmp;
        }
        /// <summary>
        /// 直线合成速度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LineVelocitySet_TextChanged(object sender, EventArgs e)
        {
            if (!decimal.TryParse(LineVelocitySet.Text, out decimal tmp))
            {
                MessageBox.Show("请正确输入数字");
                return;
            }
            Program.SystemContainer.SysPara.Line_synVel = tmp;
        }
        /// <summary>
        /// 直线合成加速度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LineACCSet_TextChanged(object sender, EventArgs e)
        {
            if (!decimal.TryParse(LineACCSet.Text, out decimal tmp))
            {
                MessageBox.Show("请正确输入数字");
                return;
            }
            Program.SystemContainer.SysPara.Line_synAcc = tmp;
        }
        /// <summary>
        /// 直线合成终止速度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LineEndVelocitySet_TextChanged(object sender, EventArgs e)
        {
            if (!decimal.TryParse(LineEndVelocitySet.Text, out decimal tmp))
            {
                MessageBox.Show("请正确输入数字");
                return;
            }
            Program.SystemContainer.SysPara.Line_endVel = tmp;
        }
        /// <summary>
        /// 圆弧合成速度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ArcVelocitySet_TextChanged(object sender, EventArgs e)
        {
            if (!decimal.TryParse(ArcVelocitySet.Text, out decimal tmp))
            {
                MessageBox.Show("请正确输入数字");
                return;
            }
            Program.SystemContainer.SysPara.Circle_synVel = tmp;
        }
        /// <summary>
        /// 圆弧合成加速度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ArcACCSet_TextChanged(object sender, EventArgs e)
        {
            if (!decimal.TryParse(ArcACCSet.Text, out decimal tmp))
            {
                MessageBox.Show("请正确输入数字");
                return;
            }
            Program.SystemContainer.SysPara.Circle_synAcc = tmp;
        }
        /// <summary>
        /// 圆弧合成终止速度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ArcEndVelocitySet_TextChanged(object sender, EventArgs e)
        {
            if (!decimal.TryParse(ArcEndVelocitySet.Text, out decimal tmp))
            {
                MessageBox.Show("请正确输入数字");
                return;
            }
            Program.SystemContainer.SysPara.Circle_endVel = tmp;
        }
        /// <summary>
        /// 系统参数保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SysParaSave_Click(object sender, EventArgs e)
        {
            OperatePara.SaveParaXml("Para", Program.SystemContainer.SysPara);
        }
        /// <summary>
        /// 系统参数读取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SyaParaRead_Click(object sender, EventArgs e)
        {
            Program.SystemContainer.SysPara = OperatePara.LoadParaXml("Para"); 
        }
    }
}

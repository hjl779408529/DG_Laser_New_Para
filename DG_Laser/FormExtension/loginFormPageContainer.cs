using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DG_Laser
{
    /// <summary>
    /// 用户登录页面
    /// </summary>
    partial class MainForm
    {
        string[] UserList = null;
        static public string usmen;//用户名，用于保存
        static public string uspass;//密码，用于保存  
        /// <summary>
        /// 登录页面初始化
        /// </summary>
        private void loginFormPageContainerInitial()
        {
            getUserList();//刷新用户列表
            User_List.SelectedIndex = 0;//默认用户为第一个
            if (!getAuthority())
            {
                this.tabFormControl.SelectedPage = this.tabFormControl.Pages.Where(p => p.Name == "LoginFormPage").ToArray()[0]; //跳转到登录页面
            }
            FirstSign = true;
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        private void getUserList()
        {
            UserList = null;
            UserList = Program.SystemContainer.User_DB.getUserList("User_Name").ToArray();
            //刷新列表
            User_List.Properties.Items.Clear();
            User_List.Properties.Items.AddRange(UserList.OrderBy(x => x).ToArray());
        }
        /// <summary>
        /// 权限判断
        /// </summary>
        /// <returns></returns>
        private bool getAuthority()
        {
            if (UserList.Contains(usmen))
            {

                this.tabFormControl.AllowMoveTabs = true;
                return true;
            }
            else
            {

                this.tabFormControl.AllowMoveTabs = false;
                return false;
            }
        }
        /// <summary>
        /// 登录
        /// </summary>
        private void login()
        {
            //判断输入信息
            if (!pdyj())
            {
                MessageBox.Show("请输入正确信息");
                return;
            }
            string Access = "select User_Name,User_Password from [User] where User_Name = '" + User_List.SelectedItem.ToString() + "' and User_Password = '" + Password_Input.Text + "'";
            if (Program.SystemContainer.User_DB.questDB(Access))
            {
                usmen = User_List.SelectedItem.ToString();
                barUserIndicate.Caption = "当前用户：" + usmen;
                Password_Input.Text = "";
                this.tabFormControl.SelectedPage = this.tabFormControl.Pages.Where(p => p.Name == "workFormPage").ToArray()[0];//跳转到主页
                //MessageBox.Show("登录成功！");
            }
            else
            {
                Password_Input.Text = "";
                MessageBox.Show("用户名或密码错误！！");
            }
        }
        /// <summary>
        /// 判断是否选择正确的用户名或密码
        /// </summary>
        /// <returns></returns>
        private bool pdyj()
        {
            //用if来判断框的内容
            if (User_List.SelectedItem.ToString() == "")//用户选择
                return false;
            if (Password_Input.Text == "")//密码输入
                return false;
            return true;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Confirm_Button_Click(object sender, EventArgs e)
        {
            login();
        }

        /// <summary>
        /// 回车登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Password_Input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login();
            }
        }

        /// <summary>
        /// 登录取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            //SysPara.Test = new Point(30, 30);
            //SysPara.Server_Ip = "192.168.2.1";
            //OperatePara.SaveParaXml("Para", SysPara);
            //OperatePara.SavePara("Para.cfg", SysPara);//保存参数
            //OperatePara.LoadPara("Para.cfg");

        }
        /// <summary>
        /// 当前窗口变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabFormControl_SelectedPageChanging(object sender, TabFormSelectedPageChangingEventArgs e)
        {
            if (FirstSign && !(UserList == null) && !getAuthority())
            {
                if (!(e.Page == LoginFormPage))
                {
                    e.Cancel = true;
                    this.tabFormControl.SelectedPage = this.tabFormControl.Pages.Where(p => p.Name == "LoginFormPage").ToArray()[0]; //跳转到登录页面
                    MessageBox.Show("请登录");
                }
            }
        }
    }
}

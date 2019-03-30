using netDxf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DG_Laser.FormExtension;
using System.IO;
using System.Drawing;

namespace DG_Laser
{
    /// <summary>
    /// main操作页面
    /// </summary>
    partial class MainForm
    {
        LaserProject MainLaserProject = new LaserProject();//主项目
        List<string> LaserLayerList = new List<string>();//需要进行Laser加工的图层
        string MainLaserProjectpath = null;//项目路径
        public event LogErrstring MainFormLogErr;
        //定义项目传送事件
        public event TransProject SendProject;
        //CAM加工数据解析
        Cam_Data_Resolve DataResolve = new Cam_Data_Resolve();
        bool MainContainerParaWRFlag = false;
        //加工过程
        private int Work_Type_No = 0;//工作模式序号
        //加工方式序号选择
        string[] Methods_List =
        {
            "振镜空白和平台未补偿",
            "振镜仿射和平台未补偿",
            "振镜仿射和平台已补偿",
            "振镜旋转和平台已补偿(废弃)",
            "振镜矩阵和平台已补偿(废弃)",
            "振镜桶形畸变图形加工",
            "振镜桶形畸变数据采集",
            "振镜仿射矩阵图形加工(废弃)",
            "振镜仿射矩阵数据采集(废弃)",
            "Mark坐标试验证",
            "Mark坐标定位重矫正(废弃)",
            "相机坐标系标定(打标)",
            "相机坐标系标定(标定板)",
            "矫正振镜坐标系偏转角",
            "振镜与ORG距离校准",
            "坐标系原点坐标校准",
            "计算标定板旋转参数(废弃)",
            "标定板对齐校准",
            "标定板校准验证",
            "振镜空白和平台已补偿",
            "标定板多次校准",
            "获取当前平台坐标",
            "指定点数据校准",
            "RTC仿射校准采集"
        };
        //加工方式序号选择
        string[] Methods_List_Normal =
        {
            "振镜仿射和平台已补偿"
        };
        //加工方式序号选择
        string[] Methods_List_Admin =
        {
            "振镜空白和平台未补偿",
            "振镜空白和平台已补偿",
            "振镜仿射和平台未补偿",
            "振镜仿射和平台已补偿",
            "振镜桶形畸变图形加工",
            "振镜桶形畸变数据采集",
            "Mark坐标试验证",
            "相机坐标系标定(打标)",
            "相机坐标系标定(标定板)",
            "振镜与ORG距离校准",
            "矫正振镜坐标系偏转角",            
            "坐标系原点坐标校准",
            "标定板对齐校准",
            "标定板多次校准",
            "标定板校准验证",
            "指定点数据校准",
            "获取当前平台坐标",
            "RTC仿射校准采集"
        };
        bool MainContainerProjectConfigFlag = false;//项目配置中标志
        bool GtsRunningFlag = false;//Jog运行中
        /// <summary>
        /// 主页界面初始化
        /// </summary>
        private void mainContainerInitial()
        {
            
            MainFormLogErr += Program.SystemContainer.Log.WriteError;
            

            RefreshMainContainerPara();//刷新主页面参数

            //事件绑定
            Start_Pos_Sel.SelectedIndexChanged += UpdateMainContainerPara;//加工类型选择
            Work_Type_Select_List.SelectedIndexChanged += UpdateMainContainerPara;//工作方式选择
            MainCoordinateJogDistance.ValueChanged += UpdateMainContainerPara;//坐标系步进值修改
            PointListSelectcomboBox.SelectedIndexChanged += SwitchPointListSelectcomboBox;//点位切换
            PointListXnumericUpDown.ValueChanged += UpdateMainContainerPara;
            PointListYnumericUpDown.ValueChanged += UpdateMainContainerPara;
            //双启按钮触发事件
            Program.SystemContainer.IO.Start_Button.Value_1 += WorkStartEvent;//启动加工
            //直角坐标系状态建立、定位坐标点、加工启动、加工停止等按钮状态刷新
            if (Program.SystemContainer.IO.Gts_Home_Flag)
            {
                PointListConfiggroupBox.Enabled = true;
                //启动和停止
                FileMarkRun.Enabled = true;
                FileMarkStop.Enabled = true;
                //点动操作按钮区
                PlatFormShiftgroupBox.Enabled = true;
            }
            else
            {
#if !DEBUG
                PointListConfiggroupBox.Enabled = false;
                //启动和停止
                FileMarkRun.Enabled = false;
                FileMarkStop.Enabled = false;
                //点动操作按钮区
                PlatFormShiftgroupBox.Enabled = false;
#endif
            }
            //绑定急停按钮事件
            Program.SystemContainer.IO.EMGButton.Value_0 += EMGButtonStatusOFF;
            Program.SystemContainer.IO.EMGButton.Value_1 += EMGButtonStatusON;
        }  
        
        /// <summary>
        /// 新建项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateProject_Click(object sender, EventArgs e)
        {
            if ((MainLaserProject.ProjectName == "") || (MainLaserProject.ProjectName == null))//项目名为空
            {
                ProjectConfig projectConfig = new ProjectConfig();
                projectConfig.SendData += IniProjectPara;
                projectConfig.ShowDialog();
            }
            else
            {
                DialogResult dr = MessageBox.Show(string.Format("是否保存当前项目\"{0}\"到文件", MainLaserProject.ProductName), "项目关闭", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    SaveProjectToFile();
                    MainLaserProjectpath = null;
                }
                else
                {
                    MainLaserProject = new LaserProject();//清空项目
                }
                ProjectConfig projectConfig = new ProjectConfig();
                projectConfig.SendData += IniProjectPara;
                projectConfig.ShowDialog();
            }
        }

        /// <summary>
        /// 新建项目参数修改
        /// </summary>
        /// <param name="ProjectName"></param>
        /// <param name="ProductName"></param>
        /// <param name="MaterialName"></param>
        private void IniProjectPara(string ProjectName, string ProductName, string MaterialName)
        {
            if (ProjectName == "")
            {
                MessageBox.Show("项目名称不能为空");
                return;
            }
            else if (ProductName == "")
            {
                MessageBox.Show("产品名称不能为空");
                return;
            }
            else if (MaterialName == "")
            {
                MessageBox.Show("材料名称不能为空");
                return;
            }
            //正确的生成参数
            MainLaserProject = new LaserProject();//释放资源
            MainLaserProject.ProjectName = ProjectName;
            MainLaserProject.ProductName = ProductName;
            MainLaserProject.MaterialName = MaterialName;
            //使能按钮操作部分
        }
        /// <summary>
        /// 打开项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenProject_Click(object sender, EventArgs e)
        {
            if ((MainLaserProject.ProjectName == "") || (MainLaserProject.ProjectName == null))//项目名为空
            {
                OpenProjectByFile();
            }
            else
            {
                DialogResult dr = MessageBox.Show(string.Format("是否保存当前项目\"{0}\"到文件", MainLaserProject.ProductName), "项目关闭", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    SaveProjectToFile();
                    MainLaserProjectpath = null;
                }
                else
                {
                    MainLaserProject = new LaserProject();//清空项目
                }
                OpenProjectByFile();//打开项目
            }
            
        }
        
        /// <summary>
        /// 打开项目
        /// </summary>
        private void OpenProjectByFile()
        {
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.Filter = "laserpro files   (*.laserpro)|*.laserpro";
            OpenFileDialog.FilterIndex = 2;
            OpenFileDialog.RestoreDirectory = true;
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                MainLaserProject = new LaserProject();
                MainLaserProject = OperatePara.LoadXmlNoPath<LaserProject>.LoadPara(OpenFileDialog.FileName);
            }
        }
        /// <summary>
        /// 导入文件
        /// </summary>
        /// <param name="sender"></param>
        ///// <param name="e"></param>
        private void ImportFile_Click(object sender, EventArgs e)
        {
            if ((MainLaserProject.ProjectName == "") || (MainLaserProject.ProjectName == null))//项目名为空
            {
                MessageBox.Show("当前项目为空，请先建立项目！");
                return;
            }
            ImportFile fileConfig = new ImportFile();
            fileConfig.SendData += VarProjectFileConfig;
            fileConfig.ShowDialog();
        }
        List<string> tem = new List<string>();
        /// <summary>
        /// 配置项目中的文件配置
        /// </summary>
        /// <param name="fileConfig"></param>
        private void VarProjectFileConfig(FileConfig fileConfig)
        {
            MainLaserProject.FileList.Clear();//保证只有一个文件保存在工程中
            MainLaserProject.FileList.Add(new FileConfig(fileConfig));
        }
        /// <summary>
        /// 配置项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfigProject_Click(object sender, EventArgs e)
        {
            if (!MainContainerProjectConfigFlag)
            {
                MainContainerProjectConfigFlag = true;
                ScissorStorageForm ScissorForm = new ScissorStorageForm();
                if (MainLaserProject.ProjectName != "")
                {
                    SendProject = new TransProject(ScissorForm.GetProject);
                    SendProject?.Invoke(MainLaserProject);
                }
                ScissorForm.SendData += ConfigProjectPara;
                ScissorForm.FormCloseEvent += ChangeFlag;
                ScissorForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("请关闭\"Mark配置\"页面后，重试！！！");
            }
        }
        /// <summary>
        /// 配置项目中的文件配置
        /// </summary>
        /// <param name="fileConfig"></param>
        private void ConfigProjectPara(LaserProject InProjectdata)
        {
            if (InProjectdata.ProjectName !="")
            {
                MainLaserProject = new LaserProject(InProjectdata);
            }
        }
        /// <summary>
        /// 物料管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaterialManagebutton_Click(object sender, EventArgs e)
        {
            if (Program.SystemContainer.MSForm == null)
            {
                Program.SystemContainer.MSForm = new MaterialStorageForm();
                Program.SystemContainer.MSForm.Show();
            }
            else
            {
                if (Program.SystemContainer.MSForm.IsDisposed) //若子窗体关闭 则打开新子窗体 并显示
                {
                    Program.SystemContainer.MSForm = new MaterialStorageForm();
                    Program.SystemContainer.MSForm.Show();
                }
                else
                {
                    Program.SystemContainer.MSForm.Activate(); //使子窗体获得焦点
                }
            }
        }
        /// <summary>
        /// 相机配置页面按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CamConfigbutton_Click(object sender, EventArgs e)
        {
            if (Program.SystemContainer.CamConfigForm == null)
            {
                Program.SystemContainer.CamConfigForm = new CameraConfigForm();
                Program.SystemContainer.CamConfigForm.Show();
            }
            else
            {
                if (Program.SystemContainer.CamConfigForm.IsDisposed) //若子窗体关闭 则打开新子窗体 并显示
                {
                    Program.SystemContainer.CamConfigForm = new CameraConfigForm();
                    Program.SystemContainer.CamConfigForm.Show();
                }
                else
                {
                    Program.SystemContainer.CamConfigForm.Activate(); //使子窗体获得焦点
                }
            }
        }
        /// <summary>
        /// 标志反转
        /// </summary>
        private void ChangeFlag()
        {
            this.Invoke((EventHandler)delegate
            {
                MainContainerProjectConfigFlag = false;
            });
        }
        /// <summary>
        /// 当前文件Mark坐标配置及查看
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MarKCoordinateConfig_Click(object sender, EventArgs e)
        {
            if (!MainContainerProjectConfigFlag)
            {
                if (MainLaserProject.ProjectName == "")
                {
                    MessageBox.Show("项目为空！！!");
                    return;
                }
                MainContainerProjectConfigFlag = true;
                MarkConfig MarkConfigForm = new MarkConfig();
                //传入当前项目
                SendProject = new TransProject(MarkConfigForm.GetProject);
                SendProject?.Invoke(MainLaserProject);
                //配置反馈事件
                MarkConfigForm.SendData += ConfigProjectPara;
                //配置定位点位事件
                MarkConfigForm.GoMarkPoint += GoPointRun;
                //配置窗口关闭事件
                MarkConfigForm.FormCloseEvent += ChangeFlag;
                //校验Mark序列
                MarkConfigForm.CheckMarkPoint += CheckMarkPointList;
                //MarkConfigForm.ShowDialog();//以对话框模式打开
                MarkConfigForm.Show();
            }
            else
            {
                MessageBox.Show("请关闭\"刀具库\"页面后，重试！！！");
            }
        }
        /// <summary>
        /// 保存项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveProject_Click(object sender, EventArgs e)
        {
            if ((MainLaserProject.ProjectName == "") || (MainLaserProject.ProjectName == null))//项目名为空
            {
                MessageBox.Show("当前项目为空，请先建立项目！");
                return;
            }
            if (MainLaserProjectpath == null)//未保存过项目
            {
                SaveProjectToFile();
            }
            else//已保存过项目
            {
                if (File.Exists(MainLaserProjectpath))
                {
                    OperatePara.SaveXmlNoPath<LaserProject>(MainLaserProjectpath, MainLaserProject);
                }
                else
                {
                    SaveProjectToFile();
                }
            }
        }

        /// <summary>
        /// 保存项目到具体文件
        /// </summary>
        private void SaveProjectToFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "laserpro files   (*.laserpro)|*.laserpro";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                MainLaserProjectpath = saveFileDialog.FileName;//记录保存位置
                OperatePara.SaveXmlNoPath<LaserProject>(saveFileDialog.FileName, MainLaserProject);
            }
        }

        /// <summary>
        /// 另存为项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveProjectAs_Click(object sender, EventArgs e)
        {
            if ((MainLaserProject.ProjectName == "") || (MainLaserProject.ProjectName == null))//项目名为空
            {
                MessageBox.Show("当前项目为空，请先建立项目！");
                return;
            }
            SaveProjectToFile();
        }
        /// <summary>
        /// 关闭项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseProject_Click(object sender, EventArgs e)
        {
            if ((MainLaserProject.ProjectName == "") || (MainLaserProject.ProjectName == null))//项目名为空
            {
                MessageBox.Show("当前项目为空，请先建立项目！");
                return;
            }
            if (MainLaserProjectpath != null) return;//项目已经保存过
            DialogResult dr = MessageBox.Show(string.Format("是否保存项目\"{0}\"到文件", MainLaserProject.ProductName), "项目关闭", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                SaveProjectToFile();
                MainLaserProjectpath = null;
            }
            else
            {
                MainLaserProject = new LaserProject();//清空项目
            }
        }

        /// <summary>
        /// 按钮启用  动作启动时，全局禁用
        /// </summary>
        private void ButtonDisable()
        {
            this.Invoke((EventHandler)delegate
            {
                AxisHome.Enabled = false;//两轴回零按钮
                Work_Type_Select_List.Enabled = false;//选择加工模式按钮
                PointListConfiggroupBox.Enabled = false;//定位坐标点按钮
                FileMarkRun.Enabled = false;//启动按钮
                FileMarkStop.Enabled = false;//停止按钮
                ResetEquipment.Enabled = false;
                //项目操作部分
                CreateProject.Enabled = false;
                SaveProjectAs.Enabled = false;
                SaveProject.Enabled = false;
                ConfigProject.Enabled = false;
                ImportFile.Enabled = false;
                OpenProject.Enabled = false;
                CloseProject.Enabled = false;
                MarKCoordinateConfig.Enabled = false;
                //点动操作按钮区
                PlatFormShiftgroupBox.Enabled = false;
                //页面区域
                manualFormPage.Enabled = false;//手动操作页面
                laserFormPage.Enabled = false;//激光操作页面
                setFormPage.Enabled = false;//参数设置页面
            });            
        }
        /// <summary>
        /// 按钮禁用 动作结束时，全局启用
        /// </summary>
        private void ButtonEnable()
        {
            this.Invoke((EventHandler)delegate
            {
                AxisHome.Enabled = true;//两轴回零按钮
                Work_Type_Select_List.Enabled = true;//选择加工模式按钮
                PointListConfiggroupBox.Enabled = true;//定位坐标点按钮
                FileMarkRun.Enabled = true;//启动按钮
                FileMarkStop.Enabled = true;//停止按钮
                ResetEquipment.Enabled = true;
                //项目操作部分
                CreateProject.Enabled = true;
                SaveProjectAs.Enabled = true;
                SaveProject.Enabled = true;
                ConfigProject.Enabled = true;
                ImportFile.Enabled = true;
                OpenProject.Enabled = true;
                CloseProject.Enabled = true;
                MarKCoordinateConfig.Enabled = true;
                //点动操作按钮区
                PlatFormShiftgroupBox.Enabled = true;
                //页面区域
                manualFormPage.Enabled = true;//手动操作页面
                laserFormPage.Enabled = true;//激光操作页面
                setFormPage.Enabled = true;//参数设置页面
            });
        }

        /// <summary>
        /// 两轴回零
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AxisHome_Click(object sender, EventArgs e)
        {
            AxisHome.Text = "平台回零中";
            Thread Axis01_home_thread = new Thread(this.Axis01_Home);
            Thread Axis02_home_thread = new Thread(this.Axis02_Home);
            Axis01_home_thread.Start();
            Axis02_home_thread.Start();
            AxisHome.Enabled = false;
            PointListConfiggroupBox.Enabled = false;
            ResetEquipment.Enabled = false;
            //启动和停止
            FileMarkRun.Enabled = false;
            FileMarkStop.Enabled = false;
            //点动操作按钮区
            PlatFormShiftgroupBox.Enabled = false;
            appendInfo("XY平台归零启动！！！");
        }
        /// <summary>
        /// X轴回零
        /// </summary>
        private void Axis01_Home()
        {
            if (Program.SystemContainer.IO.Axis01_EN)
            {
                int Xflag = Program.SystemContainer.GTS_Fun.Axis01_Home_Down_Motor();
                if (Xflag == 0)
                {
                    appendInfo("X轴归零完成！！！");
                    Thread.Sleep(200);
                    if (Program.SystemContainer.IO.Gts_Home_Flag)
                    {
                        appendInfo("XY平台归零完成！！！");
                        //定位初始点
                        UpdateAxisHomePos();
                        //刷新按钮状态
                        UpdateAxisHomeButtonStatus();
                    }
                }
                else
                {
                    Thread.Sleep(200);
                    //检测Y轴非运行中 退出
                    if (Program.SystemContainer.IO.Axis02_Busy)
                    {
                        appendInfo(string.Format("X轴归零错误，代码{0}", Xflag));
                        return;
                    }
                    if (this.IsHandleCreated) this.Invoke((EventHandler)delegate
                    {
                        AxisHome.Enabled = true;
                        AxisHome.Text = "平台初始化";
                        AxisHome.ForeColor = Color.Black;
                        ResetEquipment.Enabled = true;
                        appendInfo(string.Format("X轴归零错误，代码{0}", Xflag));
                    });                    
                }
            }
            else
            {
                if (this.IsHandleCreated) this.Invoke((EventHandler)delegate
                {
                    AxisHome.Enabled = true;
                    AxisHome.Text = "平台初始化";
                    AxisHome.ForeColor = Color.Black;
                    ResetEquipment.Enabled = true;
                    appendInfo("X轴使能关闭，归零失败！！！");
                });                
            }
        }
        /// <summary>
        /// Y轴回零
        /// </summary>
        private void Axis02_Home()
        {
            if (Program.SystemContainer.IO.Axis02_EN)
            {
                int Yflag = Program.SystemContainer.GTS_Fun.Axis02_Home_Down_Motor();
                if (Yflag == 0)
                {
                    appendInfo("Y轴归零完成！！！");
                    Thread.Sleep(200);
                    if (Program.SystemContainer.IO.Gts_Home_Flag)
                    {
                        appendInfo("XY平台归零完成！！！"); //定位初始点
                        UpdateAxisHomePos();
                        //刷新按钮状态
                        UpdateAxisHomeButtonStatus();
                    }
                }
                else
                {
                    Thread.Sleep(200);
                    //检测X轴非运行中 退出
                    if (Program.SystemContainer.IO.Axis01_Busy)
                    {
                        appendInfo(string.Format("Y轴归零错误，代码{0}",Yflag));
                        return;
                    }
                    //恢复按钮
                    if (this.IsHandleCreated) this.Invoke((EventHandler)delegate
                    {
                        AxisHome.Enabled = true;
                        AxisHome.Text = "平台初始化";
                        AxisHome.ForeColor = Color.Black;
                        ResetEquipment.Enabled = true;
                        appendInfo(string.Format("Y轴归零错误，代码{0}", Yflag));
                    });
                }
            }
            else
            {
                if (this.IsHandleCreated) this.Invoke((EventHandler)delegate
                {
                    AxisHome.Enabled = true;
                    AxisHome.Text = "平台初始化";
                    AxisHome.ForeColor = Color.Black;
                    ResetEquipment.Enabled = true;
                    appendInfo("Y轴使能关闭，归零失败！！！");
                });
                
            }
        }
        /// <summary>
        /// 更新两轴回零后归零
        /// </summary>
        private void UpdateAxisHomePos()
        {
            //判断定位坐标是否合适
            Vector MarkPoint = new Vector(0, 0) - Program.SystemContainer.SysPara.Rtc_Org;
            //判断坐标是否超出定位范围
            if (!DeterminePoint(MarkPoint)) return;
            //定位至激光对准的原点坐标
            if (!Program.SystemContainer.GTS_Fun.Gts_Point_Go(MarkPoint, 1))
            {
                MessageBox.Show("平台定位异常，加工终止！！！");
                return;
            }            
        }
        /// <summary>
        /// 更新两轴回零后刷新按钮状态
        /// </summary>
        private void UpdateAxisHomeButtonStatus()
        {
            //按钮恢复
            this.Invoke((EventHandler)delegate
            {
                AxisHome.Enabled = true;
                AxisHome.Text = "平台Ready";
                AxisHome.ForeColor = Color.Green;
                PointListConfiggroupBox.Enabled = true;
                ResetEquipment.Enabled = true;
                //启动和停止
                FileMarkRun.Enabled = true;
                FileMarkStop.Enabled = true;
                //点动操作按钮区
                PlatFormShiftgroupBox.Enabled = true;
            });
        }        
        
        /// <summary>
        /// 紧急停止按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmgStopButton_Click(object sender, EventArgs e)
        {
           Program.SystemContainer.IO.SoftEMG = !Program.SystemContainer.IO.SoftEMG;   
        }
        /// <summary>
        /// 刷新急停按钮状态 ON
        /// </summary>
        private void EMGButtonStatusON()
        {
            this.Invoke((EventHandler)delegate
            {
                Program.SystemContainer.IO.GlobalEMG = true;
                EmgStopButton.Text = "急停中";
                MainFormLogErr("急停按钮解除！！！");
                EmgStopButton.ForeColor = Color.Red;
                if (running) ThreadStop();
                ButtonDisable();//禁用按钮
            });
        }
        /// <summary>
        /// 刷新急停按钮状态 OFF
        /// </summary>
        private void EMGButtonStatusOFF()
        {
            this.Invoke((EventHandler)delegate
            {
                Program.SystemContainer.IO.GlobalEMG = false;
                EmgStopButton.Text = "急停";
                appendInfo("急停按钮解除！！！");
                MainFormLogErr("急停按钮解除！！！");
                EmgStopButton.ForeColor = Color.Black;
                ButtonEnable();//启用按钮
            });
        }

        /// <summary>
        ///  普通用户  权限操作
        /// </summary>
        private void MethodsListNormalInject()
        {
            Work_Type_Select_List.Items.Clear();
            Work_Type_Select_List.Items.AddRange(Methods_List_Normal.ToArray());
            //加工方式选择
            Work_Type_Select_List.SelectedIndex = 0;

            //隐藏手动操作页面
            manualFormPage.Visible = false;

            //隐藏主页面调试选项
            MainFormDebuggroupBox.Visible = false;

            //参数部分禁止修改
            CoordinategroupBox.Enabled = false;//坐标系参数
            DebugMenugroupBox.Visible = false;//调试菜单参数
            CalibrationgroupBox.Visible = false;//校准菜单
            AxisParagroupBox.Enabled = false;//轴参数
            CertifyRepeatPrecisiongroupBox.Enabled = false;//重复性验证
        }

        /// <summary>
        ///  管理员用户   权限操作
        /// </summary>
        private void MethodsListAdminInject()
        {
            Work_Type_Select_List.Items.Clear();
            Work_Type_Select_List.Items.AddRange(Methods_List_Admin.ToArray());
            //加工方式选择
            Work_Type_Select_List.SelectedIndex = 0;
            
            //显示手动操作页面
            manualFormPage.Visible = true;

            //显示主页面调试选项
            MainFormDebuggroupBox.Visible = true;

            //参数部分允许修改
            CoordinategroupBox.Enabled = true;//坐标系参数
            DebugMenugroupBox.Visible = true;//调试菜单参数
            CalibrationgroupBox.Visible = true;//校准菜单
            AxisParagroupBox.Enabled = true;//轴参数
            CertifyRepeatPrecisiongroupBox.Enabled = true;//重复性验证
        }
    }
}

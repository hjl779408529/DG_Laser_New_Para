using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DG_Laser
{    
    class Cam_Integrate
    {
        //退出执行
        public static event LogErrstring LogErr;
        public static event LogInfo LogInfo;
        public static bool Exit_Flag = false;
        public static string[] methods = {
            "Rts_No_Gts_No",
            "Rts_Affinity_Gts_No",
            "Rts_Affinity_Gts_Yes",
            "Rts_Angle_Gts_Yes",
            "Rtc_Mat_Gts_Yes",
            "Rts_Origin_Gts_Yes",
            "Rts_No_Gts_Yes"
        };
        /// <summary>
        /// Cam加工启动 分时序加工
        /// </summary>
        /// <param name="Work_Datas"></param>
        /// <param name="Type"></param>
        public static void Cam_Work_Start(List<List<List<Interpolation_Data>>> Work_Datas,int Type,int method_index)
        {
            //获取类中的方法
            /*
            MethodInfo[] methodInfos = typeof(Cam_Integrate_Fun).GetMethods();
            string[] methods =new string[methodInfos.Length];
            for(int i = 0;i< methodInfos.Length;i++)
            {
                methods[i] = methodInfos[i].Name;
            }
            */
            //遍历依此加工
            for (int i = 0;i< Work_Datas.Count; i++)
            {
                //退出
                if (Exit_Flag)
                {
                    Exit_Flag = false;
                    Cam_Integrate_Fun.Exit_Flag = false;
                    return;
                }

                //执行
                for (int j = 0; j < Program.SystemContainer.SysPara.Work_Repeat_Times; j++)
                {
                    //退出
                    if (Exit_Flag)
                    {
                        Exit_Flag = false;
                        Cam_Integrate_Fun.Exit_Flag = false;
                        return;
                    }
                    //刀具参数生效
                    if (Type == 0)//Drill
                    {
                        if (Work_Datas[i][0][0].Path_Type < Program.SystemContainer.Repeat_Drill_Scissor.Count)
                        {
                            if ((Program.SystemContainer.Repeat_Drill_Scissor[Work_Datas[i][0][0].Path_Type].Repeat[j] > 0) && (Program.SystemContainer.Repeat_Drill_Scissor[Work_Datas[i][0][0].Path_Type].Repeat[j] <= Program.SystemContainer.Drill_Scissor.Count))
                            {
                                if (Program.SystemContainer.Drill_Scissor[Program.SystemContainer.Repeat_Drill_Scissor[Work_Datas[i][0][0].Path_Type].Repeat[j] - 1].Mark_Speed != 0)
                                {
                                    Program.SystemContainer.RTC_Fun.Scissors_Para_Exe(Program.SystemContainer.Drill_Scissor[Program.SystemContainer.Repeat_Drill_Scissor[Work_Datas[i][0][0].Path_Type].Repeat[j] - 1]);//启用当前重复次数的刀具
                                }
                                else
                                {
                                    LogInfo?.Invoke(string.Format("Drill{0}刀具MarkSpeed为零，请检查！！！", Program.SystemContainer.Repeat_Drill_Scissor[Work_Datas[i][0][0].Path_Type].Repeat[j]));
                                    continue;
                                }
                            }
                            else
                            {
                                LogInfo?.Invoke("无可用Drill刀具！！！");
                                continue;
                            }
                        }
                        else
                        {
                            LogInfo?.Invoke(string.Format("Dill{0}超出Drill重复参数范围，请检查！！！", Work_Datas[i][0][0].Path_Type));
                            return;
                        }

                        
                    }
                    else if (Type == 1)//Arc
                    {
                        if (Work_Datas[i][0][0].Path_Type < Program.SystemContainer.Repeat_Arc_Scissor.Count)
                        {
                            if ((Program.SystemContainer.Repeat_Arc_Scissor[Work_Datas[i][0][0].Path_Type].Repeat[j] > 0) && (Program.SystemContainer.Repeat_Arc_Scissor[Work_Datas[i][0][0].Path_Type].Repeat[j] <= Program.SystemContainer.Arc_Scissor.Count))
                            {
                                if (Program.SystemContainer.Arc_Scissor[Program.SystemContainer.Repeat_Arc_Scissor[Work_Datas[i][0][0].Path_Type].Repeat[j] - 1].Mark_Speed != 0)
                                {
                                    Program.SystemContainer.RTC_Fun.Scissors_Para_Exe(Program.SystemContainer.Arc_Scissor[Program.SystemContainer.Repeat_Arc_Scissor[Work_Datas[i][0][0].Path_Type].Repeat[j] - 1]);//启用当前重复次数的刀具
                                }
                                else
                                {
                                    LogInfo?.Invoke(string.Format("Arc{0}刀具MarkSpeed为零，请检查！！！", Program.SystemContainer.Repeat_Arc_Scissor[Work_Datas[i][0][0].Path_Type].Repeat[j]));
                                    continue;
                                }
                            }
                            else
                            {
                                LogInfo?.Invoke("无可用Arc刀具！！！");
                                continue;
                            }
                        }
                        else
                        {
                            LogInfo?.Invoke(string.Format("Arc{0}超出Arc重复参数范围，请检查！！！", Work_Datas[i][0][0].Path_Type));
                            return;
                        }

                        
                    }
                    else if (Type == 2)//Line
                    {
                        if (Work_Datas[i][0][0].Path_Type < Program.SystemContainer.Repeat_Line_Scissor.Count)
                        {
                            if ((Program.SystemContainer.Repeat_Line_Scissor[Work_Datas[i][0][0].Path_Type].Repeat[j] > 0) && (Program.SystemContainer.Repeat_Line_Scissor[Work_Datas[i][0][0].Path_Type].Repeat[j] <= Program.SystemContainer.Line_Scissor.Count))
                            {
                                if (Program.SystemContainer.Line_Scissor[Program.SystemContainer.Repeat_Line_Scissor[Work_Datas[i][0][0].Path_Type].Repeat[j] - 1].Mark_Speed != 0)
                                {
                                    Program.SystemContainer.RTC_Fun.Scissors_Para_Exe(Program.SystemContainer.Line_Scissor[Program.SystemContainer.Repeat_Line_Scissor[Work_Datas[i][0][0].Path_Type].Repeat[j] - 1]);//启用当前重复次数的刀具
                                }
                                else
                                {
                                    LogInfo?.Invoke(string.Format("Line{0}刀具MarkSpeed为零，请检查！！！", Program.SystemContainer.Repeat_Line_Scissor[Work_Datas[i][0][0].Path_Type].Repeat[j]));
                                    continue;
                                }                                
                            }
                            else
                            {
                                LogInfo?.Invoke("无可用Line刀具！！！");
                                continue;
                            }
                        }
                        else
                        {
                            LogInfo?.Invoke(string.Format("Line{0}超出Line重复参数范围，请检查！！！", Work_Datas[i][0][0].Path_Type));
                            return;
                        }                       
                    }

                    //执行
                    Cam_Integrate_Fun Cam_Method = new Cam_Integrate_Fun();
                    var Work_Method = typeof(Cam_Integrate_Fun).GetMethod(methods[method_index]);
                    object[] paras = new object[] { Work_Datas[i] };
                    Work_Method.Invoke(Cam_Method, paras);

                }     
            }
        }

        /// <summary>
        /// 定位归卸料位
        /// </summary>
        public static void Pos_Upload()
        {
            if (Program.SystemContainer.SysPara.Upload_Type_Select == 1)//坐标系原点
            {
                Program.SystemContainer.GTS_Fun.Gts_Ready_Correct(0, 0);
            }
            else if (Program.SystemContainer.SysPara.Upload_Type_Select == 2)//上下料位
            {
                Program.SystemContainer.GTS_Fun.Gts_Ready_Correct(Program.SystemContainer.SysPara.Upload_Point.X, Program.SystemContainer.SysPara.Upload_Point.Y);
            }
        }

        /// <summary>
        /// 根据刀具参数设置激光功率值和频率值
        /// </summary>
        /// <param name="tech_Parameter"></param>
        /// <returns></returns>
        private bool Laser_PEC_PEF_Write(Tech_Parameter tech_Parameter)
        {
            decimal PEC = 0, PRF = 0;
            //读取PEC功率值
            Program.SystemContainer.Laser_Operation_00.Read("00", "55");
            if (!(Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Rec_Byte == null) && (Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Rec_Byte.Length == 2)) PEC = ((decimal)BitConverter.ToUInt16(Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Rec_Byte, 0) / 10m);
            //读取PRF频率值
            Program.SystemContainer.Laser_Operation_00.Read("00", "21");
            if (!(Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Rec_Byte == null) && (Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Rec_Byte.Length == 3)) PRF = ((decimal)BitConverter.ToUInt32(new byte[] { Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Rec_Byte[0], Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Rec_Byte[1], Program.SystemContainer.Laser_Operation_00.Resolve_Rec.Rec_Byte[2], 0x00 }, 0) / 1000m);
            //设置PEC功率值
            if (PEC != tech_Parameter.PEC) Program.SystemContainer.Laser_Operation_00.Change_Pec(tech_Parameter.PEC);
            //设置PRF频率值
            if (PRF != tech_Parameter.PRF) Program.SystemContainer.Laser_Operation_00.Write("00", "21", Program.SystemContainer.Laser_Operation_00.PRF_To_Str((UInt32)(tech_Parameter.PRF * 1000)));
            return true;
        }


    }

    class Cam_Integrate_Fun
    {
        //退出执行
        public static bool Exit_Flag = false;

        /// <summary>
        /// 振镜不补偿 + 平台不补偿
        /// </summary>
        /// <param name="List_Datas"></param>
        public void Rts_No_Gts_No(List<List<Interpolation_Data>> List_Datas)
        {
            //临时变量
            int i = 0, j = 0;
            //数据处理
            for (i = 0; i < List_Datas.Count; i++)//外层数据
            {
                for (j = 0; j < List_Datas[i].Count; j++)//内层数据
                {
                    if (List_Datas[i][j].Work == 10)//Gts加工数据
                    {
                        if (List_Datas[i][j].Lift_flag == 1)//抬刀标志
                        {
                            //关闭激光
                            Program.SystemContainer.RTC_Fun.Close_Laser();
                            //启动Gts运动
                            Program.SystemContainer.GTS_Fun.Integrate(List_Datas[i]);
                        }
                        else
                        {
                            //关闭激光
                            Program.SystemContainer.RTC_Fun.Close_Laser();
                            //定位到零点
                            Program.SystemContainer.RTC_Fun.Home();
                            //Gts移动到启动位置 本次的开始
                            Program.SystemContainer.GTS_Fun.Gts_Ready(List_Datas[i][0].Start_x, List_Datas[i][0].Start_y);
                            //打开激光
                            Program.SystemContainer.RTC_Fun.Open_Laser();
                            //启动Gts运动
                            Program.SystemContainer.GTS_Fun.Integrate(List_Datas[i]);
                            //关闭激光
                            Program.SystemContainer.RTC_Fun.Close_Laser();
                        }
                    }
                    else if (List_Datas[i][j].Work == 20)//Rtc加工数据
                    {
                        if (List_Datas[i][j].Lift_flag == 1)//抬刀标志
                        {
                            //关闭激光
                            Program.SystemContainer.RTC_Fun.Close_Laser();
                            //Gts移动到准备位置 本次开头
                            Program.SystemContainer.GTS_Fun.Gts_Ready(List_Datas[i][0].Gts_x, List_Datas[i][0].Gts_y);
#if !DEBUG
                            //启动RTC加工
                            Program.SystemContainer.RTC_Fun.Draw_Jump_Axis(List_Datas[i], 1);
#endif
                        }
                        else
                        {
                            //关闭激光
                            Program.SystemContainer.RTC_Fun.Close_Laser();
                            //Gts移动到准备位置 本次开头
                            Program.SystemContainer.GTS_Fun.Gts_Ready(List_Datas[i][0].Gts_x, List_Datas[i][0].Gts_y);
#if !DEBUG
                            //启动加工
                            Program.SystemContainer.RTC_Fun.Draw_Mark_Axis(List_Datas[i], 1);
#endif
                            //关闭激光
                            Program.SystemContainer.RTC_Fun.Close_Laser();
                        }
                    }
                    break;
                }
                //退出执行
                if (Exit_Flag)
                {
                    Program.SystemContainer.RTC_Fun.Home();
                    return;
                }
            }
            Program.SystemContainer.RTC_Fun.Home();
        }

        /// <summary>
        /// 振镜不补偿 + 平台补偿
        /// </summary>
        /// <param name="List_Datas"></param>
        public void Rts_No_Gts_Yes(List<List<Interpolation_Data>> List_Datas)
        {
            //临时变量
            int i = 0, j = 0;
            //数据处理
            for (i = 0; i < List_Datas.Count; i++)//外层数据
            {
                for (j = 0; j < List_Datas[i].Count; j++)//内层数据
                {
                    //退出执行
                    if (Exit_Flag)
                    {
                        Program.SystemContainer.RTC_Fun.Home();
                        return;
                    }
                    //执行
                    if (List_Datas[i][j].Work == 10)//Gts加工数据
                    {

                        if (List_Datas[i][j].Lift_flag == 1)//抬刀标志
                        {
                            //关闭激光
                            Program.SystemContainer.RTC_Fun.Close_Laser();

                            //启动Gts运动
                            Program.SystemContainer.GTS_Fun.Integrate_Correct(List_Datas[i]);
                        }
                        else
                        {
                            //关闭激光
                            Program.SystemContainer.RTC_Fun.Close_Laser();
                            //定位到零点
                            Program.SystemContainer.RTC_Fun.Home();

                            //Gts移动到启动位置 本次的开始
                            Program.SystemContainer.GTS_Fun.Gts_Ready_Correct(List_Datas[i][0].Start_x, List_Datas[i][0].Start_y);
                            //打开激光

                            Program.SystemContainer.RTC_Fun.Open_Laser();

                            //启动Gts运动
                            Program.SystemContainer.GTS_Fun.Integrate_Correct(List_Datas[i]);

                            //关闭激光
                            Program.SystemContainer.RTC_Fun.Close_Laser();

                        }

                    }
                    else if (List_Datas[i][j].Work == 20)//Rtc加工数据
                    {
                        if (List_Datas[i][j].Lift_flag == 1)//抬刀标志
                        {
                            //关闭激光
                            Program.SystemContainer.RTC_Fun.Close_Laser();
                            //Gts移动到准备位置 本次开头
                            Program.SystemContainer.GTS_Fun.Gts_Ready_Correct(List_Datas[i][0].Gts_x, List_Datas[i][0].Gts_y);
#if !DEBUG
                            //启动RTC加工
                            Program.SystemContainer.RTC_Fun.Draw_Jump_Axis(List_Datas[i], 1);
#endif

                        }
                        else
                        {
                            //关闭激光
                            Program.SystemContainer.RTC_Fun.Close_Laser();

                            //Gts移动到准备位置 本次开头
                            Program.SystemContainer.GTS_Fun.Gts_Ready_Correct(List_Datas[i][0].Gts_x, List_Datas[i][0].Gts_y);
#if !DEBUG
                            //启动加工
                            Program.SystemContainer.RTC_Fun.Draw_Mark_Axis(List_Datas[i], 1);
#endif
                            //关闭激光
                            Program.SystemContainer.RTC_Fun.Close_Laser();

                        }
                    }
                    break;
                }
                //退出执行
                if (Exit_Flag)
                {
                    Program.SystemContainer.RTC_Fun.Home();
                    return;
                }
            }
            Program.SystemContainer.RTC_Fun.Home();
        }

        /// <summary>
        /// 振镜仿射补偿 + 平台不补偿
        /// </summary>
        /// <param name="List_Datas"></param>
        public void Rts_Affinity_Gts_No(List<List<Interpolation_Data>> List_Datas)
        {
            //临时变量
            int i = 0, j = 0;
            //数据处理
            for (i = 0; i < List_Datas.Count; i++)//外层数据
            {
                for (j = 0; j < List_Datas[i].Count; j++)//内层数据
                {
                    if (List_Datas[i][j].Work == 10)//Gts加工数据
                    {
                        if (List_Datas[i][j].Lift_flag == 1)//抬刀标志
                        {
                            //关闭激光
                            Program.SystemContainer.RTC_Fun.Close_Laser();
                            //启动Gts运动
                            Program.SystemContainer.GTS_Fun.Integrate(List_Datas[i]);
                        }
                        else
                        {
                            //关闭激光
                            Program.SystemContainer.RTC_Fun.Close_Laser();
                            //定位到零点
                            Program.SystemContainer.RTC_Fun.Home();
                            //Gts移动到启动位置 本次的开始
                            Program.SystemContainer.GTS_Fun.Gts_Ready(List_Datas[i][0].Start_x, List_Datas[i][0].Start_y);
                            //打开激光
                            Program.SystemContainer.RTC_Fun.Open_Laser();
                            //启动Gts运动
                            Program.SystemContainer.GTS_Fun.Integrate(List_Datas[i]);
                            //关闭激光
                            Program.SystemContainer.RTC_Fun.Close_Laser();
                        }
                    }
                    else if (List_Datas[i][j].Work == 20)//Rtc加工数据
                    {
                        if (List_Datas[i][j].Lift_flag == 1)//抬刀标志
                        {
                            //关闭激光
                            Program.SystemContainer.RTC_Fun.Close_Laser();
                            //Gts移动到准备位置 本次开头
                            Program.SystemContainer.GTS_Fun.Gts_Ready(List_Datas[i][0].Gts_x, List_Datas[i][0].Gts_y);
#if !DEBUG
                            //启动RTC加工
                            Program.SystemContainer.RTC_Fun.Draw_Jump_AFF(List_Datas[i], 1);
#endif
                        }
                        else
                        {
                            //关闭激光
                            Program.SystemContainer.RTC_Fun.Close_Laser();
                            //Gts移动到准备位置 本次开头
                            Program.SystemContainer.GTS_Fun.Gts_Ready(List_Datas[i][0].Gts_x, List_Datas[i][0].Gts_y);
#if !DEBUG
                            //启动加工
                            Program.SystemContainer.RTC_Fun.Draw_Mark_AFF(List_Datas[i], 1);
#endif
                            //关闭激光
                            Program.SystemContainer.RTC_Fun.Close_Laser();
                        }
                    }
                    break;
                }
                //退出执行
                if (Exit_Flag)
                {
                    Program.SystemContainer.RTC_Fun.Home();
                    return;
                }
            }
            Program.SystemContainer.RTC_Fun.Home();
        }       

        /// <summary>
        /// 振镜坐标系仿射变换补偿 + 平台补偿
        /// </summary>
        /// <param name="List_Datas"></param>
        public void Rts_Affinity_Gts_Yes(List<List<Interpolation_Data>> List_Datas)
        {
            //临时变量
            int i = 0, j = 0;
            //数据处理
            for (i = 0; i < List_Datas.Count; i++)//外层数据
            {
                for (j = 0; j < List_Datas[i].Count; j++)//内层数据
                {
                    //退出执行
                    if (Exit_Flag)
                    {
                        Program.SystemContainer.RTC_Fun.Home();
                        return;
                    }
                    //执行
                    if (List_Datas[i][j].Work == 10)//Gts加工数据
                    {

                        if (List_Datas[i][j].Lift_flag == 1)//抬刀标志
                        {

                            //关闭激光
                            Program.SystemContainer.RTC_Fun.Close_Laser();

                            //启动Gts运动
                            Program.SystemContainer.GTS_Fun.Integrate_Correct(List_Datas[i]);
                        }
                        else
                        {

                            //关闭激光
                            Program.SystemContainer.RTC_Fun.Close_Laser();
                            //定位到零点
                            Program.SystemContainer.RTC_Fun.Home();

                            //Gts移动到启动位置 本次的开始
                            Program.SystemContainer.GTS_Fun.Gts_Ready_Correct(List_Datas[i][0].Start_x, List_Datas[i][0].Start_y);
                            //打开激光

                            Program.SystemContainer.RTC_Fun.Open_Laser();

                            //启动Gts运动
                            Program.SystemContainer.GTS_Fun.Integrate_Correct(List_Datas[i]);

                            //关闭激光
                            Program.SystemContainer.RTC_Fun.Close_Laser();

                        }

                    }
                    else if (List_Datas[i][j].Work == 20)//Rtc加工数据
                    {
                        if (List_Datas[i][j].Lift_flag == 1)//抬刀标志
                        {

                            //关闭激光
                            Program.SystemContainer.RTC_Fun.Close_Laser();
                            //Gts移动到准备位置 本次开头
                            Program.SystemContainer.GTS_Fun.Gts_Ready_Correct(List_Datas[i][0].Gts_x, List_Datas[i][0].Gts_y);
#if !DEBUG
                            //启动RTC加工
                            Program.SystemContainer.RTC_Fun.Draw_Jump_AFF(List_Datas[i], 1);
#endif

                        }
                        else
                        {

                            //关闭激光
                            Program.SystemContainer.RTC_Fun.Close_Laser();

                            //Gts移动到准备位置 本次开头
                            Program.SystemContainer.GTS_Fun.Gts_Ready_Correct(List_Datas[i][0].Gts_x, List_Datas[i][0].Gts_y);
#if !DEBUG
                            //启动加工
                            Program.SystemContainer.RTC_Fun.Draw_Mark_AFF(List_Datas[i], 1);
#endif
                            //关闭激光
                            Program.SystemContainer.RTC_Fun.Close_Laser();

                        }
                    }
                    break;
                }
                //退出执行
                if (Exit_Flag)
                {
                    Program.SystemContainer.RTC_Fun.Home();
                    return;
                }
            }
            Program.SystemContainer.RTC_Fun.Home();
        }

        /// <summary>
        /// 振镜坐标系角度变换补偿 + 平台补偿
        /// </summary>
        /// <param name="List_Datas"></param>
        public void Rts_Angle_Gts_Yes(List<List<Interpolation_Data>> List_Datas)
        {
            //临时变量
            int i = 0, j = 0;
            //数据处理
            for (i = 0; i < List_Datas.Count; i++)//外层数据
            {
                for (j = 0; j < List_Datas[i].Count; j++)//内层数据
                {
                    //退出执行
                    if (Exit_Flag)
                    {
                        Program.SystemContainer.RTC_Fun.Home();
                        return;
                    }
                    //执行
                    if (List_Datas[i][j].Work == 10)//Gts加工数据
                    {
                        if (List_Datas[i][j].Lift_flag == 1)//抬刀标志
                        {
                            //关闭激光
                            Program.SystemContainer.RTC_Fun.Close_Laser();
                            //启动Gts运动
                            Program.SystemContainer.GTS_Fun.Integrate_Correct(List_Datas[i]);
                        }
                        else
                        {
                            //关闭激光
                            Program.SystemContainer.RTC_Fun.Close_Laser();
                            //定位到零点
                            Program.SystemContainer.RTC_Fun.Home();
                            //Gts移动到启动位置 上一list数据的结尾数据或本次的结尾;待测试
                            Program.SystemContainer.GTS_Fun.Gts_Ready_Correct(List_Datas[i][0].Start_x, List_Datas[i][0].Start_y);
                            //打开激光
                            Program.SystemContainer.RTC_Fun.Open_Laser();
                            //启动Gts运动
                            Program.SystemContainer.GTS_Fun.Integrate_Correct(List_Datas[i]);
                            //关闭激光
                            Program.SystemContainer.RTC_Fun.Close_Laser();
                        }

                    }
                    else if (List_Datas[i][j].Work == 20)//Rtc加工数据
                    {
                        if (List_Datas[i][j].Lift_flag == 1)//抬刀标志
                        {
                            //关闭激光
                            Program.SystemContainer.RTC_Fun.Close_Laser();
                            //Gts移动到准备位置 本次开头
                            Program.SystemContainer.GTS_Fun.Gts_Ready_Correct(List_Datas[i][0].Gts_x, List_Datas[i][0].Gts_y);
#if !DEBUG
                            //启动RTC加工
                            Program.SystemContainer.RTC_Fun.Draw_Jump_Angle(List_Datas[i], 1);
#endif
                        }
                        else
                        {
                            //关闭激光
                            Program.SystemContainer.RTC_Fun.Close_Laser();
                            //Gts移动到准备位置 本次开头
                            Program.SystemContainer.GTS_Fun.Gts_Ready_Correct(List_Datas[i][0].Gts_x, List_Datas[i][0].Gts_y);
#if !DEBUG
                            //启动加工
                            Program.SystemContainer.RTC_Fun.Draw_Mark_Angle(List_Datas[i], 1);
#endif
                            //关闭激光
                            Program.SystemContainer.RTC_Fun.Close_Laser();
                        }
                    }
                    break;
                }
                //退出执行
                if (Exit_Flag)
                {
                    Program.SystemContainer.RTC_Fun.Home();
                    return;
                }
            }
            Program.SystemContainer.RTC_Fun.Home();
        }

        /// <summary>
        ///  振镜坐标系矩阵补偿 + 平台补偿
        /// </summary>
        /// <param name="List_Datas"></param>
        public void Rtc_Mat_Gts_Yes(List<List<Interpolation_Data>> List_Datas)
        {
            //临时变量
            int i = 0, j = 0;
            //数据处理
            for (i = 0; i < List_Datas.Count; i++)//外层数据
            {
                for (j = 0; j < List_Datas[i].Count; j++)//内层数据
                {
                    //退出执行
                    if (Exit_Flag)
                    {
                        Program.SystemContainer.RTC_Fun.Home();
                        return;
                    }
                    //执行
                    if (List_Datas[i][j].Work == 10)//Gts加工数据
                    {
                        if (List_Datas[i][j].Lift_flag == 1)//抬刀标志
                        {
                            //关闭激光
                            Program.SystemContainer.RTC_Fun.Close_Laser();
                            //启动Gts运动
                            Program.SystemContainer.GTS_Fun.Integrate_Correct(List_Datas[i]);
                        }
                        else
                        {
                            //关闭激光
                            Program.SystemContainer.RTC_Fun.Close_Laser();
                            //定位到零点
                            Program.SystemContainer.RTC_Fun.Home();
                            //Gts移动到启动位置 上一list数据的结尾数据或本次的结尾或本次序号0的start;待测试
                            Program.SystemContainer.GTS_Fun.Gts_Ready_Correct(List_Datas[i][0].Start_x, List_Datas[i][0].Start_y);
                            //打开激光
                            Program.SystemContainer.RTC_Fun.Open_Laser();
                            //启动Gts运动
                            Program.SystemContainer.GTS_Fun.Integrate_Correct(List_Datas[i]);
                            //关闭激光
                            Program.SystemContainer.RTC_Fun.Close_Laser();
                        }
                    }
                    else if (List_Datas[i][j].Work == 20)//Rtc加工数据
                    {
                        if (List_Datas[i][j].Lift_flag == 1)//抬刀标志
                        {
                            //关闭激光
                            Program.SystemContainer.RTC_Fun.Close_Laser();
                            //Gts移动到准备位置 本次开头
                            Program.SystemContainer.GTS_Fun.Gts_Ready_Correct(List_Datas[i][0].Gts_x, List_Datas[i][0].Gts_y);
#if !DEBUG
                            //启动RTC加工
                            Program.SystemContainer.RTC_Fun.Draw_Jump_Matrix(List_Datas[i], 1);
#endif
                        }
                        else
                        {
                            //关闭激光
                            Program.SystemContainer.RTC_Fun.Close_Laser();
                            //Gts移动到准备位置 本次开头
                            Program.SystemContainer.GTS_Fun.Gts_Ready_Correct(List_Datas[i][0].Gts_x, List_Datas[i][0].Gts_y);//启动加工
#if !DEBUG
                            //启动加工
                            Program.SystemContainer.RTC_Fun.Draw_Mark_Matrix(List_Datas[i], 1);

#endif
                            //关闭激光
                            Program.SystemContainer.RTC_Fun.Close_Laser();
                        }
                    }
                    break;
                }
                //退出执行
                if (Exit_Flag)
                {
                    Program.SystemContainer.RTC_Fun.Home();
                    return;
                }
            }
            Program.SystemContainer.RTC_Fun.Home();
        }

        /// <summary>
        /// 振镜不补偿且坐标系方向不纠正 + 平台补偿 生成RTC校准坐标 用于生RTC板卡校准文件 桶形畸变矫正图形加工
        /// </summary>
        /// <param name="List_Datas"></param>
        public void Rts_Origin_Gts_Yes(List<List<Interpolation_Data>> List_Datas)
        {
            //临时变量
            int i = 0, j = 0;
            //数据处理
            for (i = 0; i < List_Datas.Count; i++)//外层数据
            {
                for (j = 0; j < List_Datas[i].Count; j++)//内层数据
                {
                    //退出执行
                    if (Exit_Flag)
                    {
                        Program.SystemContainer.RTC_Fun.Home();
                        return;
                    }
                    //执行
                    if (List_Datas[i][j].Work == 10)//Gts加工数据
                    {
                        if (List_Datas[i][j].Lift_flag == 1)//抬刀标志
                        {
                            //关闭激光
                            Program.SystemContainer.RTC_Fun.Close_Laser();
                            //启动Gts运动
                            Program.SystemContainer.GTS_Fun.Integrate_Correct(List_Datas[i]);
                        }
                        else
                        {
                            //关闭激光
                            Program.SystemContainer.RTC_Fun.Close_Laser();
                            //定位到零点
                            Program.SystemContainer.RTC_Fun.Home();
                            //Gts移动到启动位置 上一list数据的结尾数据或本次的结尾或本次序号0的start;待测试
                            Program.SystemContainer.GTS_Fun.Gts_Ready_Correct(List_Datas[i][0].Start_x, List_Datas[i][0].Start_y);
                            //打开激光
                            Program.SystemContainer.RTC_Fun.Open_Laser();
                            //启动Gts运动
                            Program.SystemContainer.GTS_Fun.Integrate_Correct(List_Datas[i]);
                            //关闭激光
                            Program.SystemContainer.RTC_Fun.Close_Laser();
                        }
                    }
                    else if (List_Datas[i][j].Work == 20)//Rtc加工数据
                    {
                        if (List_Datas[i][j].Lift_flag == 1)//抬刀标志
                        {
                            //关闭激光
                            Program.SystemContainer.RTC_Fun.Close_Laser();
                            //Gts移动到准备位置 本次开头
                            Program.SystemContainer.GTS_Fun.Gts_Ready_Correct(List_Datas[i][0].Gts_x, List_Datas[i][0].Gts_y);
#if !DEBUG
                            //启动RTC加工
                            Program.SystemContainer.RTC_Fun.Draw_Jump_Origin(List_Datas[i], 1);
#endif
                        }
                        else
                        {
                            //关闭激光
                            Program.SystemContainer.RTC_Fun.Close_Laser();
                            //Gts移动到准备位置 本次开头
                            Program.SystemContainer.GTS_Fun.Gts_Ready_Correct(List_Datas[i][0].Gts_x, List_Datas[i][0].Gts_y);
#if !DEBUG
                            //启动加工
                            Program.SystemContainer.RTC_Fun.Draw_Mark_Origin(List_Datas[i], 1);
#endif
                            //关闭激光
                            Program.SystemContainer.RTC_Fun.Close_Laser();
                        }
                    }
                    break;
                }
                //退出执行
                if (Exit_Flag)
                {
                    Program.SystemContainer.RTC_Fun.Home();
                    return;
                }
            }
            Program.SystemContainer.RTC_Fun.Home();
        }
    }
}

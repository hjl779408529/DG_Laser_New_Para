using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Management;
using System.IO;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Emgu.Util;
using System.Drawing;
using System.Threading;
using System.Xml.Serialization;
using System.Windows.Forms;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra.Double;
using System.Data;

namespace DG_Laser
{
    public class Calibration 
    {
        //定义退出变量
        public static bool Exit_Flag = false;
        public static event LogErrstring LogErr;
        public static event LogInfo LogInfo;
        /// <summary>
        /// 矫正原点
        /// </summary>
        public static bool Calibrate_Org()
        {
            //建立变量
            Vector Cam = new Vector();
            Vector Coodinate_Point;
            Vector Tem_Mark;
            UInt16 Counting = 0;           

            //矫正原点
            do
            {
                if (Counting == 0)
                {
                    //定位到ORG原点
                    if (!Program.SystemContainer.GTS_Fun.Gts_Point_Go(new Vector(0,0), 0))
                    {
                        MessageBox.Show("平台定位异常，进程终止！！！");
                        return false;
                    }
                }
                else
                {
                    //定位坐标
                    if (!Program.SystemContainer.GTS_Fun.Gts_Point_Go(Program.SystemContainer.SysPara.Cal_Org, 0))
                    {
                        MessageBox.Show("平台定位异常，进程终止！！！");
                        return false;
                    }
                }
                //调用相机，获取对比的坐标信息
                Thread.Sleep(200);//延时200ms

                /***************方式一 矫正后的相机坐标计算****************/
                //Cam = new Vector(Program.SystemContainer.T_Client.Get_Cam_Deviation_Coordinate_Correct(1));//触发拍照 
                //if (Cam.Length == 0)
                //{
                //    MessageBox.Show("相机坐标提取失败，请检查！！！");
                //    return false;
                //}
                ////获取坐标系平台坐标
                //Coodinate_Point = new Vector(Program.SystemContainer.GTS_Fun.Get_Coordinate(0));
                ////计算偏移
                //Tem_Mark = new Vector(Coodinate_Point - Cam);

                /***************方式二 单像素对齐****************/
                Cam = new Vector(Program.SystemContainer.T_Client.Get_Cam_Deviation_Pixel_Correct(Program.SystemContainer.SysPara.Camera_Intrigue_Sequence));//触发拍照 
                if (Cam.Length == 0)
                {
                    MessageBox.Show("相机坐标提取失败，请检查！！！");
                    return false;
                }
                Cam = new Vector(Cam.X - Program.SystemContainer.SysPara.CameraCentreX * Program.SystemContainer.SysPara.Cam_Reference, Cam.Y - Program.SystemContainer.SysPara.CameraCentreY * Program.SystemContainer.SysPara.Cam_Reference);
                //获取坐标系平台坐标
                Coodinate_Point = new Vector(Program.SystemContainer.GTS_Fun.Get_Coordinate(0));
                //计算偏移
                Tem_Mark = new Vector(Coodinate_Point + Cam);

                /***************数据处理****************/
                //反馈回RTC_ORG数据
                Program.SystemContainer.SysPara.Cal_Org = new Vector(Tem_Mark);
                //自增
                Counting++;
                //跳出
                if (Counting >= 10)
                {
                    MessageBox.Show("坐标原点矫正对齐失败！！！");
                    return false;
                }
            } while (!Differ_Deviation(Cam,Program.SystemContainer.SysPara.Pos_Tolerance));
            Program.SystemContainer.SysPara.Work = new Vector(Program.SystemContainer.SysPara.Work.X - Program.SystemContainer.SysPara.Cal_Org.X, Program.SystemContainer.SysPara.Work.Y - Program.SystemContainer.SysPara.Cal_Org.Y);
            return true;
            //数据矫正完成
        }
        
        /// <summary>
        /// 计算偏转参数
        ///
        /// </summary>
        /// <param name="type"></param>
        /// type - 0 初次校准
        /// type - 1 re_cal
        public static Affinity_Matrix Calibrate_Mark(List<Vector> DxfMark,List<Vector> PlatMark)
        {
            //建立变量
            Affinity_Matrix Result = new Affinity_Matrix();
            Vector Cam = new Vector();
            Vector Coodinate_Point;
            Vector Tem_Mark;
            Vector Mark4_dif;
            int Counting = 0;
            //process the mark point
            for (int i = 0; i < PlatMark.Count; i++)
            {
                //矫正Mark           
                Counting = 0;
                do
                {
                    //定位到Mark点
                    Program.SystemContainer.GTS_Fun.Gts_Point_Go(PlatMark[i],1);
                    //调用相机，获取对比的坐标信息
                    Thread.Sleep(200);//延时200ms
                    Cam = new Vector(Program.SystemContainer.T_Client.Get_Cam_Deviation_Coordinate_Correct(Program.SystemContainer.SysPara.Camera_Intrigue_Sequence));//触发拍照 
                    if (Cam.Length == 0)
                    {
                        MessageBox.Show("相机坐标提取失败，请检查！！！");
                        return null;
                    }
                    //获取坐标系平台坐标
                    Coodinate_Point = new Vector(Program.SystemContainer.GTS_Fun.Get_Coordinate(1));
                    //计算偏移
                    Tem_Mark = new Vector(Coodinate_Point - Cam);
                    //反馈回Mark点
                    PlatMark[i] = new Vector(Tem_Mark);
                    //自增
                    Counting++;
                    //跳出
                    if (Counting >= 20)
                    {
                        MessageBox.Show(string.Format("Mark{0} 寻找失败!!!", i + 1));
                        return null;
                    }
                } while (!Differ_Deviation(Cam, Program.SystemContainer.SysPara.Pos_Tolerance));
                //获取理论坐标
                PlatMark[i] = new Vector(Program.SystemContainer.GTS_Fun.Get_Coordinate(1));
            }
            //cal Affinity matrics data 
            Result = new Affinity_Matrix(Gts_Cal_Data_Resolve.Cal_Affinity(DxfMark,PlatMark));

            //有4组Mark点
            if ((DxfMark.Count >= 4) && (PlatMark.Count >= 4))
            {
                //difference mark4 
                Tem_Mark = Gts_Cal_Data_Resolve.Get_Aff_After(DxfMark[3], Result);
                //caluate difference between theory mark4 and actual mark4
                Mark4_dif = new Vector(Tem_Mark - PlatMark[3]);
                //output result
                if (Differ_Deviation(Mark4_dif, Program.SystemContainer.SysPara.Mark_Reference))
                {
                    LogInfo?.Invoke(String.Format("Mark4 验证OK！！！，X坐标偏差：{0}，Y坐标偏差：{1}", Mark4_dif.X, Mark4_dif.Y));
                    MessageBox.Show(String.Format("Mark4 验证OK！！！，X坐标偏差：{0}，Y坐标偏差：{1}", Mark4_dif.X, Mark4_dif.Y));
                    return Result;
                }
                else
                {
                    LogInfo?.Invoke(String.Format("Mark4 验证NG！！！，X坐标偏差：{0}，Y坐标偏差：{1}", Mark4_dif.X, Mark4_dif.Y));
                    MessageBox.Show(String.Format("Mark4 验证NG！！！，X坐标偏差：{0}，Y坐标偏差：{1}", Mark4_dif.X, Mark4_dif.Y));
                    return null;
                }
            }
            //返回
            return Result;
        }
        /// <summary>
        /// 判别误差范围之内
        /// </summary>
        /// <param name="Indata"></param>
        /// <param name="reference"></param>
        /// <returns></returns>
        public static bool Differ_Deviation(Vector Indata,decimal reference)
        {
            if ((Math.Abs(Indata.X)<= reference) && (Math.Abs(Indata.Y) <= reference))
            {
                return true;
            }
            else
            {
                return false;
            }
         }       

        /// <summary>
        /// 矫正 振镜与ORG的距离
        /// </summary>
        public static bool Calibrate_RTC_ORG()
        {
            //建立变量
            Vector Cam = new Vector();
            Vector Coodinate_Point;
            Vector Tem_Mark;
            UInt16 Counting = 0;
            Vector CurrentCoordinate = Program.SystemContainer.SysPara.Debug_Gts_Basis - Program.SystemContainer.SysPara.Rtc_Org;//打标的位置
            Tem_Mark = new Vector(CurrentCoordinate + Program.SystemContainer.SysPara.Rtc_Org);
            //矫正数据
            do
            {
                //定位到ORG矫正点
                if (!Program.SystemContainer.GTS_Fun.Gts_Point_Go(Tem_Mark, 1))
                {
                    MessageBox.Show("平台定位异常，加工终止！！！");
                    return false;
                }
                //调用相机，获取对比的坐标信息
                Thread.Sleep(50);
                Cam = new Vector(Program.SystemContainer.T_Client.Get_Cam_Deviation_Pixel_Correct(Program.SystemContainer.SysPara.Camera_Intrigue_Sequence));//触发拍照 
                if (Cam.Length == 0)
                {
                    MessageBox.Show("相机坐标提取失败，请检查！！！");
                    return false;
                }
                Cam = new Vector(Cam.X - Program.SystemContainer.SysPara.CameraCentreX * Program.SystemContainer.SysPara.Cam_Reference, Cam.Y - Program.SystemContainer.SysPara.CameraCentreY * Program.SystemContainer.SysPara.Cam_Reference);
                //获取坐标系平台坐标
                Coodinate_Point = new Vector(Program.SystemContainer.GTS_Fun.Get_Coordinate(1));
                //计算偏移
                Tem_Mark = new Vector(Coodinate_Point + Cam);                                                                                                                                                                                                                                                                                                                                                                       
                //自增
                Counting++;
                if (Counting>=10)
                {
                    return false;
                }

            } while (!Differ_Deviation(Cam, Program.SystemContainer.SysPara.Pos_Tolerance));
            //获取实际坐标值            
            Coodinate_Point = new Vector(Program.SystemContainer.GTS_Fun.Get_Coordinate(1));//获取坐标系平台坐标
            Tem_Mark = new Vector(Coodinate_Point + Cam);
            Program.SystemContainer.SysPara.Rtc_Org = new Vector(Tem_Mark - CurrentCoordinate);
            //数据矫正完成
            return true;
        }

        /// <summary>
        /// 生成Circle数据 NUM:1 - 1个圆，其他 - 5个圆
        /// </summary>
        /// <param name="Radius"></param>
        /// <param name="Interval"></param>
        /// <param name="Num"></param>
        /// <returns></returns>
        public static Section_Entity_Data CreateMarkData(decimal Radius, decimal Interval,int Num)
        {
            //结果变量
            Section_Entity_Data Result = new Section_Entity_Data();//返回值
            List<Entity_Data> Temp_List_Data = new List<Entity_Data>();//内联数据
            Entity_Data Temp_Data = new Entity_Data();//临时数据
            Vector GtsBasic = Program.SystemContainer.SysPara.Debug_Gts_Basis - Program.SystemContainer.SysPara.Rtc_Org;//基准坐标
            //初始清除
            Temp_List_Data.Clear();
            Temp_Data.Empty();
            //数据写入
            Result.Centre = new Vector(GtsBasic);

            //坐标原点  1号圆
            Temp_Data.Type = 3;
            //Rtc定位 激光加工起点坐标
            Temp_Data.Start_x = Radius;
            Temp_Data.Start_y = 0;
            //RTC 圆弧加工圆心坐标转换
            Temp_Data.Center_x = 0;
            Temp_Data.Center_y = 0;
            //圆半径
            Temp_Data.Circle_radius = Radius;
            //圆方向
            Temp_Data.Circle_dir = 1;
            //圆弧角度
            Temp_Data.Angle = 370;
            //追加数据
            Temp_List_Data.Add(new  Entity_Data(Temp_Data));
           
            if (Num == 1)
            {
                Result.Circle = new List<Entity_Data>(Temp_List_Data);
                return Result;
            }

            //坐标原点  2号圆
            Temp_Data.Type = 3;
            //起点坐标
            Temp_Data.Start_x = Radius;
            Temp_Data.Start_y = Interval;
            //RTC 圆弧加工圆心坐标转换
            Temp_Data.Center_x = 0;
            Temp_Data.Center_y = Interval;
            //圆弧角度
            Temp_Data.Angle = 370;
            //追加数据
            Temp_List_Data.Add(new Entity_Data(Temp_Data));

            //坐标原点  3号圆
            Temp_Data.Type = 3;
            //起点坐标
            Temp_Data.Start_x = Radius + Interval;
            Temp_Data.Start_y = 0;
            //RTC 圆弧加工圆心坐标转换
            Temp_Data.Center_x = Interval;
            Temp_Data.Center_y = 0;
            //圆半径
            Temp_Data.Circle_radius = Radius;
            //圆方向
            Temp_Data.Circle_dir = 1;
            //圆弧角度
            Temp_Data.Angle = 370;
            //追加数据
            Temp_List_Data.Add(new Entity_Data(Temp_Data));

            //坐标原点  4号圆
            Temp_Data.Type = 3;
            //起点坐标
            Temp_Data.Start_x = Radius;
            Temp_Data.Start_y = -Interval;
            //RTC 圆弧加工圆心坐标转换
            Temp_Data.Center_x = 0;
            Temp_Data.Center_y = -Interval;
            //圆半径
            Temp_Data.Circle_radius = Radius;
            //圆方向
            Temp_Data.Circle_dir = 1;
            //圆弧角度
            Temp_Data.Angle = 370;
            //追加数据
            Temp_List_Data.Add(new Entity_Data(Temp_Data));

            //坐标原点  5号圆
            Temp_Data.Type = 3;
            //起点坐标
            Temp_Data.Start_x = -Interval + Radius;
            Temp_Data.Start_y = 0;
            //RTC 圆弧加工圆心坐标转换
            Temp_Data.Center_x = -Interval;
            Temp_Data.Center_y = 0;
            //圆半径
            Temp_Data.Circle_radius = Radius;
            //圆方向
            Temp_Data.Circle_dir = 1;
            //圆弧角度
            Temp_Data.Angle = 370;
            //追加修改的数据
            //追加数据
            Temp_List_Data.Add(new Entity_Data(Temp_Data));

            //返回结果
            return Result;
        }
        
        /**************校准相机坐标系 打标**********************/
        ///校准相机像素与物理距离的对应关系
        ///相机坐标系以相片中心为原点
        ///对应物理坐标系的坐标点
        ///实现像素与坐标的转换
        ///使用烧灼Mark点进行校准
        public static bool Cal_Cam_Affinity()
        {
            //建立变量
            Affinity_Matrix Result = new Affinity_Matrix();
            //定义仿射变换数组 
            Mat mat = new Mat(new Size(3, 2), Emgu.CV.CvEnum.DepthType.Cv32F, 1); //2行 3列 的矩阵
            //定义点位数组
            PointF[] srcTri = new PointF[3];//标准数据
            PointF[] dstTri = new PointF[3];//差异化数据 
            double[] temp_array;
            //定位点位计算标定板偏差
            Vector[] Cali_Mark_Src = new Vector[3] { new Vector(0, 0), new Vector(0, 2.0m), new Vector(1.5m, 0) };
            Vector[] Cali_Mark_Dst = new Vector[3] { new Vector(0, 0), new Vector(0, 2.0m), new Vector(1.5m, 0) };

            //矫正坐标中心对齐
            Vector CurrenPoint = Program.SystemContainer.SysPara.Debug_Gts_Basis - Program.SystemContainer.SysPara.Rtc_Org;
            Vector GtsBasic = CurrenPoint + Program.SystemContainer.SysPara.Rtc_Org;//基准坐标
            Vector Cam = new Vector();
            Vector Coodinate_Point;
            Vector Tem_Mark;
            UInt16 Counting = 0;
            //相对位移标定相机坐标系
            for (int i =0;i< Cali_Mark_Src.Length;i++)
            {
                Counting = 0;
                if (i==0)
                {
                    Tem_Mark = new Vector(Cali_Mark_Src[i] + GtsBasic);
                    do
                    {
                        //定位矫正点
                        if (!Program.SystemContainer.GTS_Fun.Gts_Point_Go(Tem_Mark, 0))
                        {
                            MessageBox.Show("平台定位异常，进程终止！！！");
                            return false;
                        }
                        //调用相机，获取对比的坐标信息
                        Thread.Sleep(100);
                        Cam = new Vector(Program.SystemContainer.T_Client.Get_Cam_Deviation_Pixel_Correct(Program.SystemContainer.SysPara.Camera_Intrigue_Sequence));//触发拍照 
                        if (Cam.Length == 0)
                        {
                            MessageBox.Show("相机坐标提取失败，请检查！！！");
                            return false;
                        }
                        Cam = new Vector(Cam.X - Program.SystemContainer.SysPara.CameraCentreX * Program.SystemContainer.SysPara.Cam_Reference, Cam.Y - Program.SystemContainer.SysPara.CameraCentreY * Program.SystemContainer.SysPara.Cam_Reference);
                        //获取坐标系平台坐标
                        Coodinate_Point = new Vector(Program.SystemContainer.GTS_Fun.Get_Coordinate(0));
                        //计算偏移
                        Tem_Mark = new Vector(Coodinate_Point + Cam);
                        //自增
                        Counting++;
                        if (Counting >= 10)
                        {
                            MessageBox.Show("相机坐标系中心对齐失败！！！");
                            return false;
                        }
                    } while (!Differ_Deviation(Cam, Program.SystemContainer.SysPara.Pos_Tolerance));
                    //获取坐标对齐mark的像素坐标
                    Thread.Sleep(200);
                    Cam = new Vector(Program.SystemContainer.T_Client.Get_Cam_Actual_Pixel(Program.SystemContainer.SysPara.Camera_Intrigue_Sequence));//触发拍照 
                    if (Cam.Length == 0)
                    {
                        MessageBox.Show("相机坐标提取失败，请检查！！！");
                        return false;
                    }
                    //反馈回相机实际坐标
                    Cali_Mark_Src[i] = new Vector(Cam);
                }
                else
                {
                    Tem_Mark = new Vector(new Vector(0,0) + GtsBasic);
                    do
                    {
                        //定位矫正点
                        if (!Program.SystemContainer.GTS_Fun.Gts_Point_Go(Tem_Mark, 0))
                        {
                            MessageBox.Show("平台定位异常，进程终止！！！");
                            return false;
                        }
                        //调用相机，获取对比的坐标信息
                        Thread.Sleep(100);
                        Cam = new Vector(Program.SystemContainer.T_Client.Get_Cam_Deviation_Pixel_Correct(Program.SystemContainer.SysPara.Camera_Intrigue_Sequence));//触发拍照 
                        if (Cam.Length == 0)
                        {
                            MessageBox.Show("相机坐标提取失败，请检查！！！");
                            return false;
                        }
                        Cam = new Vector(Cam.X - Program.SystemContainer.SysPara.CameraCentreX * Program.SystemContainer.SysPara.Cam_Reference, Cam.Y - Program.SystemContainer.SysPara.CameraCentreY * Program.SystemContainer.SysPara.Cam_Reference);
                        //获取坐标系平台坐标
                        Coodinate_Point = new Vector(Program.SystemContainer.GTS_Fun.Get_Coordinate(0));
                        //计算偏移
                        Tem_Mark = new Vector(Coodinate_Point + Cam);
                        //自增
                        Counting++;
                        if (Counting >= 10)
                        {
                            MessageBox.Show("相机坐标系中心对齐失败！！！");
                            return false;
                        }
                    } while (!Differ_Deviation(Cam, Program.SystemContainer.SysPara.Pos_Tolerance));
                    //以当前位置进行位移
                    Coodinate_Point = new Vector(Program.SystemContainer.GTS_Fun.Get_Coordinate(0));
                    Tem_Mark = new Vector(Coodinate_Point + Cali_Mark_Src[i]);
                    //定位
                    if (!Program.SystemContainer.GTS_Fun.Gts_Point_Go(Tem_Mark, 0))
                    {
                        MessageBox.Show("平台定位异常，进程终止！！！");
                        return false;
                    }
                    //调用相机，获取对比的坐标信息
                    Thread.Sleep(200);
                    Cam = new Vector(Program.SystemContainer.T_Client.Get_Cam_Actual_Pixel(Program.SystemContainer.SysPara.Camera_Intrigue_Sequence));//触发拍照 
                    if (Cam.Length == 0)
                    {
                        MessageBox.Show("相机坐标提取失败，请检查！！！");
                        return false;
                    }
                    //反馈回相机实际坐标
                    Cali_Mark_Src[i] = new Vector(Cam);
                }     
            }
            //数据提取
            //标准数据
            srcTri[0] = new PointF((float)(Cali_Mark_Src[0].X), (float)(Cali_Mark_Src[0].Y));
            srcTri[1] = new PointF((float)(Cali_Mark_Src[1].X), (float)(Cali_Mark_Src[1].Y));
            srcTri[2] = new PointF((float)(Cali_Mark_Src[2].X), (float)(Cali_Mark_Src[2].Y));
            //仿射数据
            dstTri[0] = new PointF((float)(Cali_Mark_Dst[0].X), (float)(Cali_Mark_Dst[0].Y));
            dstTri[1] = new PointF((float)(Cali_Mark_Dst[1].X), (float)(Cali_Mark_Dst[1].Y));
            dstTri[2] = new PointF((float)(Cali_Mark_Dst[2].X), (float)(Cali_Mark_Dst[2].Y));
            //计算仿射变换矩阵
            mat = CvInvoke.GetAffineTransform(srcTri, dstTri);
            //提取矩阵数据
            temp_array = mat.GetDoubleArray();
            //获取仿射变换参数
            Result = Gts_Cal_Data_Resolve.Array_To_Affinity(temp_array);
            Program.SystemContainer.SysPara.Cam_Trans_Affinity = new Affinity_Matrix(Result);
            return true;
        }
        /**************校准相机坐标系 标定板**********************/
        ///校准相机像素与物理距离的对应关系
        ///相机坐标系以相片中心为原点
        ///对应物理坐标系的坐标点
        ///实现像素与坐标的转换
        ///使用标定板原点进行校准
        public static bool Cal_Cam_Affinity_By_Board()
        {
            //建立变量
            Affinity_Matrix Result = new Affinity_Matrix();
            //定义仿射变换数组 
            Mat mat = new Mat(new Size(3, 2), Emgu.CV.CvEnum.DepthType.Cv32F, 1); //2行 3列 的矩阵
            //定义点位数组
            PointF[] srcTri = new PointF[3];//标准数据
            PointF[] dstTri = new PointF[3];//差异化数据 
            double[] temp_array;
            //定位点位计算标定板偏差
            Vector[] Cali_Mark_Src = new Vector[3] { new Vector(0, 0), new Vector(0, 2.0m), new Vector(1.5m, 0) };
            Vector[] Cali_Mark_Dst = new Vector[3] { new Vector(0, 0), new Vector(0, 2.0m), new Vector(1.5m, 0) };

            //矫正坐标中心对齐
            Vector Cam = new Vector();
            Vector Coodinate_Point;
            Vector Tem_Mark;
            UInt16 Counting = 0;
            //相对位移标定相机坐标系
            for (int i = 0; i < Cali_Mark_Src.Length; i++)
            {
                Counting = 0;
                Tem_Mark = new Vector(0,0);
                //对齐坐标原点
                do
                {
                    //定位矫正点
                    if (!Program.SystemContainer.GTS_Fun.Gts_Point_Go(Tem_Mark, 0))
                    {
                        MessageBox.Show("平台定位异常，进程终止！！！");
                        return false;
                    }
                    //调用相机，获取对比的坐标信息
                    Thread.Sleep(1000);
                    Cam = new Vector(Program.SystemContainer.T_Client.Get_Cam_Deviation_Pixel_Correct(Program.SystemContainer.SysPara.Camera_Intrigue_Sequence));//触发拍照 
                    if (Cam.Length == 0)
                    {
                        MessageBox.Show("相机坐标提取失败，请检查！！！");
                        return false;
                    }
                    Cam = new Vector(Cam.X - Program.SystemContainer.SysPara.CameraCentreX * Program.SystemContainer.SysPara.Cam_Reference, Cam.Y - Program.SystemContainer.SysPara.CameraCentreY * Program.SystemContainer.SysPara.Cam_Reference);
                    //获取坐标系平台坐标
                    Coodinate_Point = new Vector(Program.SystemContainer.GTS_Fun.Get_Coordinate(0));
                    //计算偏移
                    Tem_Mark = new Vector(Coodinate_Point + Cam);
                    //自增
                    Counting++;
                    if (Counting >= 10)
                    {
                        MessageBox.Show("相机坐标系中心对齐失败！！！");
                        return false;
                    }
                } while (!Differ_Deviation(Cam, Program.SystemContainer.SysPara.Pos_Tolerance));
                //定位具体坐标
                Tem_Mark = new Vector(Cali_Mark_Src[i]);                
                //定位坐标
                if (!Program.SystemContainer.GTS_Fun.Gts_Point_Go(Cali_Mark_Src[i], 0))
                {
                    MessageBox.Show("平台定位异常，进程终止！！！");
                    return false;
                }
                //调用相机，获取对比的坐标信息
                Thread.Sleep(500);
                Cam = new Vector(Program.SystemContainer.T_Client.Get_Cam_Actual_Pixel(Program.SystemContainer.SysPara.Camera_Intrigue_Sequence));//触发拍照 
                if (Cam.Length == 0)
                {
                    MessageBox.Show("相机坐标提取失败，请检查！！！");
                    return false;
                }
                //反馈回相机实际坐标
                Cali_Mark_Src[i] = new Vector(Cam);
            }

            //数据提取
            //标准数据
            srcTri[0] = new PointF((float)(Cali_Mark_Src[0].X), (float)(Cali_Mark_Src[0].Y));
            srcTri[1] = new PointF((float)(Cali_Mark_Src[1].X), (float)(Cali_Mark_Src[1].Y));
            srcTri[2] = new PointF((float)(Cali_Mark_Src[2].X), (float)(Cali_Mark_Src[2].Y));
            //仿射数据
            dstTri[0] = new PointF((float)(Cali_Mark_Dst[0].X), (float)(Cali_Mark_Dst[0].Y));
            dstTri[1] = new PointF((float)(Cali_Mark_Dst[1].X), (float)(Cali_Mark_Dst[1].Y));
            dstTri[2] = new PointF((float)(Cali_Mark_Dst[2].X), (float)(Cali_Mark_Dst[2].Y));
            //计算仿射变换矩阵
            mat = CvInvoke.GetAffineTransform(srcTri, dstTri);
            //提取矩阵数据
            temp_array = mat.GetDoubleArray();
            //获取仿射变换参数
            Result = Gts_Cal_Data_Resolve.Array_To_Affinity(temp_array);
            Program.SystemContainer.SysPara.Cam_Trans_Affinity = new Affinity_Matrix(Result);
            return true;
        }

        /// <summary>
        /// 计算振镜坐标系与平台坐标系的夹角或仿射变换参数
        /// </summary>
        public static bool Get_Rtc_Coordinate_Affinity(decimal Radius, decimal Interval)
        {
            //数据采集
            DataTable Calibration_Data_Acquisition = new DataTable();
            Calibration_Data_Acquisition.Columns.Add("振镜X坐标", typeof(decimal));
            Calibration_Data_Acquisition.Columns.Add("振镜Y坐标", typeof(decimal));
            Calibration_Data_Acquisition.Columns.Add("平台X坐标", typeof(decimal));
            Calibration_Data_Acquisition.Columns.Add("平台Y坐标", typeof(decimal));
            Calibration_Data_Acquisition.Columns.Add("X轴旋转角度", typeof(decimal));
            Calibration_Data_Acquisition.Columns.Add("Y轴旋转角度", typeof(decimal));
            Calibration_Data_Acquisition.Columns.Add("相机X坐标", typeof(decimal));
            Calibration_Data_Acquisition.Columns.Add("相机Y坐标", typeof(decimal));
            //建立变量
            Affinity_Matrix Result = new Affinity_Matrix();
            //定义仿射变换数组 
            Mat mat = new Mat(new Size(3, 2), Emgu.CV.CvEnum.DepthType.Cv32F, 1); //2行 3列 的矩阵
            //定义点位数组
            PointF[] srcTri = new PointF[5];//标准数据
            PointF[] dstTri = new PointF[5];//差异化数据
            //定位点位初始化
            Vector[] Cali_Mark_Src = new Vector[5] { new Vector(0, 0), new Vector(Interval, 0), new Vector(0, Interval), new Vector(0, -Interval), new Vector(-Interval, 0) };
            Vector[] Cali_Mark_Dst = new Vector[5] { new Vector(0, 0), new Vector(Interval, 0), new Vector(0, Interval), new Vector(0, -Interval), new Vector(-Interval, 0) };
            Vector CurrenPoint = Program.SystemContainer.SysPara.Debug_Gts_Basis - Program.SystemContainer.SysPara.Rtc_Org;
            Vector Gts_Point = CurrenPoint + Program.SystemContainer.SysPara.Rtc_Org;
            //Dst定位点处理
            for (int i = 0;i< Cali_Mark_Dst.Length;i++)
            {
                Cali_Mark_Dst[i] = new Vector(Gts_Point + Cali_Mark_Dst[i]);
            }
            //仿射变换数组
            double[] temp_array;
            Vector Cam = new Vector();
            Vector Tem_Mark = new Vector();
            Vector Coordinate = new Vector();
            UInt16 Counting = 0;            

            //标定板数据计算
            for (int i = 0; i < Cali_Mark_Dst.Length; i++)
            {
                do
                {
                    //定位到标定板数据实际点位i
                    if (!Program.SystemContainer.GTS_Fun.Gts_Point_Go(Cali_Mark_Dst[i], 1))
                    {
                        MessageBox.Show("平台定位异常，进程终止！！！");
                        return false;
                    }
                    //调用相机，获取对比的坐标信息
                    Thread.Sleep(500);//延时200ms
                    Cam = new Vector(Program.SystemContainer.T_Client.Get_Cam_Deviation_Coordinate_Correct(Program.SystemContainer.SysPara.Camera_Intrigue_Sequence));//触发拍照 
                    if (Cam.Length == 0)
                    {
                        MessageBox.Show("相机坐标提取失败，请检查！！！");
                        return false;
                    }
                    Coordinate = Program.SystemContainer.GTS_Fun.Get_Coordinate(1);
                    Tem_Mark = new Vector(Coordinate - Cam);//计算偏移
                    Cali_Mark_Dst[i] = new Vector(Tem_Mark);//反馈回标定板数据实际点位                                                            
                    Counting++;//自增
                    if (Counting >= 30)
                    {
                        MessageBox.Show("超出重试次数！！！");
                        return false;
                    }
                } while (!Differ_Deviation(Cam, Program.SystemContainer.SysPara.Pos_Tolerance));            
                //获取实际坐标值
                Cali_Mark_Dst[i] = Program.SystemContainer.GTS_Fun.Get_Coordinate(1);
                //数据保存
                Calibration_Data_Acquisition.Rows.Add(new object[] { Cali_Mark_Src[i].X, Cali_Mark_Src[i].Y, Cali_Mark_Dst[i].X, Cali_Mark_Dst[i].Y,Cam.X,Cam.Y});
            }
            //以原点为基准处理Dst点位
            Vector Cal_Standard = new Vector(Gts_Point);
            for (int i = 0; i < Cali_Mark_Dst.Length; i++)
            {
                Cali_Mark_Dst[i] = new Vector(Cali_Mark_Dst[i] - Cal_Standard);
            }
            //数据提取
            //标准数据  实测值
            srcTri[0] = new PointF((float)(Cali_Mark_Dst[0].X), (float)(Cali_Mark_Dst[0].Y));
            srcTri[1] = new PointF((float)(Cali_Mark_Dst[1].X), (float)(Cali_Mark_Dst[1].Y));
            srcTri[2] = new PointF((float)(Cali_Mark_Dst[2].X), (float)(Cali_Mark_Dst[2].Y));
            srcTri[3] = new PointF((float)(Cali_Mark_Dst[3].X), (float)(Cali_Mark_Dst[3].Y));
            srcTri[4] = new PointF((float)(Cali_Mark_Dst[4].X), (float)(Cali_Mark_Dst[4].Y));
            //仿射数据  振镜输出值
            dstTri[0] = new PointF((float)(Cali_Mark_Src[0].X), (float)(Cali_Mark_Src[0].Y));
            dstTri[1] = new PointF((float)(Cali_Mark_Src[1].X), (float)(Cali_Mark_Src[1].Y));
            dstTri[2] = new PointF((float)(Cali_Mark_Src[2].X), (float)(Cali_Mark_Src[2].Y));
            dstTri[3] = new PointF((float)(Cali_Mark_Src[3].X), (float)(Cali_Mark_Src[3].Y));
            srcTri[4] = new PointF((float)(Cali_Mark_Dst[4].X), (float)(Cali_Mark_Dst[4].Y));
            
            //计算仿射变换矩阵
            mat = CvInvoke.GetAffineTransform(srcTri, dstTri);
            //提取矩阵数据
            temp_array = mat.GetDoubleArray();
            //获取仿射变换参数
            Result = Gts_Cal_Data_Resolve.Array_To_Affinity(temp_array);
            Program.SystemContainer.SysPara.Rtc_Trans_Affinity = new Affinity_Matrix(Result);
            //计算角度
            //Affinity_Matrix Temp_para = new Affinity_Matrix();
            //Temp_para.Stretch_X = Cali_Mark_Dst[1].X/ Cali_Mark_Dst[1].Length;
            //Temp_para.Distortion_X = Cali_Mark_Dst[1].Y/ Cali_Mark_Dst[1].Length;
            //Temp_para.Stretch_Y = Cali_Mark_Dst[2].Y/ Cali_Mark_Dst[2].Length;
            //Temp_para.Distortion_Y = Cali_Mark_Dst[2].X/ Cali_Mark_Dst[2].Length;
            //Program.SystemContainer.SysPara.Rtc_Trans_Angle = new Affinity_Matrix(Temp_para);
            //数据保存
            CSV_RW.SaveCSV(Calibration_Data_Acquisition, "Rtc_Cor_Data_Acquisition");
            return true;
        }


        
        /// <summary>
        /// 生成振镜矫正数据圆 - 0，或直线 - 1
        /// </summary>
        /// <param name="Type"></param>
        /// <param name="Radius"></param>
        /// <param name="Interval"></param>
        /// <param name="Limit"></param>
        /// <returns></returns>
        public static List<Section_Entity_Data> Create_Rtc_Calibrate_Data(ushort Type, decimal Radius, decimal XInterval, decimal YInterval, decimal LimitX,decimal LimitY)
        {
            //结果变量
            List<Section_Entity_Data> Result = new List<Section_Entity_Data>();//返回值
            List<Entity_Data> Temp_List_Data = new  List<Entity_Data>();//打标圆数据
            Entity_Data Temp_Entity_Data = new Entity_Data();//单数据
            Section_Entity_Data Temp_Section_Data = new  Section_Entity_Data();//分层数据 
            Vector Centre = Program.SystemContainer.SysPara.Debug_Gts_Basis - Program.SystemContainer.SysPara.Rtc_Org;
            //初始清除
            Result.Clear();
            Temp_List_Data.Clear();
            Temp_Entity_Data.Empty();
            //计算总间距
            Int16 XNo = (Int16)(LimitX / XInterval);
            Int16 YNo = (Int16)(LimitY / YInterval);
            //圆数据
            if (Type == 0)
            {
                for (int i = -YNo / 2; i <= YNo / 2; i++)//Y坐标
                {
                    Temp_Section_Data = new Section_Entity_Data();
                    Temp_Section_Data.Centre = new Vector(Centre);//中心坐标
                    for (int j = -XNo / 2; j <= XNo / 2; j++)//X坐标
                    {
                        //数据清空
                        Temp_Entity_Data.Empty();
                        //加工类型为整圆
                        Temp_Entity_Data.Type = 3;
                        //加工起点坐标
                        Temp_Entity_Data.Start_x = j * XInterval + Radius;
                        Temp_Entity_Data.Start_y = -i * YInterval;
                        //加工终点坐标
                        Temp_Entity_Data.End_x = j * XInterval + Radius;
                        Temp_Entity_Data.End_y = -i * YInterval;
                        //圆半径
                        Temp_Entity_Data.Circle_radius = Radius;
                        //圆方向
                        Temp_Entity_Data.Circle_dir = 1;
                        //圆心坐标转换
                        Temp_Entity_Data.Center_x = j * XInterval;
                        Temp_Entity_Data.Center_y = -i * YInterval;
                        //圆弧角度
                        Temp_Entity_Data.Angle = 370;
                        //追加修改的数据
                        Temp_List_Data.Add(new Entity_Data(Temp_Entity_Data));
                    }
                    Temp_Section_Data.Circle = new List<Entity_Data>(Temp_List_Data);
                    Result.Add(new Section_Entity_Data(Temp_Section_Data));
                    Temp_List_Data.Clear();
                }
            }
            else//其他直线
            {
                //行数据
                Temp_Section_Data = new Section_Entity_Data();
                Temp_Section_Data.Centre = new Vector(Centre);//中心坐标
                //行数据 起点X不变，Y步进
                for (int i = -YNo / 2; i <= YNo / 2; i++)
                {
                    //数据清空
                    Temp_Entity_Data.Empty();
                    //加工类型为直线
                    Temp_Entity_Data.Type = 1;
                    //加工起点坐标
                    Temp_Entity_Data.Start_x = -LimitX / 2M;
                    Temp_Entity_Data.Start_y = -YInterval * i;
                    //加工终点坐标
                    Temp_Entity_Data.End_x = LimitX / 2M;
                    Temp_Entity_Data.End_y = -YInterval * i;
                    //追加修改的数据
                    Temp_List_Data.Add(new Entity_Data(Temp_Entity_Data));
                }
                Temp_Section_Data.ArcLine.Add(new List<Entity_Data>(Temp_List_Data));
                Result.Add(new Section_Entity_Data(Temp_Section_Data));
                Temp_List_Data.Clear();
                //列数据
                Temp_Section_Data = new Section_Entity_Data();
                Temp_Section_Data.Centre = new Vector(Centre);//中心坐标

                //列数据 起点Y不变，X变化
                for (int i = -XNo / 2; i <= XNo / 2; i++)
                {
                    //数据清空
                    Temp_Entity_Data.Empty();
                    //加工类型为直线
                    Temp_Entity_Data.Type = 1;
                    //Rtc定位 激光加工起点坐标
                    Temp_Entity_Data.Start_x = XInterval * i;
                    Temp_Entity_Data.Start_y = LimitY / 2M;
                    //坐标转换 将坐标转换为RTC坐标系坐标
                    Temp_Entity_Data.End_x = XInterval * i;
                    Temp_Entity_Data.End_y = -LimitY / 2M;
                    //追加修改的数据
                    Temp_List_Data.Add(new Entity_Data(Temp_Entity_Data));
                }
                Temp_Section_Data.ArcLine.Add(new List<Entity_Data>(Temp_List_Data));
                Result.Add(new Section_Entity_Data(Temp_Section_Data));
                Temp_List_Data.Clear();
            }
            //返回结果
            return Result;
        }


    }
    //GTS校准数据处理 
    class Gts_Cal_Data_Resolve
    {        
        /// <summary>
        /// 处理相机与轴的数据，生成仿射变换数组，并保存进入文件
        /// </summary>
        /// <param name="correct_Datas"></param>
        /// <returns></returns>
        public static List<Affinity_Matrix> Resolve(List<Correct_Data> correct_Datas)
        {
            //建立变量
            List<Affinity_Matrix> Result = new List<Affinity_Matrix>();
            Affinity_Matrix Temp_Affinity_Matrix = new Affinity_Matrix();
            Int16 i, j;
            //定义仿射变换数组 
            Mat mat = new Mat(new Size(3, 2), Emgu.CV.CvEnum.DepthType.Cv32F, 1); //2行 3列 的矩阵
            //定义仿射变换矩阵转换数组
            double[] temp_array;
            //数据处理
            if (Program.SystemContainer.SysPara.Gts_Calibration_Col_X * Program.SystemContainer.SysPara.Gts_Calibration_Row_Y == correct_Datas.Count)//矫正和差异数据完整
            {
                //定义点位数组 
                PointF[] srcTri = new PointF[Program.SystemContainer.SysPara.Gts_Calibration_Method];//标准数据
                PointF[] dstTri = new PointF[Program.SystemContainer.SysPara.Gts_Calibration_Method];//差异化数据
                //数据处理
                for (i = 0; i < Program.SystemContainer.SysPara.Gts_Calibration_Col_X - 1; i++)//决定哪一行 Y
                {
                    for (j = 0; j < Program.SystemContainer.SysPara.Gts_Calibration_Row_Y - 1; j++)//决定哪一列 X
                    {
                        switch (Program.SystemContainer.SysPara.Gts_Calibration_Method)
                        {
                            case 3:
                                //标准数据  平台坐标
                                srcTri[0] = new PointF((float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Gts_Calibration_Col_X].Xo), (float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Gts_Calibration_Col_X].Yo));
                                srcTri[1] = new PointF((float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Gts_Calibration_Col_X + Program.SystemContainer.SysPara.Gts_Calibration_Row_Y].Xo), (float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Gts_Calibration_Col_X + Program.SystemContainer.SysPara.Gts_Calibration_Row_Y].Yo));
                                srcTri[2] = new PointF((float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Gts_Calibration_Col_X + Program.SystemContainer.SysPara.Gts_Calibration_Row_Y + 1].Xo), (float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Gts_Calibration_Col_X + Program.SystemContainer.SysPara.Gts_Calibration_Row_Y + 1].Yo));
                               
                                //仿射数据  测量坐标
                                dstTri[0] = new PointF((float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Gts_Calibration_Col_X].Xm), (float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Gts_Calibration_Col_X].Ym));
                                dstTri[1] = new PointF((float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Gts_Calibration_Col_X + Program.SystemContainer.SysPara.Gts_Calibration_Row_Y].Xm), (float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Gts_Calibration_Col_X + Program.SystemContainer.SysPara.Gts_Calibration_Row_Y].Ym));
                                dstTri[2] = new PointF((float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Gts_Calibration_Col_X + Program.SystemContainer.SysPara.Gts_Calibration_Row_Y + 1].Xm), (float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Gts_Calibration_Col_X + Program.SystemContainer.SysPara.Gts_Calibration_Row_Y + 1].Ym));
                                
                                break;
                            case 4:
                                //标准数据  平台坐标
                                srcTri[0] = new PointF((float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Gts_Calibration_Col_X].Xo), (float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Gts_Calibration_Col_X].Yo));
                                srcTri[1] = new PointF((float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Gts_Calibration_Col_X + Program.SystemContainer.SysPara.Gts_Calibration_Row_Y].Xo), (float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Gts_Calibration_Col_X + Program.SystemContainer.SysPara.Gts_Calibration_Row_Y].Yo));
                                srcTri[2] = new PointF((float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Gts_Calibration_Col_X + Program.SystemContainer.SysPara.Gts_Calibration_Row_Y + 1].Xo), (float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Gts_Calibration_Col_X + Program.SystemContainer.SysPara.Gts_Calibration_Row_Y + 1].Yo));
                                srcTri[3] = new PointF((float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Gts_Calibration_Col_X + 1].Xm), (float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Gts_Calibration_Col_X + 1].Ym));

                                //仿射数据  测量坐标
                                dstTri[0] = new PointF((float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Gts_Calibration_Col_X].Xm), (float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Gts_Calibration_Col_X].Ym));
                                dstTri[1] = new PointF((float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Gts_Calibration_Col_X + Program.SystemContainer.SysPara.Gts_Calibration_Row_Y].Xm), (float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Gts_Calibration_Col_X + Program.SystemContainer.SysPara.Gts_Calibration_Row_Y].Ym));
                                dstTri[2] = new PointF((float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Gts_Calibration_Col_X + Program.SystemContainer.SysPara.Gts_Calibration_Row_Y + 1].Xm), (float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Gts_Calibration_Col_X + Program.SystemContainer.SysPara.Gts_Calibration_Row_Y + 1].Ym));
                                dstTri[3] = new PointF((float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Gts_Calibration_Col_X + 1].Xo), (float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Gts_Calibration_Col_X + 1].Yo));

                                break;
                            default:
                                break;
                        }
                       

                        //计算仿射变换矩阵
                        mat = CvInvoke.GetAffineTransform(srcTri, dstTri);
                        //mat = CvInvoke.EstimateRigidTransform(srcTri, dstTri, false);
                        //提取矩阵数据
                        temp_array = mat.GetDoubleArray();
                        //获取仿射变换参数
                        Temp_Affinity_Matrix = Array_To_Affinity(temp_array);
                        //追加进入仿射变换List
                        Result.Add(new Affinity_Matrix(Temp_Affinity_Matrix));
                        //清除变量
                        Temp_Affinity_Matrix = new Affinity_Matrix();
                    }
                }
                //保存为文件
                Serialize_Data.Serialize_Affinity_Matrix(Result, "Gts_Affinity_Matrix_Three.xml");
            }
            return Result;
        }

        /// <summary>
        /// 处理相机与轴的数据，生成仿射变换数组，并保存进入文件
        /// </summary>
        /// <param name="correct_Datas"></param>
        /// <returns></returns>
        public static List<Affinity_Matrix> Resolve(List<Correct_Data> correct_Datas, string FileName)
        {
            //建立变量
            List<Affinity_Matrix> Result = new List<Affinity_Matrix>();
            Affinity_Matrix Temp_Affinity_Matrix = new Affinity_Matrix();
            Int16 i, j;
            //定义仿射变换数组 
            Mat mat = new Mat(new Size(3, 2), Emgu.CV.CvEnum.DepthType.Cv32F, 1); //2行 3列 的矩阵
            //定义仿射变换矩阵转换数组
            double[] temp_array;
            //数据处理
            if (Program.SystemContainer.SysPara.Gts_Calibration_Col_X * Program.SystemContainer.SysPara.Gts_Calibration_Row_Y == correct_Datas.Count)//矫正和差异数据完整
            {
                //定义点位数组 
                PointF[] srcTri = new PointF[Program.SystemContainer.SysPara.Gts_Calibration_Method];//标准数据
                PointF[] dstTri = new PointF[Program.SystemContainer.SysPara.Gts_Calibration_Method];//差异化数据
                //数据处理
                for (i = 0; i < Program.SystemContainer.SysPara.Gts_Calibration_Col_X - 1; i++)//决定哪一行 Y
                {
                    for (j = 0; j < Program.SystemContainer.SysPara.Gts_Calibration_Row_Y - 1; j++)//决定哪一列 X
                    {

                        switch (Program.SystemContainer.SysPara.Gts_Calibration_Method)
                        {
                            case 3:
                                //标准数据  平台坐标
                                srcTri[0] = new PointF((float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Gts_Calibration_Col_X].Xo), (float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Gts_Calibration_Col_X].Yo));
                                srcTri[1] = new PointF((float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Gts_Calibration_Col_X + Program.SystemContainer.SysPara.Gts_Calibration_Row_Y].Xo), (float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Gts_Calibration_Col_X + Program.SystemContainer.SysPara.Gts_Calibration_Row_Y].Yo));
                                srcTri[2] = new PointF((float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Gts_Calibration_Col_X + Program.SystemContainer.SysPara.Gts_Calibration_Row_Y + 1].Xo), (float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Gts_Calibration_Col_X + Program.SystemContainer.SysPara.Gts_Calibration_Row_Y + 1].Yo));

                                //仿射数据  测量坐标
                                dstTri[0] = new PointF((float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Gts_Calibration_Col_X].Xm), (float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Gts_Calibration_Col_X].Ym));
                                dstTri[1] = new PointF((float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Gts_Calibration_Col_X + Program.SystemContainer.SysPara.Gts_Calibration_Row_Y].Xm), (float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Gts_Calibration_Col_X + Program.SystemContainer.SysPara.Gts_Calibration_Row_Y].Ym));
                                dstTri[2] = new PointF((float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Gts_Calibration_Col_X + Program.SystemContainer.SysPara.Gts_Calibration_Row_Y + 1].Xm), (float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Gts_Calibration_Col_X + Program.SystemContainer.SysPara.Gts_Calibration_Row_Y + 1].Ym));

                                break;
                            case 4:
                                //标准数据  平台坐标
                                srcTri[0] = new PointF((float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Gts_Calibration_Col_X].Xo), (float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Gts_Calibration_Col_X].Yo));
                                srcTri[1] = new PointF((float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Gts_Calibration_Col_X + Program.SystemContainer.SysPara.Gts_Calibration_Row_Y].Xo), (float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Gts_Calibration_Col_X + Program.SystemContainer.SysPara.Gts_Calibration_Row_Y].Yo));
                                srcTri[2] = new PointF((float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Gts_Calibration_Col_X + Program.SystemContainer.SysPara.Gts_Calibration_Row_Y + 1].Xo), (float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Gts_Calibration_Col_X + Program.SystemContainer.SysPara.Gts_Calibration_Row_Y + 1].Yo));
                                srcTri[3] = new PointF((float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Gts_Calibration_Col_X + 1].Xm), (float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Gts_Calibration_Col_X + 1].Ym));

                                //仿射数据  测量坐标
                                dstTri[0] = new PointF((float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Gts_Calibration_Col_X].Xm), (float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Gts_Calibration_Col_X].Ym));
                                dstTri[1] = new PointF((float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Gts_Calibration_Col_X + Program.SystemContainer.SysPara.Gts_Calibration_Row_Y].Xm), (float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Gts_Calibration_Col_X + Program.SystemContainer.SysPara.Gts_Calibration_Row_Y].Ym));
                                dstTri[2] = new PointF((float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Gts_Calibration_Col_X + Program.SystemContainer.SysPara.Gts_Calibration_Row_Y + 1].Xm), (float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Gts_Calibration_Col_X + Program.SystemContainer.SysPara.Gts_Calibration_Row_Y + 1].Ym));
                                dstTri[3] = new PointF((float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Gts_Calibration_Col_X + 1].Xo), (float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Gts_Calibration_Col_X + 1].Yo));

                                break;
                            default:
                                break;
                        }
                        //计算仿射变换矩阵
                        //mat = CvInvoke.GetAffineTransform(srcTri, dstTri);
                        mat = CvInvoke.EstimateRigidTransform(srcTri, dstTri, true);
                        //提取矩阵数据
                        temp_array = mat.GetDoubleArray();
                        //获取仿射变换参数
                        Temp_Affinity_Matrix = Array_To_Affinity(temp_array);
                        //追加进入仿射变换List
                        Result.Add(new Affinity_Matrix(Temp_Affinity_Matrix));
                        //清除变量
                        Temp_Affinity_Matrix = new Affinity_Matrix();
                    }
                }
                //保存为文件
                Serialize_Data.Serialize_Affinity_Matrix(Result, FileName);
            }
            return Result;
        }

        /// <summary>
        /// abstract affinity parameter from array
        /// </summary>
        /// <param name="temp_array"></param>
        /// <returns></returns>
        public static Affinity_Matrix Array_To_Affinity(double[] temp_array)
        {
            Affinity_Matrix Result = new Affinity_Matrix
            {
                //获取仿射变换参数
                Stretch_X = Convert.ToDecimal(temp_array[0]),
                Distortion_X = Convert.ToDecimal(temp_array[1]),
                Delta_X = Convert.ToDecimal(temp_array[2]),//x方向偏移
                Stretch_Y = Convert.ToDecimal(temp_array[4]),
                Distortion_Y = Convert.ToDecimal(temp_array[3]),
                Delta_Y = Convert.ToDecimal(temp_array[5])//y方向偏移
            };
            //返回结果
            return Result;
        }
        /// <summary>
        /// 定位坐标 X
        /// </summary>
        /// <param name="Pos"></param>
        /// <returns></returns>
        public static Int16 Seek_X_Pos(decimal Pos)
        {
            Int16 Result = 0;
            Result = (Int16)Math.Floor((Pos / Program.SystemContainer.SysPara.Gts_Calibration_X_Cell) + 0.01m);
            if (Result >= Program.SystemContainer.SysPara.Gts_Affinity_Row_Y)
            {
                Result = (Int16)(Program.SystemContainer.SysPara.Gts_Affinity_Row_Y - 1);
            }
            else if (Result <= 0)
            {
                Result = 0;
            }
            return Result;
        }
        /// <summary>
        /// 定位坐标 Y
        /// </summary>
        /// <param name="Pos"></param>
        /// <returns></returns>
        public static Int16 Seek_Y_Pos(decimal Pos)
        {
            Int16 Result = 0;
            Result = (Int16)Math.Floor((Pos / Program.SystemContainer.SysPara.Gts_Calibration_Y_Cell) + 0.01m);
            if (Result >= Program.SystemContainer.SysPara.Gts_Affinity_Col_X)
            {
                Result = (Int16)(Program.SystemContainer.SysPara.Gts_Affinity_Col_X - 1);
            }
            else if (Result <= 0)
            {
                Result = 0;
            }
            return Result;
        }
        /// <summary>
        /// dxf 仿射变换 求DX，DY，Dct(sin \cos)
        /// </summary>
        /// <param name="Dstdata"></param>
        /// <returns></returns>
        public static Affinity_Matrix Cal_Affinity(List<Vector> Srcdata,List<Vector> Dstdata)
        {
            //建立变量
            Affinity_Matrix Result = new Affinity_Matrix();
            if ((Srcdata.Count >= 3) && (Dstdata.Count >= 3))
            {
                //定义仿射变换数组 
                Mat mat = new Mat(new Size(3, 2), Emgu.CV.CvEnum.DepthType.Cv32F, 1); //2行 3列 的矩阵
                ///定义点位数组
                PointF[] srcTri = new PointF[3];//标准数据
                PointF[] dstTri = new PointF[3];//差异化数据 
                double[] temp_array;
                //数据提取
                //标准数据
                srcTri[0] = new PointF((float)(Srcdata[0].X), (float)(Srcdata[0].Y));
                srcTri[1] = new PointF((float)(Srcdata[1].X), (float)(Srcdata[1].Y));
                srcTri[2] = new PointF((float)(Srcdata[2].X), (float)(Srcdata[2].Y));
                //仿射数据
                dstTri[0] = new PointF((float)(Dstdata[0].X), (float)(Dstdata[0].Y));
                dstTri[1] = new PointF((float)(Dstdata[1].X), (float)(Dstdata[1].Y));
                dstTri[2] = new PointF((float)(Dstdata[2].X), (float)(Dstdata[2].Y));
                //计算仿射变换矩阵
                mat = CvInvoke.GetAffineTransform(srcTri, dstTri);
                //提取矩阵数据
                temp_array = mat.GetDoubleArray();
                //获取仿射变换参数
                Result = Array_To_Affinity(temp_array);
                //返回结果
                return Result;
            }
            else
            {
                //返回结果
                return Result;
            }

        }
        /// <summary>
        /// get point affinity point'
        /// </summary>
        /// <param name="src"></param>
        /// <param name="affinity_Matrices"></param>
        /// <returns></returns>
        public static Vector Get_Aff_After(Vector src,Affinity_Matrix affinity_Matrices)
        { 
            return new Vector(src.X * affinity_Matrices.Stretch_X + src.Y * affinity_Matrices.Distortion_X + affinity_Matrices.Delta_X,src.Y * affinity_Matrices.Stretch_Y + src.X * affinity_Matrices.Distortion_Y + affinity_Matrices.Delta_Y);
        }
        /// <summary>
        /// 获取Affinity补偿坐标 0 - 实际坐标转平台坐标；1 - 平台坐标转实际坐标
        /// </summary>
        /// <param name="type"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="affinity_Matrices"></param>
        /// <returns></returns>
        public static Vector Get_Affinity_Point(int type,decimal x, decimal y)//0-A_M,1-M_A
        {
            Vector Result = new Vector();
            //临时定位变量
            Int16 X_Pos, Y_Pos;
            //获取落点
            X_Pos = Seek_X_Pos(x);
            Y_Pos = Seek_Y_Pos(y);
            //计算数据
            if (type == 1) //Motor_Coordinate ---- Actual_Coordinate  电机坐标转实际坐标
            {
                //计算逆矩阵
                var matrix1 = new DenseMatrix(3, 3);
                //矩阵赋值
                if (Program.SystemContainer.GTS_Fun.AffinityCountOK)
                {
                    matrix1[0, 0] = (Double)Program.SystemContainer.GTS_Fun.affinity_Matrices[Y_Pos * Program.SystemContainer.SysPara.Gts_Affinity_Col_X + X_Pos].Stretch_X;
                    matrix1[0, 1] = (Double)Program.SystemContainer.GTS_Fun.affinity_Matrices[Y_Pos * Program.SystemContainer.SysPara.Gts_Affinity_Col_X + X_Pos].Distortion_X;
                    matrix1[0, 2] = (Double)Program.SystemContainer.GTS_Fun.affinity_Matrices[Y_Pos * Program.SystemContainer.SysPara.Gts_Affinity_Col_X + X_Pos].Delta_X;
                    matrix1[1, 0] = (Double)Program.SystemContainer.GTS_Fun.affinity_Matrices[Y_Pos * Program.SystemContainer.SysPara.Gts_Affinity_Col_X + X_Pos].Distortion_Y;
                    matrix1[1, 1] = (Double)Program.SystemContainer.GTS_Fun.affinity_Matrices[Y_Pos * Program.SystemContainer.SysPara.Gts_Affinity_Col_X + X_Pos].Stretch_Y;
                    matrix1[1, 2] = (Double)Program.SystemContainer.GTS_Fun.affinity_Matrices[Y_Pos * Program.SystemContainer.SysPara.Gts_Affinity_Col_X + X_Pos].Delta_Y;
                    matrix1[2, 0] = 0;
                    matrix1[2, 1] = 0;
                    matrix1[2, 2] = 1;
                    //逆矩阵
                    var matrix2 = matrix1.Inverse();
                    Affinity_Matrix Tmp = new Affinity_Matrix((decimal)matrix2[0, 0], (decimal)matrix2[0, 1], (decimal)matrix2[0, 2], (decimal)matrix2[1, 1], (decimal)matrix2[1, 0], (decimal)matrix2[1, 2]);
                    //终点计算
                    Result = new Vector(x * Tmp.Stretch_X + y * Tmp.Distortion_X + Tmp.Delta_X, y * Tmp.Stretch_Y + x * Tmp.Distortion_Y + Tmp.Delta_Y);
                }
                else
                {
                    Result = new Vector(x, y);
                }
            }
            else //Actual_Coordinate ----  Motor_Coordinate 实际坐标转电机坐标
            {
                //结果计算
                if (Program.SystemContainer.GTS_Fun.AffinityCountOK)
                {
                    Result = new Vector(x * Program.SystemContainer.GTS_Fun.affinity_Matrices[Y_Pos * Program.SystemContainer.SysPara.Gts_Affinity_Col_X + X_Pos].Stretch_X + y * Program.SystemContainer.GTS_Fun.affinity_Matrices[Y_Pos * Program.SystemContainer.SysPara.Gts_Affinity_Col_X + X_Pos].Distortion_X + Program.SystemContainer.GTS_Fun.affinity_Matrices[Y_Pos * Program.SystemContainer.SysPara.Gts_Affinity_Col_X + X_Pos].Delta_X, y * Program.SystemContainer.GTS_Fun.affinity_Matrices[Y_Pos * Program.SystemContainer.SysPara.Gts_Affinity_Col_X + X_Pos].Stretch_Y + x * Program.SystemContainer.GTS_Fun.affinity_Matrices[Y_Pos * Program.SystemContainer.SysPara.Gts_Affinity_Col_X + X_Pos].Distortion_Y + Program.SystemContainer.GTS_Fun.affinity_Matrices[Y_Pos * Program.SystemContainer.SysPara.Gts_Affinity_Col_X + X_Pos].Delta_Y);
                }
                else
                {
                    Result = new Vector(x, y);
                }
            }
            //返回结果坐标
            return Result;
        }   
    }
    //RTC校准数据处理
    class Rtc_Cal_Data_Resolve
    {
        /// <summary>
        /// 处理测量值与实际值 数据，生成仿射变换数组，并保存进入文件
        /// </summary>
        /// <param name="correct_Datas"></param>
        /// <returns></returns>
        public static List<Affinity_Matrix> Resolve(List<Correct_Data> correct_Datas)
        {
            //建立变量
            List<Affinity_Matrix> Result = new List<Affinity_Matrix>();
            Affinity_Matrix Temp_Affinity_Matrix = new Affinity_Matrix();
            Int16 i, j;
            //定义仿射变换数组 
            Mat mat = new Mat(new Size(3, 2), Emgu.CV.CvEnum.DepthType.Cv32F, 1); //2行 3列 的矩阵       
            //原坐标
            double[] temp_array;
            //数据处理
            if (Program.SystemContainer.SysPara.Rtc_Calibration_Col_X * Program.SystemContainer.SysPara.Rtc_Calibration_Row_Y == correct_Datas.Count)//矫正和差异数据完整
            {
                //定义点位数组 
                PointF[] srcTri = new PointF[Program.SystemContainer.SysPara.Rtc_Calibration_Method];//标准数据
                PointF[] dstTri = new PointF[Program.SystemContainer.SysPara.Rtc_Calibration_Method];//差异化数据
                //数据处理
                for (i = 0; i < Program.SystemContainer.SysPara.Rtc_Calibration_Col_X - 1; i++)
                {
                    for (j = 0; j < Program.SystemContainer.SysPara.Rtc_Calibration_Row_Y - 1; j++)
                    {
                        switch (Program.SystemContainer.SysPara.Rtc_Calibration_Method)
                        {
                            case 3://三点法
                                //标准数据  定位坐标
                                srcTri[0] = new PointF((float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Rtc_Calibration_Col_X].Xo), (float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Rtc_Calibration_Col_X].Yo));
                                srcTri[1] = new PointF((float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Rtc_Calibration_Col_X + Program.SystemContainer.SysPara.Rtc_Calibration_Row_Y].Xo), (float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Rtc_Calibration_Col_X + Program.SystemContainer.SysPara.Rtc_Calibration_Row_Y].Yo));
                                srcTri[2] = new PointF((float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Rtc_Calibration_Col_X + Program.SystemContainer.SysPara.Rtc_Calibration_Row_Y + 1].Xo), (float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Rtc_Calibration_Col_X + Program.SystemContainer.SysPara.Rtc_Calibration_Row_Y + 1].Yo));//计算仿射变换矩阵
                                //仿射数据  测量坐标
                                dstTri[0] = new PointF((float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Rtc_Calibration_Col_X].Xm), (float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Rtc_Calibration_Col_X].Ym));
                                dstTri[1] = new PointF((float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Rtc_Calibration_Col_X + Program.SystemContainer.SysPara.Rtc_Calibration_Row_Y].Xm), (float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Rtc_Calibration_Col_X + Program.SystemContainer.SysPara.Rtc_Calibration_Row_Y].Ym));
                                dstTri[2] = new PointF((float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Rtc_Calibration_Col_X + Program.SystemContainer.SysPara.Rtc_Calibration_Row_Y + 1].Xm), (float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Rtc_Calibration_Col_X + Program.SystemContainer.SysPara.Rtc_Calibration_Row_Y + 1].Ym));
                                break;
                            case 4://四点法
                                //标准数据  定位坐标
                                srcTri[0] = new PointF((float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Rtc_Calibration_Col_X].Xo), (float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Rtc_Calibration_Col_X].Yo));
                                srcTri[1] = new PointF((float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Rtc_Calibration_Col_X + Program.SystemContainer.SysPara.Rtc_Calibration_Row_Y].Xo), (float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Rtc_Calibration_Col_X + Program.SystemContainer.SysPara.Rtc_Calibration_Row_Y].Yo));
                                srcTri[2] = new PointF((float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Rtc_Calibration_Col_X + Program.SystemContainer.SysPara.Rtc_Calibration_Row_Y + 1].Xo), (float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Rtc_Calibration_Col_X + Program.SystemContainer.SysPara.Rtc_Calibration_Row_Y + 1].Yo));//计算仿射变换矩阵
                                srcTri[3] = new PointF((float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Rtc_Calibration_Col_X + 1].Xo), (float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Rtc_Calibration_Col_X + 1].Yo));//计算仿射变换矩阵
                                //仿射数据  测量坐标
                                dstTri[0] = new PointF((float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Rtc_Calibration_Col_X].Xm), (float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Rtc_Calibration_Col_X].Ym));
                                dstTri[1] = new PointF((float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Rtc_Calibration_Col_X + Program.SystemContainer.SysPara.Rtc_Calibration_Row_Y].Xm), (float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Rtc_Calibration_Col_X + Program.SystemContainer.SysPara.Rtc_Calibration_Row_Y].Ym));
                                dstTri[2] = new PointF((float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Rtc_Calibration_Col_X + Program.SystemContainer.SysPara.Rtc_Calibration_Row_Y + 1].Xm), (float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Rtc_Calibration_Col_X + Program.SystemContainer.SysPara.Rtc_Calibration_Row_Y + 1].Ym));
                                dstTri[3] = new PointF((float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Rtc_Calibration_Col_X + 1].Xm), (float)(correct_Datas[j + i * Program.SystemContainer.SysPara.Rtc_Calibration_Col_X + 1].Ym));
                                break;
                            default:
                                break;
                        }                        
                        //计算仿射变换矩阵
                        mat = CvInvoke.GetAffineTransform(srcTri, dstTri);
                        //提取矩阵数据
                        temp_array = mat.GetDoubleArray();
                        //获取仿射变换参数
                        Temp_Affinity_Matrix = Gts_Cal_Data_Resolve.Array_To_Affinity(temp_array);
                        //追加进入仿射变换List
                        Result.Add(new Affinity_Matrix(Temp_Affinity_Matrix));
                        //清除变量
                        Temp_Affinity_Matrix = new Affinity_Matrix();
                    }
                }
                //保存为文件
                Serialize_Data.Serialize_Affinity_Matrix(Result, "Rtc_Affinity_Matrix_Three.xml");

            }
            return Result;
        }
        /// <summary>
        /// 定位坐标 X
        /// </summary>
        /// <param name="Pos"></param>
        /// <returns></returns>
        public static Int16 Seek_X_Pos(decimal Pos)
        {
            Int16 Result = 0;
            Result = (Int16)Math.Floor(((Pos + Program.SystemContainer.SysPara.Rtc_Calibration_X_Len / 2m) / Program.SystemContainer.SysPara.Rtc_Calibration_X_Cell) + 0.01m);
            if (Result >= Program.SystemContainer.SysPara.Rtc_Affinity_Row_Y)
            {
                Result = (Int16)(Program.SystemContainer.SysPara.Rtc_Affinity_Row_Y - 1);
            }
            else if (Result <= 0)
            {
                Result = 0;
            }
            return Result;
        }
        /// <summary>
        /// 定位坐标 Y
        /// </summary>
        /// <param name="Pos"></param>
        /// <returns></returns>
        public static Int16 Seek_Y_Pos(decimal Pos)
        {
            Int16 Result = 0;
            Result = (Int16)Math.Floor(((Pos + Program.SystemContainer.SysPara.Rtc_Calibration_Y_Len / 2m) / Program.SystemContainer.SysPara.Rtc_Calibration_Y_Cell) + 0.01m);
            if (Result >= Program.SystemContainer.SysPara.Rtc_Affinity_Col_X)
            {
                Result = (Int16)(Program.SystemContainer.SysPara.Rtc_Affinity_Col_X - 1);
            }
            else if (Result <= 0)
            {
                Result = 0;
            }
            return Result;
        }
        /// <summary>
        /// 获取线性补偿后的坐标值
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="line_fit_data"></param>
        /// <returns></returns>
        public static Vector Get_Line_Fit_Coordinate(decimal x, decimal y, List<Double_Fit_Data> line_fit_data)
        {
            //临时定位变量
            Int16 m, n;
            decimal X_per, Y_per;
            decimal K_x1, K_x2, K_x3, K_x4, B_x;
            decimal K_y1, K_y2, K_y3, K_y4, B_y; 
            //获取落点
            m = Seek_X_Pos(y);
            n = Seek_Y_Pos(x);
            //计算比率
            X_per = Math.Abs(y - m * Program.SystemContainer.SysPara.Rtc_Calibration_Y_Cell) / Program.SystemContainer.SysPara.Rtc_Calibration_Y_Cell;
            Y_per = Math.Abs(x - m * Program.SystemContainer.SysPara.Rtc_Calibration_X_Cell) / Program.SystemContainer.SysPara.Rtc_Calibration_X_Cell;
            //计算实际 线性拟合数据
            K_x1 = (line_fit_data[m + 1].K_X1 - line_fit_data[m].K_X1) * X_per + line_fit_data[m].K_X1;
            K_x2 = (line_fit_data[m + 1].K_X2 - line_fit_data[m].K_X2) * X_per + line_fit_data[m].K_X2;
            K_x3 = (line_fit_data[m + 1].K_X3 - line_fit_data[m].K_X3) * X_per + line_fit_data[m].K_X3;
            K_x4 = (line_fit_data[m + 1].K_X4 - line_fit_data[m].K_X4) * X_per + line_fit_data[m].K_X4;
            B_x = (line_fit_data[m + 1].Delta_X - line_fit_data[m].Delta_X) * X_per + line_fit_data[m].Delta_X;
            K_y1 = (line_fit_data[m + 1].K_Y1 - line_fit_data[m].K_Y1) * Y_per + line_fit_data[m].K_Y1;
            K_y2 = (line_fit_data[m + 1].K_Y2 - line_fit_data[m].K_Y2) * Y_per + line_fit_data[m].K_Y2;
            K_y3 = (line_fit_data[m + 1].K_Y3 - line_fit_data[m].K_Y3) * Y_per + line_fit_data[m].K_Y3;
            K_y4 = (line_fit_data[m + 1].K_Y4 - line_fit_data[m].K_Y4) * Y_per + line_fit_data[m].K_Y4;
            B_y = (line_fit_data[m + 1].Delta_Y - line_fit_data[m].Delta_Y) * Y_per + line_fit_data[m].Delta_Y;
            //返回实际坐标
            return new Vector(K_x4 * x * x * x * x + K_x3 * x * x * x + K_x2 * x * x + K_x1 * x + B_x, K_y4 * y * y * y * y + K_y3 * y * y * y + K_y2 * y * y + K_y1 * y + B_y);
        }

        /// <summary>
        /// 矩阵数据 仿射变换矩阵 获取Affinity补偿坐标 0 - 实际坐标转平台坐标；1 - 平台坐标转实际坐标
        /// </summary>
        /// <param name="type"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="affinity_Matrices"></param>
        /// <returns></returns>
        public static Vector Get_Affinity_Point(int type, decimal x, decimal y, List<Affinity_Matrix> affinity_Matrices)//0-A_M,1-M_A
        {
            Vector Result = new Vector();
            //临时定位变量
            Int16 X_Pos, Y_Pos;
            //获取落点
            X_Pos = Seek_X_Pos(x);
            Y_Pos = Seek_Y_Pos(y);
            //坐标转换
            if (type == 1) //Motor_Coordinate ---- Actual_Coordinate
            {
                //计算逆矩阵
                var matrix1 = new DenseMatrix(3, 3);
                //矩阵赋值
                if (Program.SystemContainer.RTC_Fun.AffinityCountOK)
                {
                    matrix1[0, 0] = (Double)affinity_Matrices[Y_Pos * Program.SystemContainer.SysPara.Rtc_Affinity_Col_X + X_Pos].Stretch_X;
                    matrix1[0, 1] = (Double)affinity_Matrices[Y_Pos * Program.SystemContainer.SysPara.Rtc_Affinity_Col_X + X_Pos].Distortion_X;
                    matrix1[0, 2] = (Double)affinity_Matrices[Y_Pos * Program.SystemContainer.SysPara.Rtc_Affinity_Col_X + X_Pos].Delta_X;
                    matrix1[1, 0] = (Double)affinity_Matrices[Y_Pos * Program.SystemContainer.SysPara.Rtc_Affinity_Col_X + X_Pos].Distortion_Y;
                    matrix1[1, 1] = (Double)affinity_Matrices[Y_Pos * Program.SystemContainer.SysPara.Rtc_Affinity_Col_X + X_Pos].Stretch_Y;
                    matrix1[1, 2] = (Double)affinity_Matrices[Y_Pos * Program.SystemContainer.SysPara.Rtc_Affinity_Col_X + X_Pos].Delta_Y;
                    matrix1[2, 0] = 0;
                    matrix1[2, 1] = 0;
                    matrix1[2, 2] = 1;
                    //逆矩阵
                    var matrix2 = matrix1.Inverse();
                    Affinity_Matrix Tmp = new Affinity_Matrix((decimal)matrix2[0, 0], (decimal)matrix2[0, 1], (decimal)matrix2[0, 2], (decimal)matrix2[1, 1], (decimal)matrix2[1, 0], (decimal)matrix2[1, 2]);
                    //结果计算
                    Result = new Vector(x * Tmp.Stretch_X + y * Tmp.Distortion_X + Tmp.Delta_X, y * Tmp.Stretch_Y + x * Tmp.Distortion_Y + Tmp.Delta_Y);
                }
                else
                {
                    //结果计算
                    Result = new Vector(x,y);
                }
            }
            else
            {
                //结果计算
                if (Program.SystemContainer.RTC_Fun.AffinityCountOK)
                {
                    Result = new Vector(x * affinity_Matrices[Y_Pos * Program.SystemContainer.SysPara.Rtc_Affinity_Col_X + X_Pos].Stretch_X + y * affinity_Matrices[Y_Pos * Program.SystemContainer.SysPara.Rtc_Affinity_Col_X + X_Pos].Distortion_X + affinity_Matrices[Y_Pos * Program.SystemContainer.SysPara.Rtc_Affinity_Col_X + X_Pos].Delta_X, y * affinity_Matrices[Y_Pos * Program.SystemContainer.SysPara.Rtc_Affinity_Col_X + X_Pos].Stretch_Y + x * affinity_Matrices[Y_Pos * Program.SystemContainer.SysPara.Rtc_Affinity_Col_X + X_Pos].Distortion_Y + affinity_Matrices[Y_Pos * Program.SystemContainer.SysPara.Rtc_Affinity_Col_X + X_Pos].Delta_Y);
                }
                else
                {
                    Result = new Vector(x, y);
                }
            }
            //返回实际坐标
            return Result;
        }

        /// <summary>
        /// 仿射变换 矫正振镜坐标系夹角 返回矫正后的坐标
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static Vector AFF_Correct_Rtc_Axes(decimal x, decimal y)
        {
            Vector Result = new Vector();
            //临时定位变量
            Int16 X_Pos, Y_Pos;
            //获取落点
            X_Pos = Seek_X_Pos(x);
            Y_Pos = Seek_Y_Pos(y);
            //结果计算
            if (Program.SystemContainer.SysPara.RtcCorrectType == 0)//0 - 单一仿射矫正
            {
                Result =  new Vector(x * Program.SystemContainer.SysPara.Rtc_Trans_Affinity.Stretch_X + y * Program.SystemContainer.SysPara.Rtc_Trans_Affinity.Distortion_X + Program.SystemContainer.SysPara.Rtc_Trans_Affinity.Delta_X, y * Program.SystemContainer.SysPara.Rtc_Trans_Affinity.Stretch_Y + x * Program.SystemContainer.SysPara.Rtc_Trans_Affinity.Distortion_Y + Program.SystemContainer.SysPara.Rtc_Trans_Affinity.Delta_Y);
            }
            else//其他 - 仿射矩阵矫正
            {
                if (Program.SystemContainer.RTC_Fun.AffinityCountOK)
                {
                    Result = new Vector(x * Program.SystemContainer.RTC_Fun.affinity_Matrices[Y_Pos * Program.SystemContainer.SysPara.Rtc_Affinity_Col_X + X_Pos].Stretch_X + y * Program.SystemContainer.RTC_Fun.affinity_Matrices[Y_Pos * Program.SystemContainer.SysPara.Rtc_Affinity_Col_X + X_Pos].Distortion_X + Program.SystemContainer.RTC_Fun.affinity_Matrices[Y_Pos * Program.SystemContainer.SysPara.Rtc_Affinity_Col_X + X_Pos].Delta_X, y * Program.SystemContainer.RTC_Fun.affinity_Matrices[Y_Pos * Program.SystemContainer.SysPara.Rtc_Affinity_Col_X + X_Pos].Stretch_Y + x * Program.SystemContainer.RTC_Fun.affinity_Matrices[Y_Pos * Program.SystemContainer.SysPara.Rtc_Affinity_Col_X + X_Pos].Distortion_Y + Program.SystemContainer.RTC_Fun.affinity_Matrices[Y_Pos * Program.SystemContainer.SysPara.Rtc_Affinity_Col_X + X_Pos].Delta_Y);
                }
                else
                {
                    Result = new Vector(x * Program.SystemContainer.SysPara.Rtc_Trans_Affinity.Stretch_X + y * Program.SystemContainer.SysPara.Rtc_Trans_Affinity.Distortion_X + Program.SystemContainer.SysPara.Rtc_Trans_Affinity.Delta_X, y * Program.SystemContainer.SysPara.Rtc_Trans_Affinity.Stretch_Y + x * Program.SystemContainer.SysPara.Rtc_Trans_Affinity.Distortion_Y + Program.SystemContainer.SysPara.Rtc_Trans_Affinity.Delta_Y);
                }                
            }
            //返回结果
            return Result;
        }
    }
    class Laser_Watt_Cal
    {
        /// <summary>
        /// 矫正数据采集
        /// </summary>
        public static void Acquisition_Data()
        {
            //数据变量
            DataTable Laser_Watt_Percent_Data = new DataTable();
            Laser_Watt_Percent_Data.Columns.Add("激光输出百分比", typeof(decimal));
            Laser_Watt_Percent_Data.Columns.Add("激光实际功率", typeof(decimal));
            if ((Program.SystemContainer.Laser_Control_Com.ComDevice.IsOpen) && (Program.SystemContainer.Laser_Watt_Com.ComDevice.IsOpen))
            {
                for (int i = 0; i <= 100; i++)
                {
                    Program.SystemContainer.Laser_Operation_00.Change_Pec(i);
                    Thread.Sleep(500);
                    Program.SystemContainer.RTC_Fun.Open_Laser();
                    Thread.Sleep(1000);//读数稳定时间
                    Laser_Watt_Percent_Data.Rows.Add(new object[] { i, Program.SystemContainer.Laser_Watt_00.Current_Watt});
                    Program.SystemContainer.RTC_Fun.Close_Laser();
                    Thread.Sleep(5000 * i );//冷却时间
                }
            }
            else
            {
                Program.SystemContainer.RTC_Fun.Close_Laser();
                MessageBox.Show("激光控制器或激光功率计串口未打开！！！");
                return;
            }
            CSV_RW.SaveCSV(Laser_Watt_Percent_Data, "Laser_Watt_Percent_Data");
        }
        /// <summary>
        /// 生成激光 百分比 与 功率的对应关系
        /// </summary>
        /// <param name="New_Data"></param>
        /// <returns></returns>
        public static List<Double_Fit_Data> Resolve(DataTable New_Data)
        {

            //建立变量
            List<Double_Fit_Data> Result = new List<Double_Fit_Data>();
            Double_Fit_Data Temp_Fit_Data = new Double_Fit_Data();
            Int16 i;
            //拟合高阶次数
            short Line_Re = 4;
            //初始化数据
            double[] src = new double[New_Data.Rows.Count];
            double[] dst = new double[New_Data.Rows.Count];
            //数据处理
            for (i = 0; i < New_Data.Rows.Count; i++)
            {                
                if ((decimal.TryParse(New_Data.Rows[i][0].ToString(), out decimal X )) && (decimal.TryParse(New_Data.Rows[i][1].ToString(), out decimal Y)))
                {
                    src[i] = (float)X;
                    dst[i] = (float)Y;
                }                
            }
            //高阶曲线拟合
            if (Line_Re == 4)
            {
                double[] Res_00 = Fit.Polynomial(src, dst, Line_Re);
                double[] Res_01 = Fit.Polynomial(dst, src, Line_Re);
                //提取拟合直线数据
                Temp_Fit_Data = new Double_Fit_Data
                {
                    K_X4 = (decimal)Res_00[4],
                    K_X3 = (decimal)Res_00[3],
                    K_X2 = (decimal)Res_00[2],
                    K_X1 = (decimal)Res_00[1],
                    Delta_X = (decimal)Res_00[0],
                    K_Y4 = (decimal)Res_01[4],
                    K_Y3 = (decimal)Res_01[3],
                    K_Y2 = (decimal)Res_01[2],
                    K_Y1 = (decimal)Res_01[1],
                    Delta_Y = (decimal)Res_01[0]
                };
            }
            else if (Line_Re == 3)
            {
                double[] Res_00 = Fit.Polynomial(src, dst, Line_Re);
                double[] Res_01 = Fit.Polynomial(dst, src, Line_Re);
                //提取拟合直线数据
                Temp_Fit_Data = new Double_Fit_Data
                {
                    K_X4 = 0,
                    K_X3 = (decimal)Res_00[3],
                    K_X2 = (decimal)Res_00[2],
                    K_X1 = (decimal)Res_00[1],
                    Delta_X = (decimal)Res_00[0],
                    K_Y4 = 0,
                    K_Y3 = (decimal)Res_01[3],
                    K_Y2 = (decimal)Res_01[2],
                    K_Y1 = (decimal)Res_01[1],
                    Delta_Y = (decimal)Res_01[0]
                };
            }
            else if (Line_Re == 2)
            {
                double[] Res_00 = Fit.Polynomial(src, dst, Line_Re);
                double[] Res_01 = Fit.Polynomial(dst, src, Line_Re);
                //提取拟合直线数据
                Temp_Fit_Data = new Double_Fit_Data
                {
                    K_X4 = 0,
                    K_X3 = 0,
                    K_X2 = (decimal)Res_00[2],
                    K_X1 = (decimal)Res_00[1],
                    Delta_X = (decimal)Res_00[0],
                    K_Y4 = 0,
                    K_Y3 = 0,
                    K_Y2 = (decimal)Res_01[2],
                    K_Y1 = (decimal)Res_01[1],
                    Delta_Y = (decimal)Res_01[0]
                };
            }
            else if (Line_Re == 1)
            {
                double[] Res_00 = Fit.Polynomial(src, dst, Line_Re);
                double[] Res_01 = Fit.Polynomial(dst, src, Line_Re);
                //提取拟合直线数据
                Temp_Fit_Data = new Double_Fit_Data
                {
                    K_X4 = 0,
                    K_X3 = 0,
                    K_X2 = 0,
                    K_X1 = (decimal)Res_00[1],
                    Delta_X = (decimal)Res_00[0],
                    K_Y4 = 0,
                    K_Y3 = 0,
                    K_Y2 = 0,
                    K_Y1 = 0,
                    Delta_Y = (decimal)Res_01[0]
                };
            }
            else//1阶线性拟合
            {

                Tuple<double, double> R_00 = new Tuple<double, double>(0, 0);
                Tuple<double, double> R_01 = new Tuple<double, double>(0, 0);
                R_00 = Fit.Line(src, dst);
                R_01 = Fit.Line(dst, src);
                //提取拟合直线数据
                Temp_Fit_Data = new Double_Fit_Data
                {
                    K_X1 = (decimal)R_00.Item2,
                    Delta_X = (decimal)R_00.Item1,
                    K_Y1 = (decimal)R_01.Item2,
                    Delta_Y = (decimal)R_01.Item1
                };
            }
            //结果追加
            Result.Add(new Double_Fit_Data(Temp_Fit_Data));
            //清空数据
            Temp_Fit_Data.Empty();
            //保存功率矫正拟合数据
            CSV_RW.SaveCSV(CSV_RW.Double_Fit_Data_DataTable(Result), "Laser_Watt_Percent_Relate");
            //返回结果
            return Result;
        }
        /// <summary>
        /// 功率 转换为 百分比
        /// </summary>
        /// <param name="watt"></param>
        /// <returns></returns>
        public static decimal Watt_To_Percent(decimal watt)
        {
            return Program.SystemContainer.Laser_Watt_Percent_Relate.K_X4 * watt * watt * watt * watt + Program.SystemContainer.Laser_Watt_Percent_Relate.K_X3 * watt * watt * watt + Program.SystemContainer.Laser_Watt_Percent_Relate.K_X2 * watt * watt + Program.SystemContainer.Laser_Watt_Percent_Relate.K_X1 * watt + Program.SystemContainer.Laser_Watt_Percent_Relate.Delta_X;
        }
        /// <summary>
        /// 百分比 转换为 功率
        /// </summary>
        /// <param name="percent"></param>
        /// <returns></returns>
        public static decimal Percent_To_Watt(decimal percent)
        {
            return Program.SystemContainer.Laser_Watt_Percent_Relate.K_Y4 * percent * percent * percent * percent + Program.SystemContainer.Laser_Watt_Percent_Relate.K_Y3 * percent * percent * percent + Program.SystemContainer.Laser_Watt_Percent_Relate.K_Y2 * percent * percent + Program.SystemContainer.Laser_Watt_Percent_Relate.K_Y1 * percent + Program.SystemContainer.Laser_Watt_Percent_Relate.Delta_Y;
        }
        /// <summary>
        /// 功率 转换为 功率
        /// </summary>
        /// <param name="watt"></param>
        /// <returns></returns>
        public static decimal Watt_To_Watt(decimal watt) 
        {
            return Program.SystemContainer.Laser_Watt_Percent_Relate.K_X4 * watt * watt * watt * watt + Program.SystemContainer.Laser_Watt_Percent_Relate.K_X3 * watt * watt * watt + Program.SystemContainer.Laser_Watt_Percent_Relate.K_X2 * watt * watt + Program.SystemContainer.Laser_Watt_Percent_Relate.K_X1 * watt + Program.SystemContainer.Laser_Watt_Percent_Relate.Delta_X;
        }
    }      
    public class Serialize_Data 
    {
        /// <summary>
        /// List<T> 数据序列化
        /// </summary>
        /// <param name="list"></param>
        /// <param name="txtFile"></param>
        public static void Serialize_<T>(List<T> list, string txtFile)
        {
            //写入文件
            string File_Path = @"./\Config/" + txtFile;
            using (FileStream fs = new FileStream(File_Path, FileMode.Create, FileAccess.ReadWrite))
            {
                //二进制 序列化
                //BinaryFormatter bf = new BinaryFormatter();
                //xml 序列化
                XmlSerializer bf = new XmlSerializer(typeof(List<T>));
                bf.Serialize(fs, list);
            }
        }
        /// <summary>
        ///  List<T> 数据反序列化
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static List<T> Reserialize_<T>(string fileName)
        {

            //读取文件
            string File_Path = fileName;
            using (FileStream fs = new FileStream(File_Path, FileMode.Open, FileAccess.Read))
            {
                //二进制 反序列化
                //BinaryFormatter bf = new BinaryFormatter();
                //xml 反序列化
                XmlSerializer bf = new XmlSerializer(typeof(List<T>));
                List<T> list = (List<T>)bf.Deserialize(fs);
                return list;
            }
        }
        /// <summary>
        /// List<Correct_Data> 数据序列化
        /// </summary>
        /// <param name="list"></param>
        /// <param name="txtFile"></param>
        public static void Serialize_Correct_Data(List<Correct_Data> list,string txtFile)
        {
            //写入文件
            string File_Path = @"./\Config/" + txtFile;
            using (FileStream fs = new FileStream(File_Path, FileMode.Create,FileAccess.ReadWrite))
            {
                //二进制 序列化
                //BinaryFormatter bf = new BinaryFormatter();
                //xml 序列化
                XmlSerializer bf = new XmlSerializer(typeof(List<Correct_Data>));
                bf.Serialize(fs, list);
            }
        }
        /// <summary>
        ///  List<Correct_Data> 数据反序列化
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static List<Correct_Data> Reserialize_Correct_Data (string fileName)
        {            

            //读取文件
            string File_Path = @"./\Config/" + fileName;
            using (FileStream fs = new FileStream(File_Path, FileMode.Open,FileAccess.Read))
            {
                //二进制 反序列化
                //BinaryFormatter bf = new BinaryFormatter();
                //xml 反序列化
                XmlSerializer bf = new XmlSerializer(typeof(List<Correct_Data>));
                List<Correct_Data> list = (List<Correct_Data>)bf.Deserialize(fs);
                return list;
            }
        }
        /// <summary>
        /// List<Affinity_Matrix> 数据序列化
        /// </summary>
        /// <param name="list"></param>
        /// <param name="txtFile"></param>
        public static void Serialize_Affinity_Matrix(List<Affinity_Matrix> list, string txtFile) 
        {
            //写入文件
            string File_Path = @"./\Config/" + txtFile;
            using (FileStream fs = new FileStream(File_Path, FileMode.Create, FileAccess.ReadWrite))
            {
                //保存参数至文件 二进制
                //BinaryFormatter bf = new BinaryFormatter();
                //保存为xml
                XmlSerializer bf = new XmlSerializer(typeof(List<Affinity_Matrix>));
                bf.Serialize(fs, list);
            }
        }

        /// <summary>
        /// List<Affinity_Matrix> 数据反序列化
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static List<Affinity_Matrix> Reserialize_Affinity_Matrix(string File_Path)  
        {

            //读取文件
            using (FileStream fs = new FileStream(File_Path, FileMode.Open, FileAccess.Read))
            {
                //二进制 反序列化
                //BinaryFormatter bf = new BinaryFormatter();
                //xml 反序列化
                XmlSerializer bf = new XmlSerializer(typeof(List<Affinity_Matrix>));
                List<Affinity_Matrix> list = (List<Affinity_Matrix>)bf.Deserialize(fs);
                return list;
            }
        }
    }
}

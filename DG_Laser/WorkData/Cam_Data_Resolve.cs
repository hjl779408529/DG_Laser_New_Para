using netDxf;
using netDxf.Header;
using netDxf.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DG_Laser 
{
    class Cam_Data_Resolve
    {
        public event LogInfo LogInfo;
        /// <summary>
        /// 读取文件
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public DxfDocument Read_File(string filename)
        {
            //定义文件名
            string Dxf_filename = null;
            if (filename == null)
            {
                Dxf_filename = "Sample.dxf";
            }
            else
            {
                Dxf_filename = filename;
            }
            DxfDocument Result = new DxfDocument();
            //检查文件是否存在
            FileInfo fileInfo = new FileInfo(Dxf_filename);
            if (!fileInfo.Exists)
            {
                LogInfo?.Invoke(Dxf_filename + "  文件不存在！！！" + "\r\n");
                return Result;
            }
            DxfVersion dxfVersion = DxfDocument.CheckDxfFileVersion(Dxf_filename, out bool isBinary);

            // 检查Dxf文件版本是否正确
            if (dxfVersion < DxfVersion.AutoCad2000)
            {
                LogInfo?.Invoke(Dxf_filename + "  文件版本不支持" + "\r\n");
                return Result;
            }

            //读取Dxf文件
            Result = DxfDocument.Load(Dxf_filename);
            // check if there has been any problems loading the file,
            // this might be the case of a corrupt file or a problem in the library
            if (Result == null)
            {
                LogInfo?.Invoke(Dxf_filename + "  Dxf文件读取失败" + "\r\n");
                return Result;
            }
            //返回读取结果
            return Result;
        }
        /// <summary>
        /// 处理Dxf 提取圆弧数据
        /// </summary>
        /// <param name="dxf"></param>
        /// <returns></returns>
        public List<List<Entity_Data>> Resolve_Cam_Arc(DxfDocument dxf)
        {
            List<Arc> Tmp_Arcs = new List<Arc>();
            List<List<Entity_Data>> Result = new List<List<Entity_Data>>();
            List<Entity_Data> Temp_List = new List<Entity_Data>(); 
            //建立临时Entity数据
            Entity_Data Temp_Entity = new Entity_Data();
            //临时变量
            string Layer_Name = null;
            string Type = "Arc";
            int i = 0;
            //提取符合要求的直线
            for (i = 0; i < dxf.Arcs.Count; i++)
            {
                if (dxf.Arcs[i].Layer.Name.Contains(Type))
                {
                    Tmp_Arcs.Add(dxf.Arcs[i]);
                }
            }

            //圆弧数据读取
            for (int j = 0;j < Program.SystemContainer.SysPara.Work_Scissors_Limit; j++)
            {
                Layer_Name = "Arc" + j;
                if (Tmp_Arcs.Exists(o => o.Layer.Name == Layer_Name))
                {
                    //提取刀具数据do
                    do
                    {
                        for (int zone = 0; zone < 256; zone++)//区块划分总数，支持0-255共256个区块
                        {
                            if (Tmp_Arcs.Exists(o => o.Color.R == zone))
                            {
                                for (i = 0; i < Tmp_Arcs.Count; i++)
                                {
                                    if ((Tmp_Arcs[i].Layer.Name == Layer_Name) && (Tmp_Arcs[i].Color.R == zone))
                                    {
                                        //Tmp_Arcs[i].Color.
                                        Temp_Entity.Path_Type = j;//刀具类型
                                        Temp_Entity.Type = 2;//圆弧
                                                             //起点计算
                                        Temp_Entity.Start_x = Convert.ToDecimal(Tmp_Arcs[i].StartPoint.X);
                                        Temp_Entity.Start_y = Convert.ToDecimal(Tmp_Arcs[i].StartPoint.Y);
                                        //终点计算
                                        Temp_Entity.End_x = Convert.ToDecimal(Tmp_Arcs[i].EndPoint.X);
                                        Temp_Entity.End_y = Convert.ToDecimal(Tmp_Arcs[i].EndPoint.Y);
                                        //起始和终止角度提取
                                        Temp_Entity.Cir_Start_Angle = Convert.ToDecimal(Tmp_Arcs[i].StartAngle);
                                        Temp_Entity.Cir_End_Angle = Convert.ToDecimal(Tmp_Arcs[i].EndAngle);
                                        //角度处理
                                        if (Temp_Entity.Cir_Start_Angle >= 359.99m)
                                        {
                                            Temp_Entity.Cir_Start_Angle = 0.0m;
                                        }
                                        if (Temp_Entity.Cir_End_Angle <= 0.01m)
                                        {
                                            Temp_Entity.Cir_End_Angle = 360.0m;
                                        }
                                        //圆心计算
                                        Temp_Entity.Center_x = Convert.ToDecimal(Tmp_Arcs[i].Center.X);
                                        Temp_Entity.Center_y = Convert.ToDecimal(Tmp_Arcs[i].Center.Y);
                                        Temp_Entity.Circle_radius = Convert.ToDecimal(Tmp_Arcs[i].Radius);
                                        //提交
                                        Temp_List.Add(new Entity_Data(Temp_Entity));
                                        Temp_Entity.Empty();

                                        //移除当前圆
                                        Tmp_Arcs.RemoveAt(i);
                                        i = -1;
                                    }
                                }

                                if (Temp_List.Count > 0)
                                {
                                    //追加至返回结果
                                    Result.Add(new List<Entity_Data>(Temp_List));
                                    Temp_List.Clear();
                                }
                            }                            
                        }  
                    } while ((Tmp_Arcs.Count != 0) && (Tmp_Arcs.Min(o => o.Layer.Name) == Layer_Name));//数量大于零、刀具名最小刀具名依然在，只能迭代Zone 
                }
            }            
            //返回结果
            return Result;
        }
        /// <summary>
        /// 处理Dxf 提取线段数据 返回的是颜色区块内的轨迹数据
        /// </summary>
        /// <param name="dxf"></param>
        /// <returns></returns>
        public List<List<Entity_Data>> Resolve_Cam_Line(DxfDocument dxf)
        {
            List<Line> Tmp_Lines = new List<Line>();            
            List<List<Entity_Data>> Result = new List<List<Entity_Data>>();
            List<Entity_Data> Temp_List = new List<Entity_Data>(); 
            //建立临时Entity数据
            Entity_Data Temp_Entity = new Entity_Data();
            //临时变量
            string Layer_Name = null;
            string Type = "Line";
            int i = 0;
            //提取符合要求的直线
            for(i = 0;i < dxf.Lines.Count;i++)
            {
                if (dxf.Lines[i].Layer.Name.Contains(Type))
                {
                    Tmp_Lines.Add(dxf.Lines[i]);
                }
            }
            //直线数据读取
            for (int j = 0; j < Program.SystemContainer.SysPara.Work_Scissors_Limit; j++)
            {
                Layer_Name = Type + j;
                if (Tmp_Lines.Exists(o => o.Layer.Name == Layer_Name))
                {
                    do
                    {
                        //直线数据读取
                        for (int zone = 0; zone < 256; zone++)//区块划分总数，支持0-255共256个区块
                        {
                            if (Tmp_Lines.Exists(o => o.Color.R == zone))
                            {
                                for (i = 0; i < Tmp_Lines.Count; i++)
                                {
                                    if ((Tmp_Lines[i].Layer.Name == Layer_Name) && (Tmp_Lines[i].Color.R == zone))
                                    {
                                        Temp_Entity.Path_Type = j;//刀具类型
                                        Temp_Entity.Type = 1;
                                        //起点计算
                                        Temp_Entity.Start_x = Convert.ToDecimal(Tmp_Lines[i].StartPoint.X);
                                        Temp_Entity.Start_y = Convert.ToDecimal(Tmp_Lines[i].StartPoint.Y);
                                        //终点计算
                                        Temp_Entity.End_x = Convert.ToDecimal(Tmp_Lines[i].EndPoint.X);
                                        Temp_Entity.End_y = Convert.ToDecimal(Tmp_Lines[i].EndPoint.Y);

                                        //提交
                                        Temp_List.Add(new Entity_Data(Temp_Entity));
                                        Temp_Entity.Empty();

                                        //移除当前lwpolyline
                                        Tmp_Lines.RemoveAt(i);
                                        i = -1;
                                    }
                                }
                                if (Temp_List.Count > 0)
                                {
                                    //追加至返回结果
                                    Result.Add(new List<Entity_Data>(Temp_List));
                                    Temp_List.Clear();
                                }
                            }                                
                        }                        
                    } while ((Tmp_Lines.Count != 0) && (Tmp_Lines.Min(o => o.Layer.Name) == Layer_Name));//数量大于零、刀具名最小刀具名依然在，只能迭代Zone    
                }        
            }
            //返回结果
            return Result;
        }
        /// <summary>
        /// 处理Dxf 提取多边形数据
        /// </summary>
        /// <param name="dxf"></param>
        /// <returns></returns>
        public List<List<List<Entity_Data>>> Resolve_Cam_LWPolyline(DxfDocument dxf) 
        {
            List<LwPolyline> Tmp_LwPolylines = new List<LwPolyline>();
            List<List<Entity_Data>> Tmp_LwPolylines_List = new List<List<Entity_Data>>(); 
            List<List<List<Entity_Data>>> Result = new List<List<List<Entity_Data>>>();
            List<Entity_Data> Temp_List = new List<Entity_Data>();
            //建立临时Entity数据
            Entity_Data Temp_Entity = new Entity_Data();
            //临时变量
            string Layer_Name = null;
            string Type = "Line";
            int i = 0, j = 0,m =0;
            //提取符合要求的多边形
            for (i = 0; i < dxf.LwPolylines.Count; i++)
            {
                if (dxf.LwPolylines[i].Layer.Name.Contains(Type))
                {
                    Tmp_LwPolylines.Add(dxf.LwPolylines[i]);
                }
            }
            for (m = 0; m < Program.SystemContainer.SysPara.Work_Scissors_Limit; m++)
            {
                Layer_Name = Type + m;
                if (Tmp_LwPolylines.Exists(o => o.Layer.Name == Layer_Name))
                {
                    //LightWeightPolyline 多边形读取
                    do
                    {
                        for (int zone = 0; zone < 256; zone++)//区块划分总数，支持0-255共256个区块
                        {
                            if (Tmp_LwPolylines.Exists(o => o.Color.R == zone))
                            {
                                for (i = 0; i < Tmp_LwPolylines.Count; i++)
                                {
                                    if ((Tmp_LwPolylines[i].Layer.Name == Layer_Name) && (Tmp_LwPolylines[i].Color.R == zone))
                                    {
                                        for (j = 0; j < Tmp_LwPolylines[i].Vertexes.Count; j++)
                                        {
                                            Temp_Entity.Empty();
                                            if (j <= Tmp_LwPolylines[i].Vertexes.Count - 2)
                                            {
                                                if (!(Tmp_LwPolylines[i].Vertexes[j].Position.X == Tmp_LwPolylines[i].Vertexes[j + 1].Position.X) || !(Tmp_LwPolylines[i].Vertexes[j].Position.Y == Tmp_LwPolylines[i].Vertexes[j + 1].Position.Y))
                                                {
                                                    Temp_Entity.Path_Type = m;//刀具类型
                                                    Temp_Entity.Type = 1;//直线插补
                                                                         ///起点计算
                                                    Temp_Entity.Start_x = Convert.ToDecimal(Tmp_LwPolylines[i].Vertexes[j].Position.X);
                                                    Temp_Entity.Start_y = Convert.ToDecimal(Tmp_LwPolylines[i].Vertexes[j].Position.Y);
                                                    Temp_Entity.End_x = Convert.ToDecimal(Tmp_LwPolylines[i].Vertexes[j + 1].Position.X);
                                                    Temp_Entity.End_y = Convert.ToDecimal(Tmp_LwPolylines[i].Vertexes[j + 1].Position.Y);
                                                    //提交进入LwPolylines_Entity_Data
                                                    Temp_List.Add(new Entity_Data(Temp_Entity));
                                                }
                                            }
                                            else if (j == (Tmp_LwPolylines[i].Vertexes.Count - 1))
                                            {
                                                if (!(Tmp_LwPolylines[i].Vertexes[0].Position.X == Tmp_LwPolylines[i].Vertexes[j].Position.X) || !(Tmp_LwPolylines[i].Vertexes[0].Position.Y == Tmp_LwPolylines[i].Vertexes[j].Position.Y))
                                                {
                                                    Temp_Entity.Path_Type = m;//刀具类型
                                                    Temp_Entity.Type = 1;//直线插补
                                                                         ///起点计算
                                                    Temp_Entity.Start_x = Convert.ToDecimal(Tmp_LwPolylines[i].Vertexes[j].Position.X);
                                                    Temp_Entity.Start_y = Convert.ToDecimal(Tmp_LwPolylines[i].Vertexes[j].Position.Y);
                                                    Temp_Entity.End_x = Convert.ToDecimal(Tmp_LwPolylines[i].Vertexes[0].Position.X);
                                                    Temp_Entity.End_y = Convert.ToDecimal(Tmp_LwPolylines[i].Vertexes[0].Position.Y);
                                                    //提交进入LwPolylines_Entity_Data
                                                    Temp_List.Add(new Entity_Data(Temp_Entity));
                                                }
                                            }                                            
                                        }
                                        //移除当前lwpolyline
                                        Tmp_LwPolylines_List.Add(new List<Entity_Data>(Temp_List));
                                        Temp_Entity.Empty();
                                        Temp_List.Clear();
                                        Tmp_LwPolylines.RemoveAt(i);
                                        i = -1;
                                    }
                                }
                                if (Tmp_LwPolylines_List.Count > 0)
                                {
                                    //追加至返回结果
                                    Result.Add(new List<List<Entity_Data>>(Tmp_LwPolylines_List));
                                    Temp_List.Clear();
                                    Tmp_LwPolylines_List.Clear();
                                }
                            }                                
                        }

                    } while ((Tmp_LwPolylines.Count != 0) && (Tmp_LwPolylines.Min(o => o.Layer.Name) == Layer_Name));//数量大于零、刀具名最小刀具名依然在，只能迭代Zone
                }
            }
            //返回结果
            return Result;
        }
        /// <summary>
        /// 处理Dxf 提取Circle数据
        /// </summary>
        /// <param name="dxf"></param>
        /// <returns></returns>
        public List<List<List<Entity_Data>>> Resolve_Cam_Circle(DxfDocument dxf)
        {
            List<Circle> Tmp_Circles = new List<Circle>();//提取待处理数据
            List<List<Entity_Data>> Tmp_Circles_List = new List<List<Entity_Data>>();
            List<List<List<Entity_Data>>> Result = new List<List<List<Entity_Data>>>(); 
            List<Entity_Data> Temp_List = new List<Entity_Data>();
            //建立临时Entity数据
            Entity_Data Temp_Entity = new Entity_Data();
            //临时变量
            string Layer_Name = null;
            string Type = "Drill";
            int i = 0;
            //提取符合要求的多边形
            for (i = 0; i < dxf.Circles.Count; i++)
            {
                if (dxf.Circles[i].Layer.Name.Contains(Type))
                {
                    Tmp_Circles.Add(dxf.Circles[i]);
                }
            }
            //数据处理
            for (int j = 0;j < Program.SystemContainer.SysPara.Work_Scissors_Limit;j++)
            {                
                Layer_Name = Type + j;
                if (Tmp_Circles.Exists(o => o.Layer.Name == Layer_Name))
                {
                    //圆数据读取
                    do
                    {
                        for (int zone = 0; zone < 256; zone++)
                        {
                            if (Tmp_Circles.Exists(o => o.Color.R == zone))
                            {
                                for (i = 0; i < Tmp_Circles.Count; i++)
                                {
                                    if ((Tmp_Circles[i].Layer.Name == Layer_Name) && (Tmp_Circles[i].Color.R == zone))
                                    {
                                        Temp_Entity.Path_Type = j;//刀具类型
                                        Temp_Entity.Type = 3;//圆 
                                        Temp_Entity.Center_x = Convert.ToDecimal(Tmp_Circles[i].Center.X);//圆心计算
                                        Temp_Entity.Center_y = Convert.ToDecimal(Tmp_Circles[i].Center.Y);
                                        Temp_Entity.Circle_radius = Convert.ToDecimal(Tmp_Circles[i].Radius);
                                        Temp_Entity.Start_x = Temp_Entity.Center_x + Temp_Entity.Circle_radius;
                                        Temp_Entity.Start_y = Temp_Entity.Center_y;
                                        Temp_Entity.End_x = Temp_Entity.Center_x + Temp_Entity.Circle_radius;
                                        Temp_Entity.End_y = Temp_Entity.Center_y;
                                        Temp_Entity.Circle_dir = 0;//顺时针画圆                                                       
                                        Temp_Entity.Cir_End_Angle = 0.0m;//起始和终止角度
                                        Temp_Entity.Cir_Start_Angle = 360.0m;
                                        //提交进入Circle_Entity_Data
                                        Temp_List.Add(new Entity_Data(Temp_Entity));
                                        Tmp_Circles_List.Add(new List<Entity_Data>(Temp_List));
                                        Temp_Entity.Empty();
                                        Temp_List.Clear();
                                        //移除当前圆
                                        Tmp_Circles.RemoveAt(i);
                                        i = -1;
                                    }
                                }
                                if (Tmp_Circles_List.Count > 0)//追加当前分区内的加工元素
                                {
                                    //追加至返回结果
                                    Result.Add(new List<List<Entity_Data>>(Tmp_Circles_List));
                                    Temp_List.Clear();
                                    Tmp_Circles_List.Clear();
                                }
                            }
                        }
                    } while ((Tmp_Circles.Count != 0) && (Tmp_Circles.Min(o => o.Layer.Name) == Layer_Name));//数量大于零、刀具名最小刀具名依然在，只能迭代Zone 
                }
            }            
            //返回结果
            return Result;
        }
        /// <summary>
        /// 处理Dxf 提取Mark数据
        /// </summary>
        /// <param name="dxf"></param>
        /// <returns></returns>
        public List<Entity_Data> Resolve_Mark_Point(DxfDocument dxf)
        {
            List<Entity_Data> Result = new List<Entity_Data>();
            //建立临时Entity数据
            Entity_Data Temp_Entity_Data = new Entity_Data();
            //临时变量
            int i = 0;
            //Mark数据读取
            if (dxf.Circles.Count > 0)
            {
                for (i = 0; i < dxf.Circles.Count; i++)
                {
                    if (dxf.Circles[i].Layer.Name == "Mark")  //Mark点 数据收集
                    {
                        //原始数据
                        Temp_Entity_Data.Type = 0;
                        Temp_Entity_Data.Center_x = Convert.ToDecimal(dxf.Circles[i].Center.X);
                        Temp_Entity_Data.Center_y = Convert.ToDecimal(dxf.Circles[i].Center.Y);
                        Temp_Entity_Data.Circle_radius = Convert.ToDecimal(dxf.Circles[i].Radius);
                        //提交进入Circle_Entity_Data
                        Result.Add(new Entity_Data(Temp_Entity_Data));
                        Temp_Entity_Data.Empty();
                    }
                    else if (dxf.Circles[i].Layer.Name == "Mark_Focus")  //Mark点 数据收集
                    {
                        //原始数据
                        Temp_Entity_Data.Type = 10;
                        Temp_Entity_Data.Center_x = Convert.ToDecimal(dxf.Circles[i].Center.X);
                        Temp_Entity_Data.Center_y = Convert.ToDecimal(dxf.Circles[i].Center.Y);
                        Temp_Entity_Data.Circle_radius = Convert.ToDecimal(dxf.Circles[i].Radius);
                        //提交进入Circle_Entity_Data
                        Result.Add(new Entity_Data(Temp_Entity_Data));
                        Temp_Entity_Data.Empty();
                    }
                }
            }
            //返回结果
            return Result;
        }
        /// <summary>
        /// 计算并排序Mark坐标点
        /// </summary>
        /// <param name="Mark_Datas_Collection"></param>
        /// <returns></returns>
        public List<Vector> Mark_Calculate(List<Entity_Data> Mark_Datas_Collection)
        {
            //定义返回值
            List<Vector> Result = new List<Vector>();
            List<Vector> Mark_Datas = new List<Vector>();
            //abstract Mark Point
            for (int i = 0; i < Mark_Datas_Collection.Count; i++)
            {
                if (Mark_Datas_Collection[i].Type == 10)
                {
                    Mark_Datas.Add(new Vector(Mark_Datas_Collection[i].Center_x, Mark_Datas_Collection[i].Center_y));
                }
            }
            //排序
            Mark_Datas = Mark_Datas.OrderBy(a => a.X).ThenByDescending(a => a.Y).ToList();
            //点位输出
            //左下点
            Program.SystemContainer.SysPara.Mark_Dxf1 = Mark_Datas[0];
            Result.Add(new Vector(Mark_Datas[0]));
            //左上点
            Program.SystemContainer.SysPara.Mark_Dxf2 = new Vector(Mark_Datas[1]);
            Result.Add(new Vector(Mark_Datas[1]));
            //右上点
            Program.SystemContainer.SysPara.Mark_Dxf3 = new Vector(Mark_Datas[3]);
            Result.Add(new Vector(Mark_Datas[3]));
            //右下点
            Program.SystemContainer.SysPara.Mark_Dxf4 = new Vector(Mark_Datas[2]);
            Result.Add(new Vector(Mark_Datas[2]));
            //返回结果
            return Result;
        }
        /// <summary>
        /// Entity数据提取完成后，使用mark点计算的仿射变换参数处理数据，获取Dxf在平台坐标系的位置、同时补偿振镜中心与坐标系原点的差值
        /// </summary>
        /// <param name="List_Datas"></param>
        /// <param name="Mark_affinity_Matrices"></param>
        /// <returns></returns>
        public List<List<Entity_Data>> Calibration_List_Entity(List<List<Entity_Data>> List_Datas, Affinity_Matrix Mark_affinity_Matrices)
        {
            //建立变量 
            List<List<Entity_Data>> Result = new List<List<Entity_Data>>();
            List<Entity_Data> Temp_List = new List<Entity_Data>();
            Entity_Data Temp_Data = new Entity_Data();

            foreach (var entity_Datas in List_Datas)
            {
                foreach (var O in entity_Datas)
                {
                    //先清空
                    Temp_Data.Empty();
                    //后赋值
                    Temp_Data = O;
                    //加工起始位置选择
                    if (Program.SystemContainer.SysPara.Calibration_Type == 0) //非Mark点矫正，从原点起始加工
                    {
                        //sin取正  (当前坐标系采用) 已验证
                        //起点计算
                        Temp_Data.Start_x = O.Start_x - Program.SystemContainer.SysPara.Rtc_Org.X;
                        Temp_Data.Start_y = O.Start_y - Program.SystemContainer.SysPara.Rtc_Org.Y;
                        //终点计算
                        Temp_Data.End_x = O.End_x - Program.SystemContainer.SysPara.Rtc_Org.X;
                        Temp_Data.End_y = O.End_y - Program.SystemContainer.SysPara.Rtc_Org.Y;
                        //圆心计算
                        Temp_Data.Center_x = O.Center_x - Program.SystemContainer.SysPara.Rtc_Org.X;
                        Temp_Data.Center_y = O.Center_y - Program.SystemContainer.SysPara.Rtc_Org.Y;
                    }
                    else //Mark点矫正，从矫正位置起始加工
                    {
                        //sin取正  (当前坐标系采用) 已验证
                        //起点计算
                        Temp_Data.Start_x = O.Start_x * Mark_affinity_Matrices.Stretch_X + O.Start_y * Mark_affinity_Matrices.Distortion_X + Mark_affinity_Matrices.Delta_X - Program.SystemContainer.SysPara.Rtc_Org.X;
                        Temp_Data.Start_y = O.Start_y * Mark_affinity_Matrices.Stretch_Y + O.Start_x * Mark_affinity_Matrices.Distortion_Y + Mark_affinity_Matrices.Delta_Y - Program.SystemContainer.SysPara.Rtc_Org.Y;
                        //终点计算
                        Temp_Data.End_x = O.End_x * Mark_affinity_Matrices.Stretch_X + O.End_y * Mark_affinity_Matrices.Distortion_X + Mark_affinity_Matrices.Delta_X - Program.SystemContainer.SysPara.Rtc_Org.X;
                        Temp_Data.End_y = O.End_y * Mark_affinity_Matrices.Stretch_Y + O.End_x * Mark_affinity_Matrices.Distortion_Y + Mark_affinity_Matrices.Delta_Y - Program.SystemContainer.SysPara.Rtc_Org.Y;
                        //圆心计算
                        Temp_Data.Center_x = O.Center_x * Mark_affinity_Matrices.Stretch_X + O.Center_y * Mark_affinity_Matrices.Distortion_X + Mark_affinity_Matrices.Delta_X - Program.SystemContainer.SysPara.Rtc_Org.X;
                        Temp_Data.Center_y = O.Center_y * Mark_affinity_Matrices.Stretch_Y + O.Center_x * Mark_affinity_Matrices.Distortion_Y + Mark_affinity_Matrices.Delta_Y - Program.SystemContainer.SysPara.Rtc_Org.Y;

                    }
                    //追加数据至Temp_List
                    Temp_List.Add(new Entity_Data(Temp_Data));
                    //清空Temp_Data
                    Temp_Data.Empty();
                }
                //追加至结果数据
                Result.Add(new List<Entity_Data>(Temp_List));
                //清空数据
                Temp_List.Clear();
            }

            return Result;
        }
        /// <summary>
        /// Entity数据提取完成后，使用mark点计算的仿射变换参数处理数据，获取Dxf在平台坐标系的位置、同时补偿振镜中心与坐标系原点的差值
        /// </summary>
        /// <param name="List_Datas"></param>
        /// <param name="Mark_affinity_Matrices"></param> 
        /// <returns></returns>
        public List<List<List<Entity_Data>>> Calibration_List_Of_Entity(List<List<List<Entity_Data>>> List_Datas, Affinity_Matrix Mark_affinity_Matrices)
        {
            //建立变量 
            List<List<List<Entity_Data>>> Result = new List<List<List<Entity_Data>>>();
            List<List<Entity_Data>> Temp_Entinity_List = new List<List<Entity_Data>>(); 
            List<Entity_Data> Temp_List = new List<Entity_Data>();
            Entity_Data Temp_Data = new Entity_Data();
            foreach (var list_Entinity in List_Datas)
            {
                foreach (var entity_Datas in list_Entinity)
                {
                    foreach (var O in entity_Datas)
                    {
                        //先清空
                        Temp_Data.Empty();
                        //后赋值
                        Temp_Data = O;

                        //加工起始位置选择
                        if (Program.SystemContainer.SysPara.Calibration_Type == 0) //非Mark点矫正，从原点起始加工
                        {
                            //sin取正  (当前坐标系采用) 已验证
                            //起点计算
                            Temp_Data.Start_x = O.Start_x - Program.SystemContainer.SysPara.Rtc_Org.X;
                            Temp_Data.Start_y = O.Start_y - Program.SystemContainer.SysPara.Rtc_Org.Y;
                            //终点计算
                            Temp_Data.End_x = O.End_x - Program.SystemContainer.SysPara.Rtc_Org.X;
                            Temp_Data.End_y = O.End_y - Program.SystemContainer.SysPara.Rtc_Org.Y;
                            //圆心计算
                            Temp_Data.Center_x = O.Center_x - Program.SystemContainer.SysPara.Rtc_Org.X;
                            Temp_Data.Center_y = O.Center_y - Program.SystemContainer.SysPara.Rtc_Org.Y;
                        }
                        else //Mark点矫正，从矫正位置起始加工
                        {
                            //sin取正  (当前坐标系采用) 已验证
                            //起点计算
                            Temp_Data.Start_x = O.Start_x * Mark_affinity_Matrices.Stretch_X + O.Start_y * Mark_affinity_Matrices.Distortion_X + Mark_affinity_Matrices.Delta_X - Program.SystemContainer.SysPara.Rtc_Org.X;
                            Temp_Data.Start_y = O.Start_y * Mark_affinity_Matrices.Stretch_Y + O.Start_x * Mark_affinity_Matrices.Distortion_Y + Mark_affinity_Matrices.Delta_Y - Program.SystemContainer.SysPara.Rtc_Org.Y;
                            //终点计算
                            Temp_Data.End_x = O.End_x * Mark_affinity_Matrices.Stretch_X + O.End_y * Mark_affinity_Matrices.Distortion_X + Mark_affinity_Matrices.Delta_X - Program.SystemContainer.SysPara.Rtc_Org.X;
                            Temp_Data.End_y = O.End_y * Mark_affinity_Matrices.Stretch_Y + O.End_x * Mark_affinity_Matrices.Distortion_Y + Mark_affinity_Matrices.Delta_Y - Program.SystemContainer.SysPara.Rtc_Org.Y;
                            //圆心计算
                            Temp_Data.Center_x = O.Center_x * Mark_affinity_Matrices.Stretch_X + O.Center_y * Mark_affinity_Matrices.Distortion_X + Mark_affinity_Matrices.Delta_X - Program.SystemContainer.SysPara.Rtc_Org.X;
                            Temp_Data.Center_y = O.Center_y * Mark_affinity_Matrices.Stretch_Y + O.Center_x * Mark_affinity_Matrices.Distortion_Y + Mark_affinity_Matrices.Delta_Y - Program.SystemContainer.SysPara.Rtc_Org.Y;

                        }

                        //追加数据至Temp_List
                        Temp_List.Add(new Entity_Data(Temp_Data));
                        //清空Temp_Data
                        Temp_Data.Empty();
                    }
                    Temp_Entinity_List.Add(new List<Entity_Data>(Temp_List));
                    //清空数据
                    Temp_List.Clear();
                }    
                //追加至结果数据
                Result.Add(new List<List<Entity_Data>>(Temp_Entinity_List));
                //清空数据
                Temp_List.Clear();
                Temp_Entinity_List.Clear();
            }
            return Result;
        }

        /// <summary>
        /// 数据处理 生成整合数据 支持Arc、Line
        /// </summary>
        /// <param name="Cam_Arc_Datas"></param>
        /// <returns></returns>
        public List<List<List<Interpolation_Data>>> Integrate_Cam_Arc(List<List<Entity_Data>> Cam_Arc_Datas) 
        {
            //结果变量
            List<List<List<Interpolation_Data>>> Result = new List<List<List<Interpolation_Data>>>();//结果数据
            List<List<Interpolation_Data>> Temp_Assist_List = new List<List<Interpolation_Data>>();
            List<Interpolation_Data> Assist_Data = new List<Interpolation_Data>(); //辅助运算 用途:提取顺序的衔接和处理 
            //临时变量
            List<Interpolation_Data> Temp_List_Data = new List<Interpolation_Data>();
            Interpolation_Data Temp_Data = new Interpolation_Data();
            int i = 0;
            //遍历待处理的Entity数据
            for (int m = 0; m < Cam_Arc_Datas.Count; m++)
            {
                /*清空数据*/
                Temp_Assist_List.Clear();
                Assist_Data.Clear();
                Temp_List_Data.Clear();
                Temp_Data.Empty();
                /*
                处理Single_Data生成加工数据
                直线插补走刀
                强制生成独立的 List<Interpolation_Data>，并将其写入独立运行数据块 List<List<Interpolation_Data>>
                */
                if (Cam_Arc_Datas[m].Count > 0)
                {
                    //选择任意切入点
                    Temp_Data.Path_Type = Cam_Arc_Datas[m][0].Path_Type;//刀具类型
                    Temp_Data.Type = 1;//直线插补
                    Temp_Data.Work = 10;//10-Gts加工，20-Rtc加工
                    Temp_Data.Lift_flag = 1;//抬刀标志                
                    Temp_Data.End_x = Cam_Arc_Datas[m][0].Start_x;
                    Temp_Data.End_y = Cam_Arc_Datas[m][0].Start_y;

                    //提交进入Assist_Data
                    Assist_Data.Add(new Interpolation_Data(Temp_Data));
                    //整合数据生成代码
                    Temp_List_Data.Add(new Interpolation_Data(Temp_Data));//追加数据
                    Temp_Assist_List.Add(new List<Interpolation_Data>(Temp_List_Data));//追加数据

                    //清空数据
                    Temp_Data.Empty();
                    Temp_List_Data.Clear();

                    //整理数据
                    for (i = 0; i < Cam_Arc_Datas[m].Count; i++)
                    {
                        Temp_Data.Path_Type = Cam_Arc_Datas[m][i].Path_Type;//刀具类型
                        Temp_Data.Lift_flag = 0;//抬刀标志
                        Temp_Data.Work = 10;//10-Gts加工，20-Rtc加工
                        //插补起点坐标
                        Temp_Data.Start_x = Cam_Arc_Datas[m][i].Start_x;
                        Temp_Data.Start_y = Cam_Arc_Datas[m][i].Start_y;
                        //插补终点坐标
                        Temp_Data.End_x = Cam_Arc_Datas[m][i].End_x;
                        Temp_Data.End_y = Cam_Arc_Datas[m][i].End_y;

                        Temp_Data.Type = 2;//圆弧插补                                    
                        Temp_Data.Circle_radius = Cam_Arc_Datas[m][i].Circle_radius;//圆弧半径                                    
                        Temp_Data.Circle_dir = 1;//圆弧方向
                        //圆弧圆心
                        Temp_Data.Center_x = Cam_Arc_Datas[m][i].Center_x;
                        Temp_Data.Center_y = Cam_Arc_Datas[m][i].Center_y;
                        //圆弧插补 圆心坐标 减去 插补起点坐标
                        Temp_Data.Center_Start_x = Temp_Data.Center_x - Temp_Data.Start_x;
                        Temp_Data.Center_Start_y = Temp_Data.Center_y - Temp_Data.Start_y;
                        //计算圆弧角度
                        Temp_Data.Angle = Cam_Arc_Datas[m][i].Cir_Start_Angle - Cam_Arc_Datas[m][i].Cir_End_Angle;

                        //整合数据生成代码 当前结束的封闭图形加工数据
                        Temp_List_Data.Add(new Interpolation_Data(Temp_Data));//追加数据
                        Temp_Assist_List.Add(new List<Interpolation_Data>(Temp_List_Data));//追加数据
                        //清空数据
                        Temp_Data.Empty();
                        Temp_List_Data.Clear();

                        //倒数第一，禁止添加跳刀
                        if (i != Cam_Arc_Datas[m].Count - 1)
                        {
                            //跳刀直接使用直线插补走刀
                            //插补进入新的目标起点
                            Temp_Data.Path_Type = Cam_Arc_Datas[m][i + 1].Path_Type;//刀具类型
                            Temp_Data.Type = 1;//直线插补
                            Temp_Data.Lift_flag = 1;//抬刀标志
                            Temp_Data.Work = 10;//10-Gts加工，20-Rtc加工
                            Temp_Data.End_x = Cam_Arc_Datas[m][i + 1].Start_x;
                            Temp_Data.End_y = Cam_Arc_Datas[m][i + 1].Start_y;
                            //提交进入Arc_Data
                            Assist_Data.Add(new Interpolation_Data(Temp_Data));
                            //整合数据生成代码
                            Temp_List_Data.Add(new Interpolation_Data(Temp_Data));//追加数据
                            Temp_Assist_List.Add(new List<Interpolation_Data>(Temp_List_Data));//追加数据
                            //清空数据
                            Temp_Data.Empty();
                            Temp_List_Data.Clear();
                        }
                    }
                }
                //追加结果
                if (Temp_Assist_List.Count > 0)
                {
                    Result.Add(new List<List<Interpolation_Data>>(Temp_Assist_List));
                    Temp_Assist_List.Clear();
                }
            }

            //返回结果
            return Result;
        }
        /// <summary>
        /// 数据处理 生成整合数据
        /// </summary>
        /// <param name="Cam_Line_Datas"></param>
        /// <returns></returns>
        public List<List<List<Interpolation_Data>>> Integrate_Cam_Line(List<List<Entity_Data>> Cam_Line_Datas)  
        {
            //结果变量
            List<List<List<Interpolation_Data>>> Result = new List<List<List<Interpolation_Data>>>();//结果数据
            List<Entity_Data> Single_Datas = new List<Entity_Data>(); 
            List<List<Interpolation_Data>> Temp_Assist_List = new List<List<Interpolation_Data>>();
            List<Interpolation_Data> Assist_Data = new List<Interpolation_Data>(); //辅助运算 用途:提取顺序的衔接和处理 
            //临时变量
            List<Interpolation_Data> Temp_List_Data = new List<Interpolation_Data>();
            Interpolation_Data Temp_Data = new Interpolation_Data();
            int i = 0;
            int Num = 0;

            //遍历待处理的Entity数据
            for (int m = 0;m < Cam_Line_Datas.Count;m++)
            {
                /*清空数据*/
                Single_Datas.Clear();
                Temp_Assist_List.Clear();
                Assist_Data.Clear();
                Temp_List_Data.Clear();
                Temp_Data.Empty();

                Single_Datas = new List<Entity_Data>(Cam_Line_Datas[m]);//提取数据
                
                /*
                处理Single_Data生成加工数据
                直线插补走刀
                强制生成独立的 List<Interpolation_Data>，并将其写入独立运行数据块 List<List<Interpolation_Data>>
                */
                if (Single_Datas.Count > 0)
                {
                    //选择任意切入点
                    Temp_Data.Path_Type = Single_Datas[0].Path_Type;//刀具类型
                    Temp_Data.Type = 1;//直线插补
                    Temp_Data.Work = 10;//10-Gts加工，20-Rtc加工
                    Temp_Data.Lift_flag = 1;//抬刀标志                
                    Temp_Data.End_x = Single_Datas[0].Start_x;
                    Temp_Data.End_y = Single_Datas[0].Start_y;

                    //提交进入Assist_Data
                    Assist_Data.Add(new Interpolation_Data(Temp_Data));
                    //整合数据生成代码
                    Temp_List_Data.Add(new Interpolation_Data(Temp_Data));//追加数据
                    Temp_Assist_List.Add(new List<Interpolation_Data>(Temp_List_Data));//追加数据

                    //清空数据
                    Temp_Data.Empty();
                    Temp_List_Data.Clear();

                    //整理数据
                    do
                    {
                        Num = Single_Datas.Count;//记录当前Arc_Line_Datas.Count,用于判断数据是否处理完或封闭寻找结束
                        for (i = 0; i < Single_Datas.Count; i++)
                        {
                            if (Differ_Err(Assist_Data[Assist_Data.Count - 1].End_x, Assist_Data[Assist_Data.Count - 1].End_y, Single_Datas[i].End_x, Single_Datas[i].End_y))//当前插补终点是 数据处理终点 同CAD文件规定方向相反
                            {
                                Temp_Data.Path_Type = Single_Datas[i].Path_Type;//刀具类型
                                Temp_Data.Lift_flag = 0;//抬刀标志
                                Temp_Data.Work = 10;//10-Gts加工，20-Rtc加工
                                //插补起点坐标
                                Temp_Data.Start_x = Single_Datas[i].End_x;
                                Temp_Data.Start_y = Single_Datas[i].End_y;
                                //插补终点坐标
                                Temp_Data.End_x = Single_Datas[i].Start_x;
                                Temp_Data.End_y = Single_Datas[i].Start_y;

                                if (Single_Datas[i].Type == 1)//直线
                                {
                                    Temp_Data.Type = 1;//直线插补
                                }
                                else if (Single_Datas[i].Type == 2)//圆弧
                                {
                                    Temp_Data.Type = 2;//圆弧插补                                    
                                    Temp_Data.Circle_radius = Single_Datas[i].Circle_radius;//圆弧半径                                    
                                    Temp_Data.Circle_dir = 0;//圆弧方向
                                    //圆弧圆心
                                    Temp_Data.Center_x = Single_Datas[i].Center_x;
                                    Temp_Data.Center_y = Single_Datas[i].Center_y;
                                    //圆弧插补 圆心坐标 减去 插补起点坐标
                                    Temp_Data.Center_Start_x = Temp_Data.Center_x - Temp_Data.Start_x;
                                    Temp_Data.Center_Start_y = Temp_Data.Center_y - Temp_Data.Start_y;
                                    //计算圆弧角度
                                    Temp_Data.Angle = (Single_Datas[i].Cir_End_Angle - Single_Datas[i].Cir_Start_Angle);
                                    
                                }

                                //提交进入Arc_Data
                                Assist_Data.Add(new Interpolation_Data(Temp_Data));

                                //整合数据生成代码
                                Temp_List_Data.Add(new Interpolation_Data(Temp_Data));//追加数据

                                //清空数据
                                Temp_Data.Empty();

                                //删除当前的Entity数据
                                Single_Datas.RemoveAt(i);
                                break;
                            }
                            else if (Differ_Err(Assist_Data[Assist_Data.Count - 1].End_x, Assist_Data[Assist_Data.Count - 1].End_y, Single_Datas[i].Start_x, Single_Datas[i].Start_y)) //当前插补终点是 数据处理起点 同CAD文件规定方向相同
                            {
                                Temp_Data.Path_Type = Single_Datas[i].Path_Type;//刀具类型
                                Temp_Data.Lift_flag = 0;//抬刀标志
                                Temp_Data.Work = 10;//10-Gts加工，20-Rtc加工
                                //插补起点坐标
                                Temp_Data.Start_x = Single_Datas[i].Start_x;
                                Temp_Data.Start_y = Single_Datas[i].Start_y;
                                //插补终点坐标
                                Temp_Data.End_x = Single_Datas[i].End_x;
                                Temp_Data.End_y = Single_Datas[i].End_y;

                                if (Single_Datas[i].Type == 1)//直线
                                {
                                    Temp_Data.Type = 1;//直线插补 
                                }
                                else if (Single_Datas[i].Type == 2)//圆弧
                                {
                                    Temp_Data.Type = 2;//圆弧插补                                    
                                    Temp_Data.Circle_radius = Single_Datas[i].Circle_radius;//圆弧半径                                    
                                    Temp_Data.Circle_dir = 1;//圆弧方向
                                    //圆弧圆心
                                    Temp_Data.Center_x = Single_Datas[i].Center_x;
                                    Temp_Data.Center_y = Single_Datas[i].Center_y;
                                    //圆弧插补 圆心坐标 减去 插补起点坐标
                                    Temp_Data.Center_Start_x = Temp_Data.Center_x - Temp_Data.Start_x;
                                    Temp_Data.Center_Start_y = Temp_Data.Center_y - Temp_Data.Start_y;
                                    //计算圆弧角度
                                    Temp_Data.Angle = Single_Datas[i].Cir_Start_Angle - Single_Datas[i].Cir_End_Angle; 
                                }

                                //提交进入Arc_Data
                                Assist_Data.Add(new Interpolation_Data(Temp_Data));
                                //整合数据生成代码
                                Temp_List_Data.Add(new Interpolation_Data(Temp_Data));//追加数据                                                                                      
                                Temp_Data.Empty();//清空数据

                                //删除当前的Entity数据
                                Single_Datas.RemoveAt(i);
                                break;
                            }
                        }

                        //寻找结束点失败，意味着重新开始新的 线段或圆弧
                        if ((Single_Datas.Count != 0) && (Num != 0) && (Num == Single_Datas.Count))
                        {
                            //整合数据生成代码 当前结束的封闭图形加工数据
                            Temp_Assist_List.Add(new List<Interpolation_Data>(Temp_List_Data));//追加数据
                            //清空数据
                            Temp_Data.Empty();
                            Temp_List_Data.Clear();

                            //跳刀直接使用直线插补走刀
                            //插补进入新的目标起点
                            Temp_Data.Path_Type = Single_Datas[0].Path_Type;//刀具类型
                            Temp_Data.Type = 1;//直线插补
                            Temp_Data.Lift_flag = 1;//抬刀标志
                            Temp_Data.Work = 10;//10-Gts加工，20-Rtc加工
                            Temp_Data.End_x = Single_Datas[0].Start_x;
                            Temp_Data.End_y = Single_Datas[0].Start_y;
                            //提交进入Arc_Data
                            Assist_Data.Add(new Interpolation_Data(Temp_Data));
                            //整合数据生成代码
                            Temp_List_Data.Add(new Interpolation_Data(Temp_Data));//追加数据
                            Temp_Assist_List.Add(new List<Interpolation_Data>(Temp_List_Data));//追加数据

                            //清空数据
                            Temp_Data.Empty();
                            Temp_List_Data.Clear();
                        }
                        else if ((Single_Datas.Count == 0) && (Num == 1))
                        {
                            //整合数据生成代码 当前结束的封闭图形加工数据
                            Temp_Assist_List.Add(new List<Interpolation_Data>(Temp_List_Data));//追加数据                                                                                               
                            Temp_List_Data.Clear();//清空数据
                        }
                    } while (Single_Datas.Count > 0);//实体Line_Arc数据未清空完
                }
                //追加结果
                if (Temp_Assist_List.Count>0)
                {
                    Result.Add(new List<List<Interpolation_Data>>(Temp_Assist_List));
                    Temp_Assist_List.Clear();
                }
            }
            
            //返回结果
            return Result;
        }


        /// <summary>
        /// 数据处理 生成整合数据 支持LWPolyline
        /// </summary>
        /// <param name="Cam_LWPolyLine_Datas"></param>
        /// <returns></returns>
        public List<List<List<Interpolation_Data>>> Integrate_Cam_LWPolyLine(List<List<List<Entity_Data>>> Cam_LWPolyLine_Datas)
        {
            //结果变量
            List<List<List<Interpolation_Data>>> Result = new List<List<List<Interpolation_Data>>>();//结果数据
            List<List<Interpolation_Data>> Temp_Assist_List = new List<List<Interpolation_Data>>();
            //临时变量
            List<Interpolation_Data> Temp_List_Data = new List<Interpolation_Data>();
            Interpolation_Data Temp_Data = new Interpolation_Data();
            int i = 0;
            int j = 0;
            //分区
            for (int m = 0;m < Cam_LWPolyLine_Datas.Count;m++)
            {
                //分区内加工数据
                if (Cam_LWPolyLine_Datas[m].Count>0)
                {
                    //选择任意切入点
                    Temp_Data.Path_Type = Cam_LWPolyLine_Datas[m][0][0].Path_Type;//刀具类型
                    Temp_Data.Type = 1;//直线插补
                    Temp_Data.Work = 10;//10-Gts加工，20-Rtc加工
                    Temp_Data.Lift_flag = 1;//抬刀标志
                    Temp_Data.End_x = Cam_LWPolyLine_Datas[m][0][0].Start_x;
                    Temp_Data.End_y = Cam_LWPolyLine_Datas[m][0][0].Start_y;
                    //整合数据生成代码
                    Temp_List_Data.Add(new Interpolation_Data(Temp_Data));//追加数据
                    Temp_Assist_List.Add(new List<Interpolation_Data>(Temp_List_Data));//追加数据

                    //清空数据
                    Temp_Data.Empty();
                    Temp_List_Data.Clear();

                    //整理数据
                    for (i = 0; i < Cam_LWPolyLine_Datas[m].Count; i++)
                    {
                        for (j = 0; j < Cam_LWPolyLine_Datas[m][i].Count; j++)
                        {
                            Temp_Data.Type = 1;//直线插补
                            Temp_Data.Lift_flag = 0;//抬刀标志
                            Temp_Data.Work = 10;//10-Gts加工，20-Rtc加工
                            Temp_Data.Start_x = Cam_LWPolyLine_Datas[m][i][j].Start_x;
                            Temp_Data.Start_y = Cam_LWPolyLine_Datas[m][i][j].Start_y;
                            Temp_Data.End_x = Cam_LWPolyLine_Datas[m][i][j].End_x;
                            Temp_Data.End_y = Cam_LWPolyLine_Datas[m][i][j].End_y;
                            //整合数据生成代码
                            Temp_List_Data.Add(new Interpolation_Data(Temp_Data));//追加数据
                            Temp_Data.Empty(); //清空数据
                        }
                        Temp_Assist_List.Add(new List<Interpolation_Data>(Temp_List_Data));//追加数据
                        //清空数据
                        Temp_Data.Empty();
                        Temp_List_Data.Clear();

                        if (i != Cam_LWPolyLine_Datas[m].Count - 1)//不是最后一个封闭图形
                        {
                            //跳刀直接使用直线插补走刀
                            //插补进入新的目标起点
                            Temp_Data.Path_Type = Cam_LWPolyLine_Datas[m][i + 1][0].Path_Type;//刀具类型
                            Temp_Data.Type = 1;//直线插补
                            Temp_Data.Lift_flag = 1;//抬刀标志
                            Temp_Data.Work = 10;//10-Gts加工，20-Rtc加工
                            Temp_Data.End_x = Cam_LWPolyLine_Datas[m][i + 1][0].Start_x;
                            Temp_Data.End_y = Cam_LWPolyLine_Datas[m][i + 1][0].Start_y;
                            //整合数据生成代码
                            Temp_List_Data.Add(new Interpolation_Data(Temp_Data));//追加数据
                            Temp_Assist_List.Add(new List<Interpolation_Data>(Temp_List_Data));//追加数据
                            //清空数据
                            Temp_Data.Empty();
                            Temp_List_Data.Clear();
                        }
                    }

                    //追加数据
                    Result.Add(new List<List<Interpolation_Data>>(Temp_Assist_List));
                }

                //清空数据
                Temp_Data.Empty();
                Temp_Assist_List.Clear();
                Temp_List_Data.Clear();
            }
            //返回结果
            return Result;
        }

        /// <summary>
        /// 数据处理 生成整合数据 支持Circle
        /// </summary>
        /// <param name="Circle_Datas"></param>
        /// <returns></returns>
        public List<List<List<Interpolation_Data>>> Integrate_Cam_Circle(List<List<List<Entity_Data>>> Cam_Drill_Datas) 
        {
            //结果变量
            List<List<List<Interpolation_Data>>> Result = new List<List<List<Interpolation_Data>>>();//结果数据
            List<List<Interpolation_Data>> Temp_Assist_List = new List<List<Interpolation_Data>>();
            List<Interpolation_Data> Assist_Data = new List<Interpolation_Data>(); //辅助运算 用途:提取顺序的衔接和处理
            //临时变量
            List<Interpolation_Data> Temp_List_Data = new List<Interpolation_Data>();
            Interpolation_Data Temp_Data = new Interpolation_Data();
            int i = 0;
            //初始清除
            Temp_Assist_List.Clear();
            Assist_Data.Clear();
            Temp_List_Data.Clear();
            Temp_Data.Empty();

            for (int m = 0;m < Cam_Drill_Datas.Count;m++)
            {
                /*清空数据*/
                Temp_Assist_List.Clear();
                Assist_Data.Clear();
                Temp_List_Data.Clear();
                Temp_Data.Empty();
                /*
                处理Circle生成加工数据 初始数据  属于切入加工起点，故强制使用
                同一层必然是同一把刀同一个分区
                直线插补走刀
                强制生成独立的 List<Interpolation_Data>，并将其写入独立运行数据块 List<List<Interpolation_Data>>
                */
                
                if (Cam_Drill_Datas[m].Count > 0)
                {
                    //启用刀具判断进行尺度修饰
                    Tech_Parameter tmp_Parameter = new Tech_Parameter();
                    //刀具补偿类型 0-不补偿、1-钻孔 -Radius、2-落料 +Radius
                    decimal Radius = 0.0m;//定义刀具补偿半径
                    foreach (var a in Program.SystemContainer.Drill_Scissor)
                    {
                        if (a.Scissors_Type == Cam_Drill_Datas[m][0][0].Path_Type)
                        {
                            if (a.Cutter_Type == 0)
                            {
                                Radius = 0.0m;
                            }
                            else if (a.Cutter_Type == 1)
                            {
                                Radius = -a.Cutter_Radius;
                            }
                            else if (a.Cutter_Type == 2)
                            {
                                Radius = a.Cutter_Radius;
                            }
                        }
                    }
                    //选择任意切入点
                    Temp_Data.Path_Type = Cam_Drill_Datas[m][0][0].Path_Type;//刀具类型
                    Temp_Data.Type = 1;//直线插补
                    Temp_Data.Work = 10;//10-Gts加工，20-Rtc加工
                    Temp_Data.Lift_flag = 1;//抬刀标志
                    Temp_Data.End_x = Cam_Drill_Datas[m][0][0].End_x;
                    Temp_Data.End_y = Cam_Drill_Datas[m][0][0].End_y;

                    //整合数据生成代码
                    Temp_List_Data.Add(new Interpolation_Data(Temp_Data));//追加数据
                    Temp_Assist_List.Add(new List<Interpolation_Data>(Temp_List_Data));//追加数据

                    //清空数据
                    Temp_Data.Empty();
                    Temp_List_Data.Clear();

                    //整理数据
                    for (i = 0; i < Cam_Drill_Datas[m].Count; i++)
                    {
                        Temp_Data.Path_Type = Cam_Drill_Datas[m][i][0].Path_Type;//刀具类型
                        Temp_Data.Type = 3;//圆形插补
                        Temp_Data.Lift_flag = 0;//抬刀标志
                        Temp_Data.Work = 10;//10-Gts加工，20-Rtc加工
                            
                        //圆形半径
                        Temp_Data.Circle_radius = Cam_Drill_Datas[m][i][0].Circle_radius + Radius;
                        //圆形起点坐标
                        Temp_Data.Start_x = Cam_Drill_Datas[m][i][0].End_x + Radius;
                        Temp_Data.Start_y = Cam_Drill_Datas[m][i][0].End_y;
                        //圆形终点坐标
                        Temp_Data.End_x = Cam_Drill_Datas[m][i][0].End_x + Radius;
                        Temp_Data.End_y = Cam_Drill_Datas[m][i][0].End_y;
                        //圆心坐标
                        Temp_Data.Center_x = Cam_Drill_Datas[m][i][0].Center_x;
                        Temp_Data.Center_y = Cam_Drill_Datas[m][i][0].Center_y;
                        //圆弧插补 圆心坐标 减去 插补起点坐标
                        Temp_Data.Center_Start_x = Temp_Data.Center_x - Temp_Data.End_x;
                        Temp_Data.Center_Start_y = Temp_Data.Center_y - Temp_Data.End_y;
                        //圆形方向
                        Temp_Data.Circle_dir = Cam_Drill_Datas[m][i][0].Circle_dir;

                        //整合数据生成代码
                        Temp_List_Data.Add(new Interpolation_Data(Temp_Data));//追加数据
                        Temp_Assist_List.Add(new List<Interpolation_Data>(Temp_List_Data));//追加数据
                        //清空数据
                        Temp_Data.Empty();
                        Temp_List_Data.Clear();

                        if (i != Cam_Drill_Datas[m].Count -1)
                        {
                            //跳刀直接使用直线插补走刀
                            //插补进入新的目标起点
                            Temp_Data.Path_Type = Cam_Drill_Datas[m][i+1][0].Path_Type;//刀具类型
                            Temp_Data.Type = 1;//直线插补
                            Temp_Data.Lift_flag = 1;//抬刀标志
                            Temp_Data.Work = 10;//10-Gts加工，20-Rtc加工
                            Temp_Data.End_x = Cam_Drill_Datas[m][i + 1][0].End_x;
                            Temp_Data.End_y = Cam_Drill_Datas[m][i + 1][0].End_y;

                            //整合数据生成代码
                            Temp_List_Data.Add(new Interpolation_Data(Temp_Data));//追加数据
                            Temp_Assist_List.Add(new List<Interpolation_Data>(Temp_List_Data));//追加数据

                            //清空数据
                            Temp_Data.Empty();
                            Temp_List_Data.Clear();
                        }
                    }
                }

                //追加结果
                if (Temp_Assist_List.Count > 0)
                {
                    Result.Add(new List<List<Interpolation_Data>>(Temp_Assist_List));
                    Temp_Assist_List.Clear();
                }
            }      

            //返回结果
            return Result;
        }

        /// <summary>
        /// 判断两点是否同一点
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <returns></returns>
        private bool Differ_Err(decimal x1, decimal y1, decimal x2, decimal y2)
        {
            if (Math.Sqrt((double)((x1 - x2) * (x1 - x2)) + (double)((y1 - y2) * (y1 - y2))) <= (double)Program.SystemContainer.SysPara.Pos_Tolerance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 生成完整的Cam刀具加工数据 0-LINE,1-CIRCLE 
        /// </summary>
        /// <param name="In_Data"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<List<List<Interpolation_Data>>> Separate_Rtc_Gts_Cam(List<List<List<Interpolation_Data>>> In_Data, int type)
        {
            //结果变量
            List<List<List<Interpolation_Data>>> Result = new List<List<List<Interpolation_Data>>>();//返回值
            List<List<Interpolation_Data>> Temp_List = new List<List<Interpolation_Data>>();//中间过程

            //数据处理
            for (int i = 0; i < In_Data.Count; i++)
            {
                Temp_List.Clear();
                Temp_List = new List<List<Interpolation_Data>>(Separate_Rtc_Gts_Limit(In_Data[i], type));
                Result.Add(new List<List<Interpolation_Data>>(Temp_List));
            }
            //结果反馈
            return Result;
        }

        /// <summary>
        /// 将加工数据切分为RTC和GTS加工  该函数的对象是：直线、圆弧和整圆  0-LINE,1-CIRCLE 
        /// </summary>
        /// <param name="In_Data"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<List<Interpolation_Data>> Separate_Rtc_Gts_Limit(List<List<Interpolation_Data>> In_Data ,int type)
        {

            //结果变量
            List<List<Interpolation_Data>> Result = new List<List<Interpolation_Data>>();//返回值
            List<Interpolation_Data> Temp_Interpolation_List_Data = new List<Interpolation_Data>();//二级层
            Interpolation_Data Temp_Data = new Interpolation_Data();//一级层  
            decimal Delta_X = 0, Delta_Y = 0;//X、Y坐标极值差值
            decimal Rtc_Cal_X = 0, Rtc_Cal_Y = 0;//RTC坐标计算基准                  
            int i = 0;
            int j = 0;
            int m = 0;
            //初始清除
            Result.Clear();
            Temp_Interpolation_List_Data.Clear();
            Temp_Data.Empty();
            //计算极值范围
            Extreme Range_XY = new Extreme();
            if (type == 0)//直线
            {
                Range_XY = new Extreme(Cal_End_Max_Min(In_Data));
            }
            else//圆弧和圆
            {
                Range_XY = new Extreme(Cal_Center_Max_Min(In_Data));
            }
            //数据处理和提取
            if ((Range_XY.Delta_X > Program.SystemContainer.SysPara.Rtc_Limit.X) || (Range_XY.Delta_Y > Program.SystemContainer.SysPara.Rtc_Limit.Y)) //加工覆盖范围之外，强制拆分，GTS平台移动配合RTC完成加工
            {
                //数据处理部分
                for (i = 0; i < In_Data.Count; i++)
                {
                    //清除数据
                    Temp_Interpolation_List_Data.Clear();
                    if ((In_Data[i].Count > 0) && (In_Data[i].Count == 1)) //二级层，整合元素数量==1
                    {
                        for (j = 0; j < In_Data[i].Count; j++)
                        {
                            //直线、整圆拆分，整理成GTS和RTC加工数据
                            if (In_Data[i][j].Type == 1)//直线
                            {
                                if (In_Data[i][j].Lift_flag == 1)//抬刀标志
                                {
                                    Result.Add(new List<Interpolation_Data>(In_Data[i]));//直接复制进入返回结果数值
                                }
                                else
                                {
                                    //数据计算
                                    Delta_X = Convert.ToDecimal(Math.Abs(In_Data[i][j].Start_x - In_Data[i][j].End_x));//X坐标极值范围
                                    Delta_Y = Convert.ToDecimal(Math.Abs(In_Data[i][j].Start_y - In_Data[i][j].End_y));//Y坐标极值范围
                                                                                                                       //获取该直线中心
                                    Rtc_Cal_X = (In_Data[i][j].Start_x + In_Data[i][j].End_x) / 2m;//RTC坐标X基准
                                    Rtc_Cal_Y = (In_Data[i][j].Start_y + In_Data[i][j].End_y) / 2m;//RTC坐标Y基准
                                                                                                   //范围判断
                                    if ((Delta_X > Program.SystemContainer.SysPara.Rtc_Limit.X) || (Delta_Y > Program.SystemContainer.SysPara.Rtc_Limit.Y))//X、Y坐标极值范围大于等于48mm，由GTS加工，否则由RTC加工
                                    {
                                        Result.Add(new List<Interpolation_Data>(In_Data[i]));//直接复制进入返回结果数值
                                    }
                                    else
                                    {
                                        //数据清空
                                        Temp_Data.Empty();
                                        //数据赋值
                                        Temp_Data = In_Data[i][j];
                                        //强制抬刀标志：0
                                        Temp_Data.Lift_flag = 0;
                                        //强制加工类型为RTC
                                        Temp_Data.Work = 20;
                                        //RTC加工，GTS平台配合坐标
                                        if (j == 0)
                                        {
                                            //GTS平台配合坐标
                                            Temp_Data.Gts_x = Rtc_Cal_X;
                                            Temp_Data.Gts_y = Rtc_Cal_Y;
                                            //Rtc定位 激光加工起点坐标
                                            Temp_Data.Rtc_x = In_Data[i][j].Start_x - Rtc_Cal_X;
                                            Temp_Data.Rtc_y = In_Data[i][j].Start_y - Rtc_Cal_Y;
                                        }
                                        //RTC mark_abs直线
                                        Temp_Data.Type = 15;
                                        //坐标转换 将坐标转换为RTC坐标系坐标
                                        Temp_Data.Start_x = In_Data[i][j].Start_x - Rtc_Cal_X;
                                        Temp_Data.Start_y = In_Data[i][j].Start_y - Rtc_Cal_Y;
                                        Temp_Data.End_x = In_Data[i][j].End_x - Rtc_Cal_X;
                                        Temp_Data.End_y = In_Data[i][j].End_y - Rtc_Cal_Y;
                                        //追加修改的数据
                                        Temp_Interpolation_List_Data.Add(new Interpolation_Data(Temp_Data));
                                        Result.Add(new List<Interpolation_Data>(Temp_Interpolation_List_Data));
                                    }
                                }
                            }
                            else if (In_Data[i][j].Type == 2)// 圆弧
                            {
                                if (In_Data[i][j].Circle_radius >= 20)//圆弧半径大于等于20mm
                                {
                                    Result.Add(new List<Interpolation_Data>(In_Data[i]));//直接复制进入返回结果数值
                                }
                                else
                                {
                                    //生成Rtc加工数据
                                    Temp_Data = In_Data[i][j];
                                    //RTC arc_abs圆弧
                                    Temp_Data.Type = 11;
                                    //强制抬刀标志：0
                                    Temp_Data.Lift_flag = 0;
                                    //强制加工类型为RTC
                                    Temp_Data.Work = 20;
                                    //RTC加工，GTS平台配合坐标
                                    Temp_Data.Gts_x = In_Data[i][j].Center_x;
                                    Temp_Data.Gts_y = In_Data[i][j].Center_y;
                                    //Rtc定位 激光加工起点坐标
                                    Temp_Data.Rtc_x = In_Data[i][j].Start_x - Temp_Data.Gts_x;
                                    Temp_Data.Rtc_y = In_Data[i][j].Start_y - Temp_Data.Gts_y;
                                    //RTC 圆弧加工圆心坐标转换
                                    Temp_Data.Center_x = In_Data[i][j].Center_x - Temp_Data.Gts_x;
                                    Temp_Data.Center_y = In_Data[i][j].Center_y - Temp_Data.Gts_y;
                                    //坐标转换 将坐标转换为RTC坐标系坐标
                                    Temp_Data.Start_x = In_Data[i][j].Start_x - Temp_Data.Gts_x;
                                    Temp_Data.Start_y = In_Data[i][j].Start_y - Temp_Data.Gts_y;
                                    Temp_Data.End_x = In_Data[i][j].End_x - Temp_Data.Gts_x;
                                    Temp_Data.End_y = In_Data[i][j].End_y - Temp_Data.Gts_y;
                                    //追加修改的数据
                                    Temp_Interpolation_List_Data.Add(new Interpolation_Data(Temp_Data));
                                    Result.Add(new List<Interpolation_Data>(Temp_Interpolation_List_Data));
                                    //清空数据
                                    Temp_Data.Empty();
                                    Temp_Interpolation_List_Data.Clear();

                                    ////再追加一组直线插补，让GTS平台跳至该圆弧终点
                                    //Temp_Data.Scissor = In_Data[i][j].Scissor;
                                    //Temp_Data.Type = 1;//直线插补
                                    //Temp_Data.Work = 10;//10-Gts加工，20-Rtc加工
                                    //Temp_Data.Lift_flag = 1;//抬刀标志
                                    //Temp_Data.Start_x = In_Data[i][j].Center_x;
                                    //Temp_Data.Start_y = In_Data[i][j].Center_x;
                                    //Temp_Data.End_x = In_Data[i][j].End_x;
                                    //Temp_Data.End_y = In_Data[i][j].End_y;

                                    ////追加修改的数据
                                    //Temp_Interpolation_List_Data.Add(new Interpolation_Data(Temp_Data));
                                    //Result.Add(new List<Interpolation_Data>(Temp_Interpolation_List_Data));
                                    ////清空数据
                                    //Temp_Data.Empty();
                                    //Temp_Interpolation_List_Data.Clear();
                                }
                            }
                            else if (In_Data[i][j].Type == 3)//整圆
                            {
                                //判断整圆大小
                                if (In_Data[i][j].Circle_radius >= 24) //整圆半径大于24mm，GTS加工
                                {
                                    Result.Add(new List<Interpolation_Data>(In_Data[i]));//直接复制进入返回结果数值
                                }
                                else //整圆半径小于24mm，RTC加工
                                {
                                    //数据赋值
                                    Temp_Data = In_Data[i][j];
                                    //RTC arc_abs圆弧
                                    Temp_Data.Type = 11;
                                    //强制抬刀标志：0
                                    Temp_Data.Lift_flag = 0;
                                    //强制加工类型为RTC
                                    Temp_Data.Work = 20;
                                    //RTC加工，GTS平台配合坐标
                                    Temp_Data.Gts_x = In_Data[i][j].Center_x;
                                    Temp_Data.Gts_y = In_Data[i][j].Center_y;
                                    //RTC 圆弧加工圆心坐标转换
                                    Temp_Data.Center_x = 0;
                                    Temp_Data.Center_y = 0;
                                    //RTC加工终点
                                    Temp_Data.Start_x = Temp_Data.Center_x;
                                    Temp_Data.Start_y = Temp_Data.Center_y + In_Data[i][j].Circle_radius;
                                    Temp_Data.End_x = Temp_Data.Center_x;
                                    Temp_Data.End_y = Temp_Data.Center_y + In_Data[i][j].Circle_radius;
                                    //RTC加工整圆角度
                                    // arc angle in ° as a 64 - bit IEEE floating point value
                                    // (positive angle values correspond to clockwise angles);
                                    // allowed range: [–3600.0° … +3600.0°] (±10 full circles);
                                    // out-of-range values will be edge-clipped.
                                    Temp_Data.Angle = 370;//这个参数得看RTC手册，整圆的旋转角度

                                    //Rtc定位 激光加工起点坐标
                                    Temp_Data.Rtc_x = Temp_Data.Center_x;
                                    Temp_Data.Rtc_y = Temp_Data.Center_y + In_Data[i][j].Circle_radius;

                                    //追加修改的数据
                                    Temp_Interpolation_List_Data.Add(new Interpolation_Data(Temp_Data));
                                }
                                Result.Add(new List<Interpolation_Data>(Temp_Interpolation_List_Data));
                            }
                        }
                    }
                    else if (In_Data[i].Count >= 2) //二级层，整合元素数量大于等于2，说明封闭图形
                    {
                        //整合数据加工范围判断 取Max Min,Delta_X,Delta_Y长度均在50mm以内
                        //数据计算
                        Delta_X = Convert.ToDecimal(Math.Abs(In_Data[i].Max(o => o.End_x) - In_Data[i].Min(o => o.End_x)));//X坐标极值范围
                        Delta_Y = Convert.ToDecimal(Math.Abs(In_Data[i].Max(o => o.End_y) - In_Data[i].Min(o => o.End_y)));//Y坐标极值范围
                        //获取封闭图形中心坐标
                        Rtc_Cal_X = (In_Data[i].Max(o => o.End_x) + In_Data[i].Min(o => o.End_x)) / 2m;//RTC坐标X基准
                        Rtc_Cal_Y = (In_Data[i].Max(o => o.End_y) + In_Data[i].Min(o => o.End_y)) / 2m;//RTC坐标Y基准
                        //范围判断
                        if ((Delta_X > Program.SystemContainer.SysPara.Rtc_Limit.X) || (Delta_Y > Program.SystemContainer.SysPara.Rtc_Limit.Y))//X、Y坐标极值范围大于等于限制范围，由GTS加工，否则由RTC加工
                        {
                            //考虑圆弧半径大小，Radius >= 20mm由Gts加工，Radius < 20mm由Rtc加工
                            for (m = 0; m < In_Data[i].Count; m++)
                            {
                                //数据清空
                                Temp_Data.Empty();
                                //数据赋值
                                Temp_Data = In_Data[i][m];
                                //当前数据类型判断
                                if (Temp_Data.Type == 1)//直线
                                {
                                    //追加修改的数据
                                    Temp_Interpolation_List_Data.Add(new Interpolation_Data(Temp_Data));
                                }
                                else if (Temp_Data.Type == 2)//圆弧
                                {
                                    if (Temp_Data.Circle_radius >= 20)//圆弧半径大于等于20mm
                                    {
                                        //追加修改的数据
                                        Temp_Interpolation_List_Data.Add(new Interpolation_Data(Temp_Data));
                                    }
                                    else//圆弧半径小于20mm
                                    {
                                        //从起始到当前
                                        if (Temp_Interpolation_List_Data.Count > 0)
                                        {
                                            Result.Add(new List<Interpolation_Data>(Temp_Interpolation_List_Data));
                                        }
                                        //清空数据  为生成Rtc数据做准备
                                        Temp_Interpolation_List_Data.Clear();

                                        //先计算圆心与切点的直线
                                        if (m > 0)
                                        {
                                            //生成Rtc加工数据
                                            Temp_Data.Path_Type = In_Data[i][m].Path_Type;
                                            //RTC arc_abs圆弧
                                            Temp_Data.Type = 11;
                                            //强制抬刀标志：0
                                            Temp_Data.Lift_flag = 0;
                                            //强制加工类型为RTC
                                            Temp_Data.Work = 20;
                                            //RTC加工，GTS平台配合坐标
                                            Temp_Data.Gts_x = In_Data[i][m - 1].End_x;
                                            Temp_Data.Gts_y = In_Data[i][m - 1].End_y;
                                            //Rtc定位 激光加工起点坐标
                                            Temp_Data.Rtc_x = 0;
                                            Temp_Data.Rtc_y = 0;
                                            //RTC 圆弧加工圆心坐标转换
                                            Temp_Data.Center_x = In_Data[i][m].Center_x - Temp_Data.Gts_x;
                                            Temp_Data.Center_y = In_Data[i][m].Center_y - Temp_Data.Gts_y;
                                            //坐标转换 将坐标转换为RTC坐标系坐标
                                            Temp_Data.Start_x = In_Data[i][m].Start_x - Temp_Data.Gts_x;
                                            Temp_Data.Start_y = In_Data[i][m].Start_y - Temp_Data.Gts_y;
                                            Temp_Data.End_x = In_Data[i][m].End_x - Temp_Data.Gts_x;
                                            Temp_Data.End_y = In_Data[i][m].End_y - Temp_Data.Gts_y;
                                            //追加修改的数据
                                            Temp_Interpolation_List_Data.Add(new Interpolation_Data(Temp_Data));
                                            Result.Add(new List<Interpolation_Data>(Temp_Interpolation_List_Data));
                                            //清空数据
                                            Temp_Data.Empty();
                                            Temp_Interpolation_List_Data.Clear();

                                            //再追加一组直线插补，让GTS平台跳至该圆弧终点
                                            Temp_Data.Path_Type = In_Data[i][m].Path_Type;
                                            Temp_Data.Type = 1;//直线插补
                                            Temp_Data.Work = 10;//10-Gts加工，20-Rtc加工
                                            Temp_Data.Lift_flag = 1;//抬刀标志
                                            Temp_Data.Start_x = In_Data[i][m - 1].End_x;
                                            Temp_Data.Start_y = In_Data[i][m - 1].End_y;
                                            Temp_Data.End_x = In_Data[i][m].End_x;
                                            Temp_Data.End_y = In_Data[i][m].End_y;

                                            //追加修改的数据
                                            Temp_Interpolation_List_Data.Add(new Interpolation_Data(Temp_Data));
                                            Result.Add(new List<Interpolation_Data>(Temp_Interpolation_List_Data));
                                            //清空数据
                                            Temp_Data.Empty();
                                            Temp_Interpolation_List_Data.Clear();

                                        }
                                        else//肯定有切入点
                                        {
                                            if (i > 0)
                                            {

                                                //生成Rtc加工数据
                                                Temp_Data.Path_Type = In_Data[i][m].Path_Type;
                                                //RTC arc_abs圆弧
                                                Temp_Data.Type = 11;
                                                //强制抬刀标志：0
                                                Temp_Data.Lift_flag = 0;
                                                //强制加工类型为RTC
                                                Temp_Data.Work = 20;
                                                //RTC加工，GTS平台配合坐标
                                                Temp_Data.Gts_x = In_Data[i - 1][In_Data[i - 1].Count - 1].End_x;
                                                Temp_Data.Gts_y = In_Data[i - 1][In_Data[i - 1].Count - 1].End_y;
                                                //Rtc定位 激光加工起点坐标
                                                Temp_Data.Rtc_x = 0;
                                                Temp_Data.Rtc_y = 0;
                                                //RTC 圆弧加工圆心坐标转换
                                                Temp_Data.Center_x = In_Data[i][m].Center_x - Temp_Data.Gts_x;
                                                Temp_Data.Center_y = In_Data[i][m].Center_y - Temp_Data.Gts_y;
                                                //坐标转换 将坐标转换为RTC坐标系坐标
                                                Temp_Data.Start_x = In_Data[i][m].Start_x - Temp_Data.Gts_x;
                                                Temp_Data.Start_y = In_Data[i][m].Start_y - Temp_Data.Gts_y;
                                                Temp_Data.End_x = In_Data[i][m].End_x - Temp_Data.Gts_x;
                                                Temp_Data.End_y = In_Data[i][m].End_y - Temp_Data.Gts_y;
                                                //追加修改的数据
                                                Temp_Interpolation_List_Data.Add(new Interpolation_Data(Temp_Data));
                                                Result.Add(new List<Interpolation_Data>(Temp_Interpolation_List_Data));
                                                //清空数据
                                                Temp_Data.Empty();
                                                Temp_Interpolation_List_Data.Clear();

                                                //再追加一组直线插补，让GTS平台跳至该圆弧终点
                                                Temp_Data.Path_Type = In_Data[i][m].Path_Type;
                                                Temp_Data.Type = 1;//直线插补
                                                Temp_Data.Work = 10;//10-Gts加工，20-Rtc加工
                                                Temp_Data.Lift_flag = 1;//抬刀标志
                                                Temp_Data.Start_x = In_Data[i - 1][In_Data[i - 1].Count - 1].End_x;
                                                Temp_Data.Start_y = In_Data[i - 1][In_Data[i - 1].Count - 1].End_y;
                                                Temp_Data.End_x = In_Data[i][m].End_x;
                                                Temp_Data.End_y = In_Data[i][m].End_y;

                                                //追加修改的数据
                                                Temp_Interpolation_List_Data.Add(new Interpolation_Data(Temp_Data));
                                                Result.Add(new List<Interpolation_Data>(Temp_Interpolation_List_Data));
                                                //清空数据
                                                Temp_Data.Empty();
                                                Temp_Interpolation_List_Data.Clear();
                                            }
                                            else
                                            {
                                                MessageBox.Show("整合数据异常，终止！！！");
                                            }

                                        }

                                    }
                                }

                                //遍历结束
                                if ((Temp_Interpolation_List_Data.Count > 0) && (m == In_Data[i].Count - 1))
                                {
                                    Result.Add(new List<Interpolation_Data>(Temp_Interpolation_List_Data));
                                    //清空数据  为生成Rtc数据做准备
                                    Temp_Interpolation_List_Data.Clear();
                                }

                            }
                        }
                        else
                        {
                            for (j = 0; j < In_Data[i].Count; j++)
                            {
                                //数据清空
                                Temp_Data.Empty();
                                //数据赋值
                                Temp_Data = In_Data[i][j];
                                //强制抬刀标志：0
                                Temp_Data.Lift_flag = 0;
                                //强制加工类型为RTC
                                Temp_Data.Work = 20;
                                //RTC加工，GTS平台配合坐标
                                if (j == 0)
                                {
                                    //GTS平台配合坐标
                                    Temp_Data.Gts_x = Rtc_Cal_X;
                                    Temp_Data.Gts_y = Rtc_Cal_Y;
                                    //Rtc定位 激光加工起点坐标
                                    Temp_Data.Rtc_x = In_Data[i][0].Start_x - Rtc_Cal_X;
                                    Temp_Data.Rtc_y = In_Data[i][0].Start_y - Rtc_Cal_Y;
                                }
                                //直线、圆弧拆分，整理成RTC加工数据
                                if (Temp_Data.Type == 1)//直线
                                {
                                    //RTC mark_abs直线
                                    Temp_Data.Type = 15;
                                }
                                else if (Temp_Data.Type == 2)//圆弧
                                {
                                    //RTC arc_abs圆弧
                                    Temp_Data.Type = 11;
                                    //RTC 圆弧加工圆心坐标转换
                                    Temp_Data.Center_x = In_Data[i][j].Center_x - Rtc_Cal_X;
                                    Temp_Data.Center_y = In_Data[i][j].Center_y - Rtc_Cal_Y;
                                    if (In_Data[i][j].Circle_dir == 1)
                                    {
                                        Temp_Data.Angle = In_Data[i][j].Angle;
                                    }
                                    else if (In_Data[i][j].Circle_dir == 0)
                                    {
                                        Temp_Data.Angle = In_Data[i][j].Angle;
                                    }
                                }
                                //坐标转换 将坐标转换为RTC坐标系坐标
                                Temp_Data.Start_x = In_Data[i][j].Start_x - Rtc_Cal_X;
                                Temp_Data.Start_y = In_Data[i][j].Start_y - Rtc_Cal_Y;
                                Temp_Data.End_x = In_Data[i][j].End_x - Rtc_Cal_X;
                                Temp_Data.End_y = In_Data[i][j].End_y - Rtc_Cal_Y;
                                //追加修改的数据
                                Temp_Interpolation_List_Data.Add(new Interpolation_Data(Temp_Data));
                            }
                            Result.Add(new List<Interpolation_Data>(Temp_Interpolation_List_Data));
                        }
                    }
                }
            }
            else//加工覆盖范围48X48之内，完全RTC加工    角度取反暂时不允许使用
            {
                //计算封闭图形中心坐标
                Rtc_Cal_X = (Range_XY.X_Max + Range_XY.X_Min) / 2m;//RTC坐标X基准
                Rtc_Cal_Y = (Range_XY.Y_Max + Range_XY.Y_Min) / 2m;//RTC坐标Y基准
                //数据处理部分
                for (i = 0; i < In_Data.Count; i++)
                {
                    //清除数据
                    Temp_Interpolation_List_Data.Clear();
                    if ((In_Data[i].Count > 0) && (In_Data[i].Count ==1)) //二级层，整合元素数量==1
                    {
                        for (j = 0; j < In_Data[i].Count; j++)
                        {
                            //直线、整圆拆分，整理成GTS和RTC加工数据
                            if (In_Data[i][j].Type == 1)//直线
                            {
                                if (In_Data[i][j].Lift_flag == 1)//抬刀标志
                                {
                                    //数据清空
                                    Temp_Data.Empty();
                                    //数据赋值
                                    Temp_Data = In_Data[i][j];
                                    //强制加工类型为RTC
                                    Temp_Data.Work = 20;
                                    //RTC加工，GTS平台配合坐标
                                    if (j == 0)
                                    {
                                        //GTS平台配合坐标
                                        Temp_Data.Gts_x = Rtc_Cal_X;
                                        Temp_Data.Gts_y = Rtc_Cal_Y;
                                        //Rtc定位 激光加工起点坐标
                                        Temp_Data.Rtc_x = 0;
                                        Temp_Data.Rtc_y = 0;
                                    }
                                    //RTC jump_abs直线
                                    Temp_Data.Type = 13;
                                    //坐标转换 将坐标转换为RTC坐标系坐标
                                    Temp_Data.Start_x = In_Data[i][j].Start_x - Rtc_Cal_X;
                                    Temp_Data.Start_y = In_Data[i][j].Start_y - Rtc_Cal_Y;
                                    Temp_Data.End_x = In_Data[i][j].End_x - Rtc_Cal_X;
                                    Temp_Data.End_y = In_Data[i][j].End_y - Rtc_Cal_Y;
                                    //追加修改的数据
                                    Temp_Interpolation_List_Data.Add(new Interpolation_Data(Temp_Data));
                                    Result.Add(new List<Interpolation_Data>(Temp_Interpolation_List_Data));
                                    //Result.Add(new List<Interpolation_Data>(In_Data[i]));//直接复制进入返回结果数值
                                }
                                else
                                {
                                    //数据清空
                                    Temp_Data.Empty();
                                    //数据赋值
                                    Temp_Data = In_Data[i][j];
                                    //强制加工类型为RTC
                                    Temp_Data.Work = 20;
                                    //RTC加工，GTS平台配合坐标
                                    if (j == 0)
                                    {
                                        //GTS平台配合坐标
                                        Temp_Data.Gts_x = Rtc_Cal_X;
                                        Temp_Data.Gts_y = Rtc_Cal_Y;
                                        //Rtc定位 激光加工起点坐标
                                        Temp_Data.Rtc_x = In_Data[i][j].Start_x - Rtc_Cal_X;
                                        Temp_Data.Rtc_y = In_Data[i][j].Start_y - Rtc_Cal_Y;
                                    }
                                    //RTC mark_abs直线
                                    Temp_Data.Type = 15;
                                    //坐标转换 将坐标转换为RTC坐标系坐标
                                    Temp_Data.Start_x = In_Data[i][j].Start_x - Rtc_Cal_X;
                                    Temp_Data.Start_y = In_Data[i][j].Start_y - Rtc_Cal_Y;
                                    Temp_Data.End_x = In_Data[i][j].End_x - Rtc_Cal_X;
                                    Temp_Data.End_y = In_Data[i][j].End_y - Rtc_Cal_Y;
                                    //追加修改的数据
                                    Temp_Interpolation_List_Data.Add(new Interpolation_Data(Temp_Data));
                                    Result.Add(new List<Interpolation_Data>(Temp_Interpolation_List_Data));
                                }
                            }
                            else if (In_Data[i][j].Type == 2)// 圆弧
                            {
                                //数据清空
                                Temp_Data.Empty();
                                //生成Rtc加工数据
                                Temp_Data = In_Data[i][j];
                                //RTC arc_abs圆弧
                                Temp_Data.Type = 11;
                                //强制抬刀标志：0
                                Temp_Data.Lift_flag = 0;
                                //强制加工类型为RTC
                                Temp_Data.Work = 20;
                                //RTC加工，GTS平台配合坐标
                                Temp_Data.Gts_x = Rtc_Cal_X;
                                Temp_Data.Gts_y = Rtc_Cal_Y;
                                //RTC 圆弧加工圆心坐标转换
                                Temp_Data.Center_x = In_Data[i][j].Center_x - Temp_Data.Gts_x;
                                Temp_Data.Center_y = In_Data[i][j].Center_y - Temp_Data.Gts_y;
                                //Rtc定位 激光加工起点坐标
                                Temp_Data.Rtc_x = In_Data[i][j].Start_x - Temp_Data.Gts_x;
                                Temp_Data.Rtc_y = In_Data[i][j].Start_y - Temp_Data.Gts_y;
                                //坐标转换 将坐标转换为RTC坐标系坐标
                                Temp_Data.Start_x = In_Data[i][j].Start_x - Temp_Data.Gts_x;
                                Temp_Data.Start_y = In_Data[i][j].Start_y - Temp_Data.Gts_y;
                                Temp_Data.End_x = In_Data[i][j].End_x - Temp_Data.Gts_x;
                                Temp_Data.End_y = In_Data[i][j].End_y - Temp_Data.Gts_y;
                                //角度处理
                                if (In_Data[i][j].Circle_dir == 1)
                                {
                                    Temp_Data.Angle = In_Data[i][j].Angle;
                                }
                                else if (In_Data[i][j].Circle_dir == 0)
                                {
                                    Temp_Data.Angle = In_Data[i][j].Angle;
                                }
                                //追加修改的数据
                                Temp_Interpolation_List_Data.Add(new Interpolation_Data(Temp_Data));
                                Result.Add(new List<Interpolation_Data>(Temp_Interpolation_List_Data));
                                //清空数据
                                Temp_Data.Empty();
                                Temp_Interpolation_List_Data.Clear();
                            }
                            else if (In_Data[i][j].Type == 3)//整圆
                            {
                                //数据赋值
                                Temp_Data = In_Data[i][j];
                                //RTC arc_abs圆弧
                                Temp_Data.Type = 11;
                                //强制抬刀标志：0
                                Temp_Data.Lift_flag = 0;
                                //强制加工类型为RTC
                                Temp_Data.Work = 20;
                                //RTC加工，GTS平台配合坐标
                                Temp_Data.Gts_x = Rtc_Cal_X;
                                Temp_Data.Gts_y = Rtc_Cal_Y;
                                //RTC 圆弧加工圆心坐标转换
                                Temp_Data.Center_x = In_Data[i][j].Center_x - Temp_Data.Gts_x;
                                Temp_Data.Center_y = In_Data[i][j].Center_y - Temp_Data.Gts_y;
                                //RTC加工切入点
                                Temp_Data.Start_x = Temp_Data.Center_x;
                                Temp_Data.Start_y = Temp_Data.Center_y + In_Data[i][j].Circle_radius;
                                Temp_Data.End_x = Temp_Data.Center_x;
                                Temp_Data.End_y = Temp_Data.Center_y + In_Data[i][j].Circle_radius;
                                //RTC加工整圆角度
                                // arc angle in ° as a 64 - bit IEEE floating point value
                                // (positive angle values correspond to clockwise angles);
                                // allowed range: [–3600.0° … +3600.0°] (±10 full circles);
                                // out-of-range values will be edge-clipped.
                                Temp_Data.Angle = 370;//这个参数得看RTC手册，整圆的旋转角度

                                //Rtc定位 激光加工起点坐标
                                Temp_Data.Rtc_x = Temp_Data.Center_x;
                                Temp_Data.Rtc_y = Temp_Data.Center_y + In_Data[i][j].Circle_radius;

                                //追加修改的数据
                                Temp_Interpolation_List_Data.Add(new Interpolation_Data(Temp_Data));
                                Result.Add(new List<Interpolation_Data>(Temp_Interpolation_List_Data));
                            }
                        }
                    }
                    else if (In_Data[i].Count >= 2) //二级层，整合元素数量大于等于2
                    {
                        for (j = 0; j < In_Data[i].Count; j++)
                        {
                            //数据清空
                            Temp_Data.Empty();
                            //数据赋值
                            Temp_Data = In_Data[i][j];
                            //强制抬刀标志：0
                            Temp_Data.Lift_flag = 0;
                            //强制加工类型为RTC
                            Temp_Data.Work = 20;
                            //RTC加工，GTS平台配合坐标
                            if (j == 0)
                            {
                                //GTS平台配合坐标
                                Temp_Data.Gts_x = Rtc_Cal_X;
                                Temp_Data.Gts_y = Rtc_Cal_Y;
                                //Rtc定位 激光加工起点坐标
                                Temp_Data.Rtc_x = In_Data[i][0].Start_x - Rtc_Cal_X;
                                Temp_Data.Rtc_y = In_Data[i][0].Start_y - Rtc_Cal_Y;
                            }
                            //直线、圆弧拆分，整理成RTC加工数据
                            if (Temp_Data.Type == 1)//直线
                            {
                                //RTC mark_abs直线
                                Temp_Data.Type = 15;
                            }
                            else if (Temp_Data.Type == 2)//圆弧
                            {
                                //RTC arc_abs圆弧
                                Temp_Data.Type = 11;
                                //RTC 圆弧加工圆心坐标转换
                                Temp_Data.Center_x = In_Data[i][j].Center_x - Rtc_Cal_X;
                                Temp_Data.Center_y = In_Data[i][j].Center_y - Rtc_Cal_Y;
                                if (In_Data[i][j].Circle_dir == 1)
                                {
                                    Temp_Data.Angle = In_Data[i][j].Angle;
                                }
                                else if (In_Data[i][j].Circle_dir == 0)
                                {
                                    Temp_Data.Angle = In_Data[i][j].Angle;
                                }
                            }
                            //坐标转换 将坐标转换为RTC坐标系坐标
                            Temp_Data.Start_x = In_Data[i][j].Start_x - Rtc_Cal_X;
                            Temp_Data.Start_y = In_Data[i][j].Start_y - Rtc_Cal_Y;
                            Temp_Data.End_x = In_Data[i][j].End_x - Rtc_Cal_X;
                            Temp_Data.End_y = In_Data[i][j].End_y - Rtc_Cal_Y;
                            //追加修改的数据
                            Temp_Interpolation_List_Data.Add(new Interpolation_Data(Temp_Data));
                        }
                        Result.Add(new List<Interpolation_Data>(Temp_Interpolation_List_Data));
                    }
                }
            }
            //处理二次结果，合并走直线的Gts数据，下次为Rtc加工，则变动该GTS数据终点坐标为RTC加工的gts基准位置
            for (int cal = 0; cal < Result.Count; cal++)
            {
                //当前序号 数量为1、加工类型1 直线、加工方式10 GTS
                //当前+1序号 数量大于1、加工方式20 RTX
                if ((cal < Result.Count - 1) && (Result[cal].Count == 1) && (Result[cal][0].Type == 1) && (Result[cal][0].Work == 10) && (Result[cal + 1].Count >= 1) && (Result[cal + 1][0].Work == 20))
                {
                    Temp_Data.Empty();
                    Temp_Data = Result[cal][0];
                    Temp_Data.End_x = Result[cal + 1][0].Gts_x;
                    Temp_Data.End_y = Result[cal + 1][0].Gts_y;
                    //重新赋值
                    Result[cal][0] = new Interpolation_Data(Temp_Data);
                }
            }
            //返回结果
            return Result;
        }

        /// <summary>
        /// 计算End极值范围
        /// </summary>
        /// <param name="In_Data"></param>
        /// <returns></returns>
        public Extreme Cal_End_Max_Min(List<List<Interpolation_Data>> In_Data)
        {
            List<decimal> Tem_Dat_X = new List<decimal>(); 
            List<decimal> Tem_Dat_Y = new List<decimal>();
            for (int i = 0; i < In_Data.Count; i++)
            {
                if (In_Data[i][0].Lift_flag == 0)//只判断加工的路径极值
                {
                    Tem_Dat_X.Add(In_Data[i].Max(o => o.End_x));
                    Tem_Dat_X.Add(In_Data[i].Min(o => o.End_x));
                    Tem_Dat_X.Add(In_Data[i].Max(o => o.Start_x));
                    Tem_Dat_X.Add(In_Data[i].Min(o => o.Start_x));
                    Tem_Dat_Y.Add(In_Data[i].Max(o => o.End_y));
                    Tem_Dat_Y.Add(In_Data[i].Min(o => o.End_y));
                    Tem_Dat_Y.Add(In_Data[i].Max(o => o.Start_y));
                    Tem_Dat_Y.Add(In_Data[i].Min(o => o.Start_y));
                }                
            }
            return new Extreme(Tem_Dat_X.Max(), Tem_Dat_X.Min(), Tem_Dat_Y.Max(), Tem_Dat_Y.Min(), Math.Abs(Tem_Dat_X.Max() - Tem_Dat_X.Min()), Math.Abs(Tem_Dat_Y.Max() - Tem_Dat_Y.Min()));
        }
        /// <summary>
        /// 计算Center极值范围
        /// </summary>
        /// <param name="In_Data"></param>
        /// <returns></returns>
        public Extreme Cal_Center_Max_Min(List<List<Interpolation_Data>> In_Data)
        {
            List<decimal> Tem_Dat_X = new List<decimal>();
            List<decimal> Tem_Dat_Y = new List<decimal>();
            for (int i = 0; i < In_Data.Count; i++)
            {
                if (In_Data[i][0].Lift_flag == 0)
                {
                    Tem_Dat_X.Add(In_Data[i].Max(o => o.Center_x));
                    Tem_Dat_X.Add(In_Data[i].Min(o => o.Center_x));
                    Tem_Dat_Y.Add(In_Data[i].Max(o => o.Center_y));
                    Tem_Dat_Y.Add(In_Data[i].Min(o => o.Center_y));
                }                
            }
            return new Extreme(Tem_Dat_X.Max(), Tem_Dat_X.Min(), Tem_Dat_Y.Max(), Tem_Dat_Y.Min(), Math.Abs(Tem_Dat_X.Max() - Tem_Dat_X.Min()), Math.Abs(Tem_Dat_Y.Max() - Tem_Dat_Y.Min()));
        }
        
    }
}

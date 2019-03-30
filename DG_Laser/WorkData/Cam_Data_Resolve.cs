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
        /// 读取文件
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public List<string> GetLayerList(string filename)
        {
            //定义文件名
            string Dxf_filename = null;
            List<string> Result = new List<string>();
            if (filename == null)
            {
                Dxf_filename = "Sample.dxf";
            }
            else
            {
                Dxf_filename = filename;
            }
            DxfDocument dxfDocument = new DxfDocument();
            //检查文件是否存在
            FileInfo fileInfo = new FileInfo(Dxf_filename);
            if (!fileInfo.Exists)
            {
                LogInfo?.Invoke(Dxf_filename + "  文件不存在！！！" + "\r\n");
                return null;
            }
            DxfVersion dxfVersion = DxfDocument.CheckDxfFileVersion(Dxf_filename, out bool isBinary);
            // 检查Dxf文件版本是否正确
            if (dxfVersion < DxfVersion.AutoCad2000)
            {
                LogInfo?.Invoke(Dxf_filename + "  文件版本不支持" + "\r\n");
                return null;
            }
            //读取Dxf文件
            dxfDocument = DxfDocument.Load(Dxf_filename);
            // check if there has been any problems loading the file,
            // this might be the case of a corrupt file or a problem in the library            
            if (dxfDocument == null)
            {
                LogInfo?.Invoke(Dxf_filename + "  Dxf文件读取失败" + "\r\n");
                return null;
            }
            //返回读取结果
            foreach (var o in dxfDocument.Layers)
            {
                Result.Add(o.Name);
            }
            return Result;
        }

        /// <summary>
        /// 提取指定图层的的R通道颜色List
        /// </summary>
        /// <param name="dxf"></param>
        /// <param name="LayerList"></param>
        /// <returns></returns>
        public List<int> DistractSectionColor(DxfDocument dxf, string Layer_Name)
        {
            List<int> Result = new List<int>();//结果变量
            if (dxf.Lines.Count > 0)//存在直线
            {
                foreach (var o in dxf.Lines)
                {
                    if ((o.Layer.Name == Layer_Name) && !Result.Contains(o.Color.R)) Result.Add(o.Color.R);
                }
            }
            if (dxf.Arcs.Count > 0)//存在圆弧
            {
                foreach (var o in dxf.Arcs)
                {
                    if ((o.Layer.Name == Layer_Name) && !Result.Contains(o.Color.R)) Result.Add(o.Color.R);
                }
            }
            if (dxf.Circles.Count > 0)//存在整圆
            {
                foreach (var o in dxf.Circles)
                {
                    if ((o.Layer.Name == Layer_Name) && !Result.Contains(o.Color.R)) Result.Add(o.Color.R);
                }
            }
            if (dxf.LwPolylines.Count > 0)//存在多边形
            {
                foreach (var o in dxf.LwPolylines)
                {
                    if ((o.Layer.Name == Layer_Name) && !Result.Contains(o.Color.R)) Result.Add(o.Color.R);
                }
            }
            //返回结果            
            return Result.Distinct().OrderBy(o => o).ToList();
        }

        /// <summary>
        /// 处理Dxf 提取指定图层，颜色的圆弧和直线
        /// </summary>
        /// <param name="dxf"></param>
        /// <returns></returns>
        public List<List<Entity_Data>> DistractArcLine(DxfDocument dxf,int color,string Layer_Name) 
        {
            //结果数组
            List<Entity_Data> TemArcLine = new List<Entity_Data>();
            //建立临时Entity数据
            Entity_Data Temp_Entity = new Entity_Data();
            //临时变量
            int i = 0;
            //提取符合要求的直线
            for (i = 0; i < dxf.Lines.Count; i++)
            {
                if ((dxf.Lines[i].Layer.Name == Layer_Name) && (dxf.Lines[i].Color.R == color))//提取图层名、颜色符合的直线
                {
                    Temp_Entity.Empty();//清空数据
                    Temp_Entity.Type = 1;//标记为直线
                    //起点计算
                    Temp_Entity.Start_x = Convert.ToDecimal(dxf.Lines[i].StartPoint.X);
                    Temp_Entity.Start_y = Convert.ToDecimal(dxf.Lines[i].StartPoint.Y);
                    //终点计算
                    Temp_Entity.End_x = Convert.ToDecimal(dxf.Lines[i].EndPoint.X);
                    Temp_Entity.End_y = Convert.ToDecimal(dxf.Lines[i].EndPoint.Y);
                    //追加数据
                    TemArcLine.Add(new Entity_Data(Temp_Entity));
                }
            }
            
            //提取符合要求的圆弧
            for (i = 0; i < dxf.Arcs.Count; i++)
            {
                if ((dxf.Arcs[i].Layer.Name == Layer_Name) && (dxf.Arcs[i].Color.R == color))//提取图层名、颜色符合的圆弧
                {
                    Temp_Entity.Empty();//清空数据
                    Temp_Entity.Type = 2;//标记为圆弧
                    //起点计算
                    Temp_Entity.Start_x = Convert.ToDecimal(dxf.Arcs[i].StartPoint.X);
                    Temp_Entity.Start_y = Convert.ToDecimal(dxf.Arcs[i].StartPoint.Y);
                    //终点计算
                    Temp_Entity.End_x = Convert.ToDecimal(dxf.Arcs[i].EndPoint.X);
                    Temp_Entity.End_y = Convert.ToDecimal(dxf.Arcs[i].EndPoint.Y);
                    //起始和终止角度提取
                    Temp_Entity.Cir_Start_Angle = Convert.ToDecimal(dxf.Arcs[i].StartAngle);
                    Temp_Entity.Cir_End_Angle = Convert.ToDecimal(dxf.Arcs[i].EndAngle);
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
                    Temp_Entity.Center_x = Convert.ToDecimal(dxf.Arcs[i].Center.X);
                    Temp_Entity.Center_y = Convert.ToDecimal(dxf.Arcs[i].Center.Y);
                    Temp_Entity.Circle_radius = Convert.ToDecimal(dxf.Arcs[i].Radius);
                    Temp_Entity.Circle_dir = 1;
                    //提交
                    TemArcLine.Add(new Entity_Data(Temp_Entity));
                }
            }
            //判断圆弧直线数量，并排序
            //if (TemArcLine.Count > 0)
            //{
            //    TemArcLine = TemArcLine.OrderBy(o => o.Start_x).ThenBy(o => o.Start_y).ToList();
            //}
            //首尾相接处理并返回结果
            if (TemArcLine.Count <=0)
            {
                return new List<List<Entity_Data>>();
            }
            else
            {
                return CombineArcLine(TemArcLine);
            }
            
        }
        /// <summary>
        /// 整合ArcLine数据
        /// </summary>
        /// <param name="Arc_Line_Datas"></param>
        /// <returns></returns>
        public List<List<Entity_Data>> CombineArcLine(List<Entity_Data> Arc_Line_Datas)
        {
            //结果变量
            List<List<Entity_Data>> Result = new List<List<Entity_Data>>();
            List<Entity_Data> Single_Data = new List<Entity_Data>(); //辅助运算 用途:提取顺序的衔接和处理
            //临时变量
            Entity_Data Temp_Data = new Entity_Data();
            int i = 0;
            int Num = 0;
            //初始清除
            Single_Data.Clear();
            Temp_Data.Empty();

            //处理Line_Arc生成加工数据 初始数据  属于切入加工起点，故强制使用
            //直线插补走刀
            //强制生成独立的 List<Interpolation_Data>，并将其写入独立运行数据块 List<List<Interpolation_Data>>
            if (Arc_Line_Datas.Count > 0)
            {
                Single_Data.Add(new Entity_Data(Arc_Line_Datas[0]));//追加首数据
                Arc_Line_Datas.RemoveAt(0);//移除索引0数据
                //整理数据
                do
                {
                    Num = Arc_Line_Datas.Count;//记录当前Arc_Line_Datas.Count,用于判断数据是否处理完或封闭寻找结束
                    for (i = 0; i < Arc_Line_Datas.Count; i++)
                    {
                        if (Differ_Err(Single_Data[Single_Data.Count - 1].End_x, Single_Data[Single_Data.Count - 1].End_y, Arc_Line_Datas[i].End_x, Arc_Line_Datas[i].End_y))//当前插补终点是 数据处理终点 同CAD文件规定方向相反
                        {
                            //提取当前数据
                            Temp_Data = new Entity_Data(Arc_Line_Datas[i]);
                            //替换起点坐标
                            Temp_Data.Start_x = Arc_Line_Datas[i].End_x;
                            Temp_Data.Start_y = Arc_Line_Datas[i].End_y;
                            //替换终点坐标
                            Temp_Data.End_x = Arc_Line_Datas[i].Start_x;
                            Temp_Data.End_y = Arc_Line_Datas[i].Start_y;
                            //圆弧数据处理
                            if (Temp_Data.Type == 2)//圆弧
                            {
                                //重新计算圆弧中心减起点坐标值
                                Temp_Data.Center_Start_x = Temp_Data.Center_x - Temp_Data.Start_x;
                                Temp_Data.Center_Start_y = Temp_Data.Center_y - Temp_Data.Start_y;
                                //计算圆弧角度
                                Temp_Data.Cir_Start_Angle = Arc_Line_Datas[i].Cir_End_Angle;
                                Temp_Data.Cir_End_Angle = Arc_Line_Datas[i].Cir_Start_Angle;
                                //圆弧方向
                                Temp_Data.Circle_dir = 0;
                            }
                            //提交进入Arc_Data
                            Single_Data.Add(new Entity_Data(Temp_Data));
                            //清空数据
                            Temp_Data.Empty();
                            //删除当前的Entity数据
                            Arc_Line_Datas.RemoveAt(i);
                            break;
                        }
                        else if (Differ_Err(Single_Data[Single_Data.Count - 1].End_x, Single_Data[Single_Data.Count - 1].End_y, Arc_Line_Datas[i].Start_x, Arc_Line_Datas[i].Start_y)) //当前插补终点是 数据处理起点 同CAD文件规定方向相同
                        {
                            //提取当前数据
                            Temp_Data = new Entity_Data(Arc_Line_Datas[i]);
                            //圆弧数据处理
                            if (Temp_Data.Type == 2)//圆弧
                            {
                                //重新计算圆弧中心减起点坐标值
                                Temp_Data.Center_Start_x = Temp_Data.Center_x - Temp_Data.Start_x;
                                Temp_Data.Center_Start_y = Temp_Data.Center_y - Temp_Data.Start_y;
                                //圆弧方向
                                Temp_Data.Circle_dir = 1;
                            }
                            //提交进入Arc_Data
                            Single_Data.Add(new Entity_Data(Temp_Data));

                            //清空数据
                            Temp_Data.Empty();
                            //删除当前的Entity数据
                            Arc_Line_Datas.RemoveAt(i);
                            break;
                        }
                    }

                    //寻找结束点失败，意味着重新开始新的 线段或圆弧
                    if ((Arc_Line_Datas.Count > 0) && (Num == Arc_Line_Datas.Count))
                    {
                        //整合数据生成代码 当前结束的封闭图形加工数据
                        if (Single_Data.Count > 0) Result.Add(new List<Entity_Data>(Single_Data));//追加数据
                        //清空数据
                        Single_Data.Clear();

                        //跳刀直接使用直线插补走刀
                        Single_Data.Add(new Entity_Data(Arc_Line_Datas[0]));//追加首数据
                        Arc_Line_Datas.RemoveAt(0);//移除索引0数据
                        if (Arc_Line_Datas.Count > 0) continue;
                    }
                    //序列中已无整合的数据
                    if ((Arc_Line_Datas.Count == 0) && ((Num == 1) || (Num == 0)))//寻找到最后一组
                    {
                        if (Single_Data.Count > 0)
                        {
                            //整合数据生成代码 当前结束的封闭图形加工数据
                            Result.Add(new List<Entity_Data>(Single_Data));//追加数据  
                            //清空数据
                            Single_Data.Clear();
                        }
                    }
                } while (Arc_Line_Datas.Count > 0);//实体Line_Arc数据未清空完
            }
            //返回结果
            return Result;
        }

        /// <summary>
        /// 处理Dxf 提取指定图层，颜色的多边形
        /// </summary>
        /// <param name="dxf"></param>
        /// <returns></returns>
        public List<List<Entity_Data>> DistractLWPolyline(DxfDocument dxf, int color, string Layer_Name)
        {
            List<List<Entity_Data>> Result = new List<List<Entity_Data>>();
            List<Entity_Data> Temp_List = new List<Entity_Data>();
            //建立临时Entity数据
            Entity_Data Temp_Entity = new Entity_Data();
            //临时变量
            int i = 0, j = 0;
            //提取符合要求的多边形
            for (i = 0; i < dxf.LwPolylines.Count; i++)
            {
                if ((dxf.LwPolylines[i].Layer.Name == Layer_Name) && (dxf.LwPolylines[i].Color.R == color))//提取图层名、颜色符合的直线
                {
                    for (j = 0; j < dxf.LwPolylines[i].Vertexes.Count; j++)
                    {
                        Temp_Entity.Empty();//清空数据
                        if (j <= dxf.LwPolylines[i].Vertexes.Count - 2)//倒数第二个点
                        {
                            if (!(dxf.LwPolylines[i].Vertexes[j].Position.X == dxf.LwPolylines[i].Vertexes[j + 1].Position.X) || !(dxf.LwPolylines[i].Vertexes[j].Position.Y == dxf.LwPolylines[i].Vertexes[j + 1].Position.Y))
                            {
                                Temp_Entity.Type = 1;//直线插补
                                //起终点提取
                                Temp_Entity.Start_x = Convert.ToDecimal(dxf.LwPolylines[i].Vertexes[j].Position.X);
                                Temp_Entity.Start_y = Convert.ToDecimal(dxf.LwPolylines[i].Vertexes[j].Position.Y);
                                Temp_Entity.End_x = Convert.ToDecimal(dxf.LwPolylines[i].Vertexes[j + 1].Position.X);
                                Temp_Entity.End_y = Convert.ToDecimal(dxf.LwPolylines[i].Vertexes[j + 1].Position.Y);
                                //提交进入Temp_List
                                Temp_List.Add(new Entity_Data(Temp_Entity));
                            }
                        }
                        else if (j == (dxf.LwPolylines[i].Vertexes.Count - 1))//最后一个点
                        {
                            if (dxf.LwPolylines[i].IsClosed)//判断是否闭合
                            {
                                Temp_Entity.Type = 1;//直线插补
                                //起终点提取
                                Temp_Entity.Start_x = Convert.ToDecimal(dxf.LwPolylines[i].Vertexes[j].Position.X);
                                Temp_Entity.Start_y = Convert.ToDecimal(dxf.LwPolylines[i].Vertexes[j].Position.Y);
                                Temp_Entity.End_x = Convert.ToDecimal(dxf.LwPolylines[i].Vertexes[0].Position.X);
                                Temp_Entity.End_y = Convert.ToDecimal(dxf.LwPolylines[i].Vertexes[0].Position.Y);
                                //提交进入Temp_List
                                Temp_List.Add(new Entity_Data(Temp_Entity));
                            }
                        }
                    }
                    //当前LwPolyline数据提取完成，追加数据
                    Result.Add(new List<Entity_Data>(Temp_List));
                    Temp_List.Clear();//清空数据
                }
            }
            //返回结果
            return Result;
        }
        /// <summary>
        /// 处理Dxf 提取指定图层，颜色的Circle数据
        /// </summary>
        /// <param name="dxf"></param>
        /// <returns></returns>
        public List<Entity_Data> DistractCircle(DxfDocument dxf, int color, string Layer_Name)
        {
            List<Entity_Data> Result = new List<Entity_Data>();
            //建立临时Entity数据
            Entity_Data Temp_Entity = new Entity_Data();
            //临时变量
            int i = 0;
            //提取符合要求的圆
            for (i = 0; i < dxf.Circles.Count; i++)
            {
                if ((dxf.Circles[i].Layer.Name == Layer_Name) && (dxf.Circles[i].Color.R == color))
                {
                    Temp_Entity.Type = 3;//圆 
                    //圆心提取
                    Temp_Entity.Center_x = Convert.ToDecimal(dxf.Circles[i].Center.X);
                    Temp_Entity.Center_y = Convert.ToDecimal(dxf.Circles[i].Center.Y);
                    Temp_Entity.Circle_radius = Convert.ToDecimal(dxf.Circles[i].Radius);
                    Temp_Entity.Start_x = Temp_Entity.Center_x + Temp_Entity.Circle_radius;
                    Temp_Entity.Start_y = Temp_Entity.Center_y;
                    Temp_Entity.End_x = Temp_Entity.Center_x + Temp_Entity.Circle_radius;
                    Temp_Entity.End_y = Temp_Entity.Center_y;
                    Temp_Entity.Circle_dir = 0;//方向 顺时针画圆                                                       
                    Temp_Entity.Cir_End_Angle = 0.0m;//起始角度
                    Temp_Entity.Cir_Start_Angle = 360.0m;//终止角度
                    //提交进入Circle_Entity_Data
                    Result.Add(new Entity_Data(Temp_Entity));
                }
            }
            //返回结果
            return Result;
            
        }
        /// <summary>
        /// 处理Dxf 提取指定图层，颜色Mark数据
        /// </summary>
        /// <param name="dxf"></param>
        /// <returns></returns>
        public List<Vector> DistractMark(DxfDocument dxf, int color, string Layer_Name)
        {
            List<Vector> Result = new List<Vector>();            
            //临时变量
            int i = 0;
            //Mark数据读取
            if (dxf.Circles.Count > 0)
            {
                for (i = 0; i < dxf.Circles.Count; i++)
                {
                    if ((dxf.Circles[i].Layer.Name == Layer_Name) && (dxf.Circles[i].Color.R == color)) //Mark点 数据收集
                    {                       
                        //提交进入Circle
                        Result.Add(new Vector((decimal)dxf.Circles[i].Center.X, (decimal)dxf.Circles[i].Center.Y));
                    }
                }
            }
            //排序
            Result = Result.OrderBy(a => a.X).ThenByDescending(a => a.Y).ToList();
            //返回结果
            return Result;
        }
        /// <summary>
        /// 处理Dxf 提取指定图层，颜色Mark数据
        /// </summary>
        /// <param name="dxf"></param>
        /// <returns></returns>
        public List<Vector> DistractMark(DxfDocument dxf, string Layer_Name)
        {
            List<Vector> Result = new List<Vector>();
            //临时变量
            int i = 0;
            //Mark数据读取
            if (dxf.Circles.Count > 0)
            {
                for (i = 0; i < dxf.Circles.Count; i++)
                {
                    if (dxf.Circles[i].Layer.Name == Layer_Name) //Mark点 数据收集
                    {
                        //提交进入Circle
                        Result.Add(new Vector((decimal)dxf.Circles[i].Center.X, (decimal)dxf.Circles[i].Center.Y));
                    }
                }
            }
            //排序
            Result = Result.OrderBy(a => a.X).ThenBy(a => a.Y).ToList();
            //返回结果
            return Result;
        }

        /// <summary>
        /// 用指定Matrix校准List<List<Entity_Data>>数据，0 - 原点起始，1 - Mark校准，2 - 指定点起始
        /// </summary>
        /// <param name="List_Datas"></param>
        /// <param name="Matrices"></param>
        /// <param name="Flag"></param>
        /// <returns></returns>
        public List<List<Entity_Data>> CalDataByMatrix(List<List<Entity_Data>> List_Datas, Affinity_Matrix Matrices, int Flag)
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
                    Temp_Data =new Entity_Data(O);
                    //加工起始位置选择
                    switch (Flag)
                    {
                        case 0://原点起始加工
                            //起点计算
                            Temp_Data.Start_x = O.Start_x - Program.SystemContainer.SysPara.Rtc_Org.X;
                            Temp_Data.Start_y = O.Start_y - Program.SystemContainer.SysPara.Rtc_Org.Y;
                            //终点计算
                            Temp_Data.End_x = O.End_x - Program.SystemContainer.SysPara.Rtc_Org.X;
                            Temp_Data.End_y = O.End_y - Program.SystemContainer.SysPara.Rtc_Org.Y;
                            //圆心计算
                            if (Temp_Data.Type == 1) break;
                            Temp_Data.Center_x = O.Center_x - Program.SystemContainer.SysPara.Rtc_Org.X;
                            Temp_Data.Center_y = O.Center_y - Program.SystemContainer.SysPara.Rtc_Org.Y;
                            break;
                        case 1://Mark矫正
                            //sin取正  (当前坐标系采用) 已验证
                            //起点计算
                            Temp_Data.Start_x = O.Start_x * Matrices.Stretch_X + O.Start_y * Matrices.Distortion_X + Matrices.Delta_X - Program.SystemContainer.SysPara.Rtc_Org.X;
                            Temp_Data.Start_y = O.Start_y * Matrices.Stretch_Y + O.Start_x * Matrices.Distortion_Y + Matrices.Delta_Y - Program.SystemContainer.SysPara.Rtc_Org.Y;
                            //终点计算
                            Temp_Data.End_x = O.End_x * Matrices.Stretch_X + O.End_y * Matrices.Distortion_X + Matrices.Delta_X - Program.SystemContainer.SysPara.Rtc_Org.X;
                            Temp_Data.End_y = O.End_y * Matrices.Stretch_Y + O.End_x * Matrices.Distortion_Y + Matrices.Delta_Y - Program.SystemContainer.SysPara.Rtc_Org.Y;
                            //圆心计算
                            if (Temp_Data.Type == 1) break;
                            Temp_Data.Center_x = O.Center_x * Matrices.Stretch_X + O.Center_y * Matrices.Distortion_X + Matrices.Delta_X - Program.SystemContainer.SysPara.Rtc_Org.X;
                            Temp_Data.Center_y = O.Center_y * Matrices.Stretch_Y + O.Center_x * Matrices.Distortion_Y + Matrices.Delta_Y - Program.SystemContainer.SysPara.Rtc_Org.Y;
                            break;
                        case 2://指定点加工
                            //起点计算
                            Temp_Data.Start_x = O.Start_x - Program.SystemContainer.SysPara.Rtc_Org.X + Program.SystemContainer.SysPara.ResignationPoint.X;
                            Temp_Data.Start_y = O.Start_y - Program.SystemContainer.SysPara.Rtc_Org.Y + Program.SystemContainer.SysPara.ResignationPoint.Y;
                            //终点计算
                            Temp_Data.End_x = O.End_x - Program.SystemContainer.SysPara.Rtc_Org.X + Program.SystemContainer.SysPara.ResignationPoint.X;
                            Temp_Data.End_y = O.End_y - Program.SystemContainer.SysPara.Rtc_Org.Y + Program.SystemContainer.SysPara.ResignationPoint.Y;
                            //圆心计算
                            if (Temp_Data.Type == 1) break;
                            Temp_Data.Center_x = O.Center_x - Program.SystemContainer.SysPara.Rtc_Org.X + Program.SystemContainer.SysPara.ResignationPoint.X;
                            Temp_Data.Center_y = O.Center_y - Program.SystemContainer.SysPara.Rtc_Org.Y + Program.SystemContainer.SysPara.ResignationPoint.Y;
                            break;
                        default:
                            break;
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
        /// 用指定Matrix校准List<List<Entity_Data>>数据，True - 校准，False - 不校准
        /// </summary>
        /// <param name="List_Datas"></param>
        /// <param name="Matrices"></param>
        /// <param name="Flag"></param>
        /// <returns></returns>
        public List<Entity_Data> CalDataByMatrix(List<Entity_Data> List_Datas, Affinity_Matrix Matrices, int Flag)
        {
            //建立变量 
            List<Entity_Data> Result = new List<Entity_Data>();
            Entity_Data Temp_Data = new Entity_Data();
            //处理数据
            foreach (var O in List_Datas)
            {
                //先清空
                Temp_Data.Empty();
                //后赋值
                Temp_Data = new Entity_Data(O);
                switch(Flag)
                {
                    case 0://原点起始
                        //起点计算
                        Temp_Data.Start_x = O.Start_x - Program.SystemContainer.SysPara.Rtc_Org.X;
                        Temp_Data.Start_y = O.Start_y - Program.SystemContainer.SysPara.Rtc_Org.Y;
                        //终点计算
                        Temp_Data.End_x = O.End_x - Program.SystemContainer.SysPara.Rtc_Org.X;
                        Temp_Data.End_y = O.End_y - Program.SystemContainer.SysPara.Rtc_Org.Y;
                        //圆心计算
                        Temp_Data.Center_x = O.Center_x - Program.SystemContainer.SysPara.Rtc_Org.X;
                        Temp_Data.Center_y = O.Center_y - Program.SystemContainer.SysPara.Rtc_Org.Y;
                        break;
                    case 1://Mark矫正
                        //起点计算
                        Temp_Data.Start_x = O.Start_x * Matrices.Stretch_X + O.Start_y * Matrices.Distortion_X + Matrices.Delta_X - Program.SystemContainer.SysPara.Rtc_Org.X;
                        Temp_Data.Start_y = O.Start_y * Matrices.Stretch_Y + O.Start_x * Matrices.Distortion_Y + Matrices.Delta_Y - Program.SystemContainer.SysPara.Rtc_Org.Y;
                        //终点计算
                        Temp_Data.End_x = O.End_x * Matrices.Stretch_X + O.End_y * Matrices.Distortion_X + Matrices.Delta_X - Program.SystemContainer.SysPara.Rtc_Org.X;
                        Temp_Data.End_y = O.End_y * Matrices.Stretch_Y + O.End_x * Matrices.Distortion_Y + Matrices.Delta_Y - Program.SystemContainer.SysPara.Rtc_Org.Y;
                        //圆心计算
                        Temp_Data.Center_x = O.Center_x * Matrices.Stretch_X + O.Center_y * Matrices.Distortion_X + Matrices.Delta_X - Program.SystemContainer.SysPara.Rtc_Org.X;
                        Temp_Data.Center_y = O.Center_y * Matrices.Stretch_Y + O.Center_x * Matrices.Distortion_Y + Matrices.Delta_Y - Program.SystemContainer.SysPara.Rtc_Org.Y;
                        break;
                    case 2://指定点起始
                        //起点计算
                        Temp_Data.Start_x = O.Start_x - Program.SystemContainer.SysPara.Rtc_Org.X + Program.SystemContainer.SysPara.ResignationPoint.X;
                        Temp_Data.Start_y = O.Start_y - Program.SystemContainer.SysPara.Rtc_Org.Y + Program.SystemContainer.SysPara.ResignationPoint.Y;
                        //终点计算
                        Temp_Data.End_x = O.End_x - Program.SystemContainer.SysPara.Rtc_Org.X + Program.SystemContainer.SysPara.ResignationPoint.X;
                        Temp_Data.End_y = O.End_y - Program.SystemContainer.SysPara.Rtc_Org.Y + Program.SystemContainer.SysPara.ResignationPoint.Y;
                        //圆心计算
                        Temp_Data.Center_x = O.Center_x - Program.SystemContainer.SysPara.Rtc_Org.X + Program.SystemContainer.SysPara.ResignationPoint.X;
                        Temp_Data.Center_y = O.Center_y - Program.SystemContainer.SysPara.Rtc_Org.Y + Program.SystemContainer.SysPara.ResignationPoint.Y;
                        break;
                    default:
                        break;
                }
                //追加数据至Temp_List
                Result.Add(new Entity_Data(Temp_Data));
                //清空Temp_Data
                Temp_Data.Empty();
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
        /// 处理文件分区数据
        /// </summary>
        /// <param name="File_Entity_Datas"></param>
        /// <returns></returns>
        public File_Entity_Data SeperateFileData(File_Entity_Data File_Entity_Datas)
        {
            Vector Centre = new Vector();//分区中心点
            //处理数据：分区内多个图层
            for (int i = 0; i < File_Entity_Datas.SectionDataCollections.Count; i++)
            {
                Centre = GetCentre(File_Entity_Datas.SectionDataCollections[i]);//获取中心点
                File_Entity_Datas.SectionDataCollections[i].Centre = new Vector(Centre);//设置中心点
                //提取数据
                for (int j = 0; j < File_Entity_Datas.SectionDataCollections[i].SectionDatas.Count; j++)
                {
                    if (!File_Entity_Datas.SectionDataCollections[i].SectionDatas[j].EN) continue;
                    File_Entity_Datas.SectionDataCollections[i].SectionDatas[j].ArcLine = CentrelizeArcLine(File_Entity_Datas.SectionDataCollections[i].SectionDatas[j].ArcLine, Centre);
                    File_Entity_Datas.SectionDataCollections[i].SectionDatas[j].Circle = CentrelizeCircle(File_Entity_Datas.SectionDataCollections[i].SectionDatas[j].Circle, Centre);
                    File_Entity_Datas.SectionDataCollections[i].SectionDatas[j].LWPolyline = CentrelizeArcLine(File_Entity_Datas.SectionDataCollections[i].SectionDatas[j].LWPolyline, Centre);
                }
            }
            //处理数据：单分区单图层
            for (int i = 0; i < File_Entity_Datas.LayerSectionDatas.Count; i++)
            {
                for (int j = 0; j < File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas.Count; j++)
                {
                    Centre = GetCentre(File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas[j]);
                    File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas[j].Centre = new Vector(Centre);
                    File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas[j].ArcLine = CentrelizeArcLine(File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas[j].ArcLine, Centre);
                    File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas[j].Circle = CentrelizeCircle(File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas[j].Circle, Centre);
                    File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas[j].LWPolyline = CentrelizeArcLine(File_Entity_Datas.LayerSectionDatas[i].SectionEntityDatas[j].LWPolyline, Centre);
                }
            }
            return File_Entity_Datas;
        }
        /// <summary>
        /// 按照Centre重处理数据 支持ArcLine 和 LWPolyline
        /// </summary>
        /// <param name="In_Data"></param>
        /// <param name="Centre"></param>
        /// <returns></returns>
        public List<List<Entity_Data>> CentrelizeArcLine(List<List<Entity_Data>> In_Data, Vector Centre)
        {
            //结果变量
            List<List<Entity_Data>> Result = new List<List<Entity_Data>>();//结果
            List<Entity_Data> Temp_List_Data = new List<Entity_Data>();//内层数据
            Entity_Data Temp_Data = new Entity_Data();//临时数据 
            //初始清除
            Result.Clear();
            Temp_List_Data.Clear();
            Temp_Data.Empty();
            //数据处理部分
            foreach (var p in In_Data)
            {
                //清空内层数据
                Temp_List_Data.Clear();
                //提取数据
                foreach (var o in p)
                {
                    //数据获取
                    Temp_Data =new Entity_Data(o);
                    //直线和圆弧 通用坐标转换
                    Temp_Data.Start_x = o.Start_x - Centre.X;
                    Temp_Data.Start_y = o.Start_y - Centre.Y;
                    Temp_Data.End_x = o.End_x - Centre.X;
                    Temp_Data.End_y = o.End_y - Centre.Y;
                    //圆弧数据处理
                    if (o.Type == 2)
                    {
                        //RTC 圆弧加工圆心坐标转换
                        Temp_Data.Center_x = o.Center_x - Centre.X;
                        Temp_Data.Center_y = o.Center_y - Centre.Y;
                        //角度处理
                        Temp_Data.Angle = o.Cir_Start_Angle - o.Cir_End_Angle;
                    }
                    Temp_List_Data.Add(new Entity_Data(Temp_Data));
                }
                //追加结果
                Result.Add(new List<Entity_Data>(Temp_List_Data));
            }
            //返回结果
            return Result;
        }
        /// <summary>
        /// 按照Centre重处理数据 支持Circle
        /// </summary>
        /// <param name="In_Data"></param>
        /// <param name="Centre"></param>
        /// <returns></returns>
        public List<Entity_Data> CentrelizeCircle(List<Entity_Data> In_Data, Vector Centre)
        {
            //结果变量
            List<Entity_Data> Result = new List<Entity_Data>();//结果
            Entity_Data Temp_Data = new Entity_Data();//临时数据
            //初始清除
            Result.Clear();
            Temp_Data.Empty();
            //数据处理部分
            //提取数据
            foreach (var o in In_Data)
            {
                //数据获取
                Temp_Data = new Entity_Data(o);
                //RTC 圆弧加工圆心坐标转换
                Temp_Data.Center_x = o.Center_x - Centre.X;
                Temp_Data.Center_y = o.Center_y - Centre.Y;
                //RTC加工终点
                Temp_Data.Start_x = Temp_Data.Center_x;
                Temp_Data.Start_y = Temp_Data.Center_y + o.Circle_radius;
                Temp_Data.End_x = Temp_Data.Center_x;
                Temp_Data.End_y = Temp_Data.Center_y + o.Circle_radius;
                //RTC加工整圆角度
                // arc angle in ° as a 64 - bit IEEE floating point value
                // (positive angle values correspond to clockwise angles);
                // allowed range: [–3600.0° … +3600.0°] (±10 full circles);
                // out-of-range values will be edge-clipped.
                Temp_Data.Angle = 370;//这个参数得看RTC手册，整圆的旋转角度
                //追加数据
                Result.Add(new Entity_Data(Temp_Data));
            }
            //返回结果
            return Result;
        }

        /// <summary>
        /// 获取该分区中心坐标
        /// </summary>
        /// <param name="SectionEntityData"></param>
        /// <returns></returns>
        public Vector GetCentre(Section_Entity_Data SectionEntityData)
        {
            //变量初始化
            Vector Result = new Vector();
            List<decimal> Tem_Dat_X = new List<decimal>();
            List<decimal> Tem_Dat_Y = new List<decimal>();
            //获取数据
            if (SectionEntityData.ArcLine.Count > 0)
            {
                for (int i = 0; i < SectionEntityData.ArcLine.Count; i++)
                {
                    if (SectionEntityData.ArcLine[i].Count >= 0)//判断数据大于零
                    {
                        Tem_Dat_X.Add(SectionEntityData.ArcLine[i].Max(o => o.Start_x));
                        Tem_Dat_X.Add(SectionEntityData.ArcLine[i].Min(o => o.Start_x));
                        Tem_Dat_X.Add(SectionEntityData.ArcLine[i].Max(o => o.End_x));
                        Tem_Dat_X.Add(SectionEntityData.ArcLine[i].Min(o => o.End_x));
                        Tem_Dat_Y.Add(SectionEntityData.ArcLine[i].Max(o => o.Start_y));
                        Tem_Dat_Y.Add(SectionEntityData.ArcLine[i].Min(o => o.Start_y));
                        Tem_Dat_Y.Add(SectionEntityData.ArcLine[i].Max(o => o.End_y));
                        Tem_Dat_Y.Add(SectionEntityData.ArcLine[i].Min(o => o.End_y));
                    }
                }
            }
            if (SectionEntityData.Circle.Count > 0)
            {
                Tem_Dat_X.Add(SectionEntityData.Circle.Max(o => o.Center_x));
                Tem_Dat_X.Add(SectionEntityData.Circle.Min(o => o.Center_x));
                Tem_Dat_Y.Add(SectionEntityData.Circle.Max(o => o.Center_y));
                Tem_Dat_Y.Add(SectionEntityData.Circle.Min(o => o.Center_y));
            }
            if (SectionEntityData.LWPolyline.Count > 0)
            {
                for (int i = 0; i < SectionEntityData.LWPolyline.Count; i++)
                {
                    if (SectionEntityData.LWPolyline[i].Count >= 0)//判断数据大于零
                    {
                        Tem_Dat_X.Add(SectionEntityData.LWPolyline[i].Max(o => o.Start_x));
                        Tem_Dat_X.Add(SectionEntityData.LWPolyline[i].Min(o => o.Start_x));
                        Tem_Dat_X.Add(SectionEntityData.LWPolyline[i].Max(o => o.End_x));
                        Tem_Dat_X.Add(SectionEntityData.LWPolyline[i].Min(o => o.End_x));
                        Tem_Dat_Y.Add(SectionEntityData.LWPolyline[i].Max(o => o.Start_y));
                        Tem_Dat_Y.Add(SectionEntityData.LWPolyline[i].Min(o => o.Start_y));
                        Tem_Dat_Y.Add(SectionEntityData.LWPolyline[i].Max(o => o.End_y));
                        Tem_Dat_Y.Add(SectionEntityData.LWPolyline[i].Min(o => o.End_y));
                    }
                }
            }
            //计算返回坐标
            if ((Tem_Dat_X.Count <= 0) || (Tem_Dat_Y.Count <= 0))
                Result = new Vector(0,0);
            else
                Result = new Vector((Tem_Dat_X.Max() + Tem_Dat_X.Min()) / 2, (Tem_Dat_Y.Max() + Tem_Dat_Y.Min()) / 2);
            return Result;
        }
        /// <summary>
        /// 获取该分区中心坐标
        /// </summary>
        /// <param name="SectionDataCollection"></param>
        /// <returns></returns>
        public Vector GetCentre(SectionDataCollection SectionDataCollection)
        {
            //变量初始化
            Vector Result = new Vector();
            List<decimal> Tem_Dat_X = new List<decimal>();
            List<decimal> Tem_Dat_Y = new List<decimal>();
            //获取数据
            foreach (var o in SectionDataCollection.SectionDatas)
            {
                if (!o.EN) continue;
                if (o.ArcLine.Count > 0)
                {
                    for (int i = 0; i < o.ArcLine.Count; i++)
                    {
                        if (o.ArcLine[i].Count >= 0)//判断数据大于零
                        {
                            Tem_Dat_X.Add(o.ArcLine[i].Max(p => p.Start_x));
                            Tem_Dat_X.Add(o.ArcLine[i].Min(p => p.Start_x));
                            Tem_Dat_X.Add(o.ArcLine[i].Max(p => p.End_x));
                            Tem_Dat_X.Add(o.ArcLine[i].Min(p => p.End_x));
                            Tem_Dat_Y.Add(o.ArcLine[i].Max(p => p.Start_y));
                            Tem_Dat_Y.Add(o.ArcLine[i].Min(p => p.Start_y));
                            Tem_Dat_Y.Add(o.ArcLine[i].Max(p => p.End_y));
                            Tem_Dat_Y.Add(o.ArcLine[i].Min(p => p.End_y));
                        }
                    }
                }
                if (o.Circle.Count > 0)
                {
                    Tem_Dat_X.Add(o.Circle.Max(p => p.Center_x));
                    Tem_Dat_X.Add(o.Circle.Min(p => p.Center_x));
                    Tem_Dat_Y.Add(o.Circle.Max(p => p.Center_y));
                    Tem_Dat_Y.Add(o.Circle.Min(p => p.Center_y));
                }
                if (o.LWPolyline.Count > 0)
                {
                    for (int i = 0; i < o.LWPolyline.Count; i++)
                    {
                        if (o.LWPolyline[i].Count >= 0)//判断数据大于零
                        {
                            Tem_Dat_X.Add(o.LWPolyline[i].Max(p => p.Start_x));
                            Tem_Dat_X.Add(o.LWPolyline[i].Min(p => p.Start_x));
                            Tem_Dat_X.Add(o.LWPolyline[i].Max(p => p.End_x));
                            Tem_Dat_X.Add(o.LWPolyline[i].Min(p => p.End_x));
                            Tem_Dat_Y.Add(o.LWPolyline[i].Max(p => p.Start_y));
                            Tem_Dat_Y.Add(o.LWPolyline[i].Min(p => p.Start_y));
                            Tem_Dat_Y.Add(o.LWPolyline[i].Max(p => p.End_y));
                            Tem_Dat_Y.Add(o.LWPolyline[i].Min(p => p.End_y));
                        }
                    }
                }
            }
            //计算返回坐标
            if ((Tem_Dat_X.Count <= 0) || (Tem_Dat_Y.Count <= 0))
                Result = new Vector(0, 0);
            else
                Result = new Vector((Tem_Dat_X.Max() + Tem_Dat_X.Min()) / 2, (Tem_Dat_Y.Max() + Tem_Dat_Y.Min()) / 2);
            return Result;
        }
    }
}

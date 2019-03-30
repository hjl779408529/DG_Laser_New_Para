using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DG_Laser
{
    /// <summary>
    /// 向量
    /// </summary>
    [Serializable]
    public class Vector
    {
        public decimal X { get; set; }
        public decimal Y { get; set; }
        [SharpConfig.Ignore]
        public decimal Length
        {
            get => (decimal)Math.Sqrt((double)(this.X * this.X + this.Y * this.Y));
        }
        public Vector()
        {
            this.X = 0;
            this.Y = 0;
        }
        public Vector(decimal x, decimal y)
        {
            this.X = x;
            this.Y = y;
        }
        public Vector(Vector Ini)
        {
            this.X = Ini.X;
            this.Y = Ini.Y;
        }
        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.X - b.X, a.Y - b.Y);
        }
        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.X + b.X, a.Y + b.Y);
        }
    }
    /// <summary>
    /// 仿射变换参数
    /// </summary>
    [Serializable]
    public class Affinity_Matrix
    {
        //共有属性
        public decimal Stretch_X { get; set; }
        public decimal Distortion_X { get; set; }
        public decimal Delta_X { get; set; }
        public decimal Stretch_Y { get; set; }
        public decimal Distortion_Y { get; set; }
        public decimal Delta_Y { get; set; }

        //公开构造函数    
        public Affinity_Matrix()
        {
            this.Stretch_X = 0;
            this.Distortion_X = 0;
            this.Delta_X = 0;
            this.Stretch_Y = 0;
            this.Distortion_Y = 0;
            this.Delta_Y = 0;
        }
        //有参数
        public Affinity_Matrix(decimal stretch_x, decimal distortion_x, decimal delta_x, decimal stretch_y, decimal distortion_y, decimal delta_y)
        {
            this.Stretch_X = stretch_x;
            this.Distortion_X = distortion_x;
            this.Stretch_Y = stretch_y;
            this.Distortion_Y = distortion_y;
            this.Delta_X = delta_x;
            this.Delta_Y = delta_y;
        }
        public Affinity_Matrix(Affinity_Matrix Ini)
        {
            this.Stretch_X = Ini.Stretch_X;
            this.Distortion_X = Ini.Distortion_X;
            this.Delta_X = Ini.Delta_X;
            this.Stretch_Y = Ini.Stretch_Y;
            this.Distortion_Y = Ini.Distortion_Y;
            this.Delta_Y = Ini.Delta_Y;
        }
    }
    //矫正数据存储
    [Serializable]
    public struct Correct_Data
    {
        //私有属性
        private decimal xo, yo;//x0,y0--基准坐标
        private decimal xm, ym;//x1,y1--轴实际坐标 

        //公开访问的属性
        public decimal Xo
        {
            get { return xo; }
            set { xo = value; }
        }
        public decimal Yo
        {
            get { return yo; }
            set { yo = value; }
        }
        public decimal Xm
        {
            get { return xm; }
            set { xm = value; }
        }
        public decimal Ym
        {
            get { return ym; }
            set { ym = value; }
        }


        //公开访问的方法
        //构造函数
        public Correct_Data(Correct_Data Ini)
        {
            this.xo = Ini.Xo;
            this.yo = Ini.Yo;
            this.xm = Ini.Xm;
            this.ym = Ini.Ym;
        }
        public Correct_Data(decimal xo, decimal yo, decimal xm, decimal ym)
        {
            this.xo = xo;
            this.yo = yo;
            this.xm = xm;
            this.ym = ym;
        }
        //清空数据
        public void Empty()
        {
            this.xo = 0;
            this.yo = 0;
            this.xm = 0;
            this.ym = 0;
        }
    }
    public struct Fit_Data
    {
        //私有属性 
        private decimal k1, k2, k3, k4;//k1-1次系数，k2-2次系数，k3-3次系数，k4-4次系数
        private decimal delta;//坐标偏移值
        //共有属性
        public decimal K1
        {
            get { return k1; }
            set { k1 = value; }
        }
        public decimal K2
        {
            get { return k2; }
            set { k2 = value; }
        }
        public decimal K3
        {
            get { return k3; }
            set { k3 = value; }
        }
        public decimal K4
        {
            get { return k4; }
            set { k4 = value; }
        }
        public decimal Delta
        {
            get { return delta; }
            set { delta = value; }
        }
        //公开构造函数        
        //有参数
        public Fit_Data(decimal k1, decimal k2, decimal k3, decimal k4, decimal delta)
        {
            this.k1 = k1;
            this.k2 = k2;
            this.k3 = k3;
            this.k4 = k4;
            this.delta = delta;
        }
        public Fit_Data(Fit_Data Ini)
        {
            this.k1 = Ini.K1;
            this.k2 = Ini.K2;
            this.k3 = Ini.K3;
            this.k4 = Ini.K4;
            this.delta = Ini.Delta;
        }
        //清空
        public void Empty()
        {
            this.k1 = 0;
            this.k2 = 0;
            this.k3 = 0;
            this.k4 = 0;
            this.delta = 0;
        }
    }
    public struct Double_Fit_Data
    {
        //私有属性 
        private decimal k_x1, k_x2, k_x3, k_x4;//k_x1-1次系数，k_x2-2次系数，k_x3-3次系数，k_x4-4次系数
        private decimal delta_x;//坐标偏移值
        private decimal k_y1, k_y2, k_y3, k_y4;//k_y1-1次系数，k_y2-2次系数，k_y3-3次系数，k_y4-4次系数
        private decimal delta_y;//坐标偏移值
        //共有属性
        public decimal K_X1
        {
            get { return k_x1; }
            set { k_x1 = value; }
        }
        public decimal K_X2
        {
            get { return k_x2; }
            set { k_x2 = value; }
        }
        public decimal K_X3
        {
            get { return k_x3; }
            set { k_x3 = value; }
        }
        public decimal K_X4
        {
            get { return k_x4; }
            set { k_x4 = value; }
        }
        public decimal Delta_X
        {
            get { return delta_x; }
            set { delta_x = value; }
        }
        public decimal K_Y1
        {
            get { return k_y1; }
            set { k_y1 = value; }
        }
        public decimal K_Y2
        {
            get { return k_y2; }
            set { k_y2 = value; }
        }
        public decimal K_Y3
        {
            get { return k_y3; }
            set { k_y3 = value; }
        }
        public decimal K_Y4
        {
            get { return k_y4; }
            set { k_y4 = value; }
        }
        public decimal Delta_Y
        {
            get { return delta_y; }
            set { delta_y = value; }
        }

        //公开构造函数        
        //有参数
        public Double_Fit_Data(decimal k_x1, decimal k_x2, decimal k_x3, decimal k_x4, decimal delta_x, decimal k_y1, decimal k_y2, decimal k_y3, decimal k_y4, decimal delta_y)
        {
            this.k_x1 = k_x1;
            this.k_x2 = k_x2;
            this.k_x3 = k_x3;
            this.k_x4 = k_x4;
            this.delta_x = delta_x;
            this.k_y1 = k_y1;
            this.k_y2 = k_y2;
            this.k_y3 = k_y3;
            this.k_y4 = k_y4;
            this.delta_y = delta_y;
        }
        public Double_Fit_Data(Double_Fit_Data Ini)
        {
            this.k_x1 = Ini.K_X1;
            this.k_x2 = Ini.K_X2;
            this.k_x3 = Ini.K_X3;
            this.k_x4 = Ini.K_X4;
            this.delta_x = Ini.Delta_X;
            this.k_y1 = Ini.K_Y1;
            this.k_y2 = Ini.K_Y2;
            this.k_y3 = Ini.K_Y3;
            this.k_y4 = Ini.K_Y4;
            this.delta_y = Ini.Delta_Y;
        }
        //清空
        public void Empty()
        {
            this.k_x1 = 0;
            this.k_x2 = 0;
            this.k_x3 = 0;
            this.k_x4 = 0;
            this.delta_x = 0;
            this.k_y1 = 0;
            this.k_y2 = 0;
            this.k_y3 = 0;
            this.k_y4 = 0;
            this.delta_y = 0;
        }
    }
    [Serializable]
    public class Tech_Parameter
    {
        //共有属性
        /// <summary>
        /// 刀具名称
        /// </summary>
        public string Scissors_Name { get; set; }
        /// <summary>
        /// 重复次数
        /// </summary>
        public int RepeatTime { get; set; }
        /// <summary>
        /// 聚焦偏移
        /// </summary>
        public decimal FocusOffSet { get; set; }
        /// <summary>
        /// 焦距补偿值
        /// </summary>
        public decimal FocusCompensation { get; set; }
        /// <summary>
        /// 焦距补偿次数间隔
        /// </summary>
        public int FocusCompensationTimes { get; set; }
        /// <summary>
        /// 停顿延时值
        /// </summary>
        public int DelayCompensation { get; set; }
        /// <summary>
        /// 焦距补偿次数间隔
        /// </summary>
        public int DelayCompensationTimes { get; set; }
        /// <summary>
        /// 是否开吹气
        /// </summary>
        public bool Blow { get; set; }

        /// <summary>
        /// 刀具编号
        /// </summary>
        public Int16 Scissors_Type { get; set; }
        /// <summary>
        /// 功率百分比
        /// </summary>
        public decimal PEC { get; set; }
        /// <summary>
        /// 激光频率
        /// </summary>
        public decimal PRF { get; set; }
        /// <summary>
        /// 跳转速度
        /// </summary>
        public double Jump_Speed { get; set; }
        /// <summary>
        /// 标刻速度
        /// </summary>
        public double Mark_Speed { get; set; }
        /// <summary>
        /// 开光延时
        /// </summary>
        public decimal Laser_On_Delay { get; set; }
        /// <summary>
        /// 关光延时
        /// </summary>
        public decimal Laser_Off_Delay { get; set; }
        /// <summary>
        /// 跳转延时
        /// </summary>
        public decimal Jump_Delay { get; set; }
        /// <summary>
        /// 标刻延时
        /// </summary>
        public decimal Mark_Delay { get; set; }
        /// <summary>
        /// 转折延时
        /// </summary>
        public decimal Polygon_Delay { get; set; }
        /// <summary>
        /// 钻孔类型
        /// </summary>
        public int Cutter_Type { get; set; }
        /// <summary>
        /// 偏移距离
        /// </summary>
        public decimal Cutter_Radius { get; set; }

        //公开构造函数      
        public Tech_Parameter() { }
        //有参数
        public Tech_Parameter(string scissors_name,int repeattime,decimal focusoffSet,decimal focuscompensation,int focuscompensationtimes, int delaycompensation, int delaycompensationtimes, bool blow,Int16 scissors_type, decimal pec, decimal prf, double jump_speed, double mark_speed, decimal laser_on_delay, decimal laser_off_delay, decimal jump_delay, decimal mark_delay, decimal polygon_delay, short cutter_type, decimal cutter_radius)
        {
            this.Scissors_Name = scissors_name;
            this.RepeatTime = repeattime;
            this.FocusOffSet = focusoffSet;
            this.FocusCompensation = focuscompensation;
            this.FocusCompensationTimes = focuscompensationtimes;
            this.DelayCompensation = delaycompensation;
            this.DelayCompensationTimes = delaycompensationtimes;
            this.Blow = blow;
            this.Scissors_Type = scissors_type;
            this.PEC = pec;
            this.PRF = prf;
            this.Jump_Speed = jump_speed;
            this.Mark_Speed = mark_speed;
            this.Laser_On_Delay = laser_on_delay;
            this.Laser_Off_Delay = laser_off_delay;
            this.Jump_Delay = jump_delay;
            this.Mark_Delay = mark_delay;
            this.Polygon_Delay = polygon_delay;
            this.Cutter_Type = cutter_type;
            this.Cutter_Radius = cutter_radius;
        }
        public Tech_Parameter(Tech_Parameter Ini)
        {
            this.Scissors_Name = Ini.Scissors_Name;
            this.RepeatTime = Ini.RepeatTime;
            this.FocusOffSet = Ini.FocusOffSet;
            this.FocusCompensation = Ini.FocusCompensation;
            this.FocusCompensationTimes = Ini.FocusCompensationTimes;
            this.DelayCompensation = Ini.DelayCompensation;
            this.DelayCompensationTimes = Ini.DelayCompensationTimes;
            this.Blow = Ini.Blow;
            this.Scissors_Type = Ini.Scissors_Type;
            this.PEC = Ini.PEC;
            this.PRF = Ini.PRF;
            this.Jump_Speed = Ini.Jump_Speed;
            this.Mark_Speed = Ini.Mark_Speed;
            this.Laser_On_Delay = Ini.Laser_On_Delay;
            this.Laser_Off_Delay = Ini.Laser_Off_Delay;
            this.Jump_Delay = Ini.Jump_Delay;
            this.Mark_Delay = Ini.Mark_Delay;
            this.Polygon_Delay = Ini.Polygon_Delay;
            this.Cutter_Type = Ini.Cutter_Type;
            this.Cutter_Radius = Ini.Cutter_Radius;

        }
        //清空
        public void Empty()
        {
            this.Scissors_Name = "";
            this.RepeatTime = 0;
            this.FocusOffSet = 0;
            this.FocusCompensation = 0;
            this.FocusCompensationTimes = 0;
            this.DelayCompensation = 0;
            this.DelayCompensationTimes = 0;
            this.Blow = false;
            this.Scissors_Type = 0;
            this.PEC = 0;
            this.PRF = 0;
            this.Jump_Speed = 0;
            this.Mark_Speed = 0;
            this.Laser_On_Delay = 0;
            this.Laser_Off_Delay = 0;
            this.Jump_Delay = 0;
            this.Mark_Delay = 0;
            this.Polygon_Delay = 0;
            this.Cutter_Type = 0;
            this.Cutter_Radius = 0;
        }
        //清空
        public void Original()
        {
            this.Scissors_Name = "default";
            this.RepeatTime = 1;
            this.FocusOffSet = 0;
            this.FocusCompensation = 0;
            this.FocusCompensationTimes = 0;
            this.DelayCompensation = 0;
            this.DelayCompensationTimes = 0;
            this.Blow = false;
            this.PEC = 30;
            this.PRF = 400;
            this.Jump_Speed = 500;
            this.Mark_Speed = 200;
            this.Laser_On_Delay = 40;
            this.Laser_Off_Delay = 180;
            this.Jump_Delay = 600;
            this.Mark_Delay = 300;
            this.Polygon_Delay = 5;
            this.Scissors_Type = 0;
            this.Cutter_Type = 0;
            this.Cutter_Radius = 0;
        }
    }
    
    /// <summary>
    /// 状态数据变量
    /// </summary>
    public class StatusStruct
    {
        /// <summary>
        /// 激光状态：0 - 主电源关，1 - 运行中，2 - 待机状态
        /// </summary>
        public int LaserState { get; set; }
        /// <summary>
        /// 平台X坐标
        /// </summary>
        public decimal X { get; set; }
        /// <summary>
        /// 平台Y坐标
        /// </summary>
        public decimal Y { get; set; }
        /// <summary>
        /// 平台Z坐标
        /// </summary>
        public decimal Z { get; set; }
        /// <summary>
        /// 加工进度
        /// </summary>
        public int Process { get; set; }
        /// <summary>
        /// BeginTime 开始时间
        /// </summary>
        public string BeginTime { get; set; }
        /// <summary>
        /// EndTime 终止时间
        /// </summary>
        public string EndTime { get; set; }
        /// <summary>
        /// duration 持续时间
        /// </summary>
        public string Duration { get; set; }
        /// <summary>
        /// 总片数
        /// </summary>
        public int TotalPieces { get; set; }
        /// <summary>
        /// 已完成片数
        /// </summary>
        public int FinishedPieces { get; set; }
        /// <summary>
        /// 当前文档
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 当前编号
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// 当前刀具
        /// </summary>
        public string ScissorName { get; set; }
        /// <summary>
        /// 当前刀具重复总次数
        /// </summary>
        public int ScissorTotalRepeat { get; set; }
        /// <summary>
        /// 当前刀具已重复次数
        /// </summary>
        public int ScissorCurrentRepeat { get; set; }
        /// <summary>
        /// 当前功率
        /// </summary>
        public decimal LaserPEC { get; set; }
        /// <summary>
        /// 当前频率
        /// </summary>
        public decimal LaserPRF { get; set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        public StatusStruct()
        {

        }



    }
    /// <summary>
    /// 基础轨迹数据
    /// </summary>
    public class Entity_Data
    {
        public int Path_Type;//路径类型
        public int Color;//元件颜色，用于划分加工分区 
        public short Type;//插补代号：1-直线插补，2-圆弧插补（圆心描述），3-圆弧插补（半径描述，不可描述整圆）
        public decimal Angle;//角度
        public decimal Start_x;//插补起点X坐标
        public decimal Start_y;//插补起点Y坐标
        public decimal End_x;//插补终点X坐标
        public decimal End_y;//插补终点Y坐标
        public decimal Center_x;//圆心坐标x
        public decimal Center_y;//圆心坐标y
        public decimal Center_Start_x;//圆心坐标x-起点坐标x
        public decimal Center_Start_y;//圆心坐标y-起点坐标y
        public decimal Cir_Start_Angle;//圆弧起始角度
        public decimal Cir_End_Angle;//圆弧终止角度
        public decimal Circle_radius;//圆弧半径
        public short Circle_dir;//圆弧方向：顺时针-0，逆时针-1
        public Entity_Data()
        {
            Path_Type = 0;
            Type = 0;//插补代号：1-直线插补，2-圆弧插补（圆心描述），3-圆弧插补（半径描述，不可描述整圆）
            this.Color = 0;//元件颜色，用于划分加工分区
            Angle = 0;//备用
            Start_x = 0m;//插补起点X坐标
            Start_y = 0m;//插补起点Y坐标
            End_x = 0m;//插补终点X坐标
            End_y = 0m;//插补终点Y坐标
            Center_x = 0m;//圆心坐标x
            Center_y = 0m;//圆心坐标y
            Center_Start_x = 0m;//圆心坐标x-起点坐标x
            Center_Start_y = 0m;//圆心坐标y-起点坐标y 
            Cir_Start_Angle = 0m;//圆弧起始角度
            Cir_End_Angle = 0m;//圆弧终止角度 
            Circle_radius = 0m;//圆弧半径
            Circle_dir = 0;//圆弧方向：顺时针-0，逆时针-1
        }
        public Entity_Data(Entity_Data Ini)
        {
            this.Path_Type = Ini.Path_Type;//刀具类型
            this.Color = Ini.Color;//元件颜色，用于划分加工分区 
            this.Type = Ini.Type;//插补代号：1-直线插补，2-圆弧插补（圆心描述），3-圆弧插补（半径描述，不可描述整圆）
            this.Angle = Ini.Angle;//备用
            this.Start_x = Ini.Start_x;//插补起点X坐标
            this.Start_y = Ini.Start_y;//插补起点Y坐标
            this.End_x = Ini.End_x;//插补终点X坐标
            this.End_y = Ini.End_y;//插补终点Y坐标
            this.Center_x = Ini.Center_x;//圆心坐标x
            this.Center_y = Ini.Center_y;//圆心坐标y
            this.Center_Start_x = Ini.Center_Start_x;//圆心坐标x-起点坐标x
            this.Center_Start_y = Ini.Center_Start_y;//圆心坐标y-起点坐标y
            this.Cir_Start_Angle = Ini.Cir_Start_Angle;//圆弧起始角度
            this.Cir_End_Angle = Ini.Cir_End_Angle;//圆弧终止角度
            this.Circle_radius = Ini.Circle_radius;//圆弧半径
            this.Circle_dir = Ini.Circle_dir;//圆弧方向：顺时针-0，逆时针-1 
        }
        public void Empty()
        {
            Path_Type = 0;
            Type = 0;//插补代号：1-直线插补，2-圆弧插补（圆心描述），3-圆弧插补（半径描述，不可描述整圆）
            Angle = 0;//备用
            Start_x = 0m;//插补起点X坐标
            Start_y = 0m;//插补起点Y坐标
            End_x = 0m;//插补终点X坐标
            End_y = 0m;//插补终点Y坐标
            Center_x = 0m;//圆心坐标x
            Center_y = 0m;//圆心坐标y
            Center_Start_x = 0m;//圆心坐标x-起点坐标x
            Center_Start_y = 0m;//圆心坐标y-起点坐标y 
            Cir_Start_Angle = 0m;//圆弧起始角度
            Cir_End_Angle = 0m;//圆弧终止角度 
            Circle_radius = 0m;//圆弧半径
            Circle_dir = 0;//圆弧方向：顺时针-0，逆时针-1
        }
    }
    /// <summary>
    /// 文件整合数据
    /// </summary>
    public class File_Entity_Data
    {
        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 当前文件Laser分区编号，主要是颜色
        /// </summary>
        public List<int> SectionList { get; set; }
        /// <summary>
        /// DXF文件Mark信息
        /// </summary>
        public List<Vector> DxfMarkInfo = new List<Vector>();

        /// <summary>
        /// 平台Mark信息
        /// </summary>
        public List<Vector> PlatformMarkInfo = new List<Vector>();

        /// <summary>
        /// 分区数据
        /// </summary>
        public List<Integrate_Entity_Data> LayerSectionDatas = new List<Integrate_Entity_Data>();

        /// <summary>
        /// 分区数据，分区内包含多图层数据
        /// </summary>
        public List<SectionDataCollection> SectionDataCollections = new List<SectionDataCollection>();

        /// <summary>
        /// 构造函数
        /// </summary>
        public File_Entity_Data()
        {
            this.FileName = "";
            this.SectionList = new List<int>();
            this.DxfMarkInfo = new List<Vector>();
            this.PlatformMarkInfo = new List<Vector>();
            this.LayerSectionDatas = new List<Integrate_Entity_Data>();
            this.SectionDataCollections = new List<SectionDataCollection>();
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        public File_Entity_Data(File_Entity_Data Ini)
        {
            this.FileName = Ini.FileName;
            this.SectionList = Ini.SectionList;
            this.DxfMarkInfo = Ini.DxfMarkInfo;
            this.PlatformMarkInfo = Ini.PlatformMarkInfo;
            this.LayerSectionDatas = Ini.LayerSectionDatas;
            this.SectionDataCollections = Ini.SectionDataCollections;
        }
        /// <summary>
        /// 初始化清空
        /// </summary>
        public void Empty()
        {
            this.FileName = "";
            this.SectionList = new List<int>();
            this.DxfMarkInfo = new List<Vector>();
            this.PlatformMarkInfo = new List<Vector>();
            this.LayerSectionDatas = new List<Integrate_Entity_Data>();
            this.SectionDataCollections = new List<SectionDataCollection>();
        }

    }
    /// <summary>
    /// 分区整合元素数组
    /// </summary>
    public class Integrate_Entity_Data
    {
        /// <summary>
        /// 图层名
        /// </summary>
        public string LayerName { get; set; }

        /// <summary>
        /// 分区数据
        /// </summary>
        public List<Section_Entity_Data> SectionEntityDatas = new List<Section_Entity_Data>();
        /// <summary>
        /// 构造函数
        /// </summary>
        public Integrate_Entity_Data()
        {

        }
        /// <summary>
        /// 构造函数
        /// </summary>
        public Integrate_Entity_Data(Integrate_Entity_Data Ini)
        {
            this.LayerName = Ini.LayerName;
            this.SectionEntityDatas = Ini.SectionEntityDatas;
        }
        /// <summary>
        /// 初始化清空
        /// </summary>
        public void Empty()
        {
            this.LayerName = "";
            this.SectionEntityDatas = new List<Section_Entity_Data>();
        }
    }
    /// <summary>
    /// 分区数据
    /// </summary>
    public class Section_Entity_Data
    {
        /// <summary>
        /// 分区划分
        /// </summary>
        public int Color { get; set; }
        /// <summary>
        /// 平台基准坐标
        /// </summary>
        public Vector Centre = new Vector();
        /// <summary>
        /// 实体信息 圆弧和直线
        /// </summary>
        public List<List<Entity_Data>> ArcLine = new List<List<Entity_Data>>();
        /// <summary>
        /// 实体信息 整圆
        /// </summary>
        public List<Entity_Data> Circle = new List<Entity_Data>();
        /// <summary>
        /// 实体信息 多段线
        /// </summary>
        public List<List<Entity_Data>> LWPolyline = new List<List<Entity_Data>>();
        /// <summary>
        /// 构造函数
        /// </summary>
        public Section_Entity_Data()
        {
            this.Color = 0;
            this.Centre = new Vector();
            this.ArcLine = new List<List<Entity_Data>>();
            this.Circle = new List<Entity_Data>();
            this.LWPolyline = new List<List<Entity_Data>>();
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        public Section_Entity_Data(Section_Entity_Data Ini)
        {
            this.Color = Ini.Color;
            this.Centre = Ini.Centre;
            this.ArcLine = Ini.ArcLine;
            this.Circle = Ini.Circle;
            this.LWPolyline = Ini.LWPolyline;
        }
        /// <summary>
        /// 初始化清空
        /// </summary>
        public void Empty()
        {
            this.Color = 0;
            this.Centre = new Vector();
            this.ArcLine = new List<List<Entity_Data>>();
            this.Circle = new List<Entity_Data>();
            this.LWPolyline = new List<List<Entity_Data>>();
        }
    }
    /// <summary>
    /// 分区数据集合
    /// </summary>
    public class SectionDataCollection
    {
        /// <summary>
        /// 分区划分
        /// </summary>
        public int Color { get; set; }
        /// <summary>
        /// 平台基准坐标
        /// </summary>
        public Vector Centre = new Vector();
        /// <summary>
        /// 分区数据
        /// </summary>
        public List<SectionData> SectionDatas = new List<SectionData>();
        /// <summary>
        /// 构造函数
        /// </summary>
        public SectionDataCollection()
        {
            this.Color = 0;
            this.Centre = new Vector();
            this.SectionDatas = new List<SectionData>();
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        public SectionDataCollection(SectionDataCollection Ini)
        {
            this.Color = Ini.Color;
            this.Centre = Ini.Centre;
            this.SectionDatas = Ini.SectionDatas;
        }
        /// <summary>
        /// 初始化清空
        /// </summary>
        public void Empty()
        {
            this.Color = 0;
            this.Centre = new Vector();
            this.SectionDatas = new List<SectionData>();
        }
    }
    [Serializable]
    /// <summary>
    /// 单数据
    /// </summary>
    public class SectionData
    {
        /// <summary>
        /// 是否存在数据
        /// </summary>
        public bool EN { get; set; }
        /// <summary>
        /// 图层名
        /// </summary>
        public string LayerName { get; set; }
        /// <summary>
        /// 实体信息 圆弧和直线
        /// </summary>
        public List<List<Entity_Data>> ArcLine = new List<List<Entity_Data>>();
        /// <summary>
        /// 实体信息 整圆
        /// </summary>
        public List<Entity_Data> Circle = new List<Entity_Data>();
        /// <summary>
        /// 实体信息 多段线
        /// </summary>
        public List<List<Entity_Data>> LWPolyline = new List<List<Entity_Data>>();
        /// <summary>
        /// 构造函数
        /// </summary>
        public SectionData()
        {
            this.EN = false;
            this.LayerName = "";
            this.ArcLine = new List<List<Entity_Data>>();
            this.Circle = new List<Entity_Data>();
            this.LWPolyline = new List<List<Entity_Data>>();
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        public SectionData(SectionData Ini)
        {
            this.EN = Ini.EN;
            this.LayerName = Ini.LayerName;
            this.ArcLine = Ini.ArcLine;
            this.Circle = Ini.Circle;
            this.LWPolyline = Ini.LWPolyline;
        }
        /// <summary>
        /// 初始化清空
        /// </summary>
        public void Empty()
        {
            this.EN = false;
            this.LayerName = "";
            this.ArcLine = new List<List<Entity_Data>>();
            this.Circle = new List<Entity_Data>();
            this.LWPolyline = new List<List<Entity_Data>>();
        }
    }
    //Max 和 Min 判断
    [Serializable]
    public class Extreme
    {
        private decimal x_max;
        private decimal x_min;
        private decimal y_max;
        private decimal y_min;
        private decimal delta_x;
        private decimal delta_y;

        public decimal X_Max { get => x_max; set => x_max = value; }
        public decimal X_Min { get => x_min; set => x_min = value; }
        public decimal Y_Max { get => y_max; set => y_max = value; }
        public decimal Y_Min { get => y_min; set => y_min = value; }
        public decimal Delta_X { get => delta_x; set => delta_x = value; }
        public decimal Delta_Y { get => delta_y; set => delta_y = value; }
        public Extreme()
        {
            this.x_max = 0;
            this.x_min = 0;
            this.y_max = 0;
            this.y_min = 0;
            this.delta_x = 0;
            this.delta_y = 0;
        }
        public Extreme(decimal x_max, decimal x_min, decimal y_max, decimal y_min, decimal delta_x, decimal delta_y)
        {
            this.x_max = x_max;
            this.x_min = x_min;
            this.y_max = y_max;
            this.y_min = y_min;
            this.delta_x = delta_x;
            this.delta_y = delta_y;
        }
        public Extreme(Extreme Ini)
        {
            this.x_max = Ini.x_max;
            this.x_min = Ini.x_min;
            this.y_max = Ini.y_max;
            this.y_min = Ini.y_min;
            this.delta_x = Ini.delta_x;
            this.delta_y = Ini.delta_y;
        }
        public void Empty()
        {
            this.x_max = 0;
            this.x_min = 0;
            this.y_max = 0;
            this.y_min = 0;
            this.delta_x = 0;
            this.delta_y = 0;
        }
    }
    //文件配置
    [Serializable]
    public class FileConfig
    {
        /// <summary>
        /// DXf文件名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// DXf路径名
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 文件在平台的位置
        /// </summary>
        public Vector PlatFormPos { get; set; }

        /// <summary>
        /// 图层刀具列表
        /// </summary>
        public List<LayerScissor> LayerScissor = new List<LayerScissor>();
        
        /// <summary>
        /// 总片数
        /// </summary>
        public Int16 TotalPieces { get; set; }
        /// <summary>
        /// 起始片数
        /// </summary>
        public Int16 StartPieces { get; set; }
        /// <summary>
        /// 提醒片数
        /// </summary>
        public Int16 AlarmPieces { get; set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        public FileConfig()
        {
            this.Name = "";
            this.Path = "";
            this.PlatFormPos = new Vector();
            this.LayerScissor = new List<LayerScissor>();
            this.TotalPieces = 0;
            this.StartPieces = 0;
            this.AlarmPieces = 0;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="Ini"></param>
        public FileConfig(FileConfig Ini)
        {
            this.Name = Ini.Name;
            this.Path = Ini.Path;
            this.PlatFormPos = Ini.PlatFormPos;
            this.LayerScissor = Ini.LayerScissor;
            this.TotalPieces = Ini.TotalPieces;
            this.StartPieces = Ini.StartPieces;
            this.AlarmPieces = Ini.AlarmPieces;
        }
        /// <summary>
        /// Laser的图层
        /// </summary>
        public List<string> LaserLayer
        {
            get => this.LayerScissor.Where(o => o.Laser == true).Select(o => o.Layer).ToList();
        }

    }
    //图层刀具配置
    [Serializable]
    public class LayerScissor
    {
        /// <summary>
        /// 图层列表
        /// </summary>
        public string Layer { get; set; }
        /// <summary>
        /// 刀具列表
        /// </summary>
        public List<string> Scissor = new List<string>();
        /// <summary>
        /// 是否激光加工层
        /// </summary>
        public bool Laser { get; set; }
        /// <summary>
        /// 是否激光加工层
        /// </summary>
        public bool Mark { get; set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        public LayerScissor()
        {

        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="layer"></param>
        /// <param name="scissor"></param>
        public LayerScissor(string layer, List<string> scissor,bool laser,bool mark)
        {
            this.Layer = layer;
            this.Scissor = scissor;
            this.Laser = laser;
            this.Mark = mark;
        }
    }
    //材料库
    [Serializable]
    public class MaterialStorage
    {
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 材料列表
        /// </summary>
        public List<Material> MaterialList { get; set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        public MaterialStorage()
        {
            this.ProductName = "";
            this.MaterialList = new List<Material>();
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="Ini"></param>
        public MaterialStorage(MaterialStorage Ini) 
        {
            this.ProductName = Ini.ProductName;
            this.MaterialList = Ini.MaterialList;
        }
    }
    [Serializable]
    public class Material
    {
        /// <summary>
        /// 材料名称
        /// </summary>
        public string MaterialName { get; set; }
        /// <summary>
        /// 厚度
        /// </summary>
        public decimal Thickness { get; set; }
        /// <summary>
        /// 总片数
        /// </summary>
        public int TotalPieces { get; set; }
        /// <summary>
        /// 起始片数
        /// </summary>
        public int StartPieces { get; set; }
        /// <summary>
        /// 报警片数
        /// </summary>
        public int AlarmPieces { get; set; }
        /// <summary>
        /// 宽度
        /// </summary>
        public decimal Width { get; set; }
        /// <summary>
        /// 高度（长度）
        /// </summary>
        public decimal Height { get; set; }
        /// <summary>
        /// 材料位置 XY坐标
        /// </summary>
        public Vector Point { get; set; }
        /// <summary>
        /// 材料旋转角度 X-Angle,Y-Angle
        /// </summary>
        public Vector Angle { get; set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        public Material()
        {
            this.MaterialName = "";
            this.Thickness = 0;
            this.TotalPieces = 0;
            this.StartPieces = 0;
            this.AlarmPieces = 0;
            this.Width = 0;
            this.Height = 0;
            this.Point = new Vector(0, 0);
            this.Angle = new Vector(0, 0);
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="Ini"></param>
        public Material(Material Ini)
        {
            this.MaterialName = Ini.MaterialName;
            this.Thickness = Ini.Thickness;
            this.TotalPieces = Ini.TotalPieces;
            this.StartPieces = Ini.StartPieces;
            this.AlarmPieces = Ini.AlarmPieces;
            this.Width = Ini.Width;
            this.Height = Ini.Height;
            this.Point = Ini.Point;
            this.Angle = Ini.Angle;
        }


    }
    //项目配置
    [Serializable]
    public class LaserProject
    {
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 材料名称
        /// </summary>
        public string MaterialName { get; set; }
        /// <summary>
        /// 包含的文件选择
        /// </summary>
        public List<FileConfig> FileList = new List<FileConfig>(); 
        /// <summary>
        /// 构造函数
        /// </summary>
        public LaserProject()
        {
            this.ProjectName = "";
            this.ProductName = "";
            this.MaterialName = "";
            this.FileList = new List<FileConfig>();
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="Ini"></param>
        public LaserProject(LaserProject Ini)
        {
            this.ProjectName = Ini.ProjectName;
            this.ProductName = Ini.ProductName;
            this.MaterialName = Ini.MaterialName;
            this.FileList = Ini.FileList;
        }
    }

}

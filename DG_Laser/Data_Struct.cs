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
        //私有属性 
        private Int16 scissors_type;//scissors_type-刀具类型，repeat-重复次数
        private decimal pec, prf;//watt-功率，frequence-频率
        private double jump_speed, mark_speed; //jump_speed- 跳转速度，mark_speed- 打标速度
        private decimal laser_on_delay;//laser_on_delay - 开光延时
        private decimal laser_off_delay;//laser_off_delay - 关光延时
        private decimal jump_delay, mark_delay, polygon_delay;//jump_delay- 跳转延时，mark_delay-打标延时，polygon_delay- 折线延时
        private int cutter_type;
        private decimal cutter_radius;

        //共有属性
        public Int16 Scissors_Type
        {
            get { return scissors_type; }
            set { scissors_type = value; }
        }
        public decimal PEC
        {
            get { return pec; }
            set { pec = value; }
        }
        public decimal PRF
        {
            get { return prf; }
            set { prf = value; }
        }
        public double Jump_Speed
        {
            get { return jump_speed; }
            set { jump_speed = value; }
        }
        public double Mark_Speed
        {
            get { return mark_speed; }
            set { mark_speed = value; }
        }
        public decimal Laser_On_Delay
        {
            get { return laser_on_delay; }
            set { laser_on_delay = value; }
        }
        public decimal Laser_Off_Delay
        {
            get { return laser_off_delay; }
            set { laser_off_delay = value; }
        }
        public decimal Jump_Delay
        {
            get { return jump_delay; }
            set { jump_delay = value; }
        }
        public decimal Mark_Delay
        {
            get { return mark_delay; }
            set { mark_delay = value; }
        }
        public decimal Polygon_Delay
        {
            get { return polygon_delay; }
            set { polygon_delay = value; }
        }
        public int Cutter_Type
        {
            get { return cutter_type; }
            set { cutter_type = value; }
        }
        public decimal Cutter_Radius
        {
            get { return cutter_radius; }
            set { cutter_radius = value; }
        }
        //公开构造函数      
        public Tech_Parameter() { }
        //有参数
        public Tech_Parameter(Int16 scissors_type, decimal pec, decimal prf, double jump_speed, double mark_speed, decimal laser_on_delay, decimal laser_off_delay, decimal jump_delay, decimal mark_delay, decimal polygon_delay, short cutter_type, decimal cutter_radius)
        {
            this.scissors_type = scissors_type;
            this.pec = pec;
            this.prf = prf;
            this.jump_speed = jump_speed;
            this.mark_speed = mark_speed;
            this.laser_on_delay = laser_on_delay;
            this.laser_off_delay = laser_off_delay;
            this.jump_delay = jump_delay;
            this.mark_delay = mark_delay;
            this.polygon_delay = polygon_delay;
            this.cutter_type = cutter_type;
            this.cutter_radius = cutter_radius;
        }
        public Tech_Parameter(Tech_Parameter Ini)
        {
            this.scissors_type = Ini.Scissors_Type;
            this.pec = Ini.PEC;
            this.prf = Ini.PRF;
            this.jump_speed = Ini.Jump_Speed;
            this.mark_speed = Ini.Mark_Speed;
            this.laser_on_delay = Ini.Laser_On_Delay;
            this.laser_off_delay = Ini.Laser_Off_Delay;
            this.jump_delay = Ini.Jump_Delay;
            this.mark_delay = Ini.Mark_Delay;
            this.polygon_delay = Ini.Polygon_Delay;
            this.cutter_type = Ini.Cutter_Type;
            this.cutter_radius = Ini.Cutter_Radius;

        }
        //清空
        public void Empty()
        {
            this.scissors_type = 0;
            this.pec = 0;
            this.prf = 0;
            this.jump_speed = 0;
            this.mark_speed = 0;
            this.laser_on_delay = 0;
            this.laser_off_delay = 0;
            this.jump_delay = 0;
            this.mark_delay = 0;
            this.polygon_delay = 0;
            this.cutter_type = 0;
            this.cutter_radius = 0;
        }
    }
    [Serializable]
    public class Repeat_Parameter
    {
        //私有属性 
        private byte[] repeat = new byte[Program.SystemContainer.SysPara.Work_Repeat_Limit];//repeat-重复次数
        //共有属性
        public byte[] Repeat
        {
            get { return repeat; }
            set { repeat = value; }
        }
        //公开构造函数      
        public Repeat_Parameter() { }
        //有参数
        public Repeat_Parameter(Repeat_Parameter ini)
        {
            this.repeat = (byte[])ini.repeat.Clone();
        }
        //清空
        public void Empty()
        {
            for (int i = 0; i < repeat.Length; i++)
            {
                repeat[i] = 0;
            }
        }
    }
    public class Entity_Data
    {
        public int Path_Type;//路径类型
        public int Color;//元件颜色，用于划分加工分区 
        public short Type;//插补代号：1-直线插补，2-圆弧插补（圆心描述），3-圆弧插补（半径描述，不可描述整圆）
        public short Backup;//备用
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
            Backup = 0;//备用
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
            this.Backup = Ini.Backup;//备用
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
            Backup = 0;//备用
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
    //Gts插补数据
    public class Interpolation_Data
    {
        public int Path_Type;//路径类型 
        public short Type;//插补代号：1-直线插补，2-圆弧插补（圆心描述），3-圆弧插补（半径描述，不可描述整圆）
        public short Lift_flag;//抬刀标志：0-抬刀，等待刀具抬起标志；1-刀具下刀切割标志
        public short Work;//工作区域选择，10-GTS，20-RTC
        public decimal Start_x;//插补起点X坐标 保留参数
        public decimal Start_y;//插补起点Y坐标 保留参数
        public decimal End_x;//插补终点X坐标
        public decimal End_y;//插补终点Y坐标
        public Vector Trail_Center = new Vector(0,0);//封闭图形中心坐标X坐标 
        public decimal Gts_x;//Gts定位置激光加工中心X坐标
        public decimal Gts_y;//Gts定位置激光加工中心Y坐标
        public decimal Rtc_x;//Rtc定位 激光加工起点X坐标
        public decimal Rtc_y;//Rtc定位 激光加工起点Y坐标
        public decimal Center_x;//圆心坐标x
        public decimal Center_y;//圆心坐标y
        public decimal Center_Start_x;//圆心坐标x-起点坐标x
        public decimal Center_Start_y;//圆心坐标y-起点坐标y 
        public decimal Angle;//旋转角度 
        public decimal Circle_radius;//圆弧半径
        public short Circle_dir;//圆弧方向：顺时针-0，逆时针-1
        public Interpolation_Data()
        {
            Path_Type = 0;
            Type = 0;//插补代号：1-直线插补，2-圆弧插补（圆心描述），3-圆弧插补（半径描述，不可描述整圆）
            Lift_flag = 0;//抬刀标志：0-抬刀，等待刀具抬起标志；1-刀具下刀切割标志
            Work = 0;//工作区域选择，10-GTS，20-RTC
            Start_x = 0m;//插补起点X坐标
            Start_y = 0m;//插补起点Y坐标
            End_x = 0m;//插补终点X坐标
            End_y = 0m;//插补终点Y坐标
            Trail_Center = new Vector(0, 0);//封闭图形中心坐标X坐标 
            Gts_x = 0m;//Gts定位置激光加工中心X坐标
            Gts_y = 0m;//Gts定位置激光加工中心Y坐标
            Rtc_x = 0m;//Rtc定位 激光加工起点X坐标
            Rtc_y = 0m;//Rtc定位 激光加工起点Y坐标
            Center_x = 0m;//圆心坐标x
            Center_y = 0m;//圆心坐标y
            Center_Start_x = 0m;//圆心坐标x-起点坐标x
            Center_Start_y = 0m;//圆心坐标y-起点坐标y 
            Angle = 0m;//旋转角度 
            Circle_radius = 0m;//圆弧半径
            Circle_dir = 0;//圆弧方向：顺时针-0，逆时针-1
        }
        public Interpolation_Data(Interpolation_Data Ini)
        {
            this.Path_Type = Ini.Path_Type;//刀具类型
            this.Type = Ini.Type;//插补代号：1-直线插补，2-圆弧插补（圆心描述），3-圆弧插补（半径描述，不可描述整圆）
            this.Lift_flag = Ini.Lift_flag;//抬刀标志：0-抬刀，等待刀具抬起标志；1-刀具下刀切割标志
            this.Work = Ini.Work;//工作区域选择，10-GTS，20-RTC
            this.Start_x = Ini.Start_x;//插补起点X坐标 保留参数
            this.Start_y = Ini.Start_y;//插补起点Y坐标 保留参数
            this.End_x = Ini.End_x;//插补终点X坐标
            this.End_y = Ini.End_y;//插补终点Y坐标
            this.Trail_Center = new Vector(Ini.Trail_Center);//封闭图形中心坐标X坐标 
            this.Gts_x = Ini.Gts_x;//Gts定位置激光加工中心X坐标
            this.Gts_y = Ini.Gts_y;//Gts定位置激光加工中心Y坐标
            this.Rtc_x = Ini.Rtc_x;//Rtc定位 激光加工起点X坐标
            this.Rtc_y = Ini.Rtc_y;//Rtc定位 激光加工起点Y坐标
            this.Center_x = Ini.Center_x;//圆心坐标x
            this.Center_y = Ini.Center_y;//圆心坐标y
            this.Center_Start_x = Ini.Center_Start_x;//圆心坐标x-起点坐标x
            this.Center_Start_y = Ini.Center_Start_y;//圆心坐标y-起点坐标y 
            this.Angle = Ini.Angle;//旋转角度 
            this.Circle_radius = Ini.Circle_radius;//圆弧半径
            this.Circle_dir = Ini.Circle_dir;//圆弧方向：顺时针-0，逆时针-1
        }

        public void Empty()
        {
            Path_Type = 0;
            Type = 0;//插补代号：1-直线插补，2-圆弧插补（圆心描述），3-圆弧插补（半径描述，不可描述整圆）
            Lift_flag = 0;//抬刀标志：0-抬刀，等待刀具抬起标志；1-刀具下刀切割标志
            Work = 0;//工作区域选择，10-GTS，20-RTC
            Start_x = 0m;//插补起点X坐标
            Start_y = 0m;//插补起点Y坐标
            End_x = 0m;//插补终点X坐标
            End_y = 0m;//插补终点Y坐标
            Trail_Center = new Vector(0,0);//封闭图形中心坐标X坐标 
            Gts_x = 0m;//Gts定位置激光加工中心X坐标
            Gts_y = 0m;//Gts定位置激光加工中心Y坐标
            Rtc_x = 0m;//Rtc定位 激光加工起点X坐标
            Rtc_y = 0m;//Rtc定位 激光加工起点Y坐标
            Center_x = 0m;//圆心坐标x
            Center_y = 0m;//圆心坐标y
            Center_Start_x = 0m;//圆心坐标x-起点坐标x
            Center_Start_y = 0m;//圆心坐标y-起点坐标y 
            Angle = 0m;//旋转角度 
            Circle_radius = 0m;//圆弧半径
            Circle_dir = 0;//圆弧方向：顺时针-0，逆时针-1
        }
    }
    //Rtc振镜单封闭图形数据
    public class Rtc_Data
    {
        public short Type;//插补代号：1-直线插补，2-圆弧插补（圆心描述），3-圆弧插补（半径描述，不可描述整圆）
        public short Lift_flag;//抬刀标志：0-抬刀，等待刀具抬起标志；1-刀具下刀切割标志
        public short Repeat;//重复加工次数
        public decimal Start_x;//插补起点X坐标 保留参数
        public decimal Start_y;//插补起点Y坐标 保留参数
        public decimal End_x;//终点X坐标
        public decimal End_y;//终点Y坐标
        public decimal Center_x;//圆心坐标x
        public decimal Center_y;//圆心坐标y
        public decimal Angle;//旋转角度
        public void Empty()
        {
            Type = 0;//插补代号：1-直线插补，2-圆弧插补（圆心描述），3-圆弧插补（半径描述，不可描述整圆）
            Lift_flag = 0;//抬刀标志：0-抬刀，等待刀具抬起标志；1-刀具下刀切割标志
            Repeat = 0;//重复加工次数
            Start_x = 0m;//插补起点X坐标
            Start_y = 0m;//插补起点Y坐标
            End_x = 0m;//插补终点X坐标
            End_y = 0m;//插补终点Y坐标
            Center_x = 0m;//圆心坐标x
            Center_y = 0m;//圆心坐标y
            Angle = 0m;//旋转角度
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
    //仿射变换
    [Serializable]
    public class Affinity_Rate
    {
        private decimal delta_x;// 
        private decimal delta_y;//
        private decimal angle;// 

        public decimal Delta_X { get => delta_x; set => delta_x = value; }
        public decimal Delta_Y { get => delta_y; set => delta_y = value; }
        public decimal Angle { get => angle; set => angle = value; }

        public Affinity_Rate(decimal delta_x, decimal delta_y, decimal angle)
        {
            this.delta_x = delta_x;
            this.delta_y = delta_y;
            this.angle = angle;
        }
        public void Empty()
        {
            this.delta_x = 0;
            this.delta_y = 0;
            this.angle = 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DG_Laser
{
    public delegate void Change_Event();
    public class ValueChangeFilter//滤波
    {
        public int Counting = 0;//计数值
        public event Change_Event ChangeEvent;//值变化事件
        private int variable;
        /// <summary>
        /// 构造函数
        /// </summary>
        public ValueChangeFilter()
        {
            Counting = 0;
        }
        /// <summary>
        /// 清除计数值
        /// </summary>
        public void Clear()
        {
            Counting = 0;
        }
        /// <summary>
        /// 变更值
        /// </summary>
        public int Variable
        {
            get
            {
                return variable;
            }
            set
            {
                //值发生变化，才赋值
                if (variable == value)
                    return;
                else
                {
                    Counting++;
                    variable = value;
                }
            }
        }
    }
    /// <summary>
    /// 指定值变化事件：0,1,2,3
    /// </summary>
    public class SpecifyValueEvent 
    {
        public event Change_Event Value_0;//设置值 = 0
        public event Change_Event Value_1;//设置值 = 1
        public event Change_Event Value_2;//设置值 = 2
        public event Change_Event Value_3;//设置值 = 3
        private int variable;
        public int Variable
        {
            get
            {
                return variable;
            }
            set
            {
                //值发生变化，才赋值
                if (variable == value) return;
                //赋值事件
                switch (value)
                {
                    case 0:
                        Value_0?.Invoke();
                        break;
                    case 1:
                        Value_1?.Invoke();
                        break;
                    case 2:
                        Value_2?.Invoke();
                        break;
                    case 3:
                        Value_3?.Invoke();
                        break;
                    default:
                        break;
                }
                variable = value;
            }
        }
    }
    /// <summary>
    /// 达到指定值触发事件
    /// </summary>
    public class SpecifyValueAlarm
    {
        public int AlarmNum = 0;
        public event Change_Event AlarmEvent;//报警委托
        private int variable;
        /// <summary>
        /// 构造函数
        /// </summary>
        public SpecifyValueAlarm(int alarmNum)
        {
            this.AlarmNum = alarmNum;
        }
        /// <summary>
        /// 赋值事件
        /// </summary>
        public int Variable
        {
            get
            {
                return variable;
            }
            set
            {
                //值发生变化，才赋值
                if (variable == value) return;
                //赋值事件
                if (value >= AlarmNum) AlarmEvent?.Invoke();//触发事件
                variable = value;
            }
        }
    }
}

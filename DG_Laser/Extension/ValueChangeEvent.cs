using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DG_Laser
{
    public delegate void Change_Event();
    public class ValueChangeEvent
    {        
        public event Change_Event Greater_Than_Change;//设置值大于当前值触发事件
        public event Change_Event Less_Than_Change;//设置值小于当前值触发事件 
        public event Change_Event Equal_Change;//设置值小于当前值触发事件   
        private int variable;
        public int Variable
        {
            get
            {
                return variable;
            }
            set
            {
                if (variable > value)
                {
                    Greater_Than_Change?.Invoke();
                }
                else if (variable < value)
                {
                    Less_Than_Change?.Invoke();
                }
                else
                {
                    Equal_Change?.Invoke();
                }
                variable = value;
            }
        }
    }
}

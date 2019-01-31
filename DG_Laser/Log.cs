using HslCommunication.LogNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DG_Laser
{
    class Log
    {
        public ILogNet LogRecord;//日志记录 
        /// <summary>
        /// 默认
        /// </summary>
        public Log()
        {
            //配置Log参数
            LogRecord = new LogNetDateTime("./Log", GenerateMode.ByEveryHour);
        }
        /// <summary>
        /// 配置参数
        /// </summary>
        public Log(GenerateMode mode)
        {
            //配置Log参数
            LogRecord = new LogNetDateTime("./Log", mode);
        }
        /// <summary>
        /// 记录GTS指令错误
        /// </summary>
        /// <param name="context"></param>
        /// <param name="code"></param>
        public void WriteError(String context, short code) 
        {
            string Log_Component = context + "--------" + code;
            // 如果指令执行返回值为非0，说明指令执行错误，向屏幕输出错误结果
            #if !DEBUG
                if (code != 0)
                {
                    LogRecord.WriteError(Log_Component);
                }
            #endif
        }
        /// <summary>
        /// 记录RTC指令错误
        /// </summary>
        /// <param name="command"></param>
        /// <param name="error"></param>
        public void WriteError(string command, uint error)
        { 
            //执行的判断直接由 函数执行完返回值，直接判断，该Log直接生成日志项目
            string Log_Component = command + "--------" + Convert.ToString(error);
            // 如果指令执行返回值为非0，说明指令执行错误，向屏幕输出错误结果
            LogRecord.WriteError(Log_Component);
        }
        /// <summary>
        /// 用于程序的执行Log记录
        /// </summary>
        /// <param name="command"></param>
        public void WriteError(string command)
        {
            //生成错误日志
            LogRecord.WriteError(command);
        }
        /// <summary>
        /// 日志信息
        /// </summary>
        /// <param name="command"></param>
        public void Info(string command)
        {
            //生成日志
            LogRecord.WriteInfo(command);
        }
    }
}

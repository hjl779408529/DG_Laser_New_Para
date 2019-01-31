using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DG_Laser
{
    public delegate void LogErrshort(String context, short code);//用于GTS命令的错误日志记录
    public delegate void LogErruint(String context, uint code);//用于RTC命令的错误日志记录
    public delegate void LogErrstring(String context);//单纯string日志记录
    public delegate void LogInfo(String context);//信息日志记录
    public delegate void PicUpdateEvent();//相机Picture刷新
}

using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DG_Laser
{
    public delegate void Receive_Delegate(byte[] Data);
    class RS232
    {
        public event LogErrstring LogErr;
        //串口端口
        public SerialPort ComDevice = new SerialPort();
        //设备串口名List
        public List<string> PortName = new List<string>();
        //波特率
        public List<Int32> BaudRate = new List<Int32>() {300,600,1200,2400,4800,9600,19200,38400,43000,56000,57600,115200};
        //校验位
        public List<string> Parity = new List<string>() { "None", "Odd", "Even", "Mark", "Space" };
        //数据位
        public List<int> DataBits = new List<int>() {8, 7, 6};
        //停止位
        public List<int> StopBits = new List<int>() {1, 2, 3};
        public bool Rec_Flag = false;//数据接收完成标志
        public bool Closing = false;//正在关闭标志
        public bool Open = false;//串口打开状态
        // Crc Computation Class
        private CRCTool compCRC = new CRCTool();
        //委托处理
        //接收数据数组
        public event Receive_Delegate Receive_Event;
        //构造函数
        public RS232()
        {
            //更新列表
            Refresh_Com_List();
            //绑定数据接收事件
            ComDevice.DataReceived += new SerialDataReceivedEventHandler(Com_DataReceived);//绑定事件
            //清除标志
            Rec_Flag = false;//数据接收完成标志
            Closing = false;//正在关闭标志
            Open = false;//串口打开状态
        }
        //更新列表
        public void Refresh_Com_List()
        {
            //获取设备串口名
            PortName.Clear();
            PortName = SerialPort.GetPortNames().ToList<string>();
        }
        //串口打开
        public bool Open_Com(Int32 No)
        {
            if (PortName.Count < 0)
            {
                MessageBox.Show("没有发现串口,请检查线路！");
                Open = false;//串口打开状态 OFF
                return false;
            }
            if (ComDevice.IsOpen == false)
            {
                ComDevice.PortName = PortName[No];
                ComDevice.BaudRate = 115200;//波特率
                ComDevice.Parity = (Parity)Convert.ToInt32("0");//校验位 
                ComDevice.DataBits = 8;//数据位 8、7、6
                ComDevice.StopBits = (StopBits)Convert.ToInt32(1);                
                //返回打开结果
                try
                {
                    ComDevice.Open();//打开串口
                    if (ComDevice.IsOpen)
                    {
                        Open = true;//串口打开状态 ON
                        return true;
                    }
                    else
                    {
                        Open = false;//串口打开状态 OFF
                        return false;
                    }
                }
                catch (Exception e)
                {
                    Open = false;//串口打开状态 OFF
                    MessageBox.Show(e.Message);
                    return false;
                }
            }
            else
            {
                Closing = true;//正在关闭 
                //返回打开结果
                try
                {
                    ComDevice.Close();//关闭串口
                    Closing = false;//关闭OK
                    if (ComDevice.IsOpen)
                    {
                        Open = true;//串口打开状态 ON
                        return true;
                    }
                    else
                    {
                        Open = false;//串口打开状态 OFF
                        return false;
                    }
                }
                catch (Exception e)
                {
                    Open = false;//串口打开状态 OFF
                    MessageBox.Show(e.Message);
                    return false;
                }                
            }
        }
        //串口打开
        public bool Open_Com(Int32 No, short baudrate_No)
        {
            if (PortName.Count < 0)
            {
                MessageBox.Show("没有发现串口,请检查线路！");
                return false;
            }

            if (ComDevice.IsOpen == false)
            {
                ComDevice.PortName = PortName[No];
                ComDevice.BaudRate = BaudRate[baudrate_No];//波特率
                ComDevice.Parity = (Parity)Convert.ToInt32("0");//校验位 
                ComDevice.DataBits = 8;//数据位 8、7、6
                ComDevice.StopBits = (StopBits)Convert.ToInt32(1);                
                //返回打开结果
                try
                {
                    ComDevice.Open();
                    if (ComDevice.IsOpen)
                    {
                        Open = true;//串口打开状态 ON
                        return true;
                    }
                    else
                    {
                        Open = false;//串口打开状态 OFF
                        return false;
                    }
                }
                catch (Exception e)
                {
                    Open = false;//串口打开状态 OFF
                    MessageBox.Show(e.Message);
                    return false;
                }
            }
            else
            {
                Closing = true;//正在关闭                
                //返回打开结果
                try
                {
                    ComDevice.Close();//关闭串口
                    Closing = false;//关闭OK
                    if (ComDevice.IsOpen)
                    {
                        Open = true;//串口打开状态 ON
                        return true;
                    }
                    else
                    {
                        Open = false;//串口打开状态 OFF
                        return false;
                    }
                }
                catch (Exception e)
                {
                    Open = false;//串口打开状态 OFF
                    MessageBox.Show(e.Message);
                    return false;
                }
            }

        }
        //数据发送
        public bool Send_Data(string sendData)
        {
            //清除接收标志
            Rec_Flag = false;
            //发送的字节数组
            byte[] data = null;
            //将发送的字符串转化为byte,并追加终止符号
            data = StrCRC(sendData).Concat(new byte[] { 0x0D }).ToArray();
            //清空数据
            //ComDevice.DiscardInBuffer();
            //ComDevice.DiscardOutBuffer();
            //数据发送
            if (ComDevice.IsOpen)
            {
                ComDevice.Write(data, 0, data.Length);//发送数据
            }
            else
            {
                MessageBox.Show("串口未打开", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }
        //Hex字符串转换16进制字节数组 只支持为16进制数字的字符串
        public byte[] StrToHexByte(string hexString) 
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0) hexString = " " + hexString;
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length ; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2).Replace(" ", ""), 16);
            return returnBytes;
        }       
        //CRC数据校验值添加
        public byte[] StrCRC(string inStr) 
        {
            byte[] data = null;
            //Check_Sum
            ushort usCrc16 = (ushort)compCRC.Check_Sum(StrToHexByte(inStr));
            /*
            回车(Carriage Return)和换行(Line Feed)区别
            CR用符号\r表示, 十进制ASCII代码是13, 十六进制代码为0x0D
            LF使用\n符号表示, ASCII代码是10, 十六制为0x0A
            Dos / windows: 回车 + 换行CR / LF表示下一行,
            UNIX / linux: 换行符LF表示下一行，
            MAC OS: 回车符CR表示下一行.
            */
            //Prompt.Log.Info(inStr + Crc_Append_Str(usCrc16));
            //将字符串转换为Byte
            data = Encoding.ASCII.GetBytes((inStr + Crc_Append_Str(usCrc16)).Trim());
            return data;
        }
        //追加校准值
        public string Crc_Append_Str(UInt32 Num)
        {
            string Result = null;
            Result = string.Format("{0:X4}", Num);
            return Result;
        }
        //数据接收
        private void Com_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (Closing) return;//正在关闭串口，结束接收
            int len = ComDevice.BytesToRead;//接收数据长度
            if (len <= 0) return;//数据长度小于等于0，退出接收
            byte[] ReDatas = new byte[len];//初始化接收数组
            ComDevice.Read(ReDatas, 0, len);//读取数据
            //接收的Byte数据 返回
            byte[] ReceiveData = new byte[ReDatas.Length];
            ReceiveData = (byte[])ReDatas.Clone();
            //置位接收标志
            Rec_Flag = true;
            //执行数据处理
            Receive_Event?.Invoke(ReceiveData);
            //接收数据处理 将ReDatas 转化为 String
            //该方式回丢弃数据
            //ASCII编码只能包含0-127的数据，高出的数据将丢弃
            //ReceiveData = new ASCIIEncoding().GetString(ReDatas);  
            //byte[] Rec_Data = null;
            //Rec_Data = Encoding.ASCII.GetBytes(ReceiveData.Trim());
        }
    }
    /// <summary>
    /// 字节缓冲器
    /// </summary>
    public class ByteQueue

    {
        public byte Header;//头信息
        public byte Ender;//结束信息
        private List<byte> m_buffer = new List<byte>();
        public bool Find()
        {
            if (m_buffer.Count == 0)
                return false;
            int HeadIndex = m_buffer.FindIndex(o => o == Header);//获取指定字节的 索引
            if (HeadIndex == -1)//未找到
            {
                m_buffer.Clear();
                return false; //没找到AA
            }
            else if (HeadIndex != 0) //不为开头移掉之前的字节
            {
                if (HeadIndex > 1)
                    m_buffer.RemoveRange(0, HeadIndex);
            }
            int length = GetLength();//获取长度
            if (m_buffer.Count < length)
            {
                return false;
            }
            int TailIndex = m_buffer.FindIndex(o => o == Ender); //查找终止字节的 索引位置
            if (TailIndex == -1)
            {
                //这一步为防止连发一个AA开头的包后，没发55，而又发了一个AA
                int head = m_buffer.FindLastIndex(o => o == Header);
                if (head > -1)
                {
                    m_buffer.RemoveRange(0, head);
                }
                return false;
            }
            else if (TailIndex + 1 != length) //计算包尾是否与包长度相等
            {
                m_buffer.RemoveRange(0, TailIndex);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 命令类型
        /// </summary>
        /// <returns></returns>
        public byte Cmd()
        {
            if (m_buffer.Count >= 2)
            {
                return m_buffer[1];
            }
            return 0;
        }

        /// <summary>
        /// 序号
        /// </summary>
        /// <returns></returns>
        public byte Number()
        {
            if (m_buffer.Count >= 3)
            {
                return m_buffer[2];
            }
            return 0;
        }

        /// <summary>
        /// 包长度
        /// </summary>
        /// <returns></returns>
        public int GetLength()
        {
            int len = 5;//AA 命令类型 序号 校验和 55
            if (m_buffer.Count >= 3)
            {
                switch (m_buffer[2]) //第三字节为序号
                {
                    case 0x00: //序号
                        return len + 16;
                    case 0x01: //序号
                        return len + 10;
                    case 0x02: //序号
                        return len + 12;
                }
            }
            return 0;
        }

        /// <summary>
        /// 提取数据
        /// </summary>
        public void Dequeue(byte[] buffer, int offset, int size)
        {
            m_buffer.CopyTo(0, buffer, offset, size);
            m_buffer.RemoveRange(0, size);
        }

        /// <summary>
        /// 队列数据
        /// </summary>
        /// <param name="buffer"></param>
        public void Enqueue(byte[] buffer)
        {
            m_buffer.AddRange(buffer);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DG_Laser
{
    class Laser_CC_Data
    {
        public string RW;//读写标志：Read和Write (01-read；00-write),Response for Read和Write (03-for read；02-for write)；
        public string DataSize;//数据大小 ASCII:0-255；度取命令时始终为0
        public string Address;//地址
        public string Com_Control;//控制命令
        public string Data;//数据
        public string Crc;//CRC校验值
        public string Sum;//数据整合
        public Int32 Num;//接收数据十进制
        public Int64 StatusNum;//接收数据十进制
        public byte StatusD1;//接收数据十进制 
        public Laser_CC_Data()
        {
            RW = "";//读写标志：Read和Write (01-read；00-write),Response for Read和Write (03-for read；02-for write)；
            DataSize = "";//数据大小 ASCII:0-255；
            Address = "";//地址
            Com_Control = "";//控制命令
            Data = "";//数据
            Crc = "";//CRC校验值
            Sum = "";//数据整合
            Num = 0;
            StatusNum = 0;
            StatusD1 = 0x00;
        }
    }
    
    class Laser_Operation
    {
        // Crc Computation Class
        private CRCTool compCRC = new CRCTool();
        public Laser_CC_Data Resolve_Rec = new Laser_CC_Data();//接收数据解析  
        private Laser_CC_Data CC_Data = new Laser_CC_Data();//发送数据的内容
        //接收数据数组
        public event LogErrstring LogErr;
        public event LogInfo LogInfo;
        private bool WR_OK = false;//读写标志完成标志
        //构造函数
        public Laser_Operation()
        {
            
        }
        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="Address"></param>
        /// <param name="CC"></param>
        public void Read(string Address,string CC)//读取数据没有D1-Dn
        {
            CC_Data = new Laser_CC_Data();
            CC_Data.RW = "01";//读取标志
            CC_Data.DataSize = "00";//读取数据，DataSize大小强制为0
            CC_Data.Address = Address;//地址
            CC_Data.Com_Control = CC;//控制指令
            //整合指令
            CC_Data.Sum = CC_Data.RW + CC_Data.DataSize + CC_Data.Address + CC_Data.Com_Control + CC_Data.Data;
            //发送数据
            SendToLaserControl(CC_Data.Sum);
            WR_OK = false;
            int Count = 0;
            do
            {
                if (!Program.SystemContainer.Laser_Control_Com.Open) return;
                Thread.Sleep(200);//延时200ms，等待数据读取完成
                Count++;
                if (Count > 5)
                {
                    return;
                }
            } while (!WR_OK);
        }
        /// <summary>
        /// 写入数据
        /// </summary>
        /// <param name="Address"></param>
        /// <param name="CC"></param>
        /// <param name="Data"></param>
        public void Write(string Address, string CC,string Data)//写入数据，这就包含写入数据的参数：D1-Dn 
        {
            CC_Data = new Laser_CC_Data();
            CC_Data.RW = "00";//写入标志
            CC_Data.DataSize = Cal_Data_Size(Convert.ToUInt32(Data.Length/2));//写入数据，DataSize
            CC_Data.Address = Address;//地址
            CC_Data.Com_Control = CC;//控制指令
            CC_Data.Data = Data;//数据
            //整合指令
            CC_Data.Sum = CC_Data.RW + CC_Data.DataSize + CC_Data.Address + CC_Data.Com_Control + CC_Data.Data;
            //发送数据
            SendToLaserControl(CC_Data.Sum);
            //等待数据完成解析
            WR_OK = false;
            int Count = 0;
            do
            {
                if (!Program.SystemContainer.Laser_Control_Com.Open) return;
                Thread.Sleep(200);//延时200ms，等待数据读取完成
                Count++;
                if (Count > 5)
                {
                    return;
                }
            } while (!WR_OK);
        }
        /// <summary>
        /// 向激光控制器发送数据
        /// </summary>
        private void SendToLaserControl(string OrderText)
        {
            if (!Program.SystemContainer.Laser_Control_Com.Open) return;
            //发送数据
            Program.SystemContainer.Laser_Control_Com.Send_Data(OrderText);
        }
        /// <summary>
        /// 计算发送数据长度
        /// </summary>
        /// <param name="Num"></param>
        /// <returns></returns>
        public string Cal_Data_Size(UInt32 Num) 
        {
            string tempStr = null;
            if (Num <= 255)
            {
                tempStr = string.Format("{0:X2}", Num);
            }
            else
            {
                MessageBox.Show("发送数据长度异常！！！");
                return tempStr;
            }
            return tempStr;
        }
        /// <summary>
        /// 将数值10进制转16进制，再将16进制转换为字符串返回 中心是byte转化为ASCII  5000 - 1388
        /// </summary>
        /// <param name="Num"></param>
        /// <returns></returns>
        public string Uint_To_Str(UInt32 Num) 
        {
            string tempStr = null;
            tempStr = string.Format("{0:X4}", Num);
            if (tempStr.Length == 3)
            {
                tempStr = "0" + tempStr;
            }
            else if (tempStr.Length == 2)
            {
                tempStr = "00" + tempStr;
            }
            else if (tempStr.Length == 1)
            {
                tempStr = "000" + tempStr;
            }
            else if (tempStr.Length == 0)
            {
                tempStr = "0000";
            }
            return tempStr;
        }
        /// <summary>
        /// 将数值10进制转16进制，再将16进制转换为字符串返回 中心是byte转化为ASCII  5000 - 1388
        /// </summary>
        /// <param name="Num"></param>
        /// <returns></returns>
        public string PRF_To_Str(UInt32 Num) 
        {
            string tempStr = null;
            tempStr = string.Format("{0:X4}", Num);
            //MessageBox.Show(tempStr);
            if (tempStr.Length==8)
            {
                tempStr = tempStr.Substring(1);
                tempStr = tempStr.Substring(1);
            }
            else if (tempStr.Length == 7)
            {
                tempStr = tempStr.Substring(1);
            }
            else if (tempStr.Length == 5)
            {
                tempStr = "0" + tempStr;
            }
            else if (tempStr.Length == 4)
            {
                tempStr = "00" + tempStr;
            }
            else if (tempStr.Length == 3)
            {
                tempStr = "000" + tempStr;
            }
            //补位
            if ((tempStr.Length % 2) != 0) tempStr = "0" + tempStr;
            return tempStr;
        }
        /// <summary>
        /// 解析接收的数据
        /// </summary>
        /// <param name="Rec_Data"></param>
        public void Resolve_Com_Data(byte[] Rec_Data)
        {
            //清空解析数据
            Resolve_Rec = new Laser_CC_Data();
            //数据拆分
            byte Header = 0x00;//头信息
            byte Ender = 0x0d;//终止符 \r
            //判断结尾数据是否是Ender
            if (Rec_Data[Rec_Data.Length - 1] != Ender)
            {
                //再次发送数据
                SendToLaserControl(CC_Data.Sum);
                return;
            }
            string Temp = Encoding.Default.GetString(Rec_Data);//先转换为字符串
            List<byte> RecListData =new List<byte>(StrToHexByte(Temp).ToList());
            //判断写入还是读取
            if (CC_Data.RW == "00")//写入
            {
                WR_OK = true;
                return;
            }
            else if (CC_Data.RW == "01")//读取
            {
                Header = 0x03;
            }
            //检查接收到的数据是否完整
            if (RecListData.Count < 6)
            {
                //再次发送数据
                SendToLaserControl(CC_Data.Sum);
                return;
            }
            
            //获取索引值
            int HeadIndex = RecListData.FindIndex(o => o == Header);//获取头字节的 索引
            if (HeadIndex >-1)
            {
                RecListData.RemoveRange(0, HeadIndex);
            }
            else
            {
                //再次发送数据
                SendToLaserControl(CC_Data.Sum);
                return;
            }
            //判断数据长度是否合适
            if (RecListData.Count < (RecListData[1] + 4 + 2))//头部4 + 数据长度 + Crc校验2
            {
                //再次发送数据
                SendToLaserControl(CC_Data.Sum);
                return;
            }
            //数据处理
            Resolve_Rec.RW = string.Format("{0:X2}", RecListData[0]);
            Resolve_Rec.DataSize = string.Format("{0:X2}", RecListData[1]);
            Resolve_Rec.Address = string.Format("{0:X2}", RecListData[2]);
            Resolve_Rec.Com_Control = string.Format("{0:X2}", RecListData[3]);
            //判断Adress地址
            if (Resolve_Rec.Address != CC_Data.Address)
            {
                //再次发送数据
                SendToLaserControl(CC_Data.Sum);
                return;
            }
            //检查格式
            byte[] DataByte;
            switch (RecListData[1])
            {
                case 0:
                    DataByte = new byte[2];
                    DataByte[0] = 0;
                    DataByte[1] = 0;
                    Resolve_Rec.Data = "";//获取Data数据
                    break;
                case 1:
                    DataByte = new byte[2];
                    DataByte[0] = RecListData[4];
                    DataByte[1] = 0;
                    Resolve_Rec.Data = string.Format("{0:X2}", BitConverter.ToInt16(DataByte, 0));//获取Data数据
                    break;
                case 2:
                    DataByte = new byte[2];
                    DataByte[0] = RecListData[5];
                    DataByte[1] = RecListData[4];
                    Resolve_Rec.Data = string.Format("{0:X4}", BitConverter.ToInt16(DataByte, 0));//获取Data数据
                    break;
                case 3:
                    DataByte = new byte[4];
                    DataByte[0] = RecListData[6];
                    DataByte[1] = RecListData[5];
                    DataByte[2] = RecListData[4];
                    DataByte[3] = 0x00;
                    Resolve_Rec.Data = string.Format("{0:X6}", BitConverter.ToInt32(DataByte, 0));//获取Data数据
                    break;
                case 4:
                    DataByte = new byte[4];
                    DataByte[0] = RecListData[7];
                    DataByte[1] = RecListData[6];
                    DataByte[2] = RecListData[5];
                    DataByte[3] = RecListData[4];
                    Resolve_Rec.Data = string.Format("{0:X8}", BitConverter.ToInt32(DataByte, 0));//获取Data数据
                    break;
                case 5:
                    DataByte = new byte[8];
                    DataByte[0] = RecListData[8];
                    DataByte[1] = RecListData[7];
                    DataByte[2] = RecListData[6];
                    DataByte[3] = RecListData[5];
                    DataByte[4] = RecListData[4];
                    DataByte[5] = 0;
                    DataByte[6] = 0;
                    DataByte[7] = 0;
                    Resolve_Rec.Data = string.Format("{0:X10}", BitConverter.ToInt64(DataByte, 0));//获取Data数据
                    break;
                default:
                    DataByte = new byte[2];
                    DataByte[0] = 0;
                    DataByte[1] = 0;
                    Resolve_Rec.Data = "";//获取Data数据
                    break;
            }
            Resolve_Rec.Crc = string.Format("{0:X4}", BitConverter.ToInt32(new byte[] { RecListData[RecListData[1] + 4 + 1],RecListData[RecListData[1] + 4],0,0}, 0));//获取CRC值
            Resolve_Rec.Sum = Resolve_Rec.RW + Resolve_Rec.DataSize + Resolve_Rec.Address + Resolve_Rec.Com_Control + Resolve_Rec.Data;//该序列数据
            //校验数据完整性
            if (Crc_Append_Str((ushort)compCRC.Check_Sum(StrToHexByte(Resolve_Rec.Sum))) == Resolve_Rec.Crc)
            {
                if (RecListData[1] <= 4)
                    Resolve_Rec.Num = HexStrToInt32(Resolve_Rec.Data);
                else
                    //Resolve_Rec.StatusNum = HexStrToInt64(Resolve_Rec.Data);
                    Resolve_Rec.StatusD1 = RecListData[4];
                WR_OK = true;
                LogInfo?.Invoke("激光控制接收数据 校验OK！！！");
            }
            else
            {
                //再次发送数据
                SendToLaserControl(CC_Data.Sum);
            }
        }
        /// <summary>
        /// 十六进制字符串转换为 Int数值
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        public Int32 HexStrToInt32(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString == null) || (hexString == "")) return 0;
            return Int32.Parse(hexString, System.Globalization.NumberStyles.HexNumber);
        }
        /// <summary>
        /// 十六进制字符串转换为 Int数值
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        public Int64 HexStrToInt64(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString == null) || (hexString == "")) return 0;
            return Int64.Parse(hexString, System.Globalization.NumberStyles.HexNumber);
        }
        /// <summary>
        /// 校准值转换为十六进制字符串
        /// </summary>
        /// <param name="Num"></param>
        /// <returns></returns>
        public string Crc_Append_Str(UInt32 Num)
        {
            string Result = null;
            Result = string.Format("{0:X4}", Num);
            return Result;
        }
        /// <summary>
        /// Hex字符串转换16进制字节数组 只支持为16进制数字的字符串
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        public byte[] StrToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            hexString = hexString.Replace("\r", "");
            if ((hexString.Length % 2) != 0) hexString = " " + hexString;
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2).Replace(" ", ""), 16);
            return returnBytes;
        }
        /// <summary>
        /// 激光功率百分比修改写入
        /// </summary>
        /// <param name="pec"></param>
        public void Change_Pec(decimal pec)
        {
            if (Math.Abs(pec) <= 100)
            {
                Write("00", "55", Uint_To_Str((UInt16)(pec * 10)));
            }
            else
            {
                MessageBox.Show("激光功率设置值超出允许范围！！！");
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HPSocketCS;

namespace DG_Laser
{
    class HPSocket_Communication
    {       
        private HPSocketCS.TcpClient client = new HPSocketCS.TcpClient();
        public Vector Receive_Cordinate = new Vector();//接收的数据 相机转换为坐标
        bool isSend = false;//发送标志 
        public bool Rec_Ok;//接收完成标志
        public bool ConnectOk = false;//连接标志 清除
        public event LogErrstring LogErr;
        public event LogInfo LogInfo;
        /// <summary>
        /// 构造函数
        /// </summary>
        public HPSocket_Communication()
        {
            ConnectOk = false;//连接标志 清除
            try
            {
                // 设置client事件
                client.OnPrepareConnect += new TcpClientEvent.OnPrepareConnectEventHandler(OnPrepareConnect);//准备连接事件绑定
                client.OnConnect += new TcpClientEvent.OnConnectEventHandler(OnConnect);//连接事件绑定
                client.OnSend += new TcpClientEvent.OnSendEventHandler(OnSend);//发送事件绑定
                client.OnReceive += new TcpClientEvent.OnReceiveEventHandler(OnReceive);//接收事件绑定
                client.OnClose += new TcpClientEvent.OnCloseEventHandler(OnClose);//关闭事件绑定
                LogInfo?.Invoke(string.Format("HP-Socket Version: {0}", client.Version));
            }
            catch (Exception ex)
            {
                LogErr?.Invoke(ex.Message);
            }
        }
        /// <summary>
        /// 连接指定服务器Ip和Port
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        public void TCP_Start(string ip,ushort port)
        {
            try
            {                
                if (client.Connect(ip, port))
                {
                    LogInfo?.Invoke("服务器 连接触发！！！");
                }
                else
                {
                    LogErr?.Invoke("服务器 连接失败！！！");
                }
            }
            catch (Exception ex)
            {
                LogErr?.Invoke(ex.Message);
            }            
        }
        /// <summary>
        /// Stop_Connect
        /// </summary>
        public void Stop_Connect()
        {
            if (client.Stop())
            {
                LogInfo?.Invoke("服务器 断开成功！！！");
            }
            else
            {
                LogErr?.Invoke("服务器 断开异常！！！");
            }
        }
        /// <summary>
        /// Send_Data
        /// </summary>
        /// <param name="order"></param>
        public void Send_Data(int order)
        {
            //检测是否连接
            if (!ConnectOk)
            {
                LogErr?.Invoke("相机未连接，Send命令取消！！！");
                return;
            }
            //发送数据
            try
            {
                Rec_Ok = false;//清除接收完成标志
                Receive_Cordinate = new Vector(0, 0);//清除接收反馈坐标值
                string send = order.ToString();
                if (send.Length == 0)
                {
                    return;
                }
                byte[] bytes = Encoding.Default.GetBytes(send);
                IntPtr connId = client.ConnectionId;
                // 发送
                if (client.Send(bytes, bytes.Length))
                {
                    isSend = true;
                }
                else
                {
                    isSend = false;
                    LogErr?.Invoke("发送失败！！！");
                }
            }
            catch (Exception ex)
            {
                LogErr?.Invoke(ex.Message);
            }
        }
        /// <summary>
        /// 准备连接事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="socket"></param>
        /// <returns></returns>
        HandleResult OnPrepareConnect(TcpClient sender, IntPtr socket)
        {
            return HandleResult.Ok;
        }
        /// <summary>
        /// 连接事件
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        HandleResult OnConnect(TcpClient sender)
        {
            // 已连接 到达一次
            ConnectOk = true;
            LogInfo?.Invoke(string.Format("服务器连接成功！！！----> [{0},OnConnect]", sender.ConnectionId));
            return HandleResult.Ok;
        }
        /// <summary>
        /// 发送事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="bytes"></param>
        /// <returns></returns>
        HandleResult OnSend(TcpClient sender, byte[] bytes)
        {
            // 客户端发数据了
            //Log.Info(string.Format(" > [{0},OnSend] -> ({1} bytes)", sender.ConnectionId, bytes.Length));
            return HandleResult.Ok;
        }
        /// <summary>
        /// 接收事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="bytes"></param>
        /// <returns></returns>
        HandleResult OnReceive(TcpClient sender, byte[] bytes)
        {
            // 数据到达了
            byte[] contentBytes = new byte[bytes.Length];
            Array.ConstrainedCopy(bytes, 0, contentBytes, 0, contentBytes.Length);
            string data = Encoding.Default.GetString(contentBytes); 
            string[] tmp = data.Split(',');
            
            if (isSend)
            {
                isSend = false;
                if (tmp.Length <= 1)
                {                    
                    Receive_Cordinate = new Vector(0, 0);
                    Rec_Ok = true;
                    LogErr?.Invoke("图像处理反馈 -- 识别失败,数据:" + data);
                }
                else
                {
                    if ((decimal.TryParse(tmp[0], out decimal d_tmp_x)) && (decimal.TryParse(tmp[1], out decimal d_tmp_y)))
                    {
                        Receive_Cordinate = new Vector(d_tmp_x, d_tmp_y);
                        Rec_Ok = true;
                    }
                    else
                    {
                        Receive_Cordinate = new Vector(0, 0);
                        Rec_Ok = true;
                        LogErr?.Invoke("图像处理数据转换 -- 相机坐标提取失败！！！！");
                    }
                }
            }            
            return HandleResult.Ok;
        }
        /// <summary>
        /// 关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="enOperation"></param>
        /// <param name="errorCode"></param>
        /// <returns></returns>
        HandleResult OnClose(TcpClient sender, SocketOperation enOperation, int errorCode)
        {
            ConnectOk = false;//连接标志 清除
            if (errorCode == 0)
                // 连接关闭了
                LogInfo?.Invoke(string.Format(" > [{0},OnClose]", sender.ConnectionId));
            else
                // 出错了
                LogErr?.Invoke(string.Format(" > [{0},OnError] -> OP:{1},CODE:{2}", sender.ConnectionId, enOperation, errorCode));

            return HandleResult.Ok;
        }
        /// <summary>
        /// 返回相机坐标反推额实际坐标
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Vector Get_Coordinate_Corrrect_Point(decimal x, decimal y)
        {
            return new Vector(x * Program.SystemContainer.SysPara.Cam_Trans_Affinity.Stretch_X + y * Program.SystemContainer.SysPara.Cam_Trans_Affinity.Distortion_X + Program.SystemContainer.SysPara.Cam_Trans_Affinity.Delta_X, y * Program.SystemContainer.SysPara.Cam_Trans_Affinity.Stretch_Y + x * Program.SystemContainer.SysPara.Cam_Trans_Affinity.Distortion_Y + Program.SystemContainer.SysPara.Cam_Trans_Affinity.Delta_Y);
        }
        /// <summary>
        /// 返回 相机坐标系矫正过后的坐标数据
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public Vector Get_Cam_Deviation_Coordinate_Correct(int order)
        {
            Vector Result;
            //检测是否连接
            if (!ConnectOk)
            {
                LogErr?.Invoke("相机未连接！！！");
                return new Vector(0, 0);
            }
            //发送指令
            Send_Data(order);
            //等待完成
            Task.Factory.StartNew(() => { do { } while (!Rec_Ok); }).Wait(5 * 1000);//5 * 1000,该时间范围内：代码段完成 或 超出该时间范围 返回并继续向下执行
            //换算数据
            if (Rec_Ok && (Receive_Cordinate.Length != 0))
            {
                Result = new Vector(Get_Coordinate_Corrrect_Point(Receive_Cordinate.X, Receive_Cordinate.Y));
            }
            else
            {
                Result = new Vector(0, 0);//异常接收退出
                LogErr?.Invoke("坐标系矫正 -- 相机图形识别失败！！！");
            }
            //返回数据
            return Result;
        }
        /// <summary>
        /// 返回 像素计算矫正的坐标值
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public Vector Get_Cam_Deviation_Pixel_Correct(int order)
        {
            Vector Result;
            //检测是否连接
            if (!ConnectOk)
            {
                LogErr?.Invoke("相机未连接！！！");
                return new Vector(0, 0);
            }
            //发送指令
            Send_Data(order);
            //等待完成
            Task.Factory.StartNew(() => { do { } while (!Rec_Ok); }).Wait(5 * 1000);//5 * 1000,该时间范围内：代码段完成 或 超出该时间范围 返回并继续向下执行
            //换算数据
            if (Rec_Ok && (Receive_Cordinate.Length != 0))
            {
                Result = new Vector(Receive_Cordinate.X * Program.SystemContainer.SysPara.Cam_Reference, Receive_Cordinate.Y * Program.SystemContainer.SysPara.Cam_Reference);
            }
            else
            {
                Result = new Vector(0, 0);//异常接收退出
                LogErr?.Invoke("像素矫正及计算 -- 相机图形识别失败！！！");
            }
            //返回数据
            return Result;
        }
        /// <summary>
        /// 返回 实际像素坐标
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public Vector Get_Cam_Actual_Pixel(int order)
        {
            Vector Result;
            //检测是否连接
            if (!ConnectOk)
            {
                LogErr?.Invoke("相机未连接！！！");
                return new Vector(0, 0);
            }
            //发送指令
            Send_Data(order);
            //等待完成
            Task.Factory.StartNew(() => { do { } while (!Rec_Ok); }).Wait(5 * 1000);//5 * 1000,该时间范围内：代码段完成 或 超出该时间范围 返回并继续向下执行
            //换算数据
            if (Rec_Ok && (Receive_Cordinate.Length != 0))
            {
                Result = new Vector(Receive_Cordinate.X, Receive_Cordinate.Y);
            }
            else
            {
                Result = new Vector(0, 0);//异常接收退出
                LogErr?.Invoke("返回实际像素 -- 相机图形识别失败！！！");
            }
            //返回数据
            return new Vector(Result);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System;
using System.Threading;

public class Connection
{
    //Socket客户端对象     
    private Socket clientSocket;

    public int conectionServer()
    {

        //创建Socket对象， 这里我的连接类型是TCP     
        clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //服务器IP地址     
        IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
        //服务器端口     
        IPEndPoint ipEndpoint = new IPEndPoint(ipAddress, 10020);
        //这是一个异步的建立连接，当连接建立成功时调用connectCallback方法     
        IAsyncResult result = clientSocket.BeginConnect(ipEndpoint, new AsyncCallback(connectCallback), clientSocket);
        //这里做一个超时的监测，当连接超过5秒还没成功表示超时     
        bool success = result.AsyncWaitHandle.WaitOne(5000, true);
        if (!success)
        {
            //超时     

            Debug.Log("connect Time Out");
        }
        else
        {
            //与socket建立连接成功，开启线程接受服务端数据。     
            //worldpackage = new List<JFPackage.WorldPackage>();
            Thread thread = new Thread(new ThreadStart(ReceiveSorket));
            thread.IsBackground = true;
            thread.Start();
        }
        return 0;
    }
    private void connectCallback(IAsyncResult asyncConnect)
    {
        Debug.Log("connectSuccess");
    }
    private void ReceiveSorket()
    {
        //在这个线程中接受服务器返回的数据     
        while (true)
        {

            if (!clientSocket.Connected)
            {
                //与服务器断开连接跳出循环     
                Debug.Log("Failed to clientSocket server.");
                clientSocket.Close();
                break;
            }
            try
            {
                //接受数据保存至bytes当中     
                byte[] bytes = new byte[45056];
                //Receive方法中会一直等待服务端回发消息     
                //如果没有回发会一直在这里等着。     
                int i = clientSocket.Receive(bytes);
                if (i <= 0)
                {
                    clientSocket.Close();
                    break;
                }

                //这里条件可根据你的情况来判断。     
                //因为我目前的项目先要监测包头长度，     
                //我的包头长度是8，所以我这里有一个判断     
                if (bytes.Length > 8)
                {
                    SplitPackage(bytes, 0);
                }
                else
                {
                    Debug.Log("length is not  > 8");
                }

            }
            catch (Exception e)
            {
                Debug.Log("Failed to clientSocket error." + e);
                clientSocket.Close();
                break;
            }
        }
    }
    private void SplitPackage(byte[] bytes, int index)
    {
        DataBuffer data = getAgreeMentMessage(bytes);
        ICommand icommand = new ICommand();
        icommand.ReadBufferIp(data);
        Debug.Log("id===="+icommand.header.id);
        Debug.Log("length====="+icommand.header.length);
        if (icommand.header.id == CommandID.Connect)
        {
            ConnectCommand conect2 = new ConnectCommand();
            conect2.header.id = icommand.header.id;
            conect2.header.length = icommand.header.length;
            conect2.ReadFromBufferBody(data);
            Debug.Log(conect2.body);
        }
    }
    /**
	 * 接受协议信息
	 * @param bytes
	 * @return
	 */
    public DataBuffer getAgreeMentMessage(byte[] bytes)
    {
        DataBuffer data = new DataBuffer();
        char[] c = data.getChars(bytes);

        return data;
    }
}
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
    private static Socket clientSocket;
    public static Socket getInstance()
    {
        if(clientSocket!= null)
        {
            return clientSocket;
        }
        return null;
    }
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
            //检查文件
            
            string txt = UserFileTool.readFile();
            if(txt.Length == 0)
            {
                //发送空文件
                SendTool.sendMessage(new GuestLoginCommand(), JsonTools.getString(new Info("")));
            }
            else
            {
                PlayerInfo.playerId = txt;
            }
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
        XMAgreement.parserAgreement(data);
        /*
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
           
            Loom.RunAsync(() =>
            {
               
                //Run some code on the main thread  
                //to update the mesh  
                //通过Loom静态方法 使用lambda 表达式在主线Action队列中加入新的方法，在Update中执行
                //这块还是比较巧妙地，步骤 
                //1、在子线程中进行 计算 
                //2、计算完毕后子线程将结果和其赋值函数一起放入主线程Action队列中（还在子线程中） 
                //3、在主线程Update函数中执行主线程Action队列(在主线程中)，实际是借用了Update的特性替代了轮询操作
                //参数d
                Loom.QueueOnMainThread(() =>
                {
                    GameObject.Find("Label_result").GetComponent<UILabel>().text = conect2.body;
                });
            });
          } 
        */
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XMAgreement  {
    
    public static ICommand parserAgreement(DataBuffer data)
    {
        ICommand icommand = new ICommand();
        icommand.ReadBufferIp(data);
        Debug.Log("id====" + icommand.header.id);
        Debug.Log("length=====" + icommand.header.length);
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
            return conect2;
        }else if (icommand.header.id == CommandID.Heart)
        {
            
        }
        else if (icommand.header.id == CommandID.GuestLogin)
        {
            GuestLoginCommand guest = new GuestLoginCommand();
            guest.header.id = icommand.header.id;
            guest.header.length = icommand.header.length;
            guest.ReadFromBufferBody(data);

        }
        return icommand;
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class SendTool  {

	public static void sendMessage(ICommand iCommand, string str)
    {
        DataBuffer data = createAgreeMentMessage(iCommand, str);
        Connection.getInstance().Send(Encoding.ASCII.GetBytes(str));
        Debug.Log("发送协议"+str);
    }
    /**
	 * 创建协议信息
	 * @param iCommand
	 * @param str
	 * @return
	 */
    public static DataBuffer createAgreeMentMessage(ICommand iCommand, string str)
    {
        DataBuffer data = new DataBuffer();
        iCommand.WriteToBuffer(data, str);
        return data;
    }
}

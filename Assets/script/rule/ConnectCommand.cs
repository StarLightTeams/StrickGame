using UnityEngine;
using UnityEditor;

/// 连接协议
public class ConnectCommand : ICommand
{


    public string body = "";
    public ConnectCommand() : base(CommandID.Connect)
    {
       
    }
    public ConnectCommand(int id) : base(id)
    {
        // TODO Auto-generated constructor stub
     }
    public override void WriteBody(DataBuffer buffer, string str)
    {   
        buffer.WriteString(str);
    }
    public override void ReadBody(DataBuffer buffer)
    {
        //		buffer.ReadChar();
        body = buffer.ReadString();
    }
}
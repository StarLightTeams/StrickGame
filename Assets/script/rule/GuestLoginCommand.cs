using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestLoginCommand : ICommand
{
    public GuestLoginCommand() : base(CommandID.Connect)
    {

    }
    public GuestLoginCommand(int id) : base(id)
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

using UnityEngine;
using UnityEditor;

public class CommandID : ScriptableObject
{
    public  static int Unknown = 0x0000;//未知指令
    public  static int Heart = 0x0001;//心跳指令
    public  static int Connect = 0x0002;//连接协议
    public  static int GuestLogin = 0x0003;//游客登录
    public  static int Login = 0x0004;//用户登录
}
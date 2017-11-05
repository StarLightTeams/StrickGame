using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserFileTool
{
    
	public static void mdfir_file()
    {
        MdireFile m = new MdireFile();
        m.mkdirFile("userInfo", "user.txt"); 
    }
    //写入文件
    public static void writeFile(string txt)
    {
        //写入userid,name
        WriteMessage w = new WriteMessage();
        w.writeInfoToFile("userInfo/user.txt", txt);
    }
    //传入文件名字，返回文件内容
    public static string readFile()
    {
        ReadMessage r = new ReadMessage();
        string str = r.readInfoToFile("userInfo/user.txt");
        Debug.Log(str);
        return str;
    }
}

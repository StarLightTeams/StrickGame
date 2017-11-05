using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class YouKeLogin : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void login(string name)
    {
        if (!File.Exists(name))
        {
            string str  = readFile();

        }
        else
        {
            mdfir_file();

        }
    }
    public void mdfir_file()
    {
        MdireFile m = new MdireFile();
        m.mkdirFile("userInfo", "user.txt");
    }
    //写入文件
    public void writeFile()
    {
        //写入userid,name
        WriteMessage w = new WriteMessage();
        w.writeInfoToFile("userInfo/user.txt", "1111111");
    }
    //传入文件名字，返回文件内容
    public string readFile()
    {
        ReadMessage r = new ReadMessage();
        string str = r.readInfoToFile("userInfo/user.txt");
        Debug.Log(str);
        return str;
    }
}

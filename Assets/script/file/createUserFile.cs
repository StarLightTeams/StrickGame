using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createUserFile  : MonoBehaviour
{

	public void mdfir_file()
    {
        MdireFile m = new MdireFile();
        m.mkdirFile("userInfo", "user.txt");
        //写入userid,name
        WriteMessage w = new WriteMessage();
       w.writeInfoToFile("userInfo/user.txt", "1111111");
        ReadMessage r = new ReadMessage();
        string str = r.writeInfoToFile("userInfo/user.txt");
        Debug.Log(str);
    }
}

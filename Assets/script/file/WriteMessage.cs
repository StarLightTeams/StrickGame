using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class WriteMessage
{
    /*
     *写入信息 
     */
    public void writeInfoToFile(string filepath, string txt)
    {
        File.WriteAllText(Application.streamingAssetsPath + "/"+filepath, txt, Encoding.UTF8);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
public class ReadMessage  {

    /*
    *读信息 
    */
    public string readInfoToFile(string filepath)
    {
        return File.ReadAllText(Application.streamingAssetsPath + "/" + filepath, Encoding.UTF8);
    }
}

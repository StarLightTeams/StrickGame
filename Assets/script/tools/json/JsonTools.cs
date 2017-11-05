using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Data
{
    public string className;
    public Object data;
}
public class JsonTools
{
    
    public static Player readJson(string json)
    {
        return JsonUtility.FromJson<Player>(json);
    }

    public static string writeJson(Player player)
    {
       return JsonUtility.ToJson(player);
    }
    public static string getString(Object obj)
    {
        Data data = new Data();
        data.className = obj.GetType().FullName;
        data.data = obj;
        return JsonUtility.ToJson(data);
    }
}

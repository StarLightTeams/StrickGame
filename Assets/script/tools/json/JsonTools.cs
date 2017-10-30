using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}

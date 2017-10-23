using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateStrickController : MonoBehaviour {
    // Use this for initialization

    private int columnNum = 8;//列数  
    private int rowNum = 3;//列数 
    public Transform transform;
    public GameObject brick;//预制体，此处是一个立方体 
    void Start () {
        for (int rowIndex = 0; rowIndex < rowNum; rowIndex++)
        {
            for (int columnIndex = 0; columnIndex < columnNum; columnIndex++)
            {
                string cubePath = "Prefabs/strick";
                //把资源加载到内存中
                Object cubePreb = Resources.Load(cubePath, typeof(GameObject));
                //用加载得到的资源对象，实例化游戏对象，实现游戏物体的动态加载
                GameObject brick = Instantiate(cubePreb) as GameObject;

                //Instantiate(brick, new Vector3(columnIndex*2800  -11000, 18622 - 2800*rowIndex, 0), Quaternion.identity);
                brick.transform.parent = transform;
                brick.transform.position = new Vector3(-14+columnIndex * 4, 16 +4 * rowIndex, 0);
                //brick.GetComponent<Transform>().position = new Vector3(1, 0, 0);
                brick.transform.localScale = new Vector3(20F, 20F, 0);

            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

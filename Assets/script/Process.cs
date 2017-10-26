using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Process : MonoBehaviour {
    private UIProgressBar progressBar;
    public GameObject loginScene;
    private ServerConnect serverConnect = new ServerConnect();
    float i = 0;
    bool isStart = true;
    int state;
    // Use this for initialization
    void Start () {
        progressBar = this.GetComponent<UIProgressBar>();
        progressBar.value = 0;
        state =serverConnect.connectionToserver();
    }
    private void OnGUI()
    {
       
    }
    // Update is called once per frame
    void Update ()
    {
        if (isStart)
        {
            i += 0.01f;
            progressBar.value = i; Debug.Log(i);
            if (i > 1 && isStart)
            {
                isStart = false;
               
            }
        }
        else
        {
            if (state != 0)
            {
                GameObject.Find("ConnectionObject").SetActive(false);
                loginScene.SetActive(true);
            }
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Process : MonoBehaviour {
    private UIProgressBar progressBar;
    public GameObject loginScene;
    float i = 0;
    bool isStart = true;
    // Use this for initialization
    void Start () {
        progressBar = this.GetComponent<UIProgressBar>();
        progressBar.value = 0;
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
                GameObject.Find("ConnectionObject").SetActive(false);
                loginScene.SetActive(true);
            }
        }

    }
}

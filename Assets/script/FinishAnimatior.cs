using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishAnimatior : MonoBehaviour {

    private UISpriteAnimation animation;
    public GameObject connectscene;
	// Use this for initialization
	void Start () {
        animation = this.GetComponent<UISpriteAnimation>();
    }
	
	// Update is called once per frame
	void Update () {
		Debug.Log(animation.isPlaying);
        if (!animation.isPlaying) { 

            connectscene.SetActive(true);
            GameObject.Find("WeclomeScene").SetActive(false);
            
        }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehvavior : MonoBehaviour
{

    private Transform transform;
    Rigidbody2D rigidbody2D;
    private int li = 0;
    // Use this for initialization
    void Start()
    {
        transform = this.GetComponent<Transform>();
        rigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (li % 3 == 0) {
            li = 0;
         transform.position = new Vector3(transform.position.x, transform.position.y + 1, 0);
        }
        li++;
    }
    public void Move(Vector3 postions)
    {
        //在这里进行坐标的换算
        rigidbody2D.MovePosition(ScreenToWorld(postions));
    }
    private Vector2 ScreenToWorld(Vector3 postion)
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(postion);
        return new Vector2(pos.x, pos.y);

    }
}

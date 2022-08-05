using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxes : MonoBehaviour
{
    public float Upspeed = 1f;
    public float velocitySpeed = 11f;
    private bool movingRight = true;


    void Start()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.up * Time.deltaTime * Upspeed); //一直往上

        if (movingRight) //如果往右移動
        {
            transform.Translate(Vector3.right * velocitySpeed * Time.deltaTime); //往右移

            //如果往右邊移動0.5，把往右移動的狀態false
            if (transform.position.x >= 0.5)
            {
                movingRight = false;                
            }
        }
        else
        {
            //往左移
            transform.Translate(Vector3.left * velocitySpeed * Time.deltaTime);
            
            //如果往左移動0.5，把往右移動的狀態true，開始往右移動
            if (transform.position.x <= -0.5)
            {
                movingRight = true;                
            }
        }
    }
}

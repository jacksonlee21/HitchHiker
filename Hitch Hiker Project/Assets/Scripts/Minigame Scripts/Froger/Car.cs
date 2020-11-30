using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{

    public float moveSpeed = 5f;
    public bool moveD = false;
        void Start()
    {
        
    }

    
    void Update()
    {
        Vector2 pos = transform.localPosition;

        if(moveD)
        {
            pos.x += Vector2.right.x * moveSpeed * Time.deltaTime;

                if(pos.x >= 15)
            {
                pos.x = -15;
            }
        }
        else
        {
            pos.x += Vector2.left.x * moveSpeed * Time.deltaTime;
            
                if(pos.x <= -15)
            {
                pos.x = 15;
            }
        }

        

        transform.localPosition = pos;
    }
}

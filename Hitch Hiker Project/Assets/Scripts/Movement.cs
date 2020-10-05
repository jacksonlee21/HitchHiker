using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    float movedirection = 0f;

    void Update()
    {
        if(Input.GetKey("a"))
        {
            movedirection = -1f;
        }
        else if (Input.GetKey("d"))
        {
            movedirection = 1f;
        }
        else
        {
            movedirection = 0f;
        }

    }

    public void FixedUpdate()
    {
        if (movedirection == -1)
        {
            Debug.Log("Left");
            transform.position += new Vector3(-1 * Time.deltaTime, 0, 0);
        }
        if (movedirection == 1)
        {
            Debug.Log("Right");
            transform.position += new Vector3(1 * Time.deltaTime, 0, 0);
        }
    }
}

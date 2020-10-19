using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame1s : MonoBehaviour
{
    int counter = 0;
    public int limit;
    int direction = 3;
    GameObject Hammer;

    void Update()
    {
        if(Input.GetButtonDown("Space"))
        {
            counter++;
            if(counter % 20 == 0)
            {
                direction = direction * -1;
                //Debug.Log("Test");
            }
            //Debug.Log(direction);
            transform.Rotate(Vector3.back * direction); 
            
        }
        Debug.Log(counter);

        if(counter == limit)
        {
            //You Win;
        }
    }
}

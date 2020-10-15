using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame1s : MonoBehaviour
{
    int counter = 0;
    public int limit;

    void Update()
    {
        if(Input.GetButtonDown("Space"))
        {
            counter++;
        }
        Debug.Log(counter);

        if(counter == limit)
        {
            //You Win;
        }
    }
}

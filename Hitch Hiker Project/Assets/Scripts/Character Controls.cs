using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControls : MonoBehaviour
{

    float movedirection = 0f;

    void Update()
    {
        movedirection = Input.GetAxisRaw("Horrizontal");
    }

    public void FixedUpdate()
    {
        if(movedirection == -1)
        {
            transform.position = new Vector2(-1, 0);
        }
        if (movedirection == 1)
        {
            transform.position = new Vector2(1, 0);
        }
    }
}

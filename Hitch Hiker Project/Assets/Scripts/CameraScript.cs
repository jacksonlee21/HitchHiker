﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float leftLimit;
    public float rightLimit;
    public float playerPosition;
    public float cameraPosition;
    
    void Update()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().transform.position.x;

        if (playerPosition < leftLimit)
        {
            cameraPosition = leftLimit;
        }
        else if(playerPosition > rightLimit)
        {
            cameraPosition = rightLimit;
        }
        else
        {
            cameraPosition = playerPosition;
        }
        transform.position = new Vector3(cameraPosition, 1f, -5f);
    }
}

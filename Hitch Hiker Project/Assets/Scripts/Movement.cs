﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float movedirection = 0f;
    public bool walking;
    public Animator playerAnim;

    public void Awake()
    {
        if(!PlayerPrefs.HasKey("playersLastPosition"))
        {
            PlayerPrefs.SetFloat("playersLastPosition", -20f);
        }
        transform.position = new Vector3(PlayerPrefs.GetFloat("playersLastPosition"), 0, 0);
    }

    void Update()
    {
        GameObject dialogueManager = GameObject.Find("dialogueManager");
        Dialogue dialogueScript = dialogueManager.GetComponent<Dialogue>();

        if (Input.GetKey("a") && dialogueScript.canMove)
        {
            movedirection = -1f;
            walking = true;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (Input.GetKey("d") && dialogueScript.canMove)
        {
            movedirection = 1f;
            walking = true;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            movedirection = 0f;
            walking = false;
        }
        playerAnim.SetBool("In Motion", walking);

        if(Input.GetKey("t"))
        {
            Debug.Log("should do text");
            dialogueScript.sentences = new string[] { "Wassup kiddo", "You are cool", "GO YOU!" };
            dialogueScript.Type();
        }
    }

    public void FixedUpdate()
    {
        if (movedirection == -1)
        {
            transform.position += new Vector3(-1 * Time.deltaTime, 0, 0);
        }
        if (movedirection == 1)
        {
            transform.position += new Vector3(1 * Time.deltaTime, 0, 0);
        }
    }
}

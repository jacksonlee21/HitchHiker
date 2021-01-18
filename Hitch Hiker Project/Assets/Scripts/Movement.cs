﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float movedirection = 0f;
    public bool walking;
    public Animator playerAnim;

    public NPCManager npcManager;

    public void Awake()
    {
        npcManager = GameObject.FindGameObjectWithTag("NPCController").GetComponent<NPCManager>();

        if(!PlayerPrefs.HasKey("playersLastPosition"))
        {
            PlayerPrefs.SetFloat("playersLastPosition", -20f);
        }
        else
        {
            npcManager.StartPostConversation();
        }
        transform.position = new Vector3(PlayerPrefs.GetFloat("playersLastPosition"), 0f, 0f);
    }

    void Update()
    {
        GameObject dialogueManager = GameObject.Find("dialogueManager");
        Dialogue dialogueScript = dialogueManager.GetComponent<Dialogue>();

        if (Input.GetKey("a") && dialogueScript.ifDone)
        {
            movedirection = -1f;
            walking = true;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (Input.GetKey("d") && dialogueScript.ifDone)
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

        if (Input.GetKeyDown("t"))
        {
            //dialogueScript.NewText(new string[] { "Wassup kiddo", "You are cool", "Do you want to steal my wallet?" }, true, new string[] { "No way bruh.", "Yes Please." }, new string[] { "You're nice.", "Jail Jail Jail!" });
            dialogueScript.NewText(new string[] { "Street Guy: Hey you're up!", "You: Where am I?", "Street Guy: idk lol, goodbye", "You: okay bye guy" }, false, null, null)
;        }
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

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("NPC"))
        {
            npcManager.NextToNPC(other);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("NPC"))
        {
            npcManager.LeftNPC();
        }
    }
}

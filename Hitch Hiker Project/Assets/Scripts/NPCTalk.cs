using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCTalk : MonoBehaviour
{
    private Transform player;
    private NPCController npcController;

    [HideInInspector]
    public bool NextToPlayer;
    [HideInInspector]
    public bool TalkingToPlayer;

    private Animator anim;

    public bool HasTask;
    public Tasks NPCTask = null;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        npcController = GameObject.FindGameObjectWithTag("NPCController").GetComponent<NPCController>();
        anim = GetComponent<Animator>();

        NextToPlayer = false;
        TalkingToPlayer = false;
    }

    void Update()
    {
        if (HasTask)
        {
            StartTalking();
        }
        if (TalkingToPlayer)
        {
            ShowText();
        }
    }

    void ShowText()
    {
        npcController.NPCText.text = "Hey Buddy, can you give this " + NPCTask.ObjectToDeliver + ". You got " + NPCTask.TimeToDeliver + " seconds";
    }

    void StartTalking()
    {
        if (NextToPlayer)
        {
            if (Input.GetKeyDown(KeyCode.Space) || TalkingToPlayer)
            {
                TalkingToPlayer = true;
                
                anim.SetBool("In Motion", false);
            }
        }
    }

    
}

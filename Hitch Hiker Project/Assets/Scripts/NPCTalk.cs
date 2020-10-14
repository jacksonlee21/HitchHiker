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
    [HideInInspector]
    public bool isOtherNPC;

    private Animator anim;

    [HideInInspector]
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
    }

    void StartTalking()
    {
        if (NextToPlayer)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                TalkingToPlayer = true;
                npcController.ShowText();
                NextToPlayer = false;  
            }
            if (TalkingToPlayer)
            {
                anim.SetBool("In Motion", false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && isOtherNPC && npcController.inTask)
        {
            Instantiate(npcController.FinishedTaskEffect, player.position, Quaternion.identity);
            isOtherNPC = false;
            npcController.inTask = false;
            Destroy(transform.GetChild(0).gameObject);
            npcController.NPCText.gameObject.SetActive(false);
        }
    }
}

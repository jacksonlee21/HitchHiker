using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCTalk : MonoBehaviour
{
    private Transform player;

    [HideInInspector]
    public bool NextToPlayer;
    [HideInInspector]
    public bool TalkingToPlayer;

    private Animator anim;

    public bool HasTask;

    private void Start()
    {
        //TalkImage = GameObject.FindGameObjectWithTag("TalkToNPC_Image").GetComponent<Image>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
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
            if (Input.GetKeyDown(KeyCode.Space) || TalkingToPlayer)
            {
                TalkingToPlayer = true;
                
                anim.SetBool("In Motion", false);
            }
        }
    }

    
}

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
            //Sets private vars
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            npcController = GameObject.FindGameObjectWithTag("NPCController").GetComponent<NPCController>();
            anim = GetComponent<Animator>();
            //Sets bools false
            NextToPlayer = false;
            TalkingToPlayer = false;
        }

        void Update()
        {
            //Checks if NPC has a task for player
            if (HasTask)
            {
                //If yes -> runs function
                ReadyToTalk();
            }
        }

        //Function that checks if player presses space to talk
        private void ReadyToTalk()
        {
            if (NextToPlayer)
            {
                //Checks if space is pressed to start talking to NPC
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    //Shows text and sets talking to player bool to true, and next to player false
                    TalkingToPlayer = true;
                    NextToPlayer = false;
                    npcController.ShowText();
                }
                //Stops NPC walking animation
                if (TalkingToPlayer)
                {
                    anim.SetBool("In Motion", false);
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            //Checks if other NPC is next to player, and if game is in task mode
            if(other.CompareTag("Player") && isOtherNPC && npcController.inTask)
            {
                //Spawns finished task effect
                Instantiate(npcController.FinishedTaskEffect, player.position, Quaternion.identity);
                //Ends task mode and gets rid of NPC role
                isOtherNPC = false;
                npcController.inTask = false;
                //Gets rid of image and text
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(0).transform.SetParent(null);
                npcController.NPCText.gameObject.SetActive(false);
            }
        }
}






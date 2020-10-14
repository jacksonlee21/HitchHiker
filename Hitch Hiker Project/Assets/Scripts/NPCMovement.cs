using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCMovement : MonoBehaviour
{
    private Vector3 randPos;
    public float speed = 5f;
    public float walkTime;
    private float timeTillGetPos;

    private Animator anim;
    private Rigidbody2D rb;

    private NPCTalk npcTalk;
    

    private void Start()
    {
        timeTillGetPos = walkTime;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        npcTalk = GetComponent<NPCTalk>();
    }

    void Update()
    {
        if (!npcTalk.TalkingToPlayer)
        {
            GoToPos();
            TriggerAnimation();
        }
    }

    void TriggerAnimation()
    {
        if (transform.position == randPos)
        {
            anim.SetBool("In Motion", false);
        }
        else if (transform.position.x < randPos.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
            anim.SetBool("In Motion", true);
        }
        else if (transform.position.x > randPos.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            anim.SetBool("In Motion", true);
        }
    }

    void GoToPos()
    {
        timeTillGetPos += Time.deltaTime;

        if(timeTillGetPos >= walkTime)
        {
            GetRandPos();
            timeTillGetPos = 0;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, randPos, speed * Time.deltaTime);
        }
    }

    void GetRandPos()
    {
        float randX = Random.Range(-9f, 9f);

        randPos = new Vector3(randX, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            npcTalk.NextToPlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            npcTalk.NextToPlayer = false;
        }
    }
}

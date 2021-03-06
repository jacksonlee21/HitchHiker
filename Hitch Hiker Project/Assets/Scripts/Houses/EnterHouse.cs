﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterHouse : MonoBehaviour
{
    private bool atDoor;
    private string houseName;
    private ArrowManager arrowManager;
    public bool enterHouse;
    public Collider2D hitArrow;

    private void Start()
    {
        arrowManager = GameObject.FindGameObjectWithTag("ArrowManager").GetComponent<ArrowManager>();
        atDoor = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (atDoor)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                enterHouse = true;
                hitArrow = collision;

                GameObject dialogueManager = GameObject.Find("dialogueManager");
                Dialogue dialogueScript = dialogueManager.GetComponent<Dialogue>();
                
                dialogueScript.NewText(new string[] { "Want a Job?" }, true, new string[] { "No thanks", "I'd love one!" }, new string[] { "Fine, be ungrateful.", "" });


            }
        }
    }

    public void EnteringHouse()
    {

        PlayerPrefs.SetFloat("playersLastPosition", transform.position.x);
        arrowManager.CheckArrow(hitArrow.gameObject);
        SceneManager.LoadScene(houseName);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnterBuilding"))
        {
            atDoor = true;
            House tempHouse = collision.transform.parent.GetComponent<House>();
            houseName = tempHouse.sceneName;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("EnterBuilding"))
        {
            atDoor = false;
            houseName = "Null";
        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCManager : MonoBehaviour
{
    public npc[] townNPC = new npc[] {
        new npc("Little Boy", "Basketball Game",Storys.preBikePumpDialogue,Storys.postBikePumpDialogue),
        new npc("Little Girl", ""),
        new npc("Tough Guy", "",Storys.wakeUpDialogue),
        new npc("Angry Chef", "DishGame",Storys.preChefDialogue,Storys.postChefDialogue),
        new npc("Middle Aged Girl", "TrashPicker", Storys.preNinaDialogue,Storys.postNinaDialogue),
        new npc("Old Lady", "WeedPicker",Storys.preEdnaDialogue,Storys.postEdnaDialogue),
        new npc("Bug Man", "SquashBugs",Storys.preLudoDialogue, Storys.postLudoDialogue),
    };

    public int npcCounter = 0;
    public Transform[] npcObjects;
    private npc currentNPC;
    private GameObject currentNPCobject;
    private string currentSceneName;
    private bool preTalking;
    private float npcXpos;
    public static NPCManager instance;
    public GameObject npcParent;
    void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void gameStart()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("isFirstTime", true);
        PositionPlayer(GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(), npcObjects[5].transform);
        StartCoroutine(startingWait());
    }


    // toughguy
    // chef
    // bugman
    // little boy
    // old lady
    // middle aged girl
    // tough guy

    public IEnumerator startingWait()
    {
        yield return new WaitForSeconds(1.1f);

        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("getUp", true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("isFirstTime", false);

        yield return new WaitForSeconds(1.1f);
        OpeningDialogue();

    }

    private void OpeningDialogue()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("getUp", false);
        npcObjects[npcCounter].GetChild(0).gameObject.SetActive(true);
        
        GameObject.Find("dialogueManager").GetComponent<Dialogue>().NewText(Storys.wakeUpDialogue, false, null, null);
    }

    private void CheckWhichNPC(string name)
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            foreach(npc npc in townNPC)
            {
                if(npc.name == name && npc.preTaskDialogue != null && npc.minigameScene != "")
                {
                    currentNPC = npc;
                    StartConversation();
                    npcObjects[npcCounter].GetChild(0).gameObject.SetActive(false);
                    npcCounter++;
                }
            }
        }
    }

    private void Update()
    {
        if(preTalking)
        {
            if(GameObject.Find("dialogueManager").GetComponent<Dialogue>().ifDone)
            {
                preTalking = false;
                PlayerPrefs.SetFloat("playersLastPosition", GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position.x);
                npcParent.SetActive(false);
                SceneManager.LoadScene(currentNPC.minigameScene);
            }
        }
    }

    private void StartConversation()
    {
        CameraZoom.Center(GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(), npcXpos);
        PositionPlayer(GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>());
        
        preTalking = true;
        GameObject.Find("dialogueManager").GetComponent<Dialogue>().NewText(currentNPC.preTaskDialogue, false, null, null);
    }
    public void StartPostConversation()
    {
        npcObjects[npcCounter].GetChild(0).gameObject.SetActive(true);
        npcParent.SetActive(true);
        if(currentNPC.postTaskDialogue != null)
        {
            CameraZoom.Center(GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(), npcXpos);
            PositionPlayer(GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>());
            GameObject.Find("dialogueManager").GetComponent<Dialogue>().NewText(currentNPC.postTaskDialogue, false, null, null);
            currentNPC = null;
            currentNPCobject = null;
            currentSceneName = null;
        }
    }

    private void PositionPlayer(Transform player)
    {
        player.localScale = new Vector3(1, 1, 1);     
        GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position = new Vector2(npcXpos - 1.5f, GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position.y);
    }

    private void PositionPlayer(Transform player, Transform target)
    {
        player.localScale = new Vector3(1, 1, 1);     
        GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position = new Vector2(target.position.x - 1.5f, GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position.y);
    }
    
    public void NextToNPC(Collider2D other){
        currentNPCobject = other.gameObject;
        npcXpos = other.transform.parent.transform.position.x;
        CheckWhichNPC(other.transform.parent.name);
    }

    public void LeftNPC()
    {
    }
}

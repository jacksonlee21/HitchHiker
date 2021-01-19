using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCManager : MonoBehaviour
{
    public npc[] townNPC = new npc[] {
        new npc("Little Boy", ""),
        new npc("Little Girl", ""),
        new npc("Tough Guy", "", new string[] { "Street Guy: Hey you're up!", "You: Where am I?", "Street Guy: idk lol, goodbye", "You: okay bye guy" }),
        new npc("Angry Chef", ""),
        new npc("Middle Aged Girl", ""),
        new npc("Old Lady", ""),
        new npc("Bug Man", "SquashBugs", new string[] { "Bug Guy: Hey can you squash me bugs kind sir", "You: Where am I?", "Bug Guy: idk just please squash", "You: okay" }, new string[] { "Bug Guy: you did great! mwahh", "You: it was easy", "Bug Guy: thank you bro", "You: np :)" })
    };

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

    private void CheckWhichNPC(string name)
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            foreach(npc npc in townNPC)
            {
                if(npc.name == name && npc.preTaskDialogue != null && npc.minigameScene != "")
                {
                    Destroy(currentNPCobject.transform.GetChild(0).gameObject);
                    currentNPC = npc;
                    StartConversation();
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
    
    public void NextToNPC(Collider2D other){
        currentNPCobject = other.gameObject;
        npcXpos = other.transform.parent.transform.position.x;
        CheckWhichNPC(other.transform.parent.name);
    }

    public void LeftNPC()
    {
    }
}

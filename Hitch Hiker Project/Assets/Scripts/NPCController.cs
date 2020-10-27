using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCController : MonoBehaviour
{
    public GameObject NPCPrefab;
    public GameObject TalkImage;
    public GameObject FinishedTaskEffect;
    public GameObject ContinueText;
    public Text NPCText;

    [HideInInspector]
    public Tasks NPCTask = null;

    public int NPCsToSpawn;

    public float spawnRange;

    private int RandomNPCNum, OtherRandomNPCNum;
    private float time = 0;
    private NPCTalk npcWithTask,otherNPC;
    [HideInInspector]
    public bool inTask;

    void Awake()
    {
        //Sets Image That appears above NPCs head is disabled
        TalkImage.SetActive(false);
        //Sets the in task bool to false
        inTask = false;

        //Spawns a set amounnt of NPCs 
        for (int i = 0; i < NPCsToSpawn; i++)
        {
            float xSpawn = Random.Range(-spawnRange + 20, spawnRange + 20);
            Vector2 spawnLoc = new Vector2(xSpawn, 0);

            Instantiate(NPCPrefab, spawnLoc, Quaternion.identity);
        }

        //Finds a random NPC for a player to get a task from
        GiveTaskToNPC();  
    }

    //Function for selecting NPC
    public void GiveTaskToNPC()
    {
        //Gets an array of all NPCs in the scene and finds random NPC
        NPCTalk[] NPCInScene = FindObjectsOfType<NPCTalk>();
        RandomNPCNum = Random.Range(0, NPCInScene.Length - 1);
        npcWithTask = NPCInScene[RandomNPCNum];
        //Finds another random NPC for the task
        otherNPC = FindOtherNPC();

        //Assigns task for random NPC
        npcWithTask.NPCTask = new Tasks(3, "gameboy", otherNPC);
        //Sets bools to determine role of NPC
        npcWithTask.HasTask = true;
        otherNPC.isOtherNPC = true;

        //Sets the images parent to the NPC with task and above head
        TalkImage.transform.SetParent(npcWithTask.transform);
        TalkImage.transform.localPosition = new Vector2(0, .7f);
        TalkImage.SetActive(true);
    }

    //Function to find random NPC for the player to find
    public NPCTalk FindOtherNPC()
    {
        //Gets an array of all NPCs in the scene
        NPCTalk[] OtherNPCInScene = FindObjectsOfType<NPCTalk>();

        //Random number for finding random NPC that isn't the main NPC
        OtherRandomNPCNum = Random.Range(0, OtherNPCInScene.Length - 1);
        while(OtherRandomNPCNum == RandomNPCNum)
        {
            OtherRandomNPCNum = Random.Range(0, OtherNPCInScene.Length - 1);
        }
        //Returns the NPCTask class into otherNPC var
        return OtherNPCInScene[OtherRandomNPCNum];
    }

    //Update
    private void Update()
    {
        //Checks if the player is talking to the NPC
        if(npcWithTask.TalkingToPlayer && Input.GetKeyDown(KeyCode.Space)){
            //Disables text saying space to continue
            ContinueText.SetActive(false);
            //Sets in task bool to true
            inTask = true;
            //Function sets bools saying main NPC has task, its next to player, its talking to player to false
            SetAllFalse();
            //Sets time var to TimeToDeliver var
            time = npcWithTask.NPCTask.TimeToDeliver;
            //Sets the images parent to the NPC with task and places it above the NPC head
            TalkImage.transform.SetParent(otherNPC.transform);
            TalkImage.transform.localPosition = new Vector2(0, .7f);
        }
        //Checks if game is in task
        if (inTask)
        {
            //If it time runs task timer function
            TaskTimer();
        }
    }

    //Function that counts down time till deliver object to NPC
    void TaskTimer()
    {
        //Counts down time var and sets NPC text to time left
        time -= Time.deltaTime;
        NPCText.text = time.ToString("F2") + " seconds left";
        //Checks if time is up 
        if (time <= 0)
        {
            NPCText.text = "Times Up";
            //Ends task mode and destroys image above head
            inTask = false;
            otherNPC.isOtherNPC = false;
            Destroy(otherNPC.transform.GetChild(0).gameObject);
            //Waits to clear text saying Times Up
            StartCoroutine(DisableNPCTextWait());
        }
    }

    //Function sets bools saying main NPC has task, its next to player, its talking to player to false
    void SetAllFalse()
    {
        npcWithTask.HasTask = false;
        npcWithTask.NextToPlayer = false;
        npcWithTask.TalkingToPlayer = false;
    }
    //Waits to clear text saying Times Up
    IEnumerator DisableNPCTextWait()
    {
        yield return new WaitForSeconds(1.5f);
        NPCText.gameObject.SetActive(false);
    }
    //Function to show what the npc is saying
    public void ShowText()
    {
        ContinueText.SetActive(true);
        NPCText.text = "Hey Buddy, can you give this " + npcWithTask.NPCTask.ObjectToDeliver + "to my friend." + ". You got " + npcWithTask.NPCTask.TimeToDeliver + " seconds.";
    }
}


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

    private int RandomNPC, OtherRandomNPC;
    private float time = 0;
    private NPCTalk npcWithTask,otherNPC;
    [HideInInspector]
    public bool inTask;

    void Awake()
    {
        TalkImage.SetActive(false);
        inTask = false;

        for (int i = 0; i < NPCsToSpawn; i++)
        {
            float xSpawn = Random.Range(-spawnRange, spawnRange);
            Vector2 spawnLoc = new Vector2(xSpawn, 0);

            Instantiate(NPCPrefab, spawnLoc, Quaternion.identity);
        }

        GiveTaskToNPC();  
    }

    public void GiveTaskToNPC()
    {
        NPCTalk[] NPCInScene = FindObjectsOfType<NPCTalk>();

        RandomNPC = Random.Range(0, NPCInScene.Length - 1);

        npcWithTask = NPCInScene[RandomNPC];
        otherNPC = FindOtherNPC();

        npcWithTask.NPCTask = new Tasks(3, "gameboy", otherNPC);
        npcWithTask.HasTask = true;
        otherNPC.isOtherNPC = true;

        TalkImage.transform.SetParent(npcWithTask.transform);

        TalkImage.transform.localPosition = new Vector2(0, .7f);
        TalkImage.SetActive(true);
    }

    public NPCTalk FindOtherNPC()
    {
        NPCTalk[] OtherNPCInScene = FindObjectsOfType<NPCTalk>();

        OtherRandomNPC = Random.Range(0, OtherNPCInScene.Length - 1);
        while(OtherRandomNPC == RandomNPC)
        {
            OtherRandomNPC = Random.Range(0, OtherNPCInScene.Length - 1);
        }

        return OtherNPCInScene[OtherRandomNPC];
    }

    private void Update()
    {
        if(npcWithTask.TalkingToPlayer && Input.GetKeyDown(KeyCode.Space)){
            ContinueText.SetActive(false);
            inTask = true;
            SetAllFalse();
            time = npcWithTask.NPCTask.TimeToDeliver;

            TalkImage.transform.SetParent(otherNPC.transform);
            TalkImage.transform.localPosition = new Vector2(0, .7f);
        }

        if (inTask)
        {
            Timer();
        }
    }

    void Timer()
    {
        time -= Time.deltaTime;
        NPCText.text = time.ToString("F2") + " seconds left";

        if (time <= 0)
        {
            NPCText.text = "Times Up";
            inTask = false;
            otherNPC.isOtherNPC = false;
            Destroy(otherNPC.transform.GetChild(0).gameObject);
            StartCoroutine(DisableNPCTextWait());
        }
    }

    void SetAllFalse()
    {
        npcWithTask.HasTask = false;
        npcWithTask.NextToPlayer = false;
        npcWithTask.TalkingToPlayer = false;
    }

    IEnumerator DisableNPCTextWait()
    {
        yield return new WaitForSeconds(1.5f);
        NPCText.gameObject.SetActive(false);
    }

    public void ShowText()
    {
        ContinueText.SetActive(true);
        NPCText.text = "Hey Buddy, can you give this " + npcWithTask.NPCTask.ObjectToDeliver + "to my friend." + ". You got " + npcWithTask.NPCTask.TimeToDeliver + " seconds.";
    }
}


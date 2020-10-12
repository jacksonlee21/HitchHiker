using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public GameObject NPCPrefab;
    public GameObject TalkImage;

    public int NPCsToSpawn;

    public float spawnRange;


    void Awake()
    {
        TalkImage.SetActive(false);

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

        int RandomNPC = Random.Range(0, NPCInScene.Length - 1);

        NPCInScene[RandomNPC].HasTask = true;

        TalkImage.transform.SetParent(NPCInScene[RandomNPC].transform);

        TalkImage.transform.localPosition = new Vector2(0, .7f);
        TalkImage.SetActive(true);
    }
}


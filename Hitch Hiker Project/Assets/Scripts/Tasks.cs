using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tasks
{
    public float TimeToDeliver;
    public string ObjectToDeliver;
    public NPCTalk NPC;

    public Tasks(float timeToDeliver, string objectToDeliver, NPCTalk npc)
    {
        TimeToDeliver = timeToDeliver;
        ObjectToDeliver = objectToDeliver;
        NPC = npc;
    }
}

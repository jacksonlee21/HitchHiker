using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTask : MonoBehaviour
{
    public NPCController npcCont;
    private ItemManager itemManager;

    private void Start()
    {
        itemManager = GetComponent<ItemManager>();
    }

    private void Update()
    {
        itemManager.box = npcCont.inTask;
    }
}

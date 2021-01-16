using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public GameObject spaceToTalkObject;
    void Start()
    {
        spaceToTalkObject.SetActive(false);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("NPC"))
        {
            spaceToTalkObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("NPC"))
        {
            spaceToTalkObject.SetActive(false);
        }
    }
}

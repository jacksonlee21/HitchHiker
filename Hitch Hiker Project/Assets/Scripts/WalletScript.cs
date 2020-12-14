using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalletScript : MonoBehaviour
{
    public GameObject Wallet;
    public GameObject dialogueSystem;
    public int Rand;
    public bool FoundWallet;

    void Awake()
    {

        //if (!PlayerPrefs.HasKey("WalletScenario"))
        //{
        //    Rand = Random.Range(1,3);
        Rand = 1;
            if (Rand == 1)
            {
                PlayerPrefs.SetInt("WalletScenario", 1);
            }
            /*else
            {
                Wallet.SetActive(false);
            }
        }*/
        else
        {
            Wallet.SetActive(false);
        }
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Dialogue dialogueScript = dialogueSystem.GetComponent<Dialogue>();
            dialogueScript.NewText(new string[] { "You find a wallet on the ground", "You can either keep the money or try to return it", "Do you want to keep the money?" });
            FoundWallet = true;
            Debug.Log("Test");
        }
    }
}

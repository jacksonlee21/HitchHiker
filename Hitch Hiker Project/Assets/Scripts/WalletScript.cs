using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalletScript : MonoBehaviour
{
    public GameObject Wallet;
    public int Rand;

    void Awake()
    {

        if (!PlayerPrefs.HasKey("WalletScenario"))
        {
            Rand = Random.Range(1,2);
            if (Rand == 1)
            {
                PlayerPrefs.SetInt("WalletScenario", 1);
            }
            else
            {
                Wallet.SetActive(false);
            }
        }
        else
        {
            Wallet.SetActive(false);
        }
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Trigger a text box
        Debug.Log("Test");
    }
}

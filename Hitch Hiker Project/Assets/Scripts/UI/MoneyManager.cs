using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
   public int Money;
    
    void Start()
    {
        //PlayerPrefs.SetInt("cMoney", Money); 
        Money = 0;
        Money = PlayerPrefs.GetInt("cMoney");
    }

    void Update()
    {
        Money = PlayerPrefs.GetInt("cMoney");
    }
}

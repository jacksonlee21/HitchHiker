using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyDisplay : MonoBehaviour
{
    private MoneyManager moneyManager;
    int Money;
    Text MoneyText;

    // Start is called before the first frame update
    void Start()
    {
        moneyManager = GameObject.Find("Main Character").GetComponent<MoneyManager>();
        MoneyText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        MoneyText.text = moneyManager.Money.ToString();

    }
}

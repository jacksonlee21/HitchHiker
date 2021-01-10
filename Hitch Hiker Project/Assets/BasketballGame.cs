using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketballGame : MonoBehaviour
{
    public GameObject Basketball;
    public GameObject[] Pump = new GameObject[14];
    private int clickCounter = 0;
    int clickNumber = 0;
    public int clicksToWin = 50;
    bool goingDown = true;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            
            Debug.Log(clickCounter);
            clickNumber++;
            Basketball.transform.localScale += new Vector3(.05f, .05f, 0f);
            if(goingDown && clickCounter < Pump.Length -1)
            {
                clickCounter++;
            }
            if(!goingDown && clickCounter > 0)
            {
                clickCounter--;
            }
            if(clickCounter == Pump.Length -1)
            {
                goingDown = false;
            }
           
            if(clickCounter == 0)
            {
                goingDown = true;
            }


            for(int i = 0; i < Pump.Length; i++)
            {
                Pump[i].SetActive(false);
            }

            Pump[clickCounter].SetActive(true);

        }

        if(clickNumber == clicksToWin)
        {
            Debug.Log("YAYYYYYYYYYYYYY");
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BasketballGame : MonoBehaviour
{

    public GameObject[] Pump = new GameObject[2];
    public GameObject[] Basketballs = new GameObject[7];
    private int clickCounter = 0;
    private int clicksPerChange = 0;
    public int howManyToChange = 5;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {

            if(clickCounter % 2 != 0)
            {
                Pump[0].SetActive(true);
                Pump[1].SetActive(false);
            }
            else
            {
                Pump[0].SetActive(false);
                Pump[1].SetActive(true);

                clicksPerChange++;
            }

            if(clicksPerChange % howManyToChange == 0)
            {
                foreach(GameObject b in Basketballs)
                {
                    b.SetActive(false);
                }

                Basketballs[clicksPerChange/howManyToChange].SetActive(true);
            }

            if(clickCounter/howManyToChange == Basketballs.Length)
            {
                Debug.Log("YOU WIN");
            }

                clickCounter++;

        }
        
    }

}

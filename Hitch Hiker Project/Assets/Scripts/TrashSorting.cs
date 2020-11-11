using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSorting : MonoBehaviour
{

    public GameObject[] Items;
    int rand;
    int amountActive = 0;
    int startAmount = 0;


    // Start is called before the first frame update
    void Start()
    {
        rand = Random.Range(0, 6);
        Items[rand].SetActive(true);
    }

    // Update is called once per frame
    /*void Update()
    {
        //check every object in the array
        for(int i = 0; i < Items.Length; i++)
        {
            
            if(i == 0)
            {
                startAmount = amountActive;
            }

            if(Items[i].activeSelf)
            {
                amountActive++;
            }

            if(i == Items.Length - 1 && startAmount == amountActive)
            {
                amountActive = 0;
            }
        }

        if(amountActive < 1)
        {
            rand = Random.Range(0, 6);
            Items[rand].SetActive(true);
            amountActive = 0;
        }
    }*/


}

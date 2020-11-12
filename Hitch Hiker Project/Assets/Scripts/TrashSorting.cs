using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSorting : MonoBehaviour
{

    public GameObject[] Items;
    int rand;
    int oldRand;
    //int amountActive = 0;
   // int startAmount = 0;
    public bool isThereTrash = true;


    // Start is called before the first frame update
    void Start()
    {
        rand = Random.Range(0, 7 );
        Items[rand].SetActive(true);
        oldRand = rand;
    }

    void Update()
    {
        if(!isThereTrash)
        {
            Debug.Log("should work now thank u");
            rand = Random.Range(0, 7);
            if(rand != oldRand)
            {
                oldRand = rand;
                //Items[rand].transform.position = new Vector2(0f, 2f);
                Items[rand].SetActive(true);
                isThereTrash = true;
            }

        }
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

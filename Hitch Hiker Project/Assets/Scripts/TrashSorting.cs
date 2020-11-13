using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSorting : MonoBehaviour
{

    public GameObject[] Items;
    public int Points = 0;
    public bool isThereTrash = true;

    int rand;
    int oldRand;

    void Start()
    {
        rand = Random.Range(0, 7);
        GameObject newTrash = Instantiate(Items[rand], new Vector3(0f, 2f, 1f), Quaternion.identity);
        newTrash.SetActive(true);
        oldRand = rand;
    }

    void Update()
    {
        if(!isThereTrash)
        {
            Debug.Log("bye bye old trash hello new");
            rand = Random.Range(0, 7);
            if(rand != oldRand)
            {
                oldRand = rand;
                Debug.Log(Points);
                GameObject newTrash = Instantiate(Items[rand], new Vector3(0f,2f,1f), Quaternion.identity);

                //StartCoroutine(Wait());
                isThereTrash = true;
                
            }

        }
    }

   /* IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        //Items[rand].SetActive(true);

        GameObject newTrash = Instantiate(Items[rand], new Vector3(0f, 2f, 1f), Quaternion.identity);
        newTrash.SetActive(true);
        isThereTrash = true;
    }*/

}

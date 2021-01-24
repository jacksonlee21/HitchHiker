using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TrashSorting : MonoBehaviour
{

    public GameObject[] Items;
    public int Points = 15;
    public bool isThereTrash = true;
    public Text Score;
    


    int rand;
    int oldRand;

    void Start()
    {
        Score.text = "Trash Left to go: 15";
        rand = Random.Range(0, 7);
        GameObject newTrash = Instantiate(Items[rand], new Vector3(0f, 2f, 1f), Items[rand].transform.rotation);
        newTrash.SetActive(true);
        oldRand = rand;
    }

    void Update()
    {
        Score.text = "Trash Left to go: " + Points;

        if (Points == 0)
        {
            SceneManager.LoadScene("Town1");
        }
        
        else if(!isThereTrash)
        {
            rand = Random.Range(0, 7);
            if(rand != oldRand)
            {
                oldRand = rand;
                Debug.Log(Points);
                GameObject newTrash = Instantiate(Items[rand], new Vector3(0f,2f,1f), Items[rand].transform.rotation);


                //StartCoroutine(Wait());
                isThereTrash = true;
                
            }
        }
    }

}

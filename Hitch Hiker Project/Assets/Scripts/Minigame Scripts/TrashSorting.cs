using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TrashSorting : MonoBehaviour
{

    public GameObject[] Items;
    public int Points = 0;
    public bool isThereTrash = true;
    public Text Score;
    
    float Timer;

    int rand;
    int oldRand;

    void Start()
    {
        rand = Random.Range(0, 7);
        GameObject newTrash = Instantiate(Items[rand], new Vector3(0f, 2f, 1f), Items[rand].transform.rotation);
        newTrash.SetActive(true);
        oldRand = rand;
    }

    void Update()
    {
        Timer += Time.deltaTime;
        Debug.Log(Timer);
        if (Timer > 20)
        {
            PlayerPrefs.SetInt("cMoney", PlayerPrefs.GetInt("cMoney") + 50);
            PlayerPrefs.SetFloat("playerKarma", PlayerPrefs.GetFloat("playerKarma") + .25f);
            SceneManager.LoadScene("Town1");
        }
        Score.text = "Score: " + Points;
        if(!isThereTrash)
        {
            Debug.Log("bye bye old trash hello new");
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

   /* IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        //Items[rand].SetActive(true);

        GameObject newTrash = Instantiate(Items[rand], new Vector3(0f, 2f, 1f), Quaternion.identity);
        newTrash.SetActive(true);
        isThereTrash = true;
    }*/

}

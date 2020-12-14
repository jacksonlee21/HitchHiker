using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Minigame1s : MonoBehaviour
{
    int counter = 0;
    public int limit;
    int direction = 4;
    bool gameFinished = false;
    int objectCounter = 1;
    //public GameObject openChest;
    //public GameObject closedChest;

    public GameObject Chair1;
    public GameObject Chair2;
    public GameObject Chair3;
    public GameObject Chair4;
    public GameObject Chair5;

    float time;
    public AudioSource WinSound;
    bool playSound = false;

    public GameObject win;

    void Update()
    {
        if(gameFinished == false)
        {
            if (Input.GetButtonDown("Space"))
            {
                counter++;
                if (counter % 20 == 0)
                {
                    direction = direction * -1;
                    //Debug.Log("Test");
                    objectCounter++;
                }
                //Debug.Log(direction);
                transform.Rotate(Vector3.back * direction);
            }

            if (objectCounter == 2)
            {
                Chair2.SetActive(true);
                Chair1.SetActive(false);
            }
            if (objectCounter == 3)
            {
                Chair3.SetActive(true);
                Chair2.SetActive(false);
            }
            if (objectCounter == 4)
            {
                Chair4.SetActive(true);
                Chair3.SetActive(false);
            }
            if (objectCounter == 5)
            {
                Chair5.SetActive(true);
                Chair4.SetActive(false);
            }
            Debug.Log(objectCounter);
            //Debug.Log(counter);
        }

        if(counter == limit)
        {
            gameFinished = true;
            //openChest.SetActive(true);
            //closedChest.SetActive(false);
            win.SetActive(true);
            time += Time.deltaTime;
            if(playSound == false)
            {
                WinSound.Play();
                playSound = true;
            }
            if(time > 3)
            {
                PlayerPrefs.SetInt("cMoney", PlayerPrefs.GetInt("cMoney") + 50);
                PlayerPrefs.SetFloat("playerKarma", PlayerPrefs.GetFloat("playerKarma") + .25f);
                SceneManager.LoadScene("Town1");
            }
        }
    }
}

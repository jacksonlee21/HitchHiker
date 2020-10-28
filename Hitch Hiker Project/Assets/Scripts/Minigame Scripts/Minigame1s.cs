using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Minigame1s : MonoBehaviour
{
    int counter = 0;
    public int limit;
    int direction = 3;
    bool gameFinished = false;
    public GameObject openChest;
    public GameObject closedChest;
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
                }
                //Debug.Log(direction);
                transform.Rotate(Vector3.back * direction);

            }
            Debug.Log(counter);
        }

        if(counter == limit)
        {
            gameFinished = true;
            openChest.SetActive(true);
            closedChest.SetActive(false);
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
                PlayerPrefs.SetFloat("playersLastPosition", -9f);
                SceneManager.LoadScene("DialogueSystem");
            }
        }
    }
}

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
    bool MoneySound = false;
    public GameObject openChest;
    public GameObject closedChest;
    float time = 0;
    public AudioSource chaChing;

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
            time += Time.deltaTime;
            if(time > 1 && MoneySound == false)
            {
                chaChing.Play();
                MoneySound = true;
            }
            if(time > 4)
            {
                SceneManager.LoadScene("DialogueSystem");
            }
        }
    }
}

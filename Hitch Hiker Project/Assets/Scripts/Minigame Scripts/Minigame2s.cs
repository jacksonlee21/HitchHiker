using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Minigame2s : MonoBehaviour
{
    public int Sequence;
    public float time;
    public float travelDistance;
    bool thingy = false;

    public GameObject win;
    public GameObject loose;

    public AudioSource Winner;
    public AudioSource Loser;


    public void Awake()
    {
        Sequence = Random.Range(1, 5);
    }


    public void Update()
    {
        time += Time.deltaTime;
        if(time > 7 && thingy == false)
        {
            choose();
            
        }
        if(thingy == true)
        {
            if(time > 4)
            {
                PlayerPrefs.SetFloat("playersLastPosition", 9.25f);
                SceneManager.LoadScene("DialogueSystem");
            }
        }
    }


    public void choose()
    {
        Debug.Log("Pick a Card (1, 2, or 3)");

        if(Sequence == 1)
        {
            if(Input.GetKey("1"))
            {
                correct();
            }
            if(Input.GetKey("2") || Input.GetKey("3"))
            {
                wrong();
            }
        }
        if (Sequence == 2)
        {
            if (Input.GetKey("2"))
            {
                correct();
            }
            if (Input.GetKey("1") || Input.GetKey("3"))
            {
                wrong();
            }
        }
        if (Sequence == 3)
        {
            if (Input.GetKey("3"))
            {
                correct();
            }
            if (Input.GetKey("2") || Input.GetKey("1"))
            {
                wrong();
            }
        }
        if (Sequence == 4)
        {
            if (Input.GetKey("2"))
            {
                correct();
            }
            if (Input.GetKey("1") || Input.GetKey("3"))
            {
                wrong();
            }
        }
    }


    public void correct()
    {
        Debug.Log("You Win");
        thingy = true;
        time = 0;
        win.SetActive(true);
        PlayerPrefs.SetInt("cMoney", PlayerPrefs.GetInt("cMoney") + 50);
        Winner.Play();
    }


    public void wrong()
    {
        Debug.Log("You Lose, Loser");
        thingy = true;
        time = 0;
        loose.SetActive(true);
        Loser.Play();
    }
}

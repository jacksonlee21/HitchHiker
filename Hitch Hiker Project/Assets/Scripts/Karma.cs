using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Karma : MonoBehaviour
{
    public float Karmalevel;
    public float tips;

    public float dailyLuck;
    float lowPoint;
    float highPoint;

    private void Update()
    {
        //Karmalevel = PlayerPrefs.GetFloat("playerKarma");

        if (Karmalevel > 10)
        {
            PlayerPrefs.SetFloat("playerKarma", 10);
        }
        if (Karmalevel < -10f)
        {
            PlayerPrefs.SetFloat("playerKarma", -10f);
        }

        //if you have good enough karma, the towns people will give you tips on certain jobs
        TipJar();

        //when you reach a new checkpoint in the karma system a little message will play to let the player know
        SelfEsteem();

        if(Input.GetKeyDown("k"))
        {
            luckLevel();
        }

    }

    void TipJar()
    {
        if (Karmalevel >= 2.5f)
        {
            tips = Mathf.Round((1 + (Karmalevel / 15)) * 100) / 100;
            //this divides your karma level by 15, adds 1, and rounds it to the second decimal, giving you a 1.xx number you can multiply the base wage from working by.
        }
        else
        {
            tips = 1;
        }
    }

    void SelfEsteem()
    {
        GameObject dialogueManager = GameObject.Find("dialogueManager");
        Dialogue dialogueScript = dialogueManager.GetComponent<Dialogue>();

        //Good Karma
        if (Karmalevel > 7.5f && PlayerPrefs.GetFloat("KarmaCheckpoint") != 3)
        {
            //dialogueScript.NewText(new string[] { "You are a good person" }, false, new string[] {"", ""});
            PlayerPrefs.SetFloat("KarmaCheckpoint", 3);
            Debug.Log("Good 3");
        }
        else if (Karmalevel >= 5 && PlayerPrefs.GetFloat("KarmaCheckpoint") != 2)
        {
            //dialogueScript.NewText(new string[] { "You feel good" });
            Debug.Log("Good 2");
            PlayerPrefs.SetFloat("KarmaCheckpoint", 2);
        }
        else if (Karmalevel > 2.5f && PlayerPrefs.GetFloat("KarmaCheckpoint") != 1)
        {
            //dialogueScript.NewText(new string[] { "You feel a spring in your step" });
            Debug.Log("Good 1");
            PlayerPrefs.SetFloat("KarmaCheckpoint", 1);
        }

        //Bad Karma
        if (Karmalevel < -2.5f && PlayerPrefs.GetFloat("KarmaCheckpoint") != -1f)
        {
            //dialogueScript.NewText(new string[] { "You feel the weight of your mistakes" });
            PlayerPrefs.SetFloat("KarmaCheckpoint", -1f);
        }
        if (Karmalevel < -5f && PlayerPrefs.GetFloat("KarmaCheckpoint") != -2f)
        {
            //dialogueScript.NewText(new string[] { "You feel like garbage" });
            PlayerPrefs.SetFloat("KarmaCheckpoint", -2f);
        }
        if (Karmalevel < -7.5f && PlayerPrefs.GetFloat("KarmaCheckpoint") != -3f)
        {
            //dialogueScript.NewText(new string[] { "You are garbage" });
            PlayerPrefs.SetFloat("KarmaCheckpoint", -3f);
        }
    }

    void luckLevel()
    {
        if(Karmalevel != 0)
        {
            lowPoint = (Karmalevel + 10) - (4 / Mathf.Abs(Karmalevel));
            highPoint = (Karmalevel + 10) + (4 / Mathf.Abs(Karmalevel));
        }
        if(Karmalevel == 0)
        {
            lowPoint = (Karmalevel + 10) - 4;
            highPoint = (Karmalevel + 10) + 4;
        }
        dailyLuck = Random.Range(lowPoint, highPoint);
        dailyLuck = dailyLuck - 10;
        Debug.Log(dailyLuck);
    }

    void JobComplete()
    {
        PlayerPrefs.SetFloat("playerKarma", PlayerPrefs.GetFloat("playerKarma") + .25f);
    }

}

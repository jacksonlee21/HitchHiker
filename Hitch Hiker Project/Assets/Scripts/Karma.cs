using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Karma : MonoBehaviour
{
    public float Karmalevel;
    public float tips;

    private void Update()
    {
        Karmalevel = PlayerPrefs.GetFloat("playerKarma");

        if (PlayerPrefs.GetFloat("playerKarma") > 10)
        {
            PlayerPrefs.SetFloat("playerKarma", 10);
        }
        if (PlayerPrefs.GetFloat("playerKarma") < -10f)
        {
            PlayerPrefs.SetFloat("playerKarma", -10f);
        }

        //if you have good enough karma, the towns people will give you tips on certain jobs
        TipJar();

        //when you reach a new checkpoint in the karma system a little message will play to let the player know
        SelfEsteem();
    }

    void TipJar()
    {
        if (PlayerPrefs.GetFloat("playerKarma") > 2.5f)
        {
            tips = Mathf.Round((1 + (PlayerPrefs.GetFloat("playerKarma") / 15)) * 100) / 100;
            //this divides your karma level by 15, adds 1, and rounds it to the second decimal, giving you a 1.xx number you can multiply the base wage from working by.
        }
    }

    void SelfEsteem()
    {
        //Good Karma
        if(PlayerPrefs.GetFloat("playerKarma") > 7.5f && PlayerPrefs.GetFloat("KarmaCheckpoint") != 3)
        {
            //You are good
            PlayerPrefs.SetFloat("KarmaCheckpoint", 3);
        }
        if (PlayerPrefs.GetFloat("playerKarma") > 5 && PlayerPrefs.GetFloat("KarmaCheckpoint") != 2)
        {
            //You feel good
            PlayerPrefs.SetFloat("KarmaCheckpoint", 2);
        }
        if (PlayerPrefs.GetFloat("playerKarma") > 2.5f && PlayerPrefs.GetFloat("KarmaCheckpoint") != 1)
        {
            //You feel a spring in your step
            PlayerPrefs.SetFloat("KarmaCheckpoint", 1);
        }

        //Bad Karma
        if (PlayerPrefs.GetFloat("playerKarma") < -2.5f && PlayerPrefs.GetFloat("KarmaCheckpoint") != -1f)
        {
            //You feel the weight of your mistakes
            PlayerPrefs.SetFloat("KarmaCheckpoint", -1f);
        }
        if (PlayerPrefs.GetFloat("playerKarma") < -5f && PlayerPrefs.GetFloat("KarmaCheckpoint") != -2f)
        {
            //You feel like garbage
            PlayerPrefs.SetFloat("KarmaCheckpoint", -2f);
        }
        if (PlayerPrefs.GetFloat("playerKarma") < -7.5f && PlayerPrefs.GetFloat("KarmaCheckpoint") != -3f)
        {
            //You are garbage
            PlayerPrefs.SetFloat("KarmaCheckpoint", -3f);
        }
    }

    void JobComplete()
    {
        PlayerPrefs.SetFloat("playerKarma", PlayerPrefs.GetFloat("playerKarma") + .25f);
    }

}

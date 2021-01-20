using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    public Image blackFade;
    public GameObject Fade;
    bool buttonpress;
    public float fadePace = 0;

   
    public void GotoMainScene()
    {
        PlayerPrefs.DeleteAll();
        Fade.SetActive(true);
        buttonpress = true;
    }

    public void GotoMenuScene()
    {
        SceneManager.LoadScene("NewMenu");
    }

    private void Update()
    {
        if(buttonpress == true)
        {
            fadePace = fadePace + .0025f;
            blackFade.color = new Color(blackFade.color.r, blackFade.color.g, blackFade.color.b, fadePace);
            if(fadePace > 1.5)
            {
                SceneManager.LoadScene("Town1");
            }
        }
    }





}

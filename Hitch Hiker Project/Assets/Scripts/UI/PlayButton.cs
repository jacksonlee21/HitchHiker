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
    bool text1 = false;
    bool text2 = false;
    public GameObject dialogueText;

    private void Start()
    {
        dialogueText.SetActive(false);
    }
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

        GameObject dialogueManager = GameObject.Find("dialogueManager");
        Dialogue dialogueScript = dialogueManager.GetComponent<Dialogue>();

        if (buttonpress == true)
        {
            fadePace = fadePace + .0025f;
            blackFade.color = new Color(blackFade.color.r, blackFade.color.g, blackFade.color.b, fadePace);

            if(!text1)
            {
                if(fadePace > 1.25f)
                {
                    dialogueText.SetActive(true);
                    dialogueScript.NewText(new string[] { " Wake up!" }, false, null, null);
                    dialogueScript.Continue();

;
                    text1 = true;
                }
            }

            if (!text2)
            {
                if (fadePace > 2f)
                {
                    dialogueScript.NewText(new string[] { " Wake up!" }, false, null, null);
                    dialogueScript.Continue();
                    
                    text2 = true;
                }
            }

            if (fadePace > 2.75f)
            {
                dialogueText.SetActive(false);
                SceneManager.LoadScene("Town1");
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public TextMeshProUGUI yes;
    public TextMeshProUGUI no;

    public string[] sentences;
    private int index;
    public float typingSpeed;
    bool isYes = false;
    public bool ifDone;
    public bool yesOrNo;
   

    public GameObject continueButton;
    public GameObject yesButton;
    public GameObject noButton;

    void Start()
    {
        ifDone = true;

        if (!PlayerPrefs.HasKey("isFirstTime"))
        {
            PlayerPrefs.SetString("isFirstTime", "yes");
            NewText(new string[] { "test1", "test2" }, false, new string[] { "No", "Yes" });
            ifDone = false;
        }

    }
    
    public IEnumerator Type()
    {
        setFalse();

        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        whichButtons();
    }

    public void NextSentence()
    {
        setFalse();

        if (index < sentences.Length - 1)
        {
            ifDone = false;
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
            
            Debug.Log(index);
        }
        else
        {
            textDisplay.text = "";
            setFalse();
            ifDone = true;
        }
    }

    public void NewText(string[] newString, bool _yesOrNo, string[] choicesString)
    {
        yes.text = choicesString[1];
        no.text = choicesString[0];
        yesOrNo = _yesOrNo;
        whichButtons();
        index = 0;
        ifDone = false;
        //Debug.Log("should do text");
        textDisplay.text = "";
        sentences = newString;
        StartCoroutine(Type());
    }

    public void whichButtons()
    {
        if(sentences.Length - index > 1)
        {
            continueButton.SetActive(true);
            yesButton.SetActive(false);
            noButton.SetActive(false);
        }
        else
        {
            if(yesOrNo)
            {
                yesButton.SetActive(true);
                noButton.SetActive(true);
                continueButton.SetActive(false);
            }
            else
            {
                yesButton.SetActive(false);
                noButton.SetActive(false);
                continueButton.SetActive(true);
            }
        }
    }

    public void Yes()
    {
        Debug.Log("yes yes yes");
    }
    
    public void setFalse()
    {
        continueButton.SetActive(false);
        yesButton.SetActive(false);
        noButton.SetActive(false);
    }
}

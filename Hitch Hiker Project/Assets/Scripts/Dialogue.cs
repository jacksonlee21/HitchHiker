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
    public string[] _answerString;
    private int index;
    public float typingSpeed;
    bool isYes = false;
    public bool ifDone;
    public bool yesOrNo;
    public string Decision = "undecided";
   

    public GameObject continueButton;
    public GameObject yesButton;
    public GameObject noButton;

    void Start()
    {
        ifDone = true;

        if (!PlayerPrefs.HasKey("isFirstTime"))
        {
            PlayerPrefs.SetString("isFirstTime", "yes");
            NewText(new string[] { "test1", "test2" }, false, new string[] { "No", "Yes" }, new string[] { "okay", "aight" });
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

    public void NewText(string[] sentencesString, bool _yesOrNo, string[] choicesString, string[] answerString)
    {
        yesOrNo = _yesOrNo;

        if(_yesOrNo)
        {
            yes.text = choicesString[1];
            no.text = choicesString[0];
            _answerString = answerString;
        }

        whichButtons();
        index = 0;
        ifDone = false;
        //Debug.Log("should do text");
        textDisplay.text = "";
        sentences = sentencesString;
        
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
        GameObject Player = GameObject.Find("Main Character");
        EnterHouse EnterHouseScript = Player.GetComponent<EnterHouse>();

        if (EnterHouseScript.enterHouse)
        {
            EnterHouseScript.EnteringHouse();
        }

         sentences = new string[0];

         NewText(new string[] { _answerString[1] }, false, new string[] { " " }, new string[] { " " });
      
    }

    public void No()
    {
        sentences = new string[0];
        NewText(new string[] { _answerString[0] }, false, new string[] { " " }, new string[] { " " });

    }

    public void Continue()
    {
        NextSentence();

    }

    public void setFalse()
    {
        continueButton.SetActive(false);
        yesButton.SetActive(false);
        noButton.SetActive(false);
        
    }
}

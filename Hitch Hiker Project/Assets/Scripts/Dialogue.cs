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
    public TextMeshProUGUI continueText;

    public string[] sentences;
    public string[] _answerString;
    private int index = 0;
    public float typingSpeed;
    public bool ifDone;
    public bool yesOrNo;
   
    public GameObject continueButton;
    public GameObject yesButton;
    public GameObject noButton;

    void Start()
    {
        ifDone = true;
    }

    public void Continue()
    {
        NextSentence();
    }

    public void NextSentence()
    {
        setFalse();
        textDisplay.text = "";

        if (index <sentences.Length)
        {
            ifDone = false;
            StartCoroutine(Type());
            whichButtons();
            index++;
        }
        else
        {
            ifDone = true;
        }
    }

    public IEnumerator Type()
    {

        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        
    }

    public void whichButtons()
    {
        if (sentences.Length - index > 1)
        {
            continueButton.SetActive(true);
            yesButton.SetActive(false);
            noButton.SetActive(false);
        }
        else
        {
            if (yesOrNo)
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

    public void NewText(string[] sentencesString, bool _yesOrNo, string[] choicesString, string[] answerString)
    {
        yesOrNo = _yesOrNo;

        if(_yesOrNo)
        {
            yes.text = choicesString[1];
            no.text = choicesString[0];
            _answerString = answerString;
        }
        
        index = 0;
        ifDone = false;
        sentences = sentencesString;
        NextSentence();
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

    public void setFalse()
    {
        continueButton.SetActive(false);
        yesButton.SetActive(false);
        noButton.SetActive(false);
        
    }
}

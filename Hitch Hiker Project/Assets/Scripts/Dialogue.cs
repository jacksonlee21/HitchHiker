using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public TextMeshProUGUI speakerName;
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
        ifDone = false;
    }

    public void Continue()
    {
        NextSentence();
    }

    public void NextSentence()
    {
        setFalse();
        textDisplay.text = "";
        speakerName.text = "";

        if (index < sentences.Length)
        {
            ifDone = false;
            StartCoroutine(Type());

            index++;
        }
        else
        {
            ifDone = true;
            CameraZoom.ZoomOut();
            CameraZoom.ResetCamera();
        }
    }

    public IEnumerator Type()
    {
        string speaker, sentence;
        if (sentences[index].Contains(":"))
        {
            string[] sentenceAndName = SplitString(sentences[index]);

            speaker = sentenceAndName[0];
            sentence = sentenceAndName[1];
        }
        else
        {
            speaker = "No name";
            sentence = sentences[index];
        }

        speakerName.text = speaker + ":";

        foreach (char letter in sentence.ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        whichButtons();
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
        CameraZoom.ZoomIn();
        NextSentence();
    }

    private string[] SplitString(string fullSentence)
    {
        string[] sentenceAndName = fullSentence.Split(':');

        return sentenceAndName;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    bool isYes = false;
    public bool ifDone;
   

    public GameObject continueButton;

    void Start()
    {
        ifDone = true;

        if (!PlayerPrefs.HasKey("isFirstTime"))
        {
            PlayerPrefs.SetString("isFirstTime", "yes");
            NewText(new string[] { "test1", "test2" });
            ifDone = false;
        }

    }
    
    public IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        continueButton.SetActive(true);
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);

        if(index < sentences.Length - 1)
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
            continueButton.SetActive(false);
            ifDone = true;
        }
    }

    public void NewText(string[] newString)
    {
        continueButton.SetActive(true);
        index = 0;
        ifDone = false;
        Debug.Log("should do text");
        textDisplay.text = "";
        sentences = newString;
        //dialogueScript.Type();
        StartCoroutine(Type());
    }

    
}

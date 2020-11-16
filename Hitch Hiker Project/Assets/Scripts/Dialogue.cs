﻿using System.Collections;
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

    public bool textG;
   
    

    public GameObject continueButton;

    void Start()
    {
        isYes = false;

        textG = true;
        
        if (!PlayerPrefs.HasKey("isFirstTime"))
        {
            PlayerPrefs.SetString("isFirstTime", "yes");
        }
            
        if(PlayerPrefs.GetString("isFirstTime") == "yes")
        {
            StartCoroutine(Type());
            isYes = true;
        }

       
    }

    private void Update()
    {
        if(textDisplay.text == sentences[index] && isYes)
        {
            continueButton.SetActive(true);
        }

        if (index == sentences.Length - 1)
        {
            PlayerPrefs.SetString("isFirstTime", "no");
            Debug.Log("wooohaohfoahohe");
            
        }
    }

    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);

        if(index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
            Debug.Log(index);
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
            textG = false;
        }
    }

    
}

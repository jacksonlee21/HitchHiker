using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCDialogue : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    [HideInInspector]
    public int index;
    public float typingSpeed;

    [HideInInspector] public bool doneWithDialogue = false;

    public GameObject continueButton;

    private void Awake()
    {
        StartCoroutine(Type());
    }

    private void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
            Debug.Log(index);
        }
        else if (index == sentences.Length - 1)
        {
            continueButton.SetActive(false);
            textDisplay.text = "";
            doneWithDialogue = true;
        }
    }
}
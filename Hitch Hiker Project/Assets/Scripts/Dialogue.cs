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
    public bool canMove = false;
   
    

    public GameObject continueButton;

    void Start()
    {
        sentences = new string[] {"test", "test2"};
 

        isYes = false;
        
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
            //Debug.Log("wooohaohfoahohe");
            //canMove = true;
            
        }

        if(index < sentences.Length - 1 && PlayerPrefs.GetString("isFirstTime") == "yes")
        {
            canMove = false;
        }
        else
        {
            canMove = true;
            //Debug.Log(index);
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
        }
    }

    
}

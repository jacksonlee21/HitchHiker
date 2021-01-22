using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FadeManager : MonoBehaviour
{
    public GameObject panelObject;
    public Animator panelAnimator;
    
    private void Awake()
    {
        if(!PlayerPrefs.HasKey("gameStarted"))
        {
            PlayerPrefs.SetInt("gameStarted", 1);
            panelAnimator.SetTrigger("startFade");
        }
        else
        {
            panelObject.SetActive(false);
        }
    }
}

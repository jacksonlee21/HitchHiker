using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void GotoMainScene()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("TownLayout");
        
    }

    public void GotoMenuScene()
    {
        SceneManager.LoadScene("NewMenu");
    }
}

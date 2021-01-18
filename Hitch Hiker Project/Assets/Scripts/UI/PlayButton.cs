using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void GotoMainScene()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Town1");
        
    }

    public void GotoMenuScene()
    {
        SceneManager.LoadScene("NewMenu");
    }
}

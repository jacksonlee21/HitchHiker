using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void GotoMainScene()
    {
        SceneManager.LoadScene("Town1");
        PlayerPrefs.DeleteAll();
    }

    public void GotoMenuScene()
    {
        SceneManager.LoadScene("Main Menu");
    }
}

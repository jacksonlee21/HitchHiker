using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void GotoMainScene()
    {
        SceneManager.LoadScene("DialogueSystem");
    }

    public void GotoMenuScene()
    {
        SceneManager.LoadScene("Main Menu");
    }
}

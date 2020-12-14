using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPicking : MonoBehaviour
{
    public GameObject Key;
    public GameObject StartButton;
    public GameObject ClosedChest;
    public bool Hidden = true;

    private void OnMouseEnter()
    {
        Debug.Log("Lose");
        Hidden = false;
    }

    private void OnMouseExit()
    {
        Debug.Log("Lose");
        Hidden = false;
    }

    public void ButtonPress()
    {
        Key.SetActive(true);
        StartButton.SetActive(false);
    }

}

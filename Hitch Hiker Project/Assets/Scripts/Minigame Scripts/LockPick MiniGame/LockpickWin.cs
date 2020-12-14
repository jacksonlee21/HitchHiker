using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockpickWin : MonoBehaviour
{
    public GameObject ClosedChest;
    public GameObject OpenChest;
    public AudioSource Winner;

    private void OnMouseEnter()
    {
        if(GetComponentInParent<LockPicking>().Hidden == true)
        {
            ClosedChest.SetActive(false);
            OpenChest.SetActive(true);
            Winner.Play();
        } 
    }
}

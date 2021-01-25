using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weeding : MonoBehaviour
{
    private void Awake()
    {
        if (PlayerPrefsX.GetBool("DandelionsWeeded") == true)
        {
            gameObject.SetActive(false);
        }
    }
}

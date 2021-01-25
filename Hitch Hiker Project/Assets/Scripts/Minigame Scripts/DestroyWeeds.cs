using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DestroyWeeds : MonoBehaviour
{
    int weeds;
    float t;
    public AudioSource collection;

    private void Update()
    {
        if (weeds == 22)
        {
            t += Time.deltaTime;
            if (t > 1.5)
            {
                PlayerPrefsX.SetBool(("DandelionsWeeded"), true);
                SceneManager.LoadScene("Town1");
            }
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        Destroy(col.gameObject);
        weeds++;
        collection.Play();
    }
}

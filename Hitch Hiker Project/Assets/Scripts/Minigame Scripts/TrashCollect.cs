using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrashCollect : MonoBehaviour
{
    int trash;
    float t;
    public AudioSource collection;

    private void Update()
    {
        if(trash == 17)
        {
            t += Time.deltaTime;
            if(t > 1.5)
            {
                SceneManager.LoadScene("TrashSortingGame");
            }
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        Destroy(col.gameObject);
        trash++;
        collection.Play();
    }
}

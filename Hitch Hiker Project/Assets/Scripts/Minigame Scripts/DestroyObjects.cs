using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    public AudioSource Sort;
    void Start()
    {
        GameObject TrashSortingManager = GameObject.Find("TrashSortingManager");
        TrashSorting trashSortingScript = TrashSortingManager.GetComponent<TrashSorting>();
    }


    void OnTriggerStay2D (Collider2D col)
    {
        Debug.Log("Collision Detected");
        GameObject TrashSortingManager = GameObject.Find("TrashSortingManager");
        TrashSorting trashSortingScript = TrashSortingManager.GetComponent<TrashSorting>();

        if(col.tag == "Trash" && col.transform.position.x < 0f)
        {
            //you won good job, add to points by one. *Ding sound
            trashSortingScript.Points--;
            col.gameObject.transform.position = new Vector2(0f, 2f);
            Destroy(col.gameObject);

            Sort.Play();

            trashSortingScript.isThereTrash = false;
        }
        /*if (col.tag == "Trash" && col.transform.position.x > 0f)
        {
            //this is failure
            trashSortingScript.Points--;
        }*/
        if (col.tag == "Recycle" && col.transform.position.x > 0f)
        {
            //you won good job, add to points by one. *Ding sound
            trashSortingScript.Points--;
            col.gameObject.transform.position = new Vector2(0f, 2f);
            Destroy(col.gameObject);

            Sort.Play();

            trashSortingScript.isThereTrash = false;
        }
        /*if (col.tag == "Recycle" && col.transform.position.x < 0f)
        {
            //this is failure
            trashSortingScript.Points--;
        }*/

        

    }

}

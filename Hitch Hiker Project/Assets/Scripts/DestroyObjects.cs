﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour
{

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
            trashSortingScript.Points++;
        }
        if (col.tag == "Trash" && col.transform.position.x > 0f)
        {
            trashSortingScript.Points--;
        }
        if (col.tag == "Recycle" && col.transform.position.x > 0f)
        {
            trashSortingScript.Points++;
        }
        if (col.tag == "Recycle" && col.transform.position.x < 0f)
        {
            trashSortingScript.Points--;
        }

        Destroy(col.gameObject);
        col.gameObject.transform.position = new Vector2(0f, 2f);
        Debug.Log("destroy please");

        trashSortingScript.isThereTrash = false;

        /*if (Input.GetMouseButton(0) && trashSortingScript.isThereTrash)
        {
            //col.gameObject.SetActive(false);
            Destroy(col.gameObject);
            col.gameObject.transform.position = new Vector2(0f, 2f);
            Debug.Log("destroy please");

            
            trashSortingScript.isThereTrash = false;
        }*/

    }

}

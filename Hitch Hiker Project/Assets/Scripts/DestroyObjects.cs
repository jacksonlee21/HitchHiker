using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        GameObject TrashSortingManager = GameObject.Find("TrashSortingManager");
        TrashSorting trashSortingScript = TrashSortingManager.GetComponent<TrashSorting>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D (Collider2D col)
    {
        Debug.Log("Collision Detected");
        GameObject TrashSortingManager = GameObject.Find("TrashSortingManager");
        TrashSorting trashSortingScript = TrashSortingManager.GetComponent<TrashSorting>();

        if (Input.GetMouseButton(0) && trashSortingScript.isThereTrash)
        {
            //col.gameObject.SetActive(false);
            Destroy(col.gameObject);
            col.gameObject.transform.position = new Vector2(0f, 2f);
            Debug.Log("destroy please");

            
            trashSortingScript.isThereTrash = false;
        }

    }

}

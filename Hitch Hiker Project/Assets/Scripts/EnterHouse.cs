using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterHouse : MonoBehaviour
{
    private bool atDoor;
    private string houseName;
    private ArrowManager arrowManager;

    private void Start()
    {
        arrowManager = GameObject.FindGameObjectWithTag("ArrowManager").GetComponent<ArrowManager>();
        atDoor = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (atDoor)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                SceneManager.LoadScene(houseName);
                arrowManager.CheckArrow(collision.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnterBuilding"))
        {
            atDoor = true;
            houseName = collision.transform.parent.GetComponent<Transform>().tag;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("EnterBuilding"))
        {
            atDoor = false;
            houseName = "No Tag";
        }
    }
}

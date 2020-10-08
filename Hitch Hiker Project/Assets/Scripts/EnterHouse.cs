using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterHouse : MonoBehaviour
{
    private bool atDoor;
    private string houseName;

    private void Start()
    {
        atDoor = false;
    }

    private void Update()
    {
        if (atDoor)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                SceneManager.LoadScene(houseName);
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

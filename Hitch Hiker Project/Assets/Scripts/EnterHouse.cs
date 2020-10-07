using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Debug.Log(houseName);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnterBuilding"))
        {
            Debug.Log("blah");
            atDoor = true;
            houseName = collision.GetComponentInParent<Transform>().tag;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("EnterBuilding"))
        {
            atDoor = false;
        }
    }
}

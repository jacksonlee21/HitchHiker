using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAndDrag : MonoBehaviour
{

    private float startPosX;
    private float startPosY;
    private bool isBeingHeld = false;

    // Update is called once per frame
    void Update()
    {
        if (isBeingHeld)
        {
            Vector3 mousePos;
            //make and set mouse position to its position on screen
            mousePos = Input.mousePosition;

            //convert the screen mouse position to in game position
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0);
        }
    }


    private void OnMouseDown()
    {
        if (Input.GetMouseButton(0))
        {

            Vector3 mousePos;
            //make and set mouse position to its position on screen
            mousePos = Input.mousePosition;

            //convert the screen mouse position to in game position
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);


            //calculates the difference between the middle of the object and where you click so mouse stays where you click
            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            isBeingHeld = true;
        }
    }

    private void OnMouseUp()
    {
        isBeingHeld = false;
    }

}

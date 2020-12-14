using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCurser : MonoBehaviour
{
    private Vector2 MousePos;

    private void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        MousePos = Input.mousePosition;
        MousePos = Camera.main.ScreenToWorldPoint(MousePos);
        transform.position = MousePos;
    }
}

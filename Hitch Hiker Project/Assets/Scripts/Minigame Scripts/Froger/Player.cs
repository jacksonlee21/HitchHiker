using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Player : MonoBehaviour
{
    public Sprite playerUp, playerDown, playerLeft, playerRight;
 
    private Vector2 originalPosition;
 
    public Transform circlePos;
 
    bool onLog= false;
    bool onWater = false;
 
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.localPosition;
    }
 
    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
    }
 
    private void UpdatePosition()
    {
        Vector2 pos = transform.localPosition;
 
        if (Input.GetKeyDown(KeyCode.W))
        {
            GetComponent<SpriteRenderer>().sprite = playerUp;
 
            pos += Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            GetComponent<SpriteRenderer>().sprite = playerDown;
 
            if(pos.y > -11){pos += Vector2.down;}
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            GetComponent<SpriteRenderer>().sprite = playerRight;
 
            if(pos.x < 10){pos += Vector2.right;}
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            GetComponent<SpriteRenderer>().sprite = playerLeft;
 
            if(pos.x > -10){pos += Vector2.left;}
        }
 
        transform.localPosition = pos;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("bumbum");
        
        /*if(other.gameObject.tag == "log")
        {
            onLog = true;
        }
        else if(other.gameObject.tag == "killerObject")
        {
            if(!onLog){transform.localPosition = originalPosition;}
        }
        else if(other.gameObject.tag == "winObject")
        {
 
        }*/
    }
 
    void circleCheck()
    {
        Collider2D[] tempCols;
        tempCols = Physics2D.OverlapCircleAll(circlePos.position,.3f);
        foreach(Collider2D col in tempCols)
        {
            if(col.tag == "log"){onLog = true;}
            if(col.tag == "killerObject"){}
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Sprite playerUp, playerDown, playerLeft, playerRight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
        checkCollisions();
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

    private void checkCollisions ()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("CollidableObject");

        foreach (GameObject go in gameObjects)
        {
            ColidableObject colidableObject = go.GetComponent<ColidableObject>();

            if (colidableObject.IsColliding(this.gameObject))
            {
                if (colidableObject.isSafe)
                {
                    Debug.Log("SAFE");
                }
                else
                {
                    Debug.Log("SAFE");
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColidableObject : MonoBehaviour
{
    public bool isSafe;

    Rect playerRect;
    Vector2 playerSize;
    Vector2 playerPosition;

    Rect colidableObjectRect;
    Vector2 colidableObjectSize;
    Vector2 colidableObjectPosition;
    public bool IsColliding (GameObject playerGameObject)
    {
        playerSize = playerGameObject.transform.GetComponent<SpriteRenderer>().size;
        playerPosition = playerGameObject.transform.localPosition;
        
        colidableObjectSize = GetComponent<SpriteRenderer>().size;
        colidableObjectPosition = transform.localPosition;

        playerRect = new Rect(playerPosition.x - playerSize.x / 2, playerPosition.y - playerSize.y / 2,playerSize.x,playerSize.y);

        colidableObjectRect = new Rect(colidableObjectPosition.x - colidableObjectSize.x / 2,colidableObjectPosition.x - colidableObjectSize.y / 2,colidableObjectSize.x,colidableObjectSize.y);

        if(colidableObjectRect.Overlaps(playerRect,true))
        {
            return true;
        }

        return false;
    }
}

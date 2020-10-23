using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dish : MonoBehaviour
{
    public Sprite[] dishSprites;
    private SpriteRenderer sr;
    [HideInInspector]
    public bool isClean;
    private bool inPos;
    [HideInInspector]
    public int cleanCounter;
    // Start is called before the first frame update
    void Start()
    {
        isClean = false;
        inPos = false;
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!inPos)
        {
            transform.position = Vector2.MoveTowards(transform.position, Vector2.zero, .5f);
            inPos = transform.position == Vector3.zero;
        }
        else
        {
            sr.sprite = dishSprites[cleanCounter];
        }
    }

    public void MoveOutOfScene()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(15,0), .75f);
    }
}

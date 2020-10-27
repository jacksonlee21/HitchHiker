using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spatula : MonoBehaviour
{
    public Sprite[] spatulaSprites;
    private SpriteRenderer sr;
    [HideInInspector]
    public bool down;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        Cursor.visible = false;
        down = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpriteChange();
        }
        if (Input.GetMouseButtonUp(0))
        {
            SpriteChange();
        }
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10);
    }

    private void SpriteChange()
    {
        down = !down;
        sr.sprite = spatulaSprites[down ? 1 : 0];
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Bug"))
        {
            if (Input.GetMouseButtonDown(0))
            {
                BugMovement bug = collision.GetComponent<BugMovement>();
                bug.Squashed();
            }
        }
    }
}

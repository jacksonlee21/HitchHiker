using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spatula : MonoBehaviour
{
    public Sprite[] spatulaSprites;
    public Transform colliderBox;
    public LayerMask layerMask;
    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        SpriteChange(Input.GetMouseButton(0));

        SquashBug(Input.GetMouseButtonDown(0));
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10);
    }

    private void SquashBug(bool down)
    {
        if(down)
            if(Physics2D.OverlapBox(colliderBox.position, new Vector2(1.47f, 1.68f), 0, layerMask))
            {
                Collider2D col = Physics2D.OverlapBox(colliderBox.position, new Vector2(1.47f, 1.68f), 0, layerMask);
                if (col.CompareTag("Bug"))
                {
                    BugMovement bug = col.GetComponent<BugMovement>();
                    bug.GetComponent<Collider2D>().enabled = false;
                    bug.Squashed();
                }
            }
    }

    private void SpriteChange(bool isDown)
    {
        sr.sprite = spatulaSprites[isDown ? 1 : 0];
    }
}

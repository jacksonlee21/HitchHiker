using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugMovement : MonoBehaviour
{
    [SerializeField, Header("Timing")]
    public float MoveTime;
    private float timer;

    [SerializeField, Header("Speed")]
    public float speed;

    [Header("Sprites")]
    public Sprite[] sprites;
    private SpriteRenderer sr;

    private bool isAlive;

    private Vector3 posToGoTo;
    private float xRange, yRange;
    private float xMin, xMax, yMin, yMax;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = sprites[0];

        timer = MoveTime;

        isAlive = true;

        yRange = Camera.main.orthographicSize;
        xRange = yRange * Screen.width / Screen.height;

        yMin = -yRange;
        yMax = yRange;
        xMin = -xRange;
        xMax = xRange;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
            ControlBug();
    }

    private void ControlBug()
    {
        timer += Time.deltaTime;
        if (timer >= MoveTime || transform.position == posToGoTo)
        {
            posToGoTo = GetRandPos();
            timer = 0;
        }

        transform.position = Vector2.MoveTowards(transform.position, posToGoTo, speed * Time.deltaTime);
    }

    private Vector3 GetRandPos()
    {
        float x = Random.Range(xMin, xMax);
        float y = Random.Range(yMin, yMax);
        Vector3 randPos = new Vector2(x, y);

        Vector3 dir = transform.position - randPos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);

        return randPos;
    }

    public void Squashed()
    {
        isAlive = false;
        sr.sprite = sprites[1];
        StartCoroutine(WaitToDestroy());
    }

    IEnumerator WaitToDestroy()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}

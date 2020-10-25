using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugSpawner : MonoBehaviour
{
    private float xRange, yRange;
    private float xMin, xMax, yMin, yMax;

    public float TimeToNextSpawn;
    private float timer;

    public GameObject bugPrefab;

    // Start is called before the first frame update
    void Start()
    {
        yRange = Camera.main.orthographicSize;
        xRange = yRange * Screen.width / Screen.height;

        yMin = -yRange;
        yMax = yRange;
        xMin = -xRange;
        xMax = xRange;

        timer = TimeToNextSpawn;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= TimeToNextSpawn)
        {
            Instantiate(bugPrefab, GetRandPos(), Quaternion.identity);
            timer = 0;
        }
    }

    private Vector3 GetRandPos()
    {
        float x = Random.Range(xMin, xMax);
        float y = Random.Range(yMin, yMax);
        Vector3 randPos = new Vector2(x, y);

        return randPos;
    }
}

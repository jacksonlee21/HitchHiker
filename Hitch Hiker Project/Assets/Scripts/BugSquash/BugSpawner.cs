using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BugSpawner : MonoBehaviour
{
    private float xRange, yRange;
    private float xMin, xMax, yMin, yMax;

    public float TimeToNextSpawn;
    private float SpawnTimer;

    public GameObject bugPrefab;
    private int SquashCount;

    public Slider TimerSlider;
    public Text BugsSquashedText;

    public float TimeToSquash;
    private float SquashTimer;

    // Start is called before the first frame update
    void Start()
    {
        yRange = Camera.main.orthographicSize;
        xRange = yRange * Screen.width / Screen.height;

        yMin = -yRange;
        yMax = yRange;
        xMin = -xRange;
        xMax = xRange;

        SquashCount = 0;

        SpawnTimer = TimeToNextSpawn;
        SquashTimer = 0;
    }
    
    private void Update()
    {
        if(SquashTimer >= TimeToSquash)
        {
            return;
        }
        else
        {
            SquashTimer += Time.deltaTime;
            SpawnTimer += Time.deltaTime;
            if (SpawnTimer >= TimeToNextSpawn)
            {
                Instantiate(bugPrefab, GetRandPos(), Quaternion.identity);
                SpawnTimer = 0;
            }
        }
    }

    private Vector3 GetRandPos()
    {
        float x = Random.Range(xMin, xMax);
        float y = Random.Range(yMin, yMax);
        Vector3 randPos = new Vector2(x, y);

        return randPos;
    }

    public void CountBugs()
    {
        SquashCount++;
        BugsSquashedText.text = "Bugs Squashed: " + SquashCount;
    }
}

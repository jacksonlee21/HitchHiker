using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    float timer;
    bool winSound = false;

    public AudioSource Winner;
    public AudioSource BugSplat;

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
            if(winSound == false)
            {
                Winner.Play();
                winSound = true;
            }
            timer += Time.deltaTime;
            if(timer > 4)
            {
                PlayerPrefs.SetInt("cMoney", PlayerPrefs.GetInt("cMoney") + 50);
                PlayerPrefs.SetFloat("playersLastPosition", -4.35f);
                SceneManager.LoadScene("DialogueSystem");
            }                
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
        BugSplat.Play();
        SquashCount++;
        BugsSquashedText.text = "Bugs Squashed: " + SquashCount;
    }
}

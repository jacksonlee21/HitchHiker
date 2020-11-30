using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarSpawner_PD : MonoBehaviour
{
    public GameObject carPrefab;
    public Transform[] spawnPoints;
    public Text scoreText;

    [SerializeField]
    private float spawnFrequency = 1;
    private float timer = 0;

    [SerializeField, Header("If Off Uses Timer")]
    private bool useCounter;
    private bool useTimer;

    [HideInInspector]
    public bool gameOver;

    private float gameTimer;
    private float carCounter;

    // Start is called before the first frame update
    void Start()
    {
        timer = spawnFrequency;
        gameOver = false;
        gameTimer = 0;
        carCounter = 0;

        SwitchBools();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= spawnFrequency && !gameOver)
        {
            int randSpawnIndex = Random.Range(0, 3);
            Vector3 randSpawnPoint = spawnPoints[randSpawnIndex].position;
            GameObject tempCar = Instantiate(carPrefab, randSpawnPoint, carPrefab.transform.rotation);
            CarMovement_PD tempCarMove = tempCar.GetComponent<CarMovement_PD>();
            tempCarMove.SetCarSpanwerVar(GetComponent<CarSpawner_PD>());
            timer = 0;
        }
        if (!gameOver)
        {
            gameTimer += Time.deltaTime;
            SetText();
        }

        
    }

    private void SetText()
    {
        if(useCounter)
        {
            scoreText.text = carCounter.ToString();
        }
        else if (useTimer)
        {
            scoreText.text = gameTimer.ToString("F2");
        }
    }

    public void CountCar()
    {
        carCounter++;
    }

    private void SwitchBools()
    {
        useTimer = !useCounter;
    }
}

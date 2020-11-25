using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner_PD : MonoBehaviour
{
    public GameObject carPrefab;
    public Transform[] spawnPoints;

    [SerializeField]
    private float spawnFrequency = 1;
    private float timer = 0;

    [HideInInspector]
    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        timer = spawnFrequency;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= spawnFrequency && !gameOver)
        {
            int randSpawnIndex = Random.Range(0, 3);
            Vector3 randSpawnPoint = spawnPoints[randSpawnIndex].position;
            Instantiate(carPrefab, randSpawnPoint, carPrefab.transform.rotation);
            timer = 0;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeedSpawner : MonoBehaviour
{
    
    public GameObject Dandelion;
    private float time = 0f;
    private float totalTime = 0f;
    public float timeBetweenSpawn = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        totalTime += Time.deltaTime;

        if(time >= timeBetweenSpawn)
        {
            time = 0;
            GameObject newDandelion = Instantiate(Dandelion, new Vector3(Random.Range(-8f, 8f), Random.Range(-1.2f, -4f), 1f), Dandelion.transform.rotation);
        }

        if (totalTime > 3)
        {
            timeBetweenSpawn -= .05f;
            totalTime = 0;
        }
    }
}

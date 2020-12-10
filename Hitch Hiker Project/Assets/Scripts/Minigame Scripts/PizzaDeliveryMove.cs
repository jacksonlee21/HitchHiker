using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaDeliveryMove : MonoBehaviour
{
    [SerializeField]
    private CarSpawner_PD carSpawner;
    [SerializeField]
    private GameObject deathEffect;
    [SerializeField]
    private Transform[] movePoints = new Transform[3];

    private int laneIndex = 1;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = movePoints[laneIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            laneIndex--;
            laneIndex = Mathf.Clamp(laneIndex, 0, 2);
            transform.position = movePoints[laneIndex].position;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            laneIndex++;
            laneIndex = Mathf.Clamp(laneIndex, 0, 2);
            transform.position = movePoints[laneIndex].position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            carSpawner.gameOver = true;
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement_PD : MonoBehaviour
{
    private Vector3 endPosition;

    [SerializeField]
    private float speed = 5;

    private CarSpawner_PD carSpawnerVar = null;

    private void Start()
    {
        endPosition = transform.position - new Vector3(0,20,0);
    }

    public void SetCarSpanwerVar(CarSpawner_PD carSpawnerVar)
    {
        this.carSpawnerVar = carSpawnerVar;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
        {
            if(carSpawnerVar != null)
            {
                carSpawnerVar.CountCar();
            }
            Destroy(gameObject);
        }
    }
}

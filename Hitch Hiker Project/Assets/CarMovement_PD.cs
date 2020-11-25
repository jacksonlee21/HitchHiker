using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement_PD : MonoBehaviour
{
    private Vector3 endPosition;

    [SerializeField]
    private float speed = 5;

    private void Start()
    {
        endPosition = transform.position - new Vector3(0,20,0);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
        {
            Destroy(gameObject);
        }
    }
}

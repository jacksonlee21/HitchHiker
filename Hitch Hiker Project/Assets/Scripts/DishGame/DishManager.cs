using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishManager : MonoBehaviour
{
    public GameObject dishPrefab;
    private Dish dish;
    private int DishesCleaned;
    //private Transform dishLocation;

    private Vector3 spawnPos = new Vector3(-15, 0, 0);

    private void Start()
    {
        Cursor.visible = false;
        DishesCleaned = 0;
        CreateDish();
    }

    private void Update()
    {
        if(dish.cleanCounter == 9)
        {
            DishesCleaned++;
            StartCoroutine(GetRidOfDish());
        }
    }

    IEnumerator GetRidOfDish()
    {
        dish.MoveOutOfScene();
        yield return new WaitForSeconds(.3f);
        Destroy(dish.gameObject);
        CreateDish();
    }

    private void CreateDish()
    {
        GameObject dishSpawned = Instantiate(dishPrefab, spawnPos, Quaternion.identity);
        dish = dishSpawned.GetComponent<Dish>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Sponge"))
        {
            dish.cleanCounter++;
            dish.cleanCounter = Mathf.Clamp(dish.cleanCounter, 0, 9);
        }
    }
}

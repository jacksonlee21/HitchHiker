using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DishManager : MonoBehaviour
{
    public GameObject dishPrefab;
    private Dish dish;
    private Vector3 spawnPos = new Vector3(-15, 0, 0);

    private int DishesCleaned;
    public Text scoreText;

    public GameObject win;

    public AudioSource DishDing;

   
    public bool GameOver;

    private void Start()
    {

        Cursor.visible = false;
        GameOver = false;
        DishesCleaned = 0;
        scoreText.text = "Dishes Left to Clean: 10";
        CreateDish();
    }

    private void Update()
    {

        if(DishesCleaned < 10)
        {
            CheckDish();
        }
        else if(DishesCleaned >= 10)
        {
            if (dish != null)
                Destroy(dish.gameObject);

            StartCoroutine(waitAfterWIn());
            SceneManager.LoadScene("Town1");
        }

    }

    public IEnumerator waitAfterWIn()
    {
        yield return new WaitForSeconds(1f);
    }

    private void CheckDish()
    {
        if (dish.cleanCounter == 9)
        {
            if(!dish.isClean)
            {
                DishesCleaned++;
                int numberToGo = 10 - DishesCleaned;
                scoreText.text = "Dishes Left to Clean: " + numberToGo.ToString();
                DishDing.Play();
            }

            dish.isClean = true;

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
        if (collision.CompareTag("Sponge") && dish.inPos)
        {
            dish.cleanCounter++;
            dish.cleanCounter = Mathf.Clamp(dish.cleanCounter, 0, 9);
        }
    }
}

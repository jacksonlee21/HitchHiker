﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DishManager : MonoBehaviour
{
    public GameObject dishPrefab;
    private Dish dish;
    private Vector3 spawnPos = new Vector3(-15, 0, 0);

    private int DishesCleaned;
    public Text scoreText;

    public Slider TimerSlider;
    [SerializeField]
    private float TimeToClean;
    private float timer;

    public DishManager(float timeToClean)
    {
        TimeToClean = timeToClean;
    }

    public bool GameOver;

    private void Start()
    {
        TimerSlider.maxValue = TimeToClean;
        TimerSlider.minValue = 0;
        timer = TimeToClean;

        Cursor.visible = false;
        GameOver = false;
        DishesCleaned = 0;
        scoreText.text = "Dishes Cleaned: " + DishesCleaned.ToString();
        CreateDish();
    }

    private void Update()
    {
        if (!GameOver)
        {
            CheckDish();
            timer -= Time.deltaTime;
            TimerSlider.value = timer;
            if(timer <= 0)
            {
                GameOver = true;
            }
        }
        else
        {
            if (dish != null)
                Destroy(dish.gameObject);
        }
    }

    private void CheckDish()
    {
        if (dish.cleanCounter == 9)
        {
            if (!dish.isClean)
            {
                DishesCleaned++;
                scoreText.text = "Dishes Cleaned: " + DishesCleaned.ToString();
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

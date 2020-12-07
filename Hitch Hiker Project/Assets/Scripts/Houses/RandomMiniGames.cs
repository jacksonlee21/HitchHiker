using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMiniGames : MonoBehaviour
{
    public House[] houses;
    
    public GameObject[] arrows;

    public int arrowsToEnable = 5;
    public bool useAutoScenes;

    public string[] miniGameSceneNames;


    private void Awake()
    {
        if (!PlayerPrefs.HasKey("CreatedTown"))
        {
            PlayerPrefs.SetString("CreatedTown", "No");
        }

        if (PlayerPrefs.GetString("CreatedTown") == "No")
        {
            SetMiniGamesToHouses();
        }

        PlayerPrefs.DeleteKey("CreatedTown");
    }
    // Start is called before the first frame update
    private void Start()
    {
        houses = FindObjectsOfType<House>();

        arrowsToEnable = Mathf.Clamp(arrowsToEnable, 1, houses.Length);

        arrows = GameObject.FindGameObjectsWithTag("EnterBuilding");
        foreach (GameObject arrow in arrows)
        {
            arrow.SetActive(false);
        }

        if (houses.Length > miniGameSceneNames.Length)
        {
            Debug.LogError("Need More Mini Games");
        }
        else
        {
            SetMiniGamesToHouses();
        }

        ChooseRandomArrows();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ChooseRandomArrows();
        }
    }

    public void SetMiniGamesToHouses()
    {
        List<int> randMiniGameIndex = new List<int>();
        for (int i = 0; i < houses.Length; i++)
        {
            int tempIndex = Random.Range(0, houses.Length);
            while (randMiniGameIndex.Contains(tempIndex))
            {
                tempIndex = Random.Range(0, houses.Length);
            }
            randMiniGameIndex.Add(tempIndex);

            houses[i].sceneName = miniGameSceneNames[tempIndex];
            houses[i].name = miniGameSceneNames[tempIndex];
        }

        PlayerPrefs.SetString("CreatedTown", "Yes");
    }

    public void ChooseRandomArrows()
    {
        foreach (GameObject arrow in arrows)
        {
            arrow.SetActive(false);
        }

        List<int> randArrowIndex = new List<int>();
        for (int i = 0; i < arrowsToEnable; i++)
        {
            int tempIndex = Random.Range(0, arrows.Length);
            while (randArrowIndex.Contains(tempIndex))
            {
                tempIndex = Random.Range(0, arrows.Length);
            }
            randArrowIndex.Add(tempIndex);

            arrows[tempIndex].SetActive(true);
        }
    }
}

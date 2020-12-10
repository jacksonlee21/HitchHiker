using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomHouses : MonoBehaviour
{
    public Sprite[] houseSprites;
    public GameObject[] housePrefabs;

    public Transform houseParent;

    public float houseSpawnY = 1.8f, spawnOrigin = -6;
    public int housesToSpawn = 8;

    private House currHouse = null, prevHouse = null;

    private void Start()
    {
        housesToSpawn = Mathf.Clamp(housesToSpawn, 1, housePrefabs.Length);
    }

    public void CreateHouses()
    {
        List<int> randHouseIndex = new List<int>();
        for (int i = 0; i < housesToSpawn; i++)
        {
            int tempIndex = Random.Range(0, housePrefabs.Length);
            while (randHouseIndex.Contains(tempIndex))
            {
                tempIndex = Random.Range(0, housePrefabs.Length);
            }
            randHouseIndex.Add(tempIndex);

            currHouse = housePrefabs[tempIndex].GetComponent<House>();

            Vector2 housePos = GetHouseSpawnPos(currHouse, prevHouse);

            prevHouse = Instantiate(currHouse.gameObject, housePos, Quaternion.identity, houseParent).GetComponent<House>();
        }
    }

    private Vector2 GetHouseSpawnPos(House currH, House prevH)
    {
        Vector2 spawnPos = new Vector2(0, houseSpawnY);

        if(prevH == null)
        {
            spawnPos.x = spawnOrigin;
            return spawnPos;
        }
        
        float prevHousePosX = prevH.transform.position.x;

        if (prevH.houseType == House.HouseType.Large)
        {
            if (currH.houseType == House.HouseType.Small)
            {
                spawnPos.x = prevHousePosX + 4;
            }
            else if (currH.houseType == House.HouseType.Large)
            {
                spawnPos.x = prevHousePosX + 4.5f;
            }
            else Debug.Log("Large, Null");
        }
        else if (prevH.houseType == House.HouseType.Small)
        {
            if (currH.houseType == House.HouseType.Small)
            {
                spawnPos.x = prevHousePosX + 3.5f;
            }
            else if (currH.houseType == House.HouseType.Large)
            {
                spawnPos.x = prevHousePosX + 4.25f;
            }
            else Debug.Log("Small, Null");
        }
        else Debug.Log("Null, Null");

        return spawnPos;
    }
}

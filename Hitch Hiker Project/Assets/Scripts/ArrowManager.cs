using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowManager : MonoBehaviour
{
    public GameObject[] arrows;
    private bool[] arrowActive = new bool[] { false, false, false, false, false };

    public static ArrowManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.FindGameObjectWithTag("EnterBuilding") != null)
            arrows = GameObject.FindGameObjectsWithTag("EnterBuilding");
    }

    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("EnterBuilding") != null)
        {
            int index = 0;
            foreach (GameObject arrow in arrows)
            {
                arrow.SetActive(!arrowActive[index]);
                index++;
            }
        }
    }

    // Update is called once per frame
    public void CheckArrow(GameObject arrowAtPlayer)
    {
        int index = 0;
        foreach (var arrow in arrows)
        {
            if(arrowAtPlayer = arrow)
            {
                arrowActive[index] = true;
            }
            index++;
        }
    }
}

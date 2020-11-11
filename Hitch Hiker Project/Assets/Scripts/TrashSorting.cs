using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSorting : MonoBehaviour
{

    public GameObject[] Items;
    int rand;



    // Start is called before the first frame update
    void Start()
    {
        rand = Random.Range(0, 6);
        Items[rand].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }


}

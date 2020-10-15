using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame2s : MonoBehaviour
{
    public int Sequence;

    public float time;

    public float travelDistance;

    public void Awake()
    {
        Sequence = Random.Range(1, 5);
    }

    public void Update()
    {
        time += Time.deltaTime;
    }
}

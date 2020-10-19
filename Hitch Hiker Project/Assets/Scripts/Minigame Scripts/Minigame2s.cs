using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame2s : MonoBehaviour
{
    public int Sequence;

    public float time;

    public float travelDistance;

    bool thingy = false;

    public void Awake()
    {
        Sequence = Random.Range(1, 5);
    }

    public void Update()
    {
        time += Time.deltaTime;
        if(time > 7 && thingy == false)
        {
            choose();
            
        }
    }

    public void choose()
    {
        Debug.Log("Pick a Card (1, 2, or 3)");

        if(Sequence == 1)
        {
            if(Input.GetKey("1"))
            {
                correct();
            }
            if(Input.GetKey("2") || Input.GetKey("3"))
            {
                wrong();
            }
        }
        if (Sequence == 2)
        {
            if (Input.GetKey("2"))
            {
                correct();
            }
            if (Input.GetKey("1") || Input.GetKey("3"))
            {
                wrong();
            }
        }
        if (Sequence == 3)
        {
            if (Input.GetKey("3"))
            {
                correct();
            }
            if (Input.GetKey("2") || Input.GetKey("1"))
            {
                wrong();
            }
        }
        if (Sequence == 4)
        {
            if (Input.GetKey("2"))
            {
                correct();
            }
            if (Input.GetKey("1") || Input.GetKey("3"))
            {
                wrong();
            }
        }
    }

    public void correct()
    {
        Debug.Log("You Win");
        thingy = true;
    }

    public void wrong()
    {
        Debug.Log("You Lose, Loser");
        thingy = true;
    }
}

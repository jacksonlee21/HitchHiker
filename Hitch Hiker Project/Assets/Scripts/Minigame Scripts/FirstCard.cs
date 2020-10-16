using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstCard : MonoBehaviour
{
    int Sequence;
    float time;

    public void Start()
    {
        Sequence = GetComponentInParent<Minigame2s>().Sequence;
        Debug.Log(Sequence);
    }


    public void FixedUpdate()
    {
        time += Time.deltaTime;
        if (Sequence == 1)
        {
            //ends at 2
            if (time < 3f && time > 2f)
            {
                transform.position += new Vector3(-2 * Time.deltaTime, 0, 0);
            }
            else if (time < 4f && time > 3f)
            {
                transform.position += new Vector3(-2 * Time.deltaTime, 0, 0);
            }
            else if (time < 5f && time > 4f)
            {
                transform.position += new Vector3(0 * Time.deltaTime, 0, 0);
            }
            else if (time < 6f && time > 5f)
            {
                transform.position += new Vector3(2 * Time.deltaTime, 0, 0);
            }
        }
        if (Sequence == 2)
        {
            //ends at 3
            if (time < 3f && time > 2f)
            {
                transform.position += new Vector3(-2 * Time.deltaTime, 0, 0);
            }
            else if (time < 4f && time > 3f)
            {
                transform.position += new Vector3(0 * Time.deltaTime, 0, 0);
            }
            else if (time < 5f && time > 4f)
            {
                transform.position += new Vector3(0 * Time.deltaTime, 0, 0);
            }
            else if (time < 6f && time > 5f)
            {
                transform.position += new Vector3(2 * Time.deltaTime, 0, 0);
            }
        }
        if (Sequence == 3)
        {
            //ends at 1
            if (time < 3f && time > 2f)
            {
                transform.position += new Vector3(-2 * Time.deltaTime, 0, 0);
            }
            else if (time < 4f && time > 3f)
            {
                transform.position += new Vector3(-2 * Time.deltaTime, 0, 0);
            }
            else if (time < 5f && time > 4f)
            {
                transform.position += new Vector3(2 * Time.deltaTime, 0, 0);
            }
            else if (time < 6f && time > 5f)
            {
                transform.position += new Vector3(-2 * Time.deltaTime, 0, 0);
            }
        }
        if (Sequence == 4)
        {
            //ends at 1
            if (time < 3f && time > 2f)
            {
                transform.position += new Vector3(-2 * Time.deltaTime, 0, 0);
            }
            else if (time < 4f && time > 3f)
            {
                transform.position += new Vector3(2 * Time.deltaTime, 0, 0);
            }
            else if (time < 5f && time > 4f)
            {
                transform.position += new Vector3(-2 * Time.deltaTime, 0, 0);
            }
            else if (time < 6f && time > 5f)
            {
                transform.position += new Vector3(-2 * Time.deltaTime, 0, 0);
            }
        }
    }
}

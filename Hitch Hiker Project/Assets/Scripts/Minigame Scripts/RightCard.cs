using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightCard : MonoBehaviour
{
    int Sequence;
    float time;
    Material color;

    public void Start()
    {
        Sequence = GetComponentInParent<Minigame2s>().Sequence;
        color = GetComponent<Renderer>().material;
        Debug.Log(Sequence);
    }


    public void FixedUpdate()
    {
        time += Time.deltaTime;
        if(time < 2)
        {
            if (time < .4f)
            {
                color.color = Color.red;
            }
            else if(time < .8f)
            {
                color.color = Color.green;
            }
            else if (time < 1.2f)
            {
                color.color = Color.red;
            }
            else if (time < 1.6f)
            {
                color.color = Color.green;
            }
            else if (time < 2f)
            {
                color.color = Color.red;
            }
        }



        if (Sequence == 1)
        {
            //ends at 1
            if (time < 3f && time > 2f)
            {
                transform.position += new Vector3(2 * Time.deltaTime, 0, 0);
            }
            else if (time < 4f && time > 3f)
            {
                transform.position += new Vector3(-2 * Time.deltaTime, 0, 0);
            }
            else if (time < 5f && time > 4f)
            {
                transform.position += new Vector3(-2 * Time.deltaTime, 0, 0);
            }
            else if (time < 6f && time > 5f)
            {
                transform.position += new Vector3(0 * Time.deltaTime, 0, 0);
            }
        }
        if (Sequence == 2)
        {
            //ends at 2
            if (time < 3f && time > 2f)
            {
                transform.position += new Vector3(2 * Time.deltaTime, 0, 0);
            }
            else if (time < 4f && time > 3f)
            {
                transform.position += new Vector3(-2 * Time.deltaTime, 0, 0);
            }
            else if (time < 5f && time > 4f)
            {
                transform.position += new Vector3(-2 * Time.deltaTime, 0, 0);
            }
            else if (time < 6f && time > 5f)
            {
                transform.position += new Vector3(2 * Time.deltaTime, 0, 0);
            }
        }
        if (Sequence == 3)
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
                transform.position += new Vector3(2 * Time.deltaTime, 0, 0);
            }
            else if (time < 6f && time > 5f)
            {
                transform.position += new Vector3(2 * Time.deltaTime, 0, 0);
            }
        }
        if (Sequence == 4)
        {
            //ends at 2
            if (time < 3f && time > 2f)
            {
                transform.position += new Vector3(0 * Time.deltaTime, 0, 0);
            }
            else if (time < 4f && time > 3f)
            {
                transform.position += new Vector3(0 * Time.deltaTime, 0, 0);
            }
            else if (time < 5f && time > 4f)
            {
                transform.position += new Vector3(-2 * Time.deltaTime, 0, 0);
            }
            else if (time < 6f && time > 5f)
            {
                transform.position += new Vector3(2 * Time.deltaTime, 0, 0);
            }
        }
    }
}

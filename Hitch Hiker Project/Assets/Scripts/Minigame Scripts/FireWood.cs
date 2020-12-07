using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWood : MonoBehaviour
{
    public GameObject Arrow;
    public GameObject Axe;
    public GameObject Log;
    public GameObject WoodL;
    public GameObject WoodR;

    float direction = 1;
    float speed;
    float Velocity;
    float timer;
    public int Points;

    bool animationTrigger = false;
    float animationCounter = 0;
    float axeDirection = .25f;

    void Start()
    {
        speed = Random.Range(1, 5);
    }

    void Update()
    {
        BarMover();


        timer += Time.deltaTime;
        if(timer > 3)
        {
            speed = Random.Range(2,10);
            timer = 0;
        }
        if(Arrow.transform.position.x > 6.25)
        {
            Arrow.transform.position = new Vector3(6.25f, -3.2f, 0);
            direction = direction * -1;
        }
        if(Arrow.transform.position.x < -6.25)
        {
            Arrow.transform.position = new Vector3(-6.25f, -3.2f, 0);
            direction = direction * -1;
        }
        Velocity = speed * direction;
        

        if(Input.GetButtonDown("Space"))
        {
            Accuracy();
        }


        if(animationTrigger == true)
        {
            Animation();
        }
    }

    void BarMover()
    {
        Arrow.transform.position += new Vector3(Velocity * Time.deltaTime, 0, 0);
    }

    void Accuracy()
    {
        if(Arrow.transform.position.x < .3f && Arrow.transform.position.x > -.3f)
        {
            Points++;
            animationTrigger = true;
            animationCounter = 0;
            Log.SetActive(true);
            WoodL.SetActive(false);
            WoodR.SetActive(false);
        }
    }

    void Animation()
    {
        if (animationCounter < 180)
        {
            Axe.transform.Rotate(new Vector3(0, 0, .5f));
        }
        else if (animationCounter < 360)
        {
            Log.SetActive(false);
            WoodL.SetActive(true);
            WoodR.SetActive(true);
            Axe.transform.Rotate(new Vector3(0, 0, -.5f));
        }
        else
        {
            animationTrigger = false;
        }
        animationCounter++;
    }
}

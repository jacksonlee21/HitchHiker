using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFX : MonoBehaviour
{
    public AudioSource footstep;
    public float time;
    public bool wasWalking;

    void Update()
    {
        
        if (GetComponentInParent<Movement>().walking == true)
        {
            time += Time.deltaTime;
            if (wasWalking == false)
            {
                footstep.Play();
            }
            if(time > 20)
            {
                footstep.Play();
                time = 0;
            }
            wasWalking = true;
        }
        if(GetComponentInParent<Movement>().walking == false)
        {
            footstep.Stop();
            wasWalking = false;
            time = 0;
        }
    }
}

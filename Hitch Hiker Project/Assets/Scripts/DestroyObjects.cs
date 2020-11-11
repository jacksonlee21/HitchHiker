using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D (Collision2D col)
    {
      
        col.gameObject.SetActive(false);
        col.gameObject.transform.position = new Vector2(0f, 2f);
        Debug.Log("destroy please");

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimator : MonoBehaviour
{

    public GameObject Title;
    float newScale = 1;
    bool isOnMenu = true;
    public float scaleAmount = .01f;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Scale());
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public IEnumerator Scale()
    {
        while(isOnMenu)
        {
            for (int i = 0; i <= 10; i++)
            {
                yield return new WaitForSeconds(.05f);
                Title.transform.localScale = new Vector3(Title.transform.localScale.x + scaleAmount , Title.transform.localScale.y + scaleAmount, 1f);
            }
            for (int i = 0; i <= 10; i++)
            {
                yield return new WaitForSeconds(.05f);
                Title.transform.localScale = new Vector3(Title.transform.localScale.x - scaleAmount, Title.transform.localScale.y - scaleAmount, 1f);
            }
        }
       

    }
}

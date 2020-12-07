using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DayNightCycle : MonoBehaviour
{

    public TextMeshProUGUI Clock;
    private float startTime;
    public SpriteRenderer Sky;
    int r = 255;
    int g = 255;
    int b = 255;
    float t = 0;
    string minutes;
    string seconds;
    float rT;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        rT = Mathf.Round(t);

        
        minutes = ((int) t/60).ToString();
        seconds = (t%30).ToString("f0");

        Clock.text = minutes + ":" + seconds;

        /*if(rT%4 == 0)
        {
            r -= (255/12);
            g -= (255/12);
            b -= (255/12);
            //Debug.Log(r);

            Sky.color = new Color(r, g, b, 1f);
        }*/

        if(t> 5)
        {
            r -= (255 / 12);
            g -= (255 / 12);
            b -= (255 / 12);
            //Debug.Log(r);
            Sky.color = new Color(r, g, b, 1f);
            Debug.Log(r);
            t = 0;
        }

        if (t/30 == 24)
        {
            //t=0;
        }
        
    }
}

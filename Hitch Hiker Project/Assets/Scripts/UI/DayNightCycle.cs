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
    float c = 1;
    float t = 0;

    float x;
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

        
        minutes = ((int) t/6).ToString();
        seconds = (t%6).ToString("f0");
        x = (t%6);

        Clock.text = minutes + ":" + seconds + "0";

        if(t/6f > 6)
        {
            if(x > 6)
            c -= 1f / 6f;
            Sky.color = new Color(c,c,c,255f);
            Debug.Log(c);
            x = 0;
        }
        
    }
}

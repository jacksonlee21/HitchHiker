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
    float c = 1f;
    float t = 0;

    float x;
    string minutes;
    string seconds;
    float rT;
    float dayL;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        dayL = 35f;
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime*dayL;

        
        minutes = ((int) t/60).ToString();
        seconds = (t%60).ToString("f0");
        x = (t%60);

        Clock.text = minutes + ":" + seconds;

        if(t/60 > 6)
        {
            if(x > 30f)
            {
                c -= 1f / 60f;
                Vector4 CC = new Vector4 (c,c,c,255f);
                Sky.color = CC;
                Debug.Log(c);
                x = 0;
            }
        }
        
    }
}

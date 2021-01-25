using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource townTheme;
    public AudioSource sadSong;
    public static MusicPlayer instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        townTheme.volume = .25f;
    }

    void Update()
    {
        if(!townTheme.isPlaying)
        {
            townTheme.Play();
        }
        townTheme.volume = townTheme.volume + .001f;
        if(townTheme.volume > .75f)
        {
            townTheme.volume = .75f;
        }
    }
    
}

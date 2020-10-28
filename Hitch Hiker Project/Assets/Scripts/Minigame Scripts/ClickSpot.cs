using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickSpot : MonoBehaviour
{
    public CookingManager cm;
    public GameObject ClickObject;
    public Transform SpotToClick;
    public Transform Clicker;
    public LayerMask CLickSpotLayer;
    public GameObject ClickEffect;

    private readonly List<Vector3> Sizes = new List<Vector3>{ new Vector3(3, 1, 1), new Vector3(2, 1, 1), new Vector3(1, 1, 1), new Vector3(.5f, 1, 1) };
    private int sizeCounter;
    private bool DoneWithGame;

    private float spawnRange;
    private float clickerStartY;
    private float spotStartY;
    public float moveSpeed = 1f;
    float time = 0;

    //win/loose
    public GameObject win;
    public GameObject loose;

    //SFX
    public AudioSource Winner;
    public AudioSource Loser;
    public AudioSource Ding;

    private void Start()
    {
        DoneWithGame = false;
        clickerStartY = Clicker.position.y;
        spotStartY = SpotToClick.position.y;
        SpotToClick.localScale = Sizes[0];
        spawnRange = 5 - (SpotToClick.localScale.x / 2);

        SpotToClick.position = SpawnClickSpot();
    }

    private void Update()
    {
        if (DoneWithGame)
        { 
            ClickObject.SetActive(false);
            time += Time.deltaTime;
            if(time > 4)
            {
                PlayerPrefs.SetFloat("playersLastPosition", -17.25f);
                SceneManager.LoadScene("DialogueSystem");
            }
        }
        else
        {
            MoveClicker();

            if (Input.GetMouseButtonDown(0))
            {
                if (InClickSpot())
                {
                    cm.EnableFood(sizeCounter);
                    sizeCounter++;

                    SpotToClick.position = SpawnClickSpot();
                    Instantiate(ClickEffect, Vector3.zero, Quaternion.identity);
                    Ding.Play();
                }
                else
                {
                    DoneWithGame = true;
                    cm.bowlAnim.SetTrigger("TipBowl");
                    loose.SetActive(true);
                    win.SetActive(false);
                    Loser.Play();
                }
            }
        }
    }

    private Vector3 SpawnClickSpot()
    {
        sizeCounter = Mathf.Clamp(sizeCounter, 0, 4);
        if (sizeCounter >= 4)
        {
            DoneWithGame = true;
            Winner.Play();
            win.SetActive(true);
            PlayerPrefs.SetInt("cMoney", PlayerPrefs.GetInt("cMoney") + 50);
            return Vector3.zero;
        }
        SpotToClick.localScale = Sizes[sizeCounter];
        spawnRange = 5 - (SpotToClick.localScale.x / 2);
        
        
        float randomX = Random.Range(-spawnRange, spawnRange);
        Vector3 newPos = new Vector3(randomX, spotStartY, 1);
        return newPos;
    }

    private void MoveClicker()
    {
        Clicker.transform.position = Vector3.Lerp(new Vector3(-5, clickerStartY, 0), new Vector3(5, clickerStartY, 0), Mathf.PingPong(Time.time * moveSpeed, 1));
    }

    private bool InClickSpot()
    {
        bool isInClickSpot = Physics2D.OverlapCircle(Clicker.position, .2f, CLickSpotLayer);
        return isInClickSpot;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(Clicker.position, .2f);
    }
}

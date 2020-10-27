using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingManager : MonoBehaviour
{
    public ClickSpot cp;
    public List<GameObject> foodSprites;
    public Transform Bowl;
    [HideInInspector]
    public Animator bowlAnim;
    public float bowlOffset;

    private void Start()
    {
        bowlAnim = Bowl.gameObject.GetComponent<Animator>();
        foreach (var f in foodSprites)
        {
            f.SetActive(false);
        }
    }

    public void EnableFood(int index)
    {
        foodSprites[index].SetActive(true);
        foodSprites[index].GetComponent<Rigidbody2D>().gravityScale = 2;
    }
}

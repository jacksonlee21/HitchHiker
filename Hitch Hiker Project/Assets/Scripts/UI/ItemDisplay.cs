using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{
    private ItemManager itemM;
    bool hammer;
    bool paper;
    bool box;
    public Image hammerImage;
    public Image paperImage;
    public Image boxImage;
    // Start is called before the first frame update
    void Start()
    {
        itemM = GameObject.Find("Main Character").GetComponent<ItemManager>();
        hammerImage = GameObject.Find("Hammer").GetComponent<Image>();
        paperImage = GameObject.Find("Paper").GetComponent<Image>();
        boxImage = GameObject.Find("Box").GetComponent<Image>();
        itemM.hammer = false;
        itemM.paper = false;
        itemM.box = false;
    }

    // Update is called once per frame
    void Update()
    {
        hammerImage.GetComponent<Image>().enabled = itemM.hammer;
        paperImage.GetComponent<Image>().enabled = itemM.paper;
        boxImage.GetComponent<Image>().enabled = itemM.box;
        
    }
}

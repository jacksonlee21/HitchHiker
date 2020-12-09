using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public string sceneName;
    public enum HouseType
    {
        Small,
        Large
    };

    public HouseType houseType;
}

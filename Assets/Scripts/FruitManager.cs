using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class FruitManager : MonoBehaviour
{
    static public int yellowFruit = 0;
    static public int redFruit = 0;
    static public int blueFruit = 0;

    private void Start()
    {
        if(PlayerPrefs.HasKey("yellowFruits"))
            yellowFruit = PlayerPrefs.GetInt("yellowFruits");
        if (PlayerPrefs.HasKey("redFruit"))
            redFruit = PlayerPrefs.GetInt("redFruit");
        if (PlayerPrefs.HasKey("blueFruit"))
            blueFruit = PlayerPrefs.GetInt("blueFruit");
    }
}

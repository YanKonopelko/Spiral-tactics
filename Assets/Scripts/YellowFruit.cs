using UnityEngine;

public class YellowFruit : Consumable
{
    override protected void GetEffect()
    {
        PlayerPrefs.SetInt("yellowFruit" , PlayerPrefs.GetInt("yellowFruit")+1);
    }
}

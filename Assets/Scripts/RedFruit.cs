using UnityEngine;

public class RedFruit : Consumable
{
    override protected void GetEffect()
    {
        PlayerPrefs.SetInt("redFruit", PlayerPrefs.GetInt("redFruit") +1);
    }
}

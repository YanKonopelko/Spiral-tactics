using UnityEngine;

public class BlueFruit : Consumable
{
    override protected void GetEffect()
    {
        PlayerPrefs.SetInt("blueFruit", PlayerPrefs.GetInt("blueFruit") +1);
    }
}

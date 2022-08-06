using UnityEngine;
using System.Collections.Generic;
 public class FruitManager : MonoBehaviour
{
    static public int yellowFruit = 0;
    static public int redFruit = 0;
    static public int blueFruit = 0;
    public Dictionary<string, int> fruits = new Dictionary<string,int>();
    private void Start()
    {    
        fruits.Add("blueFruit", 0);
        fruits.Add("redFruit", 0);
        fruits.Add("greenFruit", 0);

        if (PlayerPrefs.HasKey("greenFruit"))
            fruits["greenFruit"] = PlayerPrefs.GetInt("greenFruit");
        if (PlayerPrefs.HasKey("redFruit"))
            fruits["redFruit"] = PlayerPrefs.GetInt("redFruit");
        if (PlayerPrefs.HasKey("blueFruit"))
            fruits["blueFruit"] = PlayerPrefs.GetInt("blueFruit");
    }
     public bool HaveFruits(string f_1,string f_2)
    {
        //Проверяет наличие указанных фруктов у игрока
        if(f_1 == f_2 && fruits[f_1] >1){
            return true;
        }
        else if (f_1 != f_2 && fruits[f_1]> 0 && fruits[f_2] > 0)
        {
            return true;
        }
        return false;
    }
    public bool FruitsSubstr(string f_1, string f_2)
    {
        if (HaveFruits(f_1, f_2))
        {        
            //Удаляет указанные фрукты, если они есть
            fruits[f_1] -= 1;
            fruits[f_2] -= 1;
            PlayerPrefs.SetInt(f_1,PlayerPrefs.GetInt(f_1) -1);
            PlayerPrefs.SetInt(f_2, PlayerPrefs.GetInt(f_2) - 1);
            return true;
        }
        else
            return false;
    }
}

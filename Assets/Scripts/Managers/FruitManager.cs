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
        fruits.Add("blue", 0);
        fruits.Add("red", 0);
        fruits.Add("yellow", 0);

        if (PlayerPrefs.HasKey("yellowFruit"))
            fruits["yellow"] = PlayerPrefs.GetInt("yellowFruit");
        if (PlayerPrefs.HasKey("redFruit"))
            fruits["red"] = PlayerPrefs.GetInt("redFruit");
        if (PlayerPrefs.HasKey("blueFruit"))
            fruits["blue"] = PlayerPrefs.GetInt("blueFruit");
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
            return true;
        }
        else
            return false;
    }
}

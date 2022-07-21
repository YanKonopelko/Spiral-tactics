using UnityEngine;

public class Chest : Consumable
{
    override public void GetEffect(Player player)
    {
        //Восполняет выносливость
        player.curStamina = player.maxStamina;

        int a = Random.Range(1,100);
        //С шансом 50% восполняет запас патронов 
        if(a >50)
            player.curBullet = player.maxBullet;
        a = Random.Range(1, 100);
        //С шансом 20% даёт один из фруктов
        if (a > 80)
        {
            a = Random.Range(1, 4);
            switch (a) {
                case 1:              
                    Player.curBLueFruitsCollect += 1;
                    break;
                case 2:
                    Player.curBLueFruitsCollect += 1;
                    break;
                case 3:
                    Player.curBLueFruitsCollect += 1;
                    break;
            }
        }
        onGetEffect.Invoke();
    }
}

using UnityEngine;

public class Chest : Consumable
{
    override public void GetEffect(Player player)
    {
        //���������� ������������
        player.curStamina = player.maxStamina;

        int a = Random.Range(1,100);
        //� ������ 50% ���������� ����� �������� 
        if(a >50)
            player.curBullet = player.maxBullet;
        a = Random.Range(1, 100);
        //� ������ 20% ��� ���� �� �������
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

using UnityEngine;
using System.Collections;
public class GoldenChest : Consumable
{
    //������� ������: ������ ������ ����������� ������������� �� �����; 
    //������������������� ����� ������������; ���� ����� ��������; �� ����� �������� ������ ��������� ���������� ������������
    override public void GetEffect(Player player)
    {

        PlayerMovement.isStay = true;
        StartCoroutine(CanMove());

        Player.addCollectTime -= 10;

        player.curStamina = player.maxStamina;

        if(player.curBullet + 8 > player.maxBullet)
            player.curBullet = player.maxBullet;
        else
            player.curBullet += player.maxBullet;
        onGetEffect.Invoke();
        StartCoroutine(StopEffect());
    }
    

    private IEnumerator CanMove(){
        yield return new WaitForSeconds(1.5f);
        PlayerMovement.isStay = false;
    }
    private IEnumerator StopEffect()
    {
        //������ ��������
        yield return new WaitForSeconds(5f);
        Player.addCollectTime += 10;
        onGetEffect.Invoke();
    }
}

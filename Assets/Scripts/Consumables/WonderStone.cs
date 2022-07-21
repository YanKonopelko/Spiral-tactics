using UnityEngine;
using System.Collections;
public class WonderStone : Consumable
{
    // амень: дает временные эффекты(повышает скорость добычи ресурсов; собиратель наносит урон врагам, которые сто€т р€дом;
    //дает бесконечнуювыносливость; дает бесконечные патроны).

    override public void GetEffect(Player player)
    {
        var a = Random.Range(0, 5);
        switch (a) {
            case 0:
                Player.addCollectTime = -0.5f;
                break;
            case 1: ;
                Collector.canAttack = true;
                break;
            case 2:
                Player.addCurStamina = 100000;
                break;
            case 3:
                Player.addCurBullet = 100000;
                break;
        }
        onGetEffect.Invoke();

    }

    private IEnumerator StopEffect(int a)
    {
        yield return new WaitForSeconds(3.5f);
        switch (a)
        {
            case 0:
                Player.addCollectTime = +0.5f;
                break; 
            case 1:
                Collector.canAttack = false;
                ;
                break;
            case 2:
                Player.addCurStamina = 0;
                break;
            case 3:
                Player.addCurBullet = 0;
                break;
        }
        onGetEffect.Invoke();
    }

}

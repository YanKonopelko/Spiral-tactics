using System.Collections;
using UnityEngine;

public class Wizard : Enemy
{
    [SerializeField] private GameObject magickBall;
    override protected IEnumerator Attack(Player player)
    {
        yield return new WaitForSeconds(1.5f);
        isAttack = false;
        var ball = Instantiate(magickBall,transform.position,Quaternion.identity);
        ball.GetComponent<Projectile>().SetTarget(player.gameObject.transform);
    }
}

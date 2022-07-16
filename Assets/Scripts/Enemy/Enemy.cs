using UnityEngine;
using System.Collections;
public abstract class Enemy : Creature
{
    protected Transform player;
    protected bool isAttack = false;
    protected float attackSpeed = 1;
    protected float attackDistance = 20;
    protected float movementSpeed = 5;
    private void Update()
    {
        var target = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.LookAt(target);
        if (Vector3.Distance(transform.position, player.position) > attackDistance)
        {
            MoveToPlayer();
        }
        else if(Vector3.Distance(transform.position, player.position) <= attackDistance && !isAttack)
        {
            isAttack = true;
            StartCoroutine(Attack(player.GetComponent<Player>()));
        }
    }




    public void SetPlayer(Transform target)
    {
        player = target;
    }
    virtual protected IEnumerator Attack(Player player)
    {
        yield return new WaitForSeconds(attackSpeed);
        isAttack = false;
        player.GetDamage(1);
    }

    protected void MoveToPlayer()
    {
        GetComponent<NavigationTest>().Move(player.position);
    }

}

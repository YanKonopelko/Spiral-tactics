using UnityEngine;
using System.Collections;
using Pathfinding;

//јбстрактный класс, содержащий общие элементы всех противников
public abstract class Enemy : Creature
{
    //Ќа сцене всегда 1 персонаж игрока и все противники следуют за ним
    protected Transform player;

    protected bool isAttack = false;
    protected float attackSpeed = 1;
    protected float attackDistance = 20;
    protected float movementSpeed = 25;

    private void Start()
    {
        //”стонавилвает целью игрока в ассете, отвечающем за передвижение 
        GetComponent<AIPath>().target = player;
        GetComponent<AIPath>().speed = movementSpeed;
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

    protected void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<AIPath>().canMove = true;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        //ѕока противник касаетс€ игрока, он может атаковать и не может передвигатьс€
        if (!isAttack && collision.gameObject.CompareTag("Player"))
        {
            GetComponent<AIPath>().canMove = false;
            isAttack = true;
            StartCoroutine(Attack(collision.gameObject.GetComponent<Player>()));
        }
    }
}

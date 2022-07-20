using UnityEngine;
using System.Collections;
using Pathfinding;

//����������� �����, ���������� ����� �������� ���� �����������
public abstract class Enemy : Creature
{
    //�� ����� ������ 1 �������� ������ � ��� ���������� ������� �� ���
    protected Transform player;

    protected bool isAttack = false;
    protected float attackSpeed = 1;
    protected float attackDistance = 20;
    protected float movementSpeed = 25;

    private void Start()
    {
        //������������� ����� ������ � ������, ���������� �� ������������ 
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
        //���� ��������� �������� ������, �� ����� ��������� � �� ����� �������������
        if (!isAttack && collision.gameObject.CompareTag("Player"))
        {
            GetComponent<AIPath>().canMove = false;
            isAttack = true;
            StartCoroutine(Attack(collision.gameObject.GetComponent<Player>()));
        }
    }
}

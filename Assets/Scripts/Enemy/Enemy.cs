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
    protected float movementSpeed = 9.5f;


    private void Start()
    {
        //������������� ����� ������ � ������, ���������� �� ������������ 
        GetComponent<AIPath>().target = player;
        GetComponent<AIPath>().maxSpeed = movementSpeed;
        StartCoroutine(isFar());
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
        anim.SetBool("Attack", false);
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
            anim.SetBool("Attack", true);
            StartCoroutine(Attack(collision.gameObject.GetComponent<Player>()));
        }
    }

    private IEnumerator isFar()
    {
        yield return new WaitForSeconds(3);

        if (Vector3.Distance(transform.position, player.position) > 100)
        {
            Destroy(gameObject);
        }
         
        StartCoroutine(isFar());
    }
}

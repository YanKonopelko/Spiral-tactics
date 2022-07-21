using UnityEngine;
using System.Collections;
using Pathfinding;
using System;

//����������� �����, ���������� ����� �������� ���� ����������� ���������
public abstract class Consumable : MonoBehaviour
{
    

    //������� ���������� ��� ������������ ������� ��������.

    public static Action onGetEffect;

    private void OnTriggerEnter(Collider other)
    {
        //�� ����� ������� �������� ������������� �����������
        if (other.CompareTag("Player"))
        {
            PlayerMovement.isStay = true;
            StartCoroutine(Collect(other.GetComponent<Player>()));
        }
        else if (other.CompareTag("Collector"))
        {
            other.GetComponent<AIPath>().canMove = false;
            StartCoroutine(Collect(other.GetComponent<Collector>()));
        }
    }


    IEnumerator Collect(Player player)
    {
        yield return new WaitForSeconds(player.collectTime);

        PlayerMovement.isStay = false; 
        //���� �������� �����, ������ ����������� ���������
        GetEffect(player);
        //��������� ����������� �������
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        //����* �� ������������ �� ������� ����, ��� ����� ������� ����� ���� ��������� 
        //����* ������������ ������ � ������ ����� �� ������� ������ ����������
    }
    IEnumerator Collect(Collector collector)
    {
        yield return new WaitForSeconds(collector.collectTime + Collector.addCollectTime);
        //��������� ������ ���������
        collector.GetComponent<AIPath>().canMove = true;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        //������ ��������� �� ����� ����������
        collector.SetCollected(gameObject);
    }
    //����� ���������������� ��� ������� ���� ������������ ��������
    virtual public void GetEffect(Player player)
    {
        Debug.Log("GetEffect");
        onGetEffect.Invoke();
    }
}

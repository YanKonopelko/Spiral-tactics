using System.Collections;
using Pathfinding;
using UnityEngine;

public class Collector : MonoBehaviour
{
    // ������ ������ �� ������� ������� ����������
    [SerializeField] private Transform target ;

    public bool isEmpty;

    static public bool canAttack = false;
    static public bool nowAttack = false;

    public float collectTime = 1.5f;
    public static float addCollectTime = 0;

    public bool isCollect = false;
    //����������� ������� ����� ���������� � ���� ������, ��������, ������������� � ������ �����
    [SerializeField] GameObject collected;

    private void Start()
    {
        collectTime += PlayerPrefs.GetFloat("collAddCollectTime");
        InputManager.onClick += SetTarget;
        GetComponent<AIPath>().target = target;
    }
    public void SetTarget(Vector3 _target)
    {
        _target.y = transform.position.y;
        target.position = _target;
    }

    private void OnDisable()
    {
        InputManager.onClick -= SetTarget;
    }
    private void OnTriggerStay(Collider other)
    {
        //������� ���� ��� �������� Wonder Stone-a
        if (other.CompareTag("Enemy") && canAttack && !nowAttack)
        {
            StartCoroutine(Attack(other.GetComponent<Creature>()));
        }
        
    }

    void OnCollisionEnter(Collision collision)
    {
        // ����� �������� ������ ����� ��� ����������� �������
        if (collision.gameObject.CompareTag("Player") && isCollect)
        {
            collected.transform.GetChild(0).GetComponent<Consumable>().GetEffect(collision.gameObject.GetComponent<Player>());
            isCollect = false;
            Destroy(collected.transform.GetChild(0).gameObject);
        }
    }
    IEnumerator Attack(Creature cr)
    {
        yield return new WaitForSeconds(1);
        cr.GetDamage(1);
    }

    public void SetCollected( GameObject coll)
    {

        isCollect = true;
        coll.transform.position = collected.transform.position;
        coll.transform.parent = collected.transform;
    }

}

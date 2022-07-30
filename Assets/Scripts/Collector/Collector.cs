using System.Collections;
using Pathfinding;
using UnityEngine;

public class Collector : MonoBehaviour
{
    // Пустой объект за которым следует собиратель
    [SerializeField] private Transform target ;
    [SerializeField] private Transform player;

    public bool isEmpty;

    static public bool canAttack = false;
    static public bool nowAttack = false;

    public float collectTime = 1.5f;
    public static float addCollectTime = 0;

    public bool isCollect = false;
    //Подробанный предмет будет помещаться в этот объект, пустышка, расположенная в нужном месте
    [SerializeField] GameObject collected;

    private void Start()
    {
        target = Instantiate(new GameObject(),transform.position,Quaternion.identity).transform;
        target.name = "CollectorTarget";

        collectTime += PlayerPrefs.GetFloat("collAddCollectTime");

        InputManager.onClick += SetTarget;
        GetComponent<AIPath>().target = target;
        player = GameObject.FindWithTag("Player").transform;

        StartCoroutine(isFar());

    }
    public void SetTarget(Vector3 _target)
    {
        //проверка на включение,включение
        _target.y = transform.position.y;
        target.position = _target;
    }

    private void OnDisable()
    {
        InputManager.onClick -= SetTarget;
    }
    private void OnTriggerStay(Collider other)
    {
        //Наносит урон при поднятии Wonder Stone-a
        if (other.CompareTag("Enemy") && canAttack && !nowAttack)
        {
            StartCoroutine(Attack(other.GetComponent<Creature>()));
        }
        
    }

    void OnCollisionEnter(Collision collision)
    {
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
        //автоматически идти к игроку
        isCollect = true;
        coll.transform.position = collected.transform.position;
        coll.transform.parent = collected.transform;
    }
    private IEnumerator isFar()
    {
        yield return new WaitForSeconds(3);

        if (Vector3.Distance(transform.position, player.position) > 200)
        {
            var pos = player.position;
            pos.y = 5;
            pos.x -= 20;
            pos.x += 10;
            transform.position = pos;
            SetTarget(pos);
        }

        StartCoroutine(isFar());
    }
}

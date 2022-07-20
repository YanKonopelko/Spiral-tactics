using System.Collections;
using UnityEngine;
using Pathfinding;

public class Wizard : Enemy
{
    [SerializeField] private GameObject magickBall;
    [SerializeField] private GameObject elementalPrefab;

    private void OnEnable()
    {
        StartCoroutine(SpawnElemental());        
    }

    override protected IEnumerator Attack(Player player)
    {
        //ћаг при атаке спавнит магический шар, лет€щий в игрока
        yield return new WaitForSeconds(1.5f);
        isAttack = false;
        var ball = Instantiate(magickBall,transform.position,Quaternion.identity);
        ball.GetComponent<Projectile>().SetTarget(player.gameObject.transform);
    }

    private IEnumerator SpawnElemental()
    {
        //ѕериодически генерирует элементалей неподалеку от себ€
        yield return new WaitForSeconds(Random.Range(3, 6));
        if (transform.parent.transform.childCount < 7)
        {
            Vector3 spawnPos = transform.position;
            spawnPos.x += Random.Range(2, 5);
            spawnPos.z += Random.Range(3, 10);
            var elem = Instantiate(elementalPrefab, spawnPos, Quaternion.identity);
            elem.transform.parent = transform.parent;
            elem.GetComponent<Enemy>().SetPlayer(player);
        }
        StartCoroutine(SpawnElemental());
    }

    //ћаг начинает атаковать, когда дистанци€ до игрока достаточно мала
    private void OnTriggerStay(Collider other)
    {
        if (!isAttack && other.CompareTag("Player"))
        {
            GetComponent<AIPath>().canMove = false;
            isAttack = true;
            StartCoroutine(Attack(other.GetComponent<Player>()));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<AIPath>().canMove = true;
        }
    }

}

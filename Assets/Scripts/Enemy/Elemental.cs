using UnityEngine;

public class Elemental : Enemy
{
    private void OnEnable()
    {
        attackSpeed = 1.5f;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!isAttack && other.CompareTag("Player"))
        {
            isAttack = true;
            StartCoroutine(Attack(other.gameObject.GetComponent<Player>()));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        StopAllCoroutines();
    }
}

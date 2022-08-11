using UnityEngine;
using System.Collections;
//Абстрактный класс, содержащий общие элементы всех живых существ
public abstract class Creature : MonoBehaviour
{
    protected int healthPoint = 5;

    protected private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void GetDamage(int damage)
    {
        healthPoint -= 1;
        if (healthPoint == 0)
            Death();
    }
    virtual protected void Death()
    {
        anim.SetBool("Death", true);
        StartCoroutine(DeathEffect());
    }

    IEnumerator DeathEffect()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }

}

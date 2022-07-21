using UnityEngine;

//Абстрактный класс, содержащий общие элементы всех живых существ
public abstract class Creature : MonoBehaviour
{
    protected int healthPoint = 5;

    public void GetDamage(int damage)
    {
        healthPoint -= 1;
        if (healthPoint == 0)
            Death();
    }
    virtual protected void Death()
    {
        gameObject.SetActive(false);
    }
}

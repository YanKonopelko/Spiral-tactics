using UnityEngine;

//Абстрактный класс, содержащий общие элементы всех снарядов
public abstract class Projectile : MonoBehaviour
{
    protected Transform target;
    protected float  speed = 10;
    protected int damage = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == target.gameObject)
        {
            target.GetComponent<Creature>().GetDamage(damage);
            Destroy(gameObject);
        }
    }
    public void SetTarget(Transform _target)
    {
        target = _target;
    }
}

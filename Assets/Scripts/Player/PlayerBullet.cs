using UnityEngine;

public class PlayerBullet : Projectile
{
    private void OnEnable()
    {
        speed = 25;
        damage = 1;
    }
    void Update()
    {
        //Приследует противника
        if (target.gameObject.active)
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        else
            Destroy(gameObject);
    }
}

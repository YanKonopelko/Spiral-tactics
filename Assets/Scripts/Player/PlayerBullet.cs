using UnityEngine;

public class PlayerBullet : Projectile
{
    private void OnEnable()
    {
        speed = 10;
        damage = 1;
    }
    void Update()
    {
        if (target.gameObject.active)
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        else
            Destroy(gameObject);
    }
}

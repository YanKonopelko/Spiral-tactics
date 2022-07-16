using UnityEngine;

public class WizardBall : Projectile
{
    
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }


}

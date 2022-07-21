using UnityEngine;

public class WizardBall : Projectile
{
    private Vector3 _target;
    private void Start()
    {
        _target = target.position;
    }
    //Магический шар не приследует игрока, а летит в ту точку, в которой он был на момент запуска шара
    void Update()
    {
        if (Vector3.Distance(transform.position, _target) > 1)
            transform.position = Vector3.MoveTowards(transform.position, _target, speed * Time.deltaTime);
        else
            Destroy(gameObject);
    }

    
}

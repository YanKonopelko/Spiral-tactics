using UnityEngine;
using System;
using UnityEngine.SceneManagement;
public class Player : Creature
{
    public float maxStamina = 30;
    public float curStamina = 30;
    private int maxBullet = 15;
    public int curBullet = 15;
    [SerializeField] private GameObject spawner;
    [SerializeField] private GameObject bulletPrefab;
    public static Action onShot;

    override protected void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Shot()
    {
        if (curBullet > 0)
        {
            float min = 1000;
            Transform target = transform;
            if (spawner.transform.childCount > 0)
            {
                for (int i = 0; i < spawner.transform.childCount; i++)
                {
                    if (Vector3.Distance(transform.position, spawner.transform.GetChild(i).position) < min && spawner.transform.GetChild(i).gameObject.active )
                    {
                        min = Vector3.Distance(transform.position, spawner.transform.GetChild(i).position);
                        target = spawner.transform.GetChild(i);
                    }
                }
                var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                bullet.GetComponent<Projectile>().SetTarget(target);
                curBullet -= 1;
                onShot.Invoke();
            }
        }
        else
        {
            Debug.Log("No Ammo");
        }
    }
}

using UnityEngine;
using System;
using UnityEngine.SceneManagement;
public class Player : Creature
{
    public float maxStamina ;
    public float curStamina ;
    public float staminaRegeneration ;

    private float startMaxStamina = 30;
    private float startCurStamina = 30;
    private float startStaminaRegeneration = 2;

    public static float addMaxStamina = 0;
    public static float addCurStamina = 0;
    public static float addStaminaRegeneration = 0;

    public int maxBullet ;
    public int curBullet ;

    public static int addMaxBullet = 0;
    public static int addCurBullet = 0;

    private int startMaxBullet = 15;
    private int startCurBullet = 15;

    [SerializeField] private GameObject spawner;
    [SerializeField] private GameObject bulletPrefab;
    public static Action onShot;

    public float collectTime ;
    public static float addCollectTime = 0;

    private float startCollectTime = 1.5f;

    [SerializeField] private Shooter shooter;


    static public int curYellowFruitsCollect = 0;
    static public int curBLueFruitsCollect = 0;
    static public int curRedFruitsCollect = 0;


    private void  Start() {
        //Задаёт значение всех характеристик
        curYellowFruitsCollect = 0;
        curBLueFruitsCollect = 0;
        curRedFruitsCollect = 0;
        startCollectTime += PlayerPrefs.GetFloat("addCollectTime");
        startMaxBullet += PlayerPrefs.GetInt("addMaxBullet");
        startCurStamina += PlayerPrefs.GetFloat("addMaxStamina");
        startStaminaRegeneration += PlayerPrefs.GetFloat("addStaminaRegeneration" );

        startCurBullet = startMaxBullet;

        addMaxStamina = 0;
        addCurStamina = 0;
        addStaminaRegeneration = 0;
        addMaxBullet = 0;
        addCurBullet = 0;
        addCollectTime = 0;
        Consumable.onGetEffect += ChangeAdd;
    }

    override protected void Death()
    {
        //Перезапускает сцену при смерти
        Consumable.onGetEffect -= ChangeAdd;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Shot()
    {
        //Выстрел в  ближайшего противника
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
                var bullet = Instantiate(bulletPrefab, transform.GetChild(0).position, Quaternion.identity);
                bullet.GetComponent<Projectile>().SetTarget(target);
                curBullet -= 1;
                onShot.Invoke();
            }
        }
    }

    public void Fruits()
    {
        //Сохраняет все собранные фрукты
            PlayerPrefs.SetInt("redFruit", PlayerPrefs.GetInt("redFruit") +curRedFruitsCollect);
            PlayerPrefs.SetInt("yellowFruit", PlayerPrefs.GetInt("yellowFruit")+curYellowFruitsCollect);
            PlayerPrefs.SetInt("blueFruit", PlayerPrefs.GetInt("blueFruit") +curBLueFruitsCollect);
    }

    private void ChangeAdd()
    {
        //Фиксирует временное изменение характеристик 
        maxStamina = startMaxStamina + addMaxStamina;
        curStamina = startCurStamina + addCurStamina;
        staminaRegeneration = startStaminaRegeneration + addStaminaRegeneration;
        maxBullet = startMaxBullet + addMaxBullet;
        curBullet = startCurBullet + addCurBullet;
        collectTime = startCollectTime + addCollectTime;
    }

}

 using UnityEngine;
using System.Collections;
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject wolfPrefab;
    [SerializeField] private GameObject wizardPrefab;
    [SerializeField] private GameObject elementalPrefab;
    [SerializeField] private Transform player;

    [SerializeField] private Transform[] spawnPoints;

    private float spawnDistance = 70;

   

    private void Start()
    {
        StartCoroutine(SpawnSomebody());
    }
    private void SpawnWolf( )
    {
        // Спавнит волка в оговоренных частях экрана
        var poses = GetPosition(spawnPoints);
        var side = Random.Range(0, 2);

        Vector3 spawnPos = new Vector3(0, 0, 0);

        spawnPos.z = Random.Range(poses[side * 2].z, poses[side * 2 + 1].z);
        spawnPos.x = poses[side * 2].x;
        var wolf = Instantiate(wolfPrefab, spawnPos, Quaternion.identity);
        wolf.transform.parent = transform;
        wolf.GetComponent<Enemy>().SetPlayer(player);

    }
    private void SpawnElemental()
    {
        var poses = GetPosition(spawnPoints);
        var side = 1;

        Vector3 spawnPos = new Vector3(0, 0, 0);

        spawnPos.z = Random.Range(poses[side * 2].z, poses[side * 2 + 1].z);
        spawnPos.x = poses[side * 2].x;


        var elem = Instantiate(elementalPrefab, spawnPos, Quaternion.identity);
        elem.transform.parent = transform;
        elem.GetComponent<Enemy>().SetPlayer(player);
        
    }
    private void SpawnWizard()
        {

        int a = Random.Range(0, 10);
        Vector3 spawnPos = new Vector3(0, 0, 0);
        var poses = GetPosition(spawnPoints);
        if (a < 9)
        {
            var side = 1;
            spawnPos.z = Random.Range(poses[side * 2].z, poses[side * 2 + 1].z);
            spawnPos.x = poses[side * 2].x;
        }
        else
        {
            spawnPos.z = Random.Range(poses[0].z, poses[3].z);
            spawnPos.x = Random.Range(poses[0].z, poses[1].z);
        }
        var wizard = Instantiate(wizardPrefab, spawnPos, Quaternion.identity);
        wizard.transform.parent = transform;
        wizard.transform.GetComponent<Enemy>().SetPlayer(player);
    }
    private Vector3[] GetPosition(Transform[] trans)
    {
        //1 3
        //2 4
        //Определяет крайние точки спавна
        Vector3[] poses = new Vector3[trans.Length];
        poses[0] = player.position;
        poses[0].y = 0;
        poses[0].x += spawnDistance;
        poses[0].z += spawnDistance;

        poses[1] = player.position;
        poses[1].y = 0;
        poses[1].x += spawnDistance;
        poses[1].z -= spawnDistance;

        poses[2] = player.position;
        poses[2].y = 0;
        poses[2].x -= spawnDistance;
        poses[2].z += spawnDistance;

        poses[3] = player.position;
        poses[3].y = 0;
        poses[3].x -= spawnDistance;
        poses[3].z -= spawnDistance;

        return poses;
    }

    private IEnumerator SpawnSomebody()
{
    //Периодически спавнит одного из 3-х врагов
    yield return new WaitForSeconds(Random.Range(3, 6));
    if (transform.transform.childCount < 7)
    {
        var a = Random.Range(0, 3);
        switch (a)
        {
            case 0:
               SpawnWolf();
                break;
            case 1:
               SpawnElemental();
                break;
            case 2:
                SpawnWizard();
                break;
        }
            
    }
        StartCoroutine(SpawnSomebody());
    }
}

    




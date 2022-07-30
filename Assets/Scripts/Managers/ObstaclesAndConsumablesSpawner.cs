using UnityEngine;

public class ObstaclesAndConsumablesSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] obstacles;
    [SerializeField] GameObject[] consumables;

    private void OnEnable()
    {
        //При спавне Tile-a генерируются объекты на нём
        Spawn();
    }

    private void Spawn()
    {
        for(int i =0; i< transform.GetChild(1).childCount; i++)
        {
            int a = Random.Range(0, 100);
            switch (a)
            {
                case <20:
                    break;
                case >=20 and <=70: 
                    SpawnObstacle(transform.GetChild(1).GetChild(i).transform);
                    break;
                case >70:
                    SpawnConsumable(transform.GetChild(1).GetChild(i).transform);
                    break;
            }
        }
    }

    private void SpawnObstacle(Transform trans)
    {
        Instantiate(obstacles[Random.Range(0, obstacles.Length)], trans);

    }
    private void SpawnConsumable(Transform trans)
    {
        Instantiate(consumables[Random.Range(0, consumables.Length)], trans);
    }
}

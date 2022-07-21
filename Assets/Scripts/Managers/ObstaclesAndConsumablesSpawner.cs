using UnityEngine;

public class ObstaclesAndConsumablesSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] obstacles;
    [SerializeField] GameObject[] consumables;

    private void OnEnable()
    {
        //��� ������ Tile-a ������������ ������� �� ���
        Spawn();
    }

    private void Spawn()
    {
        for(int i =0; i< transform.GetChild(1).childCount; i++)
        {
            int a = Random.Range(0, 3);
            switch (a)
            {
                case 0:
                    break;
                case 1: 
                    SpawnObstacle(transform.GetChild(1).GetChild(i).transform);
                    break;
                case 2:
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

using UnityEngine;
public class TileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject tile;
    [SerializeField] private GameObject camera;
    [SerializeField] private AstarPath a;
    private void Start()
    {
        SpawnTrigger.onTriggerEnter += Spawn;
    }
    private void Spawn(Vector3 spawnpos, int side)
    {
        //Создаёт Tile по заданным координатам
        
        var _tile = Instantiate(tile, spawnpos,Quaternion.identity);
        _tile.transform.SetParent(gameObject.transform);
        //Выключает тригер смежный с тригером спавна
        if (side == 1)
        {
            _tile.transform.GetChild(0).GetChild(2).GetComponent<BoxCollider>().enabled = false;
        }
        else if (side == 3)
        {
            _tile.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider>().enabled = false;
        }
        //Удаляет неиспользуемый куски карты
        if (gameObject.transform.childCount > 7)
        {
            Destroy(gameObject.transform.GetChild(0).gameObject);
        }

        a.Scan();
    }
    private void OnDisable()
    {
        SpawnTrigger.onTriggerEnter -= Spawn;
    }
}

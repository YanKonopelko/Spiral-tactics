using System;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    [SerializeField] private int side;
    [SerializeField] private int tileLength = 300;
    public static Action<Vector3,int> onTriggerEnter;
    private void OnTriggerEnter(Collider other)
    {
        //При вхождении в тригер, спавнит следующий кусок карты
        if (other.CompareTag("Player"))
        {
            Vector3 pos = new Vector3(0, 0, 0);
            switch (side)
            {
                case 1:
                    pos.z += tileLength;
                    break;
                case 2:
                    pos.x += tileLength;
                    break;
                case 3:
                    pos.z -= tileLength;
                    break;
            }
        ;

            onTriggerEnter.Invoke(transform.parent.parent.position + pos,side);
            Destroy(gameObject);
        }
    }
}

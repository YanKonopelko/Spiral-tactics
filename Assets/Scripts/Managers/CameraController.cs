using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] public Transform player;
    private float speed = 2;
    void Update()
    {
        //������ ������� �� �������
        transform.position = new Vector3(player.position.x,transform.position.y,player.position.z);
    }
}

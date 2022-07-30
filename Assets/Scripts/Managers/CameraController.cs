using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] public Transform player;
    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - player.position;
    }

    void Update()
    {
        transform.position = player.position+offset;
    }
   
}


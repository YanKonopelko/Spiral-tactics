using UnityEngine;

public class Shooter : MonoBehaviour
{
    public void Rotate(Vector3 target)
    {
        var a = new Vector3(transform.position.x, target.y, target.z);
        transform.LookAt(a);
    }
}

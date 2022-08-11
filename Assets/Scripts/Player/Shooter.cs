using UnityEngine;
using System.Collections;
public class Shooter : MonoBehaviour
{
    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
        //Player.onShot_Vector3 += RotateShooter;
        Player.onShot += Shot;
    }
    public void RotateShooter(Vector3 target)
    {
        var a = new Vector3(transform.position.x, target.y, target.z);
        transform.parent.LookAt(a);
    }
    
    private void Shot()
    {
        anim.SetBool("isShot",true); 
        StartCoroutine(EndAnim());
    }
    
    IEnumerator EndAnim()
    {
        yield return new WaitForSeconds(1f);
        anim.SetBool("isShot", false);
        StopAllCoroutines();
    }
}

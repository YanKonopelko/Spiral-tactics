using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private Vector3 target ;
    public bool isEmpty;
    public bool isStay;
    NavigationTest nav;
    [SerializeField] GameObject collected;
    private void Start()
    {
        target = new Vector3(0, transform.position.y, 0);
        InputManager.onClick += SetTarget;
        nav = GetComponent<NavigationTest>();
    }
    public void SetTarget(Vector3 _target)
    {
        _target.y = transform.position.y;
        target = _target;
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        yield return new WaitForFixedUpdate();
        if ((Mathf.Abs(transform.position.x - target.x) + Mathf.Abs(transform.position.z - target.z)) > 10)
        {
            //var a = new Vector3(target.x, target.y, transform.position.z);
            //transform.localRotation = new Quaternion (a.x,a.y,a.z,0); 
            nav.Move(target);
            StartCoroutine(Move());
        }

    }

}

using UnityEngine;
using System.Collections;

public abstract class Consumable : MonoBehaviour
{
    protected float collectTime = 1.5f;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //stop Player
            StartCoroutine(Collect(other.GetComponent<Player>()));
        }
        else if (other.CompareTag("Collector"))
        {
            //stop collector
            StartCoroutine(Collect(other.GetComponent<Collector>()));
        }
    }

    public void SetCollectTime(float value)
    {
        collectTime = value;
    }

    IEnumerator Collect(Player player)
    {
        yield return new WaitForSeconds(collectTime);
        GetEffect();
        Destroy(gameObject);
    }
    IEnumerator Collect(Collector collector)
    {
        yield return new WaitForSeconds(collectTime);
        GetEffect();
    }
    virtual protected void GetEffect()
    {
        Debug.Log("S'el");
    }
}

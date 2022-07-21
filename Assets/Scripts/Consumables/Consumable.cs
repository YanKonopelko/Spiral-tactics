using UnityEngine;
using System.Collections;
using Pathfinding;
using System;

//Абстрактный класс, содержащий общие элементы всех расходуемых предметов
public abstract class Consumable : MonoBehaviour
{
    

    //Событие вызываемое при срабатывании эффекта предмета.

    public static Action onGetEffect;

    private void OnTriggerEnter(Collider other)
    {
        //На время подбора предмета остонавливает собирающего
        if (other.CompareTag("Player"))
        {
            PlayerMovement.isStay = true;
            StartCoroutine(Collect(other.GetComponent<Player>()));
        }
        else if (other.CompareTag("Collector"))
        {
            other.GetComponent<AIPath>().canMove = false;
            StartCoroutine(Collect(other.GetComponent<Collector>()));
        }
    }


    IEnumerator Collect(Player player)
    {
        yield return new WaitForSeconds(player.collectTime);

        PlayerMovement.isStay = false; 
        //Если собирает игрок, эффект срабатывает мгновенно
        GetEffect(player);
        //Отключает отображение объекта
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        //Прим* Не уничтожается по причине того, что часть эффекта может быть отложенна 
        //Прим* Уничтожается вместе с куском карты на котором объект расположен
    }
    IEnumerator Collect(Collector collector)
    {
        yield return new WaitForSeconds(collector.collectTime + Collector.addCollectTime);
        //Отключает только коллайдер
        collector.GetComponent<AIPath>().canMove = true;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        //Объект переходит на спину коллектору
        collector.SetCollected(gameObject);
    }
    //Метод переопределяется для каждого вида расходуемого предмета
    virtual public void GetEffect(Player player)
    {
        Debug.Log("GetEffect");
        onGetEffect.Invoke();
    }
}

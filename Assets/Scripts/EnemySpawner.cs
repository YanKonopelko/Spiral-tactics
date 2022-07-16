using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject wolfPrefab;
    [SerializeField] private GameObject wizardPrefab;
    [SerializeField] private GameObject elementalPrefab;
    [SerializeField] private Transform player;
    private void Start()
    {
        SpawnWolf();
        SpawnElemental();
        SpawnWizard();

    }
    //корутины на спавн, зоны для спавна. Vector3 spawnpos
    private void SpawnWolf( )
    {
        var wolf = Instantiate(wolfPrefab, gameObject.transform);
        wolf.GetComponent<Enemy>().SetPlayer(player);
    }
    private void SpawnElemental()
    {
        var elem = Instantiate(elementalPrefab,gameObject.transform);
        elem.GetComponent<Enemy>().SetPlayer(player);
    }
    private void SpawnWizard()
    {
        var wizard = Instantiate(wizardPrefab, gameObject.transform);
        wizard.GetComponent<Enemy>().SetPlayer(player);
    }

}



using System;
using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] public Transform target;
    [SerializeField] GameObject Enemy;
    [SerializeField] float Seconds;
    [SerializeField] int numberOfEnemy;
    [SerializeField] int pvMultiplicator;
    [SerializeField] GameObject winScreen;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator Start()
    {
        for (int i = 0; i < numberOfEnemy; i++){
            yield return new WaitForSeconds(Seconds);
            GameObject enemy = Instantiate(Enemy, transform);
            enemy.GetComponent<EnemyMovement>().target = target;
            enemy.GetComponent<Health>().HP *= pvMultiplicator;
            
        }
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(1);
        GameObject enemy = Instantiate(Enemy, transform);
        enemy.GetComponent<EnemyMovement>().target = target;
        if (numberOfEnemy <= 0)
        {
            Debug.Log("You win");
            winScreen.SetActive(true);
        }
    }
    
    
}

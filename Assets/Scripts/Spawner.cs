using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] public Transform target;
    [SerializeField] GameObject Enemy;
    [SerializeField] float Seconds;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(Seconds);
            GameObject enemy = Instantiate(Enemy, transform);
            enemy.GetComponent<EnemyMovement>().target = target;
        }
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(1);
        GameObject enemy = Instantiate(Enemy, transform);
        enemy.GetComponent<EnemyMovement>().target = target;
    }
}

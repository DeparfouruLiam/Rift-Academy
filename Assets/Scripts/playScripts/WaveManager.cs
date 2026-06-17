using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public string waveName;         
    public GameObject enemyPrefab;
    public int enemyCount;         
    public float spawnRate;  
}

public class WaveManager : MonoBehaviour
{
    [Header("Paramètres des Vagues")]
    [SerializeField] private Wave[] waves; 
    [SerializeField] private float timeBetweenWaves = 5f; 

    [Header("Références Spatiales")]
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private Vector3 targetBase;


    
    private int currentWaveIndex = 0;

    void Start()
    {
        StartCoroutine(StartWavesSequence());
    }

    IEnumerator StartWavesSequence()
    {
        while (currentWaveIndex < waves.Length)
        {
            yield return StartCoroutine(SpawnWave(waves[currentWaveIndex]));
            
            currentWaveIndex++;

            if (currentWaveIndex < waves.Length)
            {
                Debug.Log("ya zebi");
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        }
        
    }

    // Coroutine qui gère l'apparition des ennemis pour une vague précise
    IEnumerator SpawnWave(Wave wave)
    {

        for (int i = 0; i < wave.enemyCount; i++)
        {
            SpawnEnemy(wave.enemyPrefab);
            
            yield return new WaitForSeconds(wave.spawnRate);
        }
    }
    void SpawnEnemy(GameObject prefab)
    {
        // 1. Choisir un point de spawn aléatoire (une ligne au hasard)
        Transform sp = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // 2. Créer l'ennemi à ce point
        GameObject enemy = Instantiate(prefab, sp.position, sp.rotation);

        // 3. Lui assigner sa cible pour qu'il sache où aller
        EnemyMovement movement = enemy.GetComponent<EnemyMovement>();
        if (movement != null)
        {
            movement.target = targetBase; // On donne la cible au script EnemyMovement
        }
    }
}
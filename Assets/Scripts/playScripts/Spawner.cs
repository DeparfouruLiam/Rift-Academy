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


    // --- AJOUT : Un tableau pour glisser les GameObjects représentants tes lignes ---
    [SerializeField] private Transform[] spawnPoints; 
    [SerializeField] private Transform[] TargetPoints; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator Start()
    {
        for (int i = 0; i < numberOfEnemy; i++)
        {
            yield return new WaitForSeconds(Seconds);

            // 1. Choisir un point d'apparition au hasard parmi tes lignes
            Transform randomSpawnPoint = transform; // Par défaut, la position du spawner lui-même
            if (spawnPoints != null && spawnPoints.Length > 0)
            {
                int randomIndex = UnityEngine.Random.Range(0, spawnPoints.Length);
                randomSpawnPoint = spawnPoints[randomIndex];
            }

            // 2. Instancier l'ennemi à la position de la ligne choisie (sans le mettre "enfant" du spawner pour éviter les bugs d'échelle)
            GameObject enemy = Instantiate(Enemy, randomSpawnPoint.position, Quaternion.identity);
            
            // 3. Appliquer tes scripts existants
           Vector3 pos = enemy.transform.position;pos.x -= 20;enemy.GetComponent<EnemyMovement>().target = pos ;
            enemy.GetComponent<Health>().HP *= pvMultiplicator;
        }

        

        // --- AJOUT : Logique de victoire ---
        // Une fois que la boucle 'for' est finie, tous les ennemis ont été créés.
        yield return new WaitForSeconds(2f); // Optionnel : petite attente avant d'afficher le écran de fin
        Debug.Log("Tous les ennemis sont apparus ! You win");
        if (winScreen != null)
        {
            winScreen.SetActive(true);
        }
    }

    // Note : J'ai retiré la fonction SpawnEnemy() car elle faisait doublon avec ton IEnumerator Start
}
using System;
using System.Collections;
using UnityEngine;

// NOUVEAU : La petite boîte qui va te permettre de configurer chaque vague dans l'Inspecteur
[System.Serializable]
public class Vague
{
    public string nomVague = "Vague 1";
    public GameObject Enemy; // Le monstre de cette vague
    public int numberOfEnemy; // Combien on en fait spawn
    public float Seconds; // Le délai entre chaque monstre
    public int pvMultiplicator = 1; // Pratique : tu peux mettre x2 pour la vague 2, x3 pour la vague 3 !
}

public class Spawner : MonoBehaviour
{
    [Header("Configuration des Vagues")]
    [SerializeField] private Vague[] vagues; 
    [SerializeField] private float tempsEntreVagues = 5f; 

    [Header("Points d'apparition")]
    [SerializeField] private Transform[] spawnPoints; 
    [SerializeField] private Transform[] TargetPoints;
    [SerializeField] public Transform target;

    private FinDeNiveau scriptFin; 

    IEnumerator Start()
    {
        
        scriptFin = FindFirstObjectByType<FinDeNiveau>();

    
        for (int w = 0; w < vagues.Length; w++)
        {
            Vague vagueActuelle = vagues[w];
            Debug.Log("Lancement de : " + vagueActuelle.nomVague);

           
            for (int i = 0; i < vagueActuelle.numberOfEnemy; i++)
            {
                yield return new WaitForSeconds(vagueActuelle.Seconds);

               
                Transform randomSpawnPoint = transform; 
                if (spawnPoints != null && spawnPoints.Length > 0)
                {
                    int randomIndex = UnityEngine.Random.Range(0, spawnPoints.Length);
                    randomSpawnPoint = spawnPoints[randomIndex];
                }

                
                GameObject enemy = Instantiate(vagueActuelle.Enemy, randomSpawnPoint.position, Quaternion.identity);
            
                Vector3 pos = enemy.transform.position;
                pos.x -= 20;
                enemy.GetComponent<EnemyMovement>().target = pos;
                enemy.GetComponent<Health>().HP *= vagueActuelle.pvMultiplicator;
            }
            if (w < vagues.Length - 1)
            {
                yield return new WaitForSeconds(tempsEntreVagues);
            }
        }

        Debug.Log("Tous les ennemis sont apparus ! On attend qu'ils soient tous morts...");
        

        if (scriptFin != null)
        {
            scriptFin.SignalerSpawnerTermine();
        }
    }
}
using System;
using System.Collections;
using UnityEngine;

[System.Serializable]
public class Vague
{
    public string nomVague = "Vague 1";
    public GameObject Enemy; 
    public int numberOfEnemy; 
    public float Seconds; 
    public int pvMultiplicator = 1; 
}

public class Spawner : MonoBehaviour
{
    // --- MAGIE : Cette variable est "static", ce qui veut dire que le script DragDrop2D peut la lire facilement ! ---
    public static bool jeuLance = false; 

    [Header("Configuration des Vagues")]
    [SerializeField] private Vague[] vagues; 
    [SerializeField] private float tempsEntreVagues = 5f; 
    [SerializeField] private GameObject BoutonDebut; 


    [Header("Points d'apparition")]
    [SerializeField] private Transform[] spawnPoints; 
    [SerializeField] private Transform[] TargetPoints; 
    [SerializeField] public Transform target;

    private FinDeNiveau scriptFin; 

    private void Awake()
    {
        // Sécurité : Quand on charge le niveau, le jeu n'est pas encore lancé
        jeuLance = false; 
    }

    void Start()
    {
        scriptFin = FindFirstObjectByType<FinDeNiveau>();
        // On a enlevé la coroutine d'ici pour qu'elle ne se lance pas toute seule !
    }

    // --- NOUVELLE FONCTION : Appelée par ton bouton UI "Lancer la partie" ---
    public void LancerLaPartie()
    {
            jeuLance = true; // On active l'interrupteur
            Debug.Log("La partie commence ! Les héros sont verrouillés.");
            StartCoroutine(LancerVaguesRoutine()); // On démarre enfin les vagues
            BoutonDebut.SetActive(false);
        
    }

    // L'ancien Start() est devenu une routine normale
    IEnumerator LancerVaguesRoutine()
    {
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
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinDeNiveau : MonoBehaviour
{
    [Header("UI de Fin")]
    public GameObject ecranVictoire; 

    [Header("Configuration Spawners")]

    public int nombreDeSpawnersTotal = 1; 
    
    private int spawnersTermines = 0;
    private bool niveauTermine = false;

    void Update()
    {
        if (spawnersTermines >= nombreDeSpawnersTotal && niveauTermine == false)
        {
            GameObject[] ennemisRestants = GameObject.FindGameObjectsWithTag("Enemy");

            if (ennemisRestants.Length == 0)
            {
                Victoire();
            }
        }
    }

    public void SignalerSpawnerTermine()
    {
        spawnersTermines++;
        Debug.Log("Un spawner a terminé ! Total terminés : " + spawnersTermines + "/" + nombreDeSpawnersTotal);
    }

    void Victoire()
    {
        niveauTermine = true;
        Debug.Log("VICTOIRE ! Tous les ennemis sont vaincus !");

        if (ecranVictoire != null)
        {
            ecranVictoire.SetActive(true); 
        }
    }

    public void RetourMenuSelection()
    {
        SceneManager.LoadScene("Select"); 
    }
}
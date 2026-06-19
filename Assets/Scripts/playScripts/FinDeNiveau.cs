using UnityEngine;
using UnityEngine.SceneManagement;
 using Firebase;
using Firebase.Auth;
using Firebase.Firestore;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;
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
    async void addShard()
    {
        FirebaseFirestore db = FirebaseFirestore.DefaultInstance;
        FirebaseAuth auth = FirebaseAuth.DefaultInstance;

        FirebaseUser user = auth.CurrentUser;
        if (user != null)
        {
            DocumentReference userRef = db.Collection("Users").Document(user.UserId);
            DocumentSnapshot snapshot = await userRef.GetSnapshotAsync();

            if (snapshot.Exists)
            {
                Dictionary<string, object> data = snapshot.ToDictionary();
                int currentShards = int.Parse(data["Shards"].ToString());
                currentShards += 100; 

                Dictionary<string, object> updates = new Dictionary<string, object>
                {
                    { "Shards", currentShards }
                };

                await userRef.UpdateAsync(updates);
                Debug.Log("Shard ajouté ! Total de shards : " + currentShards);
            }
        }
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
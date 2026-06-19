using UnityEngine;
using UnityEngine.SceneManagement;
 using Firebase;
using Firebase.Auth;
using Firebase.Firestore;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;
public class BuyScript : MonoBehaviour
{
    public int shardsToAdd ;
    public GameObject ShardsText;  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    async void addShard()
    {
        FirebaseFirestore db = FirebaseFirestore.DefaultInstance;
        FirebaseAuth auth = FirebaseAuth.DefaultInstance;

        FirebaseUser user = auth.CurrentUser;
        
        DocumentReference userRef = db.Collection("Users").Document(user.UserId);
        DocumentSnapshot snapshot = await userRef.GetSnapshotAsync();

        
        Dictionary<string, object> data = snapshot.ToDictionary();
        int currentShards = int.Parse(data["Shards"].ToString());
        currentShards += shardsToAdd; 

        Dictionary<string, object> updates = new Dictionary<string, object>
        {
            { "Shards", currentShards }
        };

        await userRef.UpdateAsync(updates);

        ShardsText.GetComponent<TextMeshProUGUI>().text = currentShards.ToString();
     }

}

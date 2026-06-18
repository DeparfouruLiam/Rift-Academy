using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Firestore;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;

public class InitShardsTB : MonoBehaviour
{
    public int shards;
    public GameObject txt; //I wanted to use this variable to hold the text, but as i said i couldn't reference it. There isn't exactly something like "public Text txt".

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    async void Start()
    {
        FirebaseFirestore db = FirebaseFirestore.DefaultInstance;

        FirebaseAuth auth = FirebaseAuth.DefaultInstance;

        if (auth.CurrentUser != null)
        {
            Debug.Log("CONNECTÉ");
        }

        DocumentSnapshot snapshot = null;
        FirebaseUser user = auth.CurrentUser;
        if (user != null)
        {

             snapshot =
                await db.Collection("Users")
                        .Document(user.UserId)
                        .GetSnapshotAsync();

            if (snapshot.Exists)
            {
                Dictionary<string, object> data = snapshot.ToDictionary();

                shards = int.Parse(data["Shards"].ToString());

            }
            txt.GetComponent<UnityEngine.UI.Text>().text = shards.ToString()+ " Shards";

        }
       
    }

    
}

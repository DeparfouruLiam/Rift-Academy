using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Firestore;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;

public class DisplayConnectedUser : MonoBehaviour
{
    [SerializeField] TMP_Text TextDisplay;
    [SerializeField] GameObject LoginButton;

    async void Start()
    {
        FirebaseAuth auth = FirebaseAuth.DefaultInstance;

        if (auth.CurrentUser != null)
        {
            Debug.Log("CONNECTÉ");
            LoginButton.SetActive(false);
        }


        FirebaseUser user = auth.CurrentUser;

        if (user != null)
        {
            FirebaseFirestore db = FirebaseFirestore.DefaultInstance;

            DocumentSnapshot snapshot =
                await db.Collection("Users")
                        .Document(user.UserId)
                        .GetSnapshotAsync();

            if (snapshot.Exists)
            {
                Dictionary<string, object> data = snapshot.ToDictionary();

                string pseudo = data["Pseudo"].ToString();

                TextDisplay.text = pseudo;
            }
        }
    }

    
}

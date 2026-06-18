using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Firestore;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;

public class InitBanner : MonoBehaviour
{
    public string Name;
    public string Description;
    public GameObject txtName; //I wanted to use this variable to hold the text, but as i said i couldn't reference it. There isn't exactly something like "public Text txt".
    public GameObject txtDescription; //I wanted to use this variable to hold the text, but as i said i couldn't reference it. There isn't exactly something like "public Text txt".

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    async void Start()
    {
        FirebaseFirestore db = FirebaseFirestore.DefaultInstance;

        DocumentSnapshot snapshot = null;
         
             snapshot =
                await db.Collection("Banners")
                        .Document("Banner1")
                        .GetSnapshotAsync();

            if (snapshot.Exists)
            {
                Dictionary<string, object> data = snapshot.ToDictionary();

                Description = data["Description"].ToString();
                txtDescription.GetComponent<TextMeshProUGUI>().text = Description;
                Name = data["Name"].ToString();
                txtName.GetComponent<UnityEngine.UI.Text>().text = Name;
            }
 
       
    }

    
}

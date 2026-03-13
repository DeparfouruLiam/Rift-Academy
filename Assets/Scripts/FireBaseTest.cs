using UnityEngine;
using Firebase.Firestore;
using System.Collections.Generic;

public class FireBaseTest : MonoBehaviour
{
    public void AddItem()
    {
        FirebaseFirestore db = FirebaseFirestore.DefaultInstance;

        Dictionary<string, object> inventory = new Dictionary<string, object>()
        {
            { "Items", "800 femboys" }
        };

        db.Collection("Inventory").Document("Player1").SetAsync(inventory);
    }
}

using UnityEngine;
using Firebase.Firestore;
using System.Threading.Tasks;
using UnityEngine.UI;
using TMPro;

public class FireBaseTestGet : MonoBehaviour
{   
    [SerializeField] GameObject textbox;

    public async void ClickUpdate()
    {
        await updateBDD();
    }
    public async Task updateBDD()
    {
        FirebaseFirestore db = FirebaseFirestore.DefaultInstance;

        DocumentSnapshot snapshot = await db.Collection("Inventory")
        .Document("Player1")
        .GetSnapshotAsync();

        if (snapshot.Exists)
        {
            string item = snapshot.GetValue<string>("Items");
            UnityEngine.Debug.Log(item);
            textbox.GetComponent<TMP_Text>().text = item;
        }

    }
}

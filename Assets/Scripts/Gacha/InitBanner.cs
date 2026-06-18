using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Firestore;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;
public class InitBanner : MonoBehaviour
{
    public string Name;
    public string Description;
    public GameObject txtName;  
    public GameObject txtDescription; 
    public GameObject HeroImg0;  
    public GameObject HeroImg1;  
    public GameObject HeroImg2;  
    public Sprite[] heroIcons;
    public string bannerHeroes;

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
                txtName.GetComponent<TextMeshProUGUI>().text = Name;
                bannerHeroes = data["Heroes"].ToString();
                HeroImg0.GetComponent<Image>().sprite = Resources.Load<Sprite>("Roaster/Hero" + bannerHeroes[0]+bannerHeroes[1]);
                HeroImg1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Roaster/Hero" + bannerHeroes[2]+bannerHeroes[3]);
                HeroImg2.GetComponent<Image>().sprite = Resources.Load<Sprite>("Roaster/Hero" + bannerHeroes[4]+bannerHeroes[5]);
            }
  
    }

    
}

using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Firestore;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
public class Roaster : MonoBehaviour
{
    public GameObject[] Panels;
    public GameObject heroPrefab;
    public Sprite[] heroIcons;
    HeroScript[] Heroes;
    int nbHeroes = 0;
    public GameObject heroPanel ;
    public GameObject mainPanel ;
    string strHeroes ;

    async void Start()
    {          
          FirebaseFirestore db = FirebaseFirestore.DefaultInstance;


        DocumentSnapshot snapshot = await db.Collection("GameStats")
            .Document("Stats")
            .GetSnapshotAsync();
            
        nbHeroes =  snapshot.GetValue<int>("HeroCount");

        FirebaseAuth auth = FirebaseAuth.DefaultInstance;

        if (auth.CurrentUser != null)
        {
            Debug.Log("CONNECTÉ");
        }


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

                 strHeroes = data["HeroesConst"].ToString();

            }
        }
        print("nbHeroes: " + nbHeroes);
        heroIcons = new Sprite[nbHeroes];
        for(int i=0; i<nbHeroes; i++){
            heroIcons[i] = Resources.Load<Sprite>("Roaster/Hero" + (i).ToString("D2")  );
            print("Roaster/Hero" + (i).ToString("D2")  );

        }
        Heroes = new HeroScript[nbHeroes];

        InitiateConstellations();
        heroPanel.SetActive(false);
        Debug.Log("Roaster initialized");
    }

    public void InitiateConstellations()
    {
        Heroes =  new HeroScript[nbHeroes];
        for (int i = 0; i < nbHeroes; i++)
        {
            Heroes[i] = new HeroScript(); 
            Heroes[i].constellation = int.Parse(strHeroes[i*2].ToString() + strHeroes[i*2+1].ToString());
            Heroes[i].type = 0;
            Heroes[i].heroName = "Hero " + i;
            Heroes[i].atk = i;
            Heroes[i].def = i;
            Heroes[i].lck = i;
            Heroes[i].vit = i;
            Heroes[i].icon = heroIcons[i];
            Debug.Log(i);
            
            if (Heroes[i].constellation > 0)
            {
                GameObject panel = Panels[Heroes[i].type];

                GameObject newHero = Instantiate(heroPrefab, panel.transform);
                newHero.GetComponent<HeroUI>().Setup(Heroes[i], heroIcons[i]);
                newHero.GetComponent<HeroScript>().Setup(Heroes[i], heroIcons[i]);
                newHero.GetComponent<OpenHeroView>().Setup(heroPanel, mainPanel, newHero.GetComponent<HeroScript>(),i);
            }
        }
    }
}
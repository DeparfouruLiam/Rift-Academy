using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Firestore;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;
public class InvocationScript : MonoBehaviour
{
    public int invocationCount;
    public GameObject ShowcasePanel;
    public string bannerHeroes;
    public string PlayerHeroes;
    public string newPlayerHeroes;
    public int shards;
     public GameObject SlotParent;
    public GameObject InactiveSlotParent;

    public GameObject InitShardsTB ;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public async void Invocation()
    {
        FirebaseFirestore db = FirebaseFirestore.DefaultInstance;

        FirebaseAuth auth = FirebaseAuth.DefaultInstance;

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
                PlayerHeroes = data["HeroesConst"].ToString();
            }
        }

        if(shards >= invocationCount*10)
        {
                ShowcasePanel.SetActive(true);
                 snapshot =
                    await db.Collection("Banners")
                            .Document("Banner1")
                            .GetSnapshotAsync();

                if (snapshot.Exists)
                {
                    Dictionary<string, object> data = snapshot.ToDictionary();

                    
                    bannerHeroes = data["Heroes"].ToString();
                    
                }
                Dictionary<string, object> updates = new Dictionary<string, object>();
                newPlayerHeroes = PlayerHeroes;
                 
                SlotParent.SetActive(true);
                InactiveSlotParent.SetActive(false);

                for (int i = 0; i < invocationCount; i++)
                {
                    
                    int tmp = Random.Range(0, 10000);

                    int heroId;

                    if (tmp < 1000)
                    {
                        heroId = int.Parse($"{bannerHeroes[0]}{bannerHeroes[1]}");
                    }
                    else if (tmp < 5500)
                    {
                        heroId = int.Parse($"{bannerHeroes[2]}{bannerHeroes[3]}");
                    }
                    else
                    {
                        heroId = int.Parse($"{bannerHeroes[4]}{bannerHeroes[5]}");
                    }

                    // Debug.Log("Roll: " + tmp);
                    // Debug.Log("Banner Heroes: " + bannerHeroes);
                    // Debug.Log("Hero ID: " + heroId);
                    // Debug.Log("PlayerHeroes: " + PlayerHeroes);

                    int index = heroId * 2;

                    int currentCount = int.Parse(newPlayerHeroes.Substring(index, 2));

                    currentCount++;

                    currentCount = Mathf.Min(currentCount, 99);

                    string newCount = currentCount.ToString("D2");
                    newPlayerHeroes =
                    newPlayerHeroes.Substring(0, index)
                    + newCount
                    + newPlayerHeroes.Substring(index + 2);

                        GameObject child = SlotParent.transform.GetChild(i).gameObject;
                  

                        Image image = child.GetComponentInChildren<Image>();
                        image.sprite = Resources.Load<Sprite>(
                        "Roaster/Hero" + heroId.ToString("D2")
                        );


                        TextMeshProUGUI nameText =
                            child.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
                        nameText.text = "Hero " + heroId.ToString("D2");

                        TextMeshProUGUI countText =
                        child.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
                        if (newCount == "01")
                        {
                            countText.text = "New Hero!";
                        }
                        else
                        {
                            countText.text = "Const " + currentCount.ToString();
                        }
                }
               
                updates = new Dictionary<string, object>()
                {
                    { "HeroesConst", newPlayerHeroes },
                    { "Shards", shards - invocationCount * 10 }
                };

                await db.Collection("Users")
                        .Document(user.UserId)
                        .UpdateAsync(updates);

                 
                InitShardsTB.GetComponent<InitShardsTB>().Start();
         }
    }
}


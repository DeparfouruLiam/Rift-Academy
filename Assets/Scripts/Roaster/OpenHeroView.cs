using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Firestore;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;
public class OpenHeroView : MonoBehaviour
{
     public GameObject heroPanel ;
     public GameObject mainPanel ;
     public HeroScript hero;
     public HeroCanvaComponents heroComponents;
     public int heroid;
     public void OpenHeroViewClick()
    {
        heroPanel.SetActive(true);
        mainPanel.SetActive(false);
        Debug.Log("ok");
        // gameObject.GetComponent<Image>().color = Color.aquamarine;
        // SceneManager.LoadScene(TargetScene);
        CustomizeHeroView();
    }
    public void Setup(GameObject tmphero, GameObject all, HeroScript tmpheroscript, int id, GameObject mainPanel)
    {
        heroPanel = tmphero;
        this.mainPanel = mainPanel  ;
        hero = tmpheroscript;
        heroid = id;
    }

    public void CustomizeHeroView()
    {
        
                    heroPanel.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(
                    "Roaster/Hero" + heroid.ToString("D2")
                        );

        heroPanel.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = hero.heroName;
        heroPanel.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = hero.constellation.ToString();
        heroPanel.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text = hero.atk.ToString()+" Atk " ;
        heroPanel.transform.GetChild(4).gameObject.GetComponent<TextMeshProUGUI>().text = hero.def.ToString()+" Def " ;
        heroPanel.transform.GetChild(5).gameObject.GetComponent<TextMeshProUGUI>().text = hero.lck.ToString()+" Lck " ;
        heroPanel.transform.GetChild(6).gameObject.GetComponent<TextMeshProUGUI>().text = hero.type.ToString()+" Type " ;
        heroPanel.transform.GetChild(7).gameObject.GetComponent<TextMeshProUGUI>().text = hero.vit.ToString()+" Vit " ;

        mainPanel.SetActive(true);
        // heroComponents = heroPanel.GetComponent<HeroCanvaComponents>();
        // heroComponents.constellation.GetComponentInChildren<Text>().text = "Tier " + hero.constellation.ToString();
        // heroComponents.heroName.GetComponentInChildren<Text>().text =  hero.heroName.ToString()  ;
        // heroComponents.atk.GetComponentInChildren<Text>().text =  hero.atk.ToString()+" Atk " ;
        // heroComponents.def.GetComponentInChildren<Text>().text =  hero.def.ToString()+" Def " ;
        // heroComponents.lck.GetComponentInChildren<Text>().text = hero.lck.ToString()+" Lck " ;
        // heroComponents.type.GetComponentInChildren<Text>().text= hero.type.ToString()+" Type " ;
        // heroComponents.vit.GetComponentInChildren<Text>().text =  hero.vit.ToString()+" Vit " ;
        // heroComponents.icon.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Roaster/Hero" + (heroid).ToString("D2")  );
    }

    
}
    
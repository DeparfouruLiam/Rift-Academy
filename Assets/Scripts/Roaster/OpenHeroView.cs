using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpenHeroView : MonoBehaviour
{
     public GameObject heroPanel ;
     public GameObject mainPanel ;
     public HeroScript hero;
     public HeroCanvaComponents heroComponents;
    public void OpenHeroViewClick()
    {
        heroPanel.SetActive(true);
        mainPanel.SetActive(false);
        Debug.Log("ok");
        // gameObject.GetComponent<Image>().color = Color.aquamarine;
        // SceneManager.LoadScene(TargetScene);
        CustomizeHeroView();
    }
    public void Setup(GameObject tmphero, GameObject all, HeroScript tmpheroscript)
    {
        heroPanel = tmphero;
        mainPanel = all;
        hero = tmpheroscript;
    }

    public void CustomizeHeroView()
    {
        heroComponents = heroPanel.GetComponent<HeroCanvaComponents>();
        heroComponents.constellation.GetComponentInChildren<Text>().text = "Tier " + hero.constellation.ToString();
        heroComponents.heroName.GetComponentInChildren<Text>().text =  hero.heroName.ToString()  ;
        heroComponents.atk.GetComponentInChildren<Text>().text =  hero.atk.ToString()+" Atk " ;
        heroComponents.def.GetComponentInChildren<Text>().text =  hero.def.ToString()+" Def " ;
        heroComponents.lck.GetComponentInChildren<Text>().text = hero.lck.ToString()+" Lck " ;
        heroComponents.type.GetComponentInChildren<Text>().text = hero.type.ToString()+" Type " ;
        heroComponents.vit.GetComponentInChildren<Text>().text =  hero.vit.ToString()+" Vit " ;
        heroComponents.icon.GetComponentInChildren<Image>().sprite = hero.icon;
    }

    
}

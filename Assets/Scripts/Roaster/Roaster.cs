using UnityEngine;

public class Roaster : MonoBehaviour
{
    public GameObject[] Panels;
    public GameObject heroPrefab;
    public Sprite[] heroIcons;
    HeroScript[] Heroes;
    int nbHeroes = 0;
    public GameObject heroPanel ;
    public GameObject mainPanel ;
    string test = "010203";

    void Start()
    {
        nbHeroes = test.Length / 2;
        heroIcons = new Sprite[nbHeroes];
        for(int i=0; i<nbHeroes; i++){
            heroIcons[i] = Resources.Load<Sprite>("Roaster/Hero" + i);
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
            Heroes[i].constellation = int.Parse(test[i*2].ToString() + test[i*2+1].ToString());
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
                newHero.GetComponent<OpenHeroView>().Setup(heroPanel, mainPanel, newHero.GetComponent<HeroScript>());
            }
        }
    }
}
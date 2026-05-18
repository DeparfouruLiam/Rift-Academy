using UnityEngine;

public class HeroScript : MonoBehaviour
{
    public int id;
    public string heroName;
    public Sprite icon;
    public int constellation;
    public int type;
    public int atk;
    public int def;
    public int vit;
    public int lck;
      public void Setup(HeroScript hero, Sprite sprite)
{
    id = hero.id;
    heroName = hero.heroName;
    icon = hero.icon;
    constellation = hero.constellation;
    type = hero.type;
    atk = hero.atk;
    def = hero.def;
    vit = hero.vit;
    lck = hero.lck;
}
}

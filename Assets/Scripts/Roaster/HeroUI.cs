using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HeroUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Image icon;
    public Text constellation;
    public void Setup(HeroScript hero, Sprite sprite)
{
    icon.sprite = sprite;
    constellation.text ="Tier " +hero.constellation.ToString();
    constellation.gameObject.SetActive(hero.constellation > 1);
}
}

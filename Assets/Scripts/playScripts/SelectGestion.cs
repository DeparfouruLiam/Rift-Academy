using UnityEngine;
using UnityEngine.UI;

public class SelectGestion : MonoBehaviour
{
    public SlotHero[] slotsEquipe;

    public void SelectionnerHero(Button personnageClique)
    {
        for (int i = 0; i < slotsEquipe.Length; i++)
        {
            
            if (slotsEquipe[i].estOccupe == false)
            {
                Image imageDuPersoClique = personnageClique.GetComponent<Image>();
              
                Image imageDuSlot = slotsEquipe[i].GetComponent<Image>();
               
                imageDuSlot.sprite = imageDuPersoClique.sprite;

                imageDuSlot.color = Color.white;

                slotsEquipe[i].estOccupe = true;

                personnageClique.interactable = false;

                imageDuPersoClique.color = new Color(1f, 1f, 1f, 0.3f);
                return;
            }
        }

        Debug.Log("Équipe pleine ou action impossible !");
    }
}
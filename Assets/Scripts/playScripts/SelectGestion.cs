using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement; 

public class SelectGestion : MonoBehaviour
{
    public SlotHero[] slotsEquipe;
    
    [SerializeField] private DataEquipe dataGlobale; 

    public void SelectionnerHero() 
    {
        GameObject objetClique = EventSystem.current.currentSelectedGameObject;
        if (objetClique == null) return;

        Button personnageClique = objetClique.GetComponent<Button>();
        // On récupère le script qui contient ton vrai Prefab !
        BoutonHeroUI infoHero = objetClique.GetComponent<BoutonHeroUI>(); 
        
        if (personnageClique == null || infoHero == null) return;

        for (int i = 0; i < slotsEquipe.Length; i++)
        {
            if (slotsEquipe[i].estOccupe == false)
            {
                Image imageDuPersoClique = personnageClique.GetComponent<Image>();
                Image imageDuSlot = slotsEquipe[i].GetComponent<Image>();

                imageDuSlot.sprite = imageDuPersoClique.sprite;
                imageDuSlot.color = Color.white;
                slotsEquipe[i].estOccupe = true;

                // --- LA CORRECTION EST ICI ---
                // On sauvegarde le PREFAB (GameObject) et non plus le Sprite !
                if (dataGlobale != null)
                {
                    dataGlobale.herosChoisis[i] = infoHero.prefabDuHero;
                }

                personnageClique.interactable = false;
                imageDuPersoClique.color = new Color(1f, 1f, 1f, 0.3f);
                return;
            }
        }
    }

    public void RetirerHero()
    {
        GameObject slotClique = EventSystem.current.currentSelectedGameObject;
        if (slotClique == null) return;

        SlotHero scriptSlot = slotClique.GetComponent<SlotHero>();
        if (scriptSlot == null || scriptSlot.estOccupe == false) return;

        for (int i = 0; i < slotsEquipe.Length; i++)
        {
            if (slotsEquipe[i].gameObject == slotClique)
            {
                if (dataGlobale != null)
                {
                    dataGlobale.herosChoisis[i] = null; // On vide le Prefab
                }
            }
        }

        Image imageDuSlot = slotClique.GetComponent<Image>();
        imageDuSlot.sprite = null; 
        scriptSlot.estOccupe = false;
    }

    public void LancerNiveau(string nomDuNiveau)
    {
        SceneManager.LoadScene(nomDuNiveau);
    }
}
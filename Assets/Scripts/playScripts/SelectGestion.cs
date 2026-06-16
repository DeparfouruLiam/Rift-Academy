using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement; // <-- AJOUTÉ pour pouvoir changer de scène

public class SelectGestion : MonoBehaviour
{
    public SlotHero[] slotsEquipe;
    
    [Header("Sauvegarde")]
    [SerializeField] private DataEquipe dataGlobale; // Glisse le fichier "SauvegardeEquipe" ici

    public void SelectionnerHero() 
    {
        GameObject objetClique = EventSystem.current.currentSelectedGameObject;
        if (objetClique == null) return;

        Button personnageClique = objetClique.GetComponent<Button>();
        if (personnageClique == null) return;

        for (int i = 0; i < slotsEquipe.Length; i++)
        {
            if (slotsEquipe[i].estOccupe == false)
            {
                Image imageDuPersoClique = personnageClique.GetComponent<Image>();
                Image imageDuSlot = slotsEquipe[i].GetComponent<Image>();

                imageDuSlot.sprite = imageDuPersoClique.sprite;
                imageDuSlot.color = Color.white;
                slotsEquipe[i].estOccupe = true;

                // --- SAUVEGARDE ---
                dataGlobale.herosChoisis[i] = imageDuPersoClique.sprite;

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

        // Trouver l'index du slot cliqué pour nettoyer la sauvegarde au bon endroit
        for (int i = 0; i < slotsEquipe.Length; i++)
        {
            if (slotsEquipe[i].gameObject == slotClique)
            {
                // --- NETTOYAGE SAUVEGARDE ---
                dataGlobale.herosChoisis[i] = null; 
            }
        }

        Image imageDuSlot = slotClique.GetComponent<Image>();
        imageDuSlot.sprite = null; 
        scriptSlot.estOccupe = false;
    }

    // --- NOUVELLE FONCTION POUR TON BOUTON COMBAT ---
    public void LancerNiveau(string nomDuNiveau)
    {
        // On charge la scène de combat (ex: "Level1")
        SceneManager.LoadScene(nomDuNiveau);
    }
}
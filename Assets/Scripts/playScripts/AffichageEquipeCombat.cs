using UnityEngine;
using UnityEngine.UI;

public class AffichageEquipeCombat : MonoBehaviour
{
    [SerializeField] private DataEquipe dataGlobale; // Glisse le MÊME fichier "SauvegardeEquipe"
    [SerializeField] private Image[] boutonsAchatCombat; // Tes 5 boutons d'UI du combat

    void Start()
    {
        if (dataGlobale == null)
        {
            Debug.LogError("Il manque le fichier de sauvegarde sur " + gameObject.name);
            return;
        }

        // On applique les sprites sauvegardés sur les boutons du niveau
        for (int i = 0; i < boutonsAchatCombat.Length; i++)
        {
            if (dataGlobale.herosChoisis[i] != null)
            {
                boutonsAchatCombat[i].sprite = dataGlobale.herosChoisis[i];
                boutonsAchatCombat[i].color = Color.white;
                boutonsAchatCombat[i].gameObject.SetActive(true);
            }
            else
            {
                // Si le slot était vide, on cache le bouton pour ce combat
                boutonsAchatCombat[i].gameObject.SetActive(false);
            }
        }
    }
}
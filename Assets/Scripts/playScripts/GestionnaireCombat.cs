using UnityEngine;

public class GestionnaireCombat : MonoBehaviour
{
    [Header("Données d'Équipe")]
    [SerializeField] private DataEquipe sauvegardeEquipe; // Glisse ton fichier "SauvegardeEquipe" ici

    void Start()
    {
        Debug.Log("Chargement de la Default Team...");
        
        // On parcourt les 5 slots de la Default Team sauvegardée
        for (int i = 0; i < sauvegardeEquipe.herosChoisis.Length; i++)
        {
            if (sauvegardeEquipe.herosChoisis[i] != null)
            {
                Debug.Log("Héros " + i + " chargé : " + sauvegardeEquipe.herosChoisis[i].name);
                
                // ICI : Tu feras ce que tu veux avec ton héros actif.
                // Par exemple, l'afficher sur tes boutons d'invocation en combat,
                // ou le faire apparaître directement sur la map.
            }
            else
            {
                Debug.Log("Le slot " + i + " de la Default Team est vide.");
            }
        }
    }
}
using UnityEngine;
using UnityEngine.UI;

public class AffichageEquipeCombat : MonoBehaviour
{
    [SerializeField] private DataEquipe dataGlobale; 
    [SerializeField] private Image[] boutonsAchatCombat; 
    
    [Header("Où faire apparaître les héros ?")]
    public Transform pointDApparition; // L'endroit où le héros spawn avant qu'on le drag

    void Start()
    {
        for (int i = 0; i < boutonsAchatCombat.Length; i++)
        {
            GameObject prefabSauvegarde = dataGlobale.herosChoisis[i];

            if (prefabSauvegarde != null)
            {
                SpriteRenderer spriteDuPrefab = prefabSauvegarde.GetComponent<SpriteRenderer>();

                if (spriteDuPrefab != null)
                {
                    boutonsAchatCombat[i].sprite = spriteDuPrefab.sprite;
                    boutonsAchatCombat[i].color = Color.white;
                }
                
                boutonsAchatCombat[i].gameObject.SetActive(true);
            }
            else
            {
                boutonsAchatCombat[i].gameObject.SetActive(false);
            }
        }
    }

    public void InvoquerHero(int indexDuBouton)
    {
        GameObject prefabAInvoquer = dataGlobale.herosChoisis[indexDuBouton];

        if (prefabAInvoquer != null)
        {
            Instantiate(prefabAInvoquer, pointDApparition.position, Quaternion.identity);
            Debug.Log("Héros invoqué ! Tu peux maintenant le Drag & Drop.");
        }
    }
}
using UnityEngine;
using UnityEngine.UI;

public class AffichageEquipeCombat : MonoBehaviour
{
    [SerializeField] private DataEquipe dataGlobale; 
    [SerializeField] private Image[] boutonsAchatCombat; 
    
    public Transform pointDApparition; 

    // NOUVEAU : Un tableau pour mémoriser les héros déjà invoqués sur la map
    private GameObject[] herosInvoques = new GameObject[5];

    void Start()
    {
        for (int i = 0; i < boutonsAchatCombat.Length; i++)
        {
            if (dataGlobale.herosChoisis[i] != null)
            {
                SpriteRenderer spriteDuPrefab = dataGlobale.herosChoisis[i].GetComponent<SpriteRenderer>();

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
    public void ActionBoutonHero(int indexDuBouton)
    {
        if (herosInvoques[indexDuBouton] == null)
        {
            GameObject prefabAInvoquer = dataGlobale.herosChoisis[indexDuBouton];

            if (prefabAInvoquer != null)
            {
                herosInvoques[indexDuBouton] = Instantiate(prefabAInvoquer, pointDApparition.position, Quaternion.identity);
                Debug.Log("Héros invoqué ! (Il ne peut plus être invoqué en double)");
            }
        }
        else
        {
            Ultimate scriptUlti = herosInvoques[indexDuBouton].GetComponent<Ultimate>();
            
            if (scriptUlti != null)
            {
                scriptUlti.LancerUltiDepuisUI();
            }
        }
    }
}
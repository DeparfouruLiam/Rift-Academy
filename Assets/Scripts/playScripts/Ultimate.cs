using UnityEngine;
using System.Collections; 

public class Ultimate : MonoBehaviour
{
    [SerializeField] private float ultimateDuration = 5f; 

    private bool isUltimateActive = false;
    
    private HeroAttack heroAttack;
    private DragDrop2D dragScript;

    void Start()
    {
        heroAttack = GetComponent<HeroAttack>();
        dragScript = GetComponent<DragDrop2D>();
    }

    public void LancerUltiDepuisUI() 
    {
        if (dragScript != null && dragScript.onCase == true)
        {
            if (!isUltimateActive) 
            {
                Debug.Log("Ultimate activé depuis le bouton UI !");
                StartCoroutine(UltimateTimerRoutine());
            }
            else
            {
                Debug.Log("L'ulti est déjà en cours ou en rechargement !");
            }
        }
        else
        {
            Debug.Log("Impossible de lancer l'ulti : le héros n'est pas encore posé !");
        }
    }

    private IEnumerator UltimateTimerRoutine() 
    {
        isUltimateActive = true;

        if (heroAttack != null) 
        {
            heroAttack.ultimateUp = true;
            yield return new WaitForSeconds(ultimateDuration);
        }
        
        isUltimateActive = false;
    }
}
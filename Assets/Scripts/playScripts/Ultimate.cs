using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections; 

public class Ultimate : MonoBehaviour, IPointerClickHandler
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
    public void OnPointerClick(PointerEventData eventData) 
    {
        if (dragScript != null && dragScript.onCase == true)
        {
            if (!isUltimateActive) 
            {
                Debug.Log("Ultimate activé en cliquant sur le Sprite !");
                StartCoroutine(UltimateTimerRoutine());
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
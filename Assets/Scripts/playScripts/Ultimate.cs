using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections; 

public class Ultimate : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject hero;
    [SerializeField] private float ultimateDuration = 5f; 

    private bool isUltimateActive = false;

    public void OnPointerClick(PointerEventData eventData) 
    {
        if (!isUltimateActive) 
        {
            Debug.Log("Ultimate activé !");
            StartCoroutine(UltimateTimerRoutine());
        }
    }

    private IEnumerator UltimateTimerRoutine() 
    {
        isUltimateActive = true;
        HeroAttack heroAttack = hero.GetComponent<HeroAttack>();

        if (heroAttack != null) 
        {
            heroAttack.ultimateUp = true;
            yield return new WaitForSeconds(ultimateDuration);
            heroAttack.ultimateUp = false;
        }
        
        isUltimateActive = false;
    }
}
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ultimate : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject hero;
    public void OnPointerClick(PointerEventData eventData) {
        Debug.Log("gooning");
        hero.GetComponent<HeroAttack>().ultimateUp = true;
    }
    
}

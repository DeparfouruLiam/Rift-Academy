using System.Collections;
using UnityEngine;

public class HeroAttack : MonoBehaviour
{
    public bool ultimateUp = false;
    private Animator anim;
    private CharacterObject characterObject;

    IEnumerator Start()
    {
        anim = gameObject.GetComponent<Animator>();
        characterObject = gameObject.GetComponent<CharacterObject>();
        while (true)
        {
            if (gameObject.GetComponent<DragDrop2D>().onCase){
                anim.SetTrigger("Attack");
            
        }
        float attackSpeed = characterObject != null ? 1f / characterObject.currentVitesseAttaque : 1f;
        yield return new WaitForSeconds(attackSpeed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<DragDrop2D>().onCase){
            if (ultimateUp)
            {
                anim.SetTrigger("Ultimate");
                ultimateUp = false;
            }
        }
    }
}
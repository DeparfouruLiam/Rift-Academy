using System.Collections;
using UnityEngine;

public class HeroAttack : MonoBehaviour
{
    public bool ultimateUp = false;
    private Animator anim;
    private CharacterObject characterObject;
    private bool isAttacking = false;

    private void Awake()
    {
        characterObject = GetComponent<CharacterObject>();
        anim = GetComponent<Animator>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator Start()
    {
        while (true)
        {
            DragDrop2D dragDrop = GetComponent<DragDrop2D>();
            if (dragDrop != null && dragDrop.onCase && characterObject != null && !isAttacking)
            {
                float attackSpeed = GetAttackSpeed();
                anim.SetTrigger("Attack");
                isAttacking = true;
                yield return new WaitForSeconds(attackSpeed);
                isAttacking = false;
            }
            else
            {
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    private float GetAttackSpeed()
    {
        if (characterObject == null) return 1f;
        return characterObject.currentVitesseAttaque > 0 ? 1f / characterObject.currentVitesseAttaque : 1f;
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

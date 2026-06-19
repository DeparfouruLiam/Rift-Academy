using System.Collections;
using UnityEngine;

public class HeroAttack : MonoBehaviour
{
     public bool ultimateUp = false;
    private Animator anim;
    public float AttackSpeedModifier = 1;
    private Coroutine AttSpeedCoroutine;
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
        yield return new WaitForSeconds(attackSpeed*AttackSpeedModifier);
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

    public void AttSpeBuff(float BuffLevel, float BuffDuration)
    {
        if (AttSpeedCoroutine != null)
            {
                StopCoroutine(AttSpeedCoroutine);
            }
        AttSpeedCoroutine = StartCoroutine(BuffDebuffCoroutine(BuffLevel,BuffDuration));
    }

    IEnumerator BuffDebuffCoroutine(float BuffLevel, float BuffDuration)
    {
        Debug.Log(BuffDuration);
        AttackSpeedModifier = BuffLevel;
        yield return new WaitForSeconds(BuffDuration+0.1f);
        Debug.Log("EndDebuff");
        AttackSpeedModifier=1;
    }
}


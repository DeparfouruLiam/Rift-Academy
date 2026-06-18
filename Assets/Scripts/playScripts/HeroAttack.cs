using System.Collections;
using UnityEngine;

public class HeroAttack : MonoBehaviour
{
    [SerializeField] public float AttackSpeed;

    public bool ultimateUp = false;
    private Animator anim;
    public float AttackSpeedModifier = 1;
    private Coroutine AttSpeedCoroutine;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator Start()
    {
        anim = gameObject.GetComponent<Animator>();
        while (true)
        {
            if (gameObject.GetComponent<DragDrop2D>().onCase){
                anim.SetTrigger("Attack");
            
        }
        yield return new WaitForSeconds(AttackSpeed*AttackSpeedModifier);
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


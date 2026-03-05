using System.Collections;
using UnityEngine;

public class HeroAttack : MonoBehaviour
{
    [SerializeField] float AttackSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator Start()
    {
        Animator anim = gameObject.GetComponent<Animator>();
        while (true)
        {
            yield return new WaitForSeconds(AttackSpeed);
            anim.SetTrigger("Attack");
            Debug.Log("AAAAAAAAAAAA");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

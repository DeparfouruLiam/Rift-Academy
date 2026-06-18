using System.Collections;
using UnityEngine;

public class HeroAttack : MonoBehaviour
{
    [SerializeField] float AttackSpeed;

    public bool ultimateUp = false;
    private Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator Start()
    {
        anim = gameObject.GetComponent<Animator>();
        while (true)
        {
            if (gameObject.GetComponent<DragDrop2D>().onCase){
                anim.SetTrigger("Attack");
            
        }
        yield return new WaitForSeconds(AttackSpeed);
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

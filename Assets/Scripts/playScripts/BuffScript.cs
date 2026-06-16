using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffScript : MonoBehaviour
{
    [SerializeField] float BuffDuration;
    private Animator anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    public void BuffSelf()
    {
        StartCoroutine(BuffCoroutine());
    }

    IEnumerator BuffCoroutine() {
        anim.SetBool("UltBuff",true);
        GetComponent<SpriteRenderer>().color = new Color (1f,1f,0.26f,1);
        yield return new WaitForSeconds(BuffDuration);
        GetComponent<SpriteRenderer>().color = new Color (1f,1f,1f,1);
        anim.SetBool("UltBuff",false);
    }
}

using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public int HP = 1;
    [SerializeField] GameObject HitEffect;

    public void IsHit(int Damage)
    {
        Debug.Log("aaaaaaaaaaaaaaaaaaaaaaantm");
        StartCoroutine(DamageColor());
        Instantiate(HitEffect,gameObject.transform.position,Quaternion.identity);
        HP -= Damage;
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator DamageColor()
    {
        GetComponent<SpriteRenderer>().color = new Color (1f,0.7f,0.7f,1);
        yield return new WaitForSeconds(0.05f);
        GetComponent<SpriteRenderer>().color = new Color (1f,1f,1f,1);
    }
}

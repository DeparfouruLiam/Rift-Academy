using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int damage = 10;
    private bool hasHit = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasHit) return;
        
        if (collision.gameObject.layer == 0) return;

        heroHp targetHp = collision.GetComponent<heroHp>();
        if (targetHp != null)
        {
            hasHit = true;
            targetHp.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}

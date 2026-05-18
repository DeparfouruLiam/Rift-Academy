using UnityEngine;

public class HeroHitbox : MonoBehaviour
{
    [SerializeField] int Damage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<Health>().HP -= Damage;
        if (collision.GetComponent<Health>().HP <= 0)
        {
            Destroy(collision.gameObject);
        }   
        
    }
}

using UnityEngine;

public class HeroHitbox : MonoBehaviour
{
    [SerializeField] int Damage;

    private ProjectileMovement ProjectileScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ProjectileScript = GetComponent<ProjectileMovement>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<Health>().HP -= Damage;
        if (collision.GetComponent<Health>().HP <= 0)
        {
            Destroy(collision.gameObject);
        }
        if (ProjectileScript!=null)
        {
            if (ProjectileScript.Pierce<1)
            {
                Destroy(gameObject);
            }
            ProjectileScript.Pierce -=1;
        }
    }
}

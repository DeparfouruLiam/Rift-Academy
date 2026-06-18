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
        if (ProjectileScript!=null)
        {
            Debug.Log(ProjectileScript.target);
            if (ProjectileScript.target != null)
            {
                ProjectileScript.UpdateTarget();
            }
            if (ProjectileScript.Pierce<1)
            {
                ProjectileScript.LastHit();
            }
            ProjectileScript.Pierce -=1;
        }
        collision.GetComponent<Health>().IsHit(Damage);
    }
}

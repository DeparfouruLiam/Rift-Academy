using UnityEngine;

public class HeroHitbox : MonoBehaviour
{
    [SerializeField] private LayerMask enemyLayer;

    private ProjectileMovement ProjectileScript;
    private CharacterObject characterObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ProjectileScript = GetComponent<ProjectileMovement>();
        characterObject = GetComponentInParent<CharacterObject>();
        if (characterObject == null)
        {
            Debug.Log("CharacterObject non trouvé pour ce petit conard de " + gameObject.name);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (ProjectileScript != null)
        {
            Debug.Log(ProjectileScript.target);
            if (ProjectileScript.target != null)
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
            if (ProjectileScript.Pierce < 1)
            {
                ProjectileScript.LastHit();
            }
            ProjectileScript.Pierce -= 1;
        }

        int damage = characterObject != null ? characterObject.GetDamageWithCritical() : 0;
        Health targetHealth = collision.GetComponent<Health>();
        if (targetHealth != null)
        {
            targetHealth.IsHit(damage);
        }
    }
}


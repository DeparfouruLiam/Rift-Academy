using UnityEngine;

public class SeekingHitbox : MonoBehaviour
{
    public GameObject Seeker;
    [SerializeField] private LayerMask enemyLayer;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.layer);
        if ((enemyLayer.value & (1 << collision.gameObject.layer)) != 0)
        {
            Seeker.GetComponent<SpawnProjectile>().target = collision.gameObject;
            Destroy(gameObject);
        }
        
    }
}

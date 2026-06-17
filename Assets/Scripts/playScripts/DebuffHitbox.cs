using UnityEngine;

public class DebuffHitbox : MonoBehaviour
{
    [SerializeField] LayerMask EnemyLayer;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == EnemyLayer)
        {
            Debug.Log("Lent ta mère");
        }
    }
}

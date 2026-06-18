using UnityEngine;

public class VacuumHitbox : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        Vector3 pos = collision.transform.position;
        pos.y = transform.position.y;
        collision.transform.position = pos;
        pos.x = transform.position.x-100;
        collision.GetComponent<EnemyMovement>().target = pos;
    }
}

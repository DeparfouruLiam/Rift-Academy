using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] public int Pierce;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x >= 30)
        {
            Destroy(gameObject);
        }
        Vector3 pos = gameObject.transform.position;
        pos.x = 35;
        transform.position = Vector3.MoveTowards(transform.position, pos, speed*Time.deltaTime);
    }
}

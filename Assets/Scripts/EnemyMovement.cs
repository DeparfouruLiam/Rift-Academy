using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] public Transform target;
    [SerializeField] float speed;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed*Time.deltaTime);
        
    }
}

using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class ScrollingBg : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject PresetBg;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x <= -25)
        {
            Instantiate(PresetBg,new Vector3 (24.76f,0,0),quaternion.identity);
            Destroy(gameObject);
        }
        transform.position = Vector3.MoveTowards(transform.position, new Vector3 (-25,0,0), speed*Time.deltaTime);
    }
}

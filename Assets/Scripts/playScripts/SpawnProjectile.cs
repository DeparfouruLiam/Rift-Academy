
using UnityEngine;

public class SpawnProjectile : MonoBehaviour
{
    [SerializeField] GameObject PresetProjo;
    [SerializeField] GameObject PresetProjoUlt;
    [SerializeField] GameObject PresetProjoSeek;
    [SerializeField] float SpawnOffset;
    public GameObject target;

    // Update is called once per frame

    
    public void Spawn()
    {
        Vector3 pos = gameObject.transform.position;
        pos.x += SpawnOffset;
        var SpawnedProjo = Instantiate(PresetProjo,pos,Quaternion.identity);
        SpawnedProjo.GetComponent<ProjectileMovement>().Spawner = gameObject;
        if (target != null)
        {
            SpawnedProjo.GetComponent<ProjectileMovement>().target = target;
        }
    }

    public void SpawnUlt()
    {
        Vector3 pos = gameObject.transform.position;
        pos.x += SpawnOffset;
        var SpawnedProjo = Instantiate(PresetProjoUlt,pos,Quaternion.identity);
        SpawnedProjo.GetComponent<ProjectileMovement>().Spawner = gameObject;
        if (target != null)
        {
            SpawnedProjo.GetComponent<ProjectileMovement>().target = target;
        }
    }

    public void SpawnSeek()
    {
        Vector3 pos = gameObject.transform.position;
        pos.x += SpawnOffset;
        var SpawnedProjo = Instantiate(PresetProjoSeek,pos,Quaternion.identity);
        SpawnedProjo.GetComponent<SeekingHitbox>().Seeker = gameObject;
    }
    
}

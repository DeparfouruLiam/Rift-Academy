
using UnityEngine;

public class SpawnProjectile : MonoBehaviour
{
    [SerializeField] GameObject PresetProjo;
    [SerializeField] GameObject PresetProjoUlt;
    [SerializeField] float SpawnOffset;

    // Update is called once per frame
    public void Spawn()
    {
        Vector3 pos = gameObject.transform.position;
        pos.x += SpawnOffset;
        Instantiate(PresetProjo,pos,Quaternion.identity);
    }

    public void SpawnUlt()
    {
        Vector3 pos = gameObject.transform.position;
        pos.x += SpawnOffset;
        Instantiate(PresetProjoUlt,pos,Quaternion.identity);
    }
}

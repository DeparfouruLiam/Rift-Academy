
using UnityEngine;

public class SpawnProjectile : MonoBehaviour
{
    [SerializeField] GameObject PresetBg;
    [SerializeField] float SpawnOffset;

    // Update is called once per frame
    public void Spawn()
    {
        Vector3 pos = gameObject.transform.position;
        pos.x += SpawnOffset;
        Instantiate(PresetBg,pos,Quaternion.identity);
    }
}

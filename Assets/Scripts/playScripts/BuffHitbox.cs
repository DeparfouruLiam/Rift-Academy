using UnityEngine;

public class BuffHitbox : MonoBehaviour
{
    [SerializeField] private LayerMask HeroLayer;
    [SerializeField] private float BuffLevel;

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.layer);
        if ((HeroLayer.value & (1 << collision.gameObject.layer)) == 0)
            return;

        var hero = collision.GetComponent<HeroAttack>();
        if (hero == null)
            return;

        if (hero.AttackSpeedModifier > BuffLevel)
        {
            var BuffValues = GetComponentInParent<BuffZoneScript>();
            hero.AttSpeBuff(BuffLevel, BuffValues.BuffDuration - (Time.time - BuffValues.BuffStartTime));
        }
    }
}

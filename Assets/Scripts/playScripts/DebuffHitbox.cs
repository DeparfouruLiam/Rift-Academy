using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffHitbox : MonoBehaviour
{
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private float SlowLevel;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((enemyLayer.value & (1 << collision.gameObject.layer)) == 0)
            return;

        var enemy = collision.GetComponent<EnemyMovement>();
        if (enemy == null)
            return;

        if (enemy.SlowEffect > SlowLevel)
        {
            var DebuffValues = GetComponentInParent<DebuffScript>();
            enemy.SlowDebuff(SlowLevel, DebuffValues.DebuffDuration - (Time.time - DebuffValues.DebuffStartTime));
        }
    }
}
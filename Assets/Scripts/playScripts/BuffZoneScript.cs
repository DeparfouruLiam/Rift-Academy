using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffZoneScript : MonoBehaviour
{
    [SerializeField] public float BuffDuration;
    [SerializeField] GameObject BuffEffect;
    public float BuffStartTime;

    // Update is called once per frame
    public void BuffGo()
    {
        StartCoroutine(BuffCoroutine());
    }

    IEnumerator BuffCoroutine() {
        BuffStartTime = Time.time;
        BuffEffect.SetActive(true);
        yield return new WaitForSeconds(BuffDuration);
        BuffEffect.SetActive(false);
    }
}

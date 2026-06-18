using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffScript : MonoBehaviour
{
    [SerializeField] public float DebuffDuration;
    [SerializeField] GameObject debuffEffect;
    public float DebuffStartTime;


    // Update is called once per frame
    public void DebuffGo()
    {
        StartCoroutine(DebuffCoroutine());
    }

    IEnumerator DebuffCoroutine() {
        DebuffStartTime = Time.time;
        debuffEffect.SetActive(true);
        yield return new WaitForSeconds(DebuffDuration);
        debuffEffect.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffScript : MonoBehaviour
{
    [SerializeField] float DebuffDuration;
    [SerializeField] GameObject debuffEffect;


    // Update is called once per frame
    public void DebuffGo()
    {
        StartCoroutine(DebuffCoroutine());
    }

    IEnumerator DebuffCoroutine() {
        debuffEffect.SetActive(true);
        yield return new WaitForSeconds(DebuffDuration);
        debuffEffect.SetActive(false);
    }
}

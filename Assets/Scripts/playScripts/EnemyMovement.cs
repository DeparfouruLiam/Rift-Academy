using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] public Vector3 target;
    
    [SerializeField] float speed;
    public float SlowEffect = 1;
    private float TrueSpeed;
    private Coroutine slowCoroutine;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TrueSpeed = speed*SlowEffect;
        transform.position = Vector3.MoveTowards(transform.position, target , TrueSpeed*Time.deltaTime);
        
    }

    public void SlowDebuff(float SlowLevel, float SlowDuration)
    {
        if (slowCoroutine != null)
            {
                StopCoroutine(slowCoroutine);
            }
        slowCoroutine = StartCoroutine(SlowDebuffCoroutine(SlowLevel,SlowDuration));
    }

    IEnumerator SlowDebuffCoroutine(float SlowLevel, float SlowDuration)
    {
        Debug.Log(SlowDuration);
        SlowEffect = SlowLevel;
        yield return new WaitForSeconds(SlowDuration+0.1f);
        Debug.Log("EndDebuff");
        SlowEffect=1;
    }
}

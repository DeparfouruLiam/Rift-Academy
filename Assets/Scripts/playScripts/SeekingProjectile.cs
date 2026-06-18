using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekingProjectile : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] public int Pierce;
    [SerializeField] float duration;
    [SerializeField] GameObject FollowUp;
    public GameObject target;


    private void Start() {
        StartCoroutine(EndDuration());
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x >= 30)
        {
            Destroy(gameObject);
        }
        Vector3 pos = gameObject.transform.position;
        pos.x = 35;
        if(target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed*Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, pos, speed*Time.deltaTime);
        }
    }

    public void LastHit()
    {
        if (FollowUp!=null)
        {
            Instantiate(FollowUp,gameObject.transform.position,Quaternion.identity);
        }
        Destroy(gameObject);
    }

    IEnumerator EndDuration() {
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }
}

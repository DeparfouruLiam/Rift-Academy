using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public int BaseHP = 100;
    void OnTriggerEnter2D(Collider2D collision)
    {
        BaseHP -= 1;
        Debug.Log("Gooning");
        Destroy(collision.gameObject);
    }
}

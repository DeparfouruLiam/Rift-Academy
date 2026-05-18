using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField]GameObject gameOverScreen;

    public int BaseHP = 100;
    void OnTriggerEnter2D(Collider2D collision)
    {
        BaseHP -= 1;
        Debug.Log("Gooning");
        Destroy(collision.gameObject);
        if (BaseHP <= 0)
        {
            Debug.Log("Game Over");
            gameOverScreen.SetActive(true);
        }
    }
}

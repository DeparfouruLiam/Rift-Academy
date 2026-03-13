using UnityEngine;

public class testclic : MonoBehaviour
{
    void OnMouseDown()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
    }
}
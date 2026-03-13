using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlotUI : MonoBehaviour
{
    public Image icon;
    public Text quantity;

    public void Setup(ItemScript item, Sprite sprite)
{
    icon.sprite = sprite;
    quantity.text = item.quantity.ToString();
    quantity.gameObject.SetActive(item.quantity > 1);
}
}
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    public GameObject[] Panels;
    public Sprite[] itemIcons;
    public GameObject slotPrefab;

    ItemScript[] items;
    int nbItems = 20;

    string test = "0127837281927362519283647382930473928374";

    void Start()
    {
        items = new ItemScript[nbItems];

        InitiateQuantities();

        Debug.Log("Inventory initialized");
    }

    public void InitiateQuantities()
    {
        for (int i = 0; i < nbItems; i++)
        {
            items[i] = new ItemScript(); // IMPORTANT

            items[i].quantity = int.Parse(test[i*2].ToString() + test[i*2+1].ToString());
            items[i].type = i % 4;

            if (items[i].quantity > 0)
            {
                GameObject panel = Panels[items[i].type];

                GameObject newItem = Instantiate(slotPrefab, panel.transform);
                Debug.Log("test initialized");

                newItem.GetComponent<SlotUI>().Setup(items[i],itemIcons[i] );
            }
        }
    }

    public void AddItems()
    {
        for (int i = 0; i < nbItems; i++)
        {
            if (items[i].quantity > 0)
            {
                return;
            }
        }
    }
}
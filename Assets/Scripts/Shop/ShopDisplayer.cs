using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Display items inside shop
/// </summary>
public class ShopDisplayer : MonoBehaviour
{
    public GameObject shopPrefab;
    public List<ItemObject> items = new List<ItemObject>();

    protected void Awake()
    {
        CreateDisplay();
    }

    protected void Start()
    {
        // Start shop hidden
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Creates item listings to buy/sell inside shop
    /// </summary>
    public void CreateDisplay()
    {
        foreach (var item in items)
        {
            GameObject clone = Instantiate(shopPrefab, transform);

            ShopItem shop = clone.GetComponent<ShopItem>();
            shop.UpdateItem(item);
        }
    }
}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplayer : MonoBehaviour
{
    public GameObject slotPrefab, itemPrefab;
    public InventoryObject inventory;

    private Dictionary<InventorySlot, GameObject> inventorySlots = new Dictionary<InventorySlot, GameObject>();
    private GameObject[] inventoryItems;

    protected void Awake()
    {
        CreateDisplay();
    }

    public void CreateDisplay()
    {
        if (inventorySlots.Count > 0)
            DestroyDisplay();

        for (int i = 0; i < inventory.Container.Count; i++)
        {
            GameObject clone = Instantiate(slotPrefab, transform);
            clone.name = "Slot" + i;
            inventorySlots.Add(inventory.Container[i], clone);
        }

        inventoryItems = new GameObject[inventorySlots.Count];
    }

    public void UpdateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            InventorySlot slot = inventory.Container[i];
            if (slot.Item == null)
            {
                if (inventoryItems[i] != null)
                    Destroy(inventoryItems[i]);
            }
            else
            {
                if (inventoryItems[i] != null)
                {
                    Image image = inventoryItems[i].GetComponent<Image>();
                    image.sprite = slot.Item.icon;
                }
                else
                {
                    GameObject clone = Instantiate(itemPrefab, inventorySlots[slot].transform);
                    clone.name = slot.Item.name;
                    inventoryItems[i] = clone;
                }
            }
        }
    }

    public void DestroyDisplay()
    {
        foreach (var slot in inventorySlots)
            Destroy(slot.Value);

        inventorySlots = new Dictionary<InventorySlot, GameObject>();
    }
}

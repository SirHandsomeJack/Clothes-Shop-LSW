using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory Object", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public List<InventorySlot> Container = new List<InventorySlot>();

    public void AddItem(ItemObject item, int amount)
    {
        // Find same item in inventory
        InventorySlot slot = Container.Find(x => x.Item == item);
        if (slot == null)
        {
            // Find empty slot
            for (int i = 0; i < Container.Count; i++)
            {
                if (Container[i].Item == null)
                {
                    slot = new InventorySlot(item, amount);
                    return;
                }
            }

            Debug.LogWarning("No Space in Inventory.");
        }
        else slot.AddAmount(amount);
    }
}

[Serializable]
public class InventorySlot
{
    public ItemObject Item;
    public int Amount;

    public InventorySlot(ItemObject item, int amount)
    {
        Item = item;
        Amount = amount;
    }

    public void UpdateSlot(ItemObject item, int amount)
    {
        Item = item;
        Amount = amount;
    }

    public void AddAmount(int value)
    {
        Amount += value;
    }
}

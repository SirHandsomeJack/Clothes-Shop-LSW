using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Adds a new inventory object to store items objects
/// </summary>
[CreateAssetMenu(fileName = "New Inventory Object", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public List<InventorySlot> Container = new List<InventorySlot>();

    /// <summary>
    /// Add item to inventory
    /// </summary>
    /// <param name="item">Item to look for</param>
    /// <param name="amount">Amount to remove</param>
    public void AddItem(ItemObject item, int amount)
    {
        // Find slot with same item
        InventorySlot slot = GetItemSlot(item);
        if (slot == null)
        {
            // Find empty slot
            slot = GetItemSlot();
            if (slot == null) Debug.LogWarning("No Space in Inventory.");
            else slot.UpdateSlot(item, amount);
        }
        else slot.AddAmount(amount);
    }

    /// <summary>
    /// Remove item from inventory
    /// </summary>
    /// <param name="item">Item to look for</param>
    /// <param name="amount">Amount to remove</param>
    /// <returns></returns>
    public bool RemoveItem(ItemObject item, int amount)
    {
        // Find same item in inventory
        InventorySlot slot = GetItemSlot(item);
        if (slot != null)
        {
            slot.AddAmount(-amount);
            if (slot.Amount < 1)
                slot.UpdateSlot(null, 0);

            return true;
        }

        return false;
    }

    /// <summary>
    /// Gets next available empty slot
    /// </summary>
    /// <returns></returns>
    public InventorySlot GetItemSlot()
    {
        foreach (var slot in Container)
        {
            if (slot.Item == null)
                return slot;
        }

        return null;
    }

    /// <summary>
    /// Gets index of item in inventory
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public int GetItemSlotIndex(ItemObject item)
    {
        return Container.FindIndex(0, Container.Count, x => x.Item == item);
    }

    /// <summary>
    /// Gets slot where item is found
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public InventorySlot GetItemSlot(ItemObject item)
    {
        return Container.Find(x => x.Item == item);
    }

    /// <summary>
    /// Gets amount of item in slot
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public int GetItemAmount(ItemObject item)
    {
        InventorySlot slot = GetItemSlot(item);
        if (slot != null)
            return slot.Amount;

        return -1;
    }
}

[Serializable]
public class InventorySlot
{
    public ItemObject Item;
    public int Amount;

    public InventorySlot() { }

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

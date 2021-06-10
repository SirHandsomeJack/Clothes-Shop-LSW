using System;
using UnityEngine;

public class CharacterInventory : MonoBehaviour
{
    public int InventorySize;
    public InventoryObject Inventory;
    public int Gold { get; private set; }

    /// <summary>
    /// Occurs when gold changes.
    /// </summary>
    public static event Action<int> OnGoldChanged;

    protected void Start()
    {
        for (int i = 0; i < InventorySize; i++)
            Inventory.Container.Add(new InventorySlot());
    }

    /// <summary>
    /// Add or remove gold
    /// </summary>
    /// <param name="gold">Gold to add or remove</param>
    public virtual void AddGold(int gold)
    {
        Gold += gold;

        OnGoldChanged?.Invoke(Gold);
    }

    /// <summary>
    /// Sets gold
    /// </summary>
    /// <param name="gold">Gold to set</param>
    public virtual void SetGold(int gold)
    {
        Gold = gold;

        OnGoldChanged?.Invoke(Gold);
    }

    /// <summary>
    /// Resets gold to initial values
    /// </summary>
    public virtual void ResetGold()
    {
        Gold = 0;

        OnGoldChanged?.Invoke(Gold);
    }

    public void OnApplicationQuit()
    {
        if (Inventory != null)
            Inventory.Container.Clear();
    }
}

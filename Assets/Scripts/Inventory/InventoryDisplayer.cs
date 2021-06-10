using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Handles the inventory slots from character inventory and equipping items
/// </summary>
public class InventoryDisplayer : MonoBehaviour
{
    public GameObject slotPrefab, itemPrefab;
    public InventoryObject inventory;

    public InventoryCharacterDisplayer CharacterDisplayer;

    private Dictionary<InventorySlot, GameObject> inventorySlots = new Dictionary<InventorySlot, GameObject>();
    private GameObject[] inventoryItems;

    private Dictionary<EquipmentType, GameObject> characterSlots = new Dictionary<EquipmentType, GameObject>();

    /// <summary>
    /// Creates items to put into slots from character inventory, destroy exisitng items in slots
    /// </summary>
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

    /// <summary>
    /// Updates items in slots, add new items, remove old items or update existing items
    /// </summary>
    public void UpdateDisplay()
    {
        if (inventorySlots.Count != inventory.Container.Count)
            CreateDisplay();

        for (int i = 0; i < inventory.Container.Count; i++)
        {
            InventorySlot slot = inventory.Container[i];
            if (slot.Item == null)
            {
                // Remove item
                if (inventoryItems[i] != null)
                {
                    InventoryItem item = inventoryItems[i].GetComponent<InventoryItem>();
                    item.UpdateItem(null, 0);

                    Destroy(inventoryItems[i]);
                    inventoryItems[i] = null;
                }
            }
            else
            {
                // Add item
                if (inventoryItems[i] == null)
                {
                    GameObject clone = Instantiate(itemPrefab, inventorySlots[slot].transform);
                    clone.name = slot.Item.name;
                    inventoryItems[i] = clone;
                }

                // Update item
                InventoryItem item = inventoryItems[i].GetComponent<InventoryItem>();
                if (item != null)
                {
                    item.UpdateItem(slot.Item, inventory.Container[i].Amount);
                    item.OnDoubleClick += OnDoubleClick;
                }
            }
        }
    }

    /// <summary>
    /// Clears the items in slots
    /// </summary>
    public void DestroyDisplay()
    {
        foreach (var slot in inventorySlots)
            Destroy(slot.Value);

        inventorySlots = new Dictionary<InventorySlot, GameObject>();
    }

    /// <summary>
    /// Double click behaviour to equip or unequip from character
    /// </summary>
    /// <param name="eventData"></param>
    /// <param name="inventoryItem"></param>
    public void OnDoubleClick(PointerEventData eventData, InventoryItem inventoryItem)
    {
        ItemObject item = inventoryItem.Item;
        if (item != null && item is EquipmentObject equipment)
        {
            GameObject characterSlot = CharacterDisplayer.GetCharacterSlot(equipment.equipmentType);
            if (characterSlot == null)
                return;

            if (characterSlots.ContainsKey(equipment.equipmentType))
            {
                // Unequip from character
                if (characterSlots[equipment.equipmentType] == inventoryItem.gameObject)
                {
                    inventory.AddItem(item, 1);

                    Destroy(characterSlots[equipment.equipmentType]);
                    characterSlots.Remove(equipment.equipmentType);
                    CharacterDisplayer.AddArmour(-equipment.armour);

                    UpdateDisplay();
                }
            }
            else
            {
                // Equip to character
                inventory.RemoveItem(item, 1);

                GameObject clone = Instantiate(itemPrefab, characterSlot.transform);
                clone.name = item.name;

                characterSlots.Add(equipment.equipmentType, clone);
                CharacterDisplayer.AddArmour(equipment.armour);

                InventoryItem i = clone.GetComponent<InventoryItem>();
                if (i != null)
                {
                    i.UpdateItem(item, 1);
                    i.OnDoubleClick += OnDoubleClick;
                }
                
                UpdateDisplay();
            }
        }
    }
}

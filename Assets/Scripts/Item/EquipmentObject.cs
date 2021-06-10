using UnityEngine;

public enum EquipmentType
{
    None,
    Head,
    Chest,
    Leg,
    Boots,
    Cloak,
    Gloves,
    Belt,
    Bracers,
}

public enum EquipmentRarity
{
    None,
    Common,
    Uncommon,
    Rare,
    Legendary,
}

/// <summary>
/// Adds a new equipment object
/// </summary>
[CreateAssetMenu(fileName = "New Equipment Object", menuName = "Inventory System/Items/Equipment")]
public class EquipmentObject : ItemObject
{
    public EquipmentType equipmentType;
    public EquipmentRarity equipmentRarity;

    public int armour;
    public int durability = 100;

    public void Awake()
    {
        type = ItemType.Equipment;
    }
}

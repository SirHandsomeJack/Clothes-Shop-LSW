using UnityEngine;

public enum EquipmentType
{
    None,
    Head,
    Chest,
    Pants,
    Boots,
    Cloak,
    Gloves,
    Belts,
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

[CreateAssetMenu(fileName = "New Equipment Object", menuName = "Inventory System/Items/Equipment")]
public class EquipmentObject : ItemObject
{
    public EquipmentType equipmentType;
    public EquipmentRarity equipmentRarity;

    public int armour;
    public int durability = 100;

    public float price;

    public void Awake()
    {
        type = ItemType.Equipment;
    }
}

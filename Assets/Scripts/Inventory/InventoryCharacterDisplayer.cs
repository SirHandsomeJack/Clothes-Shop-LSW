using UnityEngine;

public class InventoryCharacterDisplayer : MonoBehaviour
{
    public GameObject HeadSlot, ChestSlot, LegSlot, BootsSlot, CloakSlot, GlovesSlot, BeltSlot, BracersSlot;

    public GameObject GetCharacterSlot(EquipmentType type)
    {
        switch (type)
        {
            case EquipmentType.Head:
                return HeadSlot;
            case EquipmentType.Chest:
                return ChestSlot;
            case EquipmentType.Leg:
                return LegSlot;
            case EquipmentType.Boots:
                return BootsSlot;
            case EquipmentType.Cloak:
                return CloakSlot;
            case EquipmentType.Gloves:
                return GlovesSlot;
            case EquipmentType.Belt:
                return BeltSlot;
            case EquipmentType.Bracers:
                return BracersSlot;
            default:
                return null;
        }
    }
}

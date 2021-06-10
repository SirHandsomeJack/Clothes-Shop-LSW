using TMPro;
using UnityEngine;

/// <summary>
/// Handles the character slots and armour rating
/// </summary>
public class InventoryCharacterDisplayer : MonoBehaviour
{
    public GameObject HeadSlot, ChestSlot, LegSlot, BootsSlot, CloakSlot, GlovesSlot, BeltSlot, BracersSlot;
    public TextMeshProUGUI ArmourText;

    private int armour;

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

    public void AddArmour(int value)
    {
        armour += value;
        if (armour < 0)
            armour = 0;

        if (ArmourText != null)
            ArmourText.text = "" + armour;
    }
}

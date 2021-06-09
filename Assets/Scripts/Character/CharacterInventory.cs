using UnityEngine;

public class CharacterInventory : MonoBehaviour
{
    public InventoryObject Inventory;

    public void OnApplicationQuit()
    {
        if (Inventory != null)
            Inventory.Container.Clear();
    }
}

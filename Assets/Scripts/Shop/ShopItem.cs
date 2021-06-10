using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles item listing in shop, updating text and adding/removing to inventory
/// </summary>
public class ShopItem : MonoBehaviour
{
    public ItemObject Item { get; private set; }

    public CharacterInventory targetInventory;

    public Image ItemImage;
    public TextMeshProUGUI ItemName;
    public TextMeshProUGUI ItemDescription;
    public TextMeshProUGUI ItemBuy, ItemSell;

    protected void Start()
    {
        targetInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterInventory>();
    }

    /// <summary>
    /// Updates item to display icon and texts
    /// </summary>
    public void UpdateItem(ItemObject item)
    {
        Item = item;
        UpdateText();
    }

    /// <summary>
    /// Updates item to display icon and texts
    /// </summary>
    private void UpdateText()
    {
        name = Item.name;

        if (ItemImage != null) ItemImage.sprite = Item.icon;
        if (ItemName != null) ItemName.text = Item.name;
        if (ItemDescription != null) ItemDescription.text = Item.description;
        if (ItemBuy != null) ItemBuy.text = "Buy - " + Item.price;

        UpdateSellText();
    }

    /// <summary>
    /// Updates sell text to display inventory amount and sell price
    /// </summary>
    private void UpdateSellText()
    {
        if (ItemSell != null)
        {
            int amount = 0;
            if (targetInventory != null)
                amount = targetInventory.Inventory.GetItemAmount(Item);

            if (amount > 0) ItemSell.text = string.Format("Sell - {0} ({1})", GetSellPrice(), amount);
            else ItemSell.text = string.Format("Sell - {0}", GetSellPrice());
        }
    }

    /// <summary>
    /// Gets the sell price by the item price and percentage of durability
    /// </summary>
    /// <returns></returns>
    public float GetSellPrice()
    {
        float price = Item.price;

        if (targetInventory != null)
        {
            InventorySlot slot = targetInventory.Inventory.GetItemSlot(Item);
            if (slot != null && slot.Item is EquipmentObject equipment)
                price *= equipment.durability / 100;
        }

        return price;
    }

    /// <summary>
    /// Buy item, check if player has enough gold and add item to inventory
    /// </summary>
    public void BuyItem()
    {
        if (targetInventory == null)
            return;

        if (targetInventory.Gold >= Item.price)
        {
            targetInventory.Inventory.AddItem(Item, 1);
            targetInventory.AddGold(-(int)Item.price);

            UpdateSellText();
        }
    }

    /// <summary>
    /// Sell item, check if there is one item to sell of that item, remove it and add gold
    /// </summary>
    public void SellItem()
    {
        if (targetInventory == null)
            return;

        if (targetInventory.Inventory.RemoveItem(Item, 1))
            targetInventory.AddGold((int)GetSellPrice());

        UpdateSellText();
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    public void UpdateItem(ItemObject item)
    {
        Item = item;
        UpdateText();
    }

    private void UpdateText()
    {
        name = Item.name;

        if (ItemImage != null) ItemImage.sprite = Item.icon;
        if (ItemName != null) ItemName.text = Item.name;
        if (ItemDescription != null) ItemDescription.text = Item.description;
        if (ItemBuy != null) ItemBuy.text = "Buy - " + Item.price;

        UpdateSellText();
    }

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

    public void SellItem()
    {
        if (targetInventory == null)
            return;

        if (targetInventory.Inventory.RemoveItem(Item, 1))
            targetInventory.AddGold((int)GetSellPrice());

        UpdateSellText();
    }
}

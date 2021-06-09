using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    public ItemObject Item { get; private set; }

    public Image ItemImage;
    public TextMeshProUGUI ItemName;
    public TextMeshProUGUI ItemDescription;
    public TextMeshProUGUI ItemBuy, ItemSell;

    public void UpdateItem(ItemObject item)
    {
        Item = item;
        name = item.name;

        if (ItemImage != null) ItemImage.sprite = item.icon;
        if (ItemName != null) ItemName.text = item.name;
        if (ItemDescription != null) ItemDescription.text = item.description;
        if (ItemBuy != null) ItemBuy.text = "Buy - " + item.price;
        if (ItemSell != null) ItemSell.text = "Sell - " + item.price;
    }
}

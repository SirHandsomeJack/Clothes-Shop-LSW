using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Handles the item inside slot, update icon and text and send double click event
/// </summary>
public class InventoryItem : MonoBehaviour, IPointerClickHandler
{
    public ItemObject Item { get; private set; }

    public Image ItemImage;
    public TextMeshProUGUI AmountText;

    /// <summary>
    /// Occurs when double click on item.
    /// </summary>
    public event Action<PointerEventData, InventoryItem> OnDoubleClick;

    protected void Awake()
    {
        AmountText = transform.parent.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void UpdateItem(ItemObject item, int amount)
    {
        Item = item;
        if (item != null)
        {
            if (ItemImage != null)
                ItemImage.sprite = item.icon;
        }

        if (AmountText != null)
        {
            if (amount > 1) AmountText.text = "" + amount;
            else AmountText.text = "";
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.clickCount == 2)
            OnDoubleClick.Invoke(eventData, this);
    }
}

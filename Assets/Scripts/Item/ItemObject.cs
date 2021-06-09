using UnityEngine;

public enum ItemType
{
    Default,
    Equipment,
}

public abstract class ItemObject : ScriptableObject
{
    public Sprite icon;

    public ItemType type;
    [TextArea(15,20)]
    public string description;

    public float price;
}

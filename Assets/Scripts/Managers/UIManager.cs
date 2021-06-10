using TMPro;

/// <summary>
/// Handles UI, updating general texts and other elements
/// </summary>
public class UIManager : Singleton<UIManager>
{
    public TextMeshProUGUI GoldText;

    /// <summary>
    /// Update gold text when gold changes
    /// </summary>
    /// <param name="gold"></param>
    public void OnGoldChanged(int gold)
    {
        if (GoldText != null)
            GoldText.text = "" + gold;
    }

    protected virtual void OnEnable()
    {
        CharacterInventory.OnGoldChanged += OnGoldChanged;
    }

    protected virtual void OnDisable()
    {
        CharacterInventory.OnGoldChanged -= OnGoldChanged;
    }
}

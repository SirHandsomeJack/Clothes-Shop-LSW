using TMPro;

public class UIManager : Singleton<UIManager>
{
    public TextMeshProUGUI GoldText;

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

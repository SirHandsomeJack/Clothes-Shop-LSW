using Doozy.Engine;
using Doozy.Engine.UI;
using UnityEngine;

public class OpenShop : MonoBehaviour
{
    public RectTransform Area;
    public GameObject Interact;

    public DialogueTrigger Start, Shop;

    private GameObject _player;
    private UIPopup _popup;

    private bool IsFirst = true;

    protected void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _popup = UIPopup.GetPopup("Store");
    }

    public void Update()
    {
        if (Interact == null)
            return;

        Interact.SetActive(_player != null && Area.rect.Contains(_player.transform.position));

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Interact.activeSelf)
            {
                if (IsFirst) Start.TriggerDialogue();
                else Shop.TriggerDialogue();
            }
        }
    }

    public virtual void OnGameEvent(GameEventMessage gameEvent)
    {
        switch (gameEvent.EventName)
        {
            case "EndDialogue":
                if (IsFirst)
                {
                    IsFirst = false;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterInventory>().SetGold(1000);
                }

                _popup.Show();
                break;
        }
    }

    protected virtual void OnEnable()
    {
        Message.AddListener<GameEventMessage>(OnGameEvent);
    }

    protected virtual void OnDisable()
    {
        Message.RemoveListener<GameEventMessage>(OnGameEvent);
    }
}

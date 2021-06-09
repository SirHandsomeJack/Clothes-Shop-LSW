using Doozy.Engine;
using Doozy.Engine.UI;
using System;
using UnityEngine;

public class OpenShop : MonoBehaviour
{
    public RectTransform Area;
    public GameObject Interact;

    private GameObject _player;
    private UIPopup _popup;

    protected void Start()
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
                if (_popup.IsShowing) _popup.Hide();
                else _popup.Show();
            }
        }
    }

    #region Temp GameManager
    public virtual void Pause(bool status)
    {
        Time.timeScale = Convert.ToSingle(!status);
        Debug.LogFormat("Paused > <i>{0}</i>", status);
    }

    public virtual void OnGameEvent(GameEventMessage gameEvent)
    {
        Debug.LogFormat("<i>{0}</i> event triggered.", gameEvent.EventName);

        switch (gameEvent.EventName)
        {
            case "Pause":
                Pause(true);
                break;
            case "UnPause":
                Pause(false);
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
    #endregion
}

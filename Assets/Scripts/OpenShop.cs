using Doozy.Engine;
using Doozy.Engine.UI;
using System;
using UnityEngine;

public class OpenShop : MonoBehaviour
{
    public RectTransform Area;

    private GameObject _player;
    private UIPopup _popup;

    protected void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _popup = UIPopup.GetPopup("Store");
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_popup.IsShowing) _popup.Hide();
            else
            {
                _player = GameObject.FindGameObjectWithTag("Player");
                if (_player != null && Area.rect.Contains(_player.transform.position))
                    _popup.Show();
            }
        }
    }

    #region Temp GameManager
    /// <summary>
    /// Pauses/UnPauses the game
    /// </summary>
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

    /// <summary>
    /// OnEnable, start listening to events
    /// </summary>
    protected virtual void OnEnable()
    {
        Message.AddListener<GameEventMessage>(OnGameEvent);
    }

    /// <summary>
    /// OnDisable, stop listening to events
    /// </summary>
    protected virtual void OnDisable()
    {
        Message.RemoveListener<GameEventMessage>(OnGameEvent);
    }
    #endregion
}

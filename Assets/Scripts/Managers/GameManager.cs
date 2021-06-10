using Doozy.Engine;
using System;
using UnityEngine;

/// <summary>
/// Handles pausing and quitting game
/// </summary>
public class GameManager : PersistentSingleton<GameManager>
{
    /// <summary>
    /// Pauses/UnPauses the game
    /// </summary>
    public virtual void Pause(bool status)
    {
        Time.timeScale = Convert.ToSingle(!status);
        Debug.LogFormat("Paused > <i>{0}</i>", status);
    }

    /// <summary>
    /// Listens for game events triggered by buttons for script
    /// </summary>
    /// <param name="gameEvent"></param>
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
            case "Quit":
                Application.Quit();
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

using UnityEngine;

/// <summary>
/// Singleton pattern
/// </summary>
/// Developed by SirHandsomeJack
public class Singleton<T> : MonoBehaviour where T : Component
{
    protected static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject();
                    _instance = obj.AddComponent<T>();
                }
            }
            return _instance;
        }
    }

    /// <summary>
    /// On awake, we initialise the instance
    /// </summary>
    protected virtual void Awake()
    {
        if (!Application.isPlaying)
            return;

        _instance = this as T;
    }
}
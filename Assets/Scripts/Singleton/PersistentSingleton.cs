using UnityEngine;

/// <summary>
/// Persistent singleton (DontDestroyOnLoad)
/// </summary>
/// Developed by SirHandsomeJack
public class PersistentSingleton<T> : MonoBehaviour where T : Component
{
    protected static T _instance;
    protected bool _enabled;

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
    /// On Awake, check if another instance exist
    /// </summary>
    protected virtual void Awake()
    {
        if (!Application.isPlaying)
            return;

        if (_instance == null)
        {
            // if first instance, make it Singleton
            _instance = this as T;
            DontDestroyOnLoad(transform.gameObject);
            _enabled = true;
        }
        else
        {
            // if a Singleton already exists and you find another reference in scene, destroy this instance!
            if (this != _instance)
            {
                Destroy(gameObject);
            }
        }
    }
}
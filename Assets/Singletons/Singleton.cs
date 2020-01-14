using UnityEngine;

public abstract class Singleton : MonoBehaviour
{
    public static Singleton Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        { Destroy(this.gameObject); }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            OnAwake();
        }
    }

    protected virtual void OnAwake() { }
}

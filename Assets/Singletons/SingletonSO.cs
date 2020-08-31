using System.Linq;
using UnityEngine;

public class SingletonSO<T> : ScriptableObject where T : ScriptableObject
{
    // TODO not working, manually load static scriptable objects?

    static T instance = null;
    public static T Instance
    {
        get
        {
            instance = Resources.FindObjectsOfTypeAll<T>().FirstOrDefault(); 
            return instance;
        }
    }
    protected virtual void Awake()
    {
        //change, maybe T away?
    }
}
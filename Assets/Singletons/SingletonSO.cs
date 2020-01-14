using System.Linq;
using UnityEngine;

public class SingletonSO<T> : ScriptableObject where T : ScriptableObject
{
    static T instance = null;
    public static T Instance
    {
        get
        {
            if (instance == null)
            { instance = Resources.FindObjectsOfTypeAll<T>().FirstOrDefault(); }
            return instance;
        }
    }
}
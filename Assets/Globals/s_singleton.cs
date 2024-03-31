using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class s_singleton<T> : MonoBehaviour where T: Component
{
    public static T instance;

    public static T GetInstance() {
        if (instance == null) {
            instance = FindObjectOfType<T>();
            if (instance == null) {
                GameObject obj = new GameObject();
                obj.name = typeof(T).Name;
                instance = obj.AddComponent<T>();
            }
        }
        return instance;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this as T)
        {
            Destroy(gameObject);
        }
        else { DontDestroyOnLoad(gameObject); }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T instance;

    void Awake()
    {
        if (instance == null)
            instance = (T)FindObjectOfType(typeof(T));
        else
        {
            Destroy(this);
            Debug.LogError("Another instance of " + instance.GetType().Name);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// The Entire purpose of this Object is to hold any gameObject that shouldn't be doestroyed between scenes.
/// </summary>
public class GamePersistentData : MonoBehaviour
{

    void Awake()
    {
        if(FindObjectsOfType<GamePersistentData>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

}

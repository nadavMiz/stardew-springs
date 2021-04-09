using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePersistentData : MonoBehaviour
{

    
    
    // Start is called before the first frame update
    void Start()
    {
        if(FindObjectsOfType<GamePersistentData>().Length > 1)
        {
            Destroy(this);
        }
        else
        {
            DontDestroyOnLoad(this);
        }
    }

    public void LoadGame()
    {
        SaveData.current.Load();
    }


    public void SaveGame()
    {
        
        SerializationManager.Save("game3", SaveData.current);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "prefabMap", menuName = "ScriptableObjects/MapPrefab")]
public class PrefabDB : ScriptableObject
{
    public List<SinglePrefab> singlePrefabList;

    public Dictionary<string, GameObject> initAndGetDictionary()
    {
        Dictionary<string, GameObject> dictionaryOfObjects = new Dictionary<string, GameObject>();
        foreach (SinglePrefab singlePrefab in singlePrefabList)
        {
            dictionaryOfObjects.Add(singlePrefab.prefabName, singlePrefab.prefab);
        }
        return dictionaryOfObjects;
    }
}

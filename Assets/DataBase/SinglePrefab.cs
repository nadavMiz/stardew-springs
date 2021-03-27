using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="singlePrefab", menuName = "ScriptableObjects/prefab")]
public class SinglePrefab : ScriptableObject
{
    public string prefabName;
    public GameObject prefab;
}

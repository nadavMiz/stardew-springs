using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemMetadata", menuName = "ScriptableObjects/itemMetadata")]
public class ItemMetadata : ScriptableObject
{
    public GameObject m_item;
    public Sprite m_icon;
    public string m_name;
    public Iuseable m_useFunc;
    public bool m_isUsable;
    public bool m_isHoldable;
    public int m_inventoryCapacity;
}

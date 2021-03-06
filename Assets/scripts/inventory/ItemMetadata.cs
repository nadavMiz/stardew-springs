using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemMetadata", menuName = "ScriptableObjects/itemMetadata")]
public class ItemMetadata : ScriptableObject
{
    public enum ItemId { e_waterCan = 1, e_seed = 2, e_hoe = 3}

    public GameObject m_item;
    public ItemId m_itemId;
    public Sprite m_icon;
    public string m_name;
    public Iuseable m_useFunc;
    public bool m_isUsable;
    public bool m_isHoldable;
    public int m_inventoryCapacity;
}

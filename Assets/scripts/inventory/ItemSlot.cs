using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public Image m_icon;
    private ItemMetadata m_item;
    
    public void SetItem(ItemMetadata _item) 
    {
        if(_item == null) {
            Clear();
            return;
        }

        m_item = _item;

        m_icon.sprite = _item.m_icon;
        m_icon.enabled = true;
    }

    public void Clear()
    {
        m_item = null;
        m_icon.sprite = null;
        m_icon.enabled = false;
    }
}

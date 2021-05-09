using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public Image m_icon;
    public Image m_highlite;
    public Text m_quantity;
    private ItemMetadata m_item;
    
    public void SetItem(ItemMetadata _item, int _quantity = 1) 
    {
        if(_item == null) {
            Clear();
            return;
        }

        SetItemContent(_item);
        setQuantity(_quantity);

    }

    public void Clear()
    {
        m_item = null;
        m_icon.sprite = null;
        m_icon.enabled = false;
        m_quantity.enabled = false;
    }

    public void Highlight(bool _state) 
    {
        m_highlite.enabled = _state;
    }

    private void SetItemContent(ItemMetadata _item) 
    {
        m_item = _item;
        m_icon.sprite = _item.m_icon;
        m_icon.enabled = true;
    }

    private void setQuantity(int _quantity)
    {
        if (_quantity <= 1) 
        {
            m_quantity.enabled = false;
            return;
        }

        m_quantity.text = _quantity.ToString();
        m_quantity.enabled = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<ItemMetadata> m_initialItems;
    public int m_capacity { get; private set; } = 10;
    private List<ItemMetadata> m_inventory;
    private int m_numItems = 0;

    private void Start()
    {
        m_inventory = new List<ItemMetadata>(m_capacity);
        for (int i = 0; i < m_capacity; ++i) m_inventory.Add(null);

        foreach (ItemMetadata item in m_initialItems) 
        {
            InsertImp(item);
        }

        EventManager.TriggerEvent(InventoryEvent.INVENTORY_CHANGED);
    }

    public ItemMetadata GetItem(int _idx)
    {
        return m_inventory[_idx];
    }

    public bool Insert(ItemMetadata _item) 
    {
        bool retval = InsertImp(_item);
        if (retval) {
            EventManager.TriggerEvent(InventoryEvent.INVENTORY_CHANGED);
        }
        return retval;
    }

    public bool Insert(ItemMetadata _item, int _idx) 
    {
        bool retval = InsertImp(_item, _idx);
        if (retval)
        {
            EventManager.TriggerEvent(InventoryEvent.INVENTORY_CHANGED);
        }
        return retval;
    }

    public ItemMetadata Remove(int _idx)
    {
        ItemMetadata retval = RemoveImp(_idx);
        if (retval)
        {
            EventManager.TriggerEvent(InventoryEvent.INVENTORY_CHANGED);
        }
        return retval;
    }

    public bool IsFull()
    {
        return m_capacity == m_numItems;
    }

    public void Move(int _from, int _to) 
    {
        //inventory hasn't changed
        if(m_inventory[_from] == null && m_inventory[_to] == null) {
            return;
        }

        MoveImp(_from, _to);
        EventManager.TriggerEvent(InventoryEvent.INVENTORY_CHANGED);
    }

    public void Sort()
    {
        m_inventory.Sort(ItemComparison);
        EventManager.TriggerEvent(InventoryEvent.INVENTORY_CHANGED);
    }

    static private int ItemComparison(ItemMetadata _first, ItemMetadata _second)
    {
        if(_first.m_isUsable != _second.m_isUsable) {
            return _first.m_isUsable.CompareTo(_second.m_isUsable);
        }

        if (!_first.m_isUsable && (_first.m_isHoldable != _second.m_isHoldable)) {
            return _first.m_isHoldable.CompareTo(_second.m_isHoldable);
        }

        return _first.m_name.CompareTo(_second.m_name);
    }

    private bool InsertImp(ItemMetadata _item, int _idx)
    {
        if (m_inventory[_idx] != null || _item == null)
        {
            return false;
        }

        m_inventory[_idx] = _item;
        ++m_numItems;
        return true;
    }

    private bool InsertImp(ItemMetadata _item)
    {
        if (_item == null)
        {
            return false;
        }

        for (int i = 0; i < m_capacity; ++i)
        {
            if (m_inventory[i] == null)
            {
                m_inventory[i] = _item;
                ++m_numItems;

                EventManager.TriggerEvent(InventoryEvent.INVENTORY_CHANGED);
                return true;
            }
        }

        Debug.Log("Inventory::Insert: can't add item, inventory is full");
        return false;
    }

    private ItemMetadata RemoveImp(int _idx) 
    {
        if (m_inventory[_idx] == null)
        {
            return null;
        }

        ItemMetadata retval = m_inventory[_idx];
        m_inventory[_idx] = null;
        --m_numItems;
        return retval;
    }

    public void MoveImp(int _from, int _to)
    {
        ItemMetadata tmp = m_inventory[_to];
        m_inventory[_to] = m_inventory[_from];
        m_inventory[_from] = tmp;
    }

}

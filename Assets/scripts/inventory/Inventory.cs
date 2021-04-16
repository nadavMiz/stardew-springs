using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public class ItemStack
    {
        public ItemMetadata m_item = null;
        public int m_numItems = 0;
    }

    public List<ItemMetadata> m_initialItems;
    public int m_capacity { get; private set; } = 10;
    private List<ItemStack> m_inventory;
    private int m_numItems = 0;
    public int m_selectedItem = 0;

    private void Start()
    {
        m_inventory = new List<ItemStack>(m_capacity);
        for (int i = 0; i < m_capacity; ++i) m_inventory.Add(new ItemStack());

        foreach (ItemMetadata item in m_initialItems) 
        {
            InsertImp(item);
        }

        EventManager.TriggerEvent(InventoryEvent.INVENTORY_CHANGED);
    }

    public ItemMetadata GetItem(int _idx)
    {
        return m_inventory[_idx].m_item;
    }

    public int GetItemQuantity(int _idx)
    {
        return m_inventory[_idx].m_numItems;
    }

    public int Insert(ItemMetadata _item) 
    {
        int idx = InsertImp(_item);
        if (idx >= 0) {
            EventManager.TriggerEvent(InventoryEvent.INVENTORY_CHANGED);
        }
        return idx;
    }

    public ItemMetadata SetSelectedItem(int _idx) 
    {
        if (_idx != m_selectedItem) 
        {
            m_selectedItem = _idx;
            EventManager.TriggerEvent(InventoryEvent.INVENTORY_CHANGED);
        }
        return m_inventory[_idx].m_item;
    }

    public int GetSelectedItemIdx() 
    {
        return m_selectedItem;
    }

    public ItemMetadata RemoveOne(int _idx) 
    {
        if (m_inventory[_idx].m_item == null)
        {
            return null;
        }

        if (m_inventory[_idx].m_numItems == 1) 
        {
            return RemoveAll(_idx);
        }

        --m_inventory[_idx].m_numItems;
        return m_inventory[_idx].m_item;
    }

    public ItemMetadata RemoveAll(int _idx)
    {
        if (m_inventory[_idx].m_item == null)
        {
            return null;
        }

        ItemMetadata item = m_inventory[_idx].m_item;
        m_inventory[_idx].m_item = null;
        m_inventory[_idx].m_numItems = 0;
        --m_numItems;
        EventManager.TriggerEvent(InventoryEvent.INVENTORY_CHANGED);
        return item;
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
        //TODO add combine?
        m_inventory.Sort(ItemComparison);
        EventManager.TriggerEvent(InventoryEvent.INVENTORY_CHANGED);
    }

    static private int ItemComparison(ItemStack _first, ItemStack _second)
    {
        if(_first.m_item.m_isUsable != _second.m_item.m_isUsable) {
            return _first.m_item.m_isUsable.CompareTo(_second.m_item.m_isUsable);
        }

        if (!_first.m_item.m_isUsable && (_first.m_item.m_isHoldable != _second.m_item.m_isHoldable)) {
            return _first.m_item.m_isHoldable.CompareTo(_second.m_item.m_isHoldable);
        }

        return _first.m_item.m_name.CompareTo(_second.m_item.m_name);
    }

    private int InsertImp(ItemMetadata _item)
    {
        if (_item == null)
        {
            return -1;
        }

        int idx = FindFreeStack(_item.name);
        if (idx >= 0) 
        {
            ++m_inventory[idx].m_numItems;
            return idx;
        }
        idx = FindEmptySlot();
        if (idx >= 0) 
        {
            m_inventory[idx].m_item = _item;
            m_inventory[idx].m_numItems = 1;
            return idx;
        }

        Debug.Log("Inventory::Insert: can't add item, inventory is full");
        return -1;
    }

    private int FindFreeStack(string _itemName) 
    {
        for (int i = 0; i < m_capacity; ++i) 
        {
            if (m_inventory[i].m_item != null &&  _itemName == m_inventory[i].m_item.m_name && m_inventory[i].m_numItems < m_inventory[i].m_item.m_inventoryCapacity) 
            {
                return i;
            }
        }
        return -1;
    }

    private int FindEmptySlot()
    {
        for (int i = 0; i < m_capacity; ++i)
        {
            if (m_inventory[i].m_item == null)
            {
                return i;
            }
        }

        return -1;
    }

    public void MoveImp(int _from, int _to)
    {
        ItemStack tmp = m_inventory[_to];
        m_inventory[_to] = m_inventory[_from];
        m_inventory[_from] = tmp;
    }

}

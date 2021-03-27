using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    private ItemSlot[] m_itemSlots;
    public Inventory m_inventory;

    // Start is called before the first frame update
    void Start()
    {
        m_itemSlots = GetComponentsInChildren<ItemSlot>();

        EventManager.Subscribe(InventoryEvent.INVENTORY_CHANGED, UpdateUI);
    }

    private void UpdateUI()
    {
        for(int i = 0; i < m_itemSlots.Length && i < m_inventory.m_capacity; ++i)
        {
            m_itemSlots[i].SetItem(m_inventory.GetItem(i));
        }
    }
}

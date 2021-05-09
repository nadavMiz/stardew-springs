using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    public Inventory m_inventory;
    private ItemSlot[] m_itemSlots;
    private int m_activeItem = 0;

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
            m_itemSlots[i].SetItem(m_inventory.GetItem(i), m_inventory.GetItemQuantity(i));
        }

        m_itemSlots[m_activeItem].Highlight(false);
        m_itemSlots[m_inventory.GetSelectedItemIdx()].Highlight(true);
        m_activeItem = m_inventory.GetSelectedItemIdx();
    }
}

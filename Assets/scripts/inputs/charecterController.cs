using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charecterController : MonoBehaviour
{
    public float m_speed = 4.0f;
    public Inventory m_inventory;

    private Rigidbody2D m_rigidbody2D;
    private Vector3 m_Velocity = Vector3.zero;
    private float m_MovementSmoothing = 0.05f;

    private Vector2 m_orientation = Vector2.right;

    private int m_equipedItem;
    private GameObject m_heldItem;

    private Collider2D m_collider;

    private void Start()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        m_collider = GetComponent<Collider2D>();
        changeItem(0);
    }

    public void Move(Vector2 _direction)
    {
        changeOrientation(_direction);
        Vector3 targetVelocity = new Vector2(_direction.x * m_speed, _direction.y * m_speed);
        m_rigidbody2D.velocity = Vector3.SmoothDamp(m_rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
    }

    public void UseItem() 
    {
        Debug.Log(m_inventory.GetItem(m_equipedItem) + "UseItem");
        if (m_inventory.GetItem(m_equipedItem) != null && m_inventory.GetItem(m_equipedItem).m_useFunc != null)
        {
            m_inventory.GetItem(m_equipedItem).m_useFunc.Use(gameObject, m_orientation);
        }
    }

    public bool changeItem(int idx) 
    {
        if (idx >= m_inventory.m_capacity || idx < 0) 
        {
            return false;
        }

        Destroy(m_heldItem);

        m_equipedItem = idx;
        ItemMetadata item = m_inventory.SetSelectedItem(idx);
        if (item != null && item.m_item != null)
        {
            GameObject itemPrefab = item.m_item;
            Debug.Log(itemPrefab);
            //TODO ugly hack - when instentiating objects with parent the object gets modified scale. so we instantiate it outside parent. 
            //assign parent
            m_heldItem = Instantiate(itemPrefab, new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z), transform.rotation);
            m_heldItem.transform.parent = transform;
        }
        return true;
    }

    public void interactWithObject() 
    {
        RaycastHit2D hit = CommonItemActions.raycast(m_orientation, m_collider);
        if (hit.collider != null )
        {
            if (hit.transform.gameObject.GetComponent<IIteractable>() != null)
            {
                hit.transform.gameObject.GetComponent<IIteractable>().interact();
            }
            else if (hit.transform.gameObject.GetComponent<Ipickable>() != null) 
            {
                pickUp(hit.transform.gameObject.GetComponent<Ipickable>());

            }
        }
    }

    private void pickUp(Ipickable _pickable) 
    {
        if (m_inventory.IsFull()) 
        {
            Debug.Log("charecterController::pickUp: can't pick up new item. inventory is full");
            return;
        }

        ItemMetadata item = _pickable.pick();
        int idx = m_inventory.Insert(item);
    }

    private void changeOrientation(Vector2 direction)
    {
        Vector2 orientation;
        if (direction == Vector2.zero) {
            //don't change orientation when stop moving
            return;
        } 
        else if (direction.x > 0) 
        {
            orientation = Vector2.right;
        } 
        else if (direction.x < 0) 
        {
            orientation = Vector2.left;
        } 
        else if (direction.y > 0) 
        {
            orientation = Vector2.up;
        } 
        else 
        {
            //default to face down
            orientation = Vector2.down;
        }

        // guarantee to set orientation only if changed 
        if (orientation != m_orientation) {
            m_orientation = orientation;
        }
    }

}

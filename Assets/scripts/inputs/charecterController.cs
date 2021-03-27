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

    private GameObject m_equipedItem;

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
        if (m_equipedItem != null)
        {
            m_equipedItem.SendMessage("use", m_orientation);
        }
    }

    public bool changeItem(int idx) 
    {
        if (idx >= m_inventory.m_capacity || idx < 0) 
        {
            return false;
        }

        Destroy(m_equipedItem);
        if (m_inventory.GetItem(idx) == null || m_inventory.GetItem(idx).m_item == null)
        {
            m_equipedItem = null;
        }
        else 
        {
            GameObject itemPrefab = m_inventory.GetItem(idx).m_item;
            Debug.Log(itemPrefab);
            m_equipedItem = Instantiate(itemPrefab, transform);
        }
        return true;
    }

    public void interactWithObject() 
    {
        RaycastHit2D hit = CommonItemActions.raycast(m_orientation, m_collider);
        if (hit.collider != null)
        {
            hit.transform.gameObject.SendMessage("interact");
        }
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

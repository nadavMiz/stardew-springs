using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{

    public string m_plantName;

    private Collider2D m_collider;

    private void OnEnable()
    {
        m_collider = GetComponentInParent<Collider2D>();
    }

    public void use(Vector2 _direction) 
    {
        RaycastHit2D hit = CommonItemActions.raycast(_direction, m_collider);
        if (!hit)
        {
            return;
        }

        TileGO tile = hit.transform.gameObject.GetComponent<TileGO>();
        if (tile) 
        {
            tile.changeto(m_plantName);
        }
    }
}

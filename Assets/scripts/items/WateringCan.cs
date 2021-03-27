using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCan : MonoBehaviour
{
    private Collider2D m_collider;

    private void OnEnable()
    {
        m_collider = GetComponentInParent<Collider2D>();
    }

    public void use(Vector2 _direction)
    {
        RaycastHit2D hit = CommonItemActions.raycast(_direction, m_collider);
        if ( hit.collider != null)
        {
            hit.transform.gameObject.SendMessage("Water", SendMessageOptions.DontRequireReceiver);
        }
    }
}

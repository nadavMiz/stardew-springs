using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCan : MonoBehaviour, Iuseable
{
    private Collider2D m_collider;

    private void OnEnable()
    {
        m_collider = GetComponentInParent<Collider2D>();
    }

    public Iuseable.status Use(GameObject _actor, Vector2 _direction)
    {
        Collider2D collider = _actor.GetComponent<Collider2D>();
        RaycastHit2D hit = CommonItemActions.raycast(_direction, collider);
        if (hit.collider == null)
        {
            return Iuseable.status.e_none;
        }

        hit.transform.gameObject.SendMessage("Water", SendMessageOptions.DontRequireReceiver);
        return Iuseable.status.e_none;
    }
}

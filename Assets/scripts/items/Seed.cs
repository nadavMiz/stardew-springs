using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed: MonoBehaviour, Iuseable
{

    public string m_plantName;

    public Iuseable.status Use(GameObject _actor, Vector2 _direction)
    {
        Collider2D collider = _actor.GetComponent<Collider2D>();

        RaycastHit2D hit = CommonItemActions.raycast(_direction, collider);
        if (!hit)
        {
            return Iuseable.status.e_none;
        }

        TileGO tile = hit.transform.gameObject.GetComponent<TileGO>();
        if (tile)
        {
            tile.changeto(m_plantName);
            return Iuseable.status.e_consume;
        }

        return Iuseable.status.e_none;
    }
}

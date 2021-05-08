using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hoe : MonoBehaviour, Iuseable
{
    private string tilledTile = "hole";

    public Iuseable.status Use(GameObject _actor, Vector2 _direction)
    {
        Collider2D collider = _actor.GetComponent<Collider2D>();
        RaycastHit2D hit = CommonItemActions.raycast(_direction, collider);
        if (!hit)
        {
            return Iuseable.status.e_none;
        }

        TileGO tile = hit.transform.gameObject.GetComponent<TileGO>();
        if (tile && !tile.isTilled())
        {
            tile.changeto(tilledTile);
        }

        return Iuseable.status.e_none;
    }

}

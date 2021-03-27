using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonItemActions
{
    private static float TILE_SIZE = 1;

    public static RaycastHit2D raycast(Vector2 _direction, Collider2D _collider) 
    {
        // end of boundry + 0.25 of a tile. the idea is to collide with the tile in front of you, but not necessarily the on you are stepping on
        Vector3 offset = _direction * _collider.bounds.extents + _direction * TILE_SIZE * 0.25f;
        float distance = TILE_SIZE * 0.25f;
        Vector3 origin = _collider.bounds.center + offset;

        return Physics2D.Raycast(origin, _direction, distance);
    }
    
}

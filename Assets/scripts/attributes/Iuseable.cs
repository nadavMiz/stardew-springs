using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Iuseable 
{
    enum status 
    {
        e_none = 0,
        e_consume = 1
    }

    Iuseable.status Use(GameObject _actor, Vector2 _direction);
}

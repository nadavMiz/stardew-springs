using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class CharecterAnimation : MonoBehaviour
{
    private Animator m_anim;
    private SpriteRenderer m_renderer;
    private Vector2 m_direction = Vector2.zero;
    private int m_verticalOrientation = -1;

    private void Start()
    {
        m_anim = GetComponent<Animator>();
        m_renderer = GetComponent<SpriteRenderer>();
        Assert.IsNotNull(m_anim);
        Assert.IsNotNull(m_renderer);
    }

    public void move(Vector2 _direction) 
    {
        if (_direction == m_direction) 
        {
            return;
        }

        if (shouldRotate(_direction)) 
        {
            Rotate();
        }

        m_anim.SetInteger("horizontalMoveDirection", System.Math.Sign(_direction.x));
        m_anim.SetInteger("verticalMoveDirection", System.Math.Sign(_direction.y));
        m_direction = _direction;
    }

    public void useItem(ItemMetadata.ItemId itemID) 
    {
        m_anim.SetInteger("itemId", (int)itemID);
        m_anim.SetTrigger("useItem");
    }

    private bool shouldRotate(Vector2 _direction)
    {
        return _direction.x * m_verticalOrientation < 0;
    }

    private void Rotate() 
    {
        m_renderer.flipX = !m_renderer.flipX;
        m_verticalOrientation *= -1;
    }
}

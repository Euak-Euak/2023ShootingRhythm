using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletData : MonoBehaviour
{
    public Vector2 Size;
    public Sprite Sprite;

    public void Awake()
    {
        Size = GetComponent<CapsuleCollider2D>().size;
        Sprite = GetComponent<SpriteRenderer>().sprite;
    }
}

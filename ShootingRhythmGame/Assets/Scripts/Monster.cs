using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster : Attackable
{
    [SerializeField]
    private Sprite _bulletSprite;

    public override void Dead()
    {
        gameObject.SetActive(false);
    }

    public abstract void Attack();

    public Bullet Shoot(Vector3 pos, float speed, float angle, Sprite sprite = null)
    {
        Bullet bullet = BulletManager.Instance.SpawnObject();
        
        if (sprite == null)
            sprite = _bulletSprite;
        
        bullet.Init(pos, speed, angle, 1, sprite, LayerMask.NameToLayer("Player"));
        return bullet;
    }
}

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

    public Bullet Shoot(Vector3 pos, float speed, float angle, int damage, Sprite sprite = null)
    {
        Bullet bullet = BulletManager.Instance.SpawnObject();
        
        if (sprite == null)
            sprite = _bulletSprite;
        
        bullet.Init(pos, speed, angle, damage, sprite, LayerMask.NameToLayer("Player"));
        return bullet;
    }

    public Laser Beam(Vector3 pos, float angle, int damage, float time, float stayTime, Sprite sprite = null)
    {
        Laser laser = LaserManager.Instance.SpawnObject();

        if (sprite == null)
            sprite = _bulletSprite;

        laser.Init(pos, angle, damage, sprite, LayerMask.NameToLayer("Player"));
        laser.Shoot(time, stayTime);
        return laser;
    }
}

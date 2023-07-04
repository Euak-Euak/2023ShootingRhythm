using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster : Attackable
{
    public override void Dead()
    {
        gameObject.SetActive(false);
    }

    public abstract void Attack();

    public Bullet Shoot(Transform pos, float speed, float angle, Sprite sprite)
    {
        Bullet bullet = BulletManager.Instance.SpawnObject();
        bullet.Init(pos, speed, angle, sprite, LayerMask.NameToLayer("Player"));
        return bullet;
    }
}

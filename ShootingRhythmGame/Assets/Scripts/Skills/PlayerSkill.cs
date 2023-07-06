using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerSkill : MonoBehaviour
{
    [SerializeField]
    private Sprite _bulletSprite;

    public Bullet Shoot(Transform pos, float speed, float angle, Sprite sprite = null)
    {
        Bullet bullet = BulletManager.Instance.SpawnObject();

        if (sprite == null)
            sprite = _bulletSprite;

        bullet.Init(pos, speed, angle, sprite, LayerMask.NameToLayer("Player"));
        return bullet;
    }

    public abstract void SkillUse();
}

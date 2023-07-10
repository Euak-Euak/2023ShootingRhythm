using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerSkill : MonoBehaviour
{
    [SerializeField]
    public Sprite _bulletSprite;

    public string _skillName;
    public string _skillImage;
    public string _commandNormal;
    public string _commandPowerUp;
    public int _skillDamage;
    public int _bulletType;
    public bool _isPowerUp;

    public void Init(int ID)
    {
        _skillName = DataManager.Instance.SkillName(ID);
        _commandNormal = DataManager.Instance.CommandNormal(ID);
        _commandPowerUp = DataManager.Instance.CommandPowerUp(ID);
        _skillDamage = DataManager.Instance.SkillValue(ID);
        _bulletType = DataManager.Instance.BulletType(ID);
        _isPowerUp = DataManager.Instance.IsPowerUp(ID);
        _skillImage = DataManager.Instance.SkillImage(ID);
    }

    public Bullet Shoot(Vector3 pos, float speed, float angle, int damage, Sprite sprite = null)
    {
        Bullet bullet = BulletManager.Instance.SpawnObject();

        if (sprite == null)
            sprite = _bulletSprite;

        bullet.Init(pos, speed, angle, damage, sprite, LayerMask.NameToLayer("Monster"));
        return bullet;
    }

    public void SkillUse()
    {
        if (_isPowerUp)
        {
            SkillUsePowerUp();
        }
        else
        {
            SkillUseNormal();
        }
    }

    protected abstract void SkillUseNormal();
    protected abstract void SkillUsePowerUp();
}

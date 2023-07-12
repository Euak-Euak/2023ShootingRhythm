using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LudditeSkill : PlayerSkill
{
    protected override void SkillUseNormal()
    {
        StartCoroutine(NormalSkill());
    }
        
    protected override void SkillUsePowerUp()
    {
        StartCoroutine(PowerUpSkill());
    }

    IEnumerator NormalSkill()
    {
        for (int i = 0; i <= 360; i += 5)
        {
            Shoot(transform.position, 5f, i, _skillDamage).SetBulletData(Resources.Load<GameObject>($"BulletData/{_bulletType}"));
            Shoot(transform.position, 5f, i + 180, _skillDamage).SetBulletData(Resources.Load<GameObject>($"BulletData/{_bulletType}"));
            yield return new WaitForSecondsRealtime(0.006f);

        }
        yield return null;
    }

    IEnumerator PowerUpSkill()
    {
        for (int i = 0; i <= 480; i += 5)
        {
            Shoot(transform.position, 5f, i, _skillDamage).SetBulletData(Resources.Load<GameObject>($"BulletData/{_bulletType}"));
            Shoot(transform.position, 5f, i + 120, _skillDamage).SetBulletData(Resources.Load<GameObject>($"BulletData/{_bulletType}"));
            Shoot(transform.position, 5f, i + 240, _skillDamage).SetBulletData(Resources.Load<GameObject>($"BulletData/{_bulletType}"));
            yield return new WaitForSecondsRealtime(0.0005f);
        }
        yield return null;
    }
}

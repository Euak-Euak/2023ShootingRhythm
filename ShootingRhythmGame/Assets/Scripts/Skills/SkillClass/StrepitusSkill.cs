using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrepitusSkill : PlayerSkill
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
        for (int i = 1; i < 4; i++)
        {
            for(int j = -45; j <= 45; j += 5)
            {
                Shoot(transform.position, 6.5f, j, _skillDamage).SetBulletData(Resources.Load<GameObject>($"BulletData/{_bulletType}"));
            }
            yield return new WaitForSecondsRealtime(i * 0.05f);
        }
        yield return null;
    }

    IEnumerator PowerUpSkill()
    {
        for (int i = 1; i < 7; i++)
        {
            for (int j = -45; j <= 45; j += 3)
            {
                Shoot(transform.position, 6.5f, j, _skillDamage).SetBulletData(Resources.Load<GameObject>($"BulletData/{_bulletType}"));
            }
            yield return new WaitForSecondsRealtime(i * 0.02f);
        }
        yield return null;
    }
}

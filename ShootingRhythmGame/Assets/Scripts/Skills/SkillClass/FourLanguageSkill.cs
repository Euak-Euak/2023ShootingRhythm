using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourLanguageSkill : PlayerSkill
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
        for (int k = 0; k < Random.Range(1, 7); k++)
        {
            for (int j = 0; j < 3; j++)
            {
                for (float i = -22.5f; i <= 22.5f; i += 15)
                {
                    Shoot(transform.position, 5f, i, _skillDamage).SetBulletData(Resources.Load<GameObject>($"BulletData/{_bulletType}"));
                }
                yield return new WaitForSeconds(0.04f);
            }
                yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator PowerUpSkill()
    {
        for (int k = 0; k < Random.Range(5, 9); k++)
        {
            for (int j = 0; j < 4; j++)
            {
                for (float i = -22.5f; i <= 22.5f; i += 15)
                {
                    Shoot(transform.position, 5f, i, _skillDamage).SetBulletData(Resources.Load<GameObject>($"BulletData/{_bulletType}"));
                }
                yield return new WaitForSeconds(0.04f);
            }

            for (int j = 0; j < 6; j++)
            {
                for (float i = -30f; i <= 30f; i += 15)
                {
                    Shoot(transform.position, 5f, i, _skillDamage).SetBulletData(Resources.Load<GameObject>($"BulletData/{_bulletType2}"));
                }
                yield return new WaitForSeconds(0.02f);
            }
        }
    }
}

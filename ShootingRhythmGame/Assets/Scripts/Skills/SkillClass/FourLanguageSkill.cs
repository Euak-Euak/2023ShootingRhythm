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
        for (int j = 0; j < 6; j++)
        {
            for (float i = -22.5f; i <= 22.5f; i += 15)
            {
                Shoot(transform.position, 5f, i, _skillDamage);
            }
                yield return new WaitForSeconds(0.04f);
        }
    }

    IEnumerator PowerUpSkill()
    {
        for (int j = 0; j < 6; j++)
        {
            for (float i = -22.5f; i <= 22.5f; i += 15)
            {
                Shoot(transform.position, 5f, i, _skillDamage);
            }
            yield return new WaitForSeconds(0.04f);
        }

        yield return new WaitForSeconds(0.1f);

        for (int j = 0; j < 6; j++)
        {
            for (float i = -30f; i <= 30f; i += 15)
            {
                Shoot(transform.position, 5f, i, _skillDamage);
            }
            yield return new WaitForSeconds(0.04f);
        }
    }
}

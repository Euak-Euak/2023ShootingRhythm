using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntikytheraOverloadSkill : PlayerSkill
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
        for (int j = 0; j < 3;)
        {
            for (int i = 0; i <= 360; i += 10)
            {
                Shoot(transform.position, 4f, i, _skillDamage).SetBulletData(Resources.Load<GameObject>($"BulletData/{_bulletType}"));
            }
            j++;
            yield return new WaitForSecondsRealtime(0.2f);
        }
        yield return null;
    }

    IEnumerator PowerUpSkill()
    {
        for (int j = 0; j < 5;)
        {
            for (int i = 0; i <= 360; i += 15)
            {
                StartCoroutine(PowerUpSkill_s(Shoot(transform.position, 3f, i, _skillDamage)));
            }
            j++;
            yield return new WaitForSecondsRealtime(0.1f);
        }
        yield return null;
    }

    IEnumerator PowerUpSkill_s(Bullet bullet)
    {
        bullet.SetBulletData(Resources.Load<GameObject>($"BulletData/{_bulletType}"));
        float t = 0f;
        while (t < 1.5f)
        {
            t += Time.deltaTime;
            yield return null;
            if (!bullet.gameObject.activeSelf)
                yield break;
        }
        float angle = Random.Range(0, 360);
        Shoot(bullet.transform.position, 8f, angle, _skillDamage).SetBulletData(Resources.Load<GameObject>($"BulletData/{_bulletType2}"));
        Shoot(bullet.transform.position, 8f, angle + 180, _skillDamage / 2).SetBulletData(Resources.Load<GameObject>($"BulletData/{_bulletType2}"));
        bullet.gameObject.SetActive(false);
        yield return new WaitForSecondsRealtime(0.1f);

        yield return null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntikytheraBoomSkill : PlayerSkill
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
        Bullet bullet = Shoot(transform.position, 5f, 0, _skillDamage);
        bullet.SetBulletData(Resources.Load<GameObject>($"BulletData/{_bulletType}"));
        float t = 0f;
        while (t < 0.5f)
        {
            t += Time.deltaTime;
            yield return null;
            if (!bullet.gameObject.activeSelf)
                yield break;
        }

        bullet.gameObject.SetActive(false);
        for (int j = 0; j < 3;)
        {
            for (int i = 0; i <= 360; i += 10)
            {
                Shoot(bullet.transform.position, 5f, i, _skillDamage * 2 / 3).SetBulletData(Resources.Load<GameObject>($"BulletData/{_bulletType2}"));
            }
            j++;
            yield return new WaitForSecondsRealtime(0.5f);
        }
        yield return null;
    }

    IEnumerator PowerUpSkill()
    {
        Bullet bullet = Shoot(transform.position, 6f, 0, _skillDamage);
        bullet.SetBulletData(Resources.Load<GameObject>($"BulletData/{_bulletType}"));
        float t = 0f;
        while (t < 0.5f)
        {
            t += Time.deltaTime;
            yield return null;
        }

        bullet.gameObject.SetActive(false);
        for (int j = 0; j < 5;)
        {
            for (int i = 0; i <= 360; i += 15)
            {
                Shoot(bullet.transform.position, 5f, i, _skillDamage * 2 / 3).SetBulletData(Resources.Load<GameObject>($"BulletData/{_bulletType2}"));
            }
            j++;
            yield return new WaitForSecondsRealtime(0.2f);
        }
        yield return null;
    }
}

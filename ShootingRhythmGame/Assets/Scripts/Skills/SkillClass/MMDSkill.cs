using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMDSkill : PlayerSkill
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
        Bullet bullet = Shoot(transform.position, 4f, 0, _skillDamage);
        bullet.SetBulletData(Resources.Load<GameObject>($"BulletData/{_bulletType}"));

        float ti = 0f;

        while (ti < 1f)
        {
            ti += Time.deltaTime;
            yield return null;
            if (!bullet.gameObject.activeSelf)
                yield break;
        }
        bullet.gameObject.SetActive(false);

        for (float t = 0; t < 2 * Mathf.PI; t += 0.05f * Mathf.PI)
        {
            float x = 16 * Mathf.Sin(t) * Mathf.Sin(t) * Mathf.Sin(t);
            float y = 13 * Mathf.Cos(t) - 5 * Mathf.Cos(2 * t) - 2 * Mathf.Cos(3 * t) - Mathf.Cos(4 * t);

            Vector2 vector = new Vector2(x + transform.position.x, y + transform.position.y);
            Vector2 angle = (Vector2)transform.position - vector;
            float de = Mathf.Atan2(angle.y, angle.x) * Mathf.Rad2Deg + 90;
            float dis = Vector2.Distance(transform.position, vector);

            Shoot(bullet.transform.position, dis / 3, de, _skillDamage * 2 / 3).SetBulletData(Resources.Load<GameObject>($"BulletData/{_bulletType2}"));
        }
        yield return null;
    }

    IEnumerator PowerUpSkill()
    {
        Vector2 vectorA = new Vector2(transform.position.x + 1.5f,transform.position.y);
        Vector2 vectorB = new Vector2(transform.position.x - 1.5f, transform.position.y);

        Bullet bullet = Shoot(transform.position, 5f, 0, _skillDamage);
        Bullet bullet2 = Shoot(vectorA, 3f, 0, _skillDamage);
        Bullet bullet3 = Shoot(vectorB, 3f, 0, _skillDamage);

        bullet.SetBulletData(Resources.Load<GameObject>($"BulletData/{_bulletType}"));
        bullet2.SetBulletData(Resources.Load<GameObject>($"BulletData/{_bulletType}"));
        bullet3.SetBulletData(Resources.Load<GameObject>($"BulletData/{_bulletType}"));

        float ti = 0f;

        while (ti < 1f)
        {
            ti += Time.deltaTime;
            yield return null;
            if (!bullet.gameObject.activeSelf)
                yield break;
        }
        bullet.gameObject.SetActive(false);

        for (float t = 0; t < 2 * Mathf.PI; t += 0.05f * Mathf.PI)
        {
            float x = 16 * Mathf.Sin(t) * Mathf.Sin(t) * Mathf.Sin(t);
            float y = 13 * Mathf.Cos(t) - 5 * Mathf.Cos(2 * t) - 2 * Mathf.Cos(3 * t) - Mathf.Cos(4 * t);

            Vector2 vector = new Vector2(x + transform.position.x, y + transform.position.y);
            Vector2 angle = (Vector2)transform.position - vector;
            float de = Mathf.Atan2(angle.y, angle.x) * Mathf.Rad2Deg + 90;
            float dis = Vector2.Distance(transform.position, vector);

            Shoot(bullet.transform.position, dis / 3, de, _skillDamage * 2 / 3).SetBulletData(Resources.Load<GameObject>($"BulletData/{_bulletType2}"));
            Shoot(bullet2.transform.position, dis / 3, de, _skillDamage * 2 / 3).SetBulletData(Resources.Load<GameObject>($"BulletData/{_bulletType2}"));
            Shoot(bullet3.transform.position, dis / 3, de, _skillDamage * 2 / 3).SetBulletData(Resources.Load<GameObject>($"BulletData/{_bulletType2}"));
        }
        yield return null;
    }
}

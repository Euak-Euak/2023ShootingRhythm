using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShareDataSkill : PlayerSkill
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
        Vector2 vector = transform.position;
        for (int j = 0; j < 3; j++)
        {
            Vector3 trans;
            
            for (float i = -0.4f; i <= 0.4f; i += 0.2f)
            {
                trans = new Vector3(vector.x + i, vector.y);
                Shoot(trans, 5f, 0, _skillDamage).SetBulletData(Resources.Load<GameObject>($"BulletData/{_bulletType}"));


                trans = new Vector3(vector.x - i, vector.y);
                Shoot(trans, 5f, 0, _skillDamage).SetBulletData(Resources.Load<GameObject>($"BulletData/{_bulletType}"));

                yield return new WaitForSeconds(0.07f);
            }
            trans = new Vector3(vector.x - 0.13f, vector.y + 0.23f);
            Shoot(trans, 5f, 0, _skillDamage).SetBulletData(Resources.Load<GameObject>($"BulletData/{_bulletType}"));
            trans = new Vector3(vector.x + 0.13f, vector.y + 0.23f);
            Shoot(trans, 5f, 0, _skillDamage).SetBulletData(Resources.Load<GameObject>($"BulletData/{_bulletType}"));
        }
        yield return null;
    }

    IEnumerator PowerUpSkill()
    {
        Vector2 vector = transform.position;
        for (int j = 0; j < 6; j++)
        {
            Vector3 trans;

            for (float i = -0.4f; i <= 0.4f; i += 0.2f)
            {
                trans = new Vector3(vector.x + i, vector.y);
                StartCoroutine(PowerUpSkill_s(Shoot(trans, 5f, 0, _skillDamage)));

                trans = new Vector3(vector.x - i, vector.y);
                StartCoroutine(PowerUpSkill_s(Shoot(trans, 5f, 0, _skillDamage)));

                yield return new WaitForSeconds(0.07f);
            }
            trans = new Vector3(vector.x - 0.13f, vector.y + 0.23f);
            StartCoroutine(PowerUpSkill_s(Shoot(trans, 5f, 0, _skillDamage)));
            trans = new Vector3(vector.x + 0.13f, vector.y + 0.23f);
            StartCoroutine(PowerUpSkill_s(Shoot(trans, 5f, 0, _skillDamage)));
        }
        yield return null;
    }

    IEnumerator PowerUpSkill_s(Bullet bullet)
    {
        bullet.SetBulletData(Resources.Load<GameObject>($"BulletData/{_bulletType}"));
        float t = 0;
        while (t <= 1.5f)
        {
            t += Time.deltaTime;
            yield return null;
            if (!bullet.gameObject.activeSelf)
                yield break;
        }
        float angle = Random.Range(0, 360);

        Shoot(bullet.transform.position, 5f, angle, _skillDamage * 2 / 3).SetBulletData(Resources.Load<GameObject>($"BulletData/{_bulletType2}"));
        Shoot(bullet.transform.position, 5f, angle + 180, _skillDamage * 2 / 3).SetBulletData(Resources.Load<GameObject>($"BulletData/{_bulletType2}"));
        bullet.gameObject.SetActive(false);

        yield return null;
    }
}

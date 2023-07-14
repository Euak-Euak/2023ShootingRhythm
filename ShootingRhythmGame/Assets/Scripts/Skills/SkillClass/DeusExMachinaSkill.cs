using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeusExMachinaSkill : PlayerSkill
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
        Vector3 vector = new Vector3(transform.position.x, transform.position.y + 0.5f);
        Beam(vector, 0, _skillDamage, 0.2f, 1f).SetBulletData(Resources.Load<GameObject>($"BulletData/{_bulletType}"));
        yield return null;
    }

    IEnumerator PowerUpSkill()
    {
        Vector3 vector = new Vector3(transform.position.x, transform.position.y + 0.5f);
        Beam(vector, 0, _skillDamage, 0.2f, 1f).SetBulletData(Resources.Load<GameObject>($"BulletData/{_bulletType}"));
        
        for (int i = 0; i < 3; i++)
        {
            Vector3 vector2 = new Vector3(vector.x + i, vector.y);
            Beam(vector2, 0, _skillDamage, 0.2f, 1f).SetBulletData(Resources.Load<GameObject>($"BulletData/{_bulletType}"));
            vector2 = new Vector3(vector.x + -i, vector.y);
            Beam(vector2, 0, _skillDamage, 0.2f, 1f).SetBulletData(Resources.Load<GameObject>($"BulletData/{_bulletType}"));
            yield return new WaitForSecondsRealtime(0.2f);
        }
        yield return null;
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SampleMonster : Monster
{
    [SerializeField]
    private Sprite _sprite;
    [SerializeField]
    private GameObject _bullet;

    public override void Attack()
    {
        StartCoroutine(AttackCircle());
    }
    
    IEnumerator AttackCircle()
    {
        yield return null;

            for (int i = 0; i <= 360; i += 5)
            {
                Shoot(transform.position, 5f, i, 1);
                Shoot(transform.position, 5f, i + 180, 1);
            }
    }

    IEnumerator AttackCircle2()
    {
        while (true)
        {

            for (int i = 0; i <= 80; i += 10)
            {
                yield return new WaitForSeconds(0.05f);
                for (int j = 0; j <= 360; j += 36)
                {
                    Shoot(transform.position, 7f, i + j, 1);
                }
            }
            for (int i = 90; i >= 10; i -= 10)
            {
                yield return new WaitForSeconds(0.05f);
                for (int j = 0; j <= 360; j += 36)
                {
                    Shoot(transform.position, 7f, i + j, 1);
                }
            }
        }
    }

    IEnumerator AttackCircle3()
    {
        while (true)
        {
            for (int i = 0; i <= 180; i += 10)
            {
                yield return new WaitForSeconds(01f);
                for (int j = 0; j <= 360; j += 36)
                {
                    StartCoroutine(AttackCircle3_s(i + j));
                }
            }
            yield return new WaitForSeconds(5f);
        }
    }

    IEnumerator AttackCircle3_s(float angle)
    {
        Bullet bullet = Shoot(transform.position, 7f, angle, 1);
        bullet.SetBulletData(_bullet);
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime;
            yield return null;
            if (!bullet.gameObject.activeSelf)
                yield break;
        }

        bullet.Init(bullet.transform.position, 0f, angle, 1, LayerMask.NameToLayer("Player"));
        yield return new WaitForSeconds(3f);

        bullet.Init(bullet.transform.position, 5f, angle + 180, 1, LayerMask.NameToLayer("Player"));
    }
}

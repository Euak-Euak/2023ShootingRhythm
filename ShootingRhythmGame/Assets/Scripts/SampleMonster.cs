using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SampleMonster : Monster
{
    [SerializeField]
    private Sprite _sprite;
    private void Start()
    {
        Attack();
    }

    public override void Attack()
    {
        StartCoroutine(AttackCircle3());
    }

    IEnumerator AttackCircle()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);

            for (int i = 0; i <= 360; i += 5)
            {
                Shoot(transform, 5f, i);
                Shoot(transform, 5f, i + 180);
                yield return new WaitForSeconds(0.1f);
            }
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
                    Shoot(transform, 7f, i + j);
                }
            }
            for (int i = 90; i >= 10; i -= 10)
            {
                yield return new WaitForSeconds(0.05f);
                for (int j = 0; j <= 360; j += 36)
                {
                    Shoot(transform, 7f, i + j);
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
                yield return new WaitForSeconds(0.1f);
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
        Bullet bullet = Shoot(transform, 7f, angle);
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime;
            yield return null;
            if (!bullet.gameObject.activeSelf)
                yield break;
        }

        bullet.Init(bullet.transform, 0f, angle, _sprite, LayerMask.NameToLayer("Player"));
        yield return new WaitForSeconds(3f);

        bullet.Init(bullet.transform, 5f, angle + 180, _sprite, LayerMask.NameToLayer("Player"));
    }
}
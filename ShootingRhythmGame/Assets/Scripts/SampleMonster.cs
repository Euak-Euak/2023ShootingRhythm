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
                Shoot(transform, 5f, i, _sprite);
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
                    Shoot(transform, 7f, i + j, _sprite);
                }
            }
            for (int i = 90; i >= 10; i -= 10)
            {
                yield return new WaitForSeconds(0.05f);
                for (int j = 0; j <= 360; j += 36)
                {
                    Shoot(transform, 7f, i + j, _sprite);
                }
            }
        }
    }

    IEnumerator AttackCircle3()
    {
        while (true)
        {
            List<Bullet> bullets = new List<Bullet>();

            for (int i = 0; i <= 180; i += 10)
            {
                yield return new WaitForSeconds(0.1f);
                for (int j = 0; j <= 360; j += 36)
                {
                    bullets.Add(Shoot(transform, 7f, i + j, _sprite));
                }
            }
            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Init(bullets[i].transform, 0f, 180, _sprite, LayerMask.NameToLayer("Player"));
            }
            yield return new WaitForSeconds(2f);

            for (int i = 0; i <= 180; i += 10)
            {
                yield return new WaitForSeconds(0.08f);
                for (int j = 0; j <= 360; j += 36)
                {
                    Shoot(transform, 15f, i + j, _sprite);
                }
            }

            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Init(bullets[i].transform, 7f, Random.Range(0, 360), _sprite, LayerMask.NameToLayer("Player"));
                bullets.RemoveAt(i);
            }
            yield return new WaitForSeconds(5f);
        }
    }
}

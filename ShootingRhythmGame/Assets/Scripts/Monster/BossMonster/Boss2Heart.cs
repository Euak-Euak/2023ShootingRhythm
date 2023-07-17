using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;

public class Boss2Heart : Monster
{
    public int heartNum;
    public Boss2 _boss;

    public bool isActive;

    public override void Attack()
    {
        StartCoroutine(AttackCorutine());
    }

    IEnumerator AttackCorutine()
    {
        while (true)
        {
            Bullet bullet = Shoot(transform.position, 5f, 225, 1);
            StartCoroutine(ShakeBullet(bullet));
            yield return new WaitForSecondsRealtime(0.2f);
        }
    }

    IEnumerator ShakeBullet(Bullet bullet)
    {
        yield return new WaitForSecondsRealtime(0.05f);

        bool position = true;
        while (bullet.gameObject.activeSelf)
        {
            if (position)
            {
                bullet.Init(bullet.transform.position, 8f, 135, 1);
            }
            else
            {
                bullet.Init(bullet.transform.position, 8f, 225, 1);
            }
            position = !position;
            yield return new WaitForSecondsRealtime(0.1f);
        }
        yield return null;
    }

    public IEnumerator Appear()
    {
        yield return null;
        transform.DOLocalMove(new Vector3(2.5f * heartNum, 1f), 1f);
        isActive = true;
        yield return new WaitForSecondsRealtime(1f);
        Attack();
        yield return null;
    }

    public IEnumerator Disappear()
    {
        StopAllCoroutines();
        isActive = false;
        transform.DOLocalMove(new Vector3(0, 0), 1f);
        yield return null;
    }

    void Start()
    {
        _boss = GetComponentInParent<Boss2>();
        isActive = false;
    }

    public override void Attacked(int damage)
    {
        _boss.Attacked(damage);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster3_3 : Monster
{
    private List<Bullet> _shoot = new List<Bullet>();
    private bool init = true;
    private bool alreadyGiven = false;


    public override void Init(EnemyData enemy, Vector2 handle)
    {
        base.Init(enemy, handle);
        _shoot.Clear();
        init = true;
    }


    public void Update()
    {
        if (init)
        {
            alreadyGiven = false;
            StartCoroutine(GiftForYou());
            init = false;
        }
    }


    public override void Attack()
    {
        StartCoroutine(Laetitia());
    }


    IEnumerator GiftForYou()
    {
        yield return new WaitForSeconds(0.8f);
        while (true)
        {
            if (!alreadyGiven)
            {
                Bullet shoot = Shoot(transform.position, 0, 0, 1);
                _shoot.Add(shoot);
                yield return new WaitForSeconds(1.4f);
            }
            else yield break;
        }
    }


    IEnumerator Laetitia()
    {
        alreadyGiven = true;

        yield return null;
        for (int i = 0; i < _shoot.Count; i++)
        {
            for (int j = 0; j <= 360; j += 40)
            {
                Shoot(_shoot[i].gameObject.transform.position, 7f, j, 1);
                Shoot(_shoot[i].gameObject.transform.position, 7f, j + 22.5f, 1);
            }
            _shoot[i].ReturnObject();
        }
    }


    public override void Dead()
    {
        for (int i = 0; i < _shoot.Count; i++)
        {
            _shoot[i].ReturnObject();
        }
        base.Dead();
    }
}
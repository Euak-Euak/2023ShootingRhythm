using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster4_3 : Monster
{
    private Animator anim;

    [SerializeField]
    private GameObject[] _handSprite;

    private int _midAngle;
    private Vector3 _pos;

    private List<Bullet> _stop = new List<Bullet>();


    public override void Init(EnemyData enemy, Vector2 handle)
    {
        base.Init(enemy, handle);
        _stop.Clear();
    }

    public void Start()
    {
        anim = GetComponent<Animator>();
    }


    public override void Attack()
    {
        _midAngle = Random.Range(-200, -160);
        if (_midAngle > -180) _pos = transform.position + new Vector3(-1f, 0);
        else  _pos = transform.position + new Vector3(1f, 0);
        StartCoroutine(Dantehe());
    }


    IEnumerator Dantehe()
    {
        anim.SetTrigger("shoot");

        for (int i = -1; i < 2; i++)
        {
            Bullet shoot = Shoot(_pos, 0f, _midAngle + i * 30, 1);
            shoot.SetBulletData(_handSprite[i+1]);
            StartCoroutine(Chimichimi(shoot, i+ 1 , i * 30));
            _stop.Add(shoot);

            yield return new WaitForSeconds(0.1f);
        }
    }


    IEnumerator Chimichimi(Bullet dan, int order, int del)
    {

        yield return new WaitForSeconds(1f - 0.1f * order);
        Bullet shoot = Shoot(_pos, 7.77f, _midAngle + del, 1);
        shoot.SetBulletData(_handSprite[order]);
        dan.ReturnObject();
    }


    public override void Dead()
    {
        for (int i = 0; i < _stop.Count; i++)
        {
            _stop[i].ReturnObject();
        }
        base.Dead();
    }
}
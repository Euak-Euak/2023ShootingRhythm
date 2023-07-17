using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster3_3 : Monster
{
    private float delta;
    private SpriteRenderer sr;
    private Animator anim;

    [SerializeField]
    private GameObject _bombSprite;

    private List<Bullet> _shoot = new List<Bullet>();
    private bool init = true;
    private bool alreadyGiven = false;


    public override void Init(EnemyData enemy, Vector2 handle)
    {
        base.Init(enemy, handle);
        _shoot.Clear();
        init = true;
    }


    public void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }


    public void Update()
    {
        if (init)
        {
            alreadyGiven = false;
            StartCoroutine(GiftForYou());
            init = false;
        }

        if (this.transform.position.x - delta > 0) sr.flipX = true;
        else if (this.transform.position.x - delta < 0) sr.flipX = false;

        delta = this.gameObject.transform.position.x;
    }


    public override void Attack()
    {
        StartCoroutine(Laetitia());
    }


    IEnumerator GiftForYou()
    {
        yield return new WaitForSeconds(1.5f);
        while (true)
        {
            if (!alreadyGiven)
            {
                anim.SetTrigger("set");
                Bullet shoot = Shoot(transform.position, 0, 0, 2);
                shoot.SetBulletData(_bombSprite);
                _shoot.Add(shoot);
                yield return new WaitForSeconds(1.4f);
            }
            else yield break;
        }
    }


    IEnumerator Laetitia()
    {
        alreadyGiven = true;
        anim.SetTrigger("shoot");

        yield return new WaitForSeconds(0.2f);
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
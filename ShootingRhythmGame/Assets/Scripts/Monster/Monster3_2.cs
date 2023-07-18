using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster3_2 : Monster
{
    //////////////////////// 熱薑й剪 元中號擠
    private float delta;
    private SpriteRenderer sr;
    private Animator anim;

    private int move = 0;
    private bool up = true;

    private float _originalVolume;


    public void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        _originalVolume = 1f; //
    }


    public void Update()
    {
        if (this.transform.position.x - delta > 0) sr.flipX = true;
        else if (this.transform.position.x - delta < 0) sr.flipX = false;

        delta = this.gameObject.transform.position.x;


        if (up)
        {
            transform.position += new Vector3(0f, 0.001f);
        }
        else
        {
            transform.position += new Vector3(0f, -0.001f);
        }
        move++;
        if (move == 500)
        {
            move = 0;
            up = !up;
        } //六六 敝雛
    }


    public override void Attack()
    {
        StartCoroutine(vibration());
    }


    IEnumerator vibration()
    {
        anim.SetTrigger("shoot");
        StartCoroutine(Mute());
        for (int i = 0; i <= 360; i += 20)
        {
            Shoot(transform.position, 10f, i, 1);
        }

        for (int i = 0; i <= 360; i += 30)
        {
            Bullet shoot = Shoot(transform.position, 1.2f, i, 1);
            StartCoroutine(emememem(shoot));
            yield return new WaitForSeconds(0.05f);
        }
    }


    IEnumerator emememem(Bullet shoot)
    {
        int dir = 1;
        while (true)
        {
            for (int i = 0; i < 3; i++)
            {
                shoot.transform.position += new Vector3(dir * 0.03f, 0f, 0f);
                yield return new WaitForSeconds(0.02f);
            }
            dir = -dir;
        }
    }


    IEnumerator Mute()
    {
        SoundManager.Instance.BGMVolume(0f);
        SoundManager.Instance.SFXVolume(0f);

        yield return new WaitForSeconds(BGMManager.Bpm/60);
        SoundManager.Instance.BGMVolume(_originalVolume);
    }


    public override void Dead()
    {
        SoundManager.Instance.BGMVolume(_originalVolume);
        SoundManager.Instance.SFXVolume(_originalVolume);
        base.Dead();
    }
}

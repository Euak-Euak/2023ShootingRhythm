using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster2_3 : Monster
{
    private float delta;
    private SpriteRenderer sr;
    private Animator anim;
    private CircleCollider2D coll2;


    public void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        coll2 = GetComponent<CircleCollider2D>();
    }


    public void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Monster2-3_Idle2")) coll2.enabled = true;
        else coll2.enabled = false;

        if (this.transform.position.x - delta > 0) sr.flipX = true;
        else if (this.transform.position.x - delta < 0) sr.flipX = false;

        delta = this.gameObject.transform.position.x;
    }


    public override void Attack()
    {
        StartCoroutine(Pang());
    }


    IEnumerator Pang()
    {
        yield return null;
        anim.SetTrigger("shoot");

        yield return new WaitForSeconds(0.2f);
        for (int i = 0; i < 360; i += 20)
        {
            Shoot(transform.position, 6f, i, 1);
        }
        //coll2.enabled = true;
    }
}

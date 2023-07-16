using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster0_3 : Monster
{
    private float delta;
    private SpriteRenderer sr;


    public void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        delta = this.gameObject.transform.position.x;
    }


    public void Update()
    {
        if (this.transform.position.x - delta > 0)      sr.flipX = true;
        else if (this.transform.position.x - delta < 0) sr.flipX = false;

        delta = this.gameObject.transform.position.x;
    }


    public override void Attack()
    {
        StartCoroutine(ColonColon());
    }


    IEnumerator ColonColon()
    {
        yield return null;
        for (int i = 0; i < 2; i++)
        {
            Shoot(transform.position + new Vector3 (0.5f, 0f, 0f), 4f, -180, 1);
            Shoot(transform.position + new Vector3 (-0.5f, 0f, 0f), 4f, -180, 1);
            yield return new WaitForSeconds(0.2f);
        }
    }
}
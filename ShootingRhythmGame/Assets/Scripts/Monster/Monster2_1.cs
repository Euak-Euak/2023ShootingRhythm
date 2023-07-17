using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster2_1 : Monster
{
    private float delta;
    private SpriteRenderer sr;


    public void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        StartCoroutine(Gratuitous());
    }


    public void Update()
    {
        if (this.transform.position.x - delta > 0) sr.flipX = true;
        else if (this.transform.position.x - delta < 0) sr.flipX = false;

        delta = this.gameObject.transform.position.x;
    }


    public override void Attack()
    {
        StartCoroutine(X());
    }


    IEnumerator X()
    {
        yield return null;
        for (int i = 0; i < 2; i++)
        {
            for (int j = 45; j <= 315; j += 90)
            {
                Shoot(transform.position - new Vector3(0f, 0.4f, 0f), 3f, j, 1);
                yield return new WaitForSeconds(0.05f);
            }
            yield return new WaitForSeconds(0.05f);
        }
    }


    IEnumerator Gratuitous()
    {
        while (true)
        {
            Shoot(transform.position - new Vector3(0f, 0.4f, 0f), 1f, -180, 1);
            yield return new WaitForSeconds(1.8f);
        }
    }
}

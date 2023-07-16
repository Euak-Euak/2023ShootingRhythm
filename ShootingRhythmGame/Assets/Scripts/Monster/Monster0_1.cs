using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster0_1 : Monster
{
    public void Update()
    {
        transform.Rotate(0, 0, -0.9f);
    }


    public override void Attack()
    {
        StartCoroutine(RounAnRoun());
    }


    IEnumerator RounAnRoun()
    {
        yield return null;
        for (int i = 0; i <= 390; i += 30)
        {
                              //시간? 각도 데미지
            Shoot(transform.position, 4f, i, 1);
            yield return new WaitForSeconds(0.1f);
        }
    }
}

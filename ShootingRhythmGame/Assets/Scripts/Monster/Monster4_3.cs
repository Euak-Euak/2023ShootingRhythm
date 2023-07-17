using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster4_3 : Monster
{
    private int _midAngle;
    private Vector3 _pos;


    public override void Attack()
    {
        _midAngle = Random.Range(-200, -160);
        if (_midAngle > -180) _pos = transform.position + new Vector3(-1f, 0);
        else  _pos = transform.position + new Vector3(1f, 0);
        StartCoroutine(Dantehe());
    }


    IEnumerator Dantehe()
    {
        StartCoroutine(Chimichimi(Shoot(_pos, 0f, _midAngle - 30, 1), 0, -30));
        //Shoot(_pos, 0f, _midAngle - 30, 1);
        yield return new WaitForSeconds(0.1f);

        StartCoroutine(Chimichimi(Shoot(_pos, 0f, _midAngle, 1), 1, 0));
        //Shoot(_pos, 0f, _midAngle, 1);
        yield return new WaitForSeconds(0.1f);

        StartCoroutine(Chimichimi(Shoot(_pos, 0f, _midAngle + 30, 1), 2, 30));
        //Shoot(_pos, 0f, _midAngle + 30, 1);
    }


    IEnumerator Chimichimi(Bullet shoot, int order, int del)
    {
        yield return new WaitForSeconds(1f - 0.1f * order);
        Shoot(_pos, 6.66f, _midAngle + del, 1);
        shoot.ReturnObject();
    }
}
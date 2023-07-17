using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster4_1 : Monster
{
    private Vector3 pivot;
    private List<Bullet> _stop = new List<Bullet>();
    private List<float> _angle = new List<float>();


    public override void Init(EnemyData enemy, Vector2 handle)
    {
        base.Init(enemy, handle);
        _stop.Clear();
        _angle.Clear();
    }


    public override void Attack()
    {
        pivot = this.gameObject.transform.position;
        StartCoroutine(Tick());
    }


    IEnumerator Tick()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j <= 360; j += 30)
            {
                Bullet shoot = Shoot(transform.position, 4f, j, 1);
                StartCoroutine(Tock(shoot, i, j));
            }
            yield return new WaitForSeconds(0.05f);
        }
    }


    IEnumerator Tock(Bullet shoot, int order, float angle)
    {
        yield return new WaitForSeconds(BGMManager.Bpm / 240f - order * 0.1f); // º¸±âÁÁ°Ô Á¤·ÄÇÏ±â
        if (shoot.gameObject.activeSelf)
        {
            Bullet rotate = Shoot(shoot.gameObject.transform.position, 0f, 0, 1);
            shoot.ReturnObject();
            _stop.Add(rotate);
            _angle.Add(angle);

            yield return new WaitForSeconds(BGMManager.Bpm / 240f); // ¸ØÃç!
            while (true)
            {
                rotate.transform.RotateAround(pivot, new Vector3 (0, 0, 1), -0.1f);

                yield return new WaitForSeconds(BGMManager.Bpm / 480f);
                StartCoroutine(Tack(rotate, angle));
                break;
            }
        }
    }


    IEnumerator Tack(Bullet rotate, float angle)
    {
        Bullet shoot = Shoot(rotate.gameObject.transform.position, 3f, angle, 1);
        _stop.Remove(rotate);
        _angle.Remove(angle);
        rotate.ReturnObject();

        while (true)
        {
            yield return null;
            shoot.transform.RotateAround(pivot, new Vector3(0, 0, 1), -0.1f);
        }
    }


    public override void Dead()
    {
        for (int i = 0; i < _stop.Count; i++)
        {
            Bullet onDead = Shoot(_stop[i].gameObject.transform.position, 3f, _angle[i], 1);
            _stop[i].ReturnObject();
        }
        base.Dead();
    }
}
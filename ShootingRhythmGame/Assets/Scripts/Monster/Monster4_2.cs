using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster4_2 : Monster
{
    private Animator anim;
    private int _rotate;

    private Vector3 _pos;
    private int _dir;

    private List<Bullet> _shoot = new List<Bullet>();
    private List<Vector3> _record = new List<Vector3>();


    public override void Init(EnemyData enemy, Vector2 handle)
    {
        base.Init(enemy, handle);
        _shoot.Clear();
        _record.Clear();
    }


    public void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(Rotate());
    }


    public void Update()
    {
        this.gameObject.transform.Rotate(new Vector3(0, 0, _rotate * 0.08f));
    }


    public override void Attack()
    {
        if (Random.Range(0, 1) == 0) _dir = 1;
        else _dir = 0;
        _pos = this.gameObject.transform.position + new Vector3(1f * _dir, 1f);

        StartCoroutine(TickiTack());
        StartCoroutine(Rnlcksgdk());
    }


    IEnumerator TickiTack()
    {
        for (float i = 0; i <= 0.9; i += 0.3f)
        {
            int dir = 1;
            for (int j = 0; j < 2; j++)
            {
                Bullet shoot = Shoot(_pos + new Vector3(i * dir, 0f), 1.5f, -180, 1);
                _shoot.Add(shoot);
                dir = -dir;
            }
            yield return new WaitForSeconds(0.2f);
        }
        for (float i = 0.7f; i >= 0.5f; i -= 0.15f)
        {
            int dir = 1;
            for (int j = 0; j < 2; j++)
            {
                Bullet shoot = Shoot(_pos + new Vector3(i * dir, 0f), 1.5f, -180, 1);
                _shoot.Add(shoot);
                dir = -dir;
            }
            yield return new WaitForSeconds(0.2f);
        }
    }


    IEnumerator Rnlcksgdk()
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < 11; i++)
        {
            Bullet shoot = Shoot(_pos, 1.5f, -180, 1);
            _shoot.Add(shoot);
            yield return new WaitForSeconds(0.16f);
        }

        yield return new WaitForSeconds(Random.Range(0.1f, 1.2f));
        StartCoroutine(Record());
    }


    IEnumerator Record()
    {
        anim.SetTrigger("record");

        yield return new WaitForSeconds(0.3f);
        for (int i = 0; i < _shoot.Count; i++)
        {
            _record.Add(_shoot[i].gameObject.transform.position);
        }

        yield return new WaitForSeconds(Random.Range(1f, 2.5f));
        StartCoroutine(LoadRecord());
    }


    IEnumerator LoadRecord()
    {
        anim.SetTrigger("load");

        yield return new WaitForSeconds(0.3f);
        for (int i = 0; i < _record.Count; i++)
        {
            Shoot(_record[i], 1.5f, -180, 1);
        }
    }


    IEnumerator Rotate()
    {
        while (true)
        {
            _rotate = 2;
            yield return new WaitForSeconds(Random.Range(1.6f, 2.5f));
            _rotate = 1;
            yield return new WaitForSeconds(Random.Range(0.5f, 1.1f));
            _rotate = -2;
            yield return new WaitForSeconds(Random.Range(1.6f, 2.5f));
            _rotate = -1;
            yield return new WaitForSeconds(Random.Range(1.6f, 2.5f));
        }
    }
}
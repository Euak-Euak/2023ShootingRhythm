using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private int _layer;
    private int _damage;

    SpriteRenderer _renderer;
    private CapsuleCollider2D _collider;

    bool _isAttackable = true;

    private void Awake()
    {
        _renderer = GetComponentInChildren<SpriteRenderer>();
        _collider = GetComponentInChildren<CapsuleCollider2D>();
        gameObject.SetActive(false);
    }


    public void Init(Vector3 pos, float angle, int damage, Sprite sprite = null, int layer = 0)
    {
        transform.position = pos;
        transform.rotation = Quaternion.Euler(0, 0, -angle);
        _renderer.sprite = sprite;
        _damage = damage;
        _layer = layer;
        gameObject.SetActive(true);
    }

    public void Shoot(float time = 0, float stayTime = 0)
    {
        _renderer.material.SetFloat("_Y", 0);
        StartCoroutine(ShootAnimation(time, stayTime));
    }

    private IEnumerator ShootAnimation(float time, float stayTime = 0)
    {
        float t = 0f;

        while (t < time)
        {
            t += Time.deltaTime;
            yield return null;
            _renderer.material.SetFloat("_Y", t / time);

            _collider.size = new Vector2(1, t / time);
            _collider.offset = new Vector2(0, -0.5f + (t / time) / 2);
        }

        yield return new WaitForSeconds(stayTime);

        ReturnObject();
    }

    public void ReturnObject()
    {
        _renderer.material.SetFloat("_Y", 0);
        StopAllCoroutines();
        LaserManager.Instance.ReturnObject(this);
        gameObject.SetActive(false);
    }

    public void SetBulletData(BulletData bulletData)
    {
        _collider.size = bulletData.Size;
        _renderer.sprite = bulletData.Sprite;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == _layer && _isAttackable)
        {
            collision.GetComponent<Attackable>().Attacked(_damage);
            _isAttackable = false;
            StartCoroutine(AttackDalay());
        }
    }

    private IEnumerator AttackDalay()
    {
        yield return new WaitForSeconds(0.2f);
        _isAttackable = true;
    }
}

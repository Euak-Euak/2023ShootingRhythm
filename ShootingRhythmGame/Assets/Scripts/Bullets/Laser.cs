using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private int _layer;
    private int _damage;

    SpriteRenderer _renderer;
    private CapsuleCollider2D _spriteCollider;
    private CapsuleCollider2D _collider;

    bool _isAttackable = true;

    private float _distance;
    private void Awake()
    {
        _renderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        _spriteCollider = transform.GetChild(0).GetComponent<CapsuleCollider2D>();

        _collider = GetComponent<CapsuleCollider2D>();
        gameObject.SetActive(false);

        _collider.offset = transform.GetChild(0).position;

        _distance = transform.GetChild(0).position.y;
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
            _collider.size = new Vector2(_spriteCollider.size.x, (t / time) * _spriteCollider.size.y);
            _collider.offset = new Vector2(0, (t / time) * _distance);
        }

        _collider.size = _spriteCollider.size;
        _collider.offset = Vector2.up * _distance;

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
        _collider.size = bulletData.Size.size;
        _collider.direction = bulletData.Size.direction;
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

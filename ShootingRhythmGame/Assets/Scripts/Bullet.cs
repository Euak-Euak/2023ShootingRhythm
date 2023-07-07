using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _speed = 0f;
    SpriteRenderer _renderer;
    private int _layer;
    private float _angle;
    private int _damage;
    private bool _isMove;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        gameObject.SetActive(false);
    }

    public void Init(Vector3 pos, float speed, float angle, int damage, Sprite sprite, int layer)
    {
        transform.position = pos;
        _speed = speed;
        transform.rotation = Quaternion.Euler(0, 0,  - angle);
        _angle = angle;
        _renderer.sprite = sprite;
        _damage = damage;
        _layer = layer;
        gameObject.SetActive(true);
    }

    public void Init(Vector3 pos, float speed, float angle, int damage)
    {
        transform.position = pos;
        _speed = speed;
        transform.rotation = Quaternion.Euler(0, 0, -angle);
        _angle = angle;
        _damage = damage;
        gameObject.SetActive(true);
    }

    public void ReturnObject()
    {
        BulletManager.Instance.ReturnObject(this);
        gameObject.SetActive(false);
    }

    void Update()
    {
        transform.position += new Vector3(Mathf.Sin(Mathf.Deg2Rad * _angle), Mathf.Cos(Mathf.Deg2Rad * _angle)) * _speed * Time.deltaTime;

        Vector2 pos = Camera.main.WorldToViewportPoint(transform.position);

        if (pos.x >= 1.5f || pos.x <= -0.5f ||pos.y >= 1.5f || pos.y <= -0.5f)
        {
            ReturnObject();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == _layer)
        {
            collision.GetComponent<Attackable>().Attacked(_damage);

            ReturnObject();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private int _coin;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Push()
    {
        _rigidbody.AddForce(Vector3.up * 5, ForceMode2D.Impulse);
    }

    private void Update()
    {
        if (Camera.main.WorldToViewportPoint(transform.position).y < -1)
        {
            ItemManager.Instance.ReturnObject(this);
            gameObject.SetActive(false);
        }
    }

    public void Init(int coin)
    {
        _coin = coin;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerDataManager.Instance.Money(_coin);
            ItemManager.Instance.ReturnObject(this);
            gameObject.SetActive(false);
        }
    }
}

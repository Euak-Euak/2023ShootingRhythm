using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private BulletManager _bulletManager;

    Rigidbody2D _rid;

    [SerializeField]
    private Sprite _sprite;

    private void Start()
    {
        _rid = GetComponent<Rigidbody2D>();
        StartCoroutine(BulletShoot());
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        _rid.position += 5 * Time.deltaTime * new Vector2(x, y);
    }

    private IEnumerator BulletShoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            _bulletManager.SpawnObject().Init(transform, 10f, 0, _sprite, LayerMask.NameToLayer("Monster"));
        }
    }
}

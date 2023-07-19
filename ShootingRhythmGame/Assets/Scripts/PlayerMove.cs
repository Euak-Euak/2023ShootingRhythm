using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private BulletManager _bulletManager;

    Rigidbody2D _rid;

    [SerializeField]
    private GameObject _sprite;

    private void Start()
    {
        _rid = GetComponent<Rigidbody2D>();
        StartCoroutine(BulletShoot());
    }

    void Update()
    {
        float x = 0;
        float y = 0;

        if (Input.GetKey(KeyCode.UpArrow))
            y = 1;
        if (Input.GetKey(KeyCode.DownArrow))
            y = -1;
        if (Input.GetKey(KeyCode.LeftArrow))
            x = -1;
        if (Input.GetKey(KeyCode.RightArrow))
            x = 1;

        if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            _rid.position += 2.5f * Time.deltaTime * new Vector2(x, y);
        else
            _rid.position += 5 * Time.deltaTime * new Vector2(x, y);
    }

    private IEnumerator BulletShoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            var a = _bulletManager.SpawnObject();
            a.SetBulletData(_sprite);
            a.Init(transform.position, 10f, 0, 10 + PlayerDataManager.Instance.NormalDamagePlus, LayerMask.NameToLayer("Monster"));
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempUltimate : MonoBehaviour
{
    private GameObject _bulletManagerObj;


    void Start()
    {
        _bulletManagerObj = GameObject.Find("BulletManager");
    }


    void Update()
    {
        
    }

    
    public void UltimateUse()
    {
        for (int i = 0; i < _bulletManagerObj.transform.childCount; i++)
        {
            GameObject obj = _bulletManagerObj.transform.GetChild(i).gameObject;
            //if (obj.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                Bullet _bullet = obj.GetComponent<Bullet>();
                _bullet.ReturnObject();
            }
        }
    }
}

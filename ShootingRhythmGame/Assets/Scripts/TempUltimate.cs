using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempUltimate : MonoBehaviour
{
    [SerializeField]
    private GameObject _bulletManagerObj;
    
    public void UltimateUse()
    {
        for (int i = 0; i < _bulletManagerObj.transform.childCount; i++)
        {
            GameObject obj = _bulletManagerObj.transform.GetChild(i).gameObject;
            if (obj.CompareTag("Monster"))
            {
                Bullet _bullet = obj.GetComponent<Bullet>();
                _bullet.ReturnObject();
            }
        }
    }
}

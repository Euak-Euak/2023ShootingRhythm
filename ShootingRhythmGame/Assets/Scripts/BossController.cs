using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField]
    private GameObject _boss;
    private GameObject _boss1;

    public void Spawn()
    {
        _boss1 = Instantiate(_boss);
        _boss1.transform.position = new Vector3(3, 4);
    }

    private void Update()
    {
        if (_boss1 == null)
            return;

        if (!_boss1.activeSelf)
            BossDown();
    }

    public void BossDown()
    {
        SceneLoadManager.LoadScene("RewardScene");
    }
}

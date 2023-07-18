using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _bossList;

    private GameObject _boss;

    public void Spawn()
    {
        switch (PlayerDataManager.Instance.RoundType)
        {
            case GameRoundType.Stage1Boss:
                _boss = _bossList[0];
                break;
            case GameRoundType.Stage2Boss:
                _boss = _bossList[1];
                break;
            case GameRoundType.Stage3Boss:
                _boss = _bossList[2];
                break;
            case GameRoundType.Stage4Boss:
                _boss = _bossList[3];
                break;
        }

        _boss.SetActive(true);
    }

    private void Update()
    {
        if (_boss == null)
            return;
        
        if (!_boss.activeSelf)
            BossDown();
    }

    public void BossDown()
    {
        SceneLoadManager.LoadScene("RewardScene");
    }
}

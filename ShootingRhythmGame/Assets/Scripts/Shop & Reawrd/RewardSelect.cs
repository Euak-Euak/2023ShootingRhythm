using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardSelect : MonoBehaviour
{
    [SerializeField]
    private List<CellRewardSet> cellRewards;

    [SerializeField]
    private List<int> _rewardList;

    private int _nowSelect = 0;

    [SerializeField]
    private List<Sprite> _rewardSprite;


    private void Start()
    {
        for (int i = 0; i < cellRewards.Count; i++)
        {
            int index = Random.Range(0, _rewardList.Count);
            cellRewards[i].Init(_rewardList[index], _rewardSprite[index]);
            _rewardList.RemoveAt(index);
            _rewardSprite.RemoveAt(index);
        }
    }

    public void Select(int id)
    {
        _nowSelect = id;
    }

    public void Decision()
    {
        PlayerDataManager.Instance._haveSkill.Add(_nowSelect);

        SceneLoadManager.LoadScene("SkillSelectScene");
    }
}

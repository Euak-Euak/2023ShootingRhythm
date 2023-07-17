using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellRewardSet : MonoBehaviour
{
    private int _rewardID = 0;
    [SerializeField]
    private Image _image;
    [SerializeField]
    private Text _name;

    [SerializeField]
    private RewardSelect _rewardSelect;

    public void Init(int ID, Sprite sprite)
    {
        _rewardID = ID;
        _image.sprite = sprite;
        DataManager.Instance.OpenDB();
        _name.text = DataManager.Instance.SkillName(ID);
        DataManager.Instance.CloseDB();
    }

    public void SetID()
    {
        _rewardSelect.Select(_rewardID);
    }
}

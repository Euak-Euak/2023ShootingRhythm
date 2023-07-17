using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ItemSelectCell : MonoBehaviour
{
    protected int _rewardID = 0;

    [SerializeField]
    protected Image _image;
    [SerializeField]
    protected Text _name;

    [SerializeField]
    protected RewardSelect _rewardSelect;

    public virtual void Init(int ID, Sprite sprite)
    {
        _rewardID = ID;
        _image.sprite = sprite;

        if (ID > 14)
            return;

        DataManager.Instance.OpenDB();
        _name.text = DataManager.Instance.SkillName(ID);
        DataManager.Instance.CloseDB();
    }

    public abstract void SetID();
}

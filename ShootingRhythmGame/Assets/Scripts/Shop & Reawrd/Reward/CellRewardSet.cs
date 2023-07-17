using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellRewardSet : ItemSelectCell
{
    [SerializeField]
    private ItemSelectPopup _itemSelect;

    public override void SetID()
    {
        _rewardSelect.Select(_rewardID);
        _itemSelect.SetData(_image.sprite, _name.text);
    }
}

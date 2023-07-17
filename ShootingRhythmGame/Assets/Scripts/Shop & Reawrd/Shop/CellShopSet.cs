using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellShopSet : ItemSelectCell
{
    [SerializeField]
    protected Text _price;

    [SerializeField]
    private ShopItemSelectPopup _itemSelect;

    [SerializeField]
    private Shop _shop;


    public override void Init(int ID, Sprite sprite)
    {
        base.Init(ID, sprite);
        _price.text = "200";
    }

    public override void SetID()
    {
        _shop.Select(_rewardID, 200);
        _itemSelect.SetData(_image.sprite, _name.text, 200);
    }
}

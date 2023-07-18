using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    [SerializeField]
    private Button _button;
    [SerializeField]
    private GameObject soldOut;

    [SerializeField]
    private int index;

    public override void Init(int ID, Sprite sprite)
    {
        base.Init(ID, sprite);
        _price.text = "200";
    }

    public void SlodOut()
    {
        soldOut.SetActive(true);
        _button.interactable = false;
    }

    public override void SetID()
    {
        _shop.Select(_rewardID, 200, index);
        _itemSelect.SetData(_image.sprite, _name.text, 200);
    }
}

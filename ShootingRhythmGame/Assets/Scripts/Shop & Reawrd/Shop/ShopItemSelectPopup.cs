using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemSelectPopup : ItemSelectPopup
{
    [SerializeField]
    private Text _price;

    public void SetData(Sprite image, string text, int price)
    {
        base.SetData(image, text);
        _price.text = price.ToString();
    }
}

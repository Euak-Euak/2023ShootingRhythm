using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSelectPopup : MonoBehaviour
{
    [SerializeField]
    private Image _itemImage;
    [SerializeField]
    private Text _itemText;

    public void SetData(Sprite image, string text)
    {
        _itemImage.sprite = image;
        _itemText.text = text;
    }
}

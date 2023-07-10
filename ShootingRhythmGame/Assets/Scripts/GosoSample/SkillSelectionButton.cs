using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSelectionButton : tempSkillSelect
{
    private Image _image;
    private Color _originalColor = Color.white;
    private Color _selectedColor = Color.yellow;
    private bool _isSelected = false;

    private //뭐적으려한거지.....ㅅㅂ

    void Start()
    {
        _image = this.GetComponent<Image>();
    }

    void Update()
    {

        if (_isSelected)
        {
            _image.color = _selectedColor;
        }
        else
        {
            _image.color = _originalColor;
        }
    }

    public void OnClick()
    {
        if (!_isSelected)
        {
            if (!IsSelectionMax)
            {
                SelectedSkillCnt++;
            }
        }
        else
        {
            SelectedSkillCnt--;
        }
        _isSelected = !_isSelected;
    }
}

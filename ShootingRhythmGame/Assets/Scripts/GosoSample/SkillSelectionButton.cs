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

    public int _idNum;
    private Text _skillNameText;


    void Start()
    {
        _skillNameText = this.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        _image = this.GetComponent<Image>();

        _skillManager = this.gameObject.AddComponent<SkillManager>();
        _skillManager.Init();
    }

    void Update()
    {
        _skillNameText.text = _skillManager.SkillSet[_idNum]._skillName;

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
                SelectedSkillIdList.Add(_idNum);
                _isSelected = true;
            }
        }
        else
        {
            SelectedSkillIdList.Remove(_idNum);
            _isSelected = false;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class SkillContent : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Text _level;
    [SerializeField] private Text _name;
    [SerializeField] private Text _command;
    [SerializeField] private Image _powerUp;

    public int ID;
    private bool _isPowerUp;

    public void Init(int id, Action<int> action)
    {
        ID = id;
        _button.onClick.AddListener(() => { action.Invoke(ID); });
        if (DataManager.Instance.SkillLevel(ID) == 0)
            NotOpenedSkill();
        else
        {
            _level.text = DataManager.Instance.SkillLevel(ID).ToString();
            _name.text = DataManager.Instance.SkillName(ID);
            PowerUpChange();
        }
    }

    public void PowerUpChange()
    {
        _isPowerUp = DataManager.Instance.IsPowerUp(ID);
        if (_isPowerUp)
        {
            _command.text = DataManager.Instance.CommandPowerUp(ID);
            _powerUp.color = new Color(0.9f,0.8f,0.1f);
        }
        else
        {
            _command.text = DataManager.Instance.CommandNormal(ID);
            _powerUp.color = new Color(0.4f, 0.4f, 0.4f);
        }
    }

    private void NotOpenedSkill()
    {
        _level.text = string.Empty;
        _name.text = "???";
        _command.text = "???";
        _powerUp.color = new Color(0.4f, 0.4f, 0.4f);
    }

    public void SkillLevelChange()
    {
        _level.text = DataManager.Instance.SkillLevel(ID).ToString();
    }
}

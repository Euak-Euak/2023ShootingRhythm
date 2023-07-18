using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SkillContent : MonoBehaviour
{
    [SerializeField] public Button _button;
    //[SerializeField] private Text _level;
    [SerializeField] private Text _name;
    [SerializeField] private Text _command;
    [SerializeField] private Image _powerUp;
    [SerializeField] private Transform _trans;

    public int ID;
    public CanvasGroup canvasGroop;
    private bool _isPowerUp;
    private Transform ItemPos;
    private Image _skillImage;

    public void Init(int id, Action<int> action, Action<int> action2, Transform transform)
    {
        _skillImage = _button.GetComponent<Image>();
        ID = id;
        ItemPos = transform;
        _button.onClick.AddListener(() => { action.Invoke(ID); });
        _button.onClick.AddListener(() => { action2.Invoke(ID); });
        _button.onClick.AddListener(ExpandIcon);
        if (DataManager.Instance.SkillLevel(ID) == 0)
            NotOpenedSkill();
        else
        {
            //_level.text = DataManager.Instance.SkillLevel(ID).ToString();
            _name.text = DataManager.Instance.SkillName(ID);
            _skillImage.sprite = DataManager.Instance.SpriteByID(ID);
            PowerUpChange();
        }
    }

    public void ExpandIcon()
    {
        _trans.DOMove(ItemPos.position, 1f).SetEase(Ease.OutBack);
        _trans.DOScale(new Vector3(2,2), 0.5f).SetEase(Ease.OutSine);
    }

    public void ShrinkIcon()
    {
        _trans.DOLocalMove(new Vector3(0, 0), 0.7f).SetEase(Ease.InBack);
        _trans.DOScale(new Vector3(1, 1), 0.5f).SetEase(Ease.InSine);
    }

    public void PowerUpChange()
    {
        _isPowerUp = DataManager.Instance.IsPowerUp(ID);
        if (_isPowerUp)
        {
            _command.text = DataManager.Instance.CommandPowerUp(ID);
            _powerUp.sprite = Resources.Load<Sprite>("Sprites/Skills/Skill_BG_After");
        }
        else
        {
            _command.text = DataManager.Instance.CommandNormal(ID);
            _powerUp.sprite = Resources.Load<Sprite>("Sprites/Skills/Skill_BG_Before");
        }
    }

    private void NotOpenedSkill()
    {
        //_level.text = string.Empty;
        _name.text = "???";
        _command.text = "???";
        _powerUp.sprite = Resources.Load<Sprite>("Sprites/Skills/Skill_BG_Before");
        _skillImage.sprite = Resources.Load<Sprite>("Sprites/Skills/Skill0");
    }

    //public void SkillLevelChange()
    //{
    //    _level.text = DataManager.Instance.SkillLevel(ID).ToString();
    //}
}

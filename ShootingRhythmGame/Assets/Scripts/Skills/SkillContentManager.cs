using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillContentManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private SkilInfo _skillInfo;
    [SerializeField] private Transform ItemPos;
    [SerializeField] private Transform _descriptPos;
    [SerializeField] private Transform _descript;
    [SerializeField] private ScrollRect _scrollRect;
    [SerializeField] private Transform _descriptOriginalPos;

    private Dictionary<int, SkillContent> _skillInfoByID = new Dictionary<int, SkillContent>();
    
    private int _currentSelectID = 0;

    void Start()
    {
        _descriptOriginalPos.position = _descript.position;
        DataManager.Instance.OpenDB();
        for (int i = 1; i <= DataManager.Instance.SkillCount(); i++)
        {
            SkillContent skill = Instantiate(_gameObject).GetComponent<SkillContent>();
            skill.transform.SetParent(transform, false);
            skill.Init(i, _skillInfo.UpdateInfo, BlockScroll, ItemPos);
            _skillInfoByID.Add(i, skill);
        }
        DataManager.Instance.CloseDB();

        _skillInfo.GetSkillInfoDictionary(_skillInfoByID);
        _skillInfo.SetGoBackButton(AcceptScroll);
    }

    public void BlockScroll(int ID)
    {
        _currentSelectID = ID;
        _scrollRect.vertical = false;
        _descript.DOMove(_descript.position, 0.9f).OnComplete(() =>
            _descript.DOMove(_descriptPos.position, 0.7f).SetEase(Ease.OutCirc));

        for (int i = 1; i < _skillInfoByID.Count + 1; i++)
        {
            ChangeSkillInfoByID(i, false);
            if (!(i == ID))
            {
                StartCoroutine(SkillFade(i));
            }
            else
            {
                StartCoroutine(AllowButton(i, 0.7f, false));
            }
        }
    }

    private void ChangeSkillInfoByID(int ID, bool TF)
    {
        _skillInfoByID[ID].canvasGroop.interactable = TF;
        _skillInfoByID[ID].canvasGroop.blocksRaycasts = TF;
        _skillInfoByID[ID]._button.interactable = TF;
    }

    IEnumerator AllowButton(int ID, float time, bool b)
    {
        float t = 0;
        while (t <= time)
        {
            t += Time.deltaTime;
            yield return null;
        }

        ChangeSkillInfoByID(ID, b);
        yield return null;
    }

    IEnumerator SkillFade(int ID)
    {
        while (_skillInfoByID[ID].canvasGroop.alpha > 0)
        {
            _skillInfoByID[ID].canvasGroop.alpha -= Time.deltaTime * 2.5f;
            yield return null;
        }
    }

    public void AcceptScroll()
    {
        ChangeSkillInfoByID(_currentSelectID, false);
        _skillInfo.GoBackButton.interactable = false;
        StartCoroutine(AllowButton(_currentSelectID, 1.6f, true));

        _descript.DOMove(_descriptOriginalPos.position, 0.7f).SetEase(Ease.InCirc)
            .OnComplete(() => {
                for (int i = 1; i < _skillInfoByID.Count + 1; i++)
                {
                    if (!(i == _currentSelectID))
                    {
                        StartCoroutine(SkillAppear(i));
                    }
                    else
                    {
                        _skillInfoByID[i].ShrinkIcon();
                        
                        _currentSelectID = 0;
                    }
                }
                _scrollRect.vertical = true;
            });
    }

    IEnumerator SkillAppear(int ID)
    {
        float t = 0;
        while (t <= 0.5f)
        {
            t += Time.deltaTime;
            yield return null;
        }

        while (_skillInfoByID[ID].canvasGroop.alpha < 1)
        {
            _skillInfoByID[ID].canvasGroop.alpha += Time.deltaTime * 2.5f;
            yield return null;
        }

        ChangeSkillInfoByID(ID, true);
        _skillInfo.GoBackButton.interactable = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField]
    private List<string> _enterScript;
    [SerializeField]
    private List<string> _buyScript;
    [SerializeField]
    private List<string> _buyCancleScript;
    [SerializeField]
    private List<string> _sellinClickScript;
    [SerializeField]
    private List<string> _buyRefusal;
    [SerializeField]
    private Text _script;

    Animator _animator;

    [SerializeField]
    private List<CellShopSet> cellRewards;
    
    [SerializeField]
    private List<int> _rewardList;

    private int _nowSelect = 0;
    private int _price = 0;

    [SerializeField]
    private List<Sprite> _rewardSprite;

    int index;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _script.text = _enterScript[Random.Range(0, _enterScript.Count)];

        for (int i = 0; i < cellRewards.Count; i++)
        {
            int index = Random.Range(0, _rewardList.Count);
            cellRewards[i].Init(_rewardList[index], _rewardSprite[index]);
            _rewardList.RemoveAt(index);
            _rewardSprite.RemoveAt(index);
        }
    }

    public void Select(int id, int price, int index)
    {
        _nowSelect = id;
        _price = price;
        this.index = index;
    }

    public void Decision()
    {
        if (PlayerDataManager.Instance._money < _price)
        {
            BuyRefusal();
            return;
        }
        PlayerDataManager.Instance._money -= _price;
        BuyItem();

        cellRewards[index].SlodOut();

        switch (_nowSelect)
        {
            case 15:
                PlayerDataManager.Instance.NormalDamagePlus += 5;
                break;
            case 16:
                PlayerDataManager.Instance.SkillDamagePlus += 5;
                break;
            case 17:
                PlayerDataManager.Instance.UltimateMinus--;
                break;
            case 18:
                PlayerDataManager.Instance.InvincibilityTime += 0.5f;
                break;
            case 19:
                PlayerDataManager.Instance.MoneyPlus += 10;
                break;
            case 20:
                PlayerDataManager.Instance.PlayerHP++;
                break;

            default:
                PlayerDataManager.Instance._haveSkill.Add(_nowSelect);
                break;
        }
    }

    public virtual void NextScene()
    {
        PlayerDataManager.Instance.Next();
        SceneLoadManager.LoadScene("SkillSelectScene");
    }


    public void BuyItem()
    {
        _animator.SetTrigger("Speech");
        _script.text = _buyScript[Random.Range(0, _buyScript.Count)];
    }

    public void BuyCancle()
    {
        _animator.SetTrigger("Speech");
        _script.text = _buyCancleScript[Random.Range(0, _buyCancleScript.Count)];
    }

    public void BuyRefusal()
    {
        _animator.SetTrigger("Speech");
        _script.text = _buyRefusal[Random.Range(0, _buyRefusal.Count)];
    }

    public void SellinClick()
    {
        _animator.SetTrigger("Speech");
        _script.text = _sellinClickScript[Random.Range(0, _sellinClickScript.Count)];
    }

    public void ExitShop()
    {
        _animator.SetTrigger("Exit");
        _script.text = "다음에도 만나죠. 그럼 이만...";

        StartCoroutine(Animation());
    }

    IEnumerator Animation()
    {
        yield return new WaitForSeconds(5f);
        SceneLoadManager.LoadScene("SkillSelectScene");
    }
}

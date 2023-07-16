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
    private Text _script;

    Animator _animator;


    private void Start()
    {
        _animator = GetComponent<Animator>();
        _script.text = _enterScript[Random.Range(0, _enterScript.Count)];
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

    public void SellinClick()
    {
        _animator.SetTrigger("Speech");
        _script.text = _sellinClickScript[Random.Range(0, _sellinClickScript.Count)];
    }

    public void ExitShop()
    {
        _animator.SetTrigger("Exit");
        _script.text = "다음에도 만나죠. 그럼 이만...";
    }
}

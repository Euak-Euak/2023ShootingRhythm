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

    [SerializeField]
    private List<Button> _buttons;


    private void Start()
    {
        _animator = GetComponent<Animator>();
        _script.text = _enterScript[Random.Range(0, _enterScript.Count)];

        for (int i = 0; i < _buttons.Count; i++)
        {
        }
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
        _script.text = "�������� ������. �׷� �̸�...";

        StartCoroutine(Animation());
    }

    IEnumerator Animation()
    {
        yield return new WaitForSeconds(5f);
        SceneLoadManager.LoadScene("SkillSelectScene");
    }
}
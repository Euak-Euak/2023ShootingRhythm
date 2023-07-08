using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteController : MonoBehaviour
{
    [SerializeField] private float _speed;

    private enum judges { None, Near, Just, Pass, Miss };
    private judges _judge;

    private int _noteCnt;
    private bool _isUsed;
    private bool _canUsed;
    private bool _alreadyPass;

    private string _inputKeyCode;
    private List<KeyCode> _nowKeyList;

    private Image _img;

    private BGMManager _BGMManager;
    private ComboManager _comboManager;


    public void Init(Transform pos)
    {
        _noteCnt = NoteSpawner.NoteCnt;
        if (_noteCnt == 0) _canUsed = true;
        else _canUsed = false;
        _alreadyPass = false;

        _img = this.GetComponent<Image>();
        _img.color = Color.white;
        transform.position = pos.position;

        _judge = judges.None;
        gameObject.SetActive(true);
    }

    void Start()
    {
        _speed = NoteSpawner.NoteSpeed;
        _comboManager = GameObject.Find("CommandPanel").GetComponent<ComboManager>();
        _BGMManager = GameObject.Find("Main Camera").GetComponent<BGMManager>();
    }


    void Update()
    {
        _isUsed = NoteSpawner.IsUsed[_noteCnt];

        transform.Translate(new Vector2(_speed * Time.deltaTime, 0f));

        _nowKeyList = ComboManager.NowKeyList;
        _inputKeyCode = Input.inputString.ToUpper();

        for (int i = 0; i < _nowKeyList.Count; i++)
        {
            if (_inputKeyCode == _nowKeyList[i].ToString())
            {
                if (_canUsed && !_isUsed)
                {
                    ProcessJudge(_judge, i);
                }
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Perf")
        {
            _BGMManager.GetComponent<BGMManager>().MusicStart();
            Destroy(other.gameObject);
        }
        else if (other.name == "Miss")
        {
            for (int i = 0; i < _nowKeyList.Count; i++)
            {
                if (_nowKeyList[i] == KeyCode.None && !_isUsed)
                {
                    _judge = judges.Pass;
                    ProcessJudge(_judge, i);
                }
                else if (!_isUsed)//( && !_nowKeyList.Contains(KeyCode.None))
                {
                    _judge = judges.Miss;
                    EndJudgement(false, i);
                }
            }
        }
        else if (other.name == "Dismiss")
        {
            ReturnObject();
        }
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (_noteCnt != 0) _canUsed = NoteSpawner.IsUsed[_noteCnt - 1];

        if (other.name == "Just" || other.name == "Perf")
        {
            _judge = judges.Just;
        }
        else if (other.name == "Near")
        {
            _judge = judges.Near;
        }
        
    }


    //private judges ProcessJudge(judges judge, int skillNum)
    private void ProcessJudge(judges judge, int skillNum)
    {
        if (_nowKeyList[skillNum] != KeyCode.None)
        {
            if (judge == judges.Just || judge == judges.Near)
            {
                EndJudgement(true, skillNum);
            }
        }
        else if (judge == judges.Pass)
        {
            EndJudgement(true, skillNum);
        }
    }


    private void EndJudgement(bool someoneSucceeded, int skillNum)
    {
        if (someoneSucceeded)
        {
            _img.color = Color.yellow;
            _alreadyPass = true;
            ComboManager.ComboList[skillNum]++;

            for (int ImBbackchu = 0; ImBbackchu < _nowKeyList.Count; ImBbackchu++)
            {
                if (_nowKeyList[skillNum] != _nowKeyList[ImBbackchu])
                    _comboManager.ComboFailed(ImBbackchu);
            }
        }
        else
        {
            if (!_alreadyPass) { _img.color = Color.black; }
            ComboManager.ComboList[skillNum] = 0;
        }

        NoteSpawner.IsUsed[_noteCnt] = true;
    }


    public void ReturnObject()
    {
        NoteManager.Instance.ReturnObject(this);
        gameObject.SetActive(false);
    }
}

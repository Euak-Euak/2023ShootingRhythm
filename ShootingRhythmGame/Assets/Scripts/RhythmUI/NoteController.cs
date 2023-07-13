using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteController : MonoBehaviour
{
    private float _speed;

    private enum judges { None, Near, Just, Pass, Miss };
    private judges _judge;

    private int _noteCnt;
    private bool _isUsed;
    private bool _canUsed;
    private bool _alreadyPass;

    private string _inputKeyCode;
    private List<string> _nowKeyList;
    private List<string> _allKeyList = new List<string> { "A", "S", "D", "F" };

    private Image _img;

    private BGMManager _BGMManager;
    private CommandManager _commandManager;
    private AudioSource _perfBeat;


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
        _perfBeat = GetComponent<AudioSource>();

        if (GameObject.Find("Player") != null)_commandManager = GameObject.Find("Player").GetComponent<CommandManager>();
        _BGMManager = GameObject.Find("Main Camera").GetComponent<BGMManager>();
    }


    void Update()
    {
        transform.Translate(new Vector2(_speed * Time.deltaTime, 0f));

        _isUsed = NoteSpawner.IsUsed[_noteCnt];

        _nowKeyList = CommandManager.NowKeyList;
        _inputKeyCode = Input.inputString.ToUpper();
        if (_canUsed && !_isUsed)
        {
            if (Input.anyKeyDown && !PauseOnStage.IsPause)
            {
                for (int i = 0; i < _nowKeyList.Count; i++)
                {   
                    if (_inputKeyCode == _nowKeyList[i])
                    {
                        ProcessJudge(_judge, i);
                    }
                    else if (_allKeyList.Contains(_inputKeyCode) && !_nowKeyList.Contains(_inputKeyCode))
                    {
                        EndJudgement(false, i);
                    }
                }
            }
        }

        if (_noteCnt != 0) _canUsed = NoteSpawner.IsUsed[_noteCnt - 1];
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Perf")
        {
            if (!BGMManager._isMusicStart)
            {
                _BGMManager.GetComponent<BGMManager>().MusicStart();
            }
            _perfBeat.Play();
            //Destroy(other.gameObject);
        }
        else if (other.name == "Miss")
        {
            for (int i = 0; i < _nowKeyList.Count; i++)
            {
                if (_nowKeyList[i] == "-" && !_isUsed)
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
        
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == "Just" || other.name == "Perf")
        {
            _judge = judges.Just;
        }
        else if (other.name == "Near")
        {
            _judge = judges.Near;
        }
        else if (other.name != "Miss" && other.name == "Dismiss")
        {
            ReturnObject();
        }
    }


    private void ProcessJudge(judges judge, int skillNum)
    {
        if (_nowKeyList[skillNum] != "-")
        {
            if (judge == judges.Just || judge == judges.Near)
            {
                EndJudgement(true, skillNum);
            }
            else if (judge == judges.None)
            {
                EndJudgement(false, skillNum);
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
            if (!CommandManager.IsCmdCoolTime[skillNum])
            {
                _img.color = Color.yellow;
                _alreadyPass = true;
                CommandManager.ComboList[skillNum]++;
            }

            for (int ImBbackchu = 0; ImBbackchu < _nowKeyList.Count; ImBbackchu++)
            {
                if (CommandManager.ComboList[ImBbackchu] > 0 && _nowKeyList[skillNum] != _nowKeyList[ImBbackchu])
                {
                    _commandManager.ComboFailed(ImBbackchu);
                }
            }
        }
        else
        {
            if (!_alreadyPass) { _img.color = Color.black; }
            CommandManager.ComboList[skillNum] = 0;
        }

        NoteSpawner.IsUsed[_noteCnt] = true;
    }


    public void ReturnObject()
    {
        NoteSpawner.IsUsed[_noteCnt] = true;
        NoteManager.Instance.ReturnObject(this);
        gameObject.SetActive(false);
    }
}
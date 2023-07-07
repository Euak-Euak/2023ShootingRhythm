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

    private string _inputKeyCode;
    private List<KeyCode> _nowKeyList;

    private Image _img;

    private BGMManager _BGMManager;


    public void Init(Transform pos)
    {
        _noteCnt = NoteSpawner.NoteCnt;
        if (_noteCnt == 0) _canUsed = true;
        else _canUsed = false;

        _img = this.GetComponent<Image>();
        _img.color = Color.white;
        transform.position = pos.position;

        _judge = judges.None;
        gameObject.SetActive(true);
    }

    void Start()
    {
        _speed = NoteSpawner.NoteSpeed;
        _BGMManager = GameObject.Find("Main Camera").GetComponent<BGMManager>();
    }


    void Update()
    {
        _isUsed = NoteSpawner.IsUsed[_noteCnt];

        transform.Translate(new Vector2(_speed * Time.deltaTime, 0f));

        _nowKeyList = ComboManager.NowKeyList;

        if (Input.inputString == "") { _inputKeyCode = "None"; }
        else _inputKeyCode = Input.inputString.ToUpper();

        for (int i = 0; i < _nowKeyList.Count; i++)
        {
            if (_inputKeyCode == _nowKeyList[i].ToString())
            {
                Debug.Log("??" + _nowKeyList[i]);
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
            if (!BGMManager._isMusicStart)
            {
                _BGMManager.GetComponent<BGMManager>().MusicStart();
                BGMManager._isMusicStart = true;
            }
                
            //Destroy(other.gameObject);
        }
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (_noteCnt != 0) _canUsed = NoteSpawner.IsUsed[_noteCnt - 1]; //이거왜여깄지

        if (other.name == "Just")
        {
            _judge = judges.Just;
        }
        else if (other.name == "Near" || other.name == "Perf")
        {
            _judge = judges.Near;
        }
        else if (other.name == "Miss")
        {
            /*if (_inputKeyCode != "None")
            {
                _judge = judges.Miss;
                NoteSpawner.IsUsed[_noteCnt] = true;
            }
            else
            {
                _judge = judges.Pass;
            }*/
        }
        else if (other.name == "Dismiss")
        {
            ReturnObject();
        }
    }


    private judges ProcessJudge(judges judge, int skillNum)
    {
        if (judge == judges.None) { return judges.None; }
        if (judge == judges.Just)
        {
            Debug.Log("Just");
        }
        else if (judge == judges.Near)
        {
            Debug.Log("Near");
        }
        if (judge == judges.Pass)
        {
            Debug.Log("Pass");
        }
        EndJudgement(skillNum);
        return judge;
    }


    public void ReturnObject()
    {
        NoteManager.Instance.ReturnObject(this);
        gameObject.SetActive(false);
    }


    private void EndJudgement(int skillNum)
    {
        _img.color = Color.black;

        NoteSpawner.IsUsed[_noteCnt] = true;
        ComboManager.ComboList[skillNum]++;
    }
}

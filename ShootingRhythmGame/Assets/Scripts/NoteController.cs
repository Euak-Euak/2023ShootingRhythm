using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteController : MonoBehaviour
{
    private float _speed;

    private enum judges { None, Near, Just };
    private judges _judge;

    private int _noteCnt;
    private bool _isUsed;
    private bool _canUsed;

    private string _inputKeyCode;
    private List<KeyCode> _nowKeyList;
    //private int _comboCnt;

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
        gameObject.SetActive(true);
    }

    void Start()
    {
        //_keyCode = ComboManager._keyCode; //
        //_comboCnt = ComboManager.ComboCnt;
        _speed = NoteSpawner.NoteSpeed;
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
            Debug.Log(_nowKeyList[i]);
            if (_inputKeyCode == _nowKeyList[i].ToString())
            {
                if (_canUsed && !_isUsed)
                {
                    ProcessJudge(_judge);
                    //Destroy(this);
                }
            }
        }

        /*if (_isUsed) _img.color = Color.black;
        else _img.color = Color.white;*/
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
        if (_noteCnt != 0) _canUsed = NoteSpawner.IsUsed[_noteCnt - 1];
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
            _judge = judges.None;
            NoteSpawner.IsUsed[_noteCnt] = true;
        }
        else if (other.name == "Dismiss")
        {
            ReturnObject();
        }
    }


    private judges ProcessJudge(judges judge)
    {
        if (judge == judges.None) { return judges.None; }
        else
        {
            if (judge == judges.Just)
            {
                Debug.Log("Just");
            }
            else if (judge == judges.Near)
            {
                Debug.Log("Near");
            }
            _img.color = Color.black;

            NoteSpawner.IsUsed[_noteCnt] = true;
            ComboManager.ComboCnt++;
        }
        return judge;
    }


    public void ReturnObject()
    {
        NoteManager.Instance.ReturnObject(this);
        gameObject.SetActive(false);
    }


    /*public void SyncControll(float delta)
    {
    }*/
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{

    private enum judges { None, Near, Just };
    private judges _judge;

    private int _noteCnt;
    private bool _isUsed;
    private bool _canUsed;
    private KeyCode _keyCode;
    //private int _comboCnt;

    [SerializeField]
    private float _speed;

    private BGMManager _BGMManager;


    public void Init(Transform pos)
    {
        transform.position = pos.position;
        gameObject.SetActive(true);
    }


    void Start()
    {
        _keyCode = ComboManager._keyCode;
        //_comboCnt = ComboManager.ComboCnt;

        _noteCnt = NoteSpawner.NoteCnt - 1;
        _isUsed = NoteSpawner.IsUsed[_noteCnt];
        if (_noteCnt == 0) _canUsed = true;
        else _canUsed = false;

        Debug.Log(_canUsed + " " + _isUsed);

        _BGMManager = GameObject.Find("Main Camera").GetComponent<BGMManager>();
    }


    void Update()
    {
        if (!_canUsed) _canUsed = NoteSpawner.IsUsed[_noteCnt-1];
        transform.Translate(new Vector2(_speed * Time.deltaTime, 0f));

        if (_canUsed && !_isUsed)
        {
            if (Input.GetKeyDown(_keyCode))
            {
                ProcessJudge(_judge);
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
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == "Just")
        {
            _judge = judges.Just;
        }
        else if (other.name == "Near")
        {
            _judge = judges.Near;
        }
        else if (other.name == "Miss")
        {
            //_isUsed = false;
            _judge = judges.None;
            ReturnObject();
        }

    }


    private judges ProcessJudge(judges judge)
    {
        Debug.Log(_canUsed + "" + _isUsed);
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
            //_comboCnt++;
            _isUsed = true;
        }
        ///////
        ReturnObject();
        return judge;
    }


    public void ReturnObject()
    {
        NoteManager.Instance.ReturnObject(this);
        gameObject.SetActive(false);
    }
}

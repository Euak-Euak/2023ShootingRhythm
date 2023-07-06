using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; ///

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
    private Image _img;

    private BGMManager _BGMManager;


    public void Init(Transform pos)
    {
        _noteCnt = NoteSpawner.NoteCnt - 1;
        if (_noteCnt == 0) _canUsed = true;
        else _canUsed = false;

        transform.position = pos.position;
        gameObject.SetActive(true);
    }


    void Start()
    {
        _img = this.GetComponent<Image>(); 

        _keyCode = ComboManager._keyCode; //
        //_comboCnt = ComboManager.ComboCnt;

        _BGMManager = GameObject.Find("Main Camera").GetComponent<BGMManager>();
    }


    void Update()
    {
        _isUsed = NoteSpawner.IsUsed[_noteCnt];
        if (!_canUsed) _canUsed = NoteSpawner.IsUsed[_noteCnt-1];
        Debug.Log(_noteCnt + " " + _canUsed);

        if (_isUsed)
        {
            _img.color = Color.black;
        }
        else _img.color = Color.white;

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
            _judge = judges.None;
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
            //_comboCnt++;
            NoteSpawner.IsUsed[_noteCnt] = true;
        }
        return judge;
    }


    public void ReturnObject()
    {
        NoteSpawner.IsUsed[_noteCnt] = true;
        NoteManager.Instance.ReturnObject(this);
        gameObject.SetActive(false);
    }
}

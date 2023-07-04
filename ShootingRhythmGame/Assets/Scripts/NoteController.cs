using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{

    private enum judges { None, Near, Just };
    private judges _judge;
    private bool _isused = false;
    private KeyCode _keyCode;

    [SerializeField]
    private float _speed;

    private BGMManager _BGMManager;


    void Start()
    {
        _keyCode = ComboManager._keyCode;
        //_BGMManager = GameObject.Find("Main Camera").GetComponent<BGMManager>();
    }


    void Update()
    {
        transform.Translate(new Vector2(0.01f * _speed, 0f));

        if (!_isused)
        {
            if (Input.GetKeyDown(_keyCode))
            {
                Debug.Log("�ٳ����Ƕ���");
                ProcessJudge(_judge);
            }
            else if (Input.anyKeyDown)
            {
                Debug.Log("���߻�Ű");
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Perf")
        {
            //_BGMManager.GetComponent<BGMManager>().MusicStart();
            Destroy(other.gameObject);
        }
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == "Just") _judge = judges.Just;
        else if (other.name == "Near") _judge = judges.Near;
        else if (other.name == "Miss")  Destroy(gameObject);
    }


    private void ProcessJudge(judges judge)
    {
        if (judge == judges.None) return;
        else
        {
            if (judge == judges.Just)
            {
                Debug.Log("���ϴ�");
            }
            else if (judge == judges.Near)
            {
                Debug.Log("�̹��ϴ�");
            }
            _isused = true;
        }
    }
}

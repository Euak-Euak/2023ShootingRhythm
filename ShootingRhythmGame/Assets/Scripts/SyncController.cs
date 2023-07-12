using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncController : MonoBehaviour
{
    [SerializeField] private GameObject[] _judgementZones;
    private List<BoxCollider2D> _colliders = new List<BoxCollider2D>();
    // ���� -0.3 ~ 0.3
    [Range(-30, 30)] public float Sync;


    void Start()
    {
        for (int i = 0; i < _judgementZones.Length; i++)
        {
            _colliders.Add(_judgementZones[i].GetComponent<BoxCollider2D>());
        }
    }


    void Update()
    {
        for (int i = 0; i < _judgementZones.Length; i++)
        {
            //���澾��
            _colliders[i].offset = new Vector2(Sync * NoteSpawner.NoteSpeed , 0);
        }
    }
}

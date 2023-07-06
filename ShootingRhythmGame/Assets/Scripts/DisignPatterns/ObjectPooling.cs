using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling<T> : Singleton<ObjectPooling<T>>
{
    [SerializeField]
    private GameObject _object;

    [SerializeField]
    protected Transform _parent;

    protected Queue<T> _poolingObjects;

    private void Start()
    {
        if (_parent == null)
            _parent = this.transform;

        _poolingObjects = new Queue<T>();

        for (int i = 0; i < transform.childCount; i++)
        {
            T p = transform.GetChild(i).GetComponent<T>();

            if (p == null)
                continue;

            _poolingObjects.Enqueue(p);
        }
    }

    public virtual T SpawnObject()
    {
        if (_poolingObjects.Count == 0)
        {
            T o = Instantiate(_object, _parent).GetComponent<T>();
            return o;
        }

        T p = _poolingObjects.Dequeue();
        return p;
    }

    public void ReturnObject(T p)
    {
        _poolingObjects.Enqueue(p);
    }
}
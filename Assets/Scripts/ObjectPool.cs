using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _template;

    private Queue<T> _pool = new Queue<T>();

    public event Action InstancePuted;

    public T Get()
    {
        if (_pool.Count == 0)
        {
            T newInstance = Instantiate(_template);
            newInstance.transform.parent = transform;
            return newInstance;
        }

        T instance = _pool.Dequeue();
        instance.gameObject.SetActive(true);

        return instance;
    }

    public void Put(T instance)
    {
        instance.gameObject.SetActive(false);
        _pool.Enqueue(instance);
        InstancePuted?.Invoke();
    }
}
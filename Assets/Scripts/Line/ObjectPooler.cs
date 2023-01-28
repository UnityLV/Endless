using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler<T> where T : MonoBehaviour
{
    private T _prefab;
    private Func<T, IPooleable> _instantiate;
    private readonly Stack<IPooleable> _pool = new();

    public ObjectPooler(Func<T, IPooleable> instantiate, T template)
    {
        _instantiate = instantiate;
        _prefab = template;
    }

    public T Get()
    {
        if (_pool.TryPop(out IPooleable pooleable))
        {
            pooleable.Deactivation += OnDeactivation;
            return pooleable as T;
        }

        IPooleable poolable = _instantiate(_prefab);
        poolable.Deactivation += OnDeactivation;

        return poolable as T;
    }  

    private void OnDeactivation(IPooleable pooleable)
    {
        pooleable.Deactivation -= OnDeactivation;

        _pool.Push(pooleable);
    }

}

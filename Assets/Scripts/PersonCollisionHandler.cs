using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Collider2D))]

public class PersonCollisionHandler : MonoBehaviour
{
    private List<Collider2D> _exceptions = new List<Collider2D>();

    public Action<IInteractable> CollisionDetected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsException(collision))
            return;

        if(collision.TryGetComponent(out IInteractable hit))
            CollisionDetected?.Invoke(hit);
    }

    public void AddException(Collider2D collider)
    {
        if(IsException(collider) == false)
            _exceptions.Add(collider);
    }

    private bool IsException(Collider2D collision)
    {
        foreach (Collider2D exception in _exceptions)
            if (exception == collision)
                return true;

        return false;
    }
}
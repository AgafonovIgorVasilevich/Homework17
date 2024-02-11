using UnityEngine;
using System;

public class BulletCollisionHandler : MonoBehaviour
{
    private Collider2D _ignoredCollider;

    public Action CollisionDetected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_ignoredCollider != collision)
            CollisionDetected?.Invoke();
    }

    public void SetIgnore(Collider2D collider) => _ignoredCollider = collider;
}
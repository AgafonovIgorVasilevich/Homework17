using UnityEngine;
using System;

[RequireComponent(typeof(Collider2D))]

public class PersonCollisionHandler : MonoBehaviour
{
    [SerializeField] private Person _owner;

    public event Action<Obstacle> ObstacleHit;
    public event Action BulletHit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable hit))
            TakeCollision(hit);
    }

    private void TakeCollision(IInteractable interactable)
    {
        if (interactable is Bullet bullet && bullet.OwnerType != _owner.Type)
        {
            bullet.BackToPool();
            BulletHit?.Invoke();
        }
        else if (interactable is Obstacle obstacle)
        {
            ObstacleHit?.Invoke(obstacle);
        }
    }
}
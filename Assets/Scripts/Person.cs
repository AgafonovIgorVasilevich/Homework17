using UnityEngine;

[RequireComponent(typeof(PersonCollisionHandler))]

public abstract class Person : MonoBehaviour
{
    protected PersonCollisionHandler _collisionHandler;

    public abstract PersonType Type { get; }

    private void Awake() => _collisionHandler = GetComponent<PersonCollisionHandler>();

    private void OnEnable()
    {
        _collisionHandler.ObstacleHit += TakeCollision;
        _collisionHandler.BulletHit += TakeBulletHit;
    }

    private void OnDisable()
    {
        _collisionHandler.ObstacleHit -= TakeCollision;
        _collisionHandler.BulletHit -= TakeBulletHit;
    }

    protected abstract void TakeCollision(Obstacle danger);

    protected abstract void TakeBulletHit();
}
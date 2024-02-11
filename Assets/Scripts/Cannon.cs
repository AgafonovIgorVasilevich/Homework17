using UnityEngine;

[RequireComponent(typeof(BulletPool))]

public abstract class Cannon : MonoBehaviour
{
    [SerializeField] private PersonCollisionHandler _owner;

    private Collider2D _ignoredCollider;
    private BulletPool _pool;

    private void Awake()
    {
        _ignoredCollider = _owner.GetComponent<Collider2D>();
        _pool = GetComponent<BulletPool>();
    }

    protected void Shoot()
    {
        Vector2 direction = transform.right;
        Bullet bullet = _pool.GetBullet();

        bullet.Initialize(direction, transform.position, _ignoredCollider, _pool);
        _owner.AddException(bullet.GetComponent<Collider2D>());
    }
} 
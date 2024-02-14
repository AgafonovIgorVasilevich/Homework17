using UnityEngine;

public abstract class Cannon : MonoBehaviour
{
    [SerializeField] private Person _owner;

    [SerializeField] private BulletPool _pool;

    public void SetPool(BulletPool pool) => _pool = pool;

    protected void Shoot()
    {
        Vector2 direction = transform.right;
        Bullet bullet = _pool.Get();

        bullet.transform.position = transform.position;
        bullet.Launch(direction, _owner.Type);
    }
} 
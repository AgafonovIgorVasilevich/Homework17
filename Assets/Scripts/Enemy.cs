using UnityEngine;

[RequireComponent(typeof(EnemyMovement))]

public class Enemy : Person
{
    [SerializeField] private Cannon _cannon;

    public override PersonType Type => PersonType.Enemy;

    public void Initialize(BulletPool pool) => _cannon.SetPool(pool);

    protected override void TakeBulletHit()
    {
        Die();
    }

    protected override void TakeCollision(Obstacle danger)
    {
        
    }

    private void Die()
    {
        if (transform.parent.TryGetComponent(out EnemyPool pool))
            pool.Put(this);
        else
            Destroy(gameObject);
    }
}
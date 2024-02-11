using UnityEngine;

[RequireComponent(typeof(BulletCollisionHandler))]
[RequireComponent(typeof(Rigidbody2D))]

public class Bullet : DangerObject
{
    [SerializeField] private float _speed = 3;

    private BulletCollisionHandler _collisionHandler;
    private Rigidbody2D _rigidbody;
    private BulletPool _pool;

    private void Awake()
    {
        _collisionHandler = GetComponent<BulletCollisionHandler>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _collisionHandler.CollisionDetected += Remove;
        Player.s_GameOver += Remove;
    }

    private void OnDisable()
    {
        _collisionHandler.CollisionDetected -= Remove;
        Player.s_GameOver -= Remove;
    }

    public void Initialize(Vector2 direction, Vector2 position, Collider2D ignore, BulletPool pull)
    {
        _collisionHandler.SetIgnore(ignore);
        transform.position = position;
        gameObject.SetActive(true);
        _pool = pull;
        Launch(direction);
    }
    private void Launch(Vector2 direction)
    {
        direction = direction.normalized;
        _rigidbody.velocity = direction * _speed;
    }

    private void Remove()
    {
        gameObject.SetActive(false);
        _pool.PutBullet(this);
    }
}
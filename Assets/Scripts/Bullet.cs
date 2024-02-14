using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Bullet : MonoBehaviour, IInteractable
{
    [SerializeField] private float _speed = 3;

    private Rigidbody2D _rigidbody;

    public PersonType OwnerType { get; private set; }

    private void Awake() => _rigidbody = GetComponent<Rigidbody2D>();

    public void Launch(Vector2 direction, PersonType ownerType)
    {
        OwnerType = ownerType;
        direction = direction.normalized;
        _rigidbody.velocity = direction * _speed;
    }

    public void BackToPool()
    {
        if(transform.parent.TryGetComponent(out BulletPool pool))
            pool.Put(this);
        else
            Destroy(gameObject);
    }
}
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 2;
    [SerializeField] private float _jumpForce = 5;
    [SerializeField] private int _minAngle = -45;
    [SerializeField] private int _maxAngle = 45;

    private Quaternion _maxRotation;
    private Quaternion _minRotation;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _maxRotation = Quaternion.Euler(-0, 0, _maxAngle);
        _minRotation = Quaternion.Euler(0, 0, _minAngle);
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();

        transform.rotation = Quaternion.Lerp(transform.rotation,
            _minRotation, _rotationSpeed * Time.deltaTime);
    }

    private void Jump()
    {
        _rigidbody.velocity = Vector2.up * _jumpForce;
        transform.rotation = _maxRotation;
    }
}
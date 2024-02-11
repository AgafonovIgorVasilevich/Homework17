using UnityEngine;
using System;

[RequireComponent(typeof(PersonCollisionHandler))]
[RequireComponent(typeof(EnemyMovement))]

public class Enemy : MonoBehaviour
{
    private PersonCollisionHandler _collisionHandler;
    private EnemyMovement _movement;
    private EnemyPool _pull;

    public static Action s_EnemyDied;

    private void Awake()
    {
        _collisionHandler = GetComponent<PersonCollisionHandler>();
        _movement = GetComponent<EnemyMovement>();
    }

    private void OnEnable()
    {
        _collisionHandler.CollisionDetected += TakeCollision;
        Player.s_GameOver += Die;
    }

    private void OnDisable()
    {
        _collisionHandler.CollisionDetected -= TakeCollision;
        Player.s_GameOver -= Die;
    }

    public void Inintialize(Vector2 position, EnemyPool pull)
    {
        transform.position = position;
        gameObject.SetActive(true);
        _pull = pull;
        StartCoroutine(_movement.Move());
    }

    private void TakeCollision(IInteractable collision)
    {
        if (collision is Bullet)
            Die();
    }

    private void Die()
    {
        gameObject.SetActive(false);
        _pull.PutEnemy(this);
        s_EnemyDied?.Invoke();
    }
}
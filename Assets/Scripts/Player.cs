using UnityEngine;
using System;

[RequireComponent(typeof(PersonCollisionHandler))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(ScoreCounter))]

public class Player : MonoBehaviour
{
    private PersonCollisionHandler _collisionHandler;
    private PlayerMovement _movement;
    private ScoreCounter _score;

    public static Action s_GameOver;

    private void Awake()
    {
        _collisionHandler = GetComponent<PersonCollisionHandler>();
        _movement = GetComponent<PlayerMovement>();
        _score = GetComponent<ScoreCounter>();
    }

    private void OnEnable() => _collisionHandler.CollisionDetected += TakeCollision;

    private void OnDisable() => _collisionHandler.CollisionDetected -= TakeCollision;

    private void TakeCollision(IInteractable danger)
    {
        if(danger is DangerObject)
            Die();
    }

    private void Die()
    {
        s_GameOver?.Invoke();
        _movement.Reset();
        _score.Reset();
    }
}

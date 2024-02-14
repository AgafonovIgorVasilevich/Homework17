using UnityEngine;
using System;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(ScoreCounter))]

public class Player : Person
{
    public event Action Died;

    public override PersonType Type => PersonType.Player;

    protected override void TakeCollision(Obstacle danger) => Die();

    protected override void TakeBulletHit() => Die();

    private void Die() => Died?.Invoke();
}
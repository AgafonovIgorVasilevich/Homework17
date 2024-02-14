using UnityEngine;
using System;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private EnemyPool _enemyPool;

    private int _score;

    public Action<int> ScoreChanged;

    private void OnEnable() => _enemyPool.InstancePuted += AddScore;

    private void OnDisable() => _enemyPool.InstancePuted -= AddScore;

    public void AddScore()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }

    public void Reset()
    {
        _score = 0;
        ScoreChanged?.Invoke(_score);
    }
}
using UnityEngine;
using System;

public class ScoreCounter : MonoBehaviour
{
    private int _score;

    public Action<int> ScoreChanged;

    private void OnEnable() => Enemy.s_EnemyDied += AddScore;

    private void OnDisable() => Enemy.s_EnemyDied -= AddScore;

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
using System.Collections;
using UnityEngine;

public class EnemiesGenerator : MonoBehaviour
{
    [SerializeField] private float _timeDelay = 3;
    [SerializeField] private int _maxCount = 2;
    [SerializeField] private EnemyPool _pool;

    private int _currentCount = 0;

    private void OnEnable() => Enemy.s_EnemyDied += CreateFreePlace;

    private void OnDisable() => Enemy.s_EnemyDied -= CreateFreePlace;

    private void Start() => StartCoroutine(GenerateEnemies());

    private void Spawn()
    {
        Enemy enemy = _pool.GetEnemy();
        enemy.Inintialize(transform.position, _pool);
        _currentCount++;
    }

    private IEnumerator GenerateEnemies()
    {
        WaitForSeconds delay = new WaitForSeconds(_timeDelay);

        while (enabled)
        {
            if (_currentCount < _maxCount)
            {
                yield return delay;
                Spawn();
            }
            else
            {
                yield return null;
            }
        }
    }

    private void CreateFreePlace() => _currentCount--;
}
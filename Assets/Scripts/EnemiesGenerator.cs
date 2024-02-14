using System.Collections;
using UnityEngine;

public class EnemiesGenerator : MonoBehaviour
{
    [SerializeField] private float _delayTime = 3;
    [SerializeField] private int _maxCount = 2;

    [SerializeField] private BulletPool _bulletPool;
    [SerializeField] private EnemyPool _enemyPool;

    private int _currentCount = 0;

    private void OnEnable() => _enemyPool.InstancePuted += CreateFreePlace;

    private void OnDisable() => _enemyPool.InstancePuted -= CreateFreePlace;

    private void Start() => StartCoroutine(GenerateEnemies());

    private void Spawn()
    {
        Enemy enemy = _enemyPool.Get();
        enemy.transform.position = transform.position;
        enemy.Initialize(_bulletPool);
        _currentCount++;
    }

    private IEnumerator GenerateEnemies()
    {
        WaitForSeconds delay = new WaitForSeconds(_delayTime);

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
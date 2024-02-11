using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private Enemy _template;

    private Queue<Enemy> _pool = new Queue<Enemy>();

    public Enemy GetEnemy()
    {
        if(_pool.Count == 0 )
            return Instantiate(_template);

        return _pool.Dequeue();
    }

    public void PutEnemy(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
        _pool.Enqueue(enemy);
    }

    public void Reset() => _pool.Clear();
}
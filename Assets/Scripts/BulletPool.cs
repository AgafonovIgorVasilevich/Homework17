using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private Bullet _template;

    protected Queue<Bullet> _pool = new Queue<Bullet>();

    public Bullet GetBullet()
    {
        if (_pool.Count == 0)
            return Instantiate(_template);

        return _pool.Dequeue();
    }

    public void PutBullet(Bullet bullet) => _pool.Enqueue(bullet);
}
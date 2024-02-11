using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] protected float _amplitude = 2;
    [SerializeField] private float _speed = 2;

    private float _minYPosition = -3;
    private float _maxYPosition = 3f;

    private void Start() => StartCoroutine(Move());

    public IEnumerator Move()
    {
        Vector2 startPosition = GetRandomPosition();
        float yPosition;
        float angle = 0;

        while(enabled)
        {
            angle += Time.deltaTime;
            yPosition = startPosition.y + Mathf.Sin(angle * _speed) * _amplitude;
            transform.position = new Vector2(startPosition.x, yPosition);
            yield return null;
        }
    }

    private Vector2 GetRandomPosition()
    {
        Vector2 currentPosition = transform.position;
        currentPosition.y = Random.Range(_minYPosition, _maxYPosition);
        transform.position = currentPosition;

        return currentPosition;
    }
}
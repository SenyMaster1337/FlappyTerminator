using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class EnemyRemover : MonoBehaviour
{
    private BoxCollider2D _boxCollider;

    public event Action<Enemy> EnemyCollisionDetected;

    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider2D>();

        if (_boxCollider != null)
        {
            _boxCollider.isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            EnemyCollisionDetected?.Invoke(enemy);
        }
    }
}

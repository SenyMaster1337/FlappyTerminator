using System;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class BirdCollisionHandler : MonoBehaviour
{
    private CircleCollider2D _circleCollider;

    public event Action OnCollisionDetected;

    private void Awake()
    {
        _circleCollider = GetComponent<CircleCollider2D>();

        if (_circleCollider != null)
        {
            _circleCollider.isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent(out Bullet bullet) || other.TryGetComponent(out Ground ground))
        {
            OnCollisionDetected?.Invoke();
        }
    }
}

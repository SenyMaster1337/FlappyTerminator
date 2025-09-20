using System;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class CollisionHandler : MonoBehaviour
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

    public void InvokeCollisionDetected()
    {
        OnCollisionDetected?.Invoke();
    }
}

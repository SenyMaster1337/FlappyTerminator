using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 4f;
    [SerializeField] private float _delayResetParameters = 3f;
    [SerializeField] private LayerMask targetMask;

    private CircleCollider2D _circleCollider;
    private Rigidbody2D _rigidbody;
    private Coroutine _coroutine;
    private int _bitShift = 1;

    public event Action<Bullet> ParametersReseted;

    private void Awake()
    {
        _circleCollider = GetComponent<CircleCollider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();

        if (_circleCollider != null)
        {
            _circleCollider.isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((_bitShift << collision.gameObject.layer) & targetMask) != 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void Init(Vector2 direction)
    {
        _rigidbody.velocity = direction.normalized * _speed;
    }

    public void ResetParameters()
    {
        transform.rotation = Quaternion.identity;
        _rigidbody.velocity = Vector2.zero;
    }

    public void StartLifetimeCount()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(CountLifetime());
    }

    private IEnumerator CountLifetime()
    {
        yield return new WaitForSeconds(_delayResetParameters);

        ResetParameters();
        ParametersReseted?.Invoke(this);
    }
}

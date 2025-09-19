using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 4f;

    private Rigidbody2D _rigidbody;
    private Coroutine _coroutine;

    public event Action<Bullet> ParametersReseted;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            Destroy(this.gameObject);
            enemy.gameObject.SetActive(false);
        }
    }

    public void ChangeDirection()
    {
        _rigidbody.velocity = transform.right * _speed;
    }

    public void StartLifetimeCount()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(CountLifetime());
    }

    private IEnumerator CountLifetime()
    {
        yield return new WaitForSeconds(3f);

        ResetParameters();
        ParametersReseted?.Invoke(this);
    }

    public void ResetParameters()
    {
        transform.rotation = Quaternion.identity;
        _rigidbody.velocity = Vector2.zero;
    }
}

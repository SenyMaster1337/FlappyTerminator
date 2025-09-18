using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 4f;

    private CircleCollider2D _circleCollider;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _circleCollider = GetComponent<CircleCollider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = transform.right * _speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            Destroy(this.gameObject);
            Destroy(enemy.gameObject);
        }

        if (collision.gameObject.TryGetComponent(out BirdPlayer birdPlayer))
        {
            //Destroy(birdPlayer.gameObject);
        }
    }
}

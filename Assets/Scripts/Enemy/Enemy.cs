using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private Flipper _flipper;
    [SerializeField] private Transform _transformSpriteRenderer;
    [SerializeField] private float _spawnBulletDelay;

    private CircleCollider2D _circleCollider;

    private void Awake()
    {
        _circleCollider = GetComponent<CircleCollider2D>();

        if (_circleCollider != null)
        {
            _circleCollider.isTrigger = true;
        }
    }

    public void Shoot()
    {
        _weapon.StartShooting();
    }

    public void StopShoot()
    {
        _weapon.StopShooting();
    }

    public void FlipEnemy(int rotationValue)
    {
        _flipper.Flip(_transformSpriteRenderer, rotationValue);
    }
}

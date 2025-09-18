using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private Flipper _flipper;
    [SerializeField] private Transform _transformSpriteRenderer;

    private CircleCollider2D _circleCollider;

    private void Awake()
    {
        _circleCollider = GetComponent<CircleCollider2D>();

        if (_circleCollider != null)
        {
            _circleCollider.isTrigger = true;
        }
    }

    private void Update()
    {
        _weapon.Shoot();
    }

    public void FlipEnemy()
    {
        _flipper.Flip(_transformSpriteRenderer);
    }
}

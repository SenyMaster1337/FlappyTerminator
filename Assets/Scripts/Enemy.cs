using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private Flipper _flipper;
    [SerializeField] private Transform _transformSpriteRenderer;
    [SerializeField] private float _spawnBulletDelay;

    private CircleCollider2D _circleCollider;
    private Rigidbody2D _rigidbody;
    private Coroutine _coroutine;
    private bool _isSpawnerBulletEnabled = false;

    private void Awake()
    {
        _circleCollider = GetComponent<CircleCollider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();

        if (_circleCollider != null)
        {
            _circleCollider.isTrigger = true;
        }
    }

    public void ToggleSwitch()
    {
        if (_isSpawnerBulletEnabled)
        {
            StopCounting();
        }
        else
        {
            StartCounting();
        }
    }

    public void StartCounting()
    {
        _isSpawnerBulletEnabled = true;
        _coroutine = StartCoroutine(CountCubesSpawn());
    }

    public void StopCounting()
    {
        _isSpawnerBulletEnabled = false;
        StopCoroutine(_coroutine);
    }

    private IEnumerator CountCubesSpawn()
    {
        var wait = new WaitForSeconds(_spawnBulletDelay);

        while (_isSpawnerBulletEnabled)
        {
            _weapon.Shoot();
            yield return wait;
        }
    }

    public void FlipEnemy(int rotationValue)
    {
        _flipper.Flip(_transformSpriteRenderer, rotationValue);
    }
}

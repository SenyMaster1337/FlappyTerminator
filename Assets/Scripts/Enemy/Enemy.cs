using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyShooter _enemyShooter;
    [SerializeField] private EnemyCollisionHandler _enemyCollisionHandler;
    [SerializeField] private Flipper _flipper;
    [SerializeField] private Transform _transformSpriteRenderer;
    [SerializeField] private float _spawnBulletDelay;

    private EnemySpawner _enemySpawner;

    public void Init(EnemySpawner enemySpawner)
    {
        _enemySpawner = enemySpawner;
    }

    private void OnEnable()
    {
        _enemyCollisionHandler.OnCollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _enemyCollisionHandler.OnCollisionDetected -= ProcessCollision;
    }

    public void Shoot()
    {
        _enemyShooter.StartShooting();
    }

    public void StopShoot()
    {
        _enemyShooter.StopShooting();
    }

    public void FlipEnemy(int rotationValue)
    {
        _flipper.Flip(_transformSpriteRenderer, rotationValue);
    }

    private void ProcessCollision()
    {
        _enemySpawner.ReleaseObjectToPool(this);
    }
}

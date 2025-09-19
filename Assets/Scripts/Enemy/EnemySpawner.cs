using System.Collections;
using UnityEngine;

public class EnemySpawner : Spawners.Spawner<Enemy>
{
    [SerializeField] private EnemyRemover _enemyRemover;
    [SerializeField] private float _spawnDelay;

    private Coroutine _coroutine;
    private bool _isSpawnerEnabled = true;
    private int _minRandomPositionY = -3;
    private int _maxRandomPositionY = 4;
    private int _rotationValueRight = 0;
    private int _rotationValueleft = 180;

    private void Start()
    {
        StartEnemiesSpawnCount();
    }

    private void OnEnable()
    {
        _enemyRemover.EnemyCollisionDetected += ReleaseObjectToPool;
    }

    private void OnDisable()
    {
        _enemyRemover.EnemyCollisionDetected -= ReleaseObjectToPool;
    }

    public override Enemy CreateFunc()
    {
        Enemy enemy = Instantiate(Prefab);

        return enemy;
    }

    public override void ReleaseObjectToPool(Enemy enemy)
    {
        enemy.StopShoot();
        enemy.FlipEnemy(_rotationValueRight);
        base.ReleaseObjectToPool(enemy);
    }

    public override void ChangeParameters(Enemy enemy)
    {
        int randomPositionY = UnityEngine.Random.Range(_minRandomPositionY, _maxRandomPositionY);

        base.ChangeParameters(enemy);

        enemy.transform.position = new Vector3(transform.position.x, randomPositionY, transform.position.z);

        enemy.FlipEnemy(_rotationValueleft);

        enemy.Shoot();
    }

    private void StartEnemiesSpawnCount()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(CountEnemiesSpawn());
    }

    private IEnumerator CountEnemiesSpawn()
    {
        var wait = new WaitForSeconds(_spawnDelay);

        while (_isSpawnerEnabled)
        {
            yield return wait;
            SpawnObject();
        }
    }
}

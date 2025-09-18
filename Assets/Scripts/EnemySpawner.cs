using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawner : Spawners.Spawner<Enemy>
{
    [SerializeField] private float _spawnDelay;

    private Coroutine _lifetimeCoroutine;
    private bool _isSpawnerEnabled = true;
    private int _minRandomPositionY = -3;
    private int _maxRandomPositionY = 4;

    private void Start()
    {
        StartCubesSpawnCount();
    }

    public override Enemy CreateFunc()
    {
        Enemy enemy = Instantiate(Prefab);

        return enemy;
    }

    public void PutObject(Enemy Enemy)
    {
        Enemy.gameObject.SetActive(false);
    }

    public override void DestroyObject(Enemy enemy)
    {
        //enemy.ParametersReseted -= ReleaseObjectToPool;
        base.DestroyObject(enemy);
    }

    public override void ReleaseObjectToPool(Enemy enemy)
    {
        base.ReleaseObjectToPool(enemy);
    }

    public override void ChangeParameters(Enemy enemy)
    {
        int randomPositionY = UnityEngine.Random.Range(_minRandomPositionY, _maxRandomPositionY);

        enemy.transform.position = new Vector3(transform.position.x + 5, randomPositionY, transform.position.z);

        enemy.FlipEnemy();

        base.ChangeParameters(enemy);
    }

    private void StartCubesSpawnCount()
    {
        if (_lifetimeCoroutine != null)
            StopCoroutine(_lifetimeCoroutine);

        _lifetimeCoroutine = StartCoroutine(CountCubesSpawn());
    }

    private IEnumerator CountCubesSpawn()
    {
        var wait = new WaitForSeconds(_spawnDelay);

        while (_isSpawnerEnabled)
        {
            yield return wait;
            SpawnObject();
        }
    }
}

using System.Collections;
using UnityEngine;

public class Weapon : Spawners.Spawner<Bullet>
{
    [SerializeField] private FirePoint _firePoint;
    [SerializeField] private float _spawnBulletDelay;

    private Coroutine _coroutine;
    private bool _isSpawnerBulletEnabled = false;
    private bool _isOnCooldown = false;

    public override Bullet CreateFunc()
    {
        Bullet bullet = Instantiate(Prefab);
        bullet.ParametersReseted += ReleaseObjectToPool;

        return bullet;
    }

    public override void ReleaseObjectToPool(Bullet bullet)
    {
        base.ReleaseObjectToPool(bullet);
    }

    public override void DestroyObject(Bullet bullet)
    {
        bullet.ParametersReseted -= ReleaseObjectToPool;
        base.DestroyObject(bullet);
    }

    public override void ChangeParameters(Bullet bullet)
    {
        base.ChangeParameters(bullet);
        bullet.transform.position = _firePoint.transform.position;
        bullet.transform.rotation = _firePoint.transform.rotation;
        bullet.ChangeDirection();
        bullet.StartLifetimeCount();
    }

    public void OneShoot()
    {
        if (_isOnCooldown == false)
        {
            SpawnObject();
            StartActivateCooldown();
        }
    }

    public void StartShooting()
    {
        _isSpawnerBulletEnabled = true;
        _coroutine = StartCoroutine(CountBulletSpawn());
    }

    public void StopShooting()
    {
        _isSpawnerBulletEnabled = false;

        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private void StartActivateCooldown()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ActivateCooldown());
    }

    private IEnumerator ActivateCooldown()
    {
        _isOnCooldown = true;

        yield return new WaitForSeconds(_spawnBulletDelay);

        _isOnCooldown = false;
    }

    private IEnumerator CountBulletSpawn()
    {
        var wait = new WaitForSeconds(_spawnBulletDelay);

        while (_isSpawnerBulletEnabled)
        {
            SpawnObject();
            yield return wait;
        }
    }
}

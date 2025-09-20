using System.Collections;
using UnityEngine;

public class EnemyShooter : BulletSpawner
{
    private bool _isSpawnerBulletEnabled = false;
    private Vector2 _directionLeft = Vector2.left;

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

    private IEnumerator CountBulletSpawn()
    {
        var wait = new WaitForSeconds(SpawnBulletDelay);

        while (_isSpawnerBulletEnabled)
        {
            SpawnObject();
            yield return wait;
        }
    }

    public override void ChangeParameters(Bullet bullet)
    {
        base.ChangeParameters(bullet);
        bullet.Init(_directionLeft);
    }
}

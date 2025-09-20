using System.Collections;
using UnityEngine;

public class PlayerShooter : BulletSpawner
{
    private bool _isOnCooldown = false;
    private Vector2 _directionRight = Vector2.right;

    public void ShootOnce()
    {
        if (_isOnCooldown == false)
        {
            SpawnObject();
            StartActivateCooldown();
        }
    }

    public override void ChangeParameters(Bullet bullet)
    {
        base.ChangeParameters(bullet);
        bullet.Init(_directionRight);
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

        yield return new WaitForSeconds(SpawnBulletDelay);

        _isOnCooldown = false;
    }
}


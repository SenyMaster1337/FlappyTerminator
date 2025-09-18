using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private FirePoint _firePoint;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _timeCooldown;

    private Coroutine _coroutine;

    public bool IsOnCooldown { get; private set; }

    private void Awake()
    {
        IsOnCooldown = false;
    }

    public void Shoot()
    {
        if (IsOnCooldown == false)
        {
            Bullet bullet = Instantiate(_bulletPrefab);
            bullet.transform.position = _firePoint.transform.position;
            bullet.transform.rotation = _firePoint.transform.rotation;

            StartActivateCooldown();
        }
    }

    private void StartActivateCooldown()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ActivateCooldown());
    }

    private IEnumerator ActivateCooldown()
    {
        IsOnCooldown = true;

        yield return new WaitForSeconds(_timeCooldown);

        IsOnCooldown = false;
    }
}

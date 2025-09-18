using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private FirePoint _firePoint;
    [SerializeField] private Bullet _bulletPrefab;

    public void Shoot()
    {
        Bullet bullet = Instantiate(_bulletPrefab);
        bullet.transform.position = _firePoint.transform.position;
        bullet.transform.rotation = _firePoint.transform.rotation;
    }
}

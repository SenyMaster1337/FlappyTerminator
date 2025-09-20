using UnityEngine;

public class BulletSpawner : Spawners.Spawner<Bullet>
{
    [SerializeField] protected FirePoint FirePoint;
    [SerializeField] protected float SpawnBulletDelay;

    protected Coroutine _coroutine;

    public override Bullet CreateFunc()
    {
        Bullet bullet = Instantiate(Prefab);
        bullet.ParametersReseted += ReleaseObjectToPool;

        return bullet;
    }

    public override void DestroyObject(Bullet bullet)
    {
        bullet.ParametersReseted -= ReleaseObjectToPool;
        base.DestroyObject(bullet);
    }

    public override void ChangeParameters(Bullet bullet)
    {
        base.ChangeParameters(bullet);
        bullet.transform.position = FirePoint.transform.position;
        bullet.StartLifetimeCount();
    }
}

using UnityEngine;

public class EnemyCollisionHandler : CollisionHandler
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Bullet bullet))
        {
            InvokeCollisionDetected();
        }
    }
}

using UnityEngine;

public class BirdCollisionHandler : CollisionHandler
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent(out Bullet bullet) || other.TryGetComponent(out Ground ground))
        {
            InvokeCollisionDetected();
        }
    }
}

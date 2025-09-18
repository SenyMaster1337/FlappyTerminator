using UnityEngine;

public class Flipper : MonoBehaviour
{
    public void Flip(Transform transform)
    {
        transform.Rotate(0, 180, 0);
    }
}

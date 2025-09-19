using UnityEngine;

public class Flipper : MonoBehaviour
{
    private Quaternion _rotation;

    public void Flip(Transform transform, int rotationValue)
    {
        _rotation.y = rotationValue;
        transform.rotation = _rotation;
    }
}

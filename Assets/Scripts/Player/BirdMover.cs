using UnityEngine;

public class BirdMover : MonoBehaviour
{
    [SerializeField] private float _tapForce;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;

    private Quaternion _maxRotation;
    private Quaternion _minRotation;
    private Transform _transform;
    private Rigidbody2D _rigidbody;
    private Vector2 _startPositon;

    public void SetInitialValues(Transform transform, Rigidbody2D rigidbody)
    {
        _transform = transform;
        _rigidbody = rigidbody;

        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
    }

    public void TranslateDirection()
    {
        _rigidbody.velocity = new Vector2(_speed, _tapForce);
        _transform.rotation = _maxRotation;
    }

    public void TranslateRotation()
    {
        _transform.rotation = Quaternion.Lerp(_transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    public void Reset()
    {
        _transform.position = _startPositon;
        _transform.rotation = Quaternion.identity;
        _rigidbody.velocity = Vector2.zero;
    }
}

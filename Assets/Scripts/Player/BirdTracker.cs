using UnityEngine;

public class BirdTracker : MonoBehaviour
{
    [SerializeField] private BirdPlayer _bird;
    [SerializeField] private float _x0ffset;

    private void Update()
    {
        var position = transform.position;
        position.x = _bird.transform.position.x + _x0ffset;
        transform.position = position;
    }
}

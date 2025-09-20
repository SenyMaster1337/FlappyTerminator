using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdPlayer : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private BirdMover _birdMover;
    [SerializeField] private BirdCollisionHandler _birdCollisionHandler;
    [SerializeField] private PlayerShooter _playerShooter;

    private Rigidbody2D _rigidbody;

    public event Action GameOver;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _birdCollisionHandler.OnCollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _birdCollisionHandler.OnCollisionDetected -= ProcessCollision;
    }

    private void Start()
    {
        _birdMover.SetInitialValues(transform, _rigidbody);

        Reset();
    }

    private void Update()
    {
        if (_inputReader.IsJumpButtonClicked)
            _birdMover.TranslateDirection();

        _birdMover.TranslateRotation();

        if (_inputReader.IsAttackButtonClicked)
        {
            _playerShooter.ShootOnce();
        }
    }

    private void ProcessCollision()
    {
        GameOver?.Invoke();
    }

    public void Reset()
    {
        _birdMover.Reset();
    }
}

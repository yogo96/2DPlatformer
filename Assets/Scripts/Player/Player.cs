using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerAnimation))]
[RequireComponent(typeof(Wallet))]
[RequireComponent(typeof(Health))]
public class Player : MonoBehaviour, IDamageable, IBoundsHandler
{
    [SerializeField] private Transform _spawnPoint;

    private Health _health;
    private PlayerMover _mover;
    private PlayerAnimation _animation;
    private PlayerInput _input;
    private Wallet _wallet;
    private int _outBoundPosition = -1;
    private int _minHealth = 0;
    private float _pickUpCooldown = 1.0f;
    private float _lastPickUpTime = -1.0f;

    private void Awake()
    {
        _animation = GetComponent<PlayerAnimation>();
        _mover = GetComponent<PlayerMover>();
        _input = GetComponent<PlayerInput>();
        _wallet = GetComponent<Wallet>();
        _health = GetComponent<Health>();

        _health.OnHealthDepleted += Respawn;
    }

    private void Update()
    {
        _mover.Move(_input.MoveDirection);

        Animate();
    }

    private void FixedUpdate()
    {
        if (_input.Jump)
            _mover.Jump();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PickableItem pickableItem))
        {
            if (pickableItem is Coin)
                _wallet.AddCash(pickableItem.PickUp());
            else if (pickableItem is FirstAidKit && Time.time - _lastPickUpTime > _pickUpCooldown)
            {
                _health.AddValue(pickableItem.PickUp());
                _lastPickUpTime = Time.time;
            }
        }
    }

    private void OnDisable()
    {
        _health.OnHealthDepleted -= Respawn;
    }

    public void TakeDamage(int value)
    {
        _animation.Hit();
        _health.TakeDamage(value);
    }
    
    public void HandleOutOfBounds()
    {
        _animation.Fall(false);
        Respawn();
    }

    private void Animate()
    {
        _animation.Jump(_mover.IsJump);
        _animation.Run(_mover.IsRun);
        _animation.Fall(_mover.IsFall);
    }

    private void Respawn()
    {
        transform.position = _spawnPoint.position;
        _health.Reset();
    }
}
using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerAnimation))]
[RequireComponent(typeof(Wallet))]
public class Player : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    
    private PlayerMover _mover;
    private PlayerAnimation _animation;
    private PlayerInput _input;
    private Wallet _wallet;

    private void Awake()
    {
        _animation = GetComponent<PlayerAnimation>();
        _mover = GetComponent<PlayerMover>();
        _input = GetComponent<PlayerInput>();
        _wallet = GetComponent<Wallet>();
    }

    private void Update()
    {
        _mover.Move(_input.MoveDirection);

        Animate();
        CheckOutOfBounds();
    }

    private void FixedUpdate()
    {
        if (_input.TryJump)
            _mover.Jump();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Coin>(out Coin coin))
        {
            _wallet.AddCash(coin.PickUp());
        }
    }
    
    private void Animate()
    {
        _animation.Jump(_mover.IsJump);
        _animation.Run(_mover.IsRun);
        _animation.Fall(_mover.IsFall);
    }

    private void CheckOutOfBounds()
    {
        if (transform.position.y < -1)
        {
            transform.position = _spawnPoint.position;
            _animation.Fall(false);
        }
    }
}
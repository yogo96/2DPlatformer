using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerAnimation))]
[RequireComponent(typeof(Wallet))]
public class Player : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    
    private PlayerMovement _movement;
    private PlayerAnimation _animation;
    private PlayerInput _input;
    private Wallet _wallet;

    private void Awake()
    {
        _animation = GetComponent<PlayerAnimation>();
        _movement = GetComponent<PlayerMovement>();
        _input = GetComponent<PlayerInput>();
        _wallet = GetComponent<Wallet>();
    }

    private void Update()
    {
        _movement.Move(_input.MoveDirection);
        
        if (_input.TryJump)
            _movement.Jump();
        
        Animate();
        CheckOutOfBounds();
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
        _animation.Jump(_movement.IsJump());
        _animation.Run(_movement.IsRun());
        _animation.Fall(_movement.IsFall());
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
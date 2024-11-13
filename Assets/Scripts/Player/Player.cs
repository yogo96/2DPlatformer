using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerAnimation))]
[RequireComponent(typeof(Wallet))]
[RequireComponent(typeof(Health))]
public class Player : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;

    private Health _health;
    private PlayerMover _mover;
    private PlayerAnimation _animation;
    private PlayerInput _input;
    private Wallet _wallet;
    private int _outBoundPosition = -1;
    private int _minHealth = 0;

    private void Awake()
    {
        _animation = GetComponent<PlayerAnimation>();
        _mover = GetComponent<PlayerMover>();
        _input = GetComponent<PlayerInput>();
        _wallet = GetComponent<Wallet>();
        _health = GetComponent<Health>();
    }

    private void Update()
    {
        _mover.Move(_input.MoveDirection);

        Animate();
        CheckOutOfBounds();

        if (_health.GetValue() <= _minHealth)
        {
            Respawn();
        }
    }

    private void FixedUpdate()
    {
        if (_input.Jump)
            _mover.Jump();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Coin coin))
        {
            _wallet.AddCash(coin.PickUp());
        }
        if (other.TryGetComponent(out FirstAidKit firstAidKit))
        {
            if (firstAidKit.TryPickUp(out  int value))
                _health.AddValue(value);
        }
    }

    public void TakeDamage(int value)
    {
        _animation.Hit();
        _health.TakeDamage(value);
    }

    private void Animate()
    {
        _animation.Jump(_mover.IsJump);
        _animation.Run(_mover.IsRun);
        _animation.Fall(_mover.IsFall);
    }

    private void CheckOutOfBounds()
    {
        if (transform.position.y < _outBoundPosition)
        {
            _animation.Fall(false);
            Respawn();
        }
    }

    private void Respawn()
    {
        transform.position = _spawnPoint.position;
        _health.Reset();
    }
}
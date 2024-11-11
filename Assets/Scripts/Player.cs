using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerAnimation))]
[RequireComponent(typeof(Wallet))]
public class Player : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private int _health = 100;
    
    private PlayerMover _mover;
    private PlayerAnimation _animation;
    private PlayerInput _input;
    private Wallet _wallet;
    private int _outBoundPosition = -1;
    private int _maxHealth = 100;
    private int _minHealth = 0;

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

        if (_health <= _minHealth)
        {
            Respawn();
        }
    }

    private void FixedUpdate()
    {
        if (_input.TryJump)
            _mover.Jump();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<IPickable>(out IPickable pickable))
        {
            pickable.PickUp(this);
        }
    }
    
    public void AddCoin(int value)
    {
        _wallet.AddCash(value);
    }

    public void Heal(int value)
    {
        _health += value;
        if (_health > _maxHealth)
        {
            _health = _maxHealth;
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
        if (transform.position.y < _outBoundPosition)
        {
            _animation.Fall(false);
            Respawn();
        }
    }

    private void Respawn()
    {
        transform.position = _spawnPoint.position;
        _health = _maxHealth;
    }
}
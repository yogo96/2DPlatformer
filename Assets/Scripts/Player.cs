using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerInput))]
public class Player : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    
    private PlayerMovement _movement;
    private PlayerInput _input;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _movement = GetComponent<PlayerMovement>();
        _input = GetComponent<PlayerInput>();
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
            coin.PickUp();
        }
    }
    
    private void Animate()
    {
        _animator.SetBool(PlayerAnimatorData.Params.IsRun, _movement.IsRun());
        _animator.SetBool(PlayerAnimatorData.Params.IsJump, _movement.IsJump());
        _animator.SetBool(PlayerAnimatorData.Params.IsFall, _movement.IsFall());
    }

    private void CheckOutOfBounds()
    {
        if (transform.position.y < -1)
        {
            transform.position = _spawnPoint.position;
            _animator.SetBool(PlayerAnimatorData.Params.IsFall, false);
        }
    }
}
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMovement))]
public class Player : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    
    private PlayerMovement _playerMovement;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
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
        _animator.SetBool("isRun", _playerMovement.IsRun());
        _animator.SetBool("isJump", _playerMovement.IsJump());
        _animator.SetBool("isFall", _playerMovement.IsFall());
    }

    private void CheckOutOfBounds()
    {
        if (transform.position.y < -1)
        {
            transform.position = _spawnPoint.position;
        }
    }
}
using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(EnemyAnimation))]
public class Enemy : MonoBehaviour
{
    private EnemyMover _mover;
    private Health _health;
    private EnemyAnimation _animator;
    private int _minHealth = 0;
    
    private void Awake()
    {
        _mover = GetComponent<EnemyMover>();
        _health = GetComponent<Health>();
        _animator = GetComponent<EnemyAnimation>();
    }

    private void Update()
    {
        _mover.Move();

        if (_health.Value <= _minHealth)
        {
            gameObject.SetActive(false);
        }
    }

    public void TakeDamage(int value)
    {
        _animator.Hit();
        _health.TakeDamage(value);
    }
}
using System;
using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(EnemyAnimation))]
public class Enemy : MonoBehaviour, IDamageable, IBoundsHandler
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

        _health.OnHealthDepleted += HandleHealthDepleted;
    }

    private void Update()
    {
        _mover.Move();
    }

    private void OnDisable()
    {
        _health.OnHealthDepleted -= HandleHealthDepleted;
    }

    public void TakeDamage(int value)
    {
        _animator.Hit();
        _health.TakeDamage(value);
    }

    public void HandleOutOfBounds()
    {
        _mover.ResetPosition();
    }
    
    private void HandleHealthDepleted()
    {
        gameObject.SetActive(false);
    }
}
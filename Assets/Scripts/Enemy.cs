using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour
{
    private EnemyMover _mover;
    private Health _health;
    private int _minHealth = 0;
    
    private void Awake()
    {
        _mover = GetComponent<EnemyMover>();
        _health = GetComponent<Health>();
    }

    private void Update()
    {
        _mover.Move();

        if (_health.GetValue() <= _minHealth)
        {
            gameObject.SetActive(false);
        }
    }
}
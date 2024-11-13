using System.Collections;
using UnityEngine;

public abstract class Combat<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected int _attackDamage;

    protected T _target;
    protected Health _targetHealth;

    private bool _isAttack;
    private Coroutine _attackingCoroutine;
    private WaitForSeconds _attackDelay = new WaitForSeconds(0.5f);

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out T attackTarget))
        {
            if (attackTarget.TryGetComponent<Health>(out _targetHealth))
            {
                _target = attackTarget;
                _isAttack = true;
                _attackingCoroutine = StartCoroutine(Attacking());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<T>(out _))
        {
            _isAttack = false;
        }
    }

    private void OnDisable()
    {
        if (_attackingCoroutine != null)
            StopCoroutine(_attackingCoroutine);
    }

    protected abstract void AttackTarget();
    
    private IEnumerator Attacking()
    {
        while (_isAttack)
        {
            AttackTarget();
            yield return _attackDelay;
        }
    }
}
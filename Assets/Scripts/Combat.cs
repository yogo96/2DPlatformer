using System.Collections;
using UnityEngine;

public abstract class Combat<T> : MonoBehaviour where T : MonoBehaviour, IDamageable
{
    [SerializeField] protected int _attackDamage;

    private T _target;
    private Health _targetHealth;
    private bool _isAttack;
    private Coroutine _attackingCoroutine;
    private WaitForSeconds _attackDelay = new WaitForSeconds(0.5f);

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out T target))
        {
            _target = target;
            _isAttack = true;
            _attackingCoroutine = StartCoroutine(Attacking());
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

    private IEnumerator Attacking()
    {
        while (_isAttack)
        {
            _target.TakeDamage(_attackDamage);
            yield return _attackDelay;
        }
    }
}
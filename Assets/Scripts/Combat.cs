using System.Collections;
using UnityEngine;

public class Combat<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private int _attackDamage;

    private bool _isAttack;
    private Health _targetHealth;
    private Coroutine _attackingCoroutine;
    private WaitForSeconds _attackDelay = new WaitForSeconds(0.5f);

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out T attackTarget))
        {
            if (attackTarget.TryGetComponent<Health>(out _targetHealth))
            {
                Debug.Log(attackTarget.name);
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

    private IEnumerator Attacking()
    {
        while (_isAttack)
        {
            _targetHealth.TakeDamage(_attackDamage);
            yield return _attackDelay;
        }
    }
}
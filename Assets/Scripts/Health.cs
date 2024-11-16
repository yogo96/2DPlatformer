using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Action Depleted;
    [field: SerializeField] public int Value { get; private set; }

    [SerializeField] private int _maxValue = 100;

    private int _minValue = 0;

    private void Awake()
    {
        Reset();
    }

    public void AddValue(int count)
    {
        if (count <= _minValue)
            return;

        Value = Mathf.Clamp(Value + count, _minValue, _maxValue);
    }

    public void TakeDamage(int value)
    {
        if (value <= _minValue)
            return;

        Value = Mathf.Clamp(Value - value, _minValue, _maxValue);

        if (Value == 0)
        {
            Depleted?.Invoke();
        }
    }

    public void Reset()
    {
        Value = _maxValue;
    }
}
using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _currentValue;
    [SerializeField] private int _maxValue;

    public event Action Died;
    public event Action<Vector2> Damaged;
    public event Action<int, int> ValueChanged;

    public void TakeHeal(int healAmount)
    {
        if (healAmount < 0)
            return;

        Add(healAmount);
    }

    public void TakeDamage(int damage, Vector2 damageSource)
    {
        if (damage < 0)
            return;

        Add(-damage);

        if (_currentValue <= 0)
            Died?.Invoke();

        Damaged?.Invoke(damageSource);
    }

    private void Add(int value)
    {
        float _lastValue = _currentValue;

        _currentValue += value;

        _currentValue = Mathf.Clamp(_currentValue, 0, _maxValue);

        if (_lastValue != _currentValue)
            ValueChanged?.Invoke(_currentValue, _maxValue);
    }
}

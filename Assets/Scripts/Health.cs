using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _currentValue;
    [SerializeField] private int _maxValue;

    public event Action Died;
    public event Action<Vector2> Damaged;
    public event Action<int, int> ValueChanged;

    public bool TryHeal(int healAmount)
    {
        if (_currentValue < _maxValue)
        {
            if (_currentValue + healAmount > _maxValue)
                _currentValue = _maxValue;
            else
                _currentValue += healAmount;
        }

        ValueChanged?.Invoke(_currentValue, _maxValue);

        return _currentValue < _maxValue;
    }

    public void TakeDamage(int damage, Vector2 damageSource)
    {
        if (damage < 0)
            return;

        if (_currentValue - damage >= 0)
            _currentValue -= damage;
        else
            _currentValue = 0;

        if (_currentValue <= 0)
            Died?.Invoke();

        ValueChanged?.Invoke(_currentValue, _maxValue);

        Damaged?.Invoke(damageSource);
    }
}

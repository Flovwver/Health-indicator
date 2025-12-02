using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SmoothHealthBar : HealthBar
{
    [SerializeField] private float _healthChangeSpeed = 1f;

    private float _targetValue;

    private Coroutine _smoothCoroutine;

    protected override void OnHealthChanged(int currentHealth, int maxHealth)
    {
        _slider.maxValue = maxHealth;
        _targetValue = currentHealth;

        if (_smoothCoroutine == null)
            _smoothCoroutine = StartCoroutine(ChangeHealthSmooth());
    }

    private IEnumerator ChangeHealthSmooth()
    {
        while (_slider.value != _targetValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _targetValue, _healthChangeSpeed * Time.deltaTime);
            yield return null;
        }

        _smoothCoroutine = null;
    }
}

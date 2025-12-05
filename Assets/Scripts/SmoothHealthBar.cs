using System.Collections;
using UnityEngine;

public class SmoothHealthBar : HealthBar
{
    [SerializeField] private float _valueChangeSpeed = 1f;

    private float _targetValue;

    private Coroutine _smoothCoroutine;

    protected override void OnValueChanged(int currentValue, int maxValue)
    {
        _slider.maxValue = maxValue;
        _targetValue = currentValue;

        _smoothCoroutine ??= StartCoroutine(ChangeValueSmooth());
    }

    private IEnumerator ChangeValueSmooth()
    {
        while (_slider.value != _targetValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _targetValue, _valueChangeSpeed * Time.deltaTime);
            yield return null;
        }

        _smoothCoroutine = null;
    }
}

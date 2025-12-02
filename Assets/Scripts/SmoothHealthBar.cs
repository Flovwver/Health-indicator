using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SmoothHealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private float _healthChangeSpeed = 1f;

    private float _targetValue;
    private Slider _slider;

    private Coroutine _smoothCoroutine;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _health.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int currentHealth, int maxHealth)
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

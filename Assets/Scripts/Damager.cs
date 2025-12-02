using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Damager : MonoBehaviour
{
    [SerializeField] private int _damageAmount = 10;
    [SerializeField] private Health _target;

    [SerializeField] private Vector2 _sourcePosition = new(0f, 0f);

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(DealDamage);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(DealDamage);
    }

    private void DealDamage()
    {
        _target.TakeDamage(_damageAmount, _sourcePosition);
    }
}

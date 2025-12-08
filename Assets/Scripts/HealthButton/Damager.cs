using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Damager : HealthButton
{
    [SerializeField] private int _damageAmount = 10;

    [SerializeField] private Vector2 _sourcePosition = new(0f, 0f);

    protected override void OnButtonClicked()
    {
        _target.TakeDamage(_damageAmount, _sourcePosition);
    }
}

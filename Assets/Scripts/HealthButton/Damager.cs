using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Damager : HealthButton
{
    [SerializeField] private int _damageAmount = 10;

    protected override void OnButtonClicked()
    {
        _target.TakeDamage(_damageAmount);
    }
}

using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Healer : HealthButton
{
    [SerializeField] private int _healAmount = 10;

    protected override void OnButtonClicked()
    {
        _target.TakeHeal(_healAmount);
    }
}

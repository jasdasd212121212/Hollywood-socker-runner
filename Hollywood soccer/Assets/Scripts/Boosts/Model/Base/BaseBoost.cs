using System;
using UnityEngine;

public abstract class BaseBoost : MonoBehaviour
{
    private SignatureMarcup_Player _player;
    private BaseBoostSettings _selfSettings;

    private bool _activated;

    protected SignatureMarcup_Player Player => _player;
    protected BaseBoostSettings Settings => _selfSettings;

    public event Action activated;
    public event Action deactivated;

    public void SetUp(SignatureMarcup_Player player, BaseBoostSettings settings)
    {
        _player = player;
        _selfSettings = settings;

        OnSettedUp();
    }

    public void Activate()
    {
        if (_activated == true)
        {
            return;
        }

        OnActivate();
        activated?.Invoke();

        Invoke(nameof(Deactivete), _selfSettings.Duratiuon);

        _activated = true;
    }

    public void Deactivete()
    {
        _activated = false;

        OnDeactivate();
        deactivated?.Invoke();
    }

    protected abstract void OnActivate();
    protected virtual void OnDeactivate() { }
    protected virtual void OnSettedUp() { }
}
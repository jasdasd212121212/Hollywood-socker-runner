using UnityEngine;
using System;

public abstract class BaseBoostSettings : ScriptableObject
{
    [SerializeField] private BaseBoost _provider;

    [Space]

    [SerializeField] private float _duratiuon;

    public BaseBoost ProviderPrefab => _provider;
    public float Duratiuon => _duratiuon;

    protected abstract Type ProviderType { get; }

    protected void OnValidate()
    {
        Validate();

        if (_provider != null && ProviderType != _provider.GetType())
        {
            Debug.LogError($"Validation error -> can`t set a provider with type: {_provider.GetType()} because SO: {this.name} requires {ProviderType}");
            _provider = null;
        }
    }

    protected virtual void Validate() { }
}
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SignatureMarcup_Player))]
public class BoostsRouter : MonoBehaviour
{
    [SerializeField] private BaseBoostSettings[] _boostsSettings;

    private Dictionary<BaseBoostSettings, BaseBoost> _boosts = new Dictionary<BaseBoostSettings, BaseBoost>();

    private SignatureMarcup_Player _self;
    private MonoFactory<BaseBoost> _boostsFactory;

    private void Start()
    {
        _boostsFactory = new MonoFactory<BaseBoost>(); 
        _self = GetComponent<SignatureMarcup_Player>();

        foreach (BaseBoostSettings boostSettings in _boostsSettings)
        {
            BaseBoost boost = _boostsFactory.Create(boostSettings.ProviderPrefab);
            boost.transform.SetParent(_self.transform);
            boost.transform.localPosition = Vector3.zero;

            boost.SetUp(_self, boostSettings);

            _boosts.Add(boostSettings, boost);
        }
    }

    public void ActivateBoost(BaseBoostSettings boost) => GetBoost(boost).Activate();
    public void DeactivateBoost(BaseBoostSettings boost) => GetBoost(boost).Deactivete();

    private BaseBoost GetBoost(BaseBoostSettings settings) => _boosts[settings];
}
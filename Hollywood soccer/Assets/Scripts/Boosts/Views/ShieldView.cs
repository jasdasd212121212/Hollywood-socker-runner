using UnityEngine;

[RequireComponent(typeof(ShieldBoost))]
public class ShieldView : MonoBehaviour
{
    [SerializeField] private GameObject _shieldGameObject;

    private ShieldBoost _shieldBoost;

    private void Awake()
    {
        _shieldBoost = GetComponent<ShieldBoost>();

        _shieldBoost.activated += OnActivated;
        _shieldBoost.deactivated += OnDisactivated;

        _shieldGameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        _shieldBoost.activated -= OnActivated;
        _shieldBoost.deactivated -= OnDisactivated;
    }

    private void OnActivated()
    {
        _shieldGameObject.SetActive(true);
    }

    private void OnDisactivated()
    {
        _shieldGameObject.SetActive(false);
    }
}
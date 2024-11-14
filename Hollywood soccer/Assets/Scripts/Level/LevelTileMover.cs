using UnityEngine;
using Zenject;

[RequireComponent(typeof(ZenAutoInjecter))]
public class LevelTileMover : MonoBehaviour
{
    [Inject] private SpeedContainer _speedContainer;

    private Transform _cachedTransform;

    private void Awake()
    {
        _cachedTransform = transform;
    }

    private void Update()
    {
        _cachedTransform.Translate(Vector3.down * _speedContainer.Speed * Time.deltaTime);
    }
}
using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CollectableBoostView : MonoBehaviour, ICollacteble
{
    [SerializeField] private BaseBoostSettings _boost;

    public event Action<int> collectedWithScore;
    public event Action collected;

    public BaseBoostSettings GetBoost()
    {
        collectedWithScore?.Invoke(0);
        collected?.Invoke();

        return _boost;
    }
}
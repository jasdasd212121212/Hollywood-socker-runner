using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Ball : MonoBehaviour, ICollacteble
{
    [SerializeField] private BallSettings _settings;

    public event Action<int> collectedWithScore;
    public event Action collected;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<SignatureMarcup_Player>() != null)
        {
            collectedWithScore?.Invoke(_settings.CollectCost);
            collected?.Invoke();

            Destroy(gameObject);
        }
    }
}
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D), typeof(BoostsRouter))]
public class BoostCollector : MonoBehaviour
{
    private BoostsRouter _router;

    private void Awake()
    {
        _router = GetComponent<BoostsRouter>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out CollectableBoostView boost))
        {
            _router.ActivateBoost(boost.GetBoost());
            Destroy(boost.gameObject);
        }
    }
}
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Damager : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<IKIllable>(out IKIllable killable))
        {
            killable.Kill();
        }
    }
}
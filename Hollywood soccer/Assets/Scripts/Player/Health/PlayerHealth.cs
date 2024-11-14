using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D))]
public class PlayerHealth : MonoBehaviour, IKIllable
{
    protected bool _isImmortality;

    public event Action dead;

    private void Awake()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    public void Kill()
    {
        if (_isImmortality == true)
        {
            return;
        }

        dead?.Invoke();
    }

    public void SetImmortality(bool state)
    {
        _isImmortality = state;
    }
}
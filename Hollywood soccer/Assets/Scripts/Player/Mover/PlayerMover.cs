using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private PlayerMoverSettings _settings;

    [Inject] private IDirectionInputSystem _inputSystem;

    private Rigidbody2D _rigidbody;

    private Vector2 _lastInput;
    private bool _moved;

    private float _aditionalMoveSpeed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        _inputSystem.moved += OnInput;
    }

    private void OnDestroy()
    {
        _inputSystem.moved -= OnInput;
    }

    private void FixedUpdate()
    {
        if (_moved == true)
        {
            _lastInput = Vector2.zero;
        }

        _rigidbody.MovePosition(_rigidbody.position + _lastInput.normalized * (_settings.StrafeMoveSpeed + _aditionalMoveSpeed) * Time.fixedDeltaTime);
    
        _moved = true;
    }

    public void IncreaseSpeed(float speed)
    {
        if (speed < 0)
        {
            Debug.Log($"Critical error -> invalid speed value: {speed}");
            return;
        }

        _aditionalMoveSpeed += speed;
    }

    public void DecreaseSpeed(float speed)
    {
        if (speed < 0)
        {
            Debug.Log($"Critical error -> invalid speed value: {speed}");
            return;
        }

        _aditionalMoveSpeed -= speed;
    }

    private void OnInput(Vector2 input)
    {
        _lastInput = input;
        _moved = false;
    }
}
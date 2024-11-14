using UnityEngine;
using Zenject;

[RequireComponent(typeof(PlayerMover))]
public class PlayerStateMachine : MonoBehaviour
{
    [SerializeField] private GameObject _killablePlayerGameObject;
    [Inject] private IDirectionInputSystem _directionInputSystem;

    private IKIllable _killable;
    private PlayerMover _mover;

    private PlayerActiveState _activeState;
    private PlayerInactiveState _inactiveState;
    private PlayerDeadState _deadState;

    private StateMachine _stateMachine;

    public IReadOnlyStateMachine StateMachine => _stateMachine;

    private void OnValidate()
    {
        if (_killablePlayerGameObject != null)
        {
            if (_killablePlayerGameObject.GetComponent<IKIllable>() == null)
            {
                Debug.LogError($"Crtitical error -> can`t set a gameObject: {_killablePlayerGameObject.name} because it non contains any script realises: {nameof(IKIllable)} interface");
                _killablePlayerGameObject = null;
            }
        }
    }

    private void Awake()
    {
        _mover = GetComponent<PlayerMover>();
        _killable = _killablePlayerGameObject.GetComponent<IKIllable>();

        _activeState = new PlayerActiveState(_mover);
        _inactiveState = new PlayerInactiveState(_mover);
        _deadState = new PlayerDeadState();

        _stateMachine = new StateMachine(_activeState, _inactiveState, _deadState);

        _directionInputSystem.moved += OnStart;
        _killable.dead += OnDead;

        SetPlayerActive(false);
    }

    private void OnDestroy()
    {
        _directionInputSystem.moved -= OnStart;
        _killable.dead -= OnDead;
    }

    private void OnStart(Vector2 v)
    {
        SetPlayerActive(true);
    }

    private void OnDead()
    {
        SetPlayerActive(false);
        _stateMachine.ChangeState(_deadState);
    }

    private void SetPlayerActive(bool state)
    {
        if (state == true)
        {
            _stateMachine.ChangeState(_activeState);
        }
        else
        {
            _stateMachine.ChangeState(_inactiveState);
        }
    }
}
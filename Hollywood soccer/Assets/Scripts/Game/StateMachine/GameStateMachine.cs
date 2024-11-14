using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameStateMachine : MonoBehaviour
{
    [SerializeField] private GameObject[] _lockersGameObjects;

    [Inject] private PlayerStateMachine _playerStateMachine;
    [Inject] private IDirectionInputSystem _directionInputSystem;
    [Inject] private SpeedContainer _speedContainer;

    private GameplayState _gameplayState;
    private GameOverState _gameOverState;
    private LockedGameState _lockedGameState;

    private StateMachine _stateMachine;

    private ILocker[] _lockers;

    public IReadOnlyStateMachine StateMachine => _stateMachine;

    private void OnValidate()
    {
        if (_lockersGameObjects != null && _lockersGameObjects.Length != 0)
        {
            List<GameObject> valid = new List<GameObject>();

            foreach (GameObject current in _lockersGameObjects)
            {
                if (current.GetComponent<ILocker>() == null)
                {
                    Debug.LogError($"Ciritcal error -> invalid gameObject: {current}; Need {nameof(ILocker)}");
                }
                else
                {
                    valid.Add(current);
                }
            }

            _lockersGameObjects = valid.ToArray();
        }
    }

    private void Awake()
    {
        _lockers = new ILocker[_lockersGameObjects.Length];

        for (int i = 0; i < _lockersGameObjects.Length; i++)
        {
            _lockers[i] = _lockersGameObjects[i].GetComponent<ILocker>();
        }

        foreach (ILocker locker in _lockers)
        {
            locker.started += OnLock;
            locker.compleated += OnUnloack;
        }

        _gameplayState = new GameplayState();
        _gameOverState = new GameOverState(_directionInputSystem, _speedContainer);
        _lockedGameState = new LockedGameState(_directionInputSystem, _speedContainer);

        _stateMachine = new StateMachine(_gameplayState, _gameOverState, _lockedGameState);
    }

    private void Start()
    {
        _playerStateMachine.StateMachine.GetState<PlayerDeadState>().entered += OnDead;
    }

    private void OnDestroy()
    {
        _playerStateMachine.StateMachine.GetState<PlayerDeadState>().entered -= OnDead;

        foreach (ILocker locker in _lockers)
        {
            if (locker == null)
            {
                continue;
            }

            locker.started -= OnLock;
            locker.compleated -= OnUnloack;
        }
    }

    private void OnDead()
    {
        _stateMachine.ChangeState(_gameOverState);
    }

    private void OnLock()
    {
        _stateMachine.ChangeState(_lockedGameState);
    }

    private void OnUnloack()
    {
        if (_stateMachine.CurrentState == _gameOverState)
        {
            return;
        }

        _stateMachine.ChangeState(_gameplayState);
    }
}
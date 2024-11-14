using UnityEngine;

public class GameScreenView : MonoBehaviour
{
    [SerializeField] private GameStateMachine _gameStateMachine;

    [Space]

    [SerializeField] private RectTransform _losePanel;

    private void Start()
    {
        _gameStateMachine.StateMachine.GetState<GameOverState>().entered += OnDead;
    }

    private void OnDestroy()
    {
        _gameStateMachine.StateMachine.GetState<GameOverState>().entered -= OnDead;
    }

    private void OnFinished()
    {
        _losePanel.gameObject.SetActive(false);
    }

    private void OnDead()
    {
        _losePanel.gameObject.SetActive(true);
    }
}
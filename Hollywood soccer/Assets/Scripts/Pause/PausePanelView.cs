using UnityEngine;

public class PausePanelView : MonoBehaviour
{
    [SerializeField] private PauseModel _model;
    [SerializeField] private GameObject _panel;

    private void Awake()
    {
        _model.paused += OnPause;
        _model.resume += OnResume;
    }

    private void OnDestroy()
    {
        _model.paused -= OnPause;
        _model.resume -= OnResume;
    }

    private void OnPause()
    {
        _panel.SetActive(true);
    }

    private void OnResume()
    {
        _panel.SetActive(false);
    }
}
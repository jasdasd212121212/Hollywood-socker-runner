using UnityEngine;

public class TutorialPagesView : MonoBehaviour
{
    [SerializeField] private TutorialModel _model;

    [Space]

    [SerializeField] private GameObject _mainPanel;
    [SerializeField] private GameObject[] _pages;

    private void Awake()
    {
        _model.started += Display;
        _model.next += Display;
        _model.compleated += DisableAll;
    }

    private void OnDestroy()
    {
        _model.started -= Display;
        _model.next -= Display;
        _model.compleated -= DisableAll;
    }

    private void Display()
    {
        DisableAll();
        _pages[_model.CurrentStepIndex].SetActive(true);

        _mainPanel.SetActive(true);
    }

    private void DisableAll()
    {
        foreach (GameObject page in _pages)
        {
            page.SetActive(false);
        }

        _mainPanel.SetActive(false);
    }
}
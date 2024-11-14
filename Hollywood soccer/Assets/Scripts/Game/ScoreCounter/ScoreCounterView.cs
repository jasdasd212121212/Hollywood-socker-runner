using TMPro;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreCounterView : MonoBehaviour
{
    private ScoreCounterModel _scoreCounterModel;
    private TextMeshProUGUI _text;

    [Inject]
    private void Construct(ScoreCounterModel model)
    {
        _scoreCounterModel = model;
        _text = GetComponent<TextMeshProUGUI>();

        _scoreCounterModel.scoreChanged += Display;
    }

    private void OnEnable()
    {
        Display();
    }

    private void OnDestroy()
    {
        _scoreCounterModel.scoreChanged -= Display;
    }

    private void Display()
    {
        _text.text = $"X{_scoreCounterModel.Score}";
    }
}
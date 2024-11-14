using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StatsRecorderModel : ISaveble<StatsRecorderDataTransfreObject>
{
    private ScoreCounterModel _scoreCounterModel;
    private List<int> _history = new List<int>();

    public IReadOnlyList<int> History => _history;

    public event Action dataChanged;

    public StatsRecorderModel(ScoreCounterModel scoreCounterModel) 
    {  
        _scoreCounterModel = scoreCounterModel; 
    }

    public void AddToHistory()
    {
        int score = _scoreCounterModel.Score;

        if (score <= 0)
        {
            return;
        }

        _history.Add(score);

        _history.Sort();
        _history.Reverse();

        dataChanged?.Invoke();
    }

    public int[] GetTop(int count)
    {
        return _history.Take(Mathf.Clamp(count, 0, _history.Count)).ToArray();
    }

    public int[] GetWithExclude(int excludedOfTopCount)
    {
        if (_history.Count < excludedOfTopCount)
        {
            return new int[0];
        }

        int[] result = new int[_history.Count - excludedOfTopCount];

        for (int i = result.Length - 1; i >= 0; i--)
        {
            result[i] = _history[i + excludedOfTopCount];
        }

        return result;
    }

    public StatsRecorderDataTransfreObject GetSaveDataTransferObject()
    {
        _history.Sort();
        _history.Reverse();
        return new StatsRecorderDataTransfreObject(_history.ToArray());
    }

    public void SetData(StatsRecorderDataTransfreObject data)
    {
        _history = data.ScoreHistory.ToList();
    }
}
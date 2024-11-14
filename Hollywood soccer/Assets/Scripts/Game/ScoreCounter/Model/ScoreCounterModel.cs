using Cysharp.Threading.Tasks;
using System;
using System.Linq;
using UnityEngine;

public class ScoreCounterModel
{
    private IReadOnlyLevelGenerator _levelGenerator;
    private ICollacteble[] _collectables;

    public int Score { get; private set; }

    public event Action scoreChanged;

    public ScoreCounterModel(IReadOnlyLevelGenerator levelGenerator)
    {
        _levelGenerator = levelGenerator;

        _levelGenerator.levelTileGenerated += OnGenerateTile;
    }

    ~ScoreCounterModel()
    {
        _levelGenerator.levelTileGenerated -= OnGenerateTile;
    }

    public void Reset()
    {
        Score = 0;
        scoreChanged?.Invoke();
    }

    private void OnGenerateTile(LevelGeneratorLine[] lines)
    {
        if (_collectables != null)
        {
            UnsubscribeCollectables();
        }

        _collectables = GameObject.FindObjectsOfType<Transform>().Where(obj => obj.GetComponent<ICollacteble>() != null).Select(obj => obj.GetComponent<ICollacteble>()).ToArray();
        SubscribeCollectables();
    }

    private void SubscribeCollectables()
    {
        foreach (ICollacteble collectable in _collectables)
        {
            collectable.collectedWithScore += OnCollect;
        }
    }

    private void UnsubscribeCollectables()
    {
        foreach (ICollacteble collectable in _collectables)
        {
            if (collectable != null)
            {
                collectable.collectedWithScore -= OnCollect;
            }
        }
    }

    private void OnCollect(int score)
    {
        Score += score;
        scoreChanged?.Invoke();
    }
}
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class LevelGeneratorModel : IReadOnlyLevelGenerator
{
    private LevelGeneratorSettings _settings;
    private Transform[] _points;

    public event Action<LevelGeneratorLine[]> levelTileGenerated;

    public LevelGeneratorModel(LevelGeneratorSettings settings)
    {
        _settings = settings;
    }

    private void Initialize()
    {
        _points = GameObject.FindObjectsOfType<SignatureMarcup_LevelLineCenterPoint>().Select(point => point.transform).ToArray();
    }

    public void Generate()
    {
        Initialize();

        List<LevelGeneratorLine> lines = new List<LevelGeneratorLine>();

        foreach (Transform point in _points)
        {
            int enemyesCount = Random.Range(_settings.MinEnemyesPerLine, _settings.MaxEnemyesPerLine);
            int collectablesCount = Random.Range(_settings.MinCollectablesPerLine, _settings.MaxCollectablesPerLine);

            lines.Add(new LevelGeneratorLine(
                    GenerateCollectables(collectablesCount, point.position),
                    GeneratePositions(enemyesCount, point.position)
                ));
        }

        levelTileGenerated?.Invoke(lines.ToArray());
    }

    private Vector3[] GeneratePositions(int count, Vector3 basePoint)
    {
        Vector3[] result = new Vector3[count];

        for (int i = 0; i < count; i++)
        {
            result[i] = basePoint + Vector3.right * Random.Range(-_settings.Offset, _settings.Offset);
        }

        return result;
    }

    private Dictionary<Vector3, int> GenerateCollectables(int count, Vector3 point)
    {
        Dictionary<Vector3, int> result = new Dictionary<Vector3, int>();

        Vector3[] postions = GeneratePositions(count, point);
        int[] indexes = new int[count];

        indexes[0] = 0;

        for (int i = 1; i < indexes.Length; i++)
        {
            indexes[i] = Random.Range(0, _settings.CollectablesCount);
        }

        for (int i = 0; i < count; i++)
        {
            result.Add(postions[i], indexes[i]);
        }

        return result;
    }
}
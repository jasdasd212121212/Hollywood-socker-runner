using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LevelGeneratorLine
{
    public Dictionary<Vector3, int> CollectablesPositions { get; private set; }
    public Vector3[] EnemyesPositions { get; private set; }
    
    public LevelGeneratorLine(Dictionary<Vector3, int> collectablesPositions, Vector3[] enemyesPositions)
    {
        CollectablesPositions = collectablesPositions;
        EnemyesPositions = enemyesPositions;
    }
}
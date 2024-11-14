using System;
using UnityEngine;

[Serializable]
public class StatsRecorderDataTransfreObject
{
    [SerializeField] private int[] _scoreHistory;

    public int[] ScoreHistory => _scoreHistory;

    public StatsRecorderDataTransfreObject(int[] scoreHistory)
    {  
        _scoreHistory = scoreHistory; 
    }    
}